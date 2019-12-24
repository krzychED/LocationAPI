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
        public string PostNewLocation([FromBody]Location location)
        {
            string mapsAPIresponse = GoogleMapsService.GetPlaceFromMapsAPI(location);
            string placeName = new MessageFormatterService().FormattMessage(mapsAPIresponse);
            string message = RandomMessageService.GetMessageFromList() + placeName;
            MessageSender messageSender = new MessageSender();
            messageSender.SendSMS(message);
         return message;
        }
    }
}