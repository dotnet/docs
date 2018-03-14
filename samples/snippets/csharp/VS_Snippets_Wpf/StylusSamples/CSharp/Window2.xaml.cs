using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Input;

namespace StylusSamples
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>

    public partial class Window2 : Window
    {
        //ScaleTransform buttonTransform = new ScaleTransform(1.5, 1.5);
        TextBox textbox1 = new TextBox();
        Button button1 = new Button();
        Button clearText = new Button();
        TextBox output = new TextBox();
        CheckBox recordMoveCheckBox = new CheckBox();

        //InkCanvas inkCanvas1;
        public Window2()
        {
            InitializeComponent();
            //inkCanvas1.StylusInRange += new System.Windows.Input.StylusEventHandler(inkCanvas1_StylusInRange);
            //inkCanvas1.StylusOutOfRange += new System.Windows.Input.StylusEventHandler(inkCanvas1_StylusOutOfRange);
            //inkCanvas1.StylusDown += new StylusDownEventHandler(inkCanvas1_StylusDown);
            
            Canvas.SetTop(textbox1, 0);
            Canvas.SetLeft(textbox1, 0);

            textbox1.Width = 200;
            textbox1.Background = Brushes.DarkBlue;
            //myCanvas.Children.Add(textbox1);

            Canvas.SetTop(button1, 0);
            Canvas.SetLeft(button1, 0);
            button1.Content = "Move me";

            myCanvas.MouseMove += new MouseEventHandler(myCanvas_MouseMove);
            myCanvas.Children.Add(button1);
            button1.RenderTransform = null;
            button1.Click += new RoutedEventHandler(button1_Click);
            
            Canvas.SetTop(clearText, 25);
            Canvas.SetLeft(clearText, 0);
            clearText.Content = "Clear text";
            clearText.Click += new RoutedEventHandler(clearText_Click);
            myCanvas.Children.Add(clearText);

            Canvas.SetTop(output, 100);
            output.Width = 1000;
            output.Height = 1000;
            output.Background = Brushes.White;
            
            myCanvas.Children.Add(output);

            myCanvas.KeyDown += new KeyEventHandler(myCanvas_KeyDown);

            AnimateButton();
        }

        //<Snippet24>
        void AnimateButton()
        {
            TranslateTransform buttonTransform = new TranslateTransform(0, 0);
            button1.RenderTransform = buttonTransform;

            // Animate the Button's position.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.By = 100;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            buttonTransform.BeginAnimation(TranslateTransform.XProperty, myDoubleAnimation);       
      
        }
        //</Snippet24>

        //<Snippet25>
        void SynchronizeStylus()
        {
            Stylus.Synchronize();
            UIElement element = (UIElement)Stylus.DirectlyOver;
            output.Text += "The stylus is over " + element.ToString() + "\r\n";
        }
        //</Snippet25>

        //<Snippet26>
        void SynchronizeCurrentStylus()
        {
            StylusDevice currentStylus = Stylus.CurrentStylusDevice;

            currentStylus.Synchronize();
            UIElement element = (UIElement) currentStylus.DirectlyOver;
            output.Text += "The stylus is over " + element.ToString() + "\r\n";
        }
        //</Snippet26>

        void SynchronizeMouse()
        {
            Mouse.Synchronize();
            UIElement element = (UIElement) Mouse.DirectlyOver;
            output.Text += "The stylus is over " + element.ToString() + "\r\n";
        }

        void myCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R)
            {
                recordMouseMove = !recordMouseMove;
                output.Text += "Record MouseMove: " + recordMouseMove.ToString() + "\n";
                return;
            }
            if (e.Key == Key.M)
            {
                SynchronizeCurrentStylus();
            }
         
        }

        void clearText_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            recordMouseMove = false;
        }

        int i = 0;
        bool recordMouseMove = false;
        void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!recordMouseMove)
            {
                return;
            }
            output.Text += "MouseMove: ";
            output.Text += Mouse.DirectlyOver.ToString() + ", " + Stylus.DirectlyOver.ToString() + " " + i.ToString() + "\r\n";
            i++;
            if (i > 3)
            {
                i = 0;
            }
            //Stylus.Synchronize();
        }

        void button1_Click(object sender, RoutedEventArgs e)
        {
            //recordMouseMove = true;
            //double buttonPos = Canvas.GetLeft(button1);

            //if (buttonPos == 0)
            //{
            //    Canvas.SetLeft(button1, 100);
            //}
            //else
            //{
            //    Canvas.SetLeft(button1, 0);
            //}

            //if (button1.LayoutTransform == null)
            //{
            //    //button1.LayoutTransform = buttonTransform;
                
            //}
            //else
            //{
            //    //button1.LayoutTransform = null;
            //}

            //UIElement elementBeforeSynchronize = (UIElement)Stylus.DirectlyOver;
            //Stylus.Synchronize();
            //UIElement elementAfterSynchronize = (UIElement)Stylus.DirectlyOver;
            //MessageBox.Show("Before Stylus.Synchronize: " + elementBeforeSynchronize.ToString() + "\r\n" +
            //"After Stylus.Synchronize: " + elementAfterSynchronize.ToString());

            //UIElement elementBeforeSynchronize = (UIElement)Mouse.DirectlyOver;
            //Mouse.Synchronize();
            //UIElement elementAfterSynchronize = (UIElement)Mouse.DirectlyOver;
            //MessageBox.Show("Before Mouse.Synchronize: " + elementBeforeSynchronize.ToString() + "\r\n" +
            //    "After Mouse.Synchronize: " + elementAfterSynchronize.ToString());
            
        }

        

        void inkCanvas1_StylusDown(object sender, StylusDownEventArgs e)
        {
            StylusPointCollection points = e.StylusDevice.GetStylusPoints(inkCanvas1);
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, EventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

        //<Snippet18>
        void inkCanvas1_StylusInRange(object sender, StylusEventArgs e)
        {
            if (e.StylusDevice.Inverted == true)
            {
                inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByStroke;
                inkCanvas1.Cursor = System.Windows.Input.Cursors.Hand;
            }
            else
            {
                inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
                inkCanvas1.Cursor = System.Windows.Input.Cursors.Pen;
            }
        }
        //</Snippet18>

        //<Snippet19>
        void inkCanvas1_StylusOutOfRange(object sender, StylusEventArgs e)
        {
            inkCanvas1.Cursor = System.Windows.Input.Cursors.Arrow;
        }   
        //</Snippet19>
    }
}