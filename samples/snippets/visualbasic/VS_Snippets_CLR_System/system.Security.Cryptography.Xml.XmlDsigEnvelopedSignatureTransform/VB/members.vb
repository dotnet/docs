'<Snippet2>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private certificatePath As String = "..\\my509.cer"

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        ' Encrypt an XML message
        Dim productsXml As XmlDocument = LoadProducts()
        ShowTransformProperties(productsXml)

        SignDocument(productsXml)
        ShowTransformProperties(productsXml)

        ' Use XmlDsigEnvelopedSignatureTransform to resolve a Uri.
        Dim baseUri As New Uri("http://www.contoso.com")
        Dim relativeUri As String = "xml"
        Dim absoluteUri As Uri = ResolveUris(baseUri, relativeUri)

        ' Align interface and conclude application.
        WriteLine(vbCrLf + "This sample completed successfully;" + _
            " press Exit to continue.")

        ' Reset the cursor.
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Encrypt the text in the specified XmlDocument.
    Private Sub ShowTransformProperties(ByVal xmlDoc As XmlDocument)
        '<Snippet1>
        Dim xmlTransform As New XmlDsigEnvelopedSignatureTransform
        '</Snippet1>

        ' Ensure the transform is using the proper algorithm.
        '<Snippet4>
        xmlTransform.Algorithm = _
            SignedXml.XmlDsigEnvelopedSignatureTransformUrl
        '</Snippet4>

        ' Retrieve the XML representation of the current transform.
        '<Snippet10>
        Dim xmlInTransform As XmlElement = xmlTransform.GetXml()
        '</Snippet10>

        WriteLine(vbCrLf + "Xml representation of the current transform: ")
        WriteLine(xmlInTransform.OuterXml)

        ' Retrieve the valid input types for the current transform.
        '<Snippet5>
        Dim validInTypes() As Type = xmlTransform.InputTypes
        '</Snippet5>

        ' Verify the xmlTransform can accept the XMLDocument as an
        ' input type.
        For i As Int16 = 0 To validInTypes.Length Step 1
            If (validInTypes(i).Equals(xmlDoc.GetType())) Then
                ' Load the document into the transfrom.
                '<Snippet12>
                xmlTransform.LoadInput(xmlDoc)
                '</Snippet12>

                '<Snippet3>
                Dim IncludeComments As Boolean = True
                ' This transform is created for demonstration purposes.
                Dim secondTransform As _
                    New XmlDsigEnvelopedSignatureTransform(IncludeComments)
                '</Snippet3>

                '<Snippet13>
                Dim classDescription As String = secondTransform.ToString()
                '</Snippet13>

                ' This call does not perform as expected.
                '<Snippet11>
                ' An enveloped signature has no inner XML elements
                secondTransform.LoadInnerXml(xmlDoc.SelectNodes("//."))
                '</Snippet11>
                Exit For
            End If
        Next

        '<Snippet6>
        Dim validOutTypes() As Type = xmlTransform.OutputTypes
        '</Snippet6>
        For i As Int16 = validOutTypes.Length - 1 To 0 Step -1
            If (validOutTypes(i).Equals(GetType(System.Xml.XmlDocument))) Then
                Try
                    '<Snippet9>
                    Dim xmlDocumentType As Type
                    xmlDocumentType = GetType(System.Xml.XmlDocument)

                    Dim xmlDocumentOutput As XmlDocument
                    xmlDocumentOutput = CType( _
                        xmlTransform.GetOutput(xmlDocumentType), _
                        XmlDocument)
                    '</Snippet9>

                    ' Display to the console the Xml before and after
                    ' encryption.
                    WriteLine("Result of the GetOutput method call from " + _
                        "the current transform: " + _
                        xmlDocumentOutput.OuterXml)
                Catch ex As Exception
                    WriteLine("Unexpected exception caught: " + ex.ToString())

                End Try
                Exit For
            ElseIf (validOutTypes(i).Equals( _
                GetType(System.Xml.XmlNodeList))) Then

                Try
                    Dim xmlNodeListType As Type
                    xmlNodeListType = GetType(System.Xml.XmlNodeList)
                    Dim xmlNodes As XmlNodeList
                    xmlNodes = CType( _
                        xmlTransform.GetOutput(xmlNodeListType), _
                        System.Xml.XmlNodeList)

                    ' Display to the console the Xml before and after
                    ' encryption.
                    WriteLine("Encoding the following message: " + _
                        xmlDoc.InnerText)

                    WriteLine("Nodes of the XmlNodeList retrieved from " + _
                        "GetOutput:")

                    For j As Int16 = 0 To xmlNodes.Count - 1 Step 1
                        WriteLine("Node " + j.ToString() + " has the " + _
                            "following name: " + xmlNodes.Item(j).Name + _
                            " and the following InnerXml: " + _
                            xmlNodes.Item(j).InnerXml)
                    Next
                Catch ex As Exception
                    WriteLine("Unexpected exception caught: " + ex.ToString())
                End Try

                Exit For
            Else
                '<Snippet8>
                Dim outputObject As Object = xmlTransform.GetOutput()
                '</Snippet8>
            End If
        Next
    End Sub

    Private Function LoadProducts() As XmlDocument
        Dim xmlDoc As New XmlDocument

        Dim contosoProducts As String = "<PRODUCTS>"
        contosoProducts += "<PRODUCT><ID>123</ID>"
        contosoProducts += "<DESCRIPTION>Router</DESCRIPTION></PRODUCT>"
        contosoProducts += "<PRODUCT><ID>456</ID>"
        contosoProducts += "<DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT>"
        contosoProducts += "<PRODUCT><ID>789</ID>"
        contosoProducts += "<DESCRIPTION>Monitor</DESCRIPTION></PRODUCT>"
        contosoProducts += "</PRODUCTS>"

        xmlDoc.LoadXml(contosoProducts)
        Return xmlDoc
    End Function

    ' Create a signature and add it to the specified document.
    Private Sub SignDocument(ByRef xmlDoc As XmlDocument)
        ' Generate a signing key.
        Dim Key As New RSACryptoServiceProvider

        ' Create a SignedXml object.
        Dim signedXml As New SignedXml(xmlDoc)

        ' Add the key to the SignedXml document. 
        signedXml.SigningKey = Key

        ' Create a reference to be signed.
        Dim reference As New Reference
        Reference.Uri = ""

        ' Add an enveloped transformation to the reference.
        Reference.AddTransform(New XmlDsigEnvelopedSignatureTransform)

        ' Add the reference to the SignedXml object.
        SignedXml.AddReference(Reference)

        Try
            ' Create a new KeyInfo object.
            Dim keyInfo As New keyInfo

            ' Load the X509 certificate.
            Dim MSCert As X509Certificate
            MSCert = X509Certificate.CreateFromCertFile(certificatePath)

            ' Load the certificate into a KeyInfoX509Data object
            ' and add it to the KeyInfo object.
            keyInfo.AddClause(New KeyInfoX509Data(MSCert))

            ' Add the KeyInfo object to the SignedXml object.
            signedXml.KeyInfo = keyInfo

        Catch ex As FileNotFoundException
            WriteLine("Unable to load the following file: " + certificatePath)

        End Try
        ' Compute the signature.
        signedXml.ComputeSignature()

        ' Add the signature branch to the original tree so it is enveloped.
        xmlDoc.DocumentElement.AppendChild(signedXml.GetXml())
    End Sub

    ' Resolve the specified base and relative Uri's .
    Private Function ResolveUris( _
        ByVal baseUri As Uri, _
        ByVal relativeUri As String) As Uri

        '<Snippet7>
        Dim xmlResolver As New XmlUrlResolver

        xmlResolver.Credentials = _
            System.Net.CredentialCache.DefaultCredentials

        Dim xmlTransform As New XmlDsigEnvelopedSignatureTransform
        xmlTransform.Resolver = xmlResolver
        '</Snippet7>

        Dim absoluteUri As Uri = xmlResolver.ResolveUri(baseUri, relativeUri)

        If Not absoluteUri Is Nothing Then
            WriteLine(vbCrLf + "Resolved the base Uri and relative Uri " + _
                "to the following:")
            WriteLine(absoluteUri.ToString())
        Else
            WriteLine("Unable to resolve the base Uri and relative Uri")
        End If

        Return absoluteUri
    End Function

    ' Write specified message and carriage return to the output textbox.
    Private Sub WriteLine(ByVal message As String)
        tbxOutput.AppendText(Message + vbCrLf)

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
        Me.Text = "XmlDsigEnvelopedSignatureTransform"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' Xml representation of the current transform: 
' <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature"
' xmlns="http://www.w3.org/2000/09/xmldsig#" />
' Result of the GetOutput method call from the current transform: <PRODUCTS>
' <PRODUCT><ID>123</ID><DESCRIPTION>Router</DESCRIPTION></PRODUCT><PRODUCT>
' <ID>456</ID><DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT><PRODUCT><ID>789
' </ID><DESCRIPTION>Monitor</DESCRIPTION></PRODUCT></PRODUCTS>
' Unable to load the following file: ..\\my509.cer
' 
' Xml representation of the current transform: 
' <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-signature"
'  xmlns="http://www.w3.org/2000/09/xmldsig#" />
' Result of the GetOutput method call from the current transform: <PRODUCTS>
' <PRODUCT><ID>123</ID><DESCRIPTION>Router</DESCRIPTION></PRODUCT><PRODUCT>
' <ID>456</ID><DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT><PRODUCT><ID>789
' </ID><DESCRIPTION>Monitor</DESCRIPTION></PRODUCT><Signature xmlns=
' "http://www.w3.org/2000/09/xmldsig#"><SignedInfo><CanonicalizationMethod 
' Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315" />
' <SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1" />
' <Reference URI=""><Transforms><Transform Algorithm="http://www.w3.org/2000
' /09/xmldsig#enveloped-signature" /></Transforms><DigestMethod Algorithm=
' "http://www.w3.org/2000/09/xmldsig#sha1" /><DigestValue>KvPW6HUiIUMEDS0YSoTg
' po2JPbA=</DigestValue></Reference></SignedInfo><SignatureValue>c/njCGDru/aWA
' mWG83I+mWO040xOzxvmNx0b0o8ZyPc9j5VwApdAt103OGBtB1H6EkOvt7Ekw+PVuUo8m5LzLPyaT
' xUDMbb2kZZ5itSkGD4rmMUMUMuzrkAoquJZjxeOydBJ2CMehV2rE3RMPLIwRX176DZVy5JKU6Cb7
' PR2Rpw=</SignatureValue></Signature></PRODUCTS>
' 
' Resolved the base Uri and relative Uri to the following:
' http://www.contoso.com/xml
' 
' This sample completed successfully; press Exit to continue.
'</Snippet2>