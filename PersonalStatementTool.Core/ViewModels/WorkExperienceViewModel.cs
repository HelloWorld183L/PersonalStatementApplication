using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using System.Windows.Input;

namespace PersonalStatementTool.ViewModels
{
    public class WorkExperienceViewModel : ViewModelBase
    {
        public IMessageBus MessageBus { get; set; }
        public ICommand TextChangedCommand { get; set; }
        //public PersonalStatementService PersonalStatementService { get; set; }

        public WorkExperienceViewModel() { }

        //public WorkExperienceViewModel(IMessageBus messageBus)
        //{
        //    MessageBus = messageBus;
        //    TextChangedCommand = new Command(OnTextChanged, ReturnTrue);
        //    PersonalStatementService = new PersonalStatementService();
        //}

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