using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Threading;


namespace FocusSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            txtBoxResults.Clear();
        }

        private void TextBoxMouseDownHandler(object sender, MouseEventArgs e)
        {

            if (Mouse.RightButton == MouseButtonState.Pressed &&
                Mouse.LeftButton == MouseButtonState.Pressed  &&
                Mouse.MiddleButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Right,Left,Middle Buttons Pressed");
            }

            //<SnippetMouseRelatedSnippetsGetRightButtonMouse>
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Right Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetRightButtonMouse>
            //<SnippetMouseRelatedSnippetsGetLeftButtonMouse>
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Left Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetLeftButtonMouse>
            //<SnippetMouseRelatedSnippetsGetMiddleButtonMouse>
            if (Mouse.MiddleButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Middle Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetMiddleButtonMouse>
            //<SnippetMouseRelatedSnippetsGetX1ButtonMouse>
            if (Mouse.XButton1 == MouseButtonState.Pressed)
            {
                UpdateSampleResults("First Extended Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetX1ButtonMouse>
            //<SnippetMouseRelatedSnippetsGetX2ButtonMouse>
            if (Mouse.XButton2 == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Second Extended Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetX2ButtonMouse>

        }

        private void TextBoxMouseDeviceDownHandler(object sender, MouseEventArgs e)
        {
            //<SnippetMouseRelatedSnippetsGetMouseDevice>
            // Gets the mouse device associated with the current thread.
            MouseDevice currentMouseDevice = Mouse.PrimaryDevice;
            //</SnippetMouseRelatedSnippetsGetMouseDevice>


            if (currentMouseDevice.RightButton == MouseButtonState.Pressed &&
                currentMouseDevice.LeftButton == MouseButtonState.Pressed &&
                currentMouseDevice.MiddleButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Right,Left,Middle Buttons Pressed");
            }

            //<SnippetMouseRelatedSnippetsGetRightButtonMouseDevice>
            if (currentMouseDevice.RightButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Right Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetRightButtonMouseDevice>
            //<SnippetMouseRelatedSnippetsGetLeftButtonMouseDevice>
            if (currentMouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Left Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetLeftButtonMouseDevice>
            //<SnippetMouseRelatedSnippetsGetMiddleButtonMouseDevice>
            if (currentMouseDevice.MiddleButton == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Middle Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetMiddleButtonMouseDevice>
            //<SnippetMouseRelatedSnippetsGetX1ButtonMouseDevice>
            if (currentMouseDevice.XButton1 == MouseButtonState.Pressed)
            {
                UpdateSampleResults("First Extended Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetX1ButtonMouseDevice>
            //<SnippetMouseRelatedSnippetsGetX2ButtonMouseDevice>
            if (currentMouseDevice.XButton2 == MouseButtonState.Pressed)
            {
                UpdateSampleResults("Second Extended Button Pressed");
            }
            //</SnippetMouseRelatedSnippetsGetX2ButtonMouseDevice>

        }

        private void MouseMoveMouseHandler(object sender, RoutedEventArgs e)
        {
            StackPanel displayArea;
            displayArea = e.Source as StackPanel;

            if (displayArea != null)
            {
                //<SnippetMouseRelatedSnippetsPositionMouse>
                // displayArea is a StackPanel and txtBoxMousePosition is
                // a TextBox used to display the position of the mouse pointer.
                Point position = Mouse.GetPosition(displayArea);
                txtBoxMousePosition.Text = "X: " + position.X +
                    "\n" +
                    "Y: " + position.Y;
                //</SnippetMouseRelatedSnippetsPositionMouse>
            }
        }

        //<SnippetMouseRelatedSnippetsPositionMouseDevice>
        private void MouseMoveMouseDeviceHandler(object sender, RoutedEventArgs e)
        {
            
            MouseDevice currentMouseDevice = Mouse.PrimaryDevice;
            Point position;
            StackPanel source;

            source = e.Source as StackPanel;

            if (source != null)
            {
                position = currentMouseDevice.GetPosition(source);
                txtBoxMouseDevicePosition.Text = "X: " + position.X +
                    "\n" +
                    "Y: " + position.Y; 
            }
            
        }
        //</SnippetMouseRelatedSnippetsPositionMouseDevice>

        public void UpdateSampleResults(string output)
        {
            txtBoxResults.Text += output + "\n";
            
        }


    }
}