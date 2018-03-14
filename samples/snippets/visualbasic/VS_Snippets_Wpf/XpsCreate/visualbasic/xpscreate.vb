' XpsCreate SDK Sample - XpsCreate.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.IO.Packaging
Imports System.Xml
Imports System.Windows.Forms
Imports System.Windows.Xps
Imports System.Windows.Xps.Packaging
Imports System.Printing

Public Class XpsCreate
    Private Const packageWithPrintTicketName As String = "XpsDocument-withPrintTicket.xps"
    Private Const packageName As String = "XpsDocument.xps" ' (without PrintTicket)
    Private Const image1 As String = "picture.jpg"
    Private Const image2 As String = "image.tif"
    Private Const font1 As String = "courier.ttf"
    Private Const font2 As String = "arial.ttf"
    Private Const fontContentType As String = "application/vnd.ms-package.obfuscated-opentype"

    <STAThread()>
    Shared Sub Main(ByVal args() As String)
        Dim xpsCreate As New XpsCreate()
        xpsCreate.Run()
    End Sub ' end:Main()


    ' -------------------------------- Run -----------------------------------
    ''' <summary>
    '''   Creates two XpsDocument packages, the first without a PrintTicket
    '''   and a second with a PrintTicket.</summary>
    Public Sub Run()
        ' First, create an XpsDocument without a PrintTicket. - - - - - - - -

        ' If the document package exists from a previous run, delete it.
        If File.Exists(packageName) Then
            File.Delete(packageName)
        End If

        '<SnippetXpsCreatePackageOpen>
        ' Create an XpsDocument package (without PrintTicket).
        Using package1 As Package = Package.Open(packageName)
            Dim xpsDocument As New XpsDocument(package1)

            ' Add the package content (false=without PrintTicket).
            AddPackageContent(xpsDocument, False)

            ' Close the package.
            xpsDocument.Close()
        End Using
        '</SnippetXpsCreatePackageOpen>

        ' Next, create a second XpsDocument with a PrintTicket. - - - - - - -

        ' If the document package exists from a previous run, delete it.
        If File.Exists(packageWithPrintTicketName) Then
            File.Delete(packageWithPrintTicketName)
        End If

        ' Create an XpsDocument with PrintTicket.
        Using package2 As Package = Package.Open(packageWithPrintTicketName)
            Dim xpsDocumentWithPrintTicket As New XpsDocument(package2)

            ' Add the package content (true=with PrintTicket).
            AddPackageContent(xpsDocumentWithPrintTicket, True)

            ' Close the package.
            xpsDocumentWithPrintTicket.Close()
        End Using

        ' Normal Completion, show the package names created.
        Dim msg As String = "Created two XPS document packages:" & vbLf & "   - " & packageName & vbLf & "   - " & packageWithPrintTicketName
        MessageBox.Show(msg, "Normal Completion", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub ' end:Run()


    '<SnippetXpsCreateAddPkgContent>
    ' ------------------------- AddPackageContent ----------------------------
    ''' <summary>
    '''   Adds a predefined set of content to a given XPS document.</summary>
    ''' <param name="xpsDocument">
    '''   The package to add the document content to.</param>
    ''' <param name="attachPrintTicket">
    '''   true to include a PrintTicket with the
    '''   document; otherwise, false.</param>
    Private Sub AddPackageContent(ByVal xpsDocument As XpsDocument, ByVal attachPrintTicket As Boolean)
        Try
            Dim printTicket As PrintTicket = GetPrintTicketFromPrinter()
            ' PrintTicket is null, there is no need to attach one.
            If printTicket Is Nothing Then
                attachPrintTicket = False
            End If

            ' Add a FixedDocumentSequence at the Package root
            Dim documentSequenceWriter As IXpsFixedDocumentSequenceWriter = xpsDocument.AddFixedDocumentSequence()

            ' Add the 1st FixedDocument to the FixedDocumentSequence. - - - - -
            Dim fixedDocumentWriter As IXpsFixedDocumentWriter = documentSequenceWriter.AddFixedDocument()

            ' Add content to the 1st document
            AddDocumentContent(fixedDocumentWriter)

            ' Commit the 1st Document
            fixedDocumentWriter.Commit()

            ' Add a 2nd FixedDocument to the FixedDocumentSequence. - - - - - -
            fixedDocumentWriter = documentSequenceWriter.AddFixedDocument()

            ' Add content to the 2nd document.
            AddDocumentContent(fixedDocumentWriter)

            ' If attaching PrintTickets, attach one at the FixedDocument level.
            If attachPrintTicket Then
                fixedDocumentWriter.PrintTicket = printTicket
            End If

            ' Commit the 2nd document.
            fixedDocumentWriter.Commit()

            ' If attaching PrintTickets, attach one at
            ' the package FixedDocumentSequence level.
            If attachPrintTicket Then
                documentSequenceWriter.PrintTicket = printTicket
            End If

            ' Commit the FixedDocumentSequence
            documentSequenceWriter.Commit()
        Catch xpsException As XpsPackagingException
            Throw xpsException
        End Try
    End Sub ' end:AddPackageContent()
    '</SnippetXpsCreateAddPkgContent>


    '<SnippetXpsCreateAddDocContent>
    ' ------------------------- AddDocumentContent ---------------------------
    ''' <summary>
    '''   Adds a predefined set of content to a given document writer.</summary>
    ''' <param name="fixedDocumentWriter">
    '''   The document writer to add the content to.</param>
    Private Sub AddDocumentContent(ByVal fixedDocumentWriter As IXpsFixedDocumentWriter)
        ' Collection of image and font resources used on the current page.
        '   Key: "XpsImage", "XpsFont"
        '   Value: List of XpsImage or XpsFont resources
        Dim resources As Dictionary(Of String, List(Of XpsResource))

        Try
            ' Add Page 1 to current document.
            Dim fixedPageWriter As IXpsFixedPageWriter = fixedDocumentWriter.AddFixedPage()

            ' Add the resources for Page 1 and get the resource collection.
            resources = AddPageResources(fixedPageWriter)

            ' Write page content for Page 1.
            WritePageContent(fixedPageWriter.XmlWriter, "Page 1 of " & fixedDocumentWriter.Uri.ToString(), resources)

            ' Commit Page 1.
            fixedPageWriter.Commit()

            ' Add Page 2 to current document.
            fixedPageWriter = fixedDocumentWriter.AddFixedPage()

            ' Add the resources for Page 2 and get the resource collection.
            resources = AddPageResources(fixedPageWriter)

            ' Write page content to Page 2.
            WritePageContent(fixedPageWriter.XmlWriter, "Page 2 of " & fixedDocumentWriter.Uri.ToString(), resources)

            ' Commit Page 2.
            fixedPageWriter.Commit()
        Catch xpsException As XpsPackagingException
            Throw xpsException
        End Try
    End Sub ' end:AddDocumentContent()
    '</SnippetXpsCreateAddDocContent>


    '<SnippetXpsCreateAddPageResources>
    ' -------------------------- AddPageResources ----------------------------
    Private Function AddPageResources(ByVal fixedPageWriter As IXpsFixedPageWriter) As Dictionary(Of String, List(Of XpsResource))
        ' Collection of all resources for this page.
        '   Key: "XpsImage", "XpsFont"
        '   Value: List of XpsImage or XpsFont
        Dim resources As New Dictionary(Of String, List(Of XpsResource))()

        ' Collections of images and fonts used in the current page.
        Dim xpsImages As New List(Of XpsResource)()
        Dim xpsFonts As New List(Of XpsResource)()

        Try
            Dim xpsImage As XpsImage
            Dim xpsFont As XpsFont

            ' Add, Write, and Commit image1 to the current page.
            xpsImage = fixedPageWriter.AddImage(XpsImageType.JpegImageType)
            WriteToStream(xpsImage.GetStream(), image1)
            xpsImage.Commit()
            xpsImages.Add(xpsImage) ' Add image1 as a required resource.

            ' Add, Write, and Commit font 1 to the current page.
            xpsFont = fixedPageWriter.AddFont()
            WriteObfuscatedStream(xpsFont.Uri.ToString(), xpsFont.GetStream(), font1)
            xpsFont.Commit()
            xpsFonts.Add(xpsFont) ' Add font1 as a required resource.

            ' Add, Write, and Commit image2 to the current page.
            xpsImage = fixedPageWriter.AddImage(XpsImageType.TiffImageType)
            WriteToStream(xpsImage.GetStream(), image2)
            xpsImage.Commit()
            xpsImages.Add(xpsImage) ' Add image2 as a required resource.

            ' Add, Write, and Commit font2 to the current page.
            xpsFont = fixedPageWriter.AddFont(False)
            WriteToStream(xpsFont.GetStream(), font2)
            xpsFont.Commit()
            xpsFonts.Add(xpsFont) ' Add font2 as a required resource.

            ' Return the image and font resources in a combined collection.
            resources.Add("XpsImage", xpsImages)
            resources.Add("XpsFont", xpsFonts)
            Return resources
        Catch xpsException As XpsPackagingException
            Throw xpsException
        End Try
    End Function ' end:AddPageResources()
    '</SnippetXpsCreateAddPageResources>


    '<SnippetPrinterCapabilities>
    ' ---------------------- GetPrintTicketFromPrinter -----------------------
    ''' <summary>
    '''   Returns a PrintTicket based on the current default printer.</summary>
    ''' <returns>
    '''   A PrintTicket for the current local default printer.</returns>
    Private Function GetPrintTicketFromPrinter() As PrintTicket
        Dim printQueue As PrintQueue = Nothing

        Dim localPrintServer As New LocalPrintServer()

        ' Retrieving collection of local printer on user machine
        Dim localPrinterCollection As PrintQueueCollection = localPrintServer.GetPrintQueues()

        Dim localPrinterEnumerator As System.Collections.IEnumerator = localPrinterCollection.GetEnumerator()

        If localPrinterEnumerator.MoveNext() Then
            ' Get PrintQueue from first available printer
            printQueue = CType(localPrinterEnumerator.Current, PrintQueue)
        Else
            ' No printer exist, return null PrintTicket
            Return Nothing
        End If

        ' Get default PrintTicket from printer
        Dim printTicket As PrintTicket = printQueue.DefaultPrintTicket

        Dim printCapabilites As PrintCapabilities = printQueue.GetPrintCapabilities()

        ' Modify PrintTicket
        If printCapabilites.CollationCapability.Contains(Collation.Collated) Then
            printTicket.Collation = Collation.Collated
        End If

        If printCapabilites.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge) Then
            printTicket.Duplexing = Duplexing.TwoSidedLongEdge
        End If

        If printCapabilites.StaplingCapability.Contains(Stapling.StapleDualLeft) Then
            printTicket.Stapling = Stapling.StapleDualLeft
        End If

        Return printTicket
    End Function ' end:GetPrintTicketFromPrinter()
    '</SnippetPrinterCapabilities>


    '<SnippetXpsCreateWritePageContent>
    ' --------------------------- WritePageContent ---------------------------
    Private Sub WritePageContent(ByVal xmlWriter As XmlWriter, ByVal documentUri As String, ByVal resources As Dictionary(Of String, List(Of XpsResource)))
        Dim xpsImages As List(Of XpsResource) = resources("XpsImage")
        Dim xpsFonts As List(Of XpsResource) = resources("XpsFont")

        ' Element are indented for reading purposes only
        xmlWriter.WriteStartElement("FixedPage")
        xmlWriter.WriteAttributeString("Width", "816")
        xmlWriter.WriteAttributeString("Height", "1056")
        xmlWriter.WriteAttributeString("xmlns", "http://schemas.microsoft.com/xps/2005/06")
        xmlWriter.WriteAttributeString("xml:lang", "en-US")

        xmlWriter.WriteStartElement("Glyphs")
        xmlWriter.WriteAttributeString("Fill", "#ff000000")
        xmlWriter.WriteAttributeString("FontUri", xpsFonts(0).Uri.ToString())
        xmlWriter.WriteAttributeString("FontRenderingEmSize", "18")
        xmlWriter.WriteAttributeString("OriginX", "120")
        xmlWriter.WriteAttributeString("OriginY", "110")
        xmlWriter.WriteAttributeString("UnicodeString", documentUri)
        xmlWriter.WriteEndElement()

        xmlWriter.WriteStartElement("Glyphs")
        xmlWriter.WriteAttributeString("Fill", "#ff000000")
        xmlWriter.WriteAttributeString("FontUri", xpsFonts(1).Uri.ToString())
        xmlWriter.WriteAttributeString("FontRenderingEmSize", "16")
        xmlWriter.WriteAttributeString("OriginX", "120")
        xmlWriter.WriteAttributeString("OriginY", "130")
        xmlWriter.WriteAttributeString("UnicodeString", "Test String in Arial")
        xmlWriter.WriteEndElement()

        xmlWriter.WriteStartElement("Path")
        xmlWriter.WriteAttributeString("Data", "M 120,187 L 301,187 301,321 120,321 z")
        xmlWriter.WriteStartElement("Path.Fill")
        xmlWriter.WriteStartElement("ImageBrush")
        xmlWriter.WriteAttributeString("ImageSource", xpsImages(0).Uri.ToString())
        xmlWriter.WriteAttributeString("Viewbox", "0,0,181,134")
        xmlWriter.WriteAttributeString("TileMode", "None")
        xmlWriter.WriteAttributeString("ViewboxUnits", "Absolute")
        xmlWriter.WriteAttributeString("ViewportUnits", "Absolute")
        xmlWriter.WriteAttributeString("Viewport", "120,187,181,134")
        xmlWriter.WriteEndElement()
        xmlWriter.WriteEndElement()
        xmlWriter.WriteEndElement()

        xmlWriter.WriteStartElement("Path")
        xmlWriter.WriteAttributeString("Data", "M 120,357 L 324,357 324,510 120,510 z")
        xmlWriter.WriteStartElement("Path.Fill")
        xmlWriter.WriteStartElement("ImageBrush")
        xmlWriter.WriteAttributeString("ImageSource", xpsImages(1).Uri.ToString())
        xmlWriter.WriteAttributeString("Viewbox", "0,0,204,153")
        xmlWriter.WriteAttributeString("TileMode", "None")
        xmlWriter.WriteAttributeString("ViewboxUnits", "Absolute")
        xmlWriter.WriteAttributeString("ViewportUnits", "Absolute")
        xmlWriter.WriteAttributeString("Viewport", "120,357,204,153")
        xmlWriter.WriteEndElement()
        xmlWriter.WriteEndElement()
        xmlWriter.WriteEndElement()
        xmlWriter.WriteEndElement()
    End Sub ' end:WritePageContent()
    '</SnippetXpsCreateWritePageContent>


    ' ----------------------------- WriteToStream ----------------------------
    Private Sub WriteToStream(ByVal stream As Stream, ByVal resource As String)
        Const bufSize As Integer = &H1000
        Dim buf(bufSize - 1) As Byte
        Dim bytesRead As Integer = 0

        Using fileStream As New FileStream(resource, FileMode.Open, FileAccess.Read)
            bytesRead = fileStream.Read(buf, 0, bufSize)
            Do While bytesRead > 0
                stream.Write(buf, 0, bytesRead)
                bytesRead = fileStream.Read(buf, 0, bufSize)
            Loop
        End Using
    End Sub ' end:WriteToStream()


    ' ------------------------- WriteObfuscatedStream ------------------------
    Private Sub WriteObfuscatedStream(ByVal resourceName As String, ByVal stream As Stream, ByVal resource As String)
        Dim bufSize As Integer = &H1000
        Dim guidByteSize As Integer = 16
        Dim obfuscatedByte As Integer = 32

        ' Get the GUID byte from the resource name.  Typical Font name:
        '    /Resources/Fonts/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.ODTTF
        Dim startPos As Integer = resourceName.LastIndexOf("/"c) + 1
        Dim length As Integer = resourceName.LastIndexOf("."c) - startPos
        resourceName = resourceName.Substring(startPos, length)

        Dim guid As New Guid(resourceName)

        Dim guidString As String = guid.ToString("N")

        ' Parsing the guid string and coverted into byte value
        Dim guidBytes(guidByteSize - 1) As Byte
        For i As Integer = 0 To guidBytes.Length - 1
            guidBytes(i) = Convert.ToByte(guidString.Substring(i * 2, 2), 16)
        Next i

        Using filestream As New FileStream(resource, FileMode.Open)
            ' XOR the first 32 bytes of the source
            ' resource stream with GUID byte.
            Dim buf(obfuscatedByte - 1) As Byte
            filestream.Read(buf, 0, obfuscatedByte)

            For i As Integer = 0 To obfuscatedByte - 1
                Dim guidBytesPos As Integer = guidBytes.Length - (i Mod guidBytes.Length) - 1
                buf(i) = buf(i) Xor guidBytes(guidBytesPos)
            Next i
            stream.Write(buf, 0, obfuscatedByte)

            ' copy remaining stream from source without obfuscation
            buf = New Byte(bufSize - 1) {}

            Dim bytesRead As Integer = 0
            bytesRead = filestream.Read(buf, 0, bufSize)
            Do While bytesRead > 0
                stream.Write(buf, 0, bytesRead)
                bytesRead = filestream.Read(buf, 0, bufSize)
            Loop
        End Using
    End Sub ' end:WriteObfuscatedStream()

End Class ' end:class XpsCreate
