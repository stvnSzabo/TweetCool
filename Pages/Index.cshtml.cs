using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TweetCool;

namespace TweetCool.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost([FromForm(Name = "username")] string username, [FromForm(Name = "message")] string message)
        {
            List<Message> allMessages;
            XML theXml = new XML();
            MessagesModel mm = new MessagesModel();
            string filename = "AllMessages.xml";
            allMessages = mm.LoadMessages(filename);
            Message msg = new Message(username, message);


            allMessages.Add(msg);
            if (!System.IO.File.Exists("AllMessages.xml") || theXml.IsEmpty(filename))
            {
                theXml.WriteToXml(allMessages, filename);
                Console.WriteLine("Done!");
            }
            theXml.WriteToXml(allMessages, filename);
            return new RedirectToPageResult("Messages");

        }
    }
}
