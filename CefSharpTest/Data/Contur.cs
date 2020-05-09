using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpTest.Data
{
    [Serializable]
    public class Contur
    {

        /// <summary>
        /// Заголовок для вкладки по умолчанию
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Адрес контура
        /// </summary>
        public string Addres { get; set; }

        /// <summary>
        /// Пользовательская папка для хранение кэша 
        /// </summary>
        public string CustomCacheDir { get; set; }
    }
}
