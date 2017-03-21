using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;


namespace DrawingAttributesSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>


    public partial class Window1 : Window
    {
        //<Snippet3>
        InkCanvas inkCanvas1 = new InkCanvas();
        DrawingAttributes inkDA;
        DrawingAttributes highlighterDA;
        bool useHighlighter = false;

        // Add an InkCanvas to the window, and allow the user to 
        // switch between using a green pen and a purple highlighter 
        // on the InkCanvas.
        private void WindowLoaded(object sender, EventArgs e)
        {
            inkCanvas1.Background = Brushes.DarkSlateBlue;
            inkCanvas1.DefaultDrawingAttributes.Color = Colors.SpringGreen;

            root.Children.Add(inkCanvas1);

            // Set up the DrawingAttributes for the pen.
            inkDA = new DrawingAttributes();
            inkDA.Color = Colors.SpringGreen;
            inkDA.Height = 5;
            inkDA.Width = 5;
            inkDA.FitToCurve = false;

            // Set up the DrawingAttributes for the highlighter.
            highlighterDA = new DrawingAttributes();
            highlighterDA.Color = Colors.Orchid;
            highlighterDA.IsHighlighter = true;
            highlighterDA.IgnorePressure = true;
            highlighterDA.StylusTip = StylusTip.Rectangle;
            highlighterDA.Height = 30;
            highlighterDA.Width = 10;

            inkCanvas1.DefaultDrawingAttributes = inkDA;
        }

        // Create a button called switchHighlighter and use 
        // SwitchHighlighter_Click to handle the Click event.  
        // The useHighlighter variable is a boolean that indicates
        // whether the InkCanvas renders ink as a highlighter.

        //<Snippet2>
        // Switch between using the 'pen' DrawingAttributes and the 
        // 'highlighter' DrawingAttributes.
        void SwitchHighlighter_Click(Object sender, RoutedEventArgs e)
        {
            useHighlighter = !useHighlighter;
            
            if (useHighlighter)
            {
                switchHighlighter.Content = "Use Pen";
                inkCanvas1.DefaultDrawingAttributes = highlighterDA;
            }
            else
            {
                switchHighlighter.Content = "Use Highlighter";
                inkCanvas1.DefaultDrawingAttributes = inkDA;

            }
        }
        //</Snippet2>

        //</Snippet3>

        public Window1()
            : base()
        {
            InitializeComponent();
            //inkCanvas1.StrokeCollected += new InkCanvasStrokeCollectedEventHandler(inkCanvas1_StrokeCollected);
            inkCanvas1.Strokes.StrokesChanged += new StrokeCollectionChangedEventHandler(Strokes_StrokesChanged);
            inkCanvas1.DefaultDrawingAttributes.AttributeChanged += new PropertyDataChangedEventHandler(DefaultDrawingAttributes_AttributeChanged);
            //inkDA.AttributeChanged += new PropertyDataChangedEventHandler(inkDA_AttributeChanged);
            inkCanvas1.StrokeErasing += new InkCanvasStrokeErasingEventHandler(inkCanvas1_StrokeErasing);
            inkCanvas1.DefaultDrawingAttributesReplaced += new DrawingAttributesReplacedEventHandler(inkCanvas1_DefaultDrawingAttributesReplaced);
            // Uncomment the following line to assign custom properties.
            //AssignDrawingAttributesInstrument();
            ValidateHeightAndWidth();

        }

        //<Snippet17>
        void inkCanvas1_DefaultDrawingAttributesReplaced(object sender, DrawingAttributesReplacedEventArgs e)
        {
            if (e.NewDrawingAttributes.IsHighlighter)
            {
                this.Title = "Now using a highlighter.";
            }
            else
            {
                this.Title = "Now using a pen.";
            }
        }
        //</Snippet17>

        //<Snippet16>
        void inkCanvas1_StrokeErasing(object sender, InkCanvasStrokeErasingEventArgs e)
        {
            if (e.Stroke.DrawingAttributes.IsHighlighter)
            {
                e.Cancel = true;
            }
        }
        //</Snippet16>

        private void ValidateHeightAndWidth()
        {
            double DAHeight = 100;
            double DAWidth = 100;

            //<Snippet14>
            if (DAHeight < DrawingAttributes.MinHeight)
            {
                DAHeight = DrawingAttributes.MinHeight;
            }
            else if (DAHeight > DrawingAttributes.MaxHeight)
            {
                DAHeight = DrawingAttributes.MaxHeight;
            }

            inkCanvas1.DefaultDrawingAttributes.Height = DAHeight;
            //</Snippet14>

            //<Snippet15>
            if (DAWidth < DrawingAttributes.MinWidth)
            {
                DAWidth = DrawingAttributes.MinWidth;
            }
            else if (DAWidth > DrawingAttributes.MaxWidth)
            {
                DAWidth = DrawingAttributes.MaxWidth;
            }

            inkCanvas1.DefaultDrawingAttributes.Width = DAWidth;
            //</Snippet15>
        }

        private void InitializeAllProperties()
        {
            //<Snippet1>
            // Set up the DrawingAttributes for the pen.
            inkDA = new DrawingAttributes();
            inkDA.Color = Colors.SpringGreen;
            inkDA.Height = 5;
            inkDA.Width = 5;
            inkDA.FitToCurve = false;
            inkDA.StylusTipTransform = new Matrix(1, 0, 0, 5, 0, 0);

            // Set up the DrawingAttributes for the highlighter.
            highlighterDA = new DrawingAttributes();
            highlighterDA.Color = Colors.Orchid;
            highlighterDA.IsHighlighter = true;
            highlighterDA.IgnorePressure = true;
            highlighterDA.StylusTip = StylusTip.Rectangle;
            highlighterDA.Height = 30;
            highlighterDA.Width = 10;

            inkCanvas1.DefaultDrawingAttributes = inkDA;
            //</Snippet1>
        }
        //<Snippet6>
        void inkDA_AttributeChanged(object sender, PropertyDataChangedEventArgs e)
        {
            if (e.PropertyGuid == DrawingAttributeIds.Color)
            {
                this.Title = "The pen color is: " + e.NewValue.ToString();
            }
        }
        //</Snippet6>

        void DefaultDrawingAttributes_AttributeChanged(object sender, PropertyDataChangedEventArgs e)
        {
            this.Title = "default attribute changed";
        }


        //<Snippet4>
        Guid currentTimeGuid = new Guid("12345678-1234-1234-1234-123456789012");

        void Strokes_StrokesChanged(object sender, StrokeCollectionChangedEventArgs args)
        {
            foreach (Stroke s in args.Added)
            {
                s.AddPropertyData(currentTimeGuid, DateTime.Now);
            }
        }
        //</Snippet4>

        void SaveStrokes_Click(Object sender, RoutedEventArgs e)
        {
            //Byte[] isf = inkCanvas1.Strokes.Save(
            //    PersistenceFormat.InkSerializedFormat, 
            //    CompressionMode.Maximum);

            //FileStream fs = new FileStream("strokes.isf", FileMode.Create);
            //fs.Write(isf, 0, isf.Length);
            //fs.Close();


        }

        void LoadStrokes_Click(Object sender, RoutedEventArgs e)
        {
            //if (!File.Exists("strokes.isf"))
            //{
            //    MessageBox.Show("\"strokes.isf\" does not exist." +
            //        " Save the StrokeCollection before loading it.");
            //    return;
            //}

            //Byte[] buffer = new Byte[10000];
            //FileStream fs = new FileStream("strokes.isf",
            //    FileMode.Open, FileAccess.Read);
            //fs.Read(buffer, 0, buffer.Length);
            //fs.Close();

            //StrokeCollection strokes = new StrokeCollection(buffer);
            //inkCanvas1.Strokes = strokes;

            //ChangeAuthorsInk(aGuid, anAuthor, Colors.Red);

        }

        //<Snippet5>
        Guid purposeGuid = new Guid("12345678-9012-3456-7890-123456789012");
        string penValue = "pen";
        string highlighterValue = "highlighter";

        // Add a property to each DrawingAttributes object to 
        // specify its use.
        private void AssignDrawingAttributesInstrument()
        {
            inkDA.AddPropertyData(purposeGuid, penValue);
            highlighterDA.AddPropertyData(purposeGuid, highlighterValue);
        }

        // Change the color of the ink that on the InkCanvas that used the pen.
        void ChangeColors_Click(Object sender, RoutedEventArgs e)
        {
            foreach (Stroke s in inkCanvas1.Strokes)
            {
                if (s.DrawingAttributes.ContainsPropertyData(purposeGuid))
                {
                    object data = s.DrawingAttributes.GetPropertyData(purposeGuid);

                    if ((data is string) && ((string)data == penValue))
                    {
                        s.DrawingAttributes.Color = Colors.Black;
                    }
                }
            }
        }
        //</Snippet5>

        void ChangePenColors_Click(Object sender, RoutedEventArgs e)
        {
            if (inkCanvas1.DefaultDrawingAttributes.Color == Colors.Black)
            {
                inkDA.Color = Colors.AntiqueWhite;
            }
            else
            {
                inkDA.Color = Colors.Black;
            }
        }
 
       void ClearStrokes_Click(Object sender, RoutedEventArgs e)
        {
            inkCanvas1.Strokes.Clear();
            GetPropertyIDs(); 
        }


        void inkCanvas1_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
 //           SaveAuthor(inkCanvas1.DefaultDrawingAttributes, aGuid, currentAuthor);
        }

        void GetPropertyIDs()
        {
            //<Snippet7>
            Guid[] propertyIDs = inkDA.GetPropertyDataIds();
            //</Snippet7>
        }

        //<Snippet8>
        void CopyAttributes(Stroke someStroke)
        {
            DrawingAttributes attributes = new DrawingAttributes();
            attributes.Color = Colors.Red;
            someStroke.DrawingAttributes = attributes.Clone();
        }
        //</Snippet8>

        //<Snippet9>
        Guid customProperty = new Guid("12345678-9012-3456-7890-123456789012");
 
        void RemovePropertyDataId(DrawingAttributes attributes)
        {
            if (attributes.ContainsPropertyData(customProperty))
            {
                attributes.RemovePropertyData(customProperty);
            }
        }
        //</Snippet9>

        void AttributesEqual()
        {
        //<Snippet10>
            DrawingAttributes attributes1 = new DrawingAttributes();
            attributes1.Color = Colors.Blue;
            attributes1.StylusTip = StylusTip.Rectangle;
            attributes1.Height = 5;
            attributes1.Width = 5;

            DrawingAttributes attributes2 = new DrawingAttributes();
            attributes2.Color = Colors.Blue;
            attributes2.StylusTip = StylusTip.Rectangle;
            attributes2.Height = 5;
            attributes2.Width = 5;
        //</Snippet10>

        //<Snippet11>
            if (attributes1 == attributes2)
            {
                MessageBox.Show("The DrawingAttributes are equal");
            }
            else
            {
                MessageBox.Show("The DrawingAttributes are not equal");
            }
        //</Snippet11>


        //<Snippet12>
            if (attributes1.Equals(attributes2))
            {
                MessageBox.Show("The DrawingAttributes are equal");
            }
            else
            {
                MessageBox.Show("The DrawingAttributes are not equal");
            }
        //</Snippet12>

        //<Snippet13>
            if (attributes1 != attributes2)
            {
                MessageBox.Show("The DrawingAttributes are not equal");
            }
            else
            {
                MessageBox.Show("The DrawingAttributes are equal");
            }
        //</Snippet13>

        }

        void CompareAttributes_Click(Object sender, RoutedEventArgs e)
        {
            AttributesEqual();
        }
   }
}