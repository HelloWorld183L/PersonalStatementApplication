using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalStatementTool.Presentation2
{
    public class WorkExperienceViewModel : PersonalStatementViewModel
    {
        private ObservableCollection<QuestionAnswerViewModel> _savedQuestionAnswerViewModels;

        public WorkExperienceViewModel() { }

        public WorkExperienceViewModel(IMessageBus messageBus) : base(messageBus)
        {
            _personalStatementService = new WorkExperienceService();
            this.DisplayName = "Work experience";
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
                        _messageBus.Publish(new PersonalStatementMessage(MessageSource.WorkExperienceView, QuestionAnswers.Select(qa => qa.Answer)));
                    };

                    return questionAnswerViewModel;
                }));

                _savedQuestionAnswerViewModels = QuestionAnswers;
            }
            OnPropertyChanged("QuestionAnswers");
        }
    }
}