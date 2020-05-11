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
        public TabManager(IList<ITabItem> tabItems,
                          IMetadataManager metadataManager)
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;

            if (Directory.Exists(currDir + "\\Cache"))
                Directory.Delete(currDir + "\\Cache", true);

            _tabs = tabItems;
            _metadataManager = metadataManager;
        }

        /// <summary>
        /// Добавляет новую вкладку
        /// </summary>
        /// <param name="contur">Параметры контура</param>
        public void AddTab(IContur contur)
        {
            var tabItem = new TabItem(contur);
            tabItem.CloseTabEvent += TabItem_CloseTabEvent;
            tabItem.MainJSEvent += TabItem_MainJSEvent;

            _tabs.Add(tabItem);
        }

        /// <summary>
        /// Коллекция вкладок
        /// </summary>
        IList<ITabItem> _tabs;

        /// <summary>
        /// Управление метаданными
        /// </summary>
        IMetadataManager _metadataManager;

        /// <summary>
        /// Закрытие вкладки
        /// </summary>
        /// <param name="obj"></param>
        void TabItem_CloseTabEvent(ITabItem obj)
        {
            _tabs.Remove(obj);
        }

        /// <summary>
        /// Выполнение основного js
        /// </summary>
        /// <param name="obj">Результат выполнения</param>
        void TabItem_MainJSEvent(IDictionary<string, object> obj)
        {
            _metadataManager.Refresh(obj);
        }
    }
}
