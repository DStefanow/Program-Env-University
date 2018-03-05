using System;
using System.Collections.Generic;
using System.IO;

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
            
            string fileName = @"..\..\..\activity.txt";
            if (File.Exists(fileName))
            {
                File.AppendAllText(fileName, activityLine);
            }
        }
    }
}
