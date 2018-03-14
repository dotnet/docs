using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TreeViewFindTVI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestDataItem data = new TestDataItem(0, 0, 0);

        public MainWindow()
        {
            InitializeComponent();
            data.PopulateItems(2, 5);
            tv1.ItemsSource = data.Items;


        }

        //<Snippet1>
        /// <summary>
        /// Recursively search for an item in this subtree.
        /// </summary>
        /// <param name="container">
        /// The parent ItemsControl. This can be a TreeView or a TreeViewItem.
        /// </param>
        /// <param name="item">
        /// The item to search for.
        /// </param>
        /// <returns>
        /// The TreeViewItem that contains the specified item.
        /// </returns>
        private TreeViewItem GetTreeViewItem(ItemsControl container, object item)
        {
            if (container != null)
            {
                if (container.DataContext == item)
                {
                    return container as TreeViewItem;
                }

                // Expand the current container
                if (container is TreeViewItem && !((TreeViewItem)container).IsExpanded)
                {
                    container.SetValue(TreeViewItem.IsExpandedProperty, true);
                }

                // Try to generate the ItemsPresenter and the ItemsPanel.
                // by calling ApplyTemplate.  Note that in the 
                // virtualizing case even if the item is marked 
                // expanded we still need to do this step in order to 
                // regenerate the visuals because they may have been virtualized away.

                container.ApplyTemplate();
                ItemsPresenter itemsPresenter = 
                    (ItemsPresenter)container.Template.FindName("ItemsHost", container);
                if (itemsPresenter != null)
                {
                    itemsPresenter.ApplyTemplate();
                }
                else
                {
                    // The Tree template has not named the ItemsPresenter, 
                    // so walk the descendents and find the child.
                    itemsPresenter = FindVisualChild<ItemsPresenter>(container);
                    if (itemsPresenter == null)
                    {
                        container.UpdateLayout();

                        itemsPresenter = FindVisualChild<ItemsPresenter>(container);
                    }
                }

                Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);


                // Ensure that the generator for this panel has been created.
                UIElementCollection children = itemsHostPanel.Children; 

                MyVirtualizingStackPanel virtualizingPanel = 
                    itemsHostPanel as MyVirtualizingStackPanel;

                for (int i = 0, count = container.Items.Count; i < count; i++)
                {
                    TreeViewItem subContainer;
                    if (virtualizingPanel != null)
                    {
                        // Bring the item into view so 
                        // that the container will be generated.
                        virtualizingPanel.BringIntoView(i);

                        subContainer = 
                            (TreeViewItem)container.ItemContainerGenerator.
                            ContainerFromIndex(i);
                    }
                    else
                    {
                        subContainer = 
                            (TreeViewItem)container.ItemContainerGenerator.
                            ContainerFromIndex(i);

                        // Bring the item into view to maintain the 
                        // same behavior as with a virtualizing panel.
                        subContainer.BringIntoView();
                    }

                    if (subContainer != null)
                    {
                        // Search the next level for the object.
                        TreeViewItem resultContainer = GetTreeViewItem(subContainer, item);
                        if (resultContainer != null)
                        {
                            return resultContainer;
                        }
                        else
                        {
                            // The object is not under this TreeViewItem
                            // so collapse it.
                            subContainer.IsExpanded = false;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Search for an element of a certain type in the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of element to find.</typeparam>
        /// <param name="visual">The parent element.</param>
        /// <returns></returns>
        private T FindVisualChild<T>(Visual visual) where T : Visual
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual child = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (child != null)
                {
                    T correctlyTyped = child as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }

                    T descendent = FindVisualChild<T>(child);
                    if (descendent != null)
                    {
                        return descendent;
                    }
                }
            }

            return null;
        }
        //</Snippet1>


        /// <summary>
        /// Find the object that corresponds to the specified key.
        /// </summary>
        /// <param name="key">The key of the item to find.</param>
        /// <returns>The object that contains the specified key.</returns>
        /// <remarks>
        /// This method is specific to the object model in
        /// this sample and is not meant to be usable for general
        /// cases.  Applications must provide the logic to find
        /// the data in their object model.
        /// 
        /// This method relies on the data model getting populated
        /// by calling PopulateItems(2, 5).  If you Change the parameters
        /// of PopulateItems, this method might not find the
        /// specified item.
        /// </remarks>
        TestDataItem FindTreeDataItem(int key)
        {
            ObservableCollection<TestDataItem> currentList = data.Items;
            int i;
            int currentIndex;

            // Determine whether to go to the first or second node.
            if (key < currentList[1].Key)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }

            while ((currentList[i].Items.Count == 2) && (currentList[i].Key != key))
            {
                // Save the current value before changing i. 
                currentIndex = i;

                // Check whether the second item of the current list is
                // greater than the key.  If it is, the item we want is
                // under the first item.
                if (key < currentList[i].Items[1].Key)
                {
                    i = 0;
                }
                else
                {
                    i = 1;
                }

                // Get the original currentList[i].Items (before i changed).
                currentList = currentList[currentIndex].Items;
            }


            return currentList[i];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int key;

            if (!Int32.TryParse(findItem.Text, out key) || key > TestDataItem.HighestKey)
            {
                MessageBox.Show(string.Format("Please enter a number between 1 and {0}",
                    TestDataItem.HighestKey));
                return;
            }
            
            object item = FindTreeDataItem(key);

            if (item == null)
            {
                MessageBox.Show("Item not found: " + item);
                return;
            }

            TreeViewItem requestedItem = GetTreeViewItem(tv1, item);

            if (requestedItem != null)
            {
                MessageBox.Show(requestedItem.ToString());
                requestedItem.IsSelected = true;                
            }
        }

    }

    //<Snippet2>
    public class MyVirtualizingStackPanel : VirtualizingStackPanel
    {
        /// <summary>
        /// Publically expose BringIndexIntoView.
        /// </summary>
        public void BringIntoView(int index)
        {

            this.BringIndexIntoView(index);
        }
    }
    //</Snippet2>

    // Test data.
    public class TestDataItem
    {
        private int _id;
        private int _level;
        private ObservableCollection<TestDataItem> _items;
        private int _key;
        static int keyId = 0;

        public TestDataItem(int id, int level, int key)
        {
            _id = id;
            _level = level;
            _key = key;
        }

        public static int HighestKey { get { return TestDataItem.keyId; } }
        public int Id
        {
            get { return _id; }
        }

        public int Level
        {
            get { return _level; }
        }

        public int Key
        {
            get { return _key; }
        }

        public string Name
        {
            get { return Key + ": Item " + Id + " on level " + Level; }

        }

        public override string ToString()
        {
            return Key.ToString();
        }

        public ObservableCollection<TestDataItem> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ObservableCollection<TestDataItem>();
                }
                return _items;
            }
        }

        public void PopulateItems(int count, int levels)
        {

            Items.Clear();
            if (levels > Level)
            {
                for (int i = 0; i < count; i++)
                {
                    TestDataItem item = new TestDataItem(i, Level + 1, keyId++);
                    Items.Add(item);
                    item.PopulateItems(count, levels);
                }
            }
        }
    }

}
