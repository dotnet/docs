
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


'/ <summary>
'/ Summary description for Form1.
'/ </summary>

Public Class Form1
    Inherits System.Windows.Forms.Form
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing
   
   
    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
    End Sub
   
    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If fnt IsNot Nothing Then
                fnt.Dispose()
            End If
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose


    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(376, 334)
        Me.Name = "Form1"
        Me.Text = "Form1"
    End Sub 'InitializeComponent

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main

    '<Snippet1>
    ' This example creates a PictureBox control on the form and draws to it. 
    ' This example assumes that the Form_Load event handler method is connected 
    ' to the Load event of the form.
    Private pictureBox1 As New PictureBox()
    Private fnt as New Font("Arial", 10)

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Dock the PictureBox to the form and set its background to white.
        pictureBox1.Dock = DockStyle.Fill
        pictureBox1.BackColor = Color.White
        ' Connect the Paint event of the PictureBox to the event handler method.
        AddHandler pictureBox1.Paint, AddressOf Me.pictureBox1_Paint

        ' Add the PictureBox control to the Form.
        Me.Controls.Add(pictureBox1)
    End Sub 'Form1_Load


    Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Create a local version of the graphics object for the PictureBox.
        Dim g As Graphics = e.Graphics

        ' Draw a string on the PictureBox.
        g.DrawString("This is a diagonal line drawn on the control", _
            fnt, Brushes.Red, New PointF(30.0F, 30.0F))
        ' Draw a line in the PictureBox.
        g.DrawLine(System.Drawing.Pens.Red, pictureBox1.Left, _ 
            pictureBox1.Top, pictureBox1.Right, pictureBox1.Bottom)
    End Sub 'pictureBox1_Paint
    '</Snippet1>
End Class 'Form1
