using LocationProcessAPI.Models;
using LocationProcessAPI.Services;
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
        public Location PostNewLocation([FromBody]Location location)
        {

            MessageSender messageSender = new MessageSender();
            messageSender.SendSMS("elo");
            
            return location;
        }
    }
}