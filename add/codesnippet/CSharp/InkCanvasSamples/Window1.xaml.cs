using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Collections.Generic;
using System.Windows.Ink;
using System.Windows.Input;
using System.IO;
using System.Collections.ObjectModel;

namespace InkCanvasSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        Rectangle box = new Rectangle();
        TextBlock textBlock1;
        string inkFileName = "strokes.isf";
        public Window1()
        {
            InitializeComponent();

            inkCanvas1.DefaultDrawingAttributes.Width = 3;
            inkCanvas1.DefaultDrawingAttributes.Height = 3;
            inkCanvas1.DefaultDrawingAttributes.Color = Colors.Firebrick;

            copyButton.Click += new RoutedEventHandler(copyButton_Click);
            pasteButton.Click += new RoutedEventHandler(pasteButton_Click);
            copyXamlButton.Click += new RoutedEventHandler(copyXamlButton_Click);
            selectElementsButton.Click += new RoutedEventHandler(selectElementsButton_Click);
            cutSelectionButton.Click += new RoutedEventHandler(cutSelectionButton_Click);
            this.KeyDown += new System.Windows.Input.KeyEventHandler(Window1_KeyDown);
            comparePointDescriptionsButton.Click += new RoutedEventHandler(comparePointDescriptionsButton_Click);
            changePointDescriptionsButton.Click += new RoutedEventHandler(changePointDescriptionsButton_Click);
            changeColorsOfSelectionButton.Click += new RoutedEventHandler(changeColorsOfSelectionButton_Click);
            replaceStrokeButton.Click += new RoutedEventHandler(switchPlayersButton_Click);


            inkCanvas1.StylusDown += new StylusDownEventHandler(inkCanvas1_StylusDown);
            inkCanvas1.StrokeCollected += new InkCanvasStrokeCollectedEventHandler(inkCanvas1_StrokeCollected);

            inkCanvas1.StrokeErasing += new InkCanvasStrokeErasingEventHandler(inkCanvas1_StrokeErasing);
            inkCanvas1.SelectionMoving += new InkCanvasSelectionEditingEventHandler(inkCanvas1_SelectionMoving);
            inkCanvas1.SelectionChanging += new InkCanvasSelectionChangingEventHandler(inkCanvas1_SelectionChanging);
            inkCanvas1.SelectionChanged += new EventHandler(inkCanvas1_SelectionChanged);
            inkCanvas1.StrokesReplaced += new InkCanvasStrokesReplacedEventHandler(inkCanvas1_StrokesReplaced);
            inkCanvas1.SelectionResizing += new InkCanvasSelectionEditingEventHandler(inkCanvas1_SelectionResizing);
            inkCanvas1.SelectionResized += new EventHandler(inkCanvas1_SelectionResized);
            inkCanvas1.SelectionMoved += new EventHandler(inkCanvas1_SelectionMoved);
            inkCanvas1.StrokeErased += new RoutedEventHandler(inkCanvas1_StrokeErased);
            //inkCanvas1.Clip = new RectangleGeometry(new Rect(100, 100, 200, 200));
            inkCanvas1.EditingModeChanged += new RoutedEventHandler(inkCanvas1_EditingModeChanged);
            inkCanvas1.EditingModeInvertedChanged += new RoutedEventHandler(inkCanvas1_EditingModeInvertedChanged);
            inkCanvas1.ActiveEditingModeChanged += new RoutedEventHandler(inkCanvas1_ActiveEditingModeChanged);

            this.WindowState = WindowState.Maximized;
            //InitializePlayersCanvases();

            positionButtonButton.Click += new RoutedEventHandler(positionButtonButton_Click);

            // These methods contain snippets.
            
            //UseCustomCursorOnInkCanvas();
            //DisableMoveAndResize();
            //ShowPreferredPasteFormats();
            //PointEraseStrokes();
            //AddTextBlock();
        }

        
        // <Snippet36>
        void inkCanvas1_ActiveEditingModeChanged(object sender, RoutedEventArgs e)
        {
            this.Title = inkCanvas1.ActiveEditingMode.ToString();
        }
        // </Snippet36>

        void positionButtonButton_Click(object sender, RoutedEventArgs e)
        {
            AttachedPropertiesSnippets();
        }

        void ShowPreferredPasteFormats()
        {
            //<Snippet26>
            InkCanvasClipboardFormat[] formats = new InkCanvasClipboardFormat[]
                                        { 
                                          InkCanvasClipboardFormat.InkSerializedFormat,
                                          InkCanvasClipboardFormat.Xaml
                                        };

            inkCanvas1.PreferredPasteFormats = formats;
            //</Snippet26>

        }

        //<Snippet20>
        void inkCanvas1_EditingModeInvertedChanged(object sender, EventArgs e)
        {
            if (inkCanvas1.EditingModeInverted == InkCanvasEditingMode.EraseByPoint)
            {
                erasingModeLabel.Text = "Erase by point";
            }
            else if (inkCanvas1.EditingModeInverted == InkCanvasEditingMode.EraseByStroke)
            {
                erasingModeLabel.Text = "Erase by stroke";
            }
        }
        //</Snippet20>

        //<Snippet21>
        void inkCanvas1_EditingModeChanged(object sender, EventArgs e)
        {
            if (inkCanvas1.EditingMode == InkCanvasEditingMode.Ink)
            {
                modeLabel.Text = "Ink";
            }
            else if (inkCanvas1.EditingMode == InkCanvasEditingMode.Select)
            {
                modeLabel.Text = "select";
            }
        }
        //</Snippet21>

        // <Snippet19>
        // Unselect the items on the InkCanvas once the user has moved them.
        void inkCanvas1_SelectionMoved(object sender, EventArgs e)
        {
            inkCanvas1.Select(null, null);
        }
        // </Snippet19>

        // <Snippet18>
        void inkCanvas1_StrokeErased(object sender, RoutedEventArgs e)
        {
            Title = "Stroke erased " + inkCanvas1.Strokes.Count.ToString();
        }
        // </Snippet18>

        //<Snippet23>
        void inkCanvas1_SelectionResized(object sender, EventArgs e)
        {
            inkCanvas1.Select(null, null);
        }
        //</Snippet23>


        // <Snippet16>
        Rect selectionBounds;

        // Don't allow the user to make the selection smaller than its original size.
        void inkCanvas1_SelectionResizing(object sender, InkCanvasSelectionEditingEventArgs e)
        {
            if (selectionBounds == null || selectionBounds.IsEmpty)
            {
                return;
            }

            double resizeHeight;
            double resizeWidth;

            // If the user made the height of the selection smaller, 
            // use the selection's original height.
            if (e.NewRectangle.Height < selectionBounds.Height)
            {
                resizeHeight = selectionBounds.Height;
            }
            else
            {
                resizeHeight = e.NewRectangle.Height;
            }

            // If the user made the width of the selection smaller, 
            // use the selection's original width.
            if (e.NewRectangle.Width < selectionBounds.Width)
            {
                resizeWidth = selectionBounds.Width;
            }
            else
            {
                resizeWidth = e.NewRectangle.Width;
            }

            // Create a the new rectangle with the appropriate width and height.
            e.NewRectangle = new Rect(e.NewRectangle.X, e.NewRectangle.Y, resizeWidth, resizeHeight);
        }

        // Keep track of the selection bounds.
        void inkCanvas1_SelectionChanged(object sender, EventArgs e)
        {
            selectionBounds = inkCanvas1.GetSelectionBounds();
        }
        // </Snippet16>

        //<Snippet15>
        StrokeCollection player1;
        StrokeCollection player2;

        void InitializePlayersCanvases()
        {
            player1 = inkCanvas1.Strokes;
            player2 = new StrokeCollection();
        }

        // Use a different "inking surface" for each player.
        void switchPlayersButton_Click(object sender, RoutedEventArgs e)
        {
            if (StrokeCollection.ReferenceEquals(inkCanvas1.Strokes, player1))
            {
                inkCanvas1.Strokes = player2;
            }
            else
            {
                inkCanvas1.Strokes = player1;
            }
        }

        void inkCanvas1_StrokesReplaced(object sender, InkCanvasStrokesReplacedEventArgs e)
        {
            if (StrokeCollection.ReferenceEquals(e.NewStrokes, player1))
            {
                Title = "Player one's turn";
            }
            else
            {
                Title = "Player two's turn";
            }
        }
        //</Snippet15>

        // <Snippet14>
        void inkCanvas1_SelectionChanging(object sender, InkCanvasSelectionChangingEventArgs e)
        {
            StrokeCollection selectedStrokes = e.GetSelectedStrokes();
            
            foreach (Stroke aStroke in inkCanvas1.Strokes)
            {
                if (selectedStrokes.Contains(aStroke))
                {
                    aStroke.DrawingAttributes.Color = Colors.RoyalBlue;
                }
                else
                {
                    aStroke.DrawingAttributes.Color = inkCanvas1.DefaultDrawingAttributes.Color;
                }

            }
        }
        // </Snippet14>

        //<Snippet13>
        void inkCanvas1_SelectionMoving(object sender, InkCanvasSelectionEditingEventArgs e)
        {
            // Allow the selection to only move horizontally.
            Rect newRect = e.NewRectangle;
            e.NewRectangle = new Rect(newRect.X, e.OldRectangle.Y, newRect.Width, newRect.Height);
            
        }
        //</Snippet13>


        void changeColorsOfSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            //<Snippet11>
            StrokeCollection selectedStrokes = inkCanvas1.GetSelectedStrokes();

            foreach (Stroke aStroke in selectedStrokes)
            {
                aStroke.DrawingAttributes.Color = Colors.Red;
            }
            //</Snippet11>

            //<Snippet12>
            ScaleTransform scaler = new ScaleTransform(2,2);

            ReadOnlyCollection<UIElement> selectedElements = inkCanvas1.GetSelectedElements();

            foreach (UIElement element in selectedElements)
            {
                element.RenderTransform = scaler;
            }
            //</Snippet12>
        }

        void inkCanvas1_StrokeErasing(object sender, InkCanvasStrokeErasingEventArgs e)
        {
                        
        }

        void comparePointDescriptionsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Stroke s in inkCanvas1.Strokes)
            {
                MessageBox.Show(s.StylusPoints.Description.PropertyCount.ToString());
            }
        }

        void changePointDescriptionsButton_Click(object sender, RoutedEventArgs e)
        {
            //<Snippet9>
            inkCanvas1.DefaultStylusPointDescription = new StylusPointDescription(
                new StylusPointPropertyInfo[] {
                    new StylusPointPropertyInfo(StylusPointProperties.X),
                    new StylusPointPropertyInfo(StylusPointProperties.Y),
                    new StylusPointPropertyInfo(StylusPointProperties.NormalPressure),
                    new StylusPointPropertyInfo(StylusPointProperties.TipButton)});
            //</Snippet9>
        }

        private void SaveStrokes()
        {
            //<Snippet10>
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
            //</Snippet10>
        }

        //<Snippet22>

        Guid currentTimeGuid = new Guid("12345678-1234-1234-1234-123456789012");

        void inkCanvas1_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            e.Stroke.AddPropertyData(currentTimeGuid, DateTime.Now);

        }

        //</Snippet22>

        void AddTextBlock()
        {
            //<Snippet8>
            textBlock1 = new TextBlock();
            textBlock1.Text = "TextBlock content";
            Canvas.SetTop(textBlock1, 100);
            Canvas.SetLeft(textBlock1, 100);
            inkCanvas1.Children.Add(textBlock1);
            //</Snippet8>

            //<Snippet37>
            inkCanvas1.Background = Brushes.LightGreen;
            //</Snippet37>

            //<Snippet24>
            ReadOnlyCollection<ApplicationGesture> enabledGestures = inkCanvas1.GetEnabledGestures();
            //</Snippet24>
        }

        void inkCanvas1_StylusDown(object sender, StylusDownEventArgs e)
        {
            StylusPointDescription desc = e.GetStylusPoints(inkCanvas1, inkCanvas1.DefaultStylusPointDescription).Description;
        }

        void DisableMoveAndResize()
        {
            //<Snippet7>
            inkCanvas1.ResizeEnabled = false;
            inkCanvas1.MoveEnabled = false;
            //</Snippet7>
        }

        void UseCustomCursorOnInkCanvas()
        {
            //<Snippet5>
            inkCanvas1.UseCustomCursor = true;
            inkCanvas1.Cursor = Cursors.Pen;
            //</Snippet5>

        }

        void PointEraseStrokes()
        {
            //<Snippet6>
            inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByPoint;
            inkCanvas1.EraserShape = new EllipseStylusShape(5, 5);
            //</Snippet6>

        }

        void selectElementsButton_Click(object sender, RoutedEventArgs e)
        {
            //<Snippet2>
            inkCanvas1.Select(inkCanvas1.Strokes, new UIElement[] { textbox1, button1 });
            //</Snippet2>
        }

        void copyButton_Click(object sender, RoutedEventArgs e)
        {
            //<Snippet3>
            inkCanvas1.Select(new UIElement[] { textbox1, button1 });
            inkCanvas1.CopySelection();
            //</Snippet3>
        }

        void cutSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            //<Snippet4>
            inkCanvas1.Select(new UIElement[] { textbox1, button1 });
            inkCanvas1.CutSelection();
            //</Snippet4>
        }
        
        //<Snippet1>
        void copyXamlButton_Click(object sender, RoutedEventArgs e)
        {
            string rectString = XamlWriter.Save(rect1);

            DataObject rectangleData = new DataObject(DataFormats.Xaml, rectString);
            Clipboard.SetDataObject(rectangleData);
            
        }

        void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            if (inkCanvas1.CanPaste())
            {
                inkCanvas1.Paste(new Point(100, 100));
            }
    
        }
        //</Snippet1>

        void Window1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.E)
            {
                if (inkCanvas1.EditingMode == InkCanvasEditingMode.Ink)
                {
                    inkCanvas1.EditingMode = InkCanvasEditingMode.Select;
                    //modeLabel.Text = "select";
                }
                else
                {
                    inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
                    //modeLabel.Text = "Ink";     
                }
            }

            if (e.Key == Key.D)
            {
                if (inkCanvas1.EditingModeInverted == InkCanvasEditingMode.EraseByStroke)
                {
                    inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByPoint;
                }
                else
                {
                    inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByStroke;
                }
            }

            if (e.Key == Key.H)
            {
                inkCanvas1.DefaultDrawingAttributes.IsHighlighter = !inkCanvas1.DefaultDrawingAttributes.IsHighlighter;
            }
        }

        void AttachedPropertiesSnippets()
        {
            //<Snippet27>
            InkCanvas.SetTop(button1, 100);
            //</Snippet27>

            //<Snippet28>
            InkCanvas.SetBottom(button1, 100);
            //</Snippet28>

            //<Snippet29>
            InkCanvas.SetLeft(button1, 100);
            //</Snippet29>

            //<Snippet30>
            InkCanvas.SetRight(button1, 100);
            //</Snippet30>

            //<Snippet31>
            double buttonLeft = InkCanvas.GetLeft(button1);
            //</Snippet31>

            //<Snippet32>
            double buttonRight = InkCanvas.GetRight(button1);
            //</Snippet32>

            //<Snippet33>
            double buttonTop = InkCanvas.GetTop(button1);
            //</Snippet33>

            //<Snippet34>
            double buttonBottom = InkCanvas.GetBottom(button1);
            //</Snippet34>
        }
 
        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, RoutedEventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

    }
}