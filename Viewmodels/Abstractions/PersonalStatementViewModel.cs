using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Core;
using Stylet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalStatementTool.Presentation2
{
    public class PersonalStatementViewModel : Screen
    {
        protected IMessageBus _messageBus;
        public ICommand TextChangedCommand { get; set; }
        public ObservableCollection<QuestionAnswerViewModel> QuestionAnswers { get; set; }
        protected IPersonalStatementService _personalStatementService;
        public IList<string> TextBoxContent { get; set; }

        public PersonalStatementViewModel() { }

        public PersonalStatementViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;
            TextChangedCommand = new Command(OnTextChanged, (obj) => true);
            TextBoxContent = new List<string>();
        }

        public void OnTextChanged(object newText)
        {
            TextBoxContent.Add(newText.ToString() + "\n");
        }
    }
}