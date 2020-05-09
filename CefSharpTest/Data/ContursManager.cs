using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CefSharpTest.Data
{
    public class ContursManager
    {
        public ContursManager()
        {
            var xmlFormatter = new XmlSerializer(typeof(List<Contur>));
            using (Stream fStream = new FileStream("Conturs.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                IList<Contur> list = (IList<Contur>)xmlFormatter.Deserialize(fStream);
                foreach (var item in list)
                {
                    Debug.WriteLine(item.Header);
                }
            }
        }

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
