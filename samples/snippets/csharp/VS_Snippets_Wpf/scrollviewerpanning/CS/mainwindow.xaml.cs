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

namespace ScrollViewerPanning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StringBuilder sb = CreateText();
            //textBox1.Text = sb.ToString();
            //TextBlock1.Text = sb.ToString();
        }

        private static StringBuilder CreateText()
        {

            StringBuilder sb = new StringBuilder("Hello world ");

            for (int i = 0; i < 2000; i++)
            {
                sb.Append(i);
                sb.Append(" Hello world ");

                if (i % 20 == 0)
                {
                    sb.AppendLine();
                }
            }
            return sb;
        }

        private void ManipulationBoundaryFeedbackHandler(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Feedback: {0} sender: {1}  Source: {2}", e.BoundaryFeedback.Translation, sender.GetType(), e.Source.GetType());
            FrameworkElement element = sender as FrameworkElement;

            element.RenderTransform = new TranslateTransform(e.BoundaryFeedback.Translation.X, e.BoundaryFeedback.Translation.Y);
            e.Handled = true;
        }
    }
}
