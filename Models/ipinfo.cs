using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatriciaEdgarAndDonEdgar.Models
{
    public class ipinfo
    {
        public string city  { get; set; }
        public ipcountry country { get; set; }
        public iplocation location { get; set; }
        public string ip { get; set; }
        public class ipcountry
        {
            public string name { get; set; }
            public string code { get; set; }
        }
        public class iplocation
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string time_zone { get; set; }
        }
    }
}