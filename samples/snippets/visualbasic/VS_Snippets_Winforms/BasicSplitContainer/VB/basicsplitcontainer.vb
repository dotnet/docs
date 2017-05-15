' <snippet1>
' Compile this example using the following command line:
' vbc basicsplitcontainer.vb /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.dll /r:System.Data.dll
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private treeView1 As System.Windows.Forms.TreeView
    Private splitContainer2 As System.Windows.Forms.SplitContainer
    Private listView2 As System.Windows.Forms.ListView
    Private listView1 As System.Windows.Forms.ListView
   
    Public Sub New()
        InitializeComponent()
    End Sub 'New
       
    Private Sub InitializeComponent()
        splitContainer1 = New System.Windows.Forms.SplitContainer()
        treeView1 = New System.Windows.Forms.TreeView()
        splitContainer2 = New System.Windows.Forms.SplitContainer()
        listView1 = New System.Windows.Forms.ListView()
        listView2 = New System.Windows.Forms.ListView()
        splitContainer1.SuspendLayout()
        splitContainer2.SuspendLayout()
        SuspendLayout()
        ' <snippet2>
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
          
        ' Add a TreeView control to the left panel.
        splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        ' Add a TreeView control to Panel1.
        splitContainer1.Panel1.Controls.Add(treeView1)
        splitContainer1.Panel1.Name = "splitterPanel1"
        ' Controls placed on Panel1 support right-to-left fonts.
        splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        ' </snippet2>

        ' Add a SplitContainer to the right panel.
        splitContainer1.Panel2.Controls.Add(splitContainer2)
        splitContainer1.Panel2.Name = "splitterPanel2"
          
        ' This TreeView control is in Panel1 of splitContainer1.
        treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        treeView1.ForeColor = System.Drawing.SystemColors.InfoText
        treeView1.ImageIndex = - 1
        treeView1.Location = New System.Drawing.Point(0, 0)
        treeView1.Name = "treeView1"
        treeView1.SelectedImageIndex = - 1
        treeView1.Size = New System.Drawing.Size(79, 273)
        ' treeView1 is the second control in the tab order.
        treeView1.TabIndex = 1
          
        ' <snippet3>
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
        splitContainer2.TabIndex = 2
        splitContainer2.Text = "splitContainer2"
        ' </snippet3> 

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
        ' listView1 is the fourth control in the tab order.
        listView1.TabIndex = 3
          
        ' This ListView control is in the bottom panel of splitContainer2.
        listView2.Dock = System.Windows.Forms.DockStyle.Fill
        listView2.Location = New System.Drawing.Point(0, 0)
        listView2.Name = "listView2"
        listView2.Size = New System.Drawing.Size(207, 142)
        ' listView2 is the fifth control in the tab order.
        listView2.TabIndex = 4
          
        ' These are basic properties of the form.
        ClientSize = New System.Drawing.Size(292, 273)
        Controls.Add(splitContainer1)
        Name = "Form1"
        Text = "Form1"
        splitContainer1.ResumeLayout(False)
        splitContainer2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub 'InitializeComponent
       
       
<STAThread()>  _
Shared Sub Main()
    Application.Run(New Form1())
End Sub 'Main
    
Private Sub splitContainer1_SplitterMoving(sender As System.Object, e As System.Windows.Forms.SplitterCancelEventArgs) Handles splitContainer1.SplitterMoving
    ' As the splitter moves, change the cursor type.
    Cursor.Current = System.Windows.Forms.Cursors.NoMoveVert
End Sub 'splitContainer1_SplitterMoving
    
Private Sub splitContainer1_SplitterMoved(sender As System.Object, e As System.Windows.Forms.SplitterEventArgs) Handles splitContainer1.SplitterMoved
    ' When the splitter stops moving, change the cursor back to the default.
    Cursor.Current = System.Windows.Forms.Cursors.Default
End Sub 'splitContainer1_SplitterMoved
End Class 'Form1
' </snippet1>