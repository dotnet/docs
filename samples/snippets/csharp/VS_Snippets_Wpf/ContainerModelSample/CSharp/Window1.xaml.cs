using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace ContainerModelSample
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

        //<SnippetContainerMouseDown>
        // When the ContainerUIElement3D that has the two cubes as its children gets the
        // routed click event, spin the cubes in a 360 degree circle
        private void ContainerMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            // spin the cubes around
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 
                                                                  360,
                                                                  new Duration(TimeSpan.FromSeconds(0.5)));
            containerRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, doubleAnimation);
        }
        //</SnippetContainerMouseDown>

        //<SnippetCube1MouseDown>
        // Change the color of the first cube from Blue to Red, or vice versa, when it is clicked
        private void Cube1MouseDown(object sender, MouseButtonEventArgs e)
        {
            cube1Material.Brush = (cube1Material.Brush == Brushes.Blue ? Brushes.Red : Brushes.Blue);
        }
        //</SnippetCube1MouseDown>

        //<SnippetCube2MouseDown>
        // Change the color of the second cube from Green to Yellow, or vice versa, when it is clicked
        private void Cube2MouseDown(object sender, MouseButtonEventArgs e)
        {
            cube2Material.Brush = (cube2Material.Brush == Brushes.Green ? Brushes.Yellow : Brushes.Green);            
        }
        //</SnippetCube2MouseDown>
    }
}
