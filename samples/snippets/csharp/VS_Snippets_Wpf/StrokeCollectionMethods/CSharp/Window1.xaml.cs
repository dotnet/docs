using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace StrokeCollectionEraseMethods
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        StrokeCollectionDemo myInkSelector;

        public Window1()
            : base()
        {
            InitializeComponent();
            myInkSelector = new StrokeCollectionDemo();
            myInkSelector.Background = Brushes.Green;
            this.root.Children.Add(myInkSelector);
            this.KeyDown += new System.Windows.Input.KeyEventHandler(Window1_KeyDown);
            
        }

        void Window1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.H)
            {
                myInkSelector.InkDrawingAttributes.IsHighlighter = !myInkSelector.InkDrawingAttributes.IsHighlighter;
            }

        }

        // To use Loaded event put Loaded="OnLoad" attribute in root element of .xaml file.
        // private void OnLoad(object sender, EventArgs e) {}

        // Sample event handler:  
        private void HitTestWithEraser_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.HitTestWithEraser();
        }

        private void erasePath_Click(object sender, RoutedEventArgs e) 
        {
            myInkSelector.ErasePath();
        }

        private void ClipWithRect_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.ClipStrokesWithRect();
        }

        private void EraseWithRect_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.EraseStrokesWithRect();
        }

        private void RemoveFromRect_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.RemoveStrokesFromRect();
        }

        private void clipStrokes_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.ClipStrokes();
        }

        private void eraseStrokes_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.EraseStrokes();
        }

        private void RemoveStrokes_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.RemoveStrokes();
        }

        private void CopyStrokes_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.CopyStrokes();
        }

        private void ToggleSelection(object sender, RoutedEventArgs e)
        {
 
            if (myInkSelector.Mode == InkMode.Ink)
            {
                myInkSelector.Mode = InkMode.Select;
                btnToggleMode.Content = "Ink Mode";

            }
            else
            {
                myInkSelector.Mode = InkMode.Ink;
                btnToggleMode.Content = "Edit Mode";
            }
        }

        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.ClearStrokes();
        }

        private void SaveStrokes_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.SaveStrokes();
        }

        private void LoadStrokes_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.LoadStrokes();
        }


        private void GetIds_Click(object sender, RoutedEventArgs e)
        {
            myInkSelector.GetPropertyIds();
        }

         
    }
}