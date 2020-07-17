//<SnippetPersonClass>
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SDKSample
{
  // This class implements INotifyPropertyChanged
  // to support one-way and two-way bindings
  // (such that the UI element updates when the source
  // has been changed dynamically)
  public class Person : INotifyPropertyChanged
  {
      private string name;
      // Declare the event
      public event PropertyChangedEventHandler PropertyChanged;

      public Person()
      {
      }

      public Person(string value)
      {
          this.name = value;
      }

      public string PersonName
      {
          get { return name; }
          set
          {
              name = value;
              // Call OnPropertyChanged whenever the property is updated
              OnPropertyChanged();
          }
      }

      // Create the OnPropertyChanged method to raise the event
      // The calling member's name will be used as the parameter.
      protected void OnPropertyChanged([CallerMemberName] string name = null)
      {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
  }
}
//</SnippetPersonClass>