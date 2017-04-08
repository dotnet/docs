using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using StrokeSnippets_CS;

namespace StrokeSnippets_CS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        //private MyBorder border1;

        public Window1()
            : base()
        {
            InitializeComponent();

            // Get rid of this as soon as I fix Window1.xaml

            // Set up border control to get stroke events
            // (must have a background to get stroke events)
            //border1 = new MyBorder();

            //SolidColorBrush myB = new SolidColorBrush(Colors.Aquamarine);

            //border1.Background = myB;
            //border1.Background.Opacity = 0.5;

            // Get current runtime version #
            //Assembly rAss = Assembly.GetExecutingAssembly();

            //Title = "CLR runtime version: " + rAss.ImageRuntimeVersion;
        }

        // Remove touched stroke points
        void button1Click(object sender, RoutedEventArgs e)
        {
            border1.state = MyBorder.sMode.clip;
        }

        // Remove touched strokes
        void button2Click(object sender, RoutedEventArgs e)
        {
            border1.state = MyBorder.sMode.remove;
        }

        // Remove encircled strokes
        void button3Click(object sender, RoutedEventArgs e)
        {
            border1.state = MyBorder.sMode.surround;
        }

        // Add strokes to collection
        void button4Click(object sender, RoutedEventArgs e)
        {
            border1.state = MyBorder.sMode.add;
            border1.shadow = false;
        }

        // Add shadowed strokes to collection
        void button5Click(object sender, RoutedEventArgs e)
        {
            border1.state = MyBorder.sMode.add;
            border1.shadow = true;
        }

        void button6Click(object sender, RoutedEventArgs e)
        {
            border1.FitToCurve = !border1.FitToCurve;

            if (border1.FitToCurve)
            {
                button6.Content = "FtC: on";
            }
            else
            {
                button6.Content = "FtC: off";
            }
        }

        DrawingMode mode = DrawingMode.Solid;

        void ToggleDrawingMode_Click(object sender, RoutedEventArgs e)
        {
            if (mode == DrawingMode.Solid)
            {
                border1.ChangeDrawingMode(DrawingMode.StyulusPoints);
                mode = DrawingMode.StyulusPoints;
            }
            else
            {
                border1.ChangeDrawingMode(DrawingMode.Solid);
                mode = DrawingMode.Solid;
            }
        }
}
}
