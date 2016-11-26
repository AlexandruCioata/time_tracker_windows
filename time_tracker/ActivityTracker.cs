using System;
using System.Threading;
using System.Management;
using System.Configuration;
using System.Text;

using System.IO;
using log4net;
using System.Collections.Concurrent;

namespace time_tracker
{
    public class ActivityTracker
    {
        private String outputFolderPath = "";
        private String companyName = "";
        private String officeName = "";
        private String computerName = "";

        public static ConcurrentStack<DataCollectionStructure> synchronizedCollectedResults;

        public static volatile bool isStopped = false;

        private static readonly ILog logger =
          LogManager.GetLogger(typeof(ActivityTracker));


        public ActivityTracker(String outputPath)
        {
            outputFolderPath = outputPath;
        }

        public ActivityTracker()
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

        public static ConcurrentStack<DataCollectionStructure> getDataAndResetCollector()
        {
            ConcurrentStack<DataCollectionStructure> result = 
                new ConcurrentStack<DataCollectionStructure>(synchronizedCollectedResults);                        
            synchronizedCollectedResults.Clear();

            return result;
        }

        public void trackActivity()
        {
            String lastActivity = "";
            StringBuilder outputStringBuilder = new StringBuilder();
            //String lastMinuteFilename = "chunk#1_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
            String lastMinuteFilename = "activitylog_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm");

            while (!isStopped)
            {                
                try
                {
                    //added for testing!!
                    String output = getCurrentActivity();

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

                    String currentActivity = getCurrentActivity();
                    String currentTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

                    String currentTimeMinutePrecision = currentTime.Substring(0, currentTime.LastIndexOf("_"));
                    //String filename = "chunk#1_" + currentTimeMinutePrecision;
                    String filename = "activitylog_" + currentTimeMinutePrecision;

                    if (filename.Equals(lastMinuteFilename))
                    {

                        //one minute of inactivity
                        if (UserInteractionManager.GetLastInputTime() < 60)
                        {
                            Console.WriteLine("Tracking activity: " + currentActivity);
                            if (!lastActivity.Equals(currentActivity))
                            {
                                                                                   
                                if (!currentActivity.Contains("Google Chrome")  || !currentActivity.Contains("empty"))
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
                        }
                        else
                        {
                            Console.WriteLine("Inactivity...");
                            if (!lastActivity.Equals("[**Inactivity**]"))
                            {
                                String line = "[**Output**]";
                                line += "[" + currentTime + "]";
                                line += "\n";
                                line += "[**Inactivity**]";
                                line += "\n";

                                outputStringBuilder.Append(line);
                                lastActivity = "[**Inactivity**]";


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

        private static void appendData(string filename, string stringData)
        {
            using (var fileStream = new FileStream(filename,
                FileMode.Append,
                FileAccess.Write,
                FileShare.None))
            using (var bw = new BinaryWriter(fileStream))
            {
                bw.Write(stringData);
            }
        }

        private String getCurrentActivity()
        {
            String result = "";

            var CurrentApplication = new Applications();
            result = CurrentApplication.getCurrentApp();

            return result;
        }

        public static void stop()
        {
            if(!isStopped)
            {
                isStopped = true;
            }
        }

    }
}
