using Dynamensions.Infrastructure.Busses.MessageBus;
using Dynamensions.Navigation;
using Dynamensions.Navigation.Wpf;
using Microsoft.Extensions.DependencyInjection;
using PersonalStatementTool.Presentation2.Services;
using PersonalStatementTool.Presentation2.Views;
using PersonalStatementTool.Services;
using PersonalStatementTool.ViewModels;
using System;
using System.Windows;

namespace PersonalStatementTool.Presentation2
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        private MainWindow _mainWindow = new MainWindow();

        public App()
        {
            _serviceProvider = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindowViewModel viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            _mainWindow.DataContext = viewModel;
            _mainWindow.Show();

            // pull the navigation service from the DI container
            INavigationService navigationService = _serviceProvider.GetRequiredService<INavigationService>();
            navigationService.NavigateToAsync<CourseViewModel>();
        }

        private IServiceProvider ConfigureServices()
        {
            var serviceDescriptors = new ServiceCollection();
            var viewAssembly = GetType().Assembly;

            // Services
            serviceDescriptors.AddSingleton<INavigationService, NavigationService>((service) => new NavigationService(ref _serviceProvider, ref _mainWindow.NavigationFrame, ref viewAssembly));
            serviceDescriptors.AddSingleton<IMessageBus, MessageBus>();
            serviceDescriptors.AddSingleton<IPersonalStatementService, PersonalStatementService>();


            // View Models
            serviceDescriptors.AddTransient<MainWindowViewModel>();
            serviceDescriptors.AddTransient<CourseViewModel>();
            serviceDescriptors.AddTransient<SkillsViewModel>();
            serviceDescriptors.AddTransient<WorkExperienceViewModel>();



            return serviceDescriptors.BuildServiceProvider();
        }
    }
}