using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using Dynamensions.Navigation;
using PersonalStatementTool.Messages;
using PersonalStatementTool.Services;
using System.Windows.Input;

namespace PersonalStatementTool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IMessageBus _messageBus;
        private readonly INavigationService _navigationService;
        private readonly IPersonalStatementService _personalStatementService;

        private string _currentDestination;

        #region Constructors

        public MainWindowViewModel() { }

        public MainWindowViewModel(IMessageBus messageBus, INavigationService navigationService, IPersonalStatementService personalStatementService)
        {
            NavCommand = new Command(OnNav, (e) => true);
            _messageBus = messageBus;
            _navigationService = navigationService;
            _personalStatementService = personalStatementService;
            Subscribe();
        }
        #endregion Constructors

        #region Messages

        private void Subscribe()
        {
            _messageBus.Subscribe<PersonalStatementMessage>(PersonalStatementMessage);
        }

        private void PersonalStatementMessage(PersonalStatementMessage message)
        {
            Author = message.Author;
            PersonalStatement = message.Text;
        }

        #endregion Messages

        #region Properties

        #region Author

        private string _Author;
        public string Author
        {
            get { return _Author; }
            set { _Author = value; OnPropertyChanged(); }
        }

        #endregion Author

        #region PersonalStatement

        private string _PersonalStatement;
        public string PersonalStatement
        {
            get { return _PersonalStatement; }
            set { _PersonalStatement = value; OnPropertyChanged(); }
        }

        #endregion PersonalStatement

        #endregion Properties

        #region Commands

        public ICommand NavCommand { get; private set; }

        #endregion Commands

        #region Methods

        private async void OnNav(object destination)
        {
            switch (destination)
            {
                case "course":
                    await _navigationService.NavigateToAsync<CourseViewModel>();
                    break;
                case "skillsAndAchievements":
                    await _navigationService.NavigateToAsync<SkillsViewModel>();
                    break;
                default:
                case "workExperienceAndPlacements":
                    await _navigationService.NavigateToAsync<WorkExperienceViewModel>();
                    break;
            }

            _currentDestination = destination.ToString();
        }


        #endregion Methods

    }
}