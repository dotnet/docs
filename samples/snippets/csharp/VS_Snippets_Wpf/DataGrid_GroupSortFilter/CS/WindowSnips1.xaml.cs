// This file is only a container for additional snippets that can't go
// in the MainWindow file. It is not otherwise used in the sample application.

using System.Windows;
using System.Windows.Data;
using System.ComponentModel;

namespace DGGroupSortFilterExample
{
    /// <summary>
    /// Interaction logic for WindowSnips1.xaml
    /// </summary>
    public partial class WindowSnips1 : Window
    {
        public WindowSnips1()
        {
            InitializeComponent();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            // see MainWindow
        }

        private void Sort()
        {
            // <snippet211>
            // Requires using System.ComponentModel;
            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
            if (cvTasks != null && cvTasks.CanSort == true)
            {
                cvTasks.SortDescriptions.Clear();
                cvTasks.SortDescriptions.Add(new SortDescription("ProjectName", ListSortDirection.Ascending));
                cvTasks.SortDescriptions.Add(new SortDescription("Complete", ListSortDirection.Ascending));
                cvTasks.SortDescriptions.Add(new SortDescription("DueDate", ListSortDirection.Ascending));
            }
            // </snippet211>
        }
    }
}
