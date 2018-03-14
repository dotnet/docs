using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;


namespace ListViewSnips
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

      private void Refresh(Object sender, 
	                        RoutedEventArgs e)
      {
          //<SnippetRefreshView>
          ICollectionView dataView =
            CollectionViewSource.GetDefaultView(theListView.ItemsSource);
          dataView.Refresh();
          //</SnippetRefreshView>
      }
     // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
    // private void WindowLoaded(object sender, RoutedEventArgs e) {}

    // Sample event handler:  
    // private void ButtonClick(object sender, RoutedEventArgs e) {}

  }
  public class SelectFavoriteCityTemplate : DataTemplateSelector
  {
     public override DataTemplate SelectTemplate(object item,
                                               DependencyObject container)
     {
         FrameworkElement fre = (FrameworkElement)container;
         return (fre.FindResource("FavoriteCityCellTemplate") as DataTemplate);
     }
  }
    //<SnippetBackgroundConverter>
    public sealed class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
            CultureInfo culture)
        {
            ListViewItem item = (ListViewItem)value;
            ListView listView = 
                ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            // Get the index of a ListViewItem
            int index = 
                listView.ItemContainerGenerator.IndexFromContainer(item);

            if (index % 2 == 0)
            {
                return Brushes.LightBlue;
            }
            else
            {
                return Brushes.Beige;
            }
        }
        //</SnippetBackgroundConverter>

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    //<SnippetSubListView>
    public class SubListView : ListView
    {
        protected override void
            PrepareContainerForItemOverride(DependencyObject element,
            object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            if (View is GridView)
            {
                int index = ItemContainerGenerator.IndexFromContainer(element);
                ListViewItem lvi = element as ListViewItem;
                if (index % 2 == 0)
                {
                    lvi.Background = Brushes.LightBlue;
                }
                else
                {
                    lvi.Background = Brushes.Beige;
                }
            }
        }
    }
    //</SnippetSubListView>

    //<SnippetItemStyleSelector>
    public class ListViewItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, 
            DependencyObject container)
        {
            Style st = new Style();
            st.TargetType = typeof(ListViewItem);
            Setter backGroundSetter = new Setter();
            backGroundSetter.Property = ListViewItem.BackgroundProperty;
            ListView listView = 
                ItemsControl.ItemsControlFromItemContainer(container) 
                  as ListView;
            int index = 
                listView.ItemContainerGenerator.IndexFromContainer(container);
            if (index % 2 == 0)
            {
                backGroundSetter.Value = Brushes.LightBlue;
            }
            else
            {
                backGroundSetter.Value = Brushes.Beige;
            }
            st.Setters.Add(backGroundSetter);
            return st;
        }
    }    
    //</SnippetItemStyleSelector>


}