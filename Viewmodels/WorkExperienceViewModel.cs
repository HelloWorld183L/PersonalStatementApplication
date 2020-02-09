using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Core;
using System.Windows.Input;

namespace PersonalStatementTool.Presentation2.Viewmodels
{
    public class WorkExperienceViewModel : ViewModelBase
    {
        public IMessageBus MessageBus { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public PersonalStatementService PersonalStatementService { get; set; }

        public WorkExperienceViewModel() { }

        public WorkExperienceViewModel(IMessageBus messageBus)
        {
            MessageBus = messageBus;
            TextChangedCommand = new Command(OnTextChanged, ReturnTrue);
            PersonalStatementService = new PersonalStatementService();
        }

        private void OnTextChanged(object newText)
        {
            MessageBus.Publish(newText.ToString());
        }

        private bool ReturnTrue(object obj)
        {
            return true;
        }
    }
}