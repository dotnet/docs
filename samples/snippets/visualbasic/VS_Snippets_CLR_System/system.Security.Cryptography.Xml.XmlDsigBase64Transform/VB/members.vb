'<Snippet2>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml


Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        ' Encrypt an XML message
        EncryptXML(LoadXMLDoc())

        ' Using XmlDsigBase64Transform resolving a Uri.
        Dim baseUri As New Uri("http://www.microsoft.com")
        Dim relativeUri As String = "msdn"
        Dim absoluteUri As Uri = ResolveUris(baseUri, relativeUri)

        ' Reset the cursor and conclude application.
        WriteLine(vbCrLf + "This sample completed successfully;" + _
            " press Exit to continue.")
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Encrypt the text in the specified XmlDocument.
    Private Sub EncryptXML(ByVal xmlDoc As XmlDocument)
        '<Snippet1>
        Dim xmlTransform As New XmlDsigBase64Transform
        '</Snippet1>

        ' Ensure the transform is using the proper algorithm.
        '<Snippet3>
        xmlTransform.Algorithm = SignedXml.XmlDsigBase64TransformUrl
        '</Snippet3>

        ' Retrieve the XML representation of the current transform.
        '<Snippet9>
        Dim xmlInTransform As XmlElement = xmlTransform.GetXml()
        '</Snippet9>

        WriteLine("Xml representation of the current transform: ")
        WriteLine(xmlInTransform.OuterXml)

        ' Retrieve the valid input types for the current transform.
        '<Snippet4>
        Dim validInTypes() As Type = xmlTransform.InputTypes
        '</Snippet4>

        ' Verify the xmlTransform can accept the XMLDocument as an
        ' input type.
        For i As Int16 = 0 To validInTypes.Length Step 1
            If (validInTypes(i).Equals(xmlDoc.GetType())) Then
                ' Demonstrate loading the entire Xml Document.
                '<Snippet11>
                xmlTransform.LoadInput(xmlDoc)
                '</Snippet11>

                ' This transform is created for demonstration purposes.
                Dim secondTransform As New XmlDsigBase64Transform

                '<Snippet12>
                Dim classDescription As String = secondTransform.ToString()
                '</Snippet12>

                ' This call does not perform as expected.
                ' LoadInnerXml is overridden by the XmlDsigBase64Transform
                ' class, but is stubbed out.
                '<Snippet10>
                secondTransform.LoadInnerXml(xmlDoc.SelectNodes("//."))
                '</Snippet10>

                Exit For
            End If
        Next
        '<Snippet5>
        Dim validOutTypes() As Type = xmlTransform.OutputTypes
        '</Snippet5>

        For i As Int16 = 0 To validOutTypes.Length Step 1
            If (validOutTypes(i).equals(GetType(System.IO.Stream))) Then
                Try
                    '<Snippet8>
                    Dim streamType As Type = GetType(System.IO.Stream)

                    Dim outputStream As CryptoStream
                    outputStream = CType( _
                        xmlTransform.GetOutput(streamType), _
                        CryptoStream)

                    '</Snippet8>

                    ' Read the CryptoStream into a stream reader.
                    Dim streamReader As New StreamReader(outputStream)

                    ' Read the stream into a string.
                    Dim outputMessage As String = streamReader.ReadToEnd()

                    ' Close the streams.
                    outputStream.Close()
                    streamReader.Close()

                    ' Display to the console the Xml before and after
                    ' encryption.
                    WriteLine("Encoding the following message: " + _
                        xmlDoc.InnerText)
                    WriteLine("Message encoded: " + outputMessage)

                Catch ex As Exception
                    WriteLine("Unexpected exception caught: " + _
                        ex.ToString())

                End Try

                ' Stop cycling through types, exit operation.
                Exit For
            Else
                '<Snippet7>
                Dim outputObject As Object = xmlTransform.GetOutput()
                '</Snippet7>
            End If
        Next
    End Sub

    ' Create an XML document with Element and Text nodes.
    Private Function LoadXMLDoc() As XmlDocument
        Dim xmlDoc As New XmlDocument

        Dim mainNode As XmlNode = xmlDoc.CreateNode( _
            XmlNodeType.Element, _
            "ContosoMessages", _
            "http://www.contoso.com")

        Dim textNode As XmlNode
        textNode = xmlDoc.CreateTextNode("Some text to encode.")
        mainNode.AppendChild(textNode)
        xmlDoc.AppendChild(mainNode)

        WriteLine("Created the following XML Document for " + _
            "transformation: ")
        WriteLine(xmlDoc.InnerXml)
        Return xmlDoc
    End Function

    ' Resolve the specified base and relative Uri's .
    Private Function ResolveUris( _
        ByVal baseUri As Uri, _
        ByVal relativeUri As String) As Uri

        '<Snippet6>
        Dim xmlResolver As New XmlUrlResolver
        xmlResolver.Credentials = _
            System.Net.CredentialCache.DefaultCredentials

        Dim xmlTransform As New XmlDsigBase64Transform
        xmlTransform.Resolver = xmlResolver
        '</Snippet6>

        Dim absoluteUri As Uri = _
            xmlResolver.ResolveUri(baseUri, relativeUri)

        If Not absoluteUri Is Nothing Then
            WriteLine( _
                "Resolved the base Uri and relative Uri to the following:")
            WriteLine(absoluteUri.ToString())
        Else
            WriteLine("Unable to resolve the base Uri and relative Uri")
        End If
        Return absoluteUri
    End Function

    ' Write message and carriage return to the output textbox.
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
        Me.Text = "XmlDsigBase64Transform"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' Created the following XML Document for transformation: 
' <ContosoMessages xmlns="http://www.contoso.com">Some text to encode.
' </ContosoMessages>
' Xml representation of the current transform: 
' <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#base64" xmlns=
' "http://www.w3.org/2000/09/xmldsig#" />
' Encoding the following message: Some text to encode.
' Message encoded: Jmr^
' Resolved the base Uri and relative Uri to the following:
' http://www.microsoft.com/msdn
' 
' This sample completed successfully; press Exit to continue.
'</Snippet2>