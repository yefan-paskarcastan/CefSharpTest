using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CefSharp.Wpf;
using CefSharp;

namespace CefSharpTest.Data
{
    public class TabItem
    {
        public TabItem()
        {
            DirectoryInfo dirInfo = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\Inst" + Index++);
            var settings = new RequestContextSettings
            {
                IgnoreCertificateErrors = true,
                PersistSessionCookies = false,
                CachePath = dirInfo.FullName
            };

            Browser = new ChromiumWebBrowser();
            Browser.RequestContext = new RequestContext(settings);
            Browser.Address = "https://duckduckgo.com";
        }

        public static int Index = 0;

        public string Header { get; set; }

        public string Addrees { get; set; }

        public ChromiumWebBrowser Browser { get; set; }
    }
}
