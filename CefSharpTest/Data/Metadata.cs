using System;
using System.Windows;
using System.Windows.Input;
using CefSharpTest.Interfaces;

namespace CefSharpTest.Data
{
    /// <summary>
    /// Объект для возвращения данных из js
    /// </summary>
    public class Metadata : IMetadata
    {
        public Metadata()
        {
            CopyValue = new Command(OnCopyValue);
        }

        public string Label { get; set; }

        public string Value { get; set; }

        public ICommand CopyValue { get; private set; }

        void OnCopyValue()
        {
            if (Value != null && Value != string.Empty)
            {
                Clipboard.SetText(Value);
            }
        }
    }
}
