'<Snippet2>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim productsXml As XmlDocument = LoadProducts()
        Dim xsltNodeList As XmlNodeList = GetXsltAsNodeList()
        TransformDoc(productsXml, xsltNodeList)

        ' Use XmlDsigXsltTransform to resolve a Uri.
        Dim baseUri As New Uri("http://www.contoso.com")
        Dim relativeUri As String = "xml"
        Dim absoluteUri As Uri = ResolveUris(baseUri, relativeUri)

        ' Align interface and conclude application.
        WriteLine(vbCrLf + "This sample completed successfully;" + _
            " press Exit to continue.")

        ' Reset the cursor.
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Create an XML document describing various products.
    Private Function LoadProducts() As XmlDocument
        Dim contosoProducts As String = "<?xml version='1.0'?>"
        contosoProducts += "<products>"
        contosoProducts += "<product><productid>1</productid>"
        contosoProducts += "<description>Widgets</description></product>"
        contosoProducts += "<product><productid>2</productid>"
        contosoProducts += "<description>Gadgits</description></product>"
        contosoProducts += "</products>"

        WriteLine(vbCrLf + _
            "Created the following Xml document for tranformation:")
        WriteLine(contosoProducts)

        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(contosoProducts)
        Return xmlDoc
    End Function

    Private Function GetXsltAsNodeList() As XmlNodeList
        Dim transformXml As String = "<xsl:transform version='1.0' "
        transformXml += "xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>"
        transformXml += "<xsl:template match='products'>"
        transformXml += "<table><tr><td>ProductId</td><td>Name</td></tr>"
        transformXml += "<xsl:apply-templates/></table></xsl:template>"
        transformXml += "<xsl:template match='product'><tr>"
        transformXml += "<xsl:apply-templates/></tr></xsl:template>"
        transformXml += "<xsl:template match='productid'><td>"
        transformXml += "<xsl:apply-templates/></td></xsl:template>"
        transformXml += "<xsl:template match='description'><td>"
        transformXml += "<xsl:apply-templates/></td></xsl:template>"
        transformXml += "</xsl:transform>"

        WriteLine(vbCrLf + "Created the following Xslt tranform:")
        WriteLine(transformXml)

        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(transformXml)
        Return xmlDoc.GetElementsByTagName("xsl:transform")
    End Function

    Private Sub TransformDoc( _
        ByVal xmlDoc As XmlDocument, _
        ByVal xsltNodeList As XmlNodeList)

        Try
            ' Construct a new XmlDsigXsltTransform.
            '<Snippet1>
            Dim xmlTransform As New XmlDsigXsltTransform
            '</Snippet1>

            ' Load the Xslt tranform as a node list.
            '<Snippet10>
            xmlTransform.LoadInnerXml(xsltNodeList)
            '</Snippet10>

            ' Load the Xml document to perform the tranform on.
            '<Snippet11>
            dim namespaceManager as New XmlNamespaceManager(xmlDoc.NameTable)

            Dim productsNodeList As XmlNodeList
            productsNodeList = xmlDoc.SelectNodes("//.", namespaceManager)

            xmlTransform.LoadInput(productsNodeList)
            '</Snippet11>

            ' Retrieve the output from the transform.
            '<Snippet7>
            Dim outputStream As Stream
            outputStream = CType(xmlTransform.GetOutput( _
                GetType(System.IO.Stream)), _
                System.IO.Stream)
            '</Snippet7>

            ' Read the output stream into a stream reader.
            Dim streamReader As New StreamReader(outputStream)

            ' Read the stream into a string.
            Dim outputMessage As String = streamReader.ReadToEnd()

            ' Close the streams.
            outputStream.Close()
            streamReader.Close()

            ' Display to the console the Xml before and after encryption.
            WriteLine(vbCrLf + "Result of transformation: " + outputMessage)
            ShowTransformProperties(xmlTransform)
        Catch ex As Exception
            WriteLine("Caught exception in TransformDoc method: " + _
                ex.ToString())
        End Try
    End Sub

    Private Sub ShowTransformProperties( _
            ByVal xmlTransform As XmlDsigXsltTransform)

        '<Snippet12>
        Dim classDescription As String = xmlTransform.ToString()
        '</Snippet12>
        WriteLine(vbCrLf + "** Summary for " + classDescription + " **")

        ' Retrieve the XML representation of the current transform.
        '<Snippet9>
        Dim xmlInTransform As XmlElement = xmlTransform.GetXml()
        '</Snippet9>
        WriteLine("Xml representation of the current transform:" + _
            vbCrLf + xmlInTransform.OuterXml)

        ' Ensure the transform is using the proper algorithm.
        '<Snippet3>
        xmlTransform.Algorithm = SignedXml.XmlDsigXsltTransformUrl
        '</Snippet3>
        Console.WriteLine("Algorithm used: " + classDescription)

        ' Retrieve the valid input types for the current transform.
        '<Snippet4>
        Dim validInTypes() As Type = xmlTransform.InputTypes
        '</Snippet4>
        WriteLine("Transform accepts the following inputs:")
        For i As Int16 = 0 To validInTypes.Length - 1 Step 1
            WriteLine("   " + validInTypes(i).ToString())
        Next

        '<Snippet5>
        Dim validOutTypes() As Type = xmlTransform.OutputTypes
        '</Snippet5>
        WriteLine("Transform outputs in the following types:")
        For j As Int16 = 0 To validOutTypes.Length - 1 Step 1

            WriteLine("   " + validOutTypes(j).ToString())
            If (validOutTypes(j).Equals(GetType(Object))) Then
                '<Snippet8>
                Dim outputObject As Object = xmlTransform.GetOutput()
                '</Snippet8>
            End If
        Next
    End Sub

    ' Resolve the specified base and relative Uri's .
    Private Function ResolveUris( _
        ByVal baseUri As Uri, _
        ByVal relativeUri As String) As Uri

        '<Snippet6>
        Dim xmlResolver As New XmlUrlResolver
        xmlResolver.Credentials = _
            System.Net.CredentialCache.DefaultCredentials

        Dim xmlTransform As New XmlDsigXsltTransform
        xmlTransform.Resolver = xmlResolver
        '</Snippet6>

        Dim absoluteUri As Uri = xmlResolver.ResolveUri(baseUri, relativeUri)
        If (Not absoluteUri Is Nothing) Then
            WriteLine(vbCrLf + _
                "Resolved the base Uri and relative Uri to the following:")
            WriteLine(absoluteUri.ToString())
        Else
            WriteLine("Unable to resolve the base Uri and relative Uri")
        End If
        
        Return absoluteUri
    End Function

    ' Write specified message and carriage return to the output textbox.
    Private Sub WriteLine(ByVal message As String)
        tbxOutput.AppendText(message + vbCrLf)

    End Sub

    ' Event handler for Exit button.
    Private Sub Button2_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Application.Exit()
    End Sub
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbxOutput As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbxOutput = New System.Windows.Forms.RichTextBox
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.DockPadding.All = 20
        Me.Panel2.Location = New System.Drawing.Point(0, 320)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(616, 64)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(446, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Run"
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(521, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "E&xit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbxOutput)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.DockPadding.All = 20
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 320)
        Me.Panel1.TabIndex = 2
        '
        'tbxOutput
        '
        Me.tbxOutput.AccessibleDescription = _
            "Displays output from application."
        Me.tbxOutput.AccessibleName = "Output textbox."
        Me.tbxOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxOutput.Location = New System.Drawing.Point(20, 20)
        Me.tbxOutput.Name = "tbxOutput"
        Me.tbxOutput.Size = New System.Drawing.Size(576, 280)
        Me.tbxOutput.TabIndex = 1
        Me.tbxOutput.Text = "Click the Run button to run the application."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(616, 384)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form1"
        Me.Text = "XmlDsigXsltTransform"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
' 
' Created the following Xml document for tranformation:
' <?xml version='1.0'?><products><product><productid>1</productid><description
' >Widgets</description></product><product><productid>2</productid><descriptio
' n>Gadgits</description></product></products>
' 
' Created the following Xslt tranform:
' <xsl:transform version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform
' '><xsl:template match='products'><table><tr><td>ProductId</td><td>Name</td><
' /tr><xsl:apply-templates/></table></xsl:template><xsl:template match='produc
' t'><tr><xsl:apply-templates/></tr></xsl:template><xsl:template match='produc
' tid'><td><xsl:apply-templates/></td></xsl:template><xsl:template match='desc
' ription'><td><xsl:apply-templates/></td></xsl:template></xsl:transform>
' 
' Result of transformation: <table><tr><td>ProductId</td><td>Name</td></tr><tr
' ><td>1</td><td>Widgets</td></tr><tr><td>2</td><td>Gadgits</td></tr></table>
' 
' ** Summary for System.Security.Cryptography.Xml.XmlDsigXsltTransform **
' Xml representation of the current transform:
' <Transform Algorithm="http://www.w3.org/TR/1999/REC-xslt-19991116" xmlns="ht
' tp://www.w3.org/2000/09/xmldsig#"><xsl:transform version="1.0" xmlns:xsl="ht
' tp://www.w3.org/1999/XSL/Transform"><xsl:template match="products"><table xm
' lns=""><tr><td>ProductId</td><td>Name</td></tr><xsl:apply-templates /></tabl
' e></xsl:template><xsl:template match="product"><tr xmlns=""><xsl:apply-templ
' ates /></tr></xsl:template><xsl:template match="productid"><td xmlns=""><xsl
' :apply-templates /></td></xsl:template><xsl:template match="description"><td
'  xmlns=""><xsl:apply-templates /></td></xsl:template></xsl:transform></Trans
' form>
' Transform accepts the following inputs:
'    System.IO.Stream
'    System.Xml.XmlDocument
'    System.Xml.XmlNodeList
' Transform outputs in the following types:
'    System.IO.Stream
' 
' Resolved the base Uri and relative Uri to the following:
' http://www.contoso.com/xml
' 
' This sample completed successfully; press Exit to continue.
'</Snippet2>