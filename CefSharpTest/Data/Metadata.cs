using System;
using System.Windows;
using System.Windows.Input;
using CefSharpTest.Interfaces;

namespace CefSharpTest.Data
{
    /// <summary>
    /// Объект для возвращения данных из js
    /// </summary>
    public class Metadata : BaseNotify, IMetadata
    {
        public Metadata()
        {
            CopyValue = new Command(OnCopyValue);
        }

        string _value;

        /// <summary>
        /// Метка, описывающая значение
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value 
        { 
            get { return _value; } 
            set { _value = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Положить значение в буфер обмена
        /// </summary>
        public ICommand CopyValue { get; private set; }

        /// <summary>
        /// Если метки равны, то объекты равны
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (!(obj is Metadata))
            {
                return false;
            }

            var temp = (Metadata)obj;
            if (temp.Label == Label)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int result = 0;
            int length = Label.Length;

            if (length > 0)
            {
                char let1 = Label[0];
                char let2 = Label[length - 1];

                int part1 = let1 + length;
                result = (89 * part1) + let2 + length;
            }
            return result;
        }

        /// <summary>
        /// Обработчик комады CopyValue
        /// </summary>
        void OnCopyValue()
        {
            if (Value != null && Value != string.Empty)
            {
                Clipboard.SetText(Value);
            }
        }
    }
}
