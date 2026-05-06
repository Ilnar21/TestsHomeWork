using System.Xml.Serialization;

namespace SeleniumTests
{
    public class PostData
    {
        public PostData()
        {
        }

        public PostData(string message)
        {
            Message = message;
        }

        [XmlElement("Message")]
        public string Message { get; set; }
    }
}
