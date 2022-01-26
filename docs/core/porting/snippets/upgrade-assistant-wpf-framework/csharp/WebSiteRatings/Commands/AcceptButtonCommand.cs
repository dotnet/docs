using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WebSiteRatings.Commands
{
    internal class AcceptButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is Window window)
                return IsValid(window);
            else
                return false;
        }

        private bool IsValid(DependencyObject obj) =>
            !Validation.GetHasError(obj) && LogicalTreeHelper.GetChildren(obj)
                                                              .OfType<DependencyObject>()
                                                              .All(IsValid);

        public void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
            else
                throw new InvalidOperationException("This command must pass the window as the parameter");
        }
    }
}
