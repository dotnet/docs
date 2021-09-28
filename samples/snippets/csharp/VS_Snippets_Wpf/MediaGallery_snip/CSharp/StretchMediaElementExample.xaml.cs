// <SnippetMediaElementCSharpExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Input;

namespace SDKSample
{

	public partial class StretchMediaElementExample : Page
	{

        // Change the Stretch property to the selected value.
        void OnClickChangeStretch(object sender, RoutedEventArgs args)
        {
            Button btn = (Button)sender;
            myMediaElement.Stretch = Stretch.Fill;
            txt1.Text = btn.Name.ToString();
            switch (btn.Name.ToString())
            {
                case "btnFill":
                    myMediaElement.Stretch = Stretch.Fill;
                    break;
                case "btnNone":
                    myMediaElement.Stretch = Stretch.None;
                    break;
                case "btnUniform":
                    myMediaElement.Stretch = Stretch.Uniform;
                    break;
                case "btnUniformToFill":
                    myMediaElement.Stretch = Stretch.UniformToFill;
                    break;
            }
	    }
    }
}
// </SnippetMediaElementCSharpExampleWholePage>