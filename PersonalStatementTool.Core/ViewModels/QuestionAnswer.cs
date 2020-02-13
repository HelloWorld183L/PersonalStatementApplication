using Dynamensions.Infrastructure.Base;
using System;

namespace PersonalStatementTool.ViewModels
{
    public class QuestionAnswerViewModel : ViewModelBase
    {
        internal event EventHandler<string> AnswerChanged;


        public QuestionAnswerViewModel(string question)
        {
            Question = question;
        }


        #region Question

        private string _Question;
        public string Question
        {
            get { return _Question; }
            private set { _Question = value; OnPropertyChanged(); }
        }

        #endregion Question


        #region Answer

        private string _Answer;
        public string Answer
        {
            get { return _Answer; }
            set
            {
                _Answer = value;
                OnPropertyChanged();
                if (AnswerChanged != null) AnswerChanged.Invoke(this, value);
            }
        }

        #endregion Answer

    }
}
