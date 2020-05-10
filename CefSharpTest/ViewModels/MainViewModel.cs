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
        public MainViewModel(IList<ITabItem> tabItems, 
                             ITabManager tabManager,
                             IList<IContur> conturs,
                             IContursManager contursManager)
        {
            Tabs = tabItems;
            Conturs = conturs;
            NewTab = tabManager.NewTab;
            RefreshConturs = contursManager.RefreshConturs;
        }

        public IList<ITabItem> Tabs { get; set; } 

        public IList<IContur> Conturs { get; set; }

        public ICommand NewTab { get; set; }

        /// <summary>
        /// Перечитать список контуров из файла
        /// </summary>
        public ICommand RefreshConturs { get; set; }
    }
}