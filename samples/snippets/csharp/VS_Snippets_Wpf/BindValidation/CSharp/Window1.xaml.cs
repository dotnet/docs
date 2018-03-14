
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;
using System.Collections.ObjectModel;

namespace SDKSample
{
  public partial class Window1 : Window
  {
      public Window1()
      {
          InitializeComponent();
      }

      void UseCustomHandler(object sender, RoutedEventArgs e)
      {
          //<Snippetfiltercallback>

	  //<Snippetparentbinding>
          BindingExpression myBindingExpression = textBox3.GetBindingExpression(TextBox.TextProperty);
          Binding myBinding = myBindingExpression.ParentBinding;
	  //</Snippetparentbinding>
          myBinding.UpdateSourceExceptionFilter = new UpdateSourceExceptionFilterCallback(ReturnExceptionHandler);
          myBindingExpression.UpdateSource();
          //</Snippetfiltercallback>
      }

      void DisableCustomHandler(object sender, RoutedEventArgs e)
      {
          //<SnippetGetBinding>
          // textBox3 is an instance of a TextBox
          // the TextProperty is the data-bound dependency property
          Binding myBinding = BindingOperations.GetBinding(textBox3, TextBox.TextProperty);
          //</SnippetGetBinding>
          myBinding.UpdateSourceExceptionFilter -= new UpdateSourceExceptionFilterCallback(ReturnExceptionHandler);
          BindingOperations.GetBindingExpression(textBox3, TextBox.TextProperty).UpdateSource();
      }

      //<SnippetHandler>
      object ReturnExceptionHandler(object bindingExpression, Exception exception)
      {
          return "This is from the UpdateSourceExceptionFilterCallBack.";
      }
      //</SnippetHandler>
  }
}
