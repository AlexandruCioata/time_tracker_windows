using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Renci.SshNet;
using Renci.SshNet.Common;
using Renci.SshNet.Sftp;
using System.Configuration;
using System.Xml;
using System.Collections.Specialized;

using log4net;
using log4net.Config;
using System.Threading;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using Gma.System.MouseKeyHook;
using System.Security.Permissions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Concurrent;

namespace time_tracker
{

    public class MainApplication
    {
        private static Boolean isStarted = false;
        private ActivityTracker activityTracker;    
        private ScreenshotManager screenshotManager;

        public String localCacheFolder = "";
        
        private static readonly ILog logger =
          LogManager.GetLogger(typeof(MainApplication));

        public MainApplication()
        {
            XmlConfigurator.Configure();
            localCacheFolder = ConfigurationManager.AppSettings["localCacheFolder"];
        }

        public void startServices()
        {

            logger.Info("Start services before if");
            if (isStarted == false)
            {

                logger.Info("Start services inside if");
                //start tracking computer activity
                runActivityTrackerService();

                //log user interaction with PC
                runPCInteractionService();

                //take screenshots
                //takeScreenshots();  

                //track all url's accessed by user
                runURLFetcherService();                       

                isStarted = true;
            }

            logger.Info("Start services after if");
        }

        public void runActivityTrackerService()
        {
            activityTracker = new ActivityTracker();
            Thread activityTrackerThread = new Thread(
                 new ThreadStart(activityTracker.trackActivity));
            activityTrackerThread.Start();
        }

        public void runPCInteractionService()
        {
            Thread userInteractionThread = new Thread(
                 new ThreadStart(UserInteractionManager.Run));
            userInteractionThread.Start();
        }

        public void runURLFetcherService()
        {
            Thread urlFetcherThread = new Thread(
                        new ThreadStart(URLFetcher.Run));
            urlFetcherThread.Start();
        }

        public void takeScreenshots()
        {
            screenshotManager = new ScreenshotManager();
            Thread screenshotServiceThread = new Thread(
                new ThreadStart(screenshotManager.takeScreenShots));
            screenshotServiceThread.Start();
        }

        public void getData()
        {
            ConcurrentStack<DataCollectionStructure> activityTrackerData =
                ActivityTracker.getDataAndResetCollector();
            ConcurrentStack<DataCollectionStructure> userInteractionData =
                UserInteractionManager.getDataAndResetCollector();
            ConcurrentStack<DataCollectionStructure> urlFetcherService =
              URLFetcher.getDataAndResetCollector();

            IEnumerator<DataCollectionStructure> activityTrackerDataIterator = activityTrackerData.GetEnumerator();
            IEnumerator<DataCollectionStructure> userInteractionDataIterator = userInteractionData.GetEnumerator();
            IEnumerator<DataCollectionStructure> urlFetcherServiceIterator = urlFetcherService.GetEnumerator();

            String data = "Activity Tracker: \r\n";
            while(activityTrackerDataIterator.MoveNext())
            {
                data += activityTrackerDataIterator.Current.ToString();
            }

            data += "\r\nUserInteraction:\r\n";            
            while (userInteractionDataIterator.MoveNext())
            {
                data += userInteractionDataIterator.Current.ToString();
            }

            data += "\r\nURL fetcher:\r\n";
            while (urlFetcherServiceIterator.MoveNext())
            {
                data += urlFetcherServiceIterator.Current.ToString();
            }

            ScreenshotManager.takeScreenshot(localCacheFolder + "/photo.jpg");

            writeDataToFile(localCacheFolder + "/fisier.txt", data);           
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

        public void stopServices()
        {
            ActivityTracker.stop();
            ScreenshotManager.stop();
            UserInteractionManager.stop();
            URLFetcher.stop();

            isStarted = false;
        }
    }
}
