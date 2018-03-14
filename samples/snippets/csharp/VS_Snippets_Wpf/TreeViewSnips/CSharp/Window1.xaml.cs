using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace TreeViewSnips
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

        private void InitializeTreeView(object sender, EventArgs e)
        {
            //<SnippetSelectedItem>
            TreeViewItem selectedTVI = (TreeViewItem)myTreeView.SelectedItem;
            //</SnippetSelectedItem>
            if (myTreeView.SelectedValue == null)
            {
                //<SnippetSelectedValue>
                TreeViewItem selectedTVValue = (TreeViewItem)myTreeView.SelectedValue;
                //</SnippetSelectedValue>

                //<SnippetSelectedValuePath>
                string selectedTVValuePath = myTreeView.SelectedValuePath;
                //</SnippetSelectedValuePath>

            }
            //<SnippetIsExpanded>
            Employee1Data.IsExpanded = true;
            //</SnippetIsExpanded>      
            //<SnippetIsSelected>
            EmployeeWorkDays.IsSelected = true;
            //</SnippetIsSelected>      
            //<SnippetIsSelectionActive>
            bool isEmployee1Active = Employee1Data.IsSelectionActive;
            //</SnippetIsSelectionActive> 
        }
        //<SnippetSelectedValueChangedMethod>
        private void SelectionChanged(object sender, RoutedPropertyChangedEventArgs<Object> e)
        {
            //Perform actions when SelectedItem changes
            MessageBox.Show(((TreeViewItem) e.NewValue).Header.ToString());
        }
        //</SnippetSelectedValueChangedMethod>

        //<SnippetChooseWine>
        private void GetSchedule(object sender, RoutedEventArgs e)
        {
            //Perform actions when a TreeViewItem
            //controls is selected
        }
        //</SnippetChooseWine>

        //<SnippetChangeWineChoice>
        private void SetSchedule(object sender, RoutedEventArgs e)
        {
            //Perform actions when a TreeViewItem
            //control becomes unselected
        }
        //</SnippetChangeWineChoice>


        //<SnippetOnCollapsed>
        private void OnCollapsed(object sender, RoutedEventArgs e)
        {
            //Perform actions when the TreeViewItem is collapsed
        }
        //</SnippetOnCollapsed>

        //<SnippetOnExpanded>
        private void OnExpanded(object sender, RoutedEventArgs e)
        {
            //Perform actions when the TreeViewItem is expanded
        }
        //</SnippetOnExpanded>

    }
}