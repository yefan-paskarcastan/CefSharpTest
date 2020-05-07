using System.Windows.Input;

namespace CefSharpTest.Interfaces
{
    public interface ITabManager
    {
        ICommand NewTab { get; }
    }
}
