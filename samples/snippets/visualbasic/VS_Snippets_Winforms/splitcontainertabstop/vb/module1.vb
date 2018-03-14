
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Module Module1

    Private Sub Main()
        Application.Run(New Form1())
    End Sub

Public Class Form1
    Inherits System.Windows.Forms.Form
    ' use MySplitContainer to replicate 3.5 behavior 
    'private MySplitContainer splitContainer2; 
    Private splitContainer2 As SplitContainer

    Private splitContainer1 As System.Windows.Forms.SplitContainer
    Private treeView1 As System.Windows.Forms.TreeView
    Private listView2 As System.Windows.Forms.ListView
    Private listView1 As System.Windows.Forms.ListView

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub InitializeComponent()
        splitContainer1 = New System.Windows.Forms.SplitContainer()
        treeView1 = New System.Windows.Forms.TreeView()
        splitContainer2 = New MySplitContainer()
        listView1 = New System.Windows.Forms.ListView()
        listView2 = New System.Windows.Forms.ListView()
        splitContainer1.SuspendLayout()
        splitContainer2.SuspendLayout()
        SuspendLayout()

        ' Basic SplitContainer properties. 
        ' This is a vertical splitter that moves in 10-pixel increments. 
        ' This splitter needs no explicit Orientation property because Vertical is the default. 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        splitContainer1.ForeColor = System.Drawing.SystemColors.Control
        splitContainer1.Location = New System.Drawing.Point(0, 0)
        splitContainer1.Name = "splitContainer1"

        ' You can drag the splitter no nearer than 30 pixels from the left edge of the container. 
        splitContainer1.Panel1MinSize = 30

        ' You can drag the splitter no nearer than 20 pixels from the right edge of the container. 
        splitContainer1.Panel2MinSize = 20
        splitContainer1.Size = New System.Drawing.Size(292, 273)
        splitContainer1.SplitterDistance = 79

        ' This splitter moves in 10-pixel increments. 
        splitContainer1.SplitterIncrement = 10
        splitContainer1.SplitterWidth = 6

        ' splitContainer1 is the first control in the tab order. 
        splitContainer1.TabIndex = 0
        splitContainer1.Text = "splitContainer1"

        ' When the splitter moves, the cursor changes shape. 
        AddHandler splitContainer1.SplitterMoved, AddressOf splitContainer1_SplitterMoved
        AddHandler splitContainer1.SplitterMoving, AddressOf splitContainer1_SplitterMoving

        ' Add a TreeView control to the left panel. 
        splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control

        ' Add a TreeView control to Panel1. 
        splitContainer1.Panel1.Controls.Add(treeView1)
        splitContainer1.Panel1.Name = "splitterPanel1"

        ' Controls placed on Panel1 support right-to-left fonts. 
        splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes


        ' Add a SplitContainer to the right panel. 
        splitContainer1.Panel2.Controls.Add(splitContainer2)
        splitContainer1.Panel2.Name = "splitterPanel2"

        ' This TreeView control is in Panel1 of splitContainer1. 
        treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        treeView1.ForeColor = System.Drawing.SystemColors.InfoText
        treeView1.ImageIndex = -1
        treeView1.Location = New System.Drawing.Point(0, 0)
        treeView1.Name = "treeView1"
        treeView1.SelectedImageIndex = -1
        treeView1.Size = New System.Drawing.Size(79, 273)

        treeView1.BeginUpdate()
        treeView1.Nodes.Add("Parent")
        treeView1.Nodes(0).Nodes.Add("Child 1")
        treeView1.Nodes(0).Nodes.Add("Child 2")
        treeView1.Nodes(0).Nodes(1).Nodes.Add("Grandchild")
        treeView1.Nodes(0).Nodes(1).Nodes(0).Nodes.Add("Great Grandchild")
        treeView1.EndUpdate()

        ' treeView1 is the second control in the tab order. 
        treeView1.TabIndex = 1

        ' Basic SplitContainer properties. 
        ' This is a horizontal splitter whose top and bottom panels are ListView controls. The top panel is fixed. 
        splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill

        ' The top panel remains the same size when the form is resized. 
        splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        splitContainer2.Location = New System.Drawing.Point(0, 0)
        splitContainer2.Name = "splitContainer2"

        ' Create the horizontal splitter. 
        splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        splitContainer2.Size = New System.Drawing.Size(207, 273)
        splitContainer2.SplitterDistance = 125
        splitContainer2.SplitterWidth = 6

        ' splitContainer2 is the third control in the tab order. 
        'splitContainer2.TabIndex = 2; 
        splitContainer2.TabStop = False
        splitContainer2.Text = "splitContainer2"

        ' This splitter panel contains the top ListView control. 
        splitContainer2.Panel1.Controls.Add(listView1)
        splitContainer2.Panel1.Name = "splitterPanel3"

        ' This splitter panel contains the bottom ListView control. 
        splitContainer2.Panel2.Controls.Add(listView2)
        splitContainer2.Panel2.Name = "splitterPanel4"

        ' This ListView control is in the top panel of splitContainer2. 
        listView1.Dock = System.Windows.Forms.DockStyle.Fill
        listView1.Location = New System.Drawing.Point(0, 0)
        listView1.Name = "listView1"
        listView1.Size = New System.Drawing.Size(207, 125)
        listView1.View = View.Details

        ' Display grid lines. 
        listView1.GridLines = True


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

        ' listView1 is the fourth control in the tab order. 
        listView1.TabIndex = 3

        ' This ListView control is in the bottom panel of splitContainer2. 
        listView2.Dock = System.Windows.Forms.DockStyle.Fill
        listView2.Location = New System.Drawing.Point(0, 0)
        listView2.Name = "listView2"
        listView2.Size = New System.Drawing.Size(207, 142)
        listView2.View = View.Details

        ' Display grid lines. 
        listView2.GridLines = True


        ' Create three items and three sets of subitems for each item. 
        item1 = New ListViewItem("item1", 0)
        ' Place a check mark next to the item. 
        item1.Checked = True
        item1.SubItems.Add("1")
        item1.SubItems.Add("2")
        item1.SubItems.Add("3")
        item2 = New ListViewItem("item2", 1)
        item2.SubItems.Add("4")
        item2.SubItems.Add("5")
        item2.SubItems.Add("6")

        item3 = New ListViewItem("item3", 0)
        ' Place a check mark next to the item. 
        item3.Checked = True
        item3.SubItems.Add("7")
        item3.SubItems.Add("8")
        item3.SubItems.Add("9")

        ' Create columns for the items and subitems. 
        ' Width of -2 indicates auto-size. 
        listView2.Columns.Add("Item Column", -2, HorizontalAlignment.Left)
        listView2.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        listView2.Columns.Add("Column 3", -2, HorizontalAlignment.Left)
        listView2.Columns.Add("Column 4", -2, HorizontalAlignment.Center)

        'Add the items to the ListView. 
        listView2.Items.AddRange(New ListViewItem() {item1, item2, item3})

        ' listView2 is the fifth control in the tab order. 
        listView2.TabIndex = 4

        ' These are basic properties of the form. 
        'ClientSize = new System.Drawing.Size(292, 273); 
        Me.WindowState = FormWindowState.Maximized
        Controls.Add(splitContainer1)
        Name = "Form1"
        Text = "Form1"
        splitContainer1.ResumeLayout(False)
        splitContainer2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Private Sub splitContainer1_SplitterMoving(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterCancelEventArgs)
        ' As the splitter moves, change the cursor type. 
        Cursor.Current = System.Windows.Forms.Cursors.NoMoveVert
    End Sub
    Private Sub splitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs)
        ' When the splitter stops moving, change the cursor back to the default. 
        Cursor.Current = System.Windows.Forms.Cursors.[Default]
    End Sub
End Class

'<Snippet1> 
Public Class MySplitContainer
    Inherits SplitContainer
    Private m_tabStop As Boolean = True
    Public Shadows Property TabStop() As Boolean
        Get
            Return m_tabStop
        End Get
        Set(ByVal value As Boolean)
            If TabStop <> value Then
                m_tabStop = value
                OnTabStopChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Protected Overloads Overrides Function ProcessTabKey(ByVal forward As Boolean) As Boolean
        If Not m_tabStop Then
            If SelectNextControl(ActiveControl, forward, True, True, False) Then
                Return True
            End If
        End If
        Return MyBase.ProcessTabKey(forward)
    End Function
End Class
    '</Snippet1> 

End Module
