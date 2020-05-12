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
            foreach (var item in collection)
            {
                var meta = new Metadata()
                {
                    Label = item.Key,
                    Value = (string)item.Value,
                };
                App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    int result = _metadatas.IndexOf(meta);
                    if (result == -1 &&
                        !string.IsNullOrWhiteSpace(meta.Value))
                    {
                        _metadatas.Add(meta);
                        return;
                    }
                    if (result != -1 &&
                        _metadatas[result].Value != meta.Value)
                    {
                        _metadatas[result].Value = meta.Value;
                    }
                }));
            }
        }

        /// <summary>
        /// Список метаданных, извлеченных js
        /// </summary>
        IList<IMetadata> _metadatas;
    }
}
