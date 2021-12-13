using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainstormSessions.LoggingService
{
    public class CustomLog   
    { 
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
