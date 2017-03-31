Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeHelpProvider()

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TextBox1 = New System.Windows.Forms.TextBox


        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "Press F1 for help."

        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(160, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)

        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '<snippet1>

    'Declare the HelpProvider.
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider


    Private Sub InitializeHelpProvider()

        ' Construct the HelpProvider Object.
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider

        ' Set the HelpNamespace property to the Help file for 
        ' HelpProvider1.
        Me.HelpProvider1.HelpNamespace = "c:\windows\input.chm"

        ' Specify that the Help provider should open to the table
        ' of contents of the Help file.
        Me.HelpProvider1.SetHelpNavigator(TextBox1, _
            HelpNavigator.TableOfContents)

    End Sub
    '</snippet1>

    '<snippet2>
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

    ' Create an ImageList Object, populate it, and display
    ' the images it contains.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Construct the ImageList.
        ImageList1 = New ImageList

        ' Set the ImageSize property to a larger size 
        ' (the default is 16 x 16).
        ImageList1.ImageSize = New Size(112, 112)

        ' Add two images to the list.
        ImageList1.Images.Add(Image.FromFile _
            ("c:\windows\FeatherTexture.bmp"))
        ImageList1.Images.Add _
            (Image.FromFile("C:\windows\Gone Fishing.bmp"))

        Dim count As System.Int32

        ' Get a Graphics object from the form's handle.
        Dim theGraphics As Graphics = Graphics.FromHwnd(Me.Handle)

        ' Loop through the images in the list, drawing each image.
        For count = 0 To ImageList1.Images.Count - 1
            ImageList1.Draw(theGraphics, New Point(85, 85), count)

            ' Call Application.DoEvents to force a repaint of the form.
            Application.DoEvents()

            ' Call the Sleep method to allow the user to see the image.
            System.Threading.Thread.Sleep(1000)
        Next
    End Sub

    '</snippet2>

    <System.STAThread()> _
   Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub
End Class
