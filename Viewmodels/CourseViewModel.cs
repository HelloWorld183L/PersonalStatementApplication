using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Core;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace PersonalStatementTool.Presentation2.Viewmodels
{
    public class CourseViewModel : ViewModelBase
    {
        public IMessageBus MessageBus { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public PersonalStatementService PersonalStatementService { get; set; }
        public List<string> TextBoxContent { get; set; }

        public CourseViewModel() { }

        public CourseViewModel(IMessageBus messageBus)
        { 
            MessageBus = messageBus;
            TextChangedCommand = new Command(OnTextChanged, ReturnTrue);
            PersonalStatementService = new PersonalStatementService();
            TextBoxContent = new List<string>();
        }

        private void OnTextChanged(object newText)
        {
            MessageBus.Publish(newText.ToString());
            foreach (var textBoxText in TextBoxContent)
            {
                Debug.WriteLine("ZE TEXT IN ZE TEXTBOX IS THIS: " + textBoxText);
            }
        }

        private bool ReturnTrue(object obj)
        {
            return true;
        }
    }
}