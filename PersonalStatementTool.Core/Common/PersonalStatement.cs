using System.Collections.ObjectModel;

namespace PersonalStatementTool.Core
{
    public class PersonalStatement
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public ObservableCollection<string> Content { get; set; }

        public PersonalStatement()
        {
            Content = new ObservableCollection<string>();
        }
    }
}