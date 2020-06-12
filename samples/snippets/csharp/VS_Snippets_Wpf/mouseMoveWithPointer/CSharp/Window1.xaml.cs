using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Input;

namespace WCSamples
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

        //<SnippetMouseMovePointerGetPosition>
        // raised when the mouse pointer moves.
        // Expands the dimensions of an Ellipse when the mouse moves.
        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            // Get the x and y coordinates of the mouse pointer.
            System.Windows.Point position = e.GetPosition(this);
            double pX = position.X;
            double pY = position.Y;

            // Sets the Height/Width of the circle to the mouse coordinates.
            ellipse.Width = pX;
            ellipse.Height = pY;
        }
        //</SnippetMouseMovePointerGetPosition>
    }
}