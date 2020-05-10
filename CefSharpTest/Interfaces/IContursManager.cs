using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CefSharpTest.Interfaces
{
    public interface IContursManager
    {

        /// <summary>
        /// Перечитать список контуров из файла
        /// </summary>
        ICommand RefreshConturs { get; set; }
    }
}
