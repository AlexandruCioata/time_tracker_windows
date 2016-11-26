using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using log4net;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Collections.Concurrent;

namespace time_tracker
{

    public class UserInteractionManager
    {
        private static String outputFolderPath = "";
        private static String companyName = "";
        private static String officeName = "";
        private static String computerName = "";

        private static bool isStopped = false;

        public static ConcurrentStack<DataCollectionStructure> synchronizedCollectedResults;

        private static readonly ILog logger =
          LogManager.GetLogger(typeof(UserInteractionManager));

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public static void Init()
        {
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
        public static void Run()
        {
            Init();
            RunPCInteractionListener();
        }

        public static ConcurrentStack<DataCollectionStructure> getDataAndResetCollector()
        {

            ConcurrentStack<DataCollectionStructure> result =
                new ConcurrentStack<DataCollectionStructure>(synchronizedCollectedResults);
            synchronizedCollectedResults.Clear();

            return result;
        }

        static void RunPCInteractionListener()
        {

            String lastActivity = "";
            String currentActivity = "";
            StringBuilder outputStringBuilder = new StringBuilder();
            //String lastMinuteFilename = "chunk#4_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
            String lastMinuteFilename = "pcinteractionlog_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm");

            while (!isStopped)
            {
                try
                {

                    //added for testing!!
                    String output = "";

                    if(UserInteractionManager.GetLastInputTime() < 60)
                    {
                        output = "[**Activity**]";
                    }
                    else
                    {
                        output = "[**Inactivity**]";
                    }

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







                    String currentTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    String currentTimeMinutePrecision = currentTime.Substring(0, currentTime.LastIndexOf("_"));
                    //String filename = "chunk#4_" + currentTimeMinutePrecision;
                    String filename = "pcinteractionlog_" + currentTimeMinutePrecision;

                    if (filename.Equals(lastMinuteFilename))
                    {

                        //one minute of inactivity
                        if (UserInteractionManager.GetLastInputTime() < 60)
                        {

                            currentActivity = "[**Activity**]";
                            Console.WriteLine("[**Activity**]");
                            if (!lastActivity.Equals(currentActivity))
                            {
                                String line = "[**Output**]";
                                line += "[" + currentTime + "]";
                                line += "\n";

                                line += currentActivity;

                                line += "\n";

                                outputStringBuilder.Append(line);
                                lastActivity = currentActivity;

                                logger.Info(line);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Inactivity...");
                            currentActivity = "[**Inactivity**]";

                            if (!lastActivity.Equals(currentActivity))
                            {
                                String line = "[**Output**]";
                                line += "[" + currentTime + "]";
                                line += "\n";
                                line += "[**Inactivity**]";
                                line += "\n";

                                outputStringBuilder.Append(line);
                                lastActivity = currentActivity;

                                logger.Info(line);
                            }
                        }

                    }
                    else
                    {

                        String outputLine = "";
                        String toStringBuilder = outputStringBuilder.ToString();

                        if (toStringBuilder.Length > 0)
                        {

                            //including computer information firstly
                            String companyInfo = "company:" + companyName + "\n";
                            companyInfo += "office:" + officeName + "\n";
                            companyInfo += "computer:" + computerName + "\n";

                            outputLine = companyInfo + toStringBuilder;

                            //encrypt current line before writing it to file
                            //String chunkedData = XorEncrypt.Encrypt(outputLine);

                            //write this output from current minute to file
                            writeDataToFile(outputFolderPath + "/" + lastMinuteFilename, outputLine);
                            //writeDataToFile(outputFolderPath + "/" + lastMinuteFilename, chunkedData);

                            //reset variables to process next minute
                            //lastMinuteFilename = filename;

                            outputStringBuilder.Clear();
                        }

                        //reset variables to process next minute
                        lastMinuteFilename = filename;

                    }

                }
                catch (Exception e)
                {
                    logger.Error("Error in ActivityTracker: ", e);
                }


                try
                {
                    Thread.Sleep(3000);
                }
                catch (Exception e)
                {
                    logger.Error("Error in ActivityTracker: ", e);
                }
            }
        }

        private static void writeDataToFile(String filename, String stringData)
        {
            using (var fileStream = new FileStream(filename,
                FileMode.Create,
                FileAccess.ReadWrite,
                FileShare.None))
            using (var sw = new StreamWriter(fileStream))
            {
                sw.Write(stringData);
            }
        }

        public static uint GetLastInputTime()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }

        public static void stop()
        {
            if (!isStopped)
            {
                isStopped = true;
            }
        }


    }
}
