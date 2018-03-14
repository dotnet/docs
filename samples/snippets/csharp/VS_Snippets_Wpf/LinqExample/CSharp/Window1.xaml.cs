using System;
using System.Collections.Generic;
//<SnippetUsing>
using System.Linq;
//</SnippetUsing>
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

namespace LinqExample
{
    public partial class Window1 : Window
    {
        //<SnippetTasks>
        Tasks tasks = new Tasks();
        //</SnippetTasks>

        public Window1()
        {
            InitializeComponent();

        }

        //<SnippetHandler>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pri = Int32.Parse(((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString());

            //<SnippetLinq>
            this.DataContext = from task in tasks
                               where task.Priority == pri
                               select task;
            //</SnippetLinq>
        }
        //</SnippetHandler>
    }

}

