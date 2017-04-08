using System;
using System.Collections.Generic;
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


namespace ThemeReourcesControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    public partial class Painter : System.Windows.Controls.UserControl
    {

        Brush ellipseBrush;

        public Painter()
        {
            InitializeComponent();

            // MyEllipseBrush is a theme level resource so it has a ComponentResourceKey.
            ComponentResourceKey brushKey = new ComponentResourceKey(typeof(Painter), "MyEllipseBrush");
            ellipseBrush = (Brush)this.TryFindResource(brushKey);
        }

        void FillBrush(object sender, RoutedEventArgs e)
        {

            if (Ellipse1.Fill == null)
            {
                Ellipse1.Fill = ellipseBrush;
            }
            else
            {
                Ellipse1.Fill = null;
            }
        }

    }


    //This is a dummy class with no ControlTemplate.  It exists just so the
    //ComponentResourceKey snippet can reference NumericUpDown
    //public class NumericUpDown : UserControl
    //{
    //}
}