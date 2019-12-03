using LocationProcessAPI.Models;
using LocationProcessAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LocationProcessAPI.Controllers
{
    public class LocationProcessController : ApiController
    {
        public string Get()
        {
            return "pong";
        }

 
        [HttpPost]
        public JObject PostNewLocation([FromBody]Location location)
        {
            string mapsAPIresponse = GoogleMapsService.GetPlaceFromMapsAPI(location);
            /*            MessageSender messageSender = new MessageSender();
                        messageSender.SendSMS("elo");*/
            JObject jsonAPIresponse = new MessageFormatterService().FormattMessage(mapsAPIresponse);
            return jsonAPIresponse;
        }
    }
}