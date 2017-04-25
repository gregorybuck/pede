using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatriciaEdgarAndDonEdgar.Models;

namespace PatriciaEdgarAndDonEdgar.Common
{
    public static class Utils
    {
        public static bool doVisitLogging;
        public static bool doIPTranslate;
        public static String removeEverythingbutAlphaNum(String str)
        {
            if (String.IsNullOrEmpty(str)) return (str);
            String removedEverythingbutAlphaNum = System.Text.RegularExpressions.Regex.Replace(str, "[^a-zA-Z0-9]+", "");
            return removedEverythingbutAlphaNum;
        }
        public static String removeWhitespace(String str)
        {
            if (String.IsNullOrEmpty(str)) return (str);
            String removedWhitespace = str.Replace(" ", String.Empty);
            return removedWhitespace;
        }
        public static void Log(string logMessage, System.IO.TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }

    public static class Datahandler
    {
        public static void logVisit(String page, String ip, String a, String b,String c,String d, String e)
        {
            PatriciaEdgarAndDonEdgar.Models.ipinfo ipInfo = new PatriciaEdgarAndDonEdgar.Models.ipinfo();
            try
            {
                if (PatriciaEdgarAndDonEdgar.Common.Utils.doIPTranslate)
                {
                    ipInfo = PatriciaEdgarAndDonEdgar.Common.GEOip.getIPInfo(ip);
                }
                if (PatriciaEdgarAndDonEdgar.Common.Utils.doVisitLogging)
                {
                    String country = ipInfo.country.name;
                    String region = ipInfo.country.code;
                    String city = ipInfo.city;
                    String zip = ipInfo.location.time_zone;
                    String latlong = ipInfo.location.latitude + "|" + ipInfo.location.longitude;
                    using (dbDatahandlerEntities db = new dbDatahandlerEntities())
                    {
                        //save visit data via stored proc..
                        db.usp_VisitLogSet(page, ip, country, region, city, zip, latlong);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}