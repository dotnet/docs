// XpsReadWriteSign SDK Sample - ReadingAndWritingXps.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Windows;
using System.Windows.Xps.Packaging;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;


namespace SDKSample
{
    /// <summary>
    ///   Illustrates how to access the various parts of an existing
    ///   XPS document, and how to create a new XPS document from scratch.
    /// </summary>
    public partial class XpsReadWriteUtility
    {
        #region Constructor
        public XpsReadWriteUtility(string applicationDir)
        {
            _fontDictionary = new Dictionary<string, string>();
            _applicationDir = applicationDir;
        }
        #endregion Constructor


        #region Public Methods

        //<SnippetCreateAndWriteToXpsDocument>
        // ---------------------------- Create() ------------------------------
        /// <summary>
        ///   Creates an XpsDocument using the Xps.Packaging APIs.</summary>
        /// <param name="xpsDocument">
        ///   The XpsDocument to create.</param>
        /// <remarks>
        ///   The Xps.Packaging APIs are used to create the DocumentSequence,
        ///   FixedDocument, and FixedPage "PackageParts" of an XpsDocument.
        ///   The applicationt is responsible for using the XmlWriter to
        ///   serialize the page markup and for supplying the streams for any
        ///   font or image resources.</remarks>
        public void Create(XpsDocument xpsDocument)
        {
            // Create the document sequence
            IXpsFixedDocumentSequenceWriter docSeqWriter =
                xpsDocument.AddFixedDocumentSequence();

            // Create the document
            IXpsFixedDocumentWriter docWriter = docSeqWriter.AddFixedDocument();

            // Create the Page
            IXpsFixedPageWriter pageWriter = docWriter.AddFixedPage();

            // Get the XmlWriter
            XmlWriter xmlWriter = pageWriter.XmlWriter;

            // Write the mark up according the XPS Specifications
            BeginFixedPage(xmlWriter);
            AddGlyphRun(pageWriter, xmlWriter,
                "This is a photo of the famous Notre Dame in Paris",
                16, 50, 50, @"C:\Windows\fonts\arial.ttf");

            AddImage(pageWriter, xmlWriter,
                "ParisNotreDame.jpg", XpsImageType.JpegImageType,
                100, 100, 600, 1100 );

            // End the page.
            EndFixedPage( xmlWriter );

            // Close the page, document, and document sequence.
            pageWriter.Commit();
            docWriter.Commit();
            docSeqWriter.Commit();
            _fontDictionary.Clear();
        }// end:Create()
        //</SnippetCreateAndWriteToXpsDocument>


        //<SnippetIterateXpsPackageParts>
        // --------------------- IterateXpsPackageParts() ---------------------
        /// <summary>
        ///   Iterates through the parts contained in a given XpsDocument
        ///   package initializing a tree view control with the name of each
        ///   part contained within the package.</summary>
        /// <param name="xpsDocument">
        ///   The XPS document to extract the part names from.</param>
        /// <param name="treeView">
        ///   The TreeView control to insert the part names into.</param>
        /// <param name="fileName">
        ///   The XPS document filename.</param>
        public void IterateXpsPackageParts(
            XpsDocument xpsDocument, TreeView treeView, string fileName)
        {
            // Set up the Tree View
            treeView.Items.Clear();
            treeView.Visibility      = Visibility.Visible;
            TreeViewItem packageNode = new TreeViewItem();
            packageNode.ToolTip      = fileName;
            packageNode.Header       = System.IO.Path.GetFileName(fileName);
            treeView.Items.Add(packageNode);

            // Start with a DoucmentSequence.
            IXpsFixedDocumentSequenceReader docSeq =
                xpsDocument.FixedDocumentSequenceReader;
            TreeViewItem docSeqNode = AddUriToTreeView(packageNode, docSeq.Uri);

            // For every FixedDocument within the DocumentSequence.
            foreach (IXpsFixedDocumentReader docReader in docSeq.FixedDocuments)
            {
                TreeViewItem docNode = AddUriToTreeView(docSeqNode, docReader.Uri);

                // For every FixedPage within the FixedDocument.
                foreach (IXpsFixedPageReader page in docReader.FixedPages)
                {
                    TreeViewItem pageNode = AddUriToTreeView(docNode, docReader.Uri);

                    // For every Image on the page.
                    foreach (XpsImage image in page.Images)
                    {
                        AddUriToTreeView(pageNode, image.Uri);
                    }

                    // For every Font on the page.
                    foreach (XpsFont font in page.Fonts)
                    {
                        AddUriToTreeView(pageNode, font.Uri);
                    }
                }
            }
        }// end:IterateXpsPackageParts()
        //</SnippetIterateXpsPackageParts>

        #endregion Public Methods


        #region Private Methods
        // ------------------------- BeginFixedPage() -------------------------
        /// <summary>
        ///   Writes the initial prolog for a FixedPage element.</summary>
        /// <param name="xmlWriter">
        ///   The XmlWriter to output to.</param>
        private void BeginFixedPage(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("FixedPage",
                "http://schemas.microsoft.com/xps/2005/06");

            xmlWriter.WriteAttributeString("xmlns", "x", null,
                "http://schemas.microsoft.com/xps/2005/06/resourcedictionary-key");

            xmlWriter.WriteAttributeString("xml", "lang", null, "en-us");

            xmlWriter.WriteAttributeString("Width",   "816");
            xmlWriter.WriteAttributeString("Height", "1056");
        }


        // --------------------------- EndFixedPage) --------------------------
        /// <summary>
        ///   Writes the closing element for a FixedPage.</summary>
        /// <param name="xmlWriter">
        ///   The XmlWriter to output to.</param>
        private void EndFixedPage(XmlWriter xmlWriter)
        {
            xmlWriter.WriteEndElement();
        }

        // --------------------------- AddGlyphRun() --------------------------
        /// <summary>
        ///   Outputs a glyph run to a given XmlWriter.</summary>
        /// <param name="pageWriter">
        ///   The XpsFixePageWriter for accessing the page fonts.</param>
        /// <param name="writer">
        ///   The XmlWriter to output the glyph markup to.</param>
        /// <param name="text">
        ///   The text of the glyph run.</param>
        /// <param name="size">
        ///   The font size.</param>
        /// <param name="x">
        ///   The X location of the glyph run.</param>
        /// <param name="y">
        ///   The Y location of the glyph run.</param>
        /// <param name="fontUri">
        ///   The path to font file.</param>
        private void AddGlyphRun(
            IXpsFixedPageWriter pageWriter,
            XmlWriter writer,
            string text,
            int size,
            int x, int y,
            string fontUri)
        {
            string packageFontUri = GetXpsFont(pageWriter, fontUri);
            writer.WriteStartElement("Glyphs");
            writer.WriteAttributeString("OriginX", x.ToString());
            writer.WriteAttributeString("OriginY", y.ToString());
            writer.WriteAttributeString("FontRenderingEmSize", size.ToString());
            writer.WriteAttributeString("FontUri", packageFontUri);
            writer.WriteAttributeString("UnicodeString", text);
            writer.WriteAttributeString("Fill", "#FFFFE4C4");
            writer.WriteEndElement();
        }// end:AddGlyphRun()


        // --------------------------- GetXpsFont() ---------------------------
        /// <summary>
        ///   Returns the relative path to a font part in the package.</summary>
        /// <param name="pageWriter">
        ///   The page to associate the font with.</param>
        /// <param name="fontUri">
        ///   The URI for the source font file.</param>
        /// <returns>
        ///   The relative path to font part in the package.</returns>
        /// <remarks>
        ///   If the font has not been added previously, GetXpsFont creates a
        ///   new font part and copies the font data from the specified
        ///   source font URI.</remarks>
        private string GetXpsFont(IXpsFixedPageWriter pageWriter, string fontUri)
        {
            string packageFontUri;
            if (_fontDictionary.ContainsKey(fontUri))
            {
                packageFontUri = _fontDictionary[fontUri];
            }
            else
            {
                XpsFont xpsFont    = pageWriter.AddFont(false);
                Stream dstStream   = xpsFont.GetStream();
                Stream srcStream   =
                    new FileStream(fontUri, FileMode.Open, FileAccess.Read);
                Byte[] streamBytes = new Byte[srcStream.Length];
                srcStream.Read(streamBytes, 0, (int)srcStream.Length);
                dstStream.Write(streamBytes, 0, (int)srcStream.Length);
                 _fontDictionary[fontUri] = xpsFont.Uri.ToString();
                packageFontUri = xpsFont.Uri.ToString();
                xpsFont.Commit();
            }
            return packageFontUri;
        }// end:GetXpsFont()


        // ---------------------------- AddImage() ----------------------------
        /// <summary>
        ///   Outputs the markup for adding an image.</summary>
        /// <param name="pageWriter">
        ///   The FixedPageWriter associated for getting the image.</param>
        /// <param name="writer">   The XmlWriter to output to.</param>
        /// <param name="imgPath">  The image path.</param>
        /// <param name="imageType">The image type</param>
        /// <param name="x">        The X position of the image.</param>
        /// <param name="y">        The Y position of the image.</param>
        /// <param name="height">   The height of the image.</param>
        /// <param name="width">    The width of the image.</param>
        private void AddImage(
            IXpsFixedPageWriter pageWriter,
            XmlWriter writer,
            string imgPath,
            XpsImageType imageType,
            float x, float y,
            float height,
            float width )
        {
            // Write the surrounding path.
            writer.WriteStartElement("Path");

            // Form the path data string.
            // M="Move To"(start), L="Line To", Z="Close shape"
            string pathData =
                String.Format("M {0},{1} L {2},{3} {4},{5} {6},{7} z",
                x, y,
                x, y+height,
                x+width, y+height,
                x+width, y );

            writer.WriteAttributeString("Data", pathData);
            writer.WriteStartElement("Path.Fill");
            writer.WriteStartElement("ImageBrush");
            writer.WriteAttributeString("ImageSource",
                GetXpsImage(pageWriter, imgPath, imageType));
            string viewPort = String.Format("{0},{1},{2},{3}",
                                            0, 0, width, height );

            writer.WriteAttributeString("Viewport", viewPort);
            writer.WriteAttributeString( "ViewportUnits", "Absolute");
            string viewBox = String.Format("{0},{1},{2},{3}",
                                            x, y, x+width, y+height );

            writer.WriteAttributeString("Viewbox", viewBox);
            writer.WriteAttributeString("ViewboxUnits", "Absolute");
            writer.WriteEndElement(); //ImageBrush
            writer.WriteEndElement(); //Path.Fill
            writer.WriteEndElement(); //Path
        }// end:AddImage()


        // --------------------------- GetXpsImage() --------------------------
        /// <summary>
        ///   Copies a given image to a specified XPS page.</summary>
        /// <param name="pageWriter">
        ///   The FixedPage writer to copy the image to.</param>
        /// <param name="imgPath">
        ///   The source file path for the image.</param>
        /// <param name="imageType">
        ///   The type of the image.</param>
        /// <returns>
        ///   The package URI of the copied image.</returns>
        private string GetXpsImage(
            IXpsFixedPageWriter pageWriter,
            string imgPath,
            XpsImageType imageType)
        {
            XpsImage xpsImage = pageWriter.AddImage(imageType);
            Stream srcStream = new FileStream(imgPath, FileMode.Open);
            Stream dstStream = xpsImage.GetStream();
            Byte[] streamBytes = new Byte[srcStream.Length];
            srcStream.Read(streamBytes, 0, (int)srcStream.Length);
            dstStream.Write(streamBytes, 0, (int)srcStream.Length);
            xpsImage.Commit();
            return xpsImage.Uri.ToString();
        }


        // ------------------------ AddUriToTreeView() ------------------------
        /// <summary>
        ///   Adds a given package URI as a node in a TreeView control.</summary>
        /// <param name="parentNode">
        ///   The parent node of the TreeView control.</param>
        /// <param name="uri">
        ///   The URI of the package element to add.</param>
        /// <returns>
        ///   The node that was added to the TreeView control.</returns>
        private static TreeViewItem AddUriToTreeView(
            TreeViewItem parentNode, Uri uri)
        {
            TreeViewItem node = new TreeViewItem();
            node.Header = System.IO.Path.GetFileName(uri.ToString());
            node.ToolTip = uri.ToString();
            parentNode.Items.Add(node);
            return node;
        }
        #endregion Private Methods

        #region    Private Members
        private Dictionary<string, string> _fontDictionary;
        private static string _applicationDir;
        #endregion Private Members

    }// end:class XpsReadWriteUtility

}// end:namespace SDKSample
