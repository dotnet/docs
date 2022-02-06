using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebSiteRatings
{
    public class ActionCommand: ICommand
    {
        private readonly Action _action;

        public ActionCommand(Action action) =>
            _action = action;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) =>
            true;

        public void Execute(object parameter) =>
            _action();
    }
}
