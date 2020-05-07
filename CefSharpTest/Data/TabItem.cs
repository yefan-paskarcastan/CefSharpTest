using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CefSharp.Wpf;
using CefSharp;
using CefSharpTest.ViewModels;
using System.Windows.Input;
using System.Diagnostics;

namespace CefSharpTest.Data
{
    public class TabItem
    {
        public TabItem()
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;
            Index = _indexCounter++;
            DirectoryInfo dirInfo = Directory.CreateDirectory(currDir + "\\Cache\\Inst" + Index);
            var settings = new RequestContextSettings
            {
                IgnoreCertificateErrors = true,
                PersistSessionCookies = false,
                CachePath = dirInfo.FullName,
            };

            Browser = new ChromiumWebBrowser();
            Browser.RequestContext = new RequestContext(settings);
            Browser.Address = "https://duckduckgo.com";
            CloseTab = new Command(OnCloseTab);
        }

        /// <summary>
        /// Счетчик для индекса вкладки
        /// </summary>
        static int _indexCounter = 0;

        /// <summary>
        /// Уникальный индекс вкладки, используется для именования папки с кэшом
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Заголовок вкадки
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Адрес вкладки
        /// </summary>
        public string Addrees { get; set; }

        /// <summary>
        /// Экземпляр бразуера для вкладки
        /// </summary>
        public ChromiumWebBrowser Browser { get; set; }

        /// <summary>
        /// Команда закрытия вкладки
        /// </summary>
        public ICommand CloseTab { get; set; }

        /// <summary>
        /// Событие возникает при вызове команды закрытие вкладки
        /// </summary>
        public event Action<TabItem> CloseTabEvent;

        /// <summary>
        /// Обработчик команды закрытия вкадки
        /// </summary>
        void OnCloseTab()
        {
            Browser.Dispose();
            CloseTabEvent?.Invoke(this);
        }
    }
}
