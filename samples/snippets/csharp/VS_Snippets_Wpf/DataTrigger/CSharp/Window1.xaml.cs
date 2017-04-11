using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
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

  //<Snippet2>
  public class Place
  {
    private string _name;

    private string _state;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public string State
    {
      get { return _state; }
      set { _state = value; }
    }

    public Place(string name, string state)
    {
      this._name = name;
      this._state = state;
    }
  }

  public class Places : ObservableCollection<Place>
  {
    public Places()
    {
      Add(new Place("Bellevue", "WA"));
      Add(new Place("Gold Beach", "OR"));
      Add(new Place("Kirkland", "WA"));
      Add(new Place("Los Angeles", "CA"));
      Add(new Place("Portland", "ME"));
      Add(new Place("Portland", "OR"));
      Add(new Place("Redmond", "WA"));
      Add(new Place("San Diego", "CA"));
      Add(new Place("San Francisco", "CA"));
      Add(new Place("San Jose", "CA"));
      Add(new Place("Seattle", "WA"));
    }
  }
  //</Snippet2>
}
