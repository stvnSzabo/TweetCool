using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TweetCool
{
    public class XML
    {
        public void WriteToXml(List<Message> messages, string filename)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Message>));

            try
            {
                FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write);
                writer.Serialize(file, messages);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Message> LoadFromXml(string filename)
        {
            List<Message> messages = null;

            try
            {
                StreamReader xmlStream = new StreamReader(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Message>));
                messages = (List<Message>)serializer.Deserialize(xmlStream);
                xmlStream.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return messages;
        }

        public bool IsEmpty(string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            int counter = 0;
            try
            {
                xDoc.Load(filename);
                foreach (var node in xDoc.DocumentElement)
                {
                    counter++;
                    if (counter >= 1)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
            return true;
        }
    }
}
