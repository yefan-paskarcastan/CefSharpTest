using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpTest.Interfaces
{
    public interface IMetadataManager
    {

        /// <summary>
        /// Очищает список метаданных и заполняет новыми
        /// </summary>
        /// <param name="collection">Словарь с метаданными</param>
        void Refresh(IDictionary<string, object> collection);
    }
}
