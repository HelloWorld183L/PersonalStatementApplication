using Dynamensions.Infrastructure.Busses.MessageBus;
using PersonalStatementTool.Core;
using Stylet;
using System;
using System.Windows.Input;

namespace PersonalStatementTool.Presentation2
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ICommand ResetCommand { get; private set; }
        public ICommand OpenImportFileWindowCommand { get; private set; }
        public ICommand OpenExportFileWindowCommand { get; private set; }
        public ICommand OpenHelpWindowCommand { get; private set; }
        public int CharactersUsed { get; private set; }
        public PersonalStatement PersonalStatement { get; private set; }
        private string _fullText;
        public string FullText
        {
            get => _fullText;
            set { SetAndNotify(ref _fullText, value); }
        }
        private readonly IWindowManager _windowManager;
        private readonly IMessageBus _messageBus;

        public ShellViewModel() { }
        // TODO: Refactor constructor parameters (I could pass in a data structure with view models
        public ShellViewModel(IMessageBus messageBus, IWindowManager windowManager, SkillsViewModel skillsViewModel, CourseViewModel courseViewModel, WorkExperienceViewModel workExperienceViewModel)
        {
            SetUpCommands();
            _messageBus = messageBus;
            _windowManager = windowManager;
            PersonalStatement = new PersonalStatement();
            this.Items.Add(courseViewModel);
            this.Items.Add(skillsViewModel);
            this.Items.Add(workExperienceViewModel);
            this.ActiveItem = courseViewModel;
            Subscribe();
        }

        private void OpenHelpWindow(object _)
        {
            var helpViewModel = new HelpViewModel();
            _windowManager.ShowWindow(helpViewModel);
        }

        private void ResetText(object _)
        {
            PersonalStatement = new PersonalStatement();
        }

        private void OpenExportWindow(object _)
        {
            //if (!string.IsNullOrEmpty(PersonalStatement.Author))
            //{
                if (!string.IsNullOrEmpty(PersonalStatement.FullText))
                {
                    var exportViewModel = new ExportViewModel(PersonalStatement);
                    _windowManager.ShowWindow(exportViewModel);
                }
                else
                {
                    // TODO: Display empty full text validation message
                }
            //}
            //else
           // {
                // TODO: Display no author validation message (perhaps make the author optional)
           // }
        }

        private void OpenImportWindow(object _)
        {
            var importViewModel = new ImportViewModel();
            _windowManager.ShowWindow(importViewModel);
        }

        private void Subscribe()
        {
            _messageBus.Subscribe<PersonalStatementMessage>(UpdatePersonalStatement);
        }

        private void UpdatePersonalStatement(PersonalStatementMessage message)
        {
            switch (message.MessageSource)
            {
                case MessageSource.CourseView:
                    PersonalStatement.CourseViewText = message.Text + Environment.NewLine;
                    break;
                case MessageSource.SkillsView:
                    PersonalStatement.SkillsViewText = message.Text + Environment.NewLine;
                    break;
                case MessageSource.WorkExperienceView:
                    PersonalStatement.WorkExperienceViewText = message.Text + Environment.NewLine;
                    break;
            }

            FullText = PersonalStatement.CourseViewText + PersonalStatement.SkillsViewText + PersonalStatement.WorkExperienceViewText;
            PersonalStatement.FullText = FullText;
            CharactersUsed = FullText.Trim().Length;
        }

        private void SetUpCommands()
        {
            OpenHelpWindowCommand = new Command(OpenHelpWindow, (obj) => true);
            ResetCommand = new Command(ResetText, (obj) => true);
            OpenExportFileWindowCommand = new Command(OpenExportWindow, (obj) => true);
            OpenImportFileWindowCommand = new Command(OpenImportWindow, (obj) => true);
        }
    }
}