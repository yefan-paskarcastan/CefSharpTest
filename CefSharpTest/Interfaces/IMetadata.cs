using System.Windows.Input;

namespace CefSharpTest.Interfaces
{
    /// <summary>
    /// Объект для возвращения данных из js
    /// </summary>
    public interface IMetadata
    {
        string Label { get; set; }

        string Value { get; set; }

        ICommand CopyValue { get; }
    }
}
