Imports System
Imports System.Windows.Forms
Imports System.Drawing


Public Class Form1
    Inherits Form

    '<snippet10>
    Dim PictureBox1 As New PictureBox()
    Dim WithEvents Button1 As New Button

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    Private Sub InitializePictureBoxAndButton()

        Me.Controls.Add(PictureBox1)
        Me.Controls.Add(Button1)
        Button1.Location = New Point(175, 20)
        Button1.Text = "Stretch"

        ' Set the size of the PictureBox control.
        Me.PictureBox1.Size = New System.Drawing.Size(140, 140)

        'Set the SizeMode to center the image.
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage

        ' Set the border style to a three-dimensional border.
        Me.PictureBox1.BorderStyle = BorderStyle.Fixed3D

        ' Set the image property.
        Me.PictureBox1.Image = New Bitmap(GetType(Button), "Button.bmp")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        ' Set the SizeMode property to the StretchImage value.  This
        ' will enlarge the image as needed to fit into
        ' the PictureBox.
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
    '</snippet10>


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializePictureBoxAndButton()
    End Sub
End Class
