using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharpTest.Interfaces;
using System.Windows.Input;
using System.IO;

namespace CefSharpTest.Data
{
    public class TabManager : ITabManager
    {
        public TabManager(IList<TabItem> tabItems)
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;

            if (Directory.Exists(currDir + "\\Cache"))
                Directory.Delete(currDir + "\\Cache", true);

            _tabs = tabItems;
            NewTab = new Command(OnNewTab);
        }

        /// <summary>
        /// Команда открытия новой вкладки
        /// </summary>
        public ICommand NewTab { get; private set; }

        /// <summary>
        /// Коллекция вкладок
        /// </summary>
        IList<TabItem> _tabs;

        /// <summary>
        /// Обработчик добавления новой вкладки
        /// </summary>
        void OnNewTab()
        {
            var tabItem = new TabItem();
            tabItem.Header = tabItem.Index.ToString();
            tabItem.CloseTabEvent += TabItem_CloseTabEvent;

            _tabs.Add(tabItem);
        }

        /// <summary>
        /// Закрытие вкладки
        /// </summary>
        /// <param name="obj"></param>
        void TabItem_CloseTabEvent(TabItem obj)
        {
            _tabs.Remove(obj);
        }
    }
}
