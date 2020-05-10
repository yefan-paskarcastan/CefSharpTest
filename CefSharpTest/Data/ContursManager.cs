using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CefSharpTest.Interfaces;

namespace CefSharpTest.Data
{
    public class ContursManager : IContursManager
    {
        public ContursManager(IList<IContur> conturs)
        {
            _conturs = conturs;
            ReadXml();

            RefreshConturs = new Command(ReadXml);
        }

        /// <summary>
        /// Перечитать список контуров из файла
        /// </summary>
        public ICommand RefreshConturs { get; set; }

        /// <summary>
        /// Список контуров
        /// </summary>
        IList<IContur> _conturs;

        /// <summary>
        /// Считывает данные из xml файла
        /// </summary>
        void ReadXml()
        {
            _conturs.Clear();

            var list = new List<Contur>();
            var xmlFormatter = new XmlSerializer(typeof(List<Contur>));
            using (Stream fStream = new FileStream(Properties.Settings.Default.DataOfConturs, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                list = (List<Contur>)xmlFormatter.Deserialize(fStream);
            }

            foreach (Contur item in list)
            {
                _conturs.Add(item);
            }
        }

        /// <summary>
        /// Создает тестовый пример xml файла
        /// </summary>
        void CreateExample()
        {
            var duck = new Contur() { Header = "DuckDuckGo", Addres = "duckduckgo.com" };
            var google = new Contur() { Header = "Google", Addres = "google.com" };
            var ya = new Contur() { Header = "Yandex", Addres = "yandex.com" };
            var bing = new Contur() { Header = "Bing", Addres = "bing.com" };

            var listConturs = new List<Contur>();
            listConturs.Add(duck);
            listConturs.Add(google);
            listConturs.Add(ya);
            listConturs.Add(bing);

            var xmlFormatter = new XmlSerializer(typeof(List<Contur>));
            using (Stream fStream = new FileStream("Conturs.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormatter.Serialize(fStream, listConturs);
            }
        }
    }
}
