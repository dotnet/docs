//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SDKSample
{
	public partial class DirectionalBinding
	{

    //<SnippetOnRentRaise>
    private void OnRentRaise(Object sender, RoutedEventArgs args)
    {
      // Update bills
      System.Random random = new System.Random();
      double i = random.Next(10);
      BindingExpression bindingExpression =
        BindingOperations.GetBindingExpression(SavingsText, TextBlock.TextProperty);
      SDKSample.NetIncome sourceData = (SDKSample.NetIncome) bindingExpression.DataItem;
      sourceData.Rent = (int)((1 + i / 100) * (double)sourceData.Rent);
    }
    //</SnippetOnRentRaise>

    //<Snippet3>
    private void OnTargetUpdated(Object sender, DataTransferEventArgs args)
    {

      // Handle event
    //</Snippet3>
      FrameworkElement fe = sender as FrameworkElement;
      infoText.Text = "";
      infoText.Text += args.Property.Name + " property of a " + args.Property.OwnerType.Name;
      infoText.Text += " element (";
      infoText.Text += fe.Name;
      infoText.Text += ") updated...";
      infoText.Text += System.DateTime.Now.ToLongDateString();
      infoText.Text += " at ";
      infoText.Text += System.DateTime.Now.ToLongTimeString();
    //<SnippetEndEvent>
    }
    //</SnippetEndEvent>
  }
}
