using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;


namespace WCSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public static RoutedCommand CaptureMouseCommand;

        public Window1()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.MouseMove += new MouseEventHandler(MouseMoveHighlightCapture);
            this.MouseDown += new MouseButtonEventHandler(MyMouseDown);
            this.GotMouseCapture +=new MouseEventHandler(MyGotMouseCapture);
            this.LostMouseCapture += new MouseEventHandler(MyLostMouseCapture);

            CaptureMouseCommand = new RoutedCommand();
            

            MouseGesture CaptureMouseGesture = new MouseGesture(MouseAction.WheelClick, ModifierKeys.Control);
            KeyGesture CaptureMouseCommandKeyGesture = new KeyGesture(Key.A, ModifierKeys.Alt);
            
            CommandBinding CaptureMouseCommandBinding = new CommandBinding
                (CaptureMouseCommand, CaptureMouseCommandExecuted, CaptureMouseCommandCanExecute);

            InputBinding CaptureMouseCommandInputBinding = new InputBinding
                (CaptureMouseCommand, CaptureMouseGesture);
            InputBinding CaptureMouseCommandKeyBinding = new InputBinding
                (CaptureMouseCommand, CaptureMouseCommandKeyGesture);

            this.CommandBindings.Add(CaptureMouseCommandBinding);
            this.InputBindings.Add(CaptureMouseCommandInputBinding);
            this.InputBindings.Add(CaptureMouseCommandKeyBinding);
        }
//<SnippetIsMouseCaptured>
        private void CaptureMouseCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Mouse Command");
            IInputElement target = Mouse.DirectlyOver;
    
            target = target as Control;
            if (target != null)
            {
                if (!target.IsMouseCaptured)
                {
                    Mouse.Capture(target);
                }
                else
                {
                    Mouse.Capture(null);
                }
            }
        }
//</SnippetIsMouseCaptured>
        private void CaptureMouseCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        //<SnippetMouseEventArgsPosition>
        private void GetMousePosition(object sender, MouseEventArgs e)
        {
            // Casting the MouseEventArgs.OriginalSource as an IInputElement.
            IInputElement source = e.OriginalSource as IInputElement;

            // If souce is not null, get the position.
            if (source != null)
            {
                Point position = e.GetPosition(source);

                // Updates a textbox with the current postion of the mouse,
                // relative to the object which raised the event.
                txtBox.Text = position.ToString();
            }
        }
        //</SnippetMouseEventArgsPosition>

        //<SnippetMouseEventArgsMouseButton>
        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            //<SnippetMouseEventArgsRightButtonDown>
            if (e.RightButton == MouseButtonState.Pressed)
            {
                MessageBox.Show("The Right Mouse Button is pressed");
            }
            //</SnippetMouseEventArgsRightButtonDown>

            //<SnippetMouseEventArgsLeftButtonDown>
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MessageBox.Show("The Left Mouse Button is pressed");
            }
            //</SnippetMouseEventArgsLeftButtonDown>

            //<SnippetMouseEventArgsMiddleButtonDown>
            if (e.MiddleButton == MouseButtonState.Pressed)
            {

                MessageBox.Show("The Middle Mouse Button is pressed");
            }
            //</SnippetMouseEventArgsMiddleButtonDown>

            //<SnippetMouseEventArgsXButton1ButtonDown>
            if (e.XButton1 == MouseButtonState.Pressed)
            {
                MessageBox.Show("The XButton1 Mouse Button is pressed");
            }
            //</SnippetMouseEventArgsXButton1ButtonDown>

            //<SnippetMouseEventArgsXButton2ButtonDown>
            if (e.XButton2 == MouseButtonState.Pressed)
            {
                MessageBox.Show("The XButton2 Mouse Button is pressed");
            }
            //</SnippetMouseEventArgsXButton2ButtonDown>
        }
        //</SnippetMouseEventArgsMouseButton>


        private void GetDevices(object sender, MouseEventArgs e)
        {
            //<SnippetMouseEventArgsMouseDevice>
            MouseDevice mouseDevice = e.MouseDevice;
            //</SnippetMouseEventArgsMouseDevice>

            //<SnippetMouseEventArgsStylusDevice>
            StylusDevice stylusDevice = e.StylusDevice;
            //</SnippetMouseEventArgsStylusDevice>

        }

        private void btn1Click(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.WhiteSmoke;

        }

        //<SnippetMouseEventArgsChangedButton>
        private void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            Control src = e.Source as Control;

            if (src != null)
            {
                switch (e.ChangedButton)
                {
                    case MouseButton.Left:
                        src.Background = Brushes.Green;
                        break;
                    case MouseButton.Middle:
                        src.Background = Brushes.Red;
                        break;
                    case MouseButton.Right:
                        src.Background = Brushes.Yellow;
                        break;
                    case MouseButton.XButton1:
                        src.Background = Brushes.Brown;
                        break;
                    case MouseButton.XButton2:
                        src.Background = Brushes.Purple;
                        break;
                    default:
                        break;
                }
            }
        }
        //</SnippetMouseEventArgsChangedButton>

        //<SnippetMouseEventArgsClickCount>
        private void ClickCount(object sender, MouseButtonEventArgs e)
        {
            Label source = sender as Label;

            if (source != null)
            {
                source.Content = e.ClickCount.ToString();
            }
        }
        //</SnippetMouseEventArgsClickCount>

        //<SnippetMouseEventArgsButtonStatePressed>
        private void MouseButtonEventHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.Background = Brushes.BurlyWood;
            }

            if (e.ButtonState == MouseButtonState.Released)
            {
                this.Background = Brushes.Ivory;
            }
        }
        //</SnippetMouseEventArgsButtonStatePressed>

        //<SnippetMouseEventArgsButtonStateReleased>
        private void MouseUpHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Released)
            {
                this.Background = Brushes.Ivory;
            }
        }
        //</SnippetMouseEventArgsButtonStateReleased>


        //<SnippetMouseWheelDelta>
        // Moves the TextBox named box when the mouse wheel is rotated.
        // The TextBox is on a Canvas named MainCanvas.
        private void MouseWheelHandler(object sender, MouseWheelEventArgs e)
        {
            // If the mouse wheel delta is positive, move the box up.
            if (e.Delta > 0)
            {
                if (Canvas.GetTop(box) >= 1)
                {
                    Canvas.SetTop(box, Canvas.GetTop(box) - 1);
                }
            }

            // If the mouse wheel delta is negative, move the box down.
            if (e.Delta < 0)
            {
                if ((Canvas.GetTop(box) + box.Height) <= (MainCanvas.Height))
                {
                    Canvas.SetTop(box, Canvas.GetTop(box) + 1);
                }
            }

        }
        //</SnippetMouseWheelDelta>


        //<SnippetMouseClickCountDoubleClick>
        private void OnMouseDownClickCount(object sender, MouseButtonEventArgs e)
        {
            // Checks the number of clicks.
            if (e.ClickCount == 1)
            {
                // Single Click occurred.
                lblClickCount.Content = "Single Click";
            }
            if (e.ClickCount == 2)
            {
                // Double Click occurred.
                lblClickCount.Content = "Double Click";
            }
            if (e.ClickCount >= 3)
            {
                // Triple Click occurred.
                lblClickCount.Content = "Triple Click";
            }
        }
        //</SnippetMouseClickCountDoubleClick>



        private void CaptureMouseOnMouseEnter(object sender, MouseEventArgs e)
        {
            MouseDevice mDevice = e.MouseDevice;
            bool captureResult;

            captureResult = mDevice.Capture(captureTarget);

            if (captureResult == true)
            {
                captureTarget.BorderBrush = Brushes.Red;
            }
        }

        private void MouseMoveHighlightCapture(object sender, MouseEventArgs e)
        {
            IInputElement sourceElement = e.MouseDevice.Captured;
            if (sourceElement != null)
            {
                captureTarget.Content = sourceElement.ToString();
            }
            else
            {
                captureTarget.Content = "NULL";
            }
            Control sourceControl = sourceElement as Control;
            
            if (sourceControl != null)
            {
                sourceControl.Background = Brushes.Blue;
            }
           // captureTarget.Content = "BLAH";
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            IInputElement sourceElement = e.MouseDevice.Captured;
            if (sourceElement != null)
            {
                captureButton.Content = sourceElement.ToString();
            }
            else
            {
                captureButton.Content = "NULL";
            }
        }

        //<SnippetMouseSnippetsGotLostMouseCapture>
        private void MyGotMouseCapture(object sender, MouseEventArgs e)
        {
            Control source = e.Source as Control;

            if (source != null)
            {
                source.Height += 50;
                source.Width += 50;
            }

        }
        private void MyLostMouseCapture(object sender, MouseEventArgs e)
        {
            Control source = e.Source as Control;

            if (source != null)
            {
                source.Height -= 50;
                source.Width -= 50;
            }

        }
        //</SnippetMouseSnippetsGotLostMouseCapture>
    }


}