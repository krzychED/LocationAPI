using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocationProcessAPI.Models;

namespace LocationProcessAPI.Services
{
   public static class RandomMessageService
   {
      public static string GetMessageFromList()
      {
         Random random = new Random();
         int randomIndex = random.Next(MessageList.messages.Count);
         return MessageList.messages[randomIndex];
      }
   }
}