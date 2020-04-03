using System.Collections.ObjectModel;
using System.Linq;
using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Core;

namespace PersonalStatementTool.Presentation2
{
    public class SkillsViewModel : PersonalStatementViewModel
    {
        private ObservableCollection<QuestionAnswerViewModel> _savedQuestionAnswerViewModels;

        public SkillsViewModel() { }

        public SkillsViewModel(IMessageBus messageBus) : base(messageBus)
        {
            _personalStatementService = new SkillsService();
            this.DisplayName = "Skills";
        }

        protected override void OnViewLoaded()
        {
            var questions = _personalStatementService.GetQuestions();

            if (_savedQuestionAnswerViewModels != null)
            {
                QuestionAnswers = _savedQuestionAnswerViewModels;
            }
            else
            {
                if (questions != null) QuestionAnswers = new ObservableCollection<QuestionAnswerViewModel>(questions.Select((question) =>
                {
                    var questionAnswerViewModel = new QuestionAnswerViewModel(question);
                    questionAnswerViewModel.AnswerChanged += (s, e) =>
                    {
                        if (question == null) return;
                        _messageBus.Publish(new PersonalStatementMessage(MessageSource.SkillsView, QuestionAnswers.Select(qa => qa.Answer)));
                    };

                    return questionAnswerViewModel;
                }));

                _savedQuestionAnswerViewModels = QuestionAnswers;
            }
            OnPropertyChanged("QuestionAnswers");
        }
    }
}