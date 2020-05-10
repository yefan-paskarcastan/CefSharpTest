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
        public TabManager(IList<ITabItem> tabItems)
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;

            if (Directory.Exists(currDir + "\\Cache"))
                Directory.Delete(currDir + "\\Cache", true);

            _tabs = tabItems;
        }

        /// <summary>
        /// Добавляет новую вкладку
        /// </summary>
        /// <param name="contur">Параметры контура</param>
        public void AddTab(IContur contur)
        {
            var tabItem = new TabItem(contur);
            tabItem.CloseTabEvent += TabItem_CloseTabEvent;

            _tabs.Add(tabItem);
        }

        /// <summary>
        /// Коллекция вкладок
        /// </summary>
        IList<ITabItem> _tabs;

        /// <summary>
        /// Закрытие вкладки
        /// </summary>
        /// <param name="obj"></param>
        void TabItem_CloseTabEvent(ITabItem obj)
        {
            _tabs.Remove(obj);
        }
    }
}
