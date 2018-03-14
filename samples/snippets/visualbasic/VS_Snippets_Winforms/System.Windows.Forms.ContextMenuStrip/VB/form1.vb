 '<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private toolStripButton1 As ToolStripButton
   Private toolStripButton2 As ToolStripButton
   Private toolStripButton3 As ToolStripButton
   Private contextMenuStrip1 As ContextMenuStrip
   Private components As IContainer
   Private toolStripMenuItem1 As ToolStripMenuItem
   Private toolStripMenuItem2 As ToolStripMenuItem
   Private contextMenuStrip2 As ContextMenuStrip
   Private rearrangeButtonsToolStripMenuItem As ToolStripMenuItem
   Private selectIconsToolStripMenuItem As ToolStripMenuItem
   Private toolStrip1 As ToolStrip
   
   
   Public Sub New()
        InitializeComponent()
    End Sub

    <STAThread()> _
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.contextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.rearrangeButtonsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.selectIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrip1.SuspendLayout()
        Me.contextMenuStrip1.SuspendLayout()
        Me.contextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        ' <Snippet2> 
        ' Associate contextMenuStrip2 with toolStrip1.
        ' toolStrip1 property settings follow.
        '
        Me.toolStrip1.ContextMenuStrip = Me.contextMenuStrip2
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1, Me.toolStripButton2, Me.toolStripButton3})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(292, 25)
        Me.toolStrip1.TabIndex = 0
        Me.toolStrip1.Text = "toolStrip1"
        ' </Snippet2>
        ' 
        ' toolStripButton1
        ' 
        Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton1.Image = CType(resources.GetObject("toolStripButton1.Image"), System.Drawing.Image)
        Me.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButton1.Name = "toolStripButton1"
        Me.toolStripButton1.Text = "toolStripButton1"
        ' 
        ' toolStripButton2
        ' 
        Me.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton2.Image = CType(resources.GetObject("toolStripButton2.Image"), System.Drawing.Image)
        Me.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButton2.Name = "toolStripButton2"
        Me.toolStripButton2.Text = "toolStripButton2"
        ' 
        ' toolStripButton3
        ' 
        Me.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton3.Image = CType(resources.GetObject("toolStripButton3.Image"), System.Drawing.Image)
        Me.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripButton3.Name = "toolStripButton3"
        Me.toolStripButton3.Text = "toolStripButton3"
        ' 
        ' contextMenuStrip1
        ' 
        Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2})
        Me.contextMenuStrip1.Name = "contextMenuStrip1"
        Me.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.contextMenuStrip1.Size = New System.Drawing.Size(131, 48)
        ' 
        ' contextMenuStrip2
        ' 
        Me.contextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rearrangeButtonsToolStripMenuItem, Me.selectIconsToolStripMenuItem})
        Me.contextMenuStrip2.Name = "contextMenuStrip2"
        Me.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.contextMenuStrip2.Size = New System.Drawing.Size(162, 48)
        ' 
        ' toolStripMenuItem1
        ' 
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Text = "&Resize"
        ' 
        ' toolStripMenuItem2
        ' 
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Text = "&Keep on Top"
        ' 
        ' rearrangeButtonsToolStripMenuItem
        ' 
        Me.rearrangeButtonsToolStripMenuItem.Name = "rearrangeButtonsToolStripMenuItem"
        Me.rearrangeButtonsToolStripMenuItem.Text = "R&earrange Buttons"
        ' 
        ' selectIconsToolStripMenuItem
        ' 
        Me.selectIconsToolStripMenuItem.Name = "selectIconsToolStripMenuItem"
        Me.selectIconsToolStripMenuItem.Text = "&Select Icons"
        ' 
        ' <Snippet3> 
        ' Associate contextMenuStrip1 with Form1.
        ' Form1 property settings follow.
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.ContextMenuStrip = Me.contextMenuStrip1
        Me.Controls.Add(toolStrip1)
        Me.Name = "Form1"
        Me.toolStrip1.ResumeLayout(False)
        Me.contextMenuStrip1.ResumeLayout(False)
        Me.contextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    ' </Snippet3>

    '</Snippet1>
End Class