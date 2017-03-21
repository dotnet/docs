using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace GridSplitterSnips
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Page
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void InitializeGridSplitterSnip(object sender, EventArgs e)
        {
            GridSplitter myGridSplitter = new GridSplitter();
            Grid.SetRow(myGridSplitter,6);
            Grid.SetColumn(myGridSplitter,6);
            //<SnippetDragIncrement>
            myGridSplitter.DragIncrement = 10;
            //</SnippetDragIncrement>

            //<SnippetKeyboardIncrement>
            myGridSplitter.KeyboardIncrement = 25;
            //</SnippetKeyboardIncrement>

            //<SnippetResizeDirection>
            myGridSplitter.ResizeDirection = GridResizeDirection.Columns;
            //</SnippetResizeDirection>

            //<SnippetResizeBehavior>
            myGridSplitter.ResizeBehavior = GridResizeBehavior.CurrentAndNext;
            //</SnippetResizeBehavior>

            //<SnippetShowsPreview>
            myGridSplitter.ShowsPreview = true;
            //</SnippetShowsPreview>

            //<SnippetGridSplitterSimpleExample>
             GridSplitter mySimpleGridSplitter = new GridSplitter();
             Grid.SetColumn(mySimpleGridSplitter, 0);
             mySimpleGridSplitter.Background = Brushes.Blue;
             mySimpleGridSplitter.HorizontalAlignment = HorizontalAlignment.Right;
             mySimpleGridSplitter.VerticalAlignment = VerticalAlignment.Stretch;
             mySimpleGridSplitter.Width = 5;
            //</SnippetGridSplitterSimpleExample>

        }

    }
}