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

	public class GreekGod
	{
        private string _name;

		public string Name
		{
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
		}
        
        public GreekGod(string name)
        {
            Name = name;
        }
	}

	public class GreekGods : ObservableCollection<GreekGod>
	{
		public GreekGods()
		{
			Add(new GreekGod("Aphrodite"));
			Add(new GreekGod("Apollo"));
			Add(new GreekGod("Ares"));
			Add(new GreekGod("Artemis"));
			Add(new GreekGod("Athena"));
			Add(new GreekGod("Demeter"));
			Add(new GreekGod("Dionysus"));
			Add(new GreekGod("Hephaestus"));
			Add(new GreekGod("Hera"));
			Add(new GreekGod("Hermes"));
			Add(new GreekGod("Poseidon"));
			Add(new GreekGod("Zeus"));
		}
	}
}
