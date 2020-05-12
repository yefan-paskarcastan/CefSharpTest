using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CefSharpTest.Interfaces
{
    public interface IContur
    {
        /// <summary>
        /// Заголовок для вкладки по умолчанию
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// Адрес контура
        /// </summary>
        string Address { get; set; }

        /// <summary>
        /// Пользовательская папка для хранение кэша 
        /// </summary>
        string CustomCacheDir { get; set; }

        /// <summary>
        /// Игнорировать ошибки SSL сертификатов
        /// </summary>
        bool IgnoreCertificateErrors { get; set; }

        /// <summary>
        /// Сохранять куки
        /// </summary>
        bool PersistSessionCookies { get; set; }

        /// <summary>
        /// Отрыть выбранный контур
        /// </summary>
        ICommand Open { get; }

        /// <summary>
        /// Событие возникает при вызове команды открытия контура
        /// </summary>
        event Action<IContur> OpenEvent;
    }
}
