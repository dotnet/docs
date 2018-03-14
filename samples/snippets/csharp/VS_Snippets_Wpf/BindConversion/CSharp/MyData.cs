using System;
using System.Globalization;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Media;

namespace SDKSample
{
    public class MyData : INotifyPropertyChanged
    {
        private DateTime _thedate;

        public MyData()
        {
            _thedate = DateTime.Now;
        }

        public DateTime TheDate
        {
            get { return _thedate; }
            set
            {
                if (_thedate != value)
                {
                    _thedate = value;
                    OnPropertyChanged("TheDate");
                }
            }
        }

        // Declare event
        public event PropertyChangedEventHandler PropertyChanged;

        // OnPropertyChanged event handler to update property value in binding
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}