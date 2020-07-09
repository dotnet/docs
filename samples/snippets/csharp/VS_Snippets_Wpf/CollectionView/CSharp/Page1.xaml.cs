//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Input;

namespace SDKSample
{
  //<Snippet1>
  public partial class CollectionViewSample
  {
    public CollectionView myCollectionView;
    public Order o;

    public void StartHere(Object sender, DependencyPropertyChangedEventArgs args)
    {
      //<Snippet2>
      myCollectionView = (CollectionView)
          CollectionViewSource.GetDefaultView(rootElem.DataContext);
      //</Snippet2>
    }

    //<SnippetOnButton>
    //OnButton is called whenever the Next or Previous buttons
    //are clicked to change the currency
      private void OnButton(Object sender, RoutedEventArgs args)
      {
          Button b = sender as Button;

          switch (b.Name)
          {
              //<SnippetCollectionViewPrevious>
              case "Previous":
                  myCollectionView.MoveCurrentToPrevious();

                  if (myCollectionView.IsCurrentBeforeFirst)
                  {
                      myCollectionView.MoveCurrentToLast();
                  }
                  break;
              //</SnippetCollectionViewPrevious>

              //<SnippetCollectionViewNext>
              case "Next":
                  myCollectionView.MoveCurrentToNext();
                  if (myCollectionView.IsCurrentAfterLast)
                  {
                      myCollectionView.MoveCurrentToFirst();
                  }
                  break;
              //</SnippetCollectionViewNext>

              o = myCollectionView.CurrentItem as Order;
              // TODO: do something with the current Order o
          }
      }
    //</SnippetOnButton>
   }
  //</Snippet1>
}
