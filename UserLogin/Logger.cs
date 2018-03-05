using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + " ; " + LoginValidation.currentUserUsername + " ; " +
                LoginValidation.currentUserRole + " ; " + activity + "\r\n";

            Logger.currentSessionActivities.Add(activityLine);
            
            string filePath = @"..\..\..\activity.txt";
            if (File.Exists(filePath))
            {
                File.AppendAllText(filePath, activityLine);
            }
        }

        public static void GetCurrentSessionActivies()
        {
            string filePath = @"..\..\..\activity.txt";
            StreamReader sr = new StreamReader(filePath);

            StringBuilder allText = new StringBuilder();

            int lineCount = 1;
            while (!sr.EndOfStream)
            {
                string line = lineCount + "| " + sr.ReadLine() + "\r\n";
                allText.Append(line);

                lineCount++;
            }

            Console.WriteLine(allText);
        }
    }
}
