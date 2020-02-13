using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalStatementTool.ViewModels
{
    public class CourseViewModel : ViewModelBase
    {
        private readonly IMessageBus _messageBus;
        private readonly IPersonalStatementService _personalStatementService;

        #region Constructors

        public CourseViewModel()
        {
            // something to add so the view can see this as design time.
            QuestionAnswers.Add(new QuestionAnswerViewModel("Why are you applying for your chosen course(s)?"));
            QuestionAnswers.Add(new QuestionAnswerViewModel("Why does this subject interest you?"));
            QuestionAnswers.Add(new QuestionAnswerViewModel("Why do you think you're suitable for the course(s)?"));
            QuestionAnswers.Add(new QuestionAnswerViewModel("Do your current or previous studies relate to the course(s) that you have chosen?"));
            QuestionAnswers.Add(new QuestionAnswerViewModel("Have you taken part in any other activities that demonstrate your interest in the course(s)?"));
        }


        // Place the injections here, allow the Microsoft.Extensions.DependancyInjection to do it's work.
        // The injections are defined in the App.xaml.cs.
        public CourseViewModel(IMessageBus messageBus, IPersonalStatementService personalStatementService)
        {
            _messageBus = messageBus;
            _personalStatementService = personalStatementService;

        }

        #endregion Constructors

        #region Messages
        #endregion Messages

        #region Properties  

        public ObservableCollection<QuestionAnswerViewModel> QuestionAnswers { get; private set; } = new ObservableCollection<QuestionAnswerViewModel>();

        #endregion Properties

        #region Commands

        public ICommand CompileCommand { get; private set; }


        #endregion Commands

        #region Methods

        // we will override this method. the navigation bus executes this method after it loads the view model.
        public override async Task PrepareViewModelAsync(object parameter = null)
        {
            // use the service to build and return the list of questions.
            IEnumerable<string> questions = await _personalStatementService.GetQuesitonsAsync();

            // clear and add the enumerable to the observable collection.
            if (questions != null) QuestionAnswers = new ObservableCollection<QuestionAnswerViewModel>(questions.Select((question) =>
            {
                QuestionAnswerViewModel questionAnswerViewModel = new QuestionAnswerViewModel(question);
                questionAnswerViewModel.AnswerChanged += (s, e) =>
                {
                    if (question == null) return;
                    _messageBus.Publish(new Messages.PersonalStatementMessage(null, QuestionAnswers.Select(qa => qa.Answer)));
                };

                return questionAnswerViewModel;
            }));

            OnPropertyChanged("QuestionAnswers");
        }



        #endregion Methods

    }
}