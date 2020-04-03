using Dynamensions.Infrastructure.Base;
using System;

namespace PersonalStatementTool.Presentation2
{
    public class QuestionAnswerViewModel : ViewModelBase
    {
        internal event EventHandler<string> AnswerChanged;

        private string _question;
        public string Question
        {
            get { return _question; }
            private set { _question = value; OnPropertyChanged(); }
        }

        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                OnPropertyChanged();
                if (AnswerChanged != null) AnswerChanged.Invoke(this, value);
            }
        }

        public QuestionAnswerViewModel() { }

        public QuestionAnswerViewModel(string question)
        {
            Question = question;
        }
    }
}