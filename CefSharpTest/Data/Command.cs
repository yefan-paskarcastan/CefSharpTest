using System;
using System.Windows.Input;

namespace CefSharpTest.Data
{
    public class Command : ICommand
    {
        public Command(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }

        readonly Action _action;
    }
}
