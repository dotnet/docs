' XpsReadWriteSign SDK Sample - ReadingAndWritingXps.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System.Windows
Imports System.Windows.Xps.Packaging
Imports System.Xml
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Controls


Namespace SDKSample
	''' <summary>
	'''   Illustrates how to access the various parts of an existing
	'''   XPS document, and how to create a new XPS document from scratch.
	''' </summary>
	Partial Public Class XpsReadWriteUtility
		#Region "Constructor"
		Public Sub New(ByVal applicationDir As String)
			_fontDictionary = New Dictionary(Of String, String)()
			_applicationDir = applicationDir
		End Sub
		#End Region ' Constructor


		#Region "Public Methods"

		'<SnippetCreateAndWriteToXpsDocument>
		' ---------------------------- Create() ------------------------------
		''' <summary>
		'''   Creates an XpsDocument using the Xps.Packaging APIs.</summary>
		''' <param name="xpsDocument">
		'''   The XpsDocument to create.</param>
		''' <remarks>
		'''   The Xps.Packaging APIs are used to create the DocumentSequence,
		'''   FixedDocument, and FixedPage "PackageParts" of an XpsDocument.
		'''   The applicationt is responsible for using the XmlWriter to
		'''   serialize the page markup and for supplying the streams for any
		'''   font or image resources.</remarks>
		Public Sub Create(xpsDocument As XpsDocument)
			' Create the document sequence
			Dim docSeqWriter As IXpsFixedDocumentSequenceWriter = xpsDocument.AddFixedDocumentSequence()

			' Create the document
			Dim docWriter As IXpsFixedDocumentWriter = docSeqWriter.AddFixedDocument()

			' Create the Page
			Dim pageWriter As IXpsFixedPageWriter = docWriter.AddFixedPage()

			' Get the XmlWriter
			Dim xmlWriter As XmlWriter = pageWriter.XmlWriter

			' Write the mark up according the XPS Specifications
			BeginFixedPage(xmlWriter)
			AddGlyphRun(pageWriter, xmlWriter, "This is a photo of the famous Notre Dame in Paris", 16, 50, 50, "C:\Windows\fonts\arial.ttf")

			AddImage(pageWriter, xmlWriter, "ParisNotreDame.jpg", XpsImageType.JpegImageType, 100, 100, 600, 1100)

			' End the page.
			EndFixedPage(xmlWriter)

			' Close the page, document, and document sequence.
			pageWriter.Commit()
			docWriter.Commit()
			docSeqWriter.Commit()
			_fontDictionary.Clear()
		End Sub
		'</SnippetCreateAndWriteToXpsDocument>


		'<SnippetIterateXpsPackageParts>
		' --------------------- IterateXpsPackageParts() ---------------------
		''' <summary>
		'''   Iterates through the parts contained in a given XpsDocument
		'''   package initializing a tree view control with the name of each
		'''   part contained within the package.</summary>
		''' <param name="xpsDocument">
		'''   The XPS document to extract the part names from.</param>
		''' <param name="treeView">
		'''   The TreeView control to insert the part names into.</param>
		''' <param name="fileName">
		'''   The XPS document filename.</param>
		Public Sub IterateXpsPackageParts(xpsDocument As XpsDocument, treeView As TreeView, fileName As String)
			' Set up the Tree View
			treeView.Items.Clear()
			treeView.Visibility = Visibility.Visible
            Dim packageNode As New TreeViewItem With {
                .ToolTip = fileName,
                .Header = System.IO.Path.GetFileName(fileName)
            }
            treeView.Items.Add(packageNode)

            ' Start with a DoucmentSequence.
            Dim docSeq As IXpsFixedDocumentSequenceReader = xpsDocument.FixedDocumentSequenceReader
            Dim docSeqNode As TreeViewItem = AddUriToTreeView(packageNode, docSeq.Uri)

            ' For every FixedDocument within the DocumentSequence.
            For Each docReader As IXpsFixedDocumentReader In docSeq.FixedDocuments
                Dim docNode As TreeViewItem = AddUriToTreeView(docSeqNode, docReader.Uri)

                ' For every FixedPage within the FixedDocument.
                For Each page As IXpsFixedPageReader In docReader.FixedPages
                    Dim pageNode As TreeViewItem = AddUriToTreeView(docNode, docReader.Uri)

                    ' For every Image on the page.
                    For Each image As XpsImage In page.Images
                        AddUriToTreeView(pageNode, image.Uri)
                    Next image

                    ' For every Font on the page.
                    For Each font As XpsFont In page.Fonts
                        AddUriToTreeView(pageNode, font.Uri)
                    Next font
                Next page
            Next docReader
        End Sub
        '</SnippetIterateXpsPackageParts>

#End Region ' Public Methods


#Region "Private Methods"
        ' ------------------------- BeginFixedPage() -------------------------
        ''' <summary>
        '''   Writes the initial prolog for a FixedPage element.</summary>
        ''' <param name="xmlWriter">
        '''   The XmlWriter to output to.</param>
        Private Sub BeginFixedPage(xmlWriter As XmlWriter)
            xmlWriter.WriteStartElement("FixedPage", "http://schemas.microsoft.com/xps/2005/06")

            xmlWriter.WriteAttributeString("xmlns", "x", Nothing, "http://schemas.microsoft.com/xps/2005/06/resourcedictionary-key")

            xmlWriter.WriteAttributeString("xml", "lang", Nothing, "en-us")

            xmlWriter.WriteAttributeString("Width", "816")
            xmlWriter.WriteAttributeString("Height", "1056")
        End Sub


        ' --------------------------- EndFixedPage) --------------------------
        ''' <summary>
        '''   Writes the closing element for a FixedPage.</summary>
        ''' <param name="xmlWriter">
        '''   The XmlWriter to output to.</param>
        Private Sub EndFixedPage(xmlWriter As XmlWriter)
            xmlWriter.WriteEndElement()
        End Sub

        ' --------------------------- AddGlyphRun() --------------------------
        ''' <summary>
        '''   Outputs a glyph run to a given XmlWriter.</summary>
        ''' <param name="pageWriter">
        '''   The XpsFixePageWriter for accessing the page fonts.</param>
        ''' <param name="writer">
        '''   The XmlWriter to output the glyph markup to.</param>
        ''' <param name="text">
        '''   The text of the glyph run.</param>
        ''' <param name="size">
        '''   The font size.</param>
        ''' <param name="x">
        '''   The X location of the glyph run.</param>
        ''' <param name="y">
        '''   The Y location of the glyph run.</param>
        ''' <param name="fontUri">
        '''   The path to font file.</param>
        Private Sub AddGlyphRun(pageWriter As IXpsFixedPageWriter, writer As XmlWriter, text As String, size As Integer, x As Integer, y As Integer, fontUri As String)
            Dim packageFontUri As String = GetXpsFont(pageWriter, fontUri)
            writer.WriteStartElement("Glyphs")
            writer.WriteAttributeString("OriginX", x.ToString())
            writer.WriteAttributeString("OriginY", y.ToString())
            writer.WriteAttributeString("FontRenderingEmSize", size.ToString())
            writer.WriteAttributeString("FontUri", packageFontUri)
            writer.WriteAttributeString("UnicodeString", text)
            writer.WriteAttributeString("Fill", "#FFFFE4C4")
            writer.WriteEndElement()
        End Sub


        ' --------------------------- GetXpsFont() ---------------------------
        ''' <summary>
        '''   Returns the relative path to a font part in the package.</summary>
        ''' <param name="pageWriter">
        '''   The page to associate the font with.</param>
        ''' <param name="fontUri">
        '''   The URI for the source font file.</param>
        ''' <returns>
        '''   The relative path to font part in the package.</returns>
        ''' <remarks>
        '''   If the font has not been added previously, GetXpsFont creates a
        '''   new font part and copies the font data from the specified
        '''   source font URI.</remarks>
        Private Function GetXpsFont(pageWriter As IXpsFixedPageWriter, fontUri As String) As String
            Dim packageFontUri As String
            If _fontDictionary.ContainsKey(fontUri) Then
                packageFontUri = _fontDictionary(fontUri)
            Else
                Dim xpsFont As XpsFont = pageWriter.AddFont(False)
                Dim dstStream As Stream = xpsFont.GetStream()
                Using srcStream As Stream = New FileStream(fontUri, FileMode.Open, FileAccess.Read)
                    Dim streamBytes(CInt(srcStream.Length) - 1) As Byte
                    srcStream.Read(streamBytes, 0, CInt(srcStream.Length))
                    dstStream.Write(streamBytes, 0, CInt(srcStream.Length))
                End Using
                _fontDictionary(fontUri) = xpsFont.Uri.ToString()
                packageFontUri = xpsFont.Uri.ToString()
                xpsFont.Commit()
            End If
            Return packageFontUri
        End Function ' end:GetXpsFont()


        ' ---------------------------- AddImage() ----------------------------
        ''' <summary>
        '''   Outputs the markup for adding an image.</summary>
        ''' <param name="pageWriter">
        '''   The FixedPageWriter associated for getting the image.</param>
        ''' <param name="writer">   The XmlWriter to output to.</param>
        ''' <param name="imgPath">  The image path.</param>
        ''' <param name="imageType">The image type</param>
        ''' <param name="x">        The X position of the image.</param>
        ''' <param name="y">        The Y position of the image.</param>
        ''' <param name="height">   The height of the image.</param>
        ''' <param name="width">    The width of the image.</param>
        Private Sub AddImage(pageWriter As IXpsFixedPageWriter, writer As XmlWriter, imgPath As String, imageType As XpsImageType, x As Single, y As Single, height As Single, width As Single)
            ' Write the surrounding path.
            writer.WriteStartElement("Path")

            ' Form the path data string.
            ' M="Move To"(start), L="Line To", Z="Close shape"
            Dim pathData As String = String.Format("M {0},{1} L {2},{3} {4},{5} {6},{7} z", x, y, x, y + height, x + width, y + height, x + width, y)

            writer.WriteAttributeString("Data", pathData)
            writer.WriteStartElement("Path.Fill")
            writer.WriteStartElement("ImageBrush")
            writer.WriteAttributeString("ImageSource", GetXpsImage(pageWriter, imgPath, imageType))
            Dim viewPort As String = String.Format("{0},{1},{2},{3}", 0, 0, width, height)

            writer.WriteAttributeString("Viewport", viewPort)
            writer.WriteAttributeString("ViewportUnits", "Absolute")
            Dim viewBox As String = String.Format("{0},{1},{2},{3}", x, y, x + width, y + height)

            writer.WriteAttributeString("Viewbox", viewBox)
            writer.WriteAttributeString("ViewboxUnits", "Absolute")
            writer.WriteEndElement() 'ImageBrush
            writer.WriteEndElement() 'Path.Fill
            writer.WriteEndElement() 'Path
        End Sub


        ' --------------------------- GetXpsImage() --------------------------
        ''' <summary>
        '''   Copies a given image to a specified XPS page.</summary>
        ''' <param name="pageWriter">
        '''   The FixedPage writer to copy the image to.</param>
        ''' <param name="imgPath">
        '''   The source file path for the image.</param>
        ''' <param name="imageType">
        '''   The type of the image.</param>
        ''' <returns>
        '''   The package URI of the copied image.</returns>
        Private Function GetXpsImage(pageWriter As IXpsFixedPageWriter, imgPath As String, imageType As XpsImageType) As String
            Dim xpsImage As XpsImage = pageWriter.AddImage(imageType)
            Using srcStream As New FileStream(imgPath, FileMode.Open)
                Dim dstStream As Stream = xpsImage.GetStream()
                Dim streamBytes(CInt(srcStream.Length) - 1) As Byte
                srcStream.Read(streamBytes, 0, CInt(srcStream.Length))
                dstStream.Write(streamBytes, 0, CInt(srcStream.Length))
            End Using
            xpsImage.Commit()
            Return xpsImage.Uri.ToString()
        End Function


        ' ------------------------ AddUriToTreeView() ------------------------
        ''' <summary>
        '''   Adds a given package URI as a node in a TreeView control.</summary>
        ''' <param name="parentNode">
        '''   The parent node of the TreeView control.</param>
        ''' <param name="uri">
        '''   The URI of the package element to add.</param>
        ''' <returns>
        '''   The node that was added to the TreeView control.</returns>
        Private Shared Function AddUriToTreeView(parentNode As TreeViewItem, uri As Uri) As TreeViewItem
            Dim node As New TreeViewItem With {
                .Header = System.IO.Path.GetFileName(uri.ToString()),
                .ToolTip = uri.ToString()
            }
            parentNode.Items.Add(node)
            Return node
		End Function
		#End Region ' Private Methods

		#Region "   Private Members"
		Private ReadOnly _fontDictionary As Dictionary(Of String, String)
        Private Shared _applicationDir As String
#End Region ' Private Members

    End Class

End Namespace ' end:namespace SDKSample
