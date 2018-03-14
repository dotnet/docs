using System;
using System.IO;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;

namespace StrokeCollectionEraseMethods
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>

    public partial class Window2 : Window
    {
        //Point[] points = { new Point(20, 10), new Point(60, 80), new Point(300, 150) };
        Stroke s;

        public Window2()
            : base()
        {
            InitializeComponent();

            StylusPointCollection points = new StylusPointCollection();
            StylusPoint p1 = new StylusPoint(20, 10);
            StylusPoint p2 = new StylusPoint(60, 80);
            StylusPoint p3 = new StylusPoint(300, 150);

            points.Add(p1);
            points.Add(p2);
            points.Add(p3);

            s = new Stroke(points);

            getBoundsButton.Click += new RoutedEventHandler(getBoundsButton_Click);
            
        }

        void getBoundsButton_Click(object sender, RoutedEventArgs e)
        {
            GetBounds();
        }

        // To use Loaded event put Loaded="OnLoad" attribute in root element of .xaml file.
        private void OnLoad(object sender, EventArgs e) {}

        //<Snippet21>
        // Copy the strokes from one InkCanvas to another InkCanvas.
        private void CopyStrokes_Click(object sender, RoutedEventArgs e) 
        {
            StrokeCollection strokes = inkCanvas1.Strokes.Clone();
            inkCanvas2.Strokes.Clear();
            inkCanvas2.Strokes.Add(strokes);

        }
        //</Snippet21>

        private void SwitchMode_Click(object sender, RoutedEventArgs e) 
        {
            if (inkCanvas1.EditingMode == InkCanvasEditingMode.Ink)
            {
                inkCanvas1.EditingMode = InkCanvasEditingMode.Select;
                inkCanvas2.EditingMode = InkCanvasEditingMode.Select;
                switchMode.Content = "Write";

            }
            else
            {
                inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
                inkCanvas2.EditingMode = InkCanvasEditingMode.Ink;
                switchMode.Content = "Select";
            }
        }

        //<Snippet20>
        public void GetBounds()
        {
            Rect bounds = inkCanvas1.Strokes.GetBounds();

            Rectangle boundsShape = new Rectangle();
            boundsShape.Width = bounds.Width;
            boundsShape.Height = bounds.Height;
            boundsShape.Stroke = Brushes.Red;

            InkCanvas.SetTop(boundsShape, bounds.Top);
            InkCanvas.SetLeft(boundsShape, bounds.Left);

            inkCanvas1.Children.Add(boundsShape);
        }
        //</Snippet20>
        
        // Remove the selected strokes from the InkCanvas.
        private void DeleteStrokes_Click(object sender, RoutedEventArgs e)
        {
            //inkCanvas1.Cut();

            //StrokeCollection selectedStrokes = inkCanvas1.GetSelectedStrokes();

            //inkCanvas1.Strokes.Remove(selectedStrokes);
            DeleteStroke(s);
        }

        //<Snippet7>
        // Replace the selected strokes with other strokes.
        private void ReplaceStrokes(StrokeCollection strokes)
        {
            StrokeCollection selectedStrokes = inkCanvas1.GetSelectedStrokes();

            if (selectedStrokes != null && selectedStrokes.Count > 0)
            {
                inkCanvas1.Strokes.Replace(selectedStrokes, strokes);
            }
        }
        //</Snippet7>

        //<Snippet8>
        // Put the specified stroke at the beginning of the inkCanvas1.Strokes
        private void InsertStroke(Stroke aStroke)
        {
            if (inkCanvas1.Strokes.Contains(aStroke))
            {
                return;
            }

            if (inkCanvas1.Strokes.Count > 0)
            {
                inkCanvas1.Strokes.Insert(0, aStroke);
            }
            else
            {
                inkCanvas1.Strokes.Add(aStroke);
            }
        }
        //</Snippet8>

        //<Snippet9>
        // Move all the strokes on the InkCanvas to the right.
        private void MoveStrokes_Click(object sender, RoutedEventArgs e)
        {
            Matrix moveMatrix = new Matrix(1, 0, 0, 1, 20, 0);

            inkCanvas1.Strokes.Transform(moveMatrix, false);
        }
        //</Snippet9>

        string inkFileName = "strokes.isf";

        //<Snippet10>
        private void SaveStrokes_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(inkFileName, FileMode.Create);
                inkCanvas1.Strokes.Save(fs);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
        //</Snippet10>

        //<Snippet11>
        private void LoadStrokes_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = null;

            if (!File.Exists(inkFileName))
            {
                MessageBox.Show("The file you requested does not exist." +
                    " Save the StrokeCollection before loading it.");
                return;
            }

            try
            {
                fs = new FileStream(inkFileName,
                    FileMode.Open, FileAccess.Read);
                StrokeCollection strokes = new StrokeCollection(fs);
                inkCanvas1.Strokes = strokes;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

        }
        //</Snippet11>

        //<Snippet12>
        Guid timestamp = new Guid("12345678-9012-3456-7890-123456789012");

        // Add a timestamp to the StrokeCollection.
        private void AddTimestamp_Click(object sender, RoutedEventArgs e)
        {

            inkCanvas1.Strokes.AddPropertyData(timestamp, DateTime.Now);
        }

        // Get the timestamp of the StrokeCollection.
        private void GetTimestamp_Click(object sender, RoutedEventArgs e)
        {

            if (inkCanvas1.Strokes.ContainsPropertyData(timestamp))
            {
                object date = inkCanvas1.Strokes.GetPropertyData(timestamp);

                if (date is DateTime)
                {
                    MessageBox.Show("This StrokeCollection's timestamp is " +
                        ((DateTime)date).ToString());
                }
            }
            else
            {
                MessageBox.Show(
                    "The StrokeCollection does not have a timestamp.");
            }
        }
        //</Snippet12>

        //<Snippet22>
        // Remove the specified stroke from the InkCanvas.
        private void RemoveStroke(Stroke aStroke)
        {
            int index = inkCanvas1.Strokes.IndexOf(aStroke);

            if (index != -1)
            {
                inkCanvas1.Strokes.RemoveAt(index);
            }
        }
        //</Snippet22>

        //<Snippet23>
        // Remove the specified stroke from the InkCanvas.
        private void DeleteStroke(Stroke aStroke)
        {
            if (inkCanvas1.Strokes.Contains(aStroke))
            {
                inkCanvas1.Strokes.Remove(aStroke);
            }
        }
        //</Snippet23>

        private void ReplaceStrokes_Click(object sender, RoutedEventArgs e)
        {
            
            StrokeCollection collection = new StrokeCollection();
            
            collection.Add(s);

            ReplaceStrokes(collection);
        }

        private void InsertStrokes_Click(object sender, RoutedEventArgs e)
        {
            InsertStroke(s);
        }

        private void AddStrokes_Click(object sender, RoutedEventArgs e)
        {
            Stroke stroke = s.Clone();
            Stroke[] strokeArray = {s};
            AddStrokes();
        }

        private void AddStrokes()
        {
            //<Snippet25>
            Stroke[] strokes = new Stroke[inkCanvas1.Strokes.Count];
            inkCanvas1.Strokes.CopyTo(strokes, 0);
            //</Snippet25>
        }

        private void ChangeColorOfFirstStroke_Click(object sender, RoutedEventArgs e)
        {
            //<Snippet26>
            if (inkCanvas1.Strokes.Count > 0)
            {
                Stroke firstStroke = inkCanvas1.Strokes[0];
                firstStroke.DrawingAttributes.Color = Colors.Green;
            }
            //</Snippet26>
        }

        //<Snippet27>
        private void GetPropertyIds(StrokeCollection strokes)
        {
            Guid[] propertyIds = strokes.GetPropertyDataIds();
        }
        //</Snippet27>

        private void RemovePropertyIds()
        {
            //<Snippet28>
            if (inkCanvas1.Strokes.ContainsPropertyData(timestamp))
            {
                inkCanvas1.Strokes.RemovePropertyData(timestamp);
            }
            //</Snippet28>

        }

        //<Snippet30>
        // Change the color of the ink that is on the InkCanvas.
        void ChangeColors_Click(Object sender, RoutedEventArgs e)
        {
            foreach (Stroke s in inkCanvas1.Strokes)
            {
                s.DrawingAttributes.Color = Colors.DarkMagenta;
            }
        }
        //</Snippet30>


    }
}










