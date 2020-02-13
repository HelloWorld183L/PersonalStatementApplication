using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalStatementTool.Messages
{
    public class PersonalStatementMessage
    {
        public string Author { get; }
        public string Text { get; private set; }
        //public IEnumerable<string> Content { private get; set; }

        public PersonalStatementMessage()
        {

        }

        public PersonalStatementMessage(string author, IEnumerable<string> content)
        {
            Author = author;

            // we probably don't need this public as it is used only in this class.
            //Content = content;

            if (content != null && content.Count() > 0) Text = String.Join(Environment.NewLine, content);
        }
    }
}