using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace HeaderedItemsControlSimple
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>


    public class myColors : ObservableCollection<string>
    {
        public myColors()
        {
            Add("Red");
            Add("Purple");
            Add("Blue");
            Add("Green");
        }
    }


    public class MyNumbers : ObservableCollection<string>
    {
        public MyNumbers()
        {
            Add("one");
            Add("two");
            Add("three");
            Add("four");
            Add("five");
        }
    }

    public partial class Page1 : Canvas
    {

        void OnClick(object sender, RoutedEventArgs e)
        {
            //<SnippetHeaderedItemsControl_HasHeader>
            if (hitemsCtrl.HasHeader == true)
            {
                MessageBox.Show(hitemsCtrl.Header.ToString());
                
            }
            //</SnippetHeaderedItemsControl_HasHeader>
        }
    }
}

