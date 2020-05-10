using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using CefSharpTest.Data;
using CefSharpTest.Interfaces;

namespace CefSharpTest.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IList<ITabItem> tabItems, ITabManager tabManager)
        {
            Tabs = tabItems;
            NewTab = tabManager.NewTab;

            var ctr = new ContursManager();
        }

        public IList<ITabItem> Tabs { get; set; } 

        public ICommand NewTab { get; set; }
    }
}