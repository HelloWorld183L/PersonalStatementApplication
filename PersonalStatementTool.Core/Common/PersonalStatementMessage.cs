using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalStatementTool.Core
{
    public class PersonalStatementMessage
    {
        public string Text { get; set; }
        private IEnumerable<string> _content { get; set; }
        public MessageSource MessageSource { get; set; }

        public PersonalStatementMessage() { }

        public PersonalStatementMessage(MessageSource messageSource, IEnumerable<string> content)
        {
            MessageSource = messageSource;
            _content = content;

            if (content != null && _content.Count() > 0) Text = string.Join("\n", _content);
        }
    }
}