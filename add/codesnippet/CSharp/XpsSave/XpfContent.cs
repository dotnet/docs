// XpsSave SDK Sample - XpfContent.cs
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This file provides the methods for creating the default
// DocumentViewer content used by the XpsSave SDK sample.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Markup;
using SDKSample;


namespace SDKSampleHelper
{
    // -------------------------- class XPFContent ----------------------------
    /// <summary>
    ///   Generating content in memory for the SDK sample
    ///   (Visuals, FixedPages, and FixedDocuments). </summary>
    /// <remarks>
    ///   The PrintHelper class calls XPFCpntent to create
    ///   all of the media for in the documents.</remarks>
    internal class XPFContent
    {
        // ---------------------- XPFContent constructor ----------------------
        /// <summary>
        ///   Initialize a new instance of the XPFContent class.</summary>
        /// <param name="contentPath">
        ///   The path to the "\Content" folder.</param>
        public XPFContent(string contentPath)
        {
            _contentDir = contentPath;
        }


        #region Create Visuals Methods

        // ------------------------- CreateFirstVisual ------------------------
        /// <summary>
        ///   Creates content for the first visual sample.</summary>
        /// <param name="shouldMeasure">
        ///   true to remeasure the layout.</param>
        /// <returns>
        ///   The canvas containing the visual.</returns>
        public Canvas CreateFirstVisual(bool shouldMeasure)
        {
            Canvas canvas1 = new Canvas();
            canvas1.Width = 96 * 8.5;
            canvas1.Height = 96 * 11;

            // Top-Left
            TextBlock label = new TextBlock();
            label.Foreground = Brushes.DarkBlue;
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 36.0;
            label.Text = "TopLeft";
            Canvas.SetTop(label, 0);
            Canvas.SetLeft(label, 0);
            canvas1.Children.Add(label);

            // Bottom-Right
            label = new TextBlock();
            label.Foreground = Brushes.Bisque;
            label.Text = "BottomRight";
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 56.0;
            Canvas.SetTop(label, 750);
            Canvas.SetLeft(label, 520);
            canvas1.Children.Add(label);

            // Top-Right
            label = new TextBlock();
            label.Foreground = Brushes.BurlyWood;
            label.Text = "TopRight";
            label.FontFamily = new System.Windows.Media.FontFamily("CASTELLAR");
            label.FontSize = 32.0;
            Canvas.SetTop(label, 0);
            Canvas.SetLeft(label, 520);
            canvas1.Children.Add(label);

            // Bottom-Left
            label = new TextBlock();
            label.Foreground = Brushes.Cyan;
            label.Text = "BottomLeft";
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 18.0;
            Canvas.SetTop(label, 750);
            Canvas.SetLeft(label, 0);
            canvas1.Children.Add(label);

            // Add a rectangle to the page
            Rectangle firstRectangle = new Rectangle();
            firstRectangle.Fill = new SolidColorBrush(Colors.Red);
            Thickness thick = new Thickness();
            thick.Left = 150;
            thick.Top = 150;
            firstRectangle.Margin = thick;
            firstRectangle.Width = 300;
            firstRectangle.Height = 300;
            canvas1.Children.Add(firstRectangle);
            //_visual = firstRectangle;

            //Add a button to the page
            Button firstButton = new Button();
            firstButton.Background = Brushes.LightYellow;
            firstButton.BorderBrush = new SolidColorBrush(Colors.Black);
            firstButton.BorderThickness = new Thickness(4);
            firstButton.Content = "I am button 1...";
            firstButton.FontSize = 16.0;
            thick.Left = 80;
            thick.Top = 250;
            firstButton.Margin = thick;
            canvas1.Children.Add(firstButton);

            // Add an Ellipse
            Ellipse firstEllipse = new Ellipse();
            SolidColorBrush firstSolidColorBrush = new SolidColorBrush(Colors.DarkCyan);
            firstSolidColorBrush.Opacity = 0.7;
            firstEllipse.Fill = firstSolidColorBrush;
            SetEllipse(firstEllipse, 500, 350, 120, 250);
            canvas1.Children.Add(firstEllipse);

            // Adding a Polygon
            Polygon polygon = new Polygon();
            polygon.Fill = Brushes.Bisque;
            polygon.Opacity = 0.2;
            PointCollection points = new PointCollection();
            points.Add(new Point(50, 0));
            points.Add(new Point(10, 30));
            points.Add(new Point(30, 170));
            points.Add(new Point(90, 40));
            points.Add(new Point(230, 180));
            points.Add(new Point(200, 60));
            points.Add(new Point(240, 10));
            points.Add(new Point(70, 130));
            polygon.Points = points;
            polygon.Stroke = Brushes.Navy;
            Canvas.SetTop(polygon, 300);
            Canvas.SetLeft(polygon, 160);
            canvas1.Children.Add(polygon);

            if (shouldMeasure)
            {
                Size sz = new Size(8.5 * 96, 11 * 96);
                canvas1.Measure(sz);
                canvas1.Arrange(new Rect(new Point(), sz));
                canvas1.UpdateLayout();
            }

            return canvas1;
        }// end:CreateFirstVisual()


        // ------------------------- CreateSecondVisual -----------------------
        /// <summary>
        ///   Creates content for the second visual sample.</summary>
        /// <param name="shouldMeasure">
        ///   true to remeasure the layout.</param>
        /// <returns>
        ///   The canvas containing the visual.</returns>
        public Canvas CreateSecondVisual(bool shouldMeasure)
        {
            Canvas canvas = new Canvas();

            Ellipse ellipse = new Ellipse();
            ellipse.Fill = Brushes.LightSeaGreen;
            SetEllipse(ellipse, 130, 200, 100, 70);
            ellipse.Stroke = Brushes.Black;
            canvas.Children.Add(ellipse);

            Rectangle rectangle = new Rectangle();
            rectangle.Fill = Brushes.PowderBlue;
            rectangle.Opacity = 0.8;
            rectangle.RadiusX = 5;
            rectangle.RadiusY = 5;
            rectangle.Stroke = Brushes.Orange;
            rectangle.Height = 200;
            rectangle.Width = 350;
            Canvas.SetTop(rectangle, 50);
            Canvas.SetLeft(rectangle, 100);
            canvas.Children.Add(rectangle);

            Polygon polygon = new Polygon();
            polygon.Fill = Brushes.MediumVioletRed;
            polygon.Opacity = 0.7;
            PointCollection points = new PointCollection();
            points.Add(new Point(50, 0));
            points.Add(new Point(10, 30));
            points.Add(new Point(30, 170));
            points.Add(new Point(90, 40));
            points.Add(new Point(230, 180));
            points.Add(new Point(200, 60));
            points.Add(new Point(240, 10));
            points.Add(new Point(70, 130));
            polygon.Points = points;
            polygon.Stroke = Brushes.Navy;
            Canvas.SetTop(polygon, 150);
            Canvas.SetLeft(polygon, 250);
            canvas.Children.Add(polygon);

            TextBlock scribble = new TextBlock();
            scribble.Foreground = Brushes.Green;
            scribble.FontFamily =
                new System.Windows.Media.FontFamily("Courier New");
            scribble.FontSize = 18;
            scribble.Opacity = 0.5;
            Canvas.SetLeft(scribble, 96 * 3.7);
            Canvas.SetTop(scribble, 96 * 10.3);
            canvas.Children.Add(scribble);

            TextBlock para = new TextBlock();
            para.Text = "This is a piece of text content.";
            para.FontSize = 16;
            para.FontFamily =
                new System.Windows.Media.FontFamily("Comic Sans MS");
            para.Foreground = Brushes.Orange;
            Canvas.SetTop(para, 96 * 6);
            Canvas.SetLeft(para, 15);
            canvas.Children.Add(para);

            para = new TextBlock();
            para.Text = "This is the second piece of text content.";
            para.FontSize = 16;
            para.FontFamily =
                new System.Windows.Media.FontFamily("Comic Sans MS");
            para.Foreground = Brushes.Blue;
            Canvas.SetTop(para, 96 * 7.2);
            Canvas.SetLeft(para, 15);
            canvas.Children.Add(para);

            para = new TextBlock();
            para.Text = "This is the last text section.";
            para.FontSize = 16;
            para.FontFamily =
                new System.Windows.Media.FontFamily("Comic Sans MS");
            para.Foreground = Brushes.Red;
            Canvas.SetTop(para, 96 * 8.4);
            Canvas.SetLeft(para, 15);
            canvas.Children.Add(para);

            if (shouldMeasure)
            {
                Size sz = new Size(8.5 * 96, 11 * 96);
                canvas.Measure(sz);
                canvas.Arrange(new Rect(new Point(), sz));
                canvas.UpdateLayout();
            }

            return canvas;
        }// end:CreateSecondVisual()


        // ------------------------- CreateThirdVisual ------------------------
        /// <summary>
        ///   Creates content for the third visual sample.</summary>
        /// <param name="shouldMeasure">
        ///   true to remeasure the layout.</param>
        /// <returns>
        ///   The canvas containing the visual.</returns>
        public Canvas CreateThirdVisual(bool shouldMeasure)
        {
            Canvas               canvas      = new Canvas();
            RadialGradientBrush  brush       = new RadialGradientBrush();

            brush.GradientStops.Add(new GradientStop(Colors.Black, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.5));
            brush.GradientStops.Add(new GradientStop(Colors.Red, 1));

            brush.SpreadMethod = GradientSpreadMethod.Repeat;
            brush.Center = new Point(0.5, 0.5);
            brush.RadiusX = 0.2;
            brush.RadiusY = 0.2;
            brush.GradientOrigin = new Point(0.5, 0.5);

            Rectangle r = new Rectangle();
            r.Fill = brush;

            Thickness thick = new Thickness();
            thick.Left = 100;
            thick.Top  = 100;

            r.Margin = thick;
            r.Width = 400;
            r.Height = 400;

            canvas.Children.Add(r);

            LinearGradientBrush linear = new LinearGradientBrush();

            linear.GradientStops.Add(new GradientStop(Colors.Blue, 0));
            linear.GradientStops.Add(new GradientStop(Colors.Yellow, 1));

            linear.SpreadMethod = GradientSpreadMethod.Reflect;
            linear.StartPoint = new Point(0, 0);
            linear.EndPoint = new Point(0.06125, 0);
            linear.Opacity = 0.5;

            r = new Rectangle();
            r.Fill = linear;

            thick = new Thickness();
            thick.Left = 200;
            thick.Top = 200;

            r.Margin = thick;
            r.Width = 400;
            r.Height = 400;

            canvas.Children.Add(r);

            if (shouldMeasure)
            {
                Size sz = new Size(8.5 * 96, 11 * 96);
                canvas.Measure(sz);
                canvas.Arrange(new Rect(new Point(), sz));
                canvas.UpdateLayout();
            }

            return canvas;
        }// end:CreateThirdVisual()

        #endregion // Create Visuals Methods


        //<SnippetXpsSaveCreateFixedDocPages>
        // ------------------- CreateFixedDocumentWithPages -------------------
        /// <summary>
        ///   Creates a FixedDocument with fixed pages.</summary>
        /// <returns>
        ///   A FixedDocument containing fixed pages.</returns>
        public FixedDocument CreateFixedDocumentWithPages()
        {
            // Create a FixedDocument
            FixedDocument fixedDocument = CreateFixedDocument();

            // Add Page 1 to a fixed document
            PageContent page1Content = CreateFirstPageContent();
            fixedDocument.Pages.Add(page1Content);

            // Adding Page 2 to a fixed document
            PageContent page2Content = CreateSecondPageContent();
            fixedDocument.Pages.Add(page2Content);

            // Adding Page 3 to a fixed document
            PageContent page3Content = CreateThirdPageContent();
            fixedDocument.Pages.Add(page3Content);

            // Adding Page 4 to a fixed document;
            PageContent page4Content = CreateFourthPageContent();
            fixedDocument.Pages.Add(page4Content);

            // Adding Page 5 to a fixed document;
            PageContent page5Content = CreateFifthPageContent();
            fixedDocument.Pages.Add(page5Content);

            return fixedDocument;
        }// end:CreateFixedDocumentWithPages()
        //</SnippetXpsSaveCreateFixedDocPages>


        // ------------------------ CreateFlowDocument ------------------------
        /// <summary>
        ///   Creates a FlowDocument with content.</summary>
        /// <returns>
        ///   A FlowDocument with content.</returns>
        public IDocumentPaginatorSource CreateFlowDocument()
        {
            FlowDocument doc = new FlowDocument();

            for (int i = 0; i < 2; i++)
            {
                Paragraph paragraph = new Paragraph(new Run(_paragraphText));
                doc.Blocks.Add(paragraph);
            }

            return doc;
        }// end:CreateFlowDocument()


        //<SnippetXpsSaveLoadFixedDocSeq>
        //--------------- LoadFixedDocumentSequenceFromDocument ---------------
        /// <summary>
        ///   Returns the FixedDocumentSequence from the sample
        ///   ViewFixedDocumentSequence.xps document.</summary>
        /// <returns>
        ///   FixedDocumentSequence from ViewFixedDocumentSequence.xps.</returns>
        public FixedDocumentSequence LoadFixedDocumentSequenceFromDocument()
        {
            string fullPath = _contentDir + @"\ViewFixedDocumentSequence.xps";

            XpsDocument xpsPackage = new XpsDocument(
                fullPath, FileAccess.Read, CompressionOption.NotCompressed);

            FixedDocumentSequence fixedDocumentSequence =
                xpsPackage.GetFixedDocumentSequence();

            return fixedDocumentSequence;
        }
        //</SnippetXpsSaveLoadFixedDocSeq>


        //<SnippetCreateFixedDocument>
        // ------------------------ CreateFixedDocument -----------------------
        /// <summary>
        ///   Creates an empty FixedDocument.</summary>
        /// <returns>
        ///   An empty FixedDocument without any content.</returns>
        private FixedDocument CreateFixedDocument()
        {
            FixedDocument fixedDocument = new FixedDocument();
            fixedDocument.DocumentPaginator.PageSize = new Size(96 * 8.5, 96 * 11);
            return fixedDocument;
        }
        //</SnippetCreateFixedDocument>


        #region Create FixedPage methods
        // ---------------------- CreateFirstPageContent ----------------------
        /// <summary>
        ///   Creates the content for the first fixed page.</summary>
        /// <returns>
        ///   The page content for the first fixed page.</returns>
        private PageContent CreateFirstPageContent()
        {
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = CreateFirstFixedPage();
            ((IAddChild)pageContent).AddChild(fixedPage);
            return pageContent;
        }


        //<SnippetXpsSaveCreateFixedPage1>
        // ----------------------- CreateFirstFixedPage -----------------------
        /// <summary>
        ///   Creates the FixedPage for the first page.</summary>
        /// <returns>
        ///   The FixedPage for the first page.</returns>
        private FixedPage CreateFirstFixedPage()
        {
            FixedPage fixedPage = new FixedPage();
            fixedPage.Background = Brushes.LightYellow;
            UIElement visual = CreateFirstVisual(false);

            FixedPage.SetLeft(visual, 0);
            FixedPage.SetTop(visual, 0);

            double pageWidth = 96 * 8.5;
            double pageHeight = 96 * 11;

            fixedPage.Width = pageWidth;
            fixedPage.Height = pageHeight;

            fixedPage.Children.Add((UIElement)visual);

            Size sz = new Size(8.5 * 96, 11 * 96);
            fixedPage.Measure(sz);
            fixedPage.Arrange(new Rect(new Point(), sz));
            fixedPage.UpdateLayout();

            return fixedPage;
        }// end:CreateFirstFixedPage()
        //</SnippetXpsSaveCreateFixedPage1>


        // --------------------- CreateSecondPageContent ----------------------
        /// <summary>
        ///   Creates the content for the second fixed page.</summary>
        /// <returns>
        ///   The page content for the second fixed page.</returns>
        private PageContent CreateSecondPageContent()
        {
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();
            fixedPage.Background = Brushes.LightGray;
            UIElement visual = CreateSecondVisual(false);

            FixedPage.SetLeft(visual, 0);
            FixedPage.SetTop(visual, 0);

            double pageWidth = 96 * 8.5;
            double pageHeight = 96 * 11;

            fixedPage.Width = pageWidth;
            fixedPage.Height = pageHeight;

            fixedPage.Children.Add((UIElement)visual);

            Size sz = new Size(8.5 * 96, 11 * 96);
            fixedPage.Measure(sz);
            fixedPage.Arrange(new Rect(new Point(), sz));
            fixedPage.UpdateLayout();

            ((IAddChild)pageContent).AddChild(fixedPage);
            return pageContent;
        }// end:CreateSecondPageContent()


        // --------------------- CreateThirdPageContent -----------------------
        /// <summary>
        ///   Creates the content for the third fixed page.</summary>
        /// <returns>
        ///   The page content for the third fixed page.</returns>
        public PageContent CreateThirdPageContent()
        {
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();
            fixedPage.Background = Brushes.White;
            Canvas canvas1 = new Canvas();
            canvas1.Width = 8.5 * 96;
            canvas1.Height = 11 * 96;

            // Top-Left
            TextBlock label = new TextBlock();
            label.Foreground = Brushes.Black;
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 14.0;
            label.Text = String1;
            Canvas.SetTop(label, 0);
            Canvas.SetLeft(label, 0);
            canvas1.Children.Add(label);

            label = new TextBlock();
            label.Foreground = Brushes.Black;
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 14.0;
            label.Text = String2;
            Canvas.SetTop(label, 20);
            Canvas.SetLeft(label, 0);
            canvas1.Children.Add(label);

            label = new TextBlock();
            label.Foreground = Brushes.Black;
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 14.0;
            label.Text = String3;
            Canvas.SetTop(label, 40);
            Canvas.SetLeft(label, 0);
            canvas1.Children.Add(label);

            label = new TextBlock();
            label.Foreground = Brushes.Black;
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 14.0;
            label.Text = String4;
            Canvas.SetTop(label, 60);
            Canvas.SetLeft(label, 0);
            canvas1.Children.Add(label);

            label = new TextBlock();
            label.Foreground = Brushes.Black;
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontSize = 14.0;
            label.Text = String5;
            Canvas.SetTop(label, 80);
            Canvas.SetLeft(label, 0);
            canvas1.Children.Add(label);

            fixedPage.Children.Add(canvas1);

            double pageWidth = 96 * 8.5;
            double pageHeight = 96 * 11;

            fixedPage.Width = pageWidth;
            fixedPage.Height = pageHeight;

            Size sz = new Size(8.5 * 96, 11 * 96);
            fixedPage.Measure(sz);
            fixedPage.Arrange(new Rect(new Point(), sz));
            fixedPage.UpdateLayout();

            ((IAddChild)pageContent).AddChild(fixedPage);
            return pageContent;
        }// end:CreateThirdPageContent()


        // --------------------- CreateFourthPageContent ----------------------
        /// <summary>
        ///   Creates the content for the fourth fixed page.</summary>
        /// <returns>
        ///   The page content for the fourth fixed page.</returns>
        private PageContent CreateFourthPageContent()
        {
            PageContent    pageContent = new PageContent();
            FixedPage      fixedPage   = new FixedPage();
            fixedPage.Background       = Brushes.BlanchedAlmond;

            BitmapImage bitmapImage = new BitmapImage(
                new Uri(_contentDir + @"\tiger.jpg",
                        UriKind.RelativeOrAbsolute)  );

            Image image = new Image();
            image.Source = bitmapImage;
            Canvas.SetTop(image, 0);
            Canvas.SetLeft(image, 0);
            fixedPage.Children.Add(image);

            Image image2 = new Image();
            image2.Source = bitmapImage;
            image2.Opacity = 0.3;
            FixedPage.SetTop(image2,150);
            FixedPage.SetLeft(image2,150);
            fixedPage.Children.Add(image2);

            ((IAddChild)pageContent).AddChild(fixedPage);

            double pageWidth  = 96 * 8.5;
            double pageHeight = 96 * 11;

            fixedPage.Width  = pageWidth;
            fixedPage.Height = pageHeight;

            Size sz = new Size(8.5 * 96, 11 * 96);

            fixedPage.Measure(sz);
            fixedPage.Arrange(new Rect(new Point(), sz));
            fixedPage.UpdateLayout();

            return pageContent;
        }// end:CreateFourthPageContent()


        //<SnippetXpsSaveCreateFixedPage5>
        // --------------------- CreateFifthPageContent -----------------------
        /// <summary>
        ///   Creates the content for the fifth fixed page.</summary>
        /// <returns>
        ///   The page content for the fifth fixed page.</returns>
        private PageContent CreateFifthPageContent()
        {
            PageContent pageContent = new PageContent();
            FixedPage   fixedPage   = new FixedPage();
            UIElement   visual      = CreateThirdVisual(false);

            FixedPage.SetLeft(visual, 0);
            FixedPage.SetTop(visual, 0);

            double pageWidth = 96 * 8.5;
            double pageHeight = 96 * 11;

            fixedPage.Width = pageWidth;
            fixedPage.Height = pageHeight;

            fixedPage.Children.Add((UIElement)visual);

            Size sz = new Size(8.5 * 96, 11 * 96);
            fixedPage.Measure(sz);
            fixedPage.Arrange(new Rect(new Point(), sz));
            fixedPage.UpdateLayout();

            ((IAddChild)pageContent).AddChild(fixedPage);
            return pageContent;
        }// end:CreateFifthPageContent()
        //</SnippetXpsSaveCreateFixedPage5>
        #endregion // Create FixedPage methods


        // ---------------------------- SetEllipse ----------------------------
        //
        // Set Ellipse dimensions.
        //
        /// <summary>
        ///   Sets the default dimensions of a sample ellipse.</summary>
        /// <param name="shape">The ellipse shape attributes.</param>
        /// <param name="cx">The width of the ellipse.</param>
        /// <param name="cy">The height of the ellipse</param>
        /// <param name="rx">The width of the pen.</param>
        /// <param name="ry">The height of the pen.</param>
        private void SetEllipse(
                Ellipse shape, double cx, double cy, double rx, double ry)
        {
            Thickness thick = new Thickness();
            thick.Left = cx - rx;
            thick.Top  = cy - ry;

            shape.Margin = thick;
            shape.Width  = rx * 2;
            shape.Height = ry * 2;
        }// end:SetEllipse()


        #region private members

        private String _contentDir;     // Path to the \Content folder

        // Text strings for samples.
        static String String1 =
            "No scene from prehistory is quite so vivid as that of the mortal struggles";
        static String String2 =
            "of great beasts in the tar pits. In the mind's eye one sees dinosaurs,";
        static String String3 =
            " mammoths, and sabertoothed tigers struggling against the grip of the tar.";
        static String String4 =
            "The fiercer the struggle, the more entangling the tar, and no";
        static String String5 =
            "beast is so strong or so skillful but that he ultimately sinks.";

        static string _paragraphText =
           "The story which follows was first written out in Paris " +
           "during the Peace Conference, from notes jotted daily on " +
           "the march, strengthened by some reports sent to my chiefs in " +
           "Cairo. Afterwards, in the autumn of 1919, this first draft " +
           "and some of the notes were lost. It seemed to me historically " +
           "needful to reproduce the tale, as perhaps no one but myself " +
           "in Feisal's army had thought of writing down at the time what " +
           "we felt, what we hoped, what we tried. So it was built again " +
           "with heavy repugnance in London in the winter of 1919-20 from " +
           "memory and my surviving notes. The record of events was not " +
           "dulled in me and perhaps few actual mistakes crept in - " +
           "except in details of dates or numbers - but the outlines and " +
           "significance of things had lost edge in the haze of new interestz.";

        #endregion private members

    };//end:class XPFContent

}// end:namespace SDKSampleHelper
