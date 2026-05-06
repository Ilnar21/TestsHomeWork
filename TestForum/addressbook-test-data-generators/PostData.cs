using System.Xml.Serialization;

namespace addressbook_test_data_generators
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
        public string Message { get; set; } = "";
    }
}
