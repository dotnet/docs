using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SDKSample
{
  public class Person : INotifyPropertyChanged
  {
      private string firstname;
      private string lastname;
      private string hometown;

      public event PropertyChangedEventHandler PropertyChanged;

      public Person()
      {
      }

      public Person(string first, string last, string town)
      {
          this.firstname = first;
          this.lastname = last;
          this.hometown = town;
      }
      //<SnippetToString>
      public override string ToString()
      {
          return firstname.ToString();
      }
      //</SnippetToString>
      public string FirstName
      {
          get { return firstname; }
          set
          {
              firstname = value;
              OnPropertyChanged("FirstName");
          }
      }

      public string LastName
      {
          get { return lastname; }
          set
          {
              lastname = value;
              OnPropertyChanged("LastName");
          }
      }

      public string HomeTown
      {
          get { return hometown; }
          set
          {
              hometown = value;
              OnPropertyChanged("HomeTown");
          }
      }

      protected void OnPropertyChanged(string info)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(info));
          }
      }
  }
    public class People : ObservableCollection<Person>
    {
        public People(): base()
        {
            Add(new Person("Michael", "Alexander", "Bellevue"));
            Add(new Person("Jeff", "Hay", "Redmond"));
            Add(new Person("Christina", "Lee", "Kirkland"));
            Add(new Person("Samantha", "Smith", "Seattle"));
        }
    }
}
