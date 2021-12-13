using BrainstormSessions.LoggingService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainstormSessions.Api
{
   
 
    public class LogReports : Controller
    {
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<CustomLog>> Index()
        {
            LogParser parser = new LogParser();
            var res = parser.GetAllLogs();
            return  Ok (res);
        }

        [HttpGet("GetReport1")]
        public ActionResult<IEnumerable<(string, int)>> GetReport1()
        {
            LogParser parser = new LogParser();
            var allLogs = parser.GetAllLogs();
            var res = from l in allLogs
                               group l by l.Level into g
                               select new { Name = g.Key, Count = g.Count() };
            return Ok(res);
        }
    }
}
