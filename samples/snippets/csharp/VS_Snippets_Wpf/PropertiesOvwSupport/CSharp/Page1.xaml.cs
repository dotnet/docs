using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Foo
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
      void DoStuff(object sender, EventArgs e)
      {
        //<SnippetProceduralPropertySet>
        Button myButton = new Button();
        myButton.Width = 200.0;
        //</SnippetProceduralPropertySet>
        //<SnippetProceduralPropertyGet>
        double whatWidth;
        whatWidth = myButton.Width;
        //</SnippetProceduralPropertyGet>
        double checkWidth;
        //<SnippetPropertyMixedDeclProcCB>
        checkWidth = myButton.Width;
        if (checkWidth == 200.0) { anotherButton.Width = 300.0; }
        //</SnippetPropertyMixedDeclProcCB>
        MessageBox.Show(whatWidth.ToString());
        myButton.Content = "myButton";
        root.Children.Add(myButton);
      }

    }
}