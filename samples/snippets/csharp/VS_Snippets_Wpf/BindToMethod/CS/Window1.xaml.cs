using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace ObjectDataProviderSample
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{

		public Window1()
		{
			InitializeComponent();
		}
	}

	public class TemperatureScale : INotifyPropertyChanged
	{
        private TempType type;

        public event PropertyChangedEventHandler PropertyChanged;

        public TemperatureScale()
        {
        }

        public TemperatureScale(TempType type)
        {
            this.type = type;
        }

		public TempType Type
		{
			get { return type; }
			set
            {
                type = value;
                OnPropertyChanged("Type");
            }

		}

        public string ConvertTemp(double degree, TempType temptype)
        {
            this.Type = temptype;
            if (temptype == TempType.Celsius)
                return (degree * 9 / 5 + 32).ToString() + " " + "Fahrenheit";
            if (temptype == TempType.Fahrenheit)
                return ((degree - 32) / 9 * 5).ToString() + " " + "Celsius";
            return "Unknown Type";
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
	}

    public enum TempType
    {
        Celsius,
        Fahrenheit
    }
}