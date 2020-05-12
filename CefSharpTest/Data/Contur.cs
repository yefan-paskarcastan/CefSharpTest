using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CefSharpTest.Interfaces;
using Newtonsoft.Json;

namespace CefSharpTest.Data
{
    public class Contur : IContur
    {
        public Contur()
        {
            Open = new Command(() => { OpenEvent?.Invoke(this); });
        }

        /// <summary>
        /// Заголовок для вкладки по умолчанию
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Адрес контура
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Пользовательская папка для хранение кэша 
        /// </summary>
        public string CustomCacheDir { get; set; }

        /// <summary>
        /// Игнорировать ошибки SSL сертификатов
        /// </summary>
        public bool IgnoreCertificateErrors { get; set; } = true;

        /// <summary>
        /// Сохранять куки
        /// </summary>
        public bool PersistSessionCookies { get; set; } = true;

        /// <summary>
        /// Отрыть выбранный контур
        /// </summary>
        [JsonIgnore]
        public ICommand Open { get; private set; }

        /// <summary>
        /// Событие возникает при вызове команды открытия контура
        /// </summary>
        public event Action<IContur> OpenEvent;
    }
}
