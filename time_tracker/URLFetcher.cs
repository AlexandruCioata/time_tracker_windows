using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using System.ComponentModel;
using Accessibility;

using System.IO;
using System.Timers;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;

using log4net;
using System.Collections.Concurrent;

namespace time_tracker
{
    public static class URLFetcher
    {
        private static string previousURL = "";
        private static string currentURL = "";

        private static long startEventTime = 0;
        private static long stopEventTime = 0;
        private static long elapsedTime = 0;

        private static long EVENT_URL_TIMEOUT = 1000;

        private static String lastMinuteFilename = "";
        private static StringBuilder outputStringBuilder;

        private static String outputFolderPath = "";
        private static String companyName = "";
        private static String officeName = "";
        private static String computerName = "";

        public static ConcurrentStack<DataCollectionStructure> synchronizedCollectedResults;

        public static volatile bool isStopped = false;

        public static readonly ILog logger =
            LogManager.GetLogger(typeof(URLFetcher));

        [DllImport("oleacc.dll")]
        private static extern uint AccessibleObjectFromEvent(IntPtr hwnd, int dwObjectID, int dwChildID,
   out IAccessible ppacc, [MarshalAs(UnmanagedType.Struct)] out object pvarChild);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("GetURLLib.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        static extern string getURLFromBrowser(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);


        //main entrance in Class
        public static void Run()
        {
            Init();

            SubscribeToWindowEvents();

            EventLoop.Run();
        }


        public static void Init()
        {
            previousURL = "";
            currentURL = "";

            startEventTime = 0;
            stopEventTime = 0;
            elapsedTime = 0;

            EVENT_URL_TIMEOUT = 1000;

            lastMinuteFilename = "";
            outputStringBuilder = new StringBuilder();

            outputFolderPath = ConfigurationManager.AppSettings["localCacheFolder"];
            companyName = ConfigurationManager.AppSettings["companyName"];
            officeName = ConfigurationManager.AppSettings["officeName"];
            computerName = ConfigurationManager.AppSettings["computerName"];

            synchronizedCollectedResults = new ConcurrentStack<DataCollectionStructure>();

            if (!Directory.Exists(outputFolderPath))
            {
                Directory.CreateDirectory(outputFolderPath);
                logger.Info("Directory " + outputFolderPath + " created successfuly!");
            }
            else
            {
                logger.Info("Directory " + outputFolderPath + " already exists!");
            }

            isStopped = false;
        }

        public static void stop()
        {
            if (!isStopped)
            {
                isStopped = true;
            }
        }


        public static ConcurrentStack<DataCollectionStructure> getDataAndResetCollector()
        {
            ConcurrentStack<DataCollectionStructure> result =
                new ConcurrentStack<DataCollectionStructure>(synchronizedCollectedResults);
            synchronizedCollectedResults.Clear();

            return result;
        }

        public delegate void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        public static WinEventProc procHandler;

        public static void SubscribeToWindowEvents()
        {
            procHandler = new WinEventProc(WindowEventCallback);

            //logger.Info("Subscribe - Before if");
            if (windowEventHook == IntPtr.Zero)
            {
                windowEventHook = SetWinEventHook(
                    EVENT_OBJECT_FOCUS, // eventMin
                    EVENT_OBJECT_VALUECHANGE, // eventMax
                    IntPtr.Zero,             // hmodWinEventProc
                    procHandler,     // lpfnWinEventProc
                    0,                       // idProcess
                    0,                       // idThread
                    WINEVENT_SKIPOWNPROCESS);

                //logger.Info("Subscribe - Inside if");

                if (windowEventHook == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }

            //logger.Info("Subscribe - after if");
        }

        //private static string GetClassNameOfWindow(IntPtr hwnd)
        //{
        //    string className = "";
        //    StringBuilder classText = null;
        //    try
        //    {
        //        int cls_max_length = 1000;
        //        classText = new StringBuilder("", cls_max_length + 5);
        //        GetClassName(hwnd, classText, cls_max_length + 2);

        //        if (!String.IsNullOrEmpty(classText.ToString()) && !String.IsNullOrWhiteSpace(classText.ToString()))
        //            className = classText.ToString();

        //        classText.Clear();

        //    }
        //    catch (Exception ex)
        //    {
        //        className = ex.Message;
        //    }
        //    finally
        //    {
        //        classText = null;
        //    }
        //    return className;
        //}

        private static string windowEventCallback2(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {


            //C++ code
            //IAccessible* pAcc = NULL;
            IAccessible pAcc = null;

            string result = null;

            //VARIANT varChild;
            object varChild;


            //HRESULT hr = AccessibleObjectFromEvent(hwnd, idObject, idChild, pAcc, varChild);
            uint hr = AccessibleObjectFromEvent(hwnd, idObject, idChild, out pAcc, out varChild);

            if ((hr == 0) && (pAcc != null))
            {
                //BSTR bstrName, bstrValue;
                //pAcc->get_accValue(varChild, &bstrValue);
                //pAcc->get_accName(varChild, &bstrName);

                string bstrName = "";
                string bstrValue = "";

                try
                {
                    if (varChild != null)
                    {

                        //bstrName = pAcc.accValue[varChild];
                        bstrValue = pAcc.get_accValue(varChild);
                        bstrName = pAcc.get_accName(varChild);
                        //bstrValue = pAcc.accName[varChild];
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }

                if (bstrValue != null && !bstrValue.Equals(""))
                {
                    //Console.WriteLine(bstrValue);
                }

                //string className = "";

                //if (isIEServerWindow(hwnd))
                //{
                //    //Console.WriteLine("CEVA");
                //}

                //GetClassNameOfWindow(hwnd);

                StringBuilder sb = new StringBuilder(200);
                GetClassName(hwnd, sb, 100);
                sb.Clear();



                //if (classText != null)
                //{

                //    Console.WriteLine(classText);
                //    //if (!String.IsNullOrEmpty(classText) &&
                //    //!String.IsNullOrWhiteSpace(classText))
                //    //    className = classText;

                //}

                //if (className.Equals("Chrome_WidgetWin_1") && bstrValue != null && !bstrValue.Equals(""))
                //{
                //    Console.WriteLine(className + " -> " + bstrValue);
                //    //result = bstrValue;
                //}

                //if (className.Equals("MozillaWindowClass") && !bstrValue.Equals(""))
                //{
                //    //Console.WriteLine(className + " -> " + bstrValue);
                //    //result = bstrValue;
                //}

                //if (className.Equals("OperaWindowClass") && !bstrValue.Equals(""))
                //{
                //    //Console.WriteLine(className + " -> " + bstrValue);
                //    //result = bstrValue;
                //}

                //pAcc->Release();


            }
            //C++ code

            return result;
        }

        public static void UnhookFromWindowsEvent()
        {
            UnhookWinEvent(windowEventHook);
            windowEventHook = IntPtr.Zero;
        }

        private static void WindowEventCallback(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {

            if (isStopped == true)
            {
                EventLoop.PostQuitMessage(0);
                UnhookFromWindowsEvent();
            }

            //URLFetcher.logger.Info("Iteration inside messageLoop\r\n");

            if (startEventTime == 0 && stopEventTime == 0)
            {
                lastMinuteFilename = "urlwatcher_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
                outputStringBuilder = new StringBuilder();

                var timeDiff = DateTime.UtcNow - new DateTime(1970, 1, 1);
                var totaltime = timeDiff.TotalMilliseconds;
                startEventTime = (long)totaltime;
                stopEventTime = startEventTime;
            }

            String result = getURLFromBrowser(hWinEventHook, eventType, hwnd, idObject, idChild, dwmsEventTime, dwmsEventTime);
            //String result = windowEventCallback2(hWinEventHook, eventType, hwnd, idObject, idChild, dwmsEventTime, dwmsEventTime);

            if (result != null)
            {
                parseReceivedURL(result);
            }
        }

        private static void parseReceivedURL(string URL)
        {
            currentURL = URL;



            //added for testing!!
            String output = currentURL;

            String last = "";
            if (synchronizedCollectedResults.Count > 0)
            {
                DataCollectionStructure dataCollectionStructure = null;
                synchronizedCollectedResults.TryPeek(out dataCollectionStructure);

                if (dataCollectionStructure != null)
                {
                    last = dataCollectionStructure.data;
                }
            }

            if (last.Equals(output))
            {
                DataCollectionStructure dataCollectionStructure = null;
                synchronizedCollectedResults.TryPop(out dataCollectionStructure);

                if (dataCollectionStructure != null)
                {
                    dataCollectionStructure.counter++;
                    synchronizedCollectedResults.Push(dataCollectionStructure);
                }
            }
            else
            {
                synchronizedCollectedResults.Push(new DataCollectionStructure(output, 1));
            }
            //added for testing!!




            var timeDiff = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var totaltime = timeDiff.TotalMilliseconds;

            stopEventTime = (long)totaltime;

            elapsedTime += stopEventTime - startEventTime;


            if (elapsedTime >= EVENT_URL_TIMEOUT)
            {
                if (!previousURL.Equals(currentURL))
                {
                    writeURLToFile(currentURL);
                    previousURL = currentURL;
                }
            }

            //Console.WriteLine(elapsedTime);

            startEventTime = stopEventTime;
            elapsedTime = 0;

        }

        private static void writeURLToFile(string URL)
        {
            String currentTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            String currentTimeMinutePrecision = currentTime.Substring(0, currentTime.LastIndexOf("_"));
            //String filename = "chunk#3_" + currentTimeMinutePrecision; 
            String filename = "urlwatcher_" + currentTimeMinutePrecision;

            Console.WriteLine("Tracked URL: " + URL);

            if (filename.Equals(lastMinuteFilename))
            {
                String line = "[**Output**]";
                line += "[" + currentTime + "]";
                line += "\n";
                line += URL;
                line += "\n";

                outputStringBuilder.Append(line);
            }
            else
            {
                String outputLine = "";
                String toStringBuilder = outputStringBuilder.ToString();

                if (toStringBuilder.Length > 0)
                {
                    try
                    {
                        StreamWriter outputFile = new StreamWriter(outputFolderPath + "/" + lastMinuteFilename, true);

                        //including computer information firstly
                        String companyInfo = "company:" + companyName + "\n";
                        companyInfo += "office:" + officeName + "\n";
                        companyInfo += "computer:" + computerName + "\n";

                        outputLine = companyInfo + toStringBuilder;

                        //encrypt current line before writing it to file
                        //String chunkedData = XorEncrypt.Encrypt(outputLine);

                        //write this output from current minute to file
                        //writeDataToFile(outputFolderPath + "/" + lastMinuteFilename, outputLine);
                        //writeDataToFile(outputFolderPath + "/" + lastMinuteFilename, chunkedData);

                        //outputFile.WriteLine(chunkedData);
                        outputFile.WriteLine(outputLine);
                        //Console.WriteLine("Written to file!");

                        outputStringBuilder.Clear();

                        outputFile.Close();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception in URLFetcher -> " + e.Message);
                    }

                    lastMinuteFilename = filename;


                    //using (StreamWriter outputFile = new StreamWriter(outputFolderPath + "/" + lastMinuteFilename, true))
                    //{

                    //    //including computer information firstly
                    //    String companyInfo = "company:" + companyName + "\n";
                    //    companyInfo += "office:" + officeName + "\n";
                    //    companyInfo += "computer:" + computerName + "\n";

                    //    outputLine = companyInfo + toStringBuilder;

                    //    //encrypt current line before writing it to file
                    //    String chunkedData = XorEncrypt.Encrypt(outputLine);

                    //    //write this output from current minute to file
                    //    //writeDataToFile(outputFolderPath + "/" + lastMinuteFilename, outputLine);
                    //    //writeDataToFile(outputFolderPath + "/" + lastMinuteFilename, chunkedData);

                    //    outputFile.WriteLine(chunkedData);
                    //    Console.WriteLine("Written to file!");

                    //    outputStringBuilder.Clear();
                    //}

                    //lastMinuteFilename = filename;
                }
            }
        }

        private static IntPtr windowEventHook;


        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWinEventHook(int eventMin, int eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc,
            int idProcess, int idThread, int dwflags);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int UnhookWinEvent(IntPtr hWinEventHook);

        private const int WINEVENT_INCONTEXT = 4;
        private const int WINEVENT_OUTOFCONTEXT = 0;
        private const int WINEVENT_SKIPOWNPROCESS = 2;
        private const int WINEVENT_SKIPOWNTHREAD = 1;

        private const int EVENT_OBJECT_FOCUS = 0x8005;
        private const int EVENT_OBJECT_VALUECHANGE = 0x800E;

        private const int EVENT_SYSTEM_FOREGROUND = 3;
    }

    public static class EventLoop
    {

        public static void Run()
        {
            MSG msg;

            while (true)
            {

                //URLFetcher.logger.Info("EventLoop - before if");
                if (URLFetcher.isStopped)
                    break;
                if (GetMessage(out msg, IntPtr.Zero, 0, 0))
                {

                    //URLFetcher.logger.Info("EventLoop - Inside if");

                    if (msg.Message == WM_QUIT)
                        break;

                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }

                //URLFetcher.logger.Info("EventLoop - after if");

                if (URLFetcher.isStopped)
                    break;
            }

            //URLFetcher.logger.Info("EventLoop - after while");

        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public IntPtr Hwnd;
            public uint Message;
            public IntPtr WParam;
            public IntPtr LParam;
            public uint Time;
            public System.Drawing.Point Point;
        }

        const uint PM_NOREMOVE = 0;
        const uint PM_REMOVE = 1;

        const uint WM_QUIT = 0x0012;


        [DllImport("user32.dll")]
        private static extern bool GetMessage(out MSG lpMsg,
            IntPtr hwnd, uint wMsgFilterMin,
            uint wMsgFilterMax);

        [DllImport("user32.dll")]
        private static extern bool PeekMessage(out MSG lpMsg, IntPtr hwnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
        [DllImport("user32.dll")]
        private static extern bool TranslateMessage(ref MSG lpMsg);
        [DllImport("user32.dll")]
        private static extern IntPtr DispatchMessage(ref MSG lpMsg);
        [DllImport("user32.dll")]
        public static extern void PostQuitMessage(int exitCode);

    }
}
