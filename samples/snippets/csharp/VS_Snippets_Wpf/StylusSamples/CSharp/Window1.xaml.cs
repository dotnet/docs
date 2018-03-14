using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;

namespace StylusSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        ContextMenu textBoxContextMenu;
        ContextMenu onTabletMenu;

        //<Snippet6>
        public Window1()
        {
            InitializeComponent();
        //</Snippet6>    

            this.WindowState = WindowState.Maximized;
            textbox1.Background = Brushes.LightPink;

            //textbox1.StylusDown += new System.Windows.Input.StylusDownEventHandler(textbox1_StylusDown);
            //textbox1.StylusMove += new StylusEventHandler(textbox1_StylusMove);
            //textbox1.StylusUp += new StylusEventHandler(textbox1_StylusUp);

            //textbox1.PreviewStylusDown += new StylusDownEventHandler(textbox1_PreviewStylusDown);
            //textbox1.PreviewStylusUp += new StylusEventHandler(textbox1_PreviewStylusUp);
            //textbox1.StylusSystemGesture += new StylusSystemGestureEventHandler(textbox1_StylusSystemGesture);

            //textbox1.GotStylusCapture += new StylusEventHandler(textbox1_GotStylusCapture);
            //textbox1.LostStylusCapture += new StylusEventHandler(textbox1_LostStylusCapture);

            //textbox1.StylusButtonDown += new StylusButtonEventHandler(textbox1_StylusButtonDown);
            //textbox1.StylusButtonUp += new StylusButtonEventHandler(textbox1_StylusButtonUp);

            //textbox1.PreviewStylusButtonDown += new StylusButtonEventHandler(textbox1_PreviewStylusButtonDown);
            //textbox1.PreviewStylusButtonUp += new StylusButtonEventHandler(textbox1_PreviewStylusButtonUp);
            //textbox1.PreviewStylusMove += new StylusEventHandler(textbox1_PreviewStylusMove);
            //textbox1.PreviewStylusSystemGesture += new StylusSystemGestureEventHandler(textbox1_PreviewStylusSystemGesture);

            //textbox1.PreviewStylusInRange += new StylusEventHandler(textbox1_PreviewStylusInRange);
            //textbox1.PreviewStylusOutOfRange += new StylusEventHandler(textbox1_PreviewStylusOutOfRange);

            textbox1.StylusInRange += new StylusEventHandler(textbox1_StylusInRange);

            //this.StylusInAirMove += new StylusEventHandler(Window1_StylusInAirMove);
            //this.PreviewStylusInAirMove += new StylusEventHandler(Window1_PreviewStylusInAirMove);
            //this.PreviewStylusDown += new StylusDownEventHandler(Window1_PreviewStylusDown);

            //button1.StylusEnter += new StylusEventHandler(button1_StylusEnter);
            //button1.StylusLeave += new StylusEventHandler(button1_StylusLeave);

            textBoxContextMenu = new ContextMenu();
            onTabletMenu = new ContextMenu();
            MenuItem airMenu = new MenuItem();
            airMenu.Header = "In Air";
            textBoxContextMenu.Items.Add(airMenu);

            MenuItem touchingMenu = new MenuItem();
            touchingMenu.Header = "On digitizer";
            onTabletMenu.Items.Add(touchingMenu);
        //<Snippet7>
        }
        //</Snippet7>

        //<Snippet23>
        void textbox1_StylusInRange(object sender, StylusEventArgs e)
        {
            StylusButtonCollection buttons = e.StylusDevice.StylusButtons;

            StylusButton barrelButton = buttons.GetStylusButtonByGuid(StylusPointProperties.BarrelButton.Id);
            if (barrelButton != null)
            {
                textbox1.AppendText(barrelButton.StylusButtonState.ToString());
            }
        
            textbox1.AppendText("\r\n");
 
        }
        //</Snippet23>

        //<Snippet22>
        void textbox1_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            Point pos = e.GetPosition(textbox1);
            textbox1.AppendText("X: " + pos.X + " Y: " + pos.Y + "\n");
        }
        //</Snippet22>

        //<Snippet20>
        void textbox1_PreviewStylusOutOfRange(object sender, StylusEventArgs e)
        {
            if (e.StylusDevice.Inverted)
            {
                textbox1.AppendText("Pen is inverted\n");
            }
            else
            {
                textbox1.AppendText("Pen is not inverted\n");
            }
        }
        //</Snippet20>

        //<Snippet21>
        void textbox1_PreviewStylusInRange(object sender, StylusEventArgs e)
        {
            if (e.StylusDevice.Inverted)
            {
                textbox1.AppendText("Pen is inverted\n");
            }
            else
            {
                textbox1.AppendText("Pen is not inverted\n");
            }
        }
        //</Snippet21>

        //<Snippet17>
        void textbox1_PreviewStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            textbox1.AppendText(e.SystemGesture.ToString() + "\n");
        }
        //</Snippet17>

        //<Snippet16>
        void textbox1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            Point pos = e.GetPosition(textbox1);
            textbox1.AppendText("X: " + pos.X + " Y: " + pos.Y + "\n");
        }
        //</Snippet16>

        //<Snippet15>
        void Window1_PreviewStylusInAirMove(object sender, StylusEventArgs e)
        {
            textbox1.AppendText(Stylus.DirectlyOver.ToString() + "\n");
        }
        //</Snippet15>
        
        //<Snippet14>
        void textbox1_PreviewStylusButtonUp(object sender, StylusButtonEventArgs e)
        {
            textbox1.AppendText(e.StylusButton.Name + "\n");
        }
        //</Snippet14>
        
        //<Snippet13>
        void textbox1_PreviewStylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            textbox1.AppendText(e.StylusButton.Name + "\n");
        }
        //</Snippet13>

        //public Window1()
        //{
        //   Stylus.SetIsPressAndHoldEnabled(this, true);

        //}

        //<Snippet12>
        private void textbox1_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            textbox1.AppendText(e.SystemGesture.ToString() + "\n");
        }
        //</Snippet12>

        //<Snippet11>
        void textbox1_StylusButtonUp(object sender, StylusButtonEventArgs e)
        {
            if (e.StylusButton.Guid != StylusPointProperties.BarrelButton.Id)
            {
                return;
            }

            if (textbox1.SelectedText == "")
            {
                return;
            }

            Clipboard.SetDataObject(textbox1.SelectedText);
        }
        //</Snippet11>

        //<snippet10>
        void textbox1_LostStylusCapture(object sender, StylusEventArgs e)
        {
            textbox1.Background = Brushes.White;
        }

        void textbox1_GotStylusCapture(object sender, StylusEventArgs e)
        {
            textbox1.Background = Brushes.Red;
        }
        //</snippet10>

        private void PressAndHoldSnippets()
        {
            //<Snippet9>
            if (!Stylus.GetIsPressAndHoldEnabled(horizontalSlider1))
            {
                Stylus.SetIsPressAndHoldEnabled(horizontalSlider1, true);
            }
            //</Snippet9>
        }

        //<Snippet4>
        Brush originalColor;

        void button1_StylusLeave(object sender, StylusEventArgs e)
        {
            button1.Background = originalColor;
        }

        void button1_StylusEnter(object sender, StylusEventArgs e)
        {
            originalColor = button1.Background; 
            button1.Background = Brushes.Gray;
        }
        //</Snippet4>

        //<Snippet5>
        void Window1_PreviewStylusDown(object sender, StylusEventArgs e)
        {
            IInputElement capturedElement = Stylus.Captured;

            if (capturedElement != null)
            {
                capturedElement.ReleaseStylusCapture();
            }
        }
        //</Snippet5>

        //<Snippet3>
        void Window1_StylusInAirMove(object sender, StylusEventArgs e)
        {
            textbox1.AppendText(Stylus.DirectlyOver.ToString() + "\n");
        }
        //</Snippet3>

        //<Snippet2>
        // Show or hide a shortcut menu when the user clicks the barrel button.
        void textbox1_StylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            if (e.StylusButton.Guid != StylusPointProperties.BarrelButton.Id)
            {
                return;
            }

            if (textbox1.ContextMenu == null)
            {
                textbox1.ContextMenu = textBoxContextMenu;
            }
            else
            {
                textbox1.ContextMenu = null;
            }
        }
        //</Snippet2>

        // Close the context menu when the user taps on another part of the
        // TextBox.
        void textbox1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            WriteEventName("textbox1_PreviewStylusDown");
            textbox1.ContextMenu = null;
        }

        //<Snippet1>
        void textbox1_StylusDown(object sender, StylusDownEventArgs e)
        {
            Stylus.Capture(textbox1);
        }

        void textbox1_StylusMove(object sender, StylusEventArgs e)
        {
            Point pos = e.GetPosition(textbox1);
            textbox1.AppendText("X: " + pos.X + " Y: " + pos.Y + "\n");
        }

        void textbox1_StylusUp(object sender, StylusEventArgs e)
        {
            Stylus.Capture(textbox1, CaptureMode.None);
        }
        //</Snippet1>

        //<Snippet8>
        void TextBoxStylusUp(object sender, StylusEventArgs e)
        {
            StylusDevice currentStylus = Stylus.CurrentStylusDevice;

            if (currentStylus.Inverted)
            {
                string selectedText = textbox1.SelectedText;
                textbox1.SelectedText = "";
            }
        }
        //</Snippet8>

        private void WriteEventName(string name)
        {
            textbox1.AppendText(name + "\n");
            textbox1.ScrollToEnd();
            //this.CaretIndex = this.Text.Length - 1;
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, EventArgs e) {}

            // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

        private void Button1Click(object sender, RoutedEventArgs e)
        {
            this.textbox1.Text = "";
            

            //Stylus.Capture(textbox1);
        }
    }
}