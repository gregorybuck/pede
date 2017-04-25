using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PatriciaEdgarAndDonEdgar.Common
{
    public static class GEOip
    {
        public static PatriciaEdgarAndDonEdgar.Models.ipinfo getIPInfo(String ipaddress)
        {
            PatriciaEdgarAndDonEdgar.Models.ipinfo ipinfo = new PatriciaEdgarAndDonEdgar.Models.ipinfo();
            String theResponse = string.Empty;
            String restWebServicesEndpointUrl = "http://geoip.nekudo.com/api/" + ipaddress;
            var webRequest = System.Net.WebRequest.Create(restWebServicesEndpointUrl) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Timeout = 5000;
                webRequest.ContentType = "application/json";
            }
            try
            {
                HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                Stream resStream = resp.GetResponseStream();
                //StreamReader reader = new StreamReader(resStream);
                //theResponse = reader.ReadToEnd();

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PatriciaEdgarAndDonEdgar.Models.ipinfo));
                ipinfo = (PatriciaEdgarAndDonEdgar.Models.ipinfo)ser.ReadObject(resStream);

            }
            catch (Exception ex)
            {
                if (ipinfo != null) ipinfo.country.name = ex.Message;
            }
            return ipinfo;
        }
    }
}