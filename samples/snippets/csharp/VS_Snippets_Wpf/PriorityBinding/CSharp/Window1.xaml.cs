using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Threading;

namespace SDKSample
{
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }
  }

  // This example is for demonstration purposes only.
  // It is not recommended to define properties
  // that are orders of magnitude slower than a field set would be.

  //<Snippet1>
  public class AsyncDataSource
  {
  	private string _fastDP;
  	private string _slowerDP;
  	private string _slowestDP;

  	public AsyncDataSource()
  	{
  	}

  	public string FastDP
  	{
      get { return _fastDP; }
      set { _fastDP = value; }
  	}

  	public string SlowerDP
  	{
      get
      {
        // This simulates a lengthy time before the
        // data being bound to is actualy available.
        Thread.Sleep(3000);
        return _slowerDP;
      }
      set { _slowerDP = value; }
  	}

  	public string SlowestDP
  	{
      get
      {
        // This simulates a lengthy time before the
        // data being bound to is actualy available.
        Thread.Sleep(5000);
        return _slowestDP;
      }
      set { _slowestDP = value; }
  	}
  }
  //</Snippet1>
}
