using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;

namespace SDKSample
{
  public class MyData: INotifyPropertyChanged
  {
    private DateTime thedate;
    public MyData()
    {
      thedate = DateTime.Now;
    }

    public DateTime TheDate
    {
      get{return thedate;}
      set
      {
        thedate = value;
        OnPropertyChanged("TheDate");
      }
    }

    // Declare event
    public event PropertyChangedEventHandler PropertyChanged;
    // OnPropertyChanged method to update property value in binding
    private void OnPropertyChanged(String info)
    {
      if (PropertyChanged !=null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(info));
      }
    }
  }
}
