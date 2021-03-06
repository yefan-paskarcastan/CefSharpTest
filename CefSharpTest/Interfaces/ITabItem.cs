﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CefSharp.Wpf;
using CefSharpTest.Data;

namespace CefSharpTest.Interfaces
{
    public interface ITabItem
    {
        /// <summary>
        /// Уникальный индекс вкладки, используется для именования папки с кэшом
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Заголовок вкадки
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// Экземпляр бразуера для вкладки
        /// </summary>
        ChromiumWebBrowser Browser { get; }

        /// <summary>
        /// Команда закрытия вкладки
        /// </summary>
        ICommand CloseTab { get; }

        /// <summary>
        /// Отобразить DevTools
        /// </summary>
        ICommand ShowDevTools { get; }

        /// <summary>
        /// Главый js, который выполняется при движении мышки
        /// </summary>
        ICommand MainJS { get; }

        /// <summary>
        /// Событие возникает при вызове команды закрытие вкладки
        /// </summary>
        event Action<TabItem> CloseTabEvent;

        /// <summary>
        /// Событие возникает когда основной js возвращает результат выполнения
        /// </summary>
        event Action<IDictionary<string, object>> MainJSEvent;
    }
}
