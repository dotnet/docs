using System.Windows;
using System.Windows.Controls;

namespace TreeViewExpand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

   
        //<Snippet2>
        private void expandSelected_Click(object sender, RoutedEventArgs e)
        {
            if (treeView1.SelectedItem == null)
            {
                return;
            }

            TreeViewItem tvi = GetTreeViewItem(treeView1, treeView1.SelectedItem);

            if (tvi != null)
            {
                tvi.ExpandSubtree();
            }
        }

        // Traverse the TreeView to find the TreeViewItem 
        // that corresponds to the selected item.
        private TreeViewItem GetTreeViewItem(ItemsControl parent, object item)
        {
            // Check whether the selected item is a direct child of 
            // the parent ItemsControl.
            TreeViewItem tvi =
                parent.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;

            if (tvi == null)
            {
                // The selected item is not a child of parent, so check
                // the child items of parent.
                foreach (object child in parent.Items)
                {
                    TreeViewItem childItem = 
                        parent.ItemContainerGenerator.ContainerFromItem(child) as TreeViewItem;

                    if (childItem != null)
                    {
                        // Check the next level for the appropriate item.
                        tvi = GetTreeViewItem(childItem, item);
                    }
                }
            }
            return tvi;
        }
        //</Snippet2>

    }

}
