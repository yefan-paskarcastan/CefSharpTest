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
using Newtonsoft.Json;

namespace CefSharpTest.Data
{
    public class ContursManager : IContursManager
    {
        public ContursManager(IList<IContur> conturs,
                              ITabManager tabManager)
        {
            _conturs = conturs;
            _tabManager = tabManager;
            ReadJson();

            RefreshConturs = new Command(ReadJson);
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
        /// Управляющий вкладками
        /// </summary>
        ITabManager _tabManager;

        /// <summary>
        /// Считывает данные из json файла
        /// </summary>
        void ReadJson()
        {
            _conturs.Clear();

            var jsonSerializer = new JsonSerializer();
            var list = new List<Contur>();

            using (var fStream = new StreamReader("conturs.json"))
            using (JsonReader jsonReader = new JsonTextReader(fStream))
            {
                list = jsonSerializer.Deserialize<List<Contur>>(jsonReader);
            }

            foreach (Contur item in list)
            {
                item.OpenEvent += Item_OpenEvent;
                _conturs.Add(item);
            }
        }

        /// <summary>
        /// Обработчик события открытия вкладки
        /// </summary>
        /// <param name="obj">Параметры контура</param>
        void Item_OpenEvent(IContur obj)
        {
            _tabManager.AddTab(obj);
        }

        /// <summary>
        /// Создает тестовый пример json файла
        /// </summary>
        void CreateExampleJSON()
        {
            var duck = new Contur() { Header = "DuckDuckGo", Address = "duckduckgo.com" };
            var google = new Contur() { Header = "Google", Address = "google.com" };
            var ya = new Contur() { Header = "Yandex", Address = "yandex.com" };
            var bing = new Contur() { Header = "Bing", Address = "bing.com" };

            var listConturs = new List<Contur>();
            listConturs.Add(duck);
            listConturs.Add(google);
            listConturs.Add(ya);
            listConturs.Add(bing);

            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Formatting = Formatting.Indented;

            using (var fStream = new StreamWriter("conturs.json"))
            using (JsonWriter jsWriter = new JsonTextWriter(fStream))
            {
                jsonSerializer.Serialize(jsWriter, listConturs);
            }
        }
    }
}
