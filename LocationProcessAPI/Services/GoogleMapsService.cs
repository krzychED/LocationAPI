using LocationProcessAPI.Models;
using System;
using System.IO;
using System.Net;

namespace LocationProcessAPI.Services
{
    public class GoogleMapsService
    {
        public static string GetPlaceFromMapsAPI(Location location)
        {
            string requestUrl="";
            string responseText = "";
            Config mapsApiFromConfig = MessageSender.LoadConfigurationFile();
            if ((mapsApiFromConfig.mapsUrl != null) && (mapsApiFromConfig.mapsKey != null))
            {
                requestUrl = mapsApiFromConfig.mapsUrl +"&&"+ mapsApiFromConfig.mapsKey;
                requestUrl = string.Format(requestUrl, location.latitude, location.longitude);

                try
                {
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
                    webRequest.Method = "GET";
                    webRequest.ContentType = "application/json";

                    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                    responseText = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
                    webResponse.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(responseText);
                return responseText;
            }
            return responseText;
        }
    }
}