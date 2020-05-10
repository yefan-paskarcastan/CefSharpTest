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
            Browser.Address = contur.Addres;
            CloseTab = new Command(OnCloseTab);
            RunJS = new Command(OnRunJS);
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

        public string Addrees { get; set; }

        /// <summary>
        /// Экземпляр бразуера для вкладки
        /// </summary>
        public ChromiumWebBrowser Browser { get; set; }

        /// <summary>
        /// Команда закрытия вкладки
        /// </summary>
        public ICommand CloseTab { get; set; }

        public ICommand RunJS { get; private set; }

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

        void OnRunJS()
        {
            string script = @"temp = function()
                            {
                                return document.getElementsByClassName(""onboarding-ed__title js-onboarding-ed-balance-text"")[0].textContent;
                            };
                            temp();";

            if (!Browser.IsLoading)
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
    }
}
