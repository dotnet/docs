using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;


namespace SDKSamples
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

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Set button1 as the first element to get Mouse Capture,
            // if the user does not specifiy a different Button.
            _elementToCapture = Button1;
        }

        //<SnippetMouseCapturSampleCaptureElement>
        private void OnCaptureMouseRequest(object sender, RoutedEventArgs e)
        {
            Mouse.Capture(_elementToCapture);
        }
        //</SnippetMouseCapturSampleCaptureElement>

        //<SnippetMouseCaptureSampleUnCaptureElement>
        private void OnUnCaptureMouseRequest(object sender, RoutedEventArgs e)
        {
            // To release mouse capture, pass null to Mouse.Capture.
            Mouse.Capture(null);
        }
        //</SnippetMouseCaptureSampleUnCaptureElement>

        //<SnippetMouseCaptureGotMouseCaptureHandler>
        // GotMouseCapture event handler
        // MouseEventArgs.source is the element that has mouse capture
        private void ButtonGotMouseCapture(object sender, MouseEventArgs e)
        {
            Button source = e.Source as Button;
            
            if (source != null)
            {
                // Update the Label that displays the sample results.
                lblHasMouseCapture.Content = source.Name;
            }
            // Another way to get the element with Mouse Capture
            // is to use the static Mouse.Captured property.
            else
            {
                //<SnippetMouseCaptureMouseCaptured>
                // Mouse.Capture returns an IInputElement.
                IInputElement captureElement;

                captureElement = Mouse.Captured;

                // Update the Label that displays the element with mouse capture.
                lblHasMouseCapture.Content = captureElement.ToString();
                //</SnippetMouseCaptureMouseCaptured>
            }
        }
        //</SnippetMouseCaptureGotMouseCaptureHandler>

        private void ButtonLostMouseCapture(object sender, MouseEventArgs e)
        {

            Button source = e.Source as Button;

            if (source != null)
            {
                lblHasMouseCapture.Content = "";
            }
        }

        //***********************************************************
        //The rest of these methods are event handlers and methods  
        //used by the sample to process sample information.
        //***********************************************************
        private void OnButtonMouseEnter(object sender, RoutedEventArgs e)
        {
            Button source = e.Source as Button;

            if (_enlargeOnMouseOver)
            {
                if (source != null)
                {
                    source.Height += 15;
                    source.Width += 15;
                }
            }
        }

        private void ButtonMouseClick(object sender, RoutedEventArgs e)
        {
            Button source = e.Source as Button;

            if (source != null)
            {
                lblMouseClick.Content = source.Name;

            }
        }

        private void ButtonPreviewMouseDown(object sender, MouseEventArgs e)
        {
            Button source = e.Source as Button;

            if (source != null)
            {
                lblLastMouseDown.Content = source.Name;

            }
        }


        private void ButtonPreviewMouseUp(object sender, MouseEventArgs e)
        {
            Button source = e.Source as Button;

            if (source != null)
            {
                lblLastMouseUp.Content = source.Name;

            }
        }
        
        private void OnButtonMouseLeave(object sender, RoutedEventArgs e)
        {
            Button source = e.Source as Button;

            if (_enlargeOnMouseOver)
            {
                if (source != null)
                {
                    source.Height -= 15;
                    source.Width -= 15;
                }
            }
       
        }

        private void OnButtonMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Button source = e.Source as Button;

            if (_changeColorOnMouseWheel)
            {
                if (source != null)
                {
                    if (source.Background == Brushes.AliceBlue)
                    {
                        source.Background = Brushes.Gold;
                    }
                    else
                    {
                        source.Background = Brushes.AliceBlue;
                    }
                }
            }
        }


        private void OnRadioButtonSelected(object sender, RoutedEventArgs e)
        {
            RadioButton source = e.Source as RadioButton;

            if (source != null)
            {
                switch (source.Content.ToString())
                {
                    case "1":
                        _elementToCapture = Button1;
                        break;
                    case "2":
                        _elementToCapture = Button2;
                        break;
                    case "3":
                        _elementToCapture = Button3;
                        break;
                    case "4":
                        _elementToCapture = Button4;
                        break;
                    default:
                        break;
                }
            }
        }
        private void MouseOverChecked(object sender, RoutedEventArgs e)
        {
            _enlargeOnMouseOver = true;
        }
        private void MouseOverUnChecked(object sender, RoutedEventArgs e)
        {
            _enlargeOnMouseOver = false;
        }
        private void MouseWheelChecked(object sender, RoutedEventArgs e)
        {
            _changeColorOnMouseWheel = true;
        }
        private void MouseWheelUnChecked(object sender, RoutedEventArgs e)
        {
            _changeColorOnMouseWheel = false;
        }



        //private fields
        bool _enlargeOnMouseOver = false;
        bool _changeColorOnMouseWheel = false;
        IInputElement _elementToCapture;
    }
}