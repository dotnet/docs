' This sample demonstrates how to derive from the MaskGenerationMethod class.
'<Snippet1>
Imports System
Imports System.Security.Cryptography

'<Snippet2>
Public Class MaskGenerator
    Inherits System.Security.Cryptography.MaskGenerationMethod

    Private HashNameValue As String

    ' Initialize a mask to encrypt using the SHA1 algorithm.
    Public Sub New()
        HashNameValue = "SHA1"
    End Sub
    '</Snippet2>

    ' Create a mask with the specified seed.
    '<Snippet3>
    Public Overrides Function GenerateMask( _
        ByVal seed() As Byte, _
        ByVal maskLength As Integer) As Byte()

        Dim hash As HashAlgorithm
        Dim rgbCounter(4) As Byte
        Dim targetRgb(maskLength) As Byte
        Dim counter As Integer

        For inc As Int16 = 0 To targetRgb.Length
            ConvertIntToByteArray(counter + 1, rgbCounter)
            hash = CType( _
                CryptoConfig.CreateFromName(HashNameValue), _
                HashAlgorithm)
            Dim temp(4 + seed.Length) As Byte
            Buffer.BlockCopy(rgbCounter, 0, temp, 0, 4)
            Buffer.BlockCopy(seed, 0, temp, 4, seed.Length)
            hash.ComputeHash(temp)

            If (targetRgb.Length - inc > hash.HashSize / 8) Then
                Buffer.BlockCopy( _
                    hash.Hash, 0, targetRgb, inc, hash.Hash.Length)
            Else
                Buffer.BlockCopy( _
                    hash.Hash, 0, targetRgb, inc, targetRgb.Length - inc)
            End If

            inc += hash.Hash.Length
        Next

        Return targetRgb
    End Function
    '</Snippet3>

    ' Convert the specified integer to the byte array.
    Private Sub ConvertIntToByteArray( _
        ByVal sourceInt As Integer, _
        ByRef targetBytes() As Byte)
        Dim remainder As Integer
        Dim inc As Int16 = 0

        ' Clear the array prior to filling it.
        Array.Clear(targetBytes, 0, targetBytes.Length)

        While (sourceInt > 0)
            remainder = sourceInt Mod 256
            targetBytes(3 - inc) = CType(remainder, Byte)
            sourceInt = (sourceInt - remainder) / 256
            inc = inc + 1
        End While
    End Sub
End Class

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim seed() As Byte = {&H1, &H2, &H3, &H4}
        Dim length As Int16 = 16
        Dim maskGenerator As New MaskGenerator
        Dim mask() As Byte = maskGenerator.GenerateMask(seed, length)

        tbxOutput.AppendText("Generated the following mask:")
        tbxOutput.AppendText(System.Text.Encoding.ASCII.GetString(mask))

        ' Align interface and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed" + _
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
        Me.Text = "MaskGenerationMethod"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' Generated the following mask:~&*(uj98U(*UD989D
' This sample completedsuccessfully; press Exit to continue.
'</Snippet1>