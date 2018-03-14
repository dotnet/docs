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
   End Sub 'New
   Private flowLayoutPanel3 As FlowLayoutPanel
   Private label2 As Label
   Private button11 As Button
   Private button12 As Button
   Private button13 As Button
   Private button14 As Button
   Private button15 As Button
   Private flowLayoutPanel1 As FlowLayoutPanel
   Private label1 As Label
   Private button1 As Button
   Private button2 As Button
   Private button3 As Button
   Private button4 As Button
   Private button5 As Button
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   
   
   Private Sub InitializeComponent()
      Me.flowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
      Me.label2 = New System.Windows.Forms.Label()
      Me.button11 = New System.Windows.Forms.Button()
      Me.button12 = New System.Windows.Forms.Button()
      Me.button13 = New System.Windows.Forms.Button()
      Me.button14 = New System.Windows.Forms.Button()
      Me.button15 = New System.Windows.Forms.Button()
      Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.label1 = New System.Windows.Forms.Label()
      Me.button1 = New System.Windows.Forms.Button()
      Me.button2 = New System.Windows.Forms.Button()
      Me.button3 = New System.Windows.Forms.Button()
      Me.button4 = New System.Windows.Forms.Button()
      Me.button5 = New System.Windows.Forms.Button()
      Me.flowLayoutPanel3.SuspendLayout()
      Me.flowLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' flowLayoutPanel3
      ' 
      Me.flowLayoutPanel3.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.flowLayoutPanel3.Controls.Add(Me.label2)
      Me.flowLayoutPanel3.Controls.Add(Me.button11)
      Me.flowLayoutPanel3.Controls.Add(Me.button12)
      Me.flowLayoutPanel3.Controls.Add(Me.button13)
      Me.flowLayoutPanel3.Controls.Add(Me.button14)
      Me.flowLayoutPanel3.Controls.Add(Me.button15)
      Me.flowLayoutPanel3.Location = New System.Drawing.Point(12, 12)
      Me.flowLayoutPanel3.Name = "flowLayoutPanel3"
      Me.flowLayoutPanel3.Size = New System.Drawing.Size(631, 100)
      Me.flowLayoutPanel3.TabIndex = 2
      ' 
      ' label2
      ' 
      Me.label2.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(3, 28)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(138, 14)
      Me.label2.TabIndex = 10
      Me.label2.Text = "FlowDirection=LeftToRight"
      ' 
      ' button11
      ' 
      Me.button11.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.button11.AutoSize = True
      Me.button11.Location = New System.Drawing.Point(147, 44)
      Me.button11.Name = "button11"
      Me.button11.Size = New System.Drawing.Size(86, 23)
      Me.button11.TabIndex = 5
      Me.button11.Text = "Anchor=Bottom"
      ' 
      ' button12
      ' 
      Me.button12.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom, System.Windows.Forms.AnchorStyles)
      Me.button12.AutoSize = True
      Me.button12.Location = New System.Drawing.Point(239, 3)
      Me.button12.Name = "button12"
      Me.button12.Size = New System.Drawing.Size(111, 64)
      Me.button12.TabIndex = 6
      Me.button12.Text = "Anchor=Top, Bottom"
      ' 
      ' button13
      ' 
      Me.button13.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.button13.BackColor = System.Drawing.SystemColors.GradientActiveCaption
      Me.button13.Location = New System.Drawing.Point(356, 3)
      Me.button13.Name = "button13"
      Me.button13.Size = New System.Drawing.Size(75, 64)
      Me.button13.TabIndex = 7
      ' 
      ' button14
      ' 
      Me.button14.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.button14.Location = New System.Drawing.Point(437, 44)
      Me.button14.Name = "button14"
      Me.button14.TabIndex = 8
      Me.button14.Text = "Dock=Bottom"
      ' 
      ' button15
      ' 
      Me.button15.Dock = System.Windows.Forms.DockStyle.Fill
      Me.button15.Location = New System.Drawing.Point(518, 3)
      Me.button15.Name = "button15"
      Me.button15.Size = New System.Drawing.Size(75, 64)
      Me.button15.TabIndex = 9
      Me.button15.Text = "Dock=Fill"
      ' 
      ' flowLayoutPanel1
      ' 
      Me.flowLayoutPanel1.Anchor = CType(System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.flowLayoutPanel1.Controls.Add(Me.label1)
      Me.flowLayoutPanel1.Controls.Add(Me.button1)
      Me.flowLayoutPanel1.Controls.Add(Me.button2)
      Me.flowLayoutPanel1.Controls.Add(Me.button3)
      Me.flowLayoutPanel1.Controls.Add(Me.button4)
      Me.flowLayoutPanel1.Controls.Add(Me.button5)
      Me.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
      Me.flowLayoutPanel1.Location = New System.Drawing.Point(12, 118)
      Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
      Me.flowLayoutPanel1.Size = New System.Drawing.Size(200, 209)
      Me.flowLayoutPanel1.TabIndex = 3
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(3, 3)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(128, 14)
      Me.label1.TabIndex = 11
      Me.label1.Text = "FlowDirection=TopDown"
      ' 
      ' button1
      ' 
      Me.button1.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.button1.Location = New System.Drawing.Point(74, 23)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 5
      Me.button1.Text = "Anchor=Right"
      ' 
      ' button2
      ' 
      Me.button2.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button2.Location = New System.Drawing.Point(3, 52)
      Me.button2.Name = "button2"
      Me.button2.Size = New System.Drawing.Size(146, 23)
      Me.button2.TabIndex = 6
      Me.button2.Text = "Anchor=Left, Right"
      ' 
      ' button3
      ' 
      Me.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
      Me.button3.Location = New System.Drawing.Point(3, 81)
      Me.button3.Name = "button3"
      Me.button3.Size = New System.Drawing.Size(146, 23)
      Me.button3.TabIndex = 7
      ' 
      ' button4
      ' 
      Me.button4.Dock = System.Windows.Forms.DockStyle.Right
      Me.button4.Location = New System.Drawing.Point(74, 110)
      Me.button4.Name = "button4"
      Me.button4.TabIndex = 8
      Me.button4.Text = "Dock=Right"
      ' 
      ' button5
      ' 
      Me.button5.Dock = System.Windows.Forms.DockStyle.Fill
      Me.button5.Location = New System.Drawing.Point(3, 139)
      Me.button5.Name = "button5"
      Me.button5.Size = New System.Drawing.Size(146, 23)
      Me.button5.TabIndex = 9
      Me.button5.Text = "Dock=Fill"
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(658, 341)
      Me.Controls.Add(flowLayoutPanel1)
      Me.Controls.Add(flowLayoutPanel3)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.flowLayoutPanel3.ResumeLayout(False)
      Me.flowLayoutPanel3.PerformLayout()
      Me.flowLayoutPanel1.ResumeLayout(False)
      Me.flowLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent
    
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
   End Sub 'Main
End Class 'Form1
' </snippet1>