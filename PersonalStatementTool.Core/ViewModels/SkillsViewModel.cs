using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using System.Windows.Input;

namespace PersonalStatementTool.ViewModels
{
    public class SkillsViewModel : ViewModelBase
    {
        public IMessageBus MessageBus { get; set; }
        public ICommand TextChangedCommand { get; set; }
        //public PersonalStatementService PersonalStatementService { get; set; }

        public SkillsViewModel() { }

        //public SkillsViewModel(IMessageBus messageBus)
        //{
        //    MessageBus = messageBus;
        //    TextChangedCommand = new Command(OnTextChange, ReturnTrue);
        //    PersonalStatementService = new PersonalStatementService();
        //}

        private void OnTextChange(object newText)
        {
            MessageBus.Publish(newText.ToString());
        }

        private bool ReturnTrue(object obj)
        {
            return true;
        }
    }
}