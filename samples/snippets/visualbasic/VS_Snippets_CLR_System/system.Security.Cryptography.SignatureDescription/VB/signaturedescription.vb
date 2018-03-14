' This sample demonstrates how to use each member of the SignatureDescription
' class.
'<Snippet2>
Imports System
Imports System.Security
Imports System.Security.Cryptography

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        ' Create a digital signature based on RSA encryption.
        Dim rsaSignature As SignatureDescription = CreateRSAPKCS1Signature()
        ShowProperties(rsaSignature)

        ' Create a digital signature based on DSA encryption.
        Dim dsaSignature As SignatureDescription = CreateDSASignature()
        ShowProperties(dsaSignature)

        ' Create a HashAlgorithm using the digest algorithm of the signature.
        '<Snippet10>
        Dim hashAlgorithm As HashAlgorithm = dsaSignature.CreateDigest()
        '</Snippet10>
        WriteLine("Hash algorithm for the DigestAlgorithm property: " + _
            hashAlgorithm.ToString())

        ' Create an AsymmetricSignatureFormatter instance using the DSA key.
        Dim dsa As DSA = dsa.Create()
        Dim asymmetricFormatter As AsymmetricSignatureFormatter = _
            CreateDSAFormatter(dsa)

        ' Create an AsymmetricSignatureDeformatter instance using the DSA key.
        dim asymmetricDeformatter as AsymmetricSignatureDeformatter = _
            CreateDSADeformatter(dsa)

        ' Align interface and conclude application.
        WriteLine("This sample completed successfully;" + _
            " press Exit to continue.")

        ' Reset the cursor to the default look.
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Create a SignatureDescription for RSA encryption.
    Private Function CreateRSAPKCS1Signature() As SignatureDescription
        '<Snippet1>
        Dim signatureDescription As New SignatureDescription
        '</Snippet1>

        ' Set the key algorithm property for RSA encryption.
        '<Snippet7>
        signatureDescription.KeyAlgorithm = _
            "System.Security.Cryptography.RSACryptoServiceProvider"
        '</Snippet7>

        ' Set the digest algorithm for RSA encryption using the SHA1 provider.
        '<Snippet6>
        signatureDescription.DigestAlgorithm = _
            "System.Security.Cryptography.SHA1CryptoServiceProvider"
        '</Snippet6>

        ' Set the formatter algorithm with the RSAPKCS1 formatter.
        '<Snippet9>
        signatureDescription.FormatterAlgorithm = _
            "System.Security.Cryptography.RSAPKCS1SignatureFormatter"
        '</Snippet9>

        ' Set the formatter algorithm with the RSAPKCS1 deformatter.
        '<Snippet8>
        signatureDescription.DeformatterAlgorithm = _
            "System.Security.Cryptography.RSAPKCS1SignatureDeformatter"
        '</Snippet8>

        Return SignatureDescription
    End Function

    ' Create a SignatureDescription using a constructed SecurityElement for 
    ' DSA encryption.
    Private Function CreateDSASignature() As SignatureDescription
        '<Snippet3>
        Dim securityElement As New SecurityElement("DSASignature")

        ' Create new security elements for the four algorithms.
        securityElement.AddChild(new SecurityElement( _
            "Key", _
            "System.Security.Cryptography.DSACryptoServiceProvider"))
        securityElement.AddChild(New SecurityElement( _
            "Digest", _
            "System.Security.Cryptography.SHA1CryptoServiceProvider"))
        securityElement.AddChild(new SecurityElement( _
            "Formatter", _
            "System.Security.Cryptography.DSASignatureFormatter"))
        securityElement.AddChild(new SecurityElement( _
            "Deformatter", _
            "System.Security.Cryptography.DSASignatureDeformatter"))

        Dim signatureDescription As New SignatureDescription(securityElement)
        '</Snippet3>

        Return signatureDescription
    End Function

    ' Create a signature formatter for DSA encryption.
    Private Function CreateDSAFormatter(ByVal dsa As DSA) _
        As AsymmetricSignatureFormatter

        ' Create a DSA signature formatter for encryption.
        '<Snippet5>
        Dim signatureDescription As New SignatureDescription
        signatureDescription.FormatterAlgorithm = _
            "System.Security.Cryptography.DSASignatureFormatter"

        Dim asymmetricFormatter As AsymmetricSignatureFormatter
        asymmetricFormatter = signatureDescription.CreateFormatter(dsa)
        '</Snippet5>

        WriteLine("Created formatter : " + asymmetricFormatter.ToString())
        Return asymmetricFormatter
    End Function

    ' Create a signature deformatter for DSA decryption.
    Private Function CreateDSADeformatter(ByVal dsa As DSA) _
        As AsymmetricSignatureDeformatter

        ' Create a DSA signature deformatter to verify the signature.
        '<Snippet4>
        Dim signatureDescription As New SignatureDescription
        signatureDescription.DeformatterAlgorithm = _
            "System.Security.Cryptography.DSASignatureDeformatter"

        Dim asymmetricDeformatter As AsymmetricSignatureDeformatter
        asymmetricDeformatter = SignatureDescription.CreateDeformatter(dsa)
        '</Snippet4>

        WriteLine("Created deformatter : " + asymmetricDeformatter.ToString())
        Return asymmetricDeformatter
    End Function

    ' Display to the console the properties of the specified
    ' SignatureDescription.
    Private Sub ShowProperties(ByVal signatureDescription _
        As SignatureDescription)

        ' Retrieve the class path for the specified SignatureDescription.
        '<Snippet11>
        Dim classDescription As String = signatureDescription.ToString()
        '</Snippet11>

        Dim deformatterAlgorithm As String 
        deformatterAlgorithm = signatureDescription.DeformatterAlgorithm
        Dim formatterAlgorithm As String 
        formatterAlgorithm = signatureDescription.FormatterAlgorithm
        Dim digestAlgorithm As String 
        digestAlgorithm = signatureDescription.DigestAlgorithm
        Dim keyAlgorithm As String 
        keyAlgorithm = signatureDescription.KeyAlgorithm

        WriteLine(vbCrLf + "** " + classDescription + " **")
        WriteLine("DeformatterAlgorithm : " + deformatterAlgorithm)
        WriteLine("FormatterAlgorithm : " + formatterAlgorithm)
        WriteLine("DigestAlgorithm : " + digestAlgorithm)
        WriteLine("KeyAlgorithm : " + keyAlgorithm)
    End Sub

    ' Write the specified message and carriage return to the output textbox.
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
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", _
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
        Me.Text = "SignatureDescription"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
'
' ** System.Security.Cryptography.SignatureDescription **
' DeformatterAlgorithm : System.Security.Cryptography.
' RSAPKCS1SignatureDeformatter
' FormatterAlgorithm : System.Security.Cryptography.RSAPKCS1SignatureFormatter
' DigestAlgorithm : System.Security.Cryptography.SHA1CryptoServiceProvider
' KeyAlgorithm : System.Security.Cryptography.RSACryptoServiceProvider
' 
' ** System.Security.Cryptography.SignatureDescription **
' DeformatterAlgorithm : System.Security.Cryptography.DSASignatureDeformatter
' FormatterAlgorithm : System.Security.Cryptography.DSASignatureFormatter
' DigestAlgorithm : System.Security.Cryptography.SHA1CryptoServiceProvider
' KeyAlgorithm : System.Security.Cryptography.DSACryptoServiceProvider
' Hash algorithm for the DigestAlgorithm property: System.Security.
' Cryptography.
' SHA1CryptoServiceProvider
' Created formatter : System.Security.Cryptography.DSASignatureFormatter
' Created deformatter : System.Security.Cryptography.DSASignatureDeformatter
' This sample completed successfully; press Exit to continue.
'</Snippet2>