using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetCool

{
    [Serializable]
    public class Message
    {
        public string Username { get; set; } 
        public string Text { get; set; }

       
        public Message(string user, string text)
        {
            Username = user;
            Text = text;
         
        }

        public Message()
        {

        }

        public override string ToString()
        {
            return $"{Username}: {Text}";
        }

    }
}