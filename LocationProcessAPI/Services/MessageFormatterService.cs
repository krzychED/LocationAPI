using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace LocationProcessAPI.Services
{
    public class MessageFormatterService
    {
        public JObject FormattMessage(string apiResponse)
        {
            JsonFormatter(apiResponse);
            var Jobj = JObject.Parse(apiResponse);

            string placeName = ChangeJsonValueIntoPlaceName(Jobj, "long_name");
            Console.WriteLine(placeName);
            return Jobj;
        }

        public string JsonFormatter(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            var formattedJson = JsonConvert.SerializeObject(parsedJson, Formatting.Indented)
               .Replace(",", "," + Environment.NewLine)
               .Replace("{", "{" + Environment.NewLine)
               .Replace("}", Environment.NewLine + "}")
               .Replace("\r\n", "")
               .Replace("\r\n\r\n", "\r\n");
            return formattedJson;
        }

        public static string ChangeJsonValueIntoPlaceName( JObject jsonObj, string key)
        {
            var jsonObjectKeyList = jsonObj
             .Descendants()
             .Where(json => json is JObject)
             .Select(json => new { ID = (string)json[key] })
             .ToList();

            var id = "";
            
            //Remove null from the list
            jsonObjectKeyList = jsonObjectKeyList.Where(c => c.ID != null).ToList();

            foreach (var longName in jsonObjectKeyList)
            {
                if (longName.ID.Contains("County"))
                {
                    id = longName.ID.Replace(" County", "");
                    return id;
                }
            }
            
            if ( id == "")
            {
                try
                {
                    id = jsonObjectKeyList[3].ID;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("You are in the middle of nowhere");
                    id = jsonObjectKeyList[0].ID;
                }
                return id;
            }

            Console.WriteLine(id);
            return id;
        }
    }
}