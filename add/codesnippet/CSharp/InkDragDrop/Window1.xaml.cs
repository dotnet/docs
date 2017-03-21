//<Snippet2>
using System;
using System.IO;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

public partial class Window1 : Window
{

    public Window1()
    {
        InitializeComponent();
    }

    //<Snippet3>
    void InkCanvas_PreviewMouseDown(object sender, MouseEventArgs e)
    {
        InkCanvas ic = (InkCanvas)sender;
        
        Point pt = e.GetPosition(ic);

        // If the user is moving selected strokes, prepare the strokes to be
        // moved to another InkCanvas.
        if (ic.HitTestSelection(pt) == 
            InkCanvasSelectionHitResult.Selection)
        {
            StrokeCollection selectedStrokes = ic.GetSelectedStrokes();
            StrokeCollection strokesToMove = selectedStrokes.Clone();
        
            // Remove the offset of the selected strokes so they
            // are positioned when the strokes are dropped.
            Rect inkBounds = strokesToMove.GetBounds();
            TranslateStrokes(strokesToMove, -inkBounds.X, -inkBounds.Y);
            
            // Perform drag and drop.
            MemoryStream ms = new MemoryStream();
            strokesToMove.Save(ms);
            DataObject dataObject = new DataObject(
                StrokeCollection.InkSerializedFormat, ms);
            
            DragDropEffects effects = 
                DragDrop.DoDragDrop(ic, dataObject, 
                                    DragDropEffects.Move);

            if ((effects & DragDropEffects.Move) == 
                 DragDropEffects.Move)
            {
                // Remove the selected strokes 
                // from the current InkCanvas.
                ic.Strokes.Remove(selectedStrokes);
            }
        }
    }
    //</Snippet3>

    void InkCanvas_Drop(object sender, DragEventArgs e)
    {
        // Get the strokes that were moved.
        InkCanvas ic = (InkCanvas)sender;
        MemoryStream ms = (MemoryStream)e.Data.GetData(
                           StrokeCollection.InkSerializedFormat);
        ms.Position = 0;
        StrokeCollection strokes = new StrokeCollection(ms);

        // Translate the strokes to the position at which
        // they were dropped.
        Point pt = e.GetPosition(ic);
        TranslateStrokes(strokes, pt.X, pt.Y);

        // Add the strokes to the InkCanvas and keep them selected.
        ic.Strokes.Add(strokes);
        ic.Select(strokes);
    }

    // Helper method that transletes the specified strokes.
    void TranslateStrokes(StrokeCollection strokes, 
                          double x, double y)
    {
        Matrix mat = new Matrix();
        mat.Translate(x, y);
        strokes.Transform(mat, false);
    }

    void switchToSelect(object sender, RoutedEventArgs e)
    {
        ic1.EditingMode = InkCanvasEditingMode.Select;
        ic2.EditingMode = InkCanvasEditingMode.Select;
    }

    void switchToInk(object sender, RoutedEventArgs e)
    {
        ic1.EditingMode = InkCanvasEditingMode.Ink;
        ic2.EditingMode = InkCanvasEditingMode.Ink;
    }
}
//</Snippet2>