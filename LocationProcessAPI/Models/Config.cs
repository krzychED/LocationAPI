using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationProcessAPI.Models
{
    public class Config
    {
        public string username;
        public string password;
        public string mapsUrl;
        public string mapsKey;

        public Config()
        {
        }

        public Config(string username, string password, string mapsUrl, string mapsKey)
        {
            this.username = username;
            this.password = password;
            this.mapsUrl = mapsUrl;
            this.mapsKey = mapsKey;
        }

    }
}