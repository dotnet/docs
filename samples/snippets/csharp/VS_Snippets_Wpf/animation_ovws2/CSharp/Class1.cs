using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    class Class1 : Window
    {
        private void CreateRectangle()
        {
            //<SnippetRectangleOpacityFadeExampleCode_1>
            StackPanel myPanel = new StackPanel();
            myPanel.Margin = new Thickness(10);

            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "myRectangle";
            this.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = Brushes.Blue;
            myPanel.Children.Add(myRectangle);
            this.Content = myPanel;
            //</SnippetRectangleOpacityFadeExampleCode_1>
        }

        private void CreateDoubleAnimation()
        {
            //<SnippetRectangleOpacityFadeExampleCode_2>
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            //</SnippetRectangleOpacityFadeExampleCode_2>
            //<SnippetRectangleOpacityFadeExampleCode_3>
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            //</SnippetRectangleOpacityFadeExampleCode_3>
            //<SnippetRectangleOpacityFadeExampleCode_4>
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            //</SnippetRectangleOpacityFadeExampleCode_4>
        }
    }
}
