
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
    Private WithEvents listBox1 As System.Windows.Forms.ListBox
    Private textBox1 As System.Windows.Forms.TextBox
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing
   
    
    Public Sub New()
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
    End Sub 'New
    

    Private Sub InitializeComponent()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        ' 
        ' listBox1
        ' 
        Me.listBox1.Items.AddRange(New Object() {"C:\Windows\Windows Update.log"})
        Me.listBox1.Location = New System.Drawing.Point(32, 24)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(200, 108)
        Me.listBox1.TabIndex = 0
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(32, 144)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textBox1.Size = New System.Drawing.Size(448, 240)
        Me.textBox1.TabIndex = 1
        Me.textBox1.Text = "textBox1"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(520, 446)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.listBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub 'InitializeComponent

   
    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main



    '<Snippet1>
    ' This example uses the DoubleClick event of a ListBox to load text files  
    ' listed in the ListBox into a TextBox control. This example
    ' assumes that the ListBox, named listBox1, contains a list of valid file 
    ' names with path and that this event handler method
    ' is connected to the DoublClick event of a ListBox control named listBox1.
    ' This example requires code access permission to access files.
    Private Sub listBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.DoubleClick
        ' Get the name of the file to open from the ListBox.
        Dim file As [String] = listBox1.SelectedItem.ToString()

        Try
            ' Determine if the file exists before loading.
            If System.IO.File.Exists(file) Then
                ' Open the file and use a TextReader to read the contents into the TextBox.
                Dim myFile As New System.IO.FileInfo(listBox1.SelectedItem.ToString())
                Dim myData As System.IO.TextReader = myFile.OpenText()

                textBox1.Text = myData.ReadToEnd()
                myData.Close()
            End If
            ' Exception is thrown by the OpenText method of the FileInfo class.
        Catch
            MessageBox.Show("The file you specified does not exist.")
            ' Exception is thrown by the ReadToEnd method of the TextReader class.
        Catch
         MessageBox.Show("There was a problem loading the file into the TextBox. Ensure that the file is a valid text file.")
        End Try
    End Sub
    '</Snippet1>
End Class 'Form1 