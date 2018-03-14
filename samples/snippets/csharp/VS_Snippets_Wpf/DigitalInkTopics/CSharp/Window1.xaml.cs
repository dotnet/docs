using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Ink;
using Microsoft.Win32;
using System.IO;

namespace DigitalInkTopics
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        InkCanvas theInkCanvas;
        CheckBox cbSelectionMode;

        public Window1()
        {
            InitializeComponent();
        }

        void CodeExamples()
        {
            //<Snippet8>
            // Set the selection mode based on a checkbox
            if ((bool)cbSelectionMode.IsChecked)
            {
                theInkCanvas.EditingMode = InkCanvasEditingMode.Select;
            }
            else
            {
                theInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }
            //</Snippet8>

            //<Snippet9>
            // Get the selected strokes from the InkCanvas
            StrokeCollection selection = theInkCanvas.GetSelectedStrokes();

            // Check to see if any strokes are actually selected
            if (selection.Count > 0)
            {
                // Change the color of each stroke in the collection to red
                foreach (System.Windows.Ink.Stroke stroke in selection)
                {
                    stroke.DrawingAttributes.Color = System.Windows.Media.Colors.Red;
                }
            }
            //</Snippet9>
        }

        //<Snippet12>
        private void buttonSaveAsClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName,
                                               FileMode.Create);
                theInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }
        //</Snippet12>

        //<Snippet13>
        private void buttonLoadClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (openFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName,
                                               FileMode.Open);
                theInkCanvas.Strokes = new StrokeCollection(fs);
                fs.Close();
            }
        }
        //</Snippet13>
    }
}