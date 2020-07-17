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

namespace RecycleItemContainerShippets
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
    }

    //<SnippetListBoxData>
    public class LotsOfItems : ObservableCollection<String>
    {
        public LotsOfItems()
        {
            for (int i = 0; i < 1000; ++i)
            {
                Add("item " + i.ToString());
            }
        }
    }
    //</SnippetListBoxData>

    //<SnippetTreeViewData>
    public class TreeViewData : ObservableCollection<ItemsForTreeView>
    {

        public TreeViewData()
        {
            for (int i = 0; i < 100; ++i)
            {
                ItemsForTreeView item = new ItemsForTreeView();
                item.TopLevelName = "item " + i.ToString();
                Add(item);
            }
        }
    }

    public class ItemsForTreeView
    {
        public string TopLevelName { get; set; }
        private ObservableCollection<string> level2Items;

        public ObservableCollection<string> SecondLevelItems
        {
            get
            {
                level2Items ??= new ObservableCollection<string>();
                return level2Items;
            }
        }

        public ItemsForTreeView()
        {
            for (int i = 0; i < 10; ++i)
            {
                SecondLevelItems.Add("Second Level " + i.ToString());
            }
        }
    }
    //</SnippetTreeViewData>

    //<SnippetTreeViewItemStyleSelector>
    public class TreeViewItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            string itemString = item as string;

            string[] strings = itemString.Split(null);
            int value;

            if (!Int32.TryParse(strings[strings.Length - 1], out value))
            {
                return null;
            }

            StackPanel sp = ((Window1) Application.Current.MainWindow).sp1;

            if (value < 5)
            {
                return sp.FindResource("TreeViewItemStyle1") as Style;
            }
            else
            {
                return sp.FindResource("TreeViewItemStyle2") as Style;
            }
        }
    }
    //</SnippetTreeViewItemStyleSelector>
}
