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
                             IList<IContur> conturs,
                             IList<IMetadata> metadatas,
                             IContursManager contursManager)
        {
            Tabs = tabItems;
            Conturs = conturs;
            RefreshConturs = contursManager.RefreshConturs;
        }

        /// <summary>
        /// Список открытых вкладок
        /// </summary>
        public IList<ITabItem> Tabs { get; set; } 

        /// <summary>
        /// Список доступных контуров
        /// </summary>
        public IList<IContur> Conturs { get; set; }

        /// <summary>
        /// Найденные метаданные
        /// </summary>
        public IList<IMetadata> Metadatas { get; set; }

        /// <summary>
        /// Перечитать список контуров из файла
        /// </summary>
        public ICommand RefreshConturs { get; set; }
    }
}