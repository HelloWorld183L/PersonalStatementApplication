using Dynamensions.Infrastructure.Busses.MessageBus;
using Dynamensions.Navigation;
using Dynamensions.Navigation.Wpf;
using Microsoft.Extensions.DependencyInjection;
using PersonalStatementTool.Core;
using PersonalStatementTool.Presentation2.Viewmodels;
using PersonalStatementTool.Presentation2.Views;
using System;
using System.Windows;

namespace PersonalStatementTool.Presentation2
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        private MainWindow _mainWindow;

        public App()
        {
            _serviceProvider = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _mainWindow = new MainWindow();
            var mainViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            _mainWindow.DataContext = mainViewModel;
            _mainWindow.Show();
        }

        private IServiceProvider ConfigureServices()
        {
            var serviceDescriptors = new ServiceCollection();
            var viewAssembly = GetType().Assembly;

            serviceDescriptors.AddSingleton<INavigationService, NavigationService>((service) => new NavigationService(ref _serviceProvider, ref _mainWindow.NavigationFrame, ref viewAssembly));
            serviceDescriptors.AddTransient<MainWindowViewModel>();
            serviceDescriptors.AddTransient<CourseViewModel>();
            serviceDescriptors.AddTransient<SkillsViewModel>();
            serviceDescriptors.AddTransient<WorkExperienceViewModel>();
            serviceDescriptors.AddSingleton<IMessageBus, MessageBus>();

            return serviceDescriptors.BuildServiceProvider();
        }
    }
}