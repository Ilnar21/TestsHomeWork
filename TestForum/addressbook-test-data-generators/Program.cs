using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = int.Parse(args[1]);
            string filename = args[2];
            string format = args[3];

            if (type == "g")
            {
                List<PostData> posts = GeneratePosts(count);

                if (format == "xml")
                {
                    WriteToXmlFile(posts, filename);
                    Console.WriteLine("File created: " + filename);
                }
            }
        }

        static List<PostData> GeneratePosts(int count)
        {
            List<PostData> posts = new List<PostData>();
            Random random = new Random();

            string[] messages =
            {
                "Добрый день! Подскажите, нужна ли виза для транзита через Италию?",
                "Здравствуйте! Какие документы нужны для получения визы в Италию?",
                "Помогите пожалуйста, нужно ли страховать весь период поездки?",
                "Скажите, принимают ли электронные билеты для подачи на визу?",
                "Подскажите, за сколько дней лучше подавать документы на визу?",
                "Можно ли подать документы без брони отеля если еду к друзьям?",
                "Нужно ли предоставлять выписку с банковского счёта за 3 месяца?",
                "Нужно ли предоставлять билеты по передвижению по городам Италии?"
            };

            for (int i = 0; i < count; i++)
            {
                posts.Add(new PostData(messages[random.Next(messages.Length)]));
            }

            return posts;
        }

        static void WriteToXmlFile(List<PostData> posts, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PostData>));
            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, posts);
            }
        }
    }
}
