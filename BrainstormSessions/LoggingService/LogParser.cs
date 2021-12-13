using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrainstormSessions.LoggingService
{
    public class LogParser
    {
        private static string CurrentDirPath = Directory.GetCurrentDirectory();
        private readonly  string filePath = Path.Combine(CurrentDirPath, "FileSource/logsFile.txt");
        public IList<CustomLog> GetAllLogs()
        {
            var listLogs = new List<CustomLog>();
            string line = "";
            string[] str = new string[5];
            try
            {
                using StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();

            while (line != null)
            {
                str = line.Split(';');
                listLogs.Add(new CustomLog
                {
                    Date = DateTime.Parse(str[0].Substring(0, 19)),
                    Level = str[2],
                    Message = str[5] 
                });

                line = sr.ReadLine();
            }
        }
            catch (Exception e)
            {
               Logger.Error("File can't be parsed!");
            }

            return listLogs;
           
        }
       
    }
}
