using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inSUREance.Classes
{
    public class Message
    {
        public string text;
        public DateTime timeStamp;
        public bool isQuestion;

        public Message(string text, DateTime timeStamp, bool isQuestion)
        {
            this.text = text;
            this.timeStamp = timeStamp;
            this.isQuestion = isQuestion;
        }

        public class MessageManager
        {
            private List<Message> messages = new List<Message>();

            public MessageManager()
            {
                // TODO: load messages dynamically from database (where Username = ...)
                messages.Add(new Message("test2", new DateTime(2018, 1, 1), true));
                messages.Add(new Message("test3", new DateTime(2018, 1, 5), false));
                messages.Add(new Message("test4", new DateTime(2015, 1, 1), true));
                messages.Add(new Message("lorem ipsum dolor sit ich habe eine frage!", new DateTime(2018, 1, 1), true));
                messages.Add(new Message("das eine Antwort", new DateTime(2019, 1, 1), false));
            }

            public List<Message> GetMessages()
            {
                return messages;
            }
        }
    }
}
