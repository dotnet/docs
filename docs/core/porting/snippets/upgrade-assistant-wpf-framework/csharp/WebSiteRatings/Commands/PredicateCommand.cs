using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebSiteRatings
{
    public class PredicateCommand: ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public PredicateCommand(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) =>
            _canExecute.Invoke();

        public void Execute(object parameter) =>
            _action();
    }
}
