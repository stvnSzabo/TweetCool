using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TweetCool.Pages
{
    public class MessagesModel : PageModel
    {
        public List<Message> LoadMessages(string filename)
        {
            List<Message> Messages;
            XML theXml = new XML();
            Messages = theXml.LoadFromXml(filename); //ujra loadolom
            return Messages;
        }


        public void OnGet()
        {
            
        }
        public MessagesModel()
        {
        }
    }
}
