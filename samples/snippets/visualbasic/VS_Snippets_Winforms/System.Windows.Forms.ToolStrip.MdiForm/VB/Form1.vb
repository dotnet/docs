 ' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

' This code example demonstrates an MDI form 
' that supports menu merging and moveable 
' ToolStrip controls
Public Class Form1
   Inherits Form
   Private menuStrip1 As MenuStrip
   Private toolStripMenuItem1 As ToolStripMenuItem
   Private WithEvents newToolStripMenuItem As ToolStripMenuItem
   Private toolStripPanel1 As ToolStripPanel
   Private toolStrip1 As ToolStrip
   Private toolStripPanel2 As ToolStripPanel
   Private toolStrip2 As ToolStrip
   Private toolStripPanel3 As ToolStripPanel
   Private toolStrip3 As ToolStrip
   Private toolStripPanel4 As ToolStripPanel
   Private toolStrip4 As ToolStrip
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   
   ' <snippet2>
   ' This method creates a new ChildForm instance 
   ' and attaches it to the MDI parent form.
    Private Sub newToolStripMenuItem_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) _
    Handles newToolStripMenuItem.Click

        Dim f As New ChildForm()
        f.MdiParent = Me
        f.Text = "Form - " + Me.MdiChildren.Length.ToString()
        f.Show()

    End Sub
   ' </snippet2>

   #Region "Windows Form Designer generated code"
   
   Private Sub InitializeComponent()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.toolStripPanel2 = New System.Windows.Forms.ToolStripPanel
        Me.toolStrip2 = New System.Windows.Forms.ToolStrip
        Me.toolStripPanel3 = New System.Windows.Forms.ToolStripPanel
        Me.toolStrip3 = New System.Windows.Forms.ToolStrip
        Me.toolStripPanel4 = New System.Windows.Forms.ToolStripPanel
        Me.toolStrip4 = New System.Windows.Forms.ToolStrip
        Me.menuStrip1.SuspendLayout()
        Me.toolStripPanel1.SuspendLayout()
        Me.toolStripPanel2.SuspendLayout()
        Me.toolStripPanel3.SuspendLayout()
        Me.toolStripPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.MdiWindowListItem = Me.toolStripMenuItem1
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(292, 24)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem})
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(57, 20)
        Me.toolStripMenuItem1.Text = "Window"
        '
        'newToolStripMenuItem
        '
        Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
        Me.newToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.newToolStripMenuItem.Text = "New"
        '
        'toolStripPanel1
        '
        Me.toolStripPanel1.Controls.Add(Me.toolStrip1)
        Me.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.toolStripPanel1.Location = New System.Drawing.Point(0, 49)
        Me.toolStripPanel1.Name = "toolStripPanel1"
        Me.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.toolStripPanel1.RowMargin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.toolStripPanel1.Size = New System.Drawing.Size(26, 199)
        '
        'toolStrip1
        '
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(26, 109)
        Me.toolStrip1.TabIndex = 0
        '
        'toolStripPanel2
        '
        Me.toolStripPanel2.Controls.Add(Me.toolStrip2)
        Me.toolStripPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.toolStripPanel2.Location = New System.Drawing.Point(0, 24)
        Me.toolStripPanel2.Name = "toolStripPanel2"
        Me.toolStripPanel2.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.toolStripPanel2.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.toolStripPanel2.Size = New System.Drawing.Size(292, 25)
        '
        'toolStrip2
        '
        Me.toolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.toolStrip2.Name = "toolStrip2"
        Me.toolStrip2.Size = New System.Drawing.Size(109, 25)
        Me.toolStrip2.TabIndex = 0
        '
        'toolStripPanel3
        '
        Me.toolStripPanel3.Controls.Add(Me.toolStrip3)
        Me.toolStripPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.toolStripPanel3.Location = New System.Drawing.Point(266, 49)
        Me.toolStripPanel3.Name = "toolStripPanel3"
        Me.toolStripPanel3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.toolStripPanel3.RowMargin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.toolStripPanel3.Size = New System.Drawing.Size(26, 199)
        '
        'toolStrip3
        '
        Me.toolStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip3.Location = New System.Drawing.Point(0, 3)
        Me.toolStrip3.Name = "toolStrip3"
        Me.toolStrip3.Size = New System.Drawing.Size(26, 109)
        Me.toolStrip3.TabIndex = 0
        '
        'toolStripPanel4
        '
        Me.toolStripPanel4.Controls.Add(Me.toolStrip4)
        Me.toolStripPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.toolStripPanel4.Location = New System.Drawing.Point(0, 248)
        Me.toolStripPanel4.Name = "toolStripPanel4"
        Me.toolStripPanel4.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.toolStripPanel4.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.toolStripPanel4.Size = New System.Drawing.Size(292, 25)
        '
        'toolStrip4
        '
        Me.toolStrip4.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip4.Location = New System.Drawing.Point(3, 0)
        Me.toolStrip4.Name = "toolStrip4"
        Me.toolStrip4.Size = New System.Drawing.Size(109, 25)
        Me.toolStrip4.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.toolStripPanel3)
        Me.Controls.Add(Me.toolStripPanel1)
        Me.Controls.Add(Me.toolStripPanel2)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.toolStripPanel4)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStripPanel1.ResumeLayout(False)
        Me.toolStripPanel1.PerformLayout()
        Me.toolStripPanel2.ResumeLayout(False)
        Me.toolStripPanel2.PerformLayout()
        Me.toolStripPanel3.ResumeLayout(False)
        Me.toolStripPanel3.PerformLayout()
        Me.toolStripPanel4.ResumeLayout(False)
        Me.toolStripPanel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub 
   
   #End Region
End Class


Public Class ChildForm
   Inherits Form
   Private menuStrip1 As System.Windows.Forms.MenuStrip
   Private toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
   Private components As System.ComponentModel.IContainer = Nothing
   
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   #Region "Windows Form Designer generated code"
  
   Private Sub InitializeComponent()
      Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
      Me.menuStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' menuStrip1
      ' 
      Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1})
      Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.menuStrip1.Name = "menuStrip1"
      Me.menuStrip1.Size = New System.Drawing.Size(292, 24)
      Me.menuStrip1.TabIndex = 0
      Me.menuStrip1.Text = "menuStrip1"
      ' 
      ' toolStripMenuItem1
      ' 
      Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
      Me.toolStripMenuItem1.Size = New System.Drawing.Size(90, 20)
      Me.toolStripMenuItem1.Text = "ChildMenuItem"
      ' 
      ' ChildForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.Add(menuStrip1)
      Me.MainMenuStrip = Me.menuStrip1
      Me.Name = "ChildForm"
      Me.Text = "ChildForm"
      Me.menuStrip1.ResumeLayout(False)
      Me.menuStrip1.PerformLayout()
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
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>