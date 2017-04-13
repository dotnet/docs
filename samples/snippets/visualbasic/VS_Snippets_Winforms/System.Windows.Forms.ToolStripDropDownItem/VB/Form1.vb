 ' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private toolStrip1 As ToolStrip
   Private statusStrip1 As StatusStrip
   Private toolStripStatusLabel1 As ToolStripStatusLabel
   Private contextMenuStrip1 As ContextMenuStrip
   Private menuItem1ToolStripMenuItem As ToolStripMenuItem
   Private menuItem2ToolStripMenuItem As ToolStripMenuItem
   Private subItemToolStripMenuItem As ToolStripMenuItem
   Private subItem2ToolStripMenuItem As ToolStripMenuItem
   Private WithEvents showButton As Button
   Private WithEvents hideButton As Button
   Private components As System.ComponentModel.IContainer = Nothing
   
   
   Public Sub New()
      InitializeComponent()
      Me.InitializeToolStripDropDownItems()
    End Sub
   
   ' <snippet2>
   ' This utility method creates and initializes three 
   ' ToolStripDropDownItem controls and adds them 
   ' to the form's ToolStrip control.
   Private Sub InitializeToolStripDropDownItems()
      Dim b As New ToolStripDropDownButton("DropDownButton")
      b.DropDown = Me.contextMenuStrip1
      AddHandler b.DropDownClosed, AddressOf toolStripDropDownItem_DropDownClosed
      AddHandler b.DropDownItemClicked, AddressOf toolStripDropDownItem_DropDownItemClicked
      AddHandler b.DropDownOpened, AddressOf toolStripDropDownItem_DropDownOpened
      
      Dim m As New ToolStripMenuItem("MenuItem")
      m.DropDown = Me.contextMenuStrip1
      AddHandler m.DropDownClosed, AddressOf toolStripDropDownItem_DropDownClosed
      AddHandler m.DropDownItemClicked, AddressOf toolStripDropDownItem_DropDownItemClicked
      AddHandler m.DropDownOpened, AddressOf toolStripDropDownItem_DropDownOpened
      
      Dim sb As New ToolStripSplitButton("SplitButton")
      sb.DropDown = Me.contextMenuStrip1
      AddHandler sb.DropDownClosed, AddressOf toolStripDropDownItem_DropDownClosed
      AddHandler sb.DropDownItemClicked, AddressOf toolStripDropDownItem_DropDownItemClicked
      AddHandler sb.DropDownOpened, AddressOf toolStripDropDownItem_DropDownOpened
      
      Me.toolStrip1.Items.AddRange(New ToolStripItem() {b, m, sb})
   End Sub 
    ' </snippet2>

   ' <snippet3>
   ' This method handles the DropDownOpened event from a 
   ' ToolStripDropDownItem. It displays the value of the 
   ' item's Text property in the form's StatusStrip control.
    Private Sub toolStripDropDownItem_DropDownOpened(ByVal sender As Object, ByVal e As EventArgs)

        Dim item As ToolStripDropDownItem = CType(sender, ToolStripDropDownItem)

        Dim msg As String = String.Format("Item opened: {0}", item.Text)
        Me.toolStripStatusLabel1.Text = msg

    End Sub
    ' </snippet3>

   ' <snippet4>
   ' This method handles the DropDownItemClicked event from a 
   ' ToolStripDropDownItem. It displays the value of the clicked
   ' item's Text property in the form's StatusStrip control.
    Private Sub toolStripDropDownItem_DropDownItemClicked( _
    ByVal sender As Object, _
    ByVal e As ToolStripItemClickedEventArgs)

        Dim msg As String = String.Format("Item clicked: {0}", e.ClickedItem.Text)
        Me.toolStripStatusLabel1.Text = msg

    End Sub
    ' </snippet4>

   ' <snippet5>
   ' This method handles the DropDownClosed event from a 
   ' ToolStripDropDownItem. It displays the value of the 
   ' item's Text property in the form's StatusStrip control.
    Private Sub toolStripDropDownItem_DropDownClosed(ByVal sender As Object, ByVal e As EventArgs)

        Dim item As ToolStripDropDownItem = CType(sender, ToolStripDropDownItem)

        Dim msg As String = String.Format("Item closed: {0}", item.Text)
        Me.toolStripStatusLabel1.Text = msg

    End Sub
    ' </snippet5>

   ' <snippet6>
   ' This method shows the drop-down for the first item
   ' in the form's ToolStrip.
    Private Sub showButton_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) _
    Handles showButton.Click

        Dim item As ToolStripDropDownItem = CType(Me.toolStrip1.Items(0), ToolStripDropDownItem)

        If item.HasDropDownItems Then
            item.ShowDropDown()
        End If

    End Sub
    ' </snippet6>

   ' <snippet7>
   ' This method hides the drop-down for the first item
   ' in the form's ToolStrip.
    Private Sub hideButton_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) _
    Handles hideButton.Click

        Dim item As ToolStripDropDownItem = CType(Me.toolStrip1.Items(0), ToolStripDropDownItem)

        item.HideDropDown()
    End Sub
    ' </snippet7>

   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   #Region "Windows Form Designer generated code"
   
   
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.menuItem1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.menuItem2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.subItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.subItem2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.showButton = New System.Windows.Forms.Button()
      Me.hideButton = New System.Windows.Forms.Button()
      Me.statusStrip1.SuspendLayout()
      Me.contextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' toolStrip1
      ' 
      Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip1.Name = "toolStrip1"
      Me.toolStrip1.Size = New System.Drawing.Size(292, 25)
      Me.toolStrip1.TabIndex = 0
      Me.toolStrip1.Text = "toolStrip1"
      ' 
      ' statusStrip1
      ' 
      Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1})
      Me.statusStrip1.Location = New System.Drawing.Point(0, 251)
      Me.statusStrip1.Name = "statusStrip1"
      Me.statusStrip1.Size = New System.Drawing.Size(292, 22)
      Me.statusStrip1.TabIndex = 1
      Me.statusStrip1.Text = "statusStrip1"
      ' 
      ' toolStripStatusLabel1
      ' 
      Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
      Me.toolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
      Me.toolStripStatusLabel1.Text = "Ready"
      ' 
      ' contextMenuStrip1
      ' 
      Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItem1ToolStripMenuItem, Me.menuItem2ToolStripMenuItem})
      Me.contextMenuStrip1.Name = "contextMenuStrip1"
      Me.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.contextMenuStrip1.Size = New System.Drawing.Size(146, 48)
      ' 
      ' menuItem1ToolStripMenuItem
      ' 
      Me.menuItem1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.subItemToolStripMenuItem})
      Me.menuItem1ToolStripMenuItem.Name = "menuItem1ToolStripMenuItem"
      Me.menuItem1ToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.menuItem1ToolStripMenuItem.Text = "Menu Item1"
      ' 
      ' menuItem2ToolStripMenuItem
      ' 
      Me.menuItem2ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.subItem2ToolStripMenuItem})
      Me.menuItem2ToolStripMenuItem.Name = "menuItem2ToolStripMenuItem"
      Me.menuItem2ToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.menuItem2ToolStripMenuItem.Text = "Menu Item 2"
      ' 
      ' subItemToolStripMenuItem
      ' 
      Me.subItemToolStripMenuItem.Name = "subItemToolStripMenuItem"
      Me.subItemToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.subItemToolStripMenuItem.Text = "Sub Item"
      ' 
      ' subItem2ToolStripMenuItem
      ' 
      Me.subItem2ToolStripMenuItem.Name = "subItem2ToolStripMenuItem"
      Me.subItem2ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.subItem2ToolStripMenuItem.Text = "Sub Item2"
      ' 
      ' showButton
      ' 
      Me.showButton.Location = New System.Drawing.Point(12, 180)
      Me.showButton.Name = "showButton"
      Me.showButton.Size = New System.Drawing.Size(75, 23)
      Me.showButton.TabIndex = 2
      Me.showButton.Text = "Show"
      Me.showButton.UseVisualStyleBackColor = True
      ' 
      ' hideButton
      ' 
      Me.hideButton.Location = New System.Drawing.Point(12, 209)
      Me.hideButton.Name = "hideButton"
      Me.hideButton.Size = New System.Drawing.Size(75, 23)
      Me.hideButton.TabIndex = 3
      Me.hideButton.Text = "Hide"
      Me.hideButton.UseVisualStyleBackColor = True
      ' 
      ' Form1
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(statusStrip1)
      Me.Controls.Add(hideButton)
      Me.Controls.Add(toolStrip1)
      Me.Controls.Add(showButton)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.statusStrip1.ResumeLayout(False)
      Me.statusStrip1.PerformLayout()
      Me.contextMenuStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()
    End Sub
   
   #End Region
End Class


Public Class Program

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>