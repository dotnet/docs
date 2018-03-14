using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SDKSample
{
  public partial class MainWindow : Window
  {
    //----------------  Response to user actions   --------------------//

    //<SnippetNewColor>
    // Event handler for the NewColor button
    void  OnNewColorClicked(object sender, RoutedEventArgs args)
    {
      Button button = (Button)sender;
      ColorItemList colorList = (ColorItemList)button.DataContext;
      CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView((IEnumerable)colorList);

      // add a new color based on the current one, then select the new one
      ColorItem newItem = new ColorItem((ColorItem)cv.CurrentItem);
      colorList.Add(newItem);
      cv.MoveCurrentTo(newItem);
    }
    //</SnippetNewColor>

    // Event handler for the SortBy radio buttons
    void OnSortByChanged(object sender, RoutedEventArgs args)
    {
      RadioButton rb = (RadioButton)sender;
      string SortBy = rb.Content.ToString();
      CollectionView cv;

      if (SortBy != null)
      {
        // sort by the user's chosen property
        cv = (CollectionView)CollectionViewSource.GetDefaultView((IEnumerable)rb.DataContext);
        cv.SortDescriptions.Clear();
        cv.SortDescriptions.Add(new SortDescription(SortBy, ListSortDirection.Descending));
      }
    }
  }
}
