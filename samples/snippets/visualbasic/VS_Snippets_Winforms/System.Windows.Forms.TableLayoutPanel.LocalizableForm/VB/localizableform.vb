 '---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class LocalizableForm
    Inherits Form

   Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Private listView1 As System.Windows.Forms.ListView
   Private panel1 As System.Windows.Forms.Panel
   Private WithEvents button3 As System.Windows.Forms.Button
   Private WithEvents button2 As System.Windows.Forms.Button
   Private WithEvents button1 As System.Windows.Forms.Button
   Private tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
   Private WithEvents button4 As System.Windows.Forms.Button
   Private WithEvents button5 As System.Windows.Forms.Button
   Private WithEvents button6 As System.Windows.Forms.Button
   Private label1 As System.Windows.Forms.Label
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   Private Sub AddText(sender As Object, e As EventArgs) Handles button3.Click, button2.Click, button1.Click, button4.Click, button5.Click, button6.Click
      CType(sender, Button).Text += "x"
    End Sub
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub 
   
   Private Sub InitializeComponent()
      Dim listViewGroup16 As New System.Windows.Forms.ListViewGroup("First Group", System.Windows.Forms.HorizontalAlignment.Left)
      Dim listViewGroup17 As New System.Windows.Forms.ListViewGroup("Second Group", System.Windows.Forms.HorizontalAlignment.Left)
      Dim listViewGroup18 As New System.Windows.Forms.ListViewGroup("Third Group", System.Windows.Forms.HorizontalAlignment.Left)
      Dim listViewItem26 As New System.Windows.Forms.ListViewItem("Item 1")
      Dim listViewItem27 As New System.Windows.Forms.ListViewItem("Item 2")
      Dim listViewItem28 As New System.Windows.Forms.ListViewItem("Item 3")
      Dim listViewItem29 As New System.Windows.Forms.ListViewItem("Item 4")
      Dim listViewItem30 As New System.Windows.Forms.ListViewItem("Item 5")
      Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.listView1 = New System.Windows.Forms.ListView()
      Me.panel1 = New System.Windows.Forms.Panel()
      Me.button3 = New System.Windows.Forms.Button()
      Me.button2 = New System.Windows.Forms.Button()
      Me.button1 = New System.Windows.Forms.Button()
      Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
      Me.button4 = New System.Windows.Forms.Button()
      Me.button5 = New System.Windows.Forms.Button()
      Me.button6 = New System.Windows.Forms.Button()
      Me.label1 = New System.Windows.Forms.Label()
      Me.tableLayoutPanel1.SuspendLayout()
      Me.panel1.SuspendLayout()
      Me.tableLayoutPanel2.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' tableLayoutPanel1
      ' 
      Me.tableLayoutPanel1.ColumnCount = 2
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F))
      Me.tableLayoutPanel1.Controls.Add(Me.listView1, 1, 0)
      Me.tableLayoutPanel1.Controls.Add(Me.panel1, 0, 0)
      Me.tableLayoutPanel1.Location = New System.Drawing.Point(2, 52)
      Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
      Me.tableLayoutPanel1.RowCount = 1
      Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F))
      Me.tableLayoutPanel1.Size = New System.Drawing.Size(524, 270)
      Me.tableLayoutPanel1.TabIndex = 1
      ' 
      ' listView1
      ' 
      Me.listView1.Dock = System.Windows.Forms.DockStyle.Fill
      listViewGroup16.Header = "First Group"
      listViewGroup16.Name = Nothing
      listViewGroup17.Header = "Second Group"
      listViewGroup17.Name = Nothing
      listViewGroup18.Header = "Third Group"
      listViewGroup18.Name = Nothing
      Me.listView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {listViewGroup16, listViewGroup17, listViewGroup18})
      'this.listView1.IsBackgroundImageTiled = false;
      listViewItem26.Group = listViewGroup16
      listViewItem27.Group = listViewGroup16
      listViewItem28.Group = listViewGroup17
      listViewItem29.Group = listViewGroup17
      listViewItem30.Group = listViewGroup18
      Me.listView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem26, listViewItem27, listViewItem28, listViewItem29, listViewItem30})
      Me.listView1.Location = New System.Drawing.Point(90, 3)
      Me.listView1.Name = "listView1"
      Me.listView1.Size = New System.Drawing.Size(431, 264)
      Me.listView1.TabIndex = 1
      ' 
      ' panel1
      ' 
      Me.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
      Me.panel1.AutoSize = True
      Me.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.panel1.Controls.Add(Me.button3)
      Me.panel1.Controls.Add(Me.button2)
      Me.panel1.Controls.Add(Me.button1)
      Me.panel1.Location = New System.Drawing.Point(3, 3)
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(81, 86)
      Me.panel1.TabIndex = 2
      ' 
      ' button3
      ' 
      Me.button3.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button3.AutoSize = True
      Me.button3.Location = New System.Drawing.Point(3, 60)
      Me.button3.Name = "button3"
      Me.button3.TabIndex = 2
      Me.button3.Text = "Add Text"
      ' 
      ' button2
      ' 
      Me.button2.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button2.AutoSize = True
      Me.button2.Location = New System.Drawing.Point(3, 31)
      Me.button2.Name = "button2"
      Me.button2.TabIndex = 1
      Me.button2.Text = "Add Text"
      ' 
      ' button1
      ' 
      Me.button1.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button1.AutoSize = True
      Me.button1.Location = New System.Drawing.Point(3, 2)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 0
      Me.button1.Text = "Add Text"
      ' 
      ' tableLayoutPanel2
      ' 
      Me.tableLayoutPanel2.Anchor = CType(System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.tableLayoutPanel2.AutoSize = True
      Me.tableLayoutPanel2.ColumnCount = 3
      Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F))
      Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F))
      Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F))
      Me.tableLayoutPanel2.Controls.Add(Me.button4, 0, 0)
      Me.tableLayoutPanel2.Controls.Add(Me.button5, 1, 0)
      Me.tableLayoutPanel2.Controls.Add(Me.button6, 2, 0)
      Me.tableLayoutPanel2.Location = New System.Drawing.Point(284, 328)
      Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
      Me.tableLayoutPanel2.RowCount = 1
      Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tableLayoutPanel2.Size = New System.Drawing.Size(243, 34)
      Me.tableLayoutPanel2.TabIndex = 2
      ' 
      ' button4
      ' 
      Me.button4.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button4.AutoSize = True
      Me.button4.Location = New System.Drawing.Point(3, 5)
      Me.button4.Name = "button4"
      Me.button4.TabIndex = 0
      Me.button4.Text = "Add Text"
      ' 
      ' button5
      ' 
      Me.button5.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button5.AutoSize = True
      Me.button5.Location = New System.Drawing.Point(84, 5)
      Me.button5.Name = "button5"
      Me.button5.TabIndex = 1
      Me.button5.Text = "Add Text"
      ' 
      ' button6
      ' 
      Me.button6.Anchor = CType(System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
      Me.button6.AutoSize = True
      Me.button6.Location = New System.Drawing.Point(165, 5)
      Me.button6.Name = "button6"
      Me.button6.TabIndex = 2
      Me.button6.Text = "Add Text"
      ' 
      ' label1
      ' 
      Me.label1.Location = New System.Drawing.Point(8, 7)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(518, 40)
      Me.label1.TabIndex = 3
      Me.label1.Text = "Click on any button to add text to the button. This simulates localizing strings," + " and provides a good demonstration of how the dialog will automatically adjust w" + "hen those longer strings are added to the UI."
      ' 
      ' LocalizableForm
      ' 
      Me.ClientSize = New System.Drawing.Size(539, 374)
      Me.Controls.Add(label1)
      Me.Controls.Add(tableLayoutPanel2)
      Me.Controls.Add(tableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Name = "LocalizableForm"
      Me.Text = "Localizable Dialog"
      Me.tableLayoutPanel1.ResumeLayout(False)
      Me.tableLayoutPanel1.PerformLayout()
      Me.panel1.ResumeLayout(False)
      Me.panel1.PerformLayout()
      Me.tableLayoutPanel2.ResumeLayout(False)
      Me.tableLayoutPanel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()
    End Sub 
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New LocalizableForm())
    End Sub
End Class
' </snippet1>