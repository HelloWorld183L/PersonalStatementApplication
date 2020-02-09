using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Core;
using System.Windows.Input;

namespace PersonalStatementTool.Presentation2.Viewmodels
{
    public class SkillsViewModel : ViewModelBase
    {
        public IMessageBus MessageBus { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public PersonalStatementService PersonalStatementService { get; set; }

        public SkillsViewModel() {}

        public SkillsViewModel(IMessageBus messageBus)
        {
            MessageBus = messageBus;
            TextChangedCommand = new Command(OnTextChange, ReturnTrue);
            PersonalStatementService = new PersonalStatementService();
        }

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