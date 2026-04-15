using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumTests
{
    public class PostData
    {
        public PostData(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}