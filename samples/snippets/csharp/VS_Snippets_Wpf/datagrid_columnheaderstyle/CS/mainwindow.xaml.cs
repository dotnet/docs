using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace DataGrid_ColumnHeaderStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Animal> data = new ObservableCollection<Animal>();

            data.Add(new Animal("Dog", "Mammal", false));
            data.Add(new Animal("Cat", "Mammal", false));
            data.Add(new Animal("Horse", "Mammal", false));
            data.Add(new Animal("Tyrannosaurus rex", "Reptile", true));
            data.Add(new Animal("Salmon", "Fish", false));

            dataGrid1.ItemsSource = data;

        }

        public class Animal
        {
            public Animal()
            {
            }

            public Animal(string name, string classification, bool extinct)
            {
                Name = name;
                Classification = classification;
                Extinct = extinct;
            }


            public string Name { get; set; }
            public string Classification { get; set; }
            public bool Extinct { get; set; }

        }

    }
}
