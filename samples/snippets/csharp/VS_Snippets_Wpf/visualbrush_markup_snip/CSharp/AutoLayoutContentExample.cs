using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
namespace SDKSample
{
    public partial class AutoLayoutContentExample : Page
    {
        public AutoLayoutContentExample()
        {
            StackPanel stackPanel1 = ReturnStackPanel1();
            StackPanel stackPanel2 = ReturnStackPanel2();
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(stackPanel1);
            myStackPanel.Children.Add(stackPanel2);

            this.Content = myStackPanel;
        }

        private StackPanel ReturnStackPanel1()
        {
            // <SnippetAutoLayoutContentNonParentedUIElementExample>
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20, 0, 0, 0);
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness(0, 10, 0, 0);
            myTextBlock.Text = "AutoLayoutContent: True";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Stroke = Brushes.Black;
            myRectangle.StrokeThickness = 1;

            // Create the Fill for the rectangle using a VisualBrush.
            VisualBrush myVisualBrush = new VisualBrush();
            myVisualBrush.AutoLayoutContent = true;

            // This button is used as the visual for the VisualBrush.
            Button myButton = new Button();
            myButton.Content = "Hello, World";

            myVisualBrush.Visual = myButton;

            // Set the fill of the Rectangle to the Visual Brush.
            myRectangle.Fill = myVisualBrush;

            myStackPanel.Children.Add(myRectangle);

            TextBlock myTextBlock2 = new TextBlock();
            myTextBlock2.Margin = new Thickness(0, 10, 0, 0);
            myTextBlock2.Text = "AutoLayoutContent: False";
            myStackPanel.Children.Add(myTextBlock2);

            Rectangle myRectangle2 = new Rectangle();
            myRectangle2.Width = 100;
            myRectangle2.Height = 100;
            myRectangle2.Stroke = Brushes.Black;
            myRectangle2.StrokeThickness = 1;

            // Create the Fill for the rectangle using a VisualBrush.
            VisualBrush myVisualBrush2 = new VisualBrush();
            myVisualBrush2.AutoLayoutContent = false;

            // This button is used as the visual for the VisualBrush.
            Button myButton2 = new Button();
            myButton2.Content = "Hello, World";
            myButton2.Width = 100;
            myButton2.Height = 100;

            myVisualBrush2.Visual = myButton2;

            // Set the fill of the Rectangle to the Visual Brush.
            myRectangle2.Fill = myVisualBrush2;

            myStackPanel.Children.Add(myRectangle2);
            // </SnippetAutoLayoutContentNonParentedUIElementExample>
            return myStackPanel;
        }

        private StackPanel ReturnStackPanel2()
        {

            // <SnippetAutoLayoutContentParentedUIElementExample>
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20, 0, 0, 0);
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness(0, 10, 0, 0);
            myTextBlock.Text = "The UIElement";
            myStackPanel.Children.Add(myTextBlock);

            Button myButton = new Button();
            myButton.Content = "Hello, World";
            myButton.Width = 70;
            this.RegisterName("MyButton", myButton);
            myStackPanel.Children.Add(myButton);

            TextBlock myTextBlock2 = new TextBlock();
            myTextBlock2.Margin = new Thickness(0, 10, 0, 0);
            myTextBlock2.Text = "AutoLayoutContent: True";
            myStackPanel.Children.Add(myTextBlock2);

            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Stroke = Brushes.Black;
            myRectangle.StrokeThickness = 1;

            // Create the Fill for the rectangle using a VisualBrush.
            VisualBrush myVisualBrush = new VisualBrush();
            myVisualBrush.AutoLayoutContent = true;
            Binding buttonBinding = new Binding();
            buttonBinding.ElementName = "MyButton";
            BindingOperations.SetBinding(myVisualBrush, VisualBrush.VisualProperty, buttonBinding);

            // Set the fill of the Rectangle to the Visual Brush.
            myRectangle.Fill = myVisualBrush;

            // Add the first rectangle.
            myStackPanel.Children.Add(myRectangle);

            TextBlock myTextBlock3 = new TextBlock();
            myTextBlock3.Margin = new Thickness(0, 10, 0, 0);
            myTextBlock3.Text = "AutoLayoutContent: False";
            myStackPanel.Children.Add(myTextBlock3);

            Rectangle myRectangle2 = new Rectangle();
            myRectangle2.Width = 100;
            myRectangle2.Height = 100;
            myRectangle2.Stroke = Brushes.Black;
            myRectangle2.StrokeThickness = 1;

            // Create the Fill for the rectangle using a VisualBrush.
            VisualBrush myVisualBrush2 = new VisualBrush();
            myVisualBrush2.AutoLayoutContent = false;
            Binding buttonBinding2 = new Binding();
            buttonBinding2.ElementName = "MyButton";
            BindingOperations.SetBinding(myVisualBrush2, VisualBrush.VisualProperty, buttonBinding2);

            // Set the fill of the Rectangle to the Visual Brush.
            myRectangle2.Fill = myVisualBrush2;

            myStackPanel.Children.Add(myRectangle2);

            // </SnippetAutoLayoutContentParentedUIElementExample>
            return myStackPanel;
        }
        
    }
}