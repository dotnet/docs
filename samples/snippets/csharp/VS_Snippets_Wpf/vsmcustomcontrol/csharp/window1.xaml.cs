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

namespace VSMCustomControl
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            nud.ValueChanged += new ValueChangedEventHandler(nud_ValueChanged);
        }

        void nud_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;

            if (n == null)
            {
                MessageBox.Show("no sender");
                return;
            }

            //e.Value;
        }

        //<SnippetGoToElementState>
        private void rect_MouseEvent(object sender, MouseEventArgs e)
        {
            if (rect.IsMouseOver)
            {
                VisualStateManager.GoToElementState(rect, "MouseEnter", true);
            }
            else
            {
                VisualStateManager.GoToElementState(rect, "MouseLeave", true);
            }
        }
        //</SnippetGoToElementState>

        //<SnippetVSMEasingFunctionLogic>
        bool isMouseDown;

        private void Canvas_MouseEvent(object sender, MouseEventArgs e)
        {
            isMouseDown = !isMouseDown;

            if (isMouseDown)
            {
                VisualStateManager.GoToElementState(canvasRoot, "CanvasButtonDown", true);
            }
            else
            {
                VisualStateManager.GoToElementState(canvasRoot, "CanvasButtonUp", true);
            }
        }
        //</SnippetVSMEasingFunctionLogic>
    }
}
