using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharpTest.Interfaces;

namespace CefSharpTest.Data
{
    public class MetadataManager : IMetadataManager
    {
        public MetadataManager(IList<IMetadata> metadatas)
        {
            _metadatas = metadatas;
        }

        /// <summary>
        /// Очищает список метаданных и заполняет новыми
        /// </summary>
        /// <param name="collection">Словарь с метаданными</param>
        public void Refresh(IDictionary<string, object> collection)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                _metadatas.Clear();
            }));

            foreach (var item in collection)
            {
                var meta = new Metadata()
                {
                    Label = item.Key,
                    Value = (string)item.Value,
                };
                App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    _metadatas.Add(meta);
                }));
            }
        }

        /// <summary>
        /// Список метаданных, извлеченных js
        /// </summary>
        IList<IMetadata> _metadatas;
    }
}
