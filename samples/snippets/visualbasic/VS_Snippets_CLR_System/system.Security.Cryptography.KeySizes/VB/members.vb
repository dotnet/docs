' This sample demonstrates how to use each member of the KeySizes class.
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

        ' Initializes a new instance of the KeySizes class with the
        ' specified key values.
        '<Snippet2>
        Dim MinSize As Integer = 64
        Dim MaxSize As Integer = 1024
        Dim SkipSize As Integer = 64
        Dim keySizes As New KeySizes(MinSize, MaxSize, SkipSize)
        '</Snippet2>

        ' Show the values of the keys.
        ShowKeys(New KeySizes(0) {keySizes}, "Custom Keys")

        ' Create a new symmetric algorithm and display its key values.
        Dim rijn As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        WriteLine("rijn.blocksize:" + rijn.BlockSize.ToString())
        ShowKeys(rijn.LegalKeySizes, rijn.ToString())

        ' Create a new RSA algorithm and display its key values.
        Dim rsaCSP As New RSACryptoServiceProvider(384)
        WriteLine("RSACryptoServiceProvider KeySize = " + _
            rsaCSP.KeySize.ToString())
        ShowKeys(rsaCSP.LegalKeySizes, rsaCSP.ToString())

        ' Reset the cursor and conclude application.
        WriteLine("This sample completed successfully;" + _
            " press Exit to continue.")
        tbxOutput.Cursor = Cursors.Default
    End Sub

    ' Display specified KeySize properties to output textbox.
    Private Sub ShowKeys( _
        ByVal KeySizes() As KeySizes, _
        ByVal objectName As String)

        ' Retrieve the first KeySizes in the array.
        Dim firstKeySize As KeySizes = KeySizes(0)

        ' Retrieve the minimum key size in bits.
        '<Snippet3>
        Dim minKeySize As Integer = firstKeySize.MinSize
        '</Snippet3>

        ' Retrieve the maximum key size in bits.
        '<Snippet4>
        Dim maxKeySize As Integer = firstKeySize.MaxSize
        '</Snippet4>

        ' Retrieve the interval between valid key size in bits.
        '<Snippet5>
        Dim skipKeySize As Integer = firstKeySize.SkipSize
        '</Snippet5>

        WriteLine("KeySizes retrieved from the " + objectName + " object.")
        WriteLine("Minimum key size bits: " + minKeySize.ToString())
        WriteLine("Maximum key size bits: " + maxKeySize.ToString())
        WriteLine("Interval between key size bits: " + skipKeySize.ToString())
        WriteLine("")
    End Sub
    ' Display the message to the textbox with a carriage return and line feed.
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
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", _
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
        Me.Text = "KeySizes"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' KeySizes retrieved from the Custom Keys object.
' Minimum key size bits: 64
' Maximum key size bits: 1024
' Interval between key size bits: 64
' 
' rijn.blocksize:128
' KeySizes retrieved from the System.Security.Cryptography.RijndaelManaged
' object.
' Minimum key size bits: 128
' Maximum key size bits: 256
' Interval between key size bits: 64
' 
' RSACryptoServiceProvider KeySize = 384
' KeySizes retrieved from the
' System.Security.Cryptography.RSACryptoServiceProvider object.
' Minimum key size bits: 384
' Maximum key size bits: 16384
' Interval between key size bits: 8
' 
' This sample completed successfully; press Exit to continue.
'</Snippet1>