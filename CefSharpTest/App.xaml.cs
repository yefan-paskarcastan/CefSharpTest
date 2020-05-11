using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CefSharpTest.ViewModels;
using CefSharpTest.Services;
using CefSharpTest.Data;
using System.Collections.ObjectModel;
using CefSharpTest.Interfaces;

namespace CefSharpTest
{

    public partial class App : Application
    {
        IWindsorContainer container;

        public App()
        {
            container = new WindsorContainer();
            RegisterComponents();
            RegisterViewModels();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow();

            var mainViewModel = container.Resolve<MainViewModel>();

            window.DataContext = mainViewModel;
            window.Show();
        }

        void RegisterComponents()
        {
            container.RegisterSingleton<IList<ITabItem>, ObservableCollection<ITabItem>>();
            container.RegisterSingleton<IList<IContur>, ObservableCollection<IContur>>();
            container.RegisterSingleton<IList<IMetadata>, ObservableCollection<IMetadata>>();

            container.RegisterService<ITabManager, TabManager>();
            container.RegisterService<IContursManager, ContursManager>();
            container.RegisterService<IMetadataManager, MetadataManager>();
        }

        void RegisterViewModels()
        {
            container.RegisterService<MainViewModel, MainViewModel>();
        }
    }
}
