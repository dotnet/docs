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


namespace DataGrid_CellStyle
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            ObservableCollection<Animal> data = new ObservableCollection<Animal>();

            data.Add(new Animal("dog"));
            data.Add(new Animal("cat"));
            data.Add(new Animal("horse"));
            data.Add(new Animal("pig"));
            data.Add(new Animal("goat"));

            DG1.DataContext = data;

        }
        public class Animal
        {
            public Animal()
            {
            }

            public Animal(string name)
            {
                Name = name;
            }


            public string Name { get; set; }

        }

    }
}
