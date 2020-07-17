using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class EnumerateDrawingsExample : Page
    {
        public EnumerateDrawingsExample()
        {
            InitializeComponent();
        }

        private void EnumerateButton_OnClick(object sender, RoutedEventArgs e)
        {
            RetrieveDrawing(MainBorder);
        }

        //<SnippetGraphicsMMRetrieveDrawings>
        public void RetrieveDrawing(Visual v)
        {
            DrawingGroup drawingGroup = VisualTreeHelper.GetDrawing(v);
            EnumDrawingGroup(drawingGroup);
        }

        // Enumerate the drawings in the DrawingGroup.
        public void EnumDrawingGroup(DrawingGroup drawingGroup)
        {
            DrawingCollection dc = drawingGroup.Children;

            // Enumerate the drawings in the DrawingCollection.
            foreach (Drawing drawing in dc)
            {
                // If the drawing is a DrawingGroup, call the function recursively.
                if (drawing is DrawingGroup group)
                {
                    EnumDrawingGroup(group);
                }
                else if (drawing is GeometryDrawing)
                {
                    // Perform action based on drawing type.
                }
                else if (drawing is ImageDrawing)
                {
                    // Perform action based on drawing type.
                }
                else if (drawing is GlyphRunDrawing)
                {
                    // Perform action based on drawing type.
                }
                else if (drawing is VideoDrawing)
                {
                    // Perform action based on drawing type.
                }
            }
        }

        //</SnippetGraphicsMMRetrieveDrawings>
    }
}
