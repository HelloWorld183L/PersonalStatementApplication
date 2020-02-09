using Dynamensions.Infrastructure.Base;
using Dynamensions.Infrastructure.Busses.MessageBus;
using Dynamensions.Navigation;
using PersonalStatementTool.Core;
using System.Windows.Input;

namespace PersonalStatementTool.Presentation2.Viewmodels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand NavCommand { get; set; }
        public IMessageBus MessageBus { get; set; }
        private readonly INavigationService _navigationService;
        public PersonalStatementService PersonalStatementService { get; set; }

        public MainWindowViewModel() { NavCommand = new Command(OnNav, ReturnTrue); }

        public MainWindowViewModel(IMessageBus messageBus, INavigationService navigationService)
        {
            NavCommand = new Command(OnNav, ReturnTrue);
            MessageBus = messageBus;
            _navigationService = navigationService;
            PersonalStatementService = new PersonalStatementService();
            Subscribe();
        }

        private bool ReturnTrue(object obj)
        {
            return true;
        }

        private async void OnNav(object destination)
        {
            switch (destination)
            {
                case "course":
                    await _navigationService.NavigateToAsync<CourseViewModel>(MessageBus);
                    break;
                case "skillsAndAchievements":
                    await _navigationService.NavigateToAsync<SkillsViewModel>(MessageBus);
                    break;
                default:
                case "workExperienceAndPlacements":
                    await _navigationService.NavigateToAsync<WorkExperienceViewModel>(MessageBus);
                    break;
            }
        }

        private void OnTextChanged(string message)
        {
            PersonalStatementService.SetNewText(message);
        }

        private void Subscribe()
        {
            MessageBus.Subscribe<string>(OnTextChanged);
        }
    }
}