
using System;
using System.Globalization;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Media;

namespace SDKSample
{
  /// <summary>
  /// Window1: This is the class that encapsulates the code
  /// "behind" the Window1.Xaml page.
  /// </summary>
  //<Snippet3>
  public partial class Window1 : Window
  {
    private MyConverter _theConverter = null;

    public MyConverter TheConverter
    {
      get
      {
        if (_theConverter == null)
          _theConverter = new MyConverter();

        return _theConverter;
      }
    }

    //<Snippet2>
	public void ChangeTheCulture(string sSelectedCulture)
 	{
        string sCulture;

//<SnippetParentBinding>
  		Binding binding = myDateText.GetBindingExpression(TextBlock.TextProperty).ParentBinding;
//</SnippetParentBinding>
      
        switch (sSelectedCulture)
        {
            case "English (en-US)":
              sCulture = "en-US";
              break;
            case "Spanish (es-ES)":
              sCulture = "es-ES";
              break;
            case "German (de-DE)":
              sCulture = "de-DE";
              break;
            case "French (fr-FR)":
              sCulture = "fr-FR";
              break;
            default:
              sCulture = "";
              break;
        }
	}
    //</Snippet2>

	private void OnSelectionChanged(Object sender, RoutedEventArgs args)
	{
      ListBoxItem oLI = (ListBoxItem) lbChooseCulture.SelectedItem;
      string sSelectedCulture = oLI.Content.ToString();
      ChangeTheCulture(sSelectedCulture);
	}

      public void RelativeSource_snip()
      {
          //<SnippetRelativeSource>
          Binding myBinding = new Binding();
          // Returns the second ItemsControl encountered on the upward path
          // starting at the target element of the binding
          myBinding.RelativeSource = new RelativeSource(
              RelativeSourceMode.FindAncestor, typeof(ItemsControl), 2);
          //</SnippetRelativeSource>
      }


    //<Snippet1>
    private void OnPageLoaded(object sender, EventArgs e)
    {
        // Make a new source, to grab a new timestamp
        MyData myChangedData = new MyData();
        
        // Create a new binding
	// TheDate is a property of type DateTime on MyData class
        Binding myNewBindDef = new Binding("TheDate");
        
        myNewBindDef.Mode = BindingMode.OneWay;
        myNewBindDef.Source = myChangedData;
        myNewBindDef.Converter = TheConverter;
        myNewBindDef.ConverterCulture = new CultureInfo("en-US");
        
	//<SnippetBOSetBinding>
	// myDatetext is a TextBlock object that is the binding target object
        BindingOperations.SetBinding(myDateText, TextBlock.TextProperty, myNewBindDef);
        BindingOperations.SetBinding(myDateText, TextBlock.ForegroundProperty, myNewBindDef);
	//</SnippetBOSetBinding>

    //</Snippet1>
        lbChooseCulture.SelectedIndex = 0;
//<Snippetend1>
    }
//</Snippetend1>
  }
  //</Snippet3>
}
