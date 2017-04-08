' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Private button1 As System.Windows.Forms.Button
   Private button2 As System.Windows.Forms.Button
   Private button3 As System.Windows.Forms.Button
   Private button4 As System.Windows.Forms.Button
   Private button5 As System.Windows.Forms.Button
   Private tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
   Private button6 As System.Windows.Forms.Button
   Private button7 As System.Windows.Forms.Button
   Private button8 As System.Windows.Forms.Button
   Private button9 As System.Windows.Forms.Button
   Private tableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
   Private button10 As System.Windows.Forms.Button
   Private button11 As System.Windows.Forms.Button
   Private button12 As System.Windows.Forms.Button
   
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   
   Private Sub InitializeComponent()
      Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.button1 = New System.Windows.Forms.Button()
      Me.button2 = New System.Windows.Forms.Button()
      Me.button3 = New System.Windows.Forms.Button()
      Me.button4 = New System.Windows.Forms.Button()
      Me.button5 = New System.Windows.Forms.Button()
      Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
      Me.button6 = New System.Windows.Forms.Button()
      Me.button7 = New System.Windows.Forms.Button()
      Me.button8 = New System.Windows.Forms.Button()
      Me.button9 = New System.Windows.Forms.Button()
      Me.tableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
      Me.button10 = New System.Windows.Forms.Button()
      Me.button11 = New System.Windows.Forms.Button()
      Me.button12 = New System.Windows.Forms.Button()
      Me.tableLayoutPanel1.SuspendLayout()
      Me.tableLayoutPanel2.SuspendLayout()
      Me.tableLayoutPanel3.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' tableLayoutPanel1
      ' 
      Me.tableLayoutPanel1.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single
      Me.tableLayoutPanel1.ColumnCount = 5
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F))
      Me.tableLayoutPanel1.Controls.Add(Me.button1, 0, 0)
      Me.tableLayoutPanel1.Controls.Add(Me.button2, 1, 0)
      Me.tableLayoutPanel1.Controls.Add(Me.button3, 2, 0)
      Me.tableLayoutPanel1.Controls.Add(Me.button4, 3, 0)
      Me.tableLayoutPanel1.Controls.Add(Me.button5, 4, 0)
      Me.tableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
      Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
      Me.tableLayoutPanel1.RowCount = 1
      Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
      Me.tableLayoutPanel1.Size = New System.Drawing.Size(731, 100)
      Me.tableLayoutPanel1.TabIndex = 0
      ' 
      ' button1
      ' 
      Me.button1.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.button1.AutoSize = True
      Me.button1.Location = New System.Drawing.Point(34, 38)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(79, 23)
      Me.button1.TabIndex = 0
      Me.button1.Text = "Anchor=None"
      ' 
      ' button2
      ' 
      Me.button2.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.button2.AutoSize = True
      Me.button2.Location = New System.Drawing.Point(150, 38)
      Me.button2.Name = "button2"
      Me.button2.TabIndex = 1
      Me.button2.Text = "Anchor=Left"
      ' 
      ' button3
      ' 
      Me.button3.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.button3.AutoSize = True
      Me.button3.Location = New System.Drawing.Point(328, 4)
      Me.button3.Name = "button3"
      Me.button3.TabIndex = 2
      Me.button3.Text = "Anchor=Top"
      ' 
      ' button4
      ' 
      Me.button4.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.button4.AutoSize = True
      Me.button4.Location = New System.Drawing.Point(503, 38)
      Me.button4.Name = "button4"
      Me.button4.Size = New System.Drawing.Size(78, 23)
      Me.button4.TabIndex = 3
      Me.button4.Text = "Anchor=Right"
      ' 
      ' button5
      ' 
      Me.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.button5.AutoSize = True
      Me.button5.Location = New System.Drawing.Point(614, 73)
      Me.button5.Name = "button5"
      Me.button5.Size = New System.Drawing.Size(86, 23)
      Me.button5.TabIndex = 4
      Me.button5.Text = "Anchor=Bottom"
      ' 
      ' tableLayoutPanel2
      ' 
      Me.tableLayoutPanel2.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single
      Me.tableLayoutPanel2.ColumnCount = 4
      Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F))
      Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F))
      Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F))
      Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F))
      Me.tableLayoutPanel2.Controls.Add(Me.button6, 0, 0)
      Me.tableLayoutPanel2.Controls.Add(Me.button7, 1, 0)
      Me.tableLayoutPanel2.Controls.Add(Me.button8, 2, 0)
      Me.tableLayoutPanel2.Controls.Add(Me.button9, 3, 0)
      Me.tableLayoutPanel2.Location = New System.Drawing.Point(12, 118)
      Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
      Me.tableLayoutPanel2.RowCount = 1
      Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
      Me.tableLayoutPanel2.Size = New System.Drawing.Size(731, 100)
      Me.tableLayoutPanel2.TabIndex = 1
      ' 
      ' button6
      ' 
      Me.button6.AutoSize = True
      Me.button6.Location = New System.Drawing.Point(4, 4)
      Me.button6.Name = "button6"
      Me.button6.TabIndex = 0
      Me.button6.Text = "Top, Left"
      ' 
      ' button7
      ' 
      Me.button7.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button7.AutoSize = True
      Me.button7.Location = New System.Drawing.Point(286, 4)
      Me.button7.Name = "button7"
      Me.button7.TabIndex = 1
      Me.button7.Text = "Top, Right"
      ' 
      ' button8
      ' 
      Me.button8.Anchor = CType(System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button8.AutoSize = True
      Me.button8.Location = New System.Drawing.Point(466, 73)
      Me.button8.Name = "button8"
      Me.button8.Size = New System.Drawing.Size(77, 23)
      Me.button8.TabIndex = 2
      Me.button8.Text = "Bottom, Right"
      ' 
      ' button9
      ' 
      Me.button9.Anchor = CType(System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left, System.Windows.Forms.AnchorStyles)
      Me.button9.AutoSize = True
      Me.button9.Location = New System.Drawing.Point(550, 73)
      Me.button9.Name = "button9"
      Me.button9.TabIndex = 3
      Me.button9.Text = "Bottom, Left"
      ' 
      ' tableLayoutPanel3
      ' 
      Me.tableLayoutPanel3.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single
      Me.tableLayoutPanel3.ColumnCount = 3
      Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F))
      Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F))
      Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F))
      Me.tableLayoutPanel3.Controls.Add(Me.button10, 0, 0)
      Me.tableLayoutPanel3.Controls.Add(Me.button11, 1, 0)
      Me.tableLayoutPanel3.Controls.Add(Me.button12, 2, 0)
      Me.tableLayoutPanel3.Location = New System.Drawing.Point(12, 225)
      Me.tableLayoutPanel3.Name = "tableLayoutPanel3"
      Me.tableLayoutPanel3.RowCount = 1
      Me.tableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
      Me.tableLayoutPanel3.Size = New System.Drawing.Size(731, 100)
      Me.tableLayoutPanel3.TabIndex = 2
      ' 
      ' button10
      ' 
      Me.button10.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button10.Location = New System.Drawing.Point(4, 39)
      Me.button10.Name = "button10"
      Me.button10.Size = New System.Drawing.Size(236, 23)
      Me.button10.TabIndex = 0
      Me.button10.Text = "Left, Right"
      ' 
      ' button11
      ' 
      Me.button11.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom, System.Windows.Forms.AnchorStyles)
      Me.button11.Location = New System.Drawing.Point(327, 4)
      Me.button11.Name = "button11"
      Me.button11.Size = New System.Drawing.Size(75, 93)
      Me.button11.TabIndex = 1
      Me.button11.Text = "Top, Bottom"
      ' 
      ' button12
      ' 
      Me.button12.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button12.Location = New System.Drawing.Point(490, 4)
      Me.button12.Name = "button12"
      Me.button12.Size = New System.Drawing.Size(237, 93)
      Me.button12.TabIndex = 2
      Me.button12.Text = "Top, Bottom, Left, Right"
      ' 
      ' Form1
      ' 
      Me.AutoSize = True
      Me.ClientSize = New System.Drawing.Size(755, 338)
      Me.Controls.Add(tableLayoutPanel3)
      Me.Controls.Add(tableLayoutPanel2)
      Me.Controls.Add(tableLayoutPanel1)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.tableLayoutPanel1.ResumeLayout(False)
      Me.tableLayoutPanel1.PerformLayout()
      Me.tableLayoutPanel2.ResumeLayout(False)
      Me.tableLayoutPanel2.PerformLayout()
      Me.tableLayoutPanel3.ResumeLayout(False)
      Me.ResumeLayout(False)
    End Sub
    
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
    End Sub
End Class

' </snippet1>