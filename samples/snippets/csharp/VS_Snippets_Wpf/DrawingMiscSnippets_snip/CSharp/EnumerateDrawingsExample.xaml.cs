using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;


namespace SDKSample
{


    public partial class EnumerateDrawingsExample: Page
    {

        public EnumerateDrawingsExample()
        {
            InitializeComponent();
        }

        private void retrieveDrawings(object sender, RoutedEventArgs e)
        {
            RetrieveDrawing(MainBorder);
        }

        //<SnippetGraphicsMMRetrieveDrawings>
        public void RetrieveDrawing(Visual v)
        {
            DrawingGroup dGroup = VisualTreeHelper.GetDrawing(v);
            EnumDrawingGroup(dGroup);

        }

         // Enumerate the drawings in the DrawingGroup.
         public void EnumDrawingGroup(DrawingGroup drawingGroup)
         {
             DrawingCollection dc = drawingGroup.Children;

             // Enumerate the drawings in the DrawingCollection.
             foreach (Drawing drawing in dc)
             {
                 // If the drawing is a DrawingGroup, call the function recursively.
                 if (drawing.GetType() == typeof(DrawingGroup))
                 {
                     EnumDrawingGroup((DrawingGroup)drawing);
                 }
                 else if (drawing.GetType() == typeof(GeometryDrawing))
                 {
                     // Perform action based on drawing type.  
                 }
                 else if (drawing.GetType() == typeof(ImageDrawing))
                 {
                     // Perform action based on drawing type.
                 }
                 else if (drawing.GetType() == typeof(GlyphRunDrawing))
                 {
                     // Perform action based on drawing type.
                 }
                 else if (drawing.GetType() == typeof(VideoDrawing))
                 {
                     // Perform action based on drawing type.
                 }
             }
         }
         //</SnippetGraphicsMMRetrieveDrawings>
     }
    

}
