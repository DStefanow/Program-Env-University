using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static Dictionary<Activities, string> activitiesDescription = new Dictionary<Activities, string>();

        public static void LogActivity(Activities activityId, string activity)
        {
            string activityLine = DateTime.Now + " ; " + LoginValidation.currentUserUsername + " ; " +
                LoginValidation.currentUserRole + " ; " + activity + "\r\n";

            Logger.activitiesDescription.Add(activityId, activityLine);

            Logger.currentSessionActivities.Add(activityLine);
            
            string filePath = @"..\..\..\activity.txt";
            if (File.Exists(filePath))
            {
                File.AppendAllText(filePath, activityLine);

                if (activityId != 0)
                {
                    Console.WriteLine(activityLine);
                }
            }
        }

        public static void GetCurrentSessionActivies(string filter)
        {
            StringBuilder allText = new StringBuilder();

            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();

            foreach (string currentLine in filteredActivities)
            {
                allText.Append(currentLine);
            }

            Console.WriteLine(allText);
        }
    }
}
