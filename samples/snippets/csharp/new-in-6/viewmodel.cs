using System.ComponentModel;

namespace UXComponents
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // <nameofNotify>
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    PropertyChanged?.Invoke(this, 
                        new PropertyChangedEventArgs(nameof(LastName)));
                }
            }
        }
        private string lastName;
        // </nameofNotify>

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