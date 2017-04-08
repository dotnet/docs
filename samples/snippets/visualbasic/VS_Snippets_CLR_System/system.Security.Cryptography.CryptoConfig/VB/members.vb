' This sample demonstrates how to use each member of the CryptoConfig class.
'<Snippet1>
Imports System
Imports System.Security.Cryptography

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        ' Create a CryptoConfig object to store configuration information.
        '<Snippet2>
        Dim cryptoConfig As New CryptoConfig
        '</Snippet2>

        ' Retrieve the class path for CryptoConfig.
        '<Snippet7>
        Dim classDescription As String = cryptoConfig.ToString()
        '</Snippet7>

        ' Create a new SHA1 provider.
        '<Snippet4>
        Dim SHA1alg As SHA1CryptoServiceProvider
        SHA1alg = CType( _
            cryptoConfig.CreateFromName("SHA1"), SHA1CryptoServiceProvider)
        '</Snippet4>

        ' Create an RSAParameters with the TestContainer key container.
        '<Snippet5>
        Dim parameters As New CspParameters
        parameters.KeyContainerName = "TestContainer"
        Dim argsArray() = New Object() {parameters}

        ' Instantiate the RSA provider instance accessing the key container
        '  TestContainer.
        Dim rsaProvider As New RSACryptoServiceProvider
        rsaProvider = CType(cryptoConfig.CreateFromName( _
            "RSA", argsArray), _
            RSACryptoServiceProvider)
        '</Snippet5>

        ' Use the MapNameToOID method to get an object identifier.
        '<Snippet3>
        ' (OID) from the string name of the SHA1 algorithm.
        Dim sha1Oid As String = cryptoConfig.MapNameToOID("SHA1")
        '</Snippet3>

        ' Encode the specified object identifier.
        '<Snippet6>
        Dim encodedMessage() As Byte = cryptoConfig.EncodeOID(sha1Oid)
        '</Snippet6>

        ' Display the results to the console.
        tbxOutput.AppendText("** " + classDescription + " **" + vbCrLf)
        tbxOutput.AppendText("Created an RSA provider with a ")
        tbxOutput.AppendText("KeyContainerName called ")
        tbxOutput.AppendText(parameters.KeyContainerName + "." + vbCrLf)
        tbxOutput.AppendText("Object identifier from the SHA1 name:")
        tbxOutput.AppendText(sha1Oid + vbCrLf)
        tbxOutput.AppendText("The object identifier encoded: ")
        tbxOutput.AppendText( _
            System.Text.Encoding.ASCII.GetString(encodedMessage))

        ' Reset the cursor and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")
        tbxOutput.Cursor = Cursors.Default
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
            "Microsoft Sans Serif", 9.0!, _
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
        Me.Text = "CryptoConfig"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' ** System.Security.Cryptography.CryptoConfig **
' Created an RSA provider with a KeyContainerName called TestContainer.
' Object identifier from the SHA1 name:1.3.14.3.2.26
' The object identifier encoded: 6767gG&*(*
' This sample completed successfully; press Exit to continue.
'</Snippet1>