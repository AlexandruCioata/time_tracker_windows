using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApplication2
{
    class currentAppName
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public string getCurrentAppName()
        {
            var appName = "null";

            try
            {
                IntPtr hWnd = GetForegroundWindow();
                uint procId = 0;
                GetWindowThreadProcessId(hWnd, out procId);
                var proc = Process.GetProcessById((int)procId);
                appName = proc.MainModule.ModuleName;
            }
            catch
            {
                appName = "null";

            }

            return appName;
        }


    }
}
