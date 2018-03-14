using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;
using System.Collections.ObjectModel;

namespace SDKSample
{
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }
  }

  //<Snippet1>
  public class NameList : ObservableCollection<PersonName>
  {
      public NameList() : base()
      {
          Add(new PersonName("Willa", "Cather"));
          Add(new PersonName("Isak", "Dinesen"));
          Add(new PersonName("Victor", "Hugo"));
          Add(new PersonName("Jules", "Verne"));
      }
    }

    public class PersonName
    {
        private string firstName;
        private string lastName;

        public PersonName(string first, string last)
        {
            this.firstName = first;
            this.lastName = last;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
  //</Snippet1>
}
