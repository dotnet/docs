using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Windows.Input;
//using System.Windows.Design;
using System.Collections;

namespace StrokeCollectionEraseMethods
{
    // This control allows the user to input and select ink.  When the
    // user selects ink, the lasso remains visible until they erase, or clip
    // the selected strokes, or clear the selection.  When the control is
    // in selection mode, strokes that are selected turn red.
    public class StrokeCollectionDemo : InkSelector
    {
        Guid dateTimeGuid = new Guid("12345678-9012-3456-7890-123456789012");
        InkPresenter presenter;
        
        public StrokeCollectionDemo()
        {
            presenter = this.Presenter;
            this.presenter.Strokes.PropertyDataChanged += new PropertyDataChangedEventHandler(Strokes_PropertyDataChanged);

            
        }

        //<Snippet29>
        void Strokes_PropertyDataChanged(object sender, PropertyDataChangedEventArgs e)
        {
            if ((e.PropertyGuid == dateTimeGuid) && (e.NewValue is DateTime))
            {
                MessageBox.Show("The timestamp for the strokes is " +
                    ((DateTime)e.NewValue).ToString());

            }
        }
        //</Snippet29>

        // Assign the current time to the StrokeCollection and save it.
        public void SaveStrokes()
        {
            if (presenter.Strokes.ContainsPropertyData(dateTimeGuid))
            {
                presenter.Strokes.RemovePropertyData(dateTimeGuid);
            }

            presenter.Strokes.AddPropertyData(dateTimeGuid, DateTime.Now);

            FileStream fs = new FileStream("strokes.isf", FileMode.Create);
            presenter.Strokes.Save(fs);

            // Be sure to close the FileStream after you save the StrokeCollection.
            fs.Close();
        }

        // Open "strokes.isf" and get the time the StrokeCollection was saved.
        public void LoadStrokes()
        {

            if (!File.Exists("strokes.isf"))
            {
                MessageBox.Show("\"strokes.isf\" does not exist." +
                    " Save the StrokeCollection before loading it.");
                return;
            }

            FileStream fs = new FileStream("strokes.isf",
                FileMode.Open, FileAccess.Read);

            StrokeCollection strokes = new StrokeCollection(fs);

            // Be sure to close the FileStream after you create a new StrokeCollection.
            fs.Close();
            presenter.Strokes = strokes;

            // Get the time the StrokeCollection was saved.
            if (presenter.Strokes.ContainsPropertyData(dateTimeGuid))
            {
                object date = presenter.Strokes.GetPropertyData(dateTimeGuid);
                
                if (date is DateTime)
                {
                    MessageBox.Show("This StrokeCollection was saved on " + 
                        ((DateTime) date).ToString());
                }
                else
                {
                    MessageBox.Show(
                        "The property data is not a DateTime object.");
                }
            }

        }
        
        // This snippet illustrates the Clip and Erase methods.
        // It assumes that there is a Stroke called lasso, and an Inkpresenter called presenter.
        //<Snippet2>
        // Erase the selected strokes.
        public void EraseStrokes(Stroke lasso)
        {
            Point[] strokePoints = (Point[])lasso.StylusPoints;
            presenter.Strokes.Erase(strokePoints);
        }
        //</Snippet2>

        //<Snippet13>
        // Clip the selected strokes.
        public void ClipStrokes(Stroke lasso)
        {
            Point[] strokePoints = (Point[])lasso.StylusPoints;
            presenter.Strokes.Clip(strokePoints);
        }
        //</Snippet13>

        //<Snippet14>
        // Erase the ink that intersects the lasso.
        public void ErasePath(Stroke lasso)
        {
            EllipseStylusShape eraserTip = new EllipseStylusShape(5, 5);
            Point[] strokePoints = (Point[])lasso.StylusPoints;

            presenter.Strokes.Erase(strokePoints, eraserTip);
        }
        //</Snippet14>

        public void CopyStrokes()
        {
            CopyStrokeCollection(presenter.Strokes);
        }

        //<Snippet5>
        public void CopyStrokeCollection(StrokeCollection strokes)
        {
            MemoryStream strokesInMemory = new MemoryStream();
            strokes.Save(strokesInMemory);
            
            DataObject dataobj = new DataObject(StrokeCollection.InkSerializedFormat,
                strokesInMemory);

            Clipboard.SetDataObject(dataobj, true);

        }
        //</Snippet5>

        // Remove the lasso stroke.
        public void ClearSelection()
        {
            if (SelectingStroke != null)
            {
                presenter.Strokes.Remove(SelectingStroke);
                SelectingStroke = null;
            }
        }

        //<Snippet15>
        // Change the color of all the strokes at the specified position.
        public void SelectStrokes(Point position)
        {
            StrokeCollection selected = presenter.Strokes.HitTest(position, 5);

            foreach (Stroke s in selected)
            {
                s.DrawingAttributes.Color = Colors.Purple;
            }

        }
        //</Snippet15>

 
        public int Count
        {
            get
            {
                return presenter.Strokes.Count;
            }
        }

        Point[] ConvertToPointArray(StylusPointCollection stylusPointsCollection)
        {
            ArrayList strokePoints = new ArrayList();

            foreach (StylusPoint p in stylusPointsCollection)
            {
                strokePoints.Add((Point)p);
            }

            return (Point[])strokePoints.ToArray(typeof(Point));
            
        }

        public void EraseStrokes()
        {
            if (SelectingStroke == null)
            {
                return;
            }

            EraseStrokes(SelectingStroke);
            SelectingStroke = null;
        }

        // Clip the selected strokes.
        public void ClipStrokes()
        {
            if (SelectingStroke == null)
            {
                return;
            }

            ClipStrokes(SelectingStroke);
            SelectingStroke = null;
        }

        // Erase the ink that intersects the lasso.
        public void ErasePath()
        {
            if (SelectingStroke == null)
            {
                return;
            }
            ErasePath(SelectingStroke);
            SelectingStroke = null;
        }

        public void EraseStrokesWithRect()
        {
            //<Snippet34>
            Rect rect = new Rect(100, 100, 200, 200);
            presenter.Strokes.Erase(rect);
            //</Snippet34>
        }

        public void ClipStrokesWithRect()
        {
            //<Snippet35>
            Rect rect = new Rect(100, 100, 200, 200);
            presenter.Strokes.Clip(rect);
            //</Snippet35>
        }

        public void RemoveStrokesFromRect()
        {
            //<Snippet36>
            Rect rect = new Rect(100, 100, 200, 200);
            StrokeCollection strokes = presenter.Strokes.HitTest(rect, 50);

            presenter.Strokes.Remove(strokes);
            //</Snippet36>
        }

        //<Snippet16>
        // Remove the strokes within the lasso from the InkPresenter
        public void RemoveStrokes(Point[] lasso)
        {
            StrokeCollection strokes = presenter.Strokes.HitTest(lasso, 80);

            presenter.Strokes.Remove(strokes);
            
        }
        //</Snippet16>

        public void HitTestWithEraser()
        {
            if (SelectingStroke == null)
            {
                return;
            }
            Point[] points = ConvertToPointArray(SelectingStroke.StylusPoints);
            HitTestWithEraser(points);
            presenter.Strokes.Remove(SelectingStroke);
            SelectingStroke = null;
        }

        //<Snippet37>
        private void HitTestWithEraser(Point[] points)
        {
            RectangleStylusShape eraser = new RectangleStylusShape(3, 3, 0);

            StrokeCollection strokes = presenter.Strokes.HitTest(points, eraser);

            foreach (Stroke s in strokes)
            {
                s.DrawingAttributes.Color = Colors.Purple;
            }
        }
        //</Snippet37>

        public void RemoveStrokes()
        {
            if (SelectingStroke == null)
            {
                return;
            }
            RemoveStrokes(ConvertToPointArray(SelectingStroke.StylusPoints));
            SelectingStroke = null;
        }

        public void GetPropertyIds()
        {
            Guid[] ids = presenter.Strokes.GetPropertyDataIds();
            MessageBox.Show(ids.Length.ToString());
        }
    }
}
