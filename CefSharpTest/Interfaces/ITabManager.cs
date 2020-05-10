using System.Windows.Input;

namespace CefSharpTest.Interfaces
{
    public interface ITabManager
    {
        /// <summary>
        /// Добавляет новую вкладку
        /// </summary>
        /// <param name="contur">Параметры контура</param>
        void AddTab(IContur contur);
    }
}
