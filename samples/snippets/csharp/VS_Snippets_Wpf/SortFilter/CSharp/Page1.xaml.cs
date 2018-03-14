//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Input;
using SDKSample;

namespace SDKSample
{
  public partial class SortFilter
  {
    //<Snippet2>
    public bool Contains(object de)
    {
        Order order = de as Order;
        //Return members whose Orders have not been filled
        return(order.Filled== "No");
    }
    //</Snippet2>

    //<Snippet3>
    public ListCollectionView myCollectionView;

    // Object o keeps the currency for the table
    public SDKSample.Order o;

    public void StartHere(Object sender, DependencyPropertyChangedEventArgs args)
    {
      myCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(rootElement.DataContext);
    }

    //<SnippetSortEventHandler>
    private void OnClick(Object sender, RoutedEventArgs args)
    {
      Button button = sender as Button;
      //Sort the data based on the column selected
      myCollectionView.SortDescriptions.Clear();
      switch(button.Name.ToString())
      {
        case "orderButton":
          myCollectionView.SortDescriptions.Add(new SortDescription("OrderItem",
              ListSortDirection.Ascending));
          break;
        case "customerButton":
          myCollectionView.SortDescriptions.Add(new SortDescription("Customer",
              ListSortDirection.Ascending));
          break;
        case "nameButton":
          myCollectionView.SortDescriptions.Add(new SortDescription("Name",
              ListSortDirection.Ascending));
          break;
        case "idButton":
          myCollectionView.SortDescriptions.Add(new SortDescription("Id",
              ListSortDirection.Ascending));
          break;
        case "filledButton":
          myCollectionView.SortDescriptions.Add(new SortDescription("Filled",
              ListSortDirection.Ascending));
          break;
      }
    }
    //</SnippetSortEventHandler>

    //</Snippet3>

    //OnBrowse is called whenever the Next or Previous buttons
    //are clicked to change the currency
    private void OnBrowse(Object sender, RoutedEventArgs args)
    {
      Button b = sender as Button;
      switch(b.Name)
      {
        case "Previous":
          if(myCollectionView.MoveCurrentToPrevious())
          {
            feedbackText.Text = "";
            o = myCollectionView.CurrentItem as Order;
          }
          else
          {
            myCollectionView.MoveCurrentToFirst();
            feedbackText.Text = "At first record";
          }
          break;
        case "Next":
          if (myCollectionView.MoveCurrentToNext())
          {
            feedbackText.Text = "";
            o =  myCollectionView.CurrentItem as Order;
          }
          else
          {
            myCollectionView.MoveCurrentToLast();
            feedbackText.Text = "At last record";
          }
          break;
      }
    }

    //OnButton is called whenever the Next or Previous buttons
    //are clicked to change the currency
    //<Snippet1>
    private void OnFilter(Object sender, RoutedEventArgs args)
    {
      Button b = sender as Button;
      switch(b.Name)
      {
        case "Filter":
          //<SnippetFilter>
          myCollectionView.Filter = new Predicate<object>(Contains);
          //</SnippetFilter>
          break;
        case "Unfilter":
          //<SnippetUnfilter>
          myCollectionView.Filter = null;
          //</SnippetUnfilter>
          break;
      }
    }
    //</Snippet1>
  }
}
