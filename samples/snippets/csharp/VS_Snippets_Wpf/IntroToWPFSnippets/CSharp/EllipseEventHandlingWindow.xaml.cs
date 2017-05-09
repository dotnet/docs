//<SnippetHandleEllipseMouseUpEventCODEBEHIND>
using System.Windows;
using System.Windows.Input;

namespace SDKSample
{
    public partial class EllipseEventHandlingWindow : Window
    {
        public EllipseEventHandlingWindow()
        {
            InitializeComponent();
        }

        void clickableEllipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Display a message
            MessageBox.Show("You clicked the ellipse!");
        }
    }
}
//</SnippetHandleEllipseMouseUpEventCODEBEHIND>