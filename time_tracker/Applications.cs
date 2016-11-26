using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;


namespace time_tracker
{
    class Applications
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);    

        public string GetApp()
        {

            string Application = "empty";
            const int nChars = 256;
            try
            {
                StringBuilder Buff = new StringBuilder(nChars);
                IntPtr handle = GetForegroundWindow();
                //getting active process
                // Process currentProcess = Process.GetCurrentProcess();
                //if process exists
                if (GetWindowText(handle, Buff, nChars) > 0)
                {
                    Application = Buff.ToString();
                    return Application;
                }
            }
            catch (Exception GetApp)
            {
                Console.WriteLine("Error In Getting current App"+ GetApp);
            }
            return Application;
        }





        public bool FileExplorerCheck(string Current)
        {
            //getting current application title
            string CurrentApplication = Current;
            bool flag = false;
            try
            {
                //Check if process name is file explorer
                SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
                string filename;
                ArrayList windows = new ArrayList();
                foreach (SHDocVw.InternetExplorer ie in shellWindows)
                {
                    filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                    if (filename.Equals("explorer"))
                    {
                        if (CurrentApplication == ie.LocationName.ToString())
                        {
                            flag = true;
                        }
                    }
                }
            }
            catch (Exception FileExplorerCheck)
            {
                Console.WriteLine("Error In Checking File Explorer is current"+ FileExplorerCheck);
            }
            return flag;
        }



        public string GetFileExplorerURL()
        {
            string URL = "empty";

            try
            {
                var AppInstance = new Applications();
                //getting current application title
                string CurrentApplication = AppInstance.GetApp();
                //Check if process name is file explorer
                SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
                string filename;
                ArrayList windows = new ArrayList();
                foreach (SHDocVw.InternetExplorer ie in shellWindows)
                {
                    filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                    if (filename.Equals("explorer"))
                    {
                        if (CurrentApplication == ie.LocationName.ToString())
                        {
                            URL = ie.LocationURL.ToString();
                        }
                    }
                }
            }
            catch (Exception explorerURL)
            {
                Console.WriteLine("Error In Getting File Explorer URL"+ explorerURL);
            }
            return URL;
        }

        public string getCurrentApp()
        {
            string currentApp = GetApp();
            string response = null;
            try
            {
                if (FileExplorerCheck(currentApp))
                {
                    response = GetFileExplorerURL();
                }
                else
                {
                    response = currentApp;
                }

                if (response == null || response == "")
                {
                    response = "empty";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error In Getting Current Application Info"+ e);
            }
            return response;
        }


    }


}

