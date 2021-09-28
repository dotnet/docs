using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InkSelectorTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        InkSelector selector = new InkSelector();

        public Window1()
        {
            InitializeComponent();
            selector.Background = Brushes.Blue;
            root.Children.Add(selector);
            this.WindowState = WindowState.Maximized;
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == System.Windows.Input.Key.S)
            {
                if (selector.Mode == InkMode.Ink)
                {
                    selector.Mode = InkMode.Select;
                }
                else
                {
                    selector.Mode = InkMode.Ink;
                }
            }
            if (e.Key == System.Windows.Input.Key.C)
            {
                if (selector.InkDrawingAttributes.Color == Colors.Black)
                {
                    selector.InkDrawingAttributes.Color = Colors.Yellow;
                }
                else
                {
                    selector.InkDrawingAttributes.Color = Colors.Black;
                }
            }
        }
    }
}