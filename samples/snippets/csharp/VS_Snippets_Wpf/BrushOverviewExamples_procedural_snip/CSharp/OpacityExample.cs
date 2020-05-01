using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.BrushExamples
{

    public class OpacityExample : Page
    {

        public OpacityExample()
        {
            this.WindowTitle = "Opacity Example";
            this.Background = Brushes.White;
            StackPanel myMainPanel = new StackPanel();

            // <SnippetOpacityExample1CSharp>
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            SolidColorBrush partiallyTransparentSolidColorBrush
                = new SolidColorBrush(Colors.Blue);
            partiallyTransparentSolidColorBrush.Opacity = 0.25;
            myRectangle.Fill = partiallyTransparentSolidColorBrush;
            // </SnippetOpacityExample1CSharp>

            myMainPanel.Children.Add(myRectangle);

            this.Content = myMainPanel;
        }
    }
}
