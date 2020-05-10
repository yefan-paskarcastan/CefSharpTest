using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        string Addres { get; set; }

        /// <summary>
        /// Пользовательская папка для хранение кэша 
        /// </summary>
        string CustomCacheDir { get; set; }
    }
}
