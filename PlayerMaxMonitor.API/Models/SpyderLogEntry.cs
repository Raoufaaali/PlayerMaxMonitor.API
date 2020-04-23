using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerMaxMonitor.API.Models
{
    public class SpyderLogEntry
    {
        public int Id { get; set; }
        public string Call { get; set; }
        public bool isSuccess { get; set; }
        public int ResponseCode { get; set; }
        public DateTime Timestamp { get; set; }
        public int ElapsedMS { get; set; }
        public int LatencyMS { get; set; }
        public string URL { get; set; }
        public string ResosnseMessage { get; set; }

    }
}