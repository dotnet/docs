
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Private WithEvents button1 As Button
    Private imageList1 As ImageList
    Private components As IContainer
    
    
    Public Sub New() 
        InitializeComponent()
        InitializeRadioButtons()

    
    End Sub 'New
    
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click
        AddStripToCollection()

    End Sub
    
    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    '<snippet2>
    Private groupBox1 As GroupBox
    Private radioButton2 As RadioButton
    Private radioButton1 As RadioButton
    Private selectedrb As RadioButton
    Private WithEvents getSelectedRB As Button

    Public Sub InitializeRadioButtons()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioButton2 = New System.Windows.Forms.RadioButton()
        Me.radioButton1 = New System.Windows.Forms.RadioButton()
        Me.getSelectedRB = New System.Windows.Forms.Button()

        Me.groupBox1.Controls.Add(Me.radioButton2)
        Me.groupBox1.Controls.Add(Me.radioButton1)
        Me.groupBox1.Controls.Add(Me.getSelectedRB)
        Me.groupBox1.Location = New System.Drawing.Point(30, 100)
        Me.groupBox1.Size = New System.Drawing.Size(220, 125)
        Me.groupBox1.Text = "Radio Buttons"

        Me.radioButton2.Location = New System.Drawing.Point(31, 53)
        Me.radioButton2.Size = New System.Drawing.Size(67, 17)
        Me.radioButton2.Text = "Choice 2"
        AddHandler Me.radioButton2.Click, AddressOf radioButton_CheckedChanged

        Me.radioButton1.Location = New System.Drawing.Point(31, 20)
        Me.radioButton1.Name = "radioButton1"
        Me.radioButton1.Size = New System.Drawing.Size(67, 17)
        Me.radioButton1.Text = "Choice 1"
        AddHandler Me.radioButton1.Click, AddressOf radioButton_CheckedChanged

        Me.getSelectedRB.Location = New System.Drawing.Point(10, 75)
        Me.getSelectedRB.Size = New System.Drawing.Size(200, 25)
        Me.getSelectedRB.Text = "Get selected RadioButton"

        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.groupBox1)
    End Sub

    Private Sub radioButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _

        Dim rb As RadioButton = TryCast(sender, RadioButton)

        If rb Is Nothing Then
            MessageBox.Show("Sender is not a RadioButton")
            Return
        End If

        ' Ensure that the RadioButton.Checked property
        ' changed to true.
        If rb.Checked Then
            ' Keep track of the selected RadioButton by saving a reference
            ' to it.
            selectedrb = rb
        End If
    End Sub

    ' Show the text of the selected RadioButton.
    Private Sub getSelectedRB_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles getSelectedRB.Click

        MessageBox.Show(selectedrb.Text)
    End Sub
    '</snippet2>

    Private WithEvents printDocument1 As System.Drawing.Printing.PrintDocument
    '<snippet3>
    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)  Handles printDocument1.PrintPage
        If e.PageSettings.Color AndAlso Not printDocument1.PrinterSettings.SupportsColor Then
            MessageBox.Show("Color printing not supported on selected printer.", "Printer Warning", MessageBoxButtons.OKCancel)
        End If
    
    End Sub
    '</snippet3>


    '<snippet6>
    Private numericUpDown1 As NumericUpDown
    
    Private Sub InitializeAcceleratedUpDown() 
        numericUpDown1 = New NumericUpDown()
        numericUpDown1.Location = New Point(40, 40)
        numericUpDown1.Maximum = 40000
        numericUpDown1.Minimum = - 40000
        
        ' Add some accelerations to the control.
        numericUpDown1.Accelerations.Add(New NumericUpDownAcceleration(2, 100))
        numericUpDown1.Accelerations.Add(New NumericUpDownAcceleration(5, 1000))
        numericUpDown1.Accelerations.Add(New NumericUpDownAcceleration(8, 5000))
        Controls.Add(numericUpDown1)
    
    End Sub
     
    '</snippet6>

    'Per VSWhidbey 370432 Demonstrates the ImageListCollection.AddStrip method.
    '<snippet1>
    Private Sub AddStripToCollection() 
        ' Add the image strip.
        Dim bitmaps As New Bitmap(GetType(PrintPreviewDialog), "PrintPreviewStrip.bmp")
        imageList1.Images.AddStrip(bitmaps)
        
        ' Iterate through the images and display them on the form.
        Dim i As Integer
        For i = 0 To imageList1.Images.Count
            
            imageList1.Draw(Me.CreateGraphics(), New Point(10, 10), i)
            Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
        Next i
     
    End Sub
    
    
    
    '</snippet1>
    Private Sub InitializeComponent() 
        Me.components = New System.ComponentModel.Container()
        Me.button1 = New System.Windows.Forms.Button()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        ' 
        ' button1
        ' 
        Me.button1.Location = New System.Drawing.Point(148, 25)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 0
        Me.button1.Text = "button1"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(button1)
        Me.Name = "Form1"
        Me.ResumeLayout(False)
    
    End Sub
End Class

