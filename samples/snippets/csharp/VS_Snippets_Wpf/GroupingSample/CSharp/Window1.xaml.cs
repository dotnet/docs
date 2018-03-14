//<SnippetCode>
using System;
using System.Windows;
using System.Windows.Data;

namespace GroupingSample
{
    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();
        }

//<SnippetMyView>
        CollectionView myView;
//</SnippetMyView>
        private void AddGrouping(object sender, RoutedEventArgs e)
        {
//<SnippetGetView>
            myView = (CollectionView)CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource);
//</SnippetGetView>
            if (myView.CanGroup == true)
            {
                PropertyGroupDescription groupDescription
                    = new PropertyGroupDescription("@Type");
                myView.GroupDescriptions.Add(groupDescription);
            }
            else
                return;
        }

        private void RemoveGrouping(object sender, RoutedEventArgs e)
        {
            myView = (CollectionView)CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource);
            myView.GroupDescriptions.Clear();
        }
    }
}
//</SnippetCode>