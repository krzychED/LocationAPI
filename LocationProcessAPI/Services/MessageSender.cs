using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using TextmagicRest;
using TextmagicRest.Model;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using LocationProcessAPI.Models;
using User = LocationProcessAPI.Models.User;
using LocationProcessAPI.Configuration;

namespace LocationProcessAPI.Services
{
    public class MessageSender
    {
       // public static Configuration Conf { get; private set; }

        public void SendSMS(string messageText)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            Config userFromConfig = LoadConfigurationFile();

            if ( (userFromConfig.password != null) && (userFromConfig.username != null))
            {
                string AccountSid = userFromConfig.username;
                string AuthToken =  userFromConfig.password;

                TwilioClient.Init(AccountSid, AuthToken);

                var message = MessageResource.Create(
                    body: messageText,
                    from: new Twilio.Types.PhoneNumber("+12012317462"),
                    to: new Twilio.Types.PhoneNumber("+48609696052")
                );
                Console.WriteLine(message.Sid);
            }

        }

        public static Config LoadConfigurationFile()
        {
            try
            {
                if (!File.Exists(LocationProcessAPIConfig.configFilePath))
                    throw new FileNotFoundException();
                string filePath = LocationProcessAPIConfig.configFilePath;
                ExeConfigurationFileMap customConfigFileMap = new ExeConfigurationFileMap();
                customConfigFileMap.ExeConfigFilename = filePath;

                AppSettingsSection appSettings = ( ConfigurationManager
                    .OpenMappedExeConfiguration(customConfigFileMap, ConfigurationUserLevel.None)
                    .GetSection("appSettings") as AppSettingsSection);

                string username = appSettings.Settings["account_sid"].Value;
                string password = appSettings.Settings["auth_token"].Value;
                string mapsUrl =  appSettings.Settings["maps_url"].Value;
                string mapsKey =  appSettings.Settings["maps_key"].Value;
     
                return new Config(username, password, mapsUrl, mapsKey);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            return new Config();
        }

  

    }
}