using System.ComponentModel;

namespace UXComponents
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // <QualifiedNameofNotify>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(UXComponents.ViewModel.FirstName)));
                }
            }
        }
        private string firstName;
        // </QualifiedNameofNotify>
    }
}