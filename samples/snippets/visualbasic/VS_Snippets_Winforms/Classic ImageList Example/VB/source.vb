'<snippet1>
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private listBox1 As System.Windows.Forms.ListBox
    Private label3 As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
    Private pictureBox1 As System.Windows.Forms.PictureBox
    Private imageList1 As System.Windows.Forms.ImageList
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Protected myGraphics As Graphics
    Private panel1 As System.Windows.Forms.Panel
    Private label5 As System.Windows.Forms.Label
    Private currentImage As Integer = 0

    Public Sub New()
        imageList1 = New ImageList()

        InitializeComponent()
        ' The default image size is 16 x 16, which sets up a larger
        ' image size. 
        imageList1.ImageSize = New Size(255, 255)
        imageList1.TransparentColor = Color.White

        ' Assigns the graphics object to use in the draw options.
        myGraphics = Graphics.FromHwnd(panel1.Handle)

    End Sub 'New

    Private Sub InitializeComponent()

        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.button4 = New System.Windows.Forms.Button()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()

        Me.listBox1.Location = New System.Drawing.Point(16, 16)
        Me.listBox1.Size = New System.Drawing.Size(400, 95)
        Me.listBox1.TabIndex = 0

        Me.label3.Location = New System.Drawing.Point(24, 168)
        Me.label3.Text = "label3"

        Me.button1.Location = New System.Drawing.Point(96, 128)
        Me.button1.Size = New System.Drawing.Size(104, 23)
        Me.button1.Text = "Show Next Image"

        Me.button2.Location = New System.Drawing.Point(208, 128)
        Me.button2.Size = New System.Drawing.Size(104, 23)
        Me.button2.Text = "Remove Image"

        Me.button3.Location = New System.Drawing.Point(320, 128)
        Me.button3.Text = "Clear List"

        Me.button4.Location = New System.Drawing.Point(16, 128)
        Me.button4.Text = "Open Image"

        Me.pictureBox1.Location = New System.Drawing.Point(328, 232)
        Me.pictureBox1.Size = New System.Drawing.Size(336, 192)

        Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent

        Me.panel1.Location = New System.Drawing.Point(8, 240)
        Me.panel1.Size = New System.Drawing.Size(296, 184)

        Me.label5.Location = New System.Drawing.Point(168, 168)
        Me.label5.Size = New System.Drawing.Size(312, 40)
        Me.label5.Text = "label5"

        Me.ClientSize = New System.Drawing.Size(672, 461)
        Me.Controls.Add(label5)
        Me.Controls.Add(panel1)
        Me.Controls.Add(pictureBox1)
        Me.Controls.Add(button4)
        Me.Controls.Add(button3)
        Me.Controls.Add(button2)
        Me.Controls.Add(button1)
        Me.Controls.Add(label3)
        Me.Controls.Add(listBox1)
        Me.ResumeLayout(False)
    End Sub

    ' Display the image.
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles button1.Click

        If imageList1.Images.Empty <> True Then
            If imageList1.Images.Count - 1 > currentImage Then
                currentImage += 1
            Else
                currentImage = 0
            End If
            panel1.Refresh()

            ' Draw the image in the panel.
            imageList1.Draw(myGraphics, 10, 10, currentImage)

            ' Show the image in the PictureBox.
            pictureBox1.Image = imageList1.Images(currentImage)
            label3.Text = "Current image is " + currentImage.ToString
            listBox1.SelectedIndex = currentImage
            label5.Text = "Image is " + listBox1.Text
        End If
    End Sub

    ' Remove the image.
    Private Sub button2_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles button2.Click

        imageList1.Images.RemoveAt(listBox1.SelectedIndex)
        listBox1.Items.Remove(listBox1.SelectedItem)
    End Sub

    ' Clear all images.
    Private Sub button3_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles button3.Click
        imageList1.Images.Clear()
        listBox1.Items.Clear()
    End Sub

    ' Find an image.
    Private Sub button4_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles button4.Click

        openFileDialog1.Multiselect = True
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            If (openFileDialog1.FileNames IsNot Nothing) Then
                Dim i As Integer
                For i = 0 To openFileDialog1.FileNames.Length - 1
                    addImage(openFileDialog1.FileNames(i))
                Next i
            Else
                addImage(openFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub addImage(ByVal imageToLoad As String)
        If imageToLoad <> "" Then
            imageList1.Images.Add(Image.FromFile(imageToLoad))
            listBox1.BeginUpdate()
            listBox1.Items.Add(imageToLoad)
            listBox1.EndUpdate()
        End If
    End Sub

    <StaThread()> _
    Public Shared Sub Main(ByVal args() As String)
        Application.Run(New Form1())
    End Sub
End Class
'</snippet1>