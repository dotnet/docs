using System;
using System.IO;
using wpf = System.Windows;
using System.Windows.Input;

// Using Statements for winforms
//<SnippetUsingWinforms>
using Microsoft.Ink;
using System.Drawing;
//</SnippetUsingWinforms>

// Using Statements for WPF.
//<SnippetUsingWPF>
using System.Windows.Ink;
//</SnippetUsingWPF>


namespace WinformStylusPointsTest_Console
{
    class WinformInk
    {
        Ink theInk;
        Point[] points;
        Point[] points2;

        Microsoft.Ink.Stroke stroke1;
        Microsoft.Ink.Stroke stroke2;

        public WinformInk()
        {
            theInk = new Ink();

            
        }

        private void CreateStrokes()
        {
            if (theInk.Strokes.Count > 0)
            {
                return;
            }
            points = new Point[] { new Point(0, 0), new Point(100, 100) };
            points2 = new Point[] { new Point(0, 0), new Point(150, 150) };

            stroke1 = theInk.CreateStroke(points);
            stroke2 = theInk.CreateStroke(points);
        }

        public void ReportStrokes()
        {
            foreach (Microsoft.Ink.Stroke stroke in theInk.Strokes)
            {
                Console.Write("StrokePoints: ");
                foreach (Point p in stroke.GetPoints())
                {
                    Console.Write(p.ToString() + ", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        // Test method that proves the Stylus packet data is copied into a stroke.
        public void ChangeStylusPoints()
        {
            CreateStrokes();
            ReportStrokes();
            stroke2.SetPoints(points2);
            ReportStrokes();

            Console.ReadLine();
        }

        public MemoryStream SaveInk()
        {
            CreateStrokes();

            return SaveInkInWinforms(theInk);
        }

        //<SnippetSaveWinforms>
        /// <summary>
        /// Saves the digital ink from a Windows Forms application.
        /// </summary>
        /// <param name="inkToSave">An Ink object that contains the 
        /// digital ink.</param>
        /// <returns>A MemoryStream containing the digital ink.</returns>
        MemoryStream SaveInkInWinforms(Ink inkToSave)
        {
            byte[] savedInk = inkToSave.Save();

            return (new MemoryStream(savedInk));

        }
        //</SnippetSaveWinforms>

        //<SnippetLoadWinforms>
        /// <summary>
        /// Loads digital ink into a Windows Forms application.
        /// </summary>
        /// <param name="savedInk">A MemoryStream containing the digital ink.</param>
        public void LoadInkInWinforms(MemoryStream savedInk)
        {
            theInk = new Ink();
            theInk.Load(savedInk.ToArray());
        }
        //</SnippetLoadWinforms>
    }

    class WPFInk
    {
        StrokeCollection strokes;

        public WPFInk()
        {
        }

        public MemoryStream SaveInk()
        {
            CreateStrokes();

            return SaveInkInWPF(strokes);
        }

        public void ChangeStylusPoints()
        {
            if (strokes != null)
            {
                return;
            }

            wpf.Point[] points = new wpf.Point[] { new wpf.Point(0, 100), new wpf.Point(200, 200) };

            StylusPointCollection stylusPoints = new StylusPointCollection(points);
            wpf.Ink.Stroke stroke1 = new System.Windows.Ink.Stroke(stylusPoints);
            wpf.Ink.Stroke stroke2 = new System.Windows.Ink.Stroke(stylusPoints);

            strokes = new StrokeCollection();
            strokes.Add(stroke1);
            strokes.Add(stroke2);

            ReportStrokes();

            StylusPoint point = stroke2.StylusPoints[1];
            point.Y = 300;
            stroke2.StylusPoints[1] = point;

            ReportStrokes();
        }

        //<SnippetSaveWPF>
        /// <summary>
        /// Saves the digital ink from a WPF application.
        /// </summary>
        /// <param name="inkToSave">A StrokeCollection that contains the 
        /// digital ink.</param>
        /// <returns>A MemoryStream containing the digital ink.</returns>
        MemoryStream SaveInkInWPF(StrokeCollection strokesToSave)
        {
            MemoryStream savedInk = new MemoryStream();

            strokesToSave.Save(savedInk);

            return savedInk;
        }
        //</SnippetSaveWPF>

        //<SnippetLoadWPF>
        /// <summary>
        /// Loads digital ink into a StrokeCollection, which can be 
        /// used by a WPF application.
        /// </summary>
        /// <param name="savedInk">A MemoryStream containing the digital ink.</param>
        public void LoadInkInWPF(MemoryStream inkStream)
        {
            strokes = new StrokeCollection(inkStream);
        }
        //</SnippetLoadWPF>

        void CreateStrokes()
        {
            wpf.Point[] points = new wpf.Point[] { new wpf.Point(0, 0), new wpf.Point(100, 100) };
            wpf.Point[] points2 = new wpf.Point[] { new wpf.Point(0, 0), new wpf.Point(150, 150) };

            strokes = new StrokeCollection();
            System.Windows.Ink.Stroke stroke1 = new System.Windows.Ink.Stroke(new StylusPointCollection(points));
            System.Windows.Ink.Stroke stroke2 = new System.Windows.Ink.Stroke(new StylusPointCollection(points2));

            strokes.Add(stroke1);
            strokes.Add(stroke2);
        }

        public void ReportStrokes()
        {
            if (strokes == null)
            {
                Console.WriteLine("Strokes is null");
                return;
            }

            foreach (System.Windows.Ink.Stroke stroke in strokes)
            {
                Console.Write("StrokePoints({0}): ", stroke.StylusPoints.Count);
                foreach (StylusPoint sp in stroke.StylusPoints)
                {
                    Console.Write(sp.ToPoint().ToString() + ", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            WinformInk winformTest = new WinformInk();
            WPFInk wpfTest = new WPFInk();
            MemoryStream savedStrokes;

            //winformTest.ChangeStylusPoints();
            
            // First save the ink in winforms and load it into WPF.
            Console.WriteLine("Winforms Saved Ink:");
            savedStrokes = winformTest.SaveInk();
            winformTest.ReportStrokes();
            
            Console.WriteLine("\nWPF Loaded Ink:");
            wpfTest.LoadInkInWPF(savedStrokes);
            wpfTest.ReportStrokes();
            savedStrokes = null;

            // Then save ink in WPF and load it into winforms.
            Console.WriteLine("\nWPF savedInk");
            savedStrokes = wpfTest.SaveInk();
            wpfTest.ReportStrokes();

            Console.WriteLine("\nWinform Loaded Iml");
            winformTest.LoadInkInWinforms(savedStrokes);
            winformTest.ReportStrokes();

            Console.WriteLine("\nWPF StylusPointTest");
            WPFInk stylusPointTest = new WPFInk();
            stylusPointTest.ChangeStylusPoints();

            Console.ReadLine();

        }
    }
}
