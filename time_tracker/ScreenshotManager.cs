using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

using System.Configuration;
using System.IO;
using log4net;
using System.Windows.Forms;
using System.Threading;

namespace time_tracker
{
    public class ScreenshotManager
    {
        private String outputFolderPath = "";
        private String companyName = "";
        private String officeName = "";
        private String computerName = "";

        private static bool isStopped = false;

        private static readonly ILog logger =
          LogManager.GetLogger(typeof(ScreenshotManager));

        public ScreenshotManager(String outputPath)
        {
            outputFolderPath = outputPath;
        }

        public ScreenshotManager()
        {
            outputFolderPath = ConfigurationManager.AppSettings["localCacheFolder"];
            companyName = ConfigurationManager.AppSettings["companyName"];
            officeName = ConfigurationManager.AppSettings["officeName"];
            computerName = ConfigurationManager.AppSettings["computerName"];

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

        public static void takeScreenshot(String path)
        {
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                               Screen.PrimaryScreen.Bounds.Height,
                               PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save(path, ImageFormat.Png);
        }


        //take screenshots every 3 seconds if user is active in the last minute
        public void takeScreenShots()
        {            
            StringBuilder outputStringBuilder = new StringBuilder();            

            while (!isStopped)
            {
                try
                {               
                    String currentTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");                                    
                    String filename = "screenshot_" + currentTime + ".png";

                    //one minute of inactivity
                    if (UserInteractionManager.GetLastInputTime() < 60)
                    {
                        Console.WriteLine("Taking screenshot...");
                        takeScreenshot(outputFolderPath + "/" + filename);
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

        public static void stop()
        {
            if (!isStopped)
            {
                isStopped = true;
            }
        }
    }
}
