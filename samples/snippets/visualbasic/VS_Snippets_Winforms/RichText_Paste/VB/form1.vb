Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        PasteMyBitmap("c:\\NoImage.bmp")

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(96, 80)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = "RichTextBox1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.RichTextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    '<snippet1>
    Private Function PasteMyBitmap(ByVal Filename As String) As Boolean

        'Open an bitmap from file and copy it to the clipboard.
        Dim MyBitmap As Bitmap
        MyBitmap = Bitmap.FromFile(Filename)

        ' Copy the bitmap to the clipboard.
        Clipboard.SetDataObject(MyBitmap)

        ' Get the format for the object type.
        Dim MyFormat As DataFormats.Format = DataFormats.GetFormat(DataFormats.Bitmap)

        ' After verifying that the data can be pasted, paste it.
        If RichTextBox1.CanPaste(MyFormat) Then

            RichTextBox1.Paste(MyFormat)
            PasteMyBitmap = True

        Else

            MessageBox.Show("The data format that you attempted to paste is not supported by this control.")
            PasteMyBitmap = False

        End If


    End Function
    '</snippet1>

#End Region

Public Shared Sub Main()
   Application.Run(New Form1())
End Sub

End Class
