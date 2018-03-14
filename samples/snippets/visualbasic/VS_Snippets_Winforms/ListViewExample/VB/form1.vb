
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace ListViewExample
    _
   '/ <summary>
   '/ Summary description for Form1.
   '/ </summary>
   Public Class Form1
      Inherits System.Windows.Forms.Form
        Private WithEvents button1 As System.Windows.Forms.Button
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
       
      '
      ' TODO: Add any constructor code after InitializeComponent call
      '

      '
      'ToDo: Error processing original source shown below
      '
      '
      '-----^--- Pre-processor directives not translated
      '/ <summary>
      '
      'ToDo: Error processing original source shown below
      '
      '
      '--^--- Unexpected pre-processor directive
      '/ Required method for Designer support - do not modify
      '/ the contents of this method with the code editor.
      '/ </summary>
      Private Sub InitializeComponent()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(344, 360)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(104, 24)
         Me.button1.TabIndex = 0
         Me.button1.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(464, 397)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      '
      'ToDo: Error processing original source shown below
      '
      '
      '-----^--- Pre-processor directives not translated
      '
      'ToDo: Error processing original source shown below
      '
      '
      '--^--- Unexpected pre-processor directive
      '/ <summary>
      '/ The main entry point for the application.
      '/ </summary>
        <STAThread()> _
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub 'Main


        '<snippet1>
        Private Sub CreateMyListView()
            ' Create a new ListView control.
            Dim listView1 As New ListView()
            listView1.Bounds = New Rectangle(New Point(10, 10), New Size(300, 200))

            ' Set the view to show details.
            listView1.View = View.Details
            ' Allow the user to edit item text.
            listView1.LabelEdit = True
            ' Allow the user to rearrange columns.
            listView1.AllowColumnReorder = True
            ' Display check boxes.
            listView1.CheckBoxes = True
            ' Select the item and subitems when selection is made.
            listView1.FullRowSelect = True
            ' Display grid lines.
            listView1.GridLines = True
            ' Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending

            ' Create three items and three sets of subitems for each item.
            Dim item1 As New ListViewItem("item1", 0)
            ' Place a check mark next to the item.
            item1.Checked = True
            item1.SubItems.Add("1")
            item1.SubItems.Add("2")
            item1.SubItems.Add("3")
            Dim item2 As New ListViewItem("item2", 1)
            item2.SubItems.Add("4")
            item2.SubItems.Add("5")
            item2.SubItems.Add("6")
            Dim item3 As New ListViewItem("item3", 0)
            ' Place a check mark next to the item.
            item3.Checked = True
            item3.SubItems.Add("7")
            item3.SubItems.Add("8")
            item3.SubItems.Add("9")

            ' Create columns for the items and subitems.
            ' Width of -2 indicates auto-size.
            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left)
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left)
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center)

            'Add the items to the ListView.
            listView1.Items.AddRange(New ListViewItem() {item1, item2, item3})

            ' Create two ImageList objects.
            Dim imageListSmall As New ImageList()
            Dim imageListLarge As New ImageList()

            ' Initialize the ImageList objects with bitmaps.
            imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage1.bmp"))
            imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage2.bmp"))
            imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage1.bmp"))
            imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage2.bmp"))

            'Assign the ImageList objects to the ListView.
            listView1.LargeImageList = imageListLarge
            listView1.SmallImageList = imageListSmall

            ' Add the ListView to the control collection.
            Me.Controls.Add(listView1)
        End Sub 'CreateMyListView

        '</snippet1>
        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            CreateMyListView()
        End Sub 'button1_Click
    End Class 'Form1
End Namespace 'ListViewExample