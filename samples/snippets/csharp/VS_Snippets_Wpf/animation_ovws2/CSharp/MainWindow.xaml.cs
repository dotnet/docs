//<SnippetRectangleOpacityFadeExampleCode>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    //<SnippetRectangleOpacityFadeExampleCode_100>
    public partial class MainWindow : Window
    {
        private Storyboard myStoryboard;
        //</SnippetRectangleOpacityFadeExampleCode_100>

        public MainWindow()
        {
            InitializeComponent();

            StackPanel myPanel = new StackPanel();
            myPanel.Margin = new Thickness(10);

            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "myRectangle";
            this.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = Brushes.Blue;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            //<SnippetRectangleOpacityFadeExampleCode_101>
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            //</SnippetRectangleOpacityFadeExampleCode_101>
            //<SnippetRectangleOpacityFadeExampleCode_102>
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            //</SnippetRectangleOpacityFadeExampleCode_102>
            //<SnippetRectangleOpacityFadeExampleCode_103>
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));
            //</SnippetRectangleOpacityFadeExampleCode_103>

            // Use the Loaded event to start the Storyboard.
            //<SnippetRectangleOpacityFadeExampleCode_104>
            myRectangle.Loaded += new RoutedEventHandler(myRectangleLoaded);
            //</SnippetRectangleOpacityFadeExampleCode_104>
            myPanel.Children.Add(myRectangle);
            this.Content = myPanel;
        }

        //<SnippetRectangleOpacityFadeExampleCode_105>
        private void myRectangleLoaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }
        //</SnippetRectangleOpacityFadeExampleCode_105>
    }
}
//</SnippetRectangleOpacityFadeExampleCode>
