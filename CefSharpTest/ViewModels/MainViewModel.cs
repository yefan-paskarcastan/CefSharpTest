using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using CefSharpTest.Data;

namespace CefSharpTest.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly string _currDir;
        public MainViewModel()
        {
            _currDir = AppDomain.CurrentDomain.BaseDirectory;

            if(Directory.Exists(_currDir + "\\Cache"))
                Directory.Delete(_currDir + "\\Cache", true);

            Tabs = new ObservableCollection<TabItem>();
            NewTab = new Command(CreateNewTab);
        }

        public ObservableCollection<TabItem> Tabs { get; set; } 

        public ICommand NewTab { get; set; }

        public void CreateNewTab()
        {
            var tabItem = new TabItem();
            tabItem.Header = "123";

            Tabs.Add(tabItem);
        }
    }

}