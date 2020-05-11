using CefSharpTest.Interfaces;

namespace CefSharpTest.Data
{
    /// <summary>
    /// Объект для возвращения данных из js
    /// </summary>
    public class Metadata : IMetadata
    {
        public string Label { get; set; }

        public string Value { get; set; }
    }
}
