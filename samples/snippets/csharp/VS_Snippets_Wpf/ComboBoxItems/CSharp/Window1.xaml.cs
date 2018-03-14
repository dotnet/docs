
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace ComboBox_Index
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


        private void GetThirdCity_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> itemCollection =
                this.FindResource("myCities") as ObservableCollection<string>;

            if (itemCollection == null)
            {
                MessageBox.Show("myCities not found");
                return;
            }

            object objectInCollection = itemCollection[2];

            //<Snippet3>
            ComboBoxItem cbi = (ComboBoxItem)
                cb.ItemContainerGenerator.ContainerFromItem(objectInCollection);
            
            cbi.IsSelected = true;
            //</Snippet3>
       
        }

        private void GetCity(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            int index = Convert.ToInt32(rb.Content.ToString());

            GetComboBoxItem(index);
        }

        //<Snippet2>
        private void GetComboBoxItem(int index)
        {
            ComboBoxItem cbi = (ComboBoxItem)
                 (cb.ItemContainerGenerator.ContainerFromIndex(index));

            cbi.IsSelected = true;
            Info.Content = "I visited " +
                 (cbi.Content.ToString()) + ".";
        }
        //</Snippet2>           

 

    }

    class Cities : ObservableCollection<string>
    {
        public Cities()
        {

            Add("Spain - First stop");
            Add("France - Second stop");
            Add("Peru - Third stop");
            Add("Mexico - Fourth stop");

        }
    }

    //<SnippetData>
    class VacationSpots : ObservableCollection<string>
    {
        public VacationSpots ()
        {

            Add("Spain");
            Add("France");
            Add("Peru");
            Add("Mexico");
            Add("Italy");
        }
    }
    //</SnippetData>

}