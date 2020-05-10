using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CefSharp.Wpf;
using CefSharp;
using System.Windows.Input;
using System.Diagnostics;
using CefSharpTest.ViewModels;
using CefSharpTest.Interfaces;

namespace CefSharpTest.Data
{
    public class TabItem : BaseNotify, ITabItem
    {
        public TabItem(IContur contur)
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
            Header = contur.Header;
            Browser.Address = contur.Address;
            CloseTab = new Command(OnCloseTab);
            MainJS = new Command(OnMainJS);
            ShowDevTools = new Command(OnShowDevTools);
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
        /// Экземпляр бразуера для вкладки
        /// </summary>
        public ChromiumWebBrowser Browser { get; set; }

        /// <summary>
        /// Команда закрытия вкладки
        /// </summary>
        public ICommand CloseTab { get; set; }

        /// <summary>
        /// Отобразить DevTools
        /// </summary>
        public ICommand ShowDevTools { get; set; }

        /// <summary>
        /// Главый js, который выполняется при движении мышки
        /// </summary>
        public ICommand MainJS { get; private set; }

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

        /// <summary>
        /// Обработчик команды запуска основного js файла
        /// </summary>
        void OnMainJS()
        {
            string currDir = AppDomain.CurrentDomain.BaseDirectory;
            string script = string.Empty;
            using (var stream = new StreamReader(currDir + "\\js\\Test.js"))
            {
                script = stream.ReadToEnd();
            }

            if (!Browser.IsLoading && script != string.Empty)
            {
                Browser.EvaluateScriptAsync(script).ContinueWith(x =>
                {
                    var response = x.Result;

                    if (response.Success && response.Result != null)
                    {
                        var className = (string)response.Result;
                        Header = className;
                        OnPropertyChanged("Header");
                    }
                });
            }
        }

        /// <summary>
        /// Показать devtools
        /// </summary>
        void OnShowDevTools()
        {
            Browser.ShowDevTools();
        }
    }
}
