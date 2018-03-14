// <Snippet2>
using System;
using System.Globalization;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml.Controls;

public class Example
{
    public static void Run(Windows.UI.Xaml.Controls.TextBlock outputBlock)
    {
        outputBlock.Text += String.Format("\nThe current culture is {0}.\n", CultureInfo.CurrentCulture.Name);
        ResourceLoader rl = new ResourceLoader();

        // Display greeting using the resources of the current culture.
        string greeting = rl.GetString("Greeting");
        outputBlock.Text += String.Format("{0}\n", String.IsNullOrEmpty(greeting) ? "Здравствуйте" :  greeting);

        
        // Display greeting using fr-FR resources.
        ResourceContext ctx = new Windows.ApplicationModel.Resources.Core.ResourceContext();
        ctx.Languages =  new string[] { "fr-FR" } ;

        ResourceMap rmap = ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
        string newGreeting = rmap.GetValue("Greeting", ctx).ValueAsString();

        outputBlock.Text += String.Format("\n\nCulture of Current Context: {0}\n", ctx.Languages[0]);
        outputBlock.Text += String.Format("{0}\n", String.IsNullOrEmpty(newGreeting) ? greeting : newGreeting);
        
    }
}
// </Snippet2>

namespace ResourceCS1
{
    public sealed partial class BlankPage : Page
    {
        // <Snippet1>
        public BlankPage()
        {
            
            InitializeComponent();
            Example.Run(outputBlock);
        }
        // </Snippet1>    
    }
}
