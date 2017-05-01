 ' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
   Inherits Form
   Private components As System.ComponentModel.IContainer = Nothing
   Private WithEvents autoCloseCheckBox As CheckBox
   Private WithEvents closeButton As Button
   Private statusStrip1 As StatusStrip
   Private toolStripStatusLabel1 As ToolStripStatusLabel
   Private WithEvents radioButton1 As RadioButton
   Private WithEvents radioButton2 As RadioButton
   Private WithEvents radioButton3 As RadioButton
   Private WithEvents radioButton4 As RadioButton
   Private WithEvents radioButton5 As RadioButton
   Private WithEvents radioButton6 As RadioButton
   Private WithEvents radioButton7 As RadioButton
   Private groupBox1 As GroupBox
   Private WithEvents showButton As Button
   Private WithEvents showAtPointButton As Button
   Private toolStripStatusLabel2 As ToolStripStatusLabel
   Private WithEvents contextMenuStrip1 As ContextMenuStrip
   Private item1ToolStripMenuItem As ToolStripMenuItem
   Private WithEvents subItem1ToolStripMenuItem As ToolStripMenuItem
   Private WithEvents button1 As Button
   Private WithEvents subItem2ToolStripMenuItem As ToolStripMenuItem
   Private doneToolStripMenuItem As ToolStripMenuItem
   Private WithEvents button2 As Button
   
   Private dropDownDirection As ToolStripDropDownDirection
   
   
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
   ' This method calls the ToolStripDropDown control's Show 
   ' method to display the ContextMenuStrip relative to the
   ' owning control.
   Private Sub button1_MouseUp(sender As Object, e As MouseEventArgs) Handles button1.MouseUp
        Dim c As Control = CType(sender, Control)
      
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.contextMenuStrip1.Show(c, e.Location, Me.dropDownDirection)
        End If
    End Sub
    ' </snippet2>

   ' <snippet3>
   ' This method calls the ToolStripDropDown control's Show 
   ' method to display the ContextMenuStrip in its 
   ' default location.
   Private Sub showButton_Click(sender As Object, e As EventArgs) Handles showButton.Click
      Me.contextMenuStrip1.Show()
    End Sub
    ' </snippet3>

   ' <snippet4>
   ' This method calls the ToolStripDropDown control's Show 
   ' method to display the ContextMenuStrip relative to the
   ' origin of the form. 
   Private Sub showRelativeButton_Click(sender As Object, e As EventArgs)
      Me.contextMenuStrip1.Show(Me.Location, Me.dropDownDirection)
    End Sub
    ' </snippet4>

   ' <snippet5>
   ' This method calls the ToolStripDropDown control's Show 
   ' method to display the ContextMenuStrip at a fixed point.
   Private Sub showAtPointButton_Click(sender As Object, e As EventArgs) Handles showAtPointButton.Click, button2.Click
      Me.contextMenuStrip1.Show(23, 55)
    End Sub
    ' </snippet5>

   ' <snippet6>
   ' This method handles the Closing event. The ToolStripDropDown
   ' control is not allowed to close unless the Done menu item
   ' is clicked or the Close method is called explicitly.
   ' The Done menu item is enabled only after both of the other
   ' menu items have been selected.
   Private Sub contextMenuStrip_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles contextMenuStrip1.Closing
      If e.CloseReason <> ToolStripDropDownCloseReason.CloseCalled Then
         If subItem1ToolStripMenuItem.Checked AndAlso subItem2ToolStripMenuItem.Checked AndAlso doneToolStripMenuItem.Enabled Then
            ' Reset the state of menu items.
            subItem1ToolStripMenuItem.Checked = False
            subItem2ToolStripMenuItem.Checked = False
            doneToolStripMenuItem.Enabled = False
            
            ' Allow the ToolStripDropDown to close.
            ' Don't cancel the Close operation.
            e.Cancel = False
         Else
            ' Cancel the Close operation to keep the menu open.
            e.Cancel = True
            Me.toolStripStatusLabel1.Text = "Close canceled"
         End If
      End If
    End Sub
    ' </snippet6>

   ' <snippet7>
   ' This method handles the ToolStripDropDown control's 
   ' Closed event. It displays the CloseReason in the 
   ' ToolStripStatusLabel control.
   Private Sub contextMenuStrip_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles contextMenuStrip1.Closed
      Dim msg As String = String.Format("DropDown closed - CloseReason: {0}", e.CloseReason.ToString())
      
      Me.toolStripStatusLabel1.Text = msg
    End Sub
    ' </snippet7>

   ' <snippet8>
   ' This method explicitly closes the ToolStripDropDown control
   ' and specifies the reason for closing as CloseCalled.
   Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
      Me.contextMenuStrip1.Close(ToolStripDropDownCloseReason.CloseCalled)
    End Sub
    ' </snippet8>

   ' <snippet9>
   ' This method toggles the value of the ToolStripDropDown 
   ' control's AutoClose property.
   Private Sub autoCloseCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles autoCloseCheckBox.CheckedChanged
      Me.contextMenuStrip1.AutoClose = Me.contextMenuStrip1.AutoClose Xor True
    End Sub
    ' </snippet9>

   ' <snippet10>
   ' This method toggles the value of a subitem's Checked property.
   Private Sub subItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles subItem1ToolStripMenuItem.Click, subItem2ToolStripMenuItem.Click
        Dim item As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
      
      item.Checked = item.Checked Xor True
      
      Me.doneToolStripMenuItem.Enabled = subItem1ToolStripMenuItem.Checked AndAlso subItem2ToolStripMenuItem.Checked
    End Sub
    ' </snippet10>

   ' <snippet11>
   ' The following methods handle the CheckChanged event 
   ' for all the radio buttons. Each method calls a utility
   ' method to set the ToolStripDropDownDirection appropriately.
   Private Sub radioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton1.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.AboveLeft)
    End Sub
   
   
   Private Sub radioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton2.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.AboveRight)
    End Sub
   
   
   Private Sub radioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton3.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.BelowLeft)
    End Sub
   
   
   Private Sub radioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton4.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.BelowRight)
    End Sub
   
   
   Private Sub radioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton5.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.Default)
    End Sub
   
   
   Private Sub radioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton6.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.Left)
    End Sub
   
   
   Private Sub radioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton7.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.Right)
    End Sub
   
   
    ' This utility method sets the DefaultDropDownDirection property.
   Private Sub HandleRadioButton(sender As Object, direction As ToolStripDropDownDirection)
        Dim rb As RadioButton = CType(sender, RadioButton)
      
        If rb IsNot Nothing Then
            If rb.Checked Then
                Me.dropDownDirection = direction
                Me.contextMenuStrip1.DefaultDropDownDirection = direction
            End If
        End If
    End Sub
   ' </snippet11>
   
   #Region "Windows Form Designer generated code"
   
   
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.autoCloseCheckBox = New System.Windows.Forms.CheckBox()
      Me.closeButton = New System.Windows.Forms.Button()
      Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.radioButton1 = New System.Windows.Forms.RadioButton()
      Me.radioButton2 = New System.Windows.Forms.RadioButton()
      Me.radioButton3 = New System.Windows.Forms.RadioButton()
      Me.radioButton4 = New System.Windows.Forms.RadioButton()
      Me.radioButton5 = New System.Windows.Forms.RadioButton()
      Me.radioButton6 = New System.Windows.Forms.RadioButton()
      Me.radioButton7 = New System.Windows.Forms.RadioButton()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me.showButton = New System.Windows.Forms.Button()
      Me.showAtPointButton = New System.Windows.Forms.Button()
      Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.item1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.subItem1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.subItem2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.doneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.button1 = New System.Windows.Forms.Button()
      Me.button2 = New System.Windows.Forms.Button()
      Me.statusStrip1.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      Me.contextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' autoCloseCheckBox
      ' 
      Me.autoCloseCheckBox.AutoSize = True
      Me.autoCloseCheckBox.Checked = True
      Me.autoCloseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
      Me.autoCloseCheckBox.Location = New System.Drawing.Point(13, 288)
      Me.autoCloseCheckBox.Name = "autoCloseCheckBox"
      Me.autoCloseCheckBox.Size = New System.Drawing.Size(74, 17)
      Me.autoCloseCheckBox.TabIndex = 1
      Me.autoCloseCheckBox.Text = "AutoClose"
      Me.autoCloseCheckBox.UseVisualStyleBackColor = True
      ' 
      ' closeButton
      ' 
      Me.closeButton.Location = New System.Drawing.Point(12, 259)
      Me.closeButton.Name = "closeButton"
      Me.closeButton.Size = New System.Drawing.Size(95, 23)
      Me.closeButton.TabIndex = 2
      Me.closeButton.Text = "Close DropDown"
      Me.closeButton.UseVisualStyleBackColor = True
      ' 
      ' statusStrip1
      ' 
      Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1, Me.toolStripStatusLabel2})
      Me.statusStrip1.Location = New System.Drawing.Point(0, 320)
      Me.statusStrip1.Name = "statusStrip1"
      Me.statusStrip1.Size = New System.Drawing.Size(292, 22)
      Me.statusStrip1.TabIndex = 3
      Me.statusStrip1.Text = "statusStrip1"
      ' 
      ' toolStripStatusLabel1
      ' 
      Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
      Me.toolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
      Me.toolStripStatusLabel1.Text = "Ready"
      ' 
      ' toolStripStatusLabel2
      ' 
      Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
      Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
      ' 
      ' radioButton1
      ' 
      Me.radioButton1.AutoSize = True
      Me.radioButton1.Location = New System.Drawing.Point(24, 30)
      Me.radioButton1.Name = "radioButton1"
      Me.radioButton1.Size = New System.Drawing.Size(74, 17)
      Me.radioButton1.TabIndex = 4
      Me.radioButton1.TabStop = True
      Me.radioButton1.Text = "AboveLeft"
      Me.radioButton1.UseVisualStyleBackColor = True
      ' 
      ' radioButton2
      ' 
      Me.radioButton2.AutoSize = True
      Me.radioButton2.Location = New System.Drawing.Point(24, 54)
      Me.radioButton2.Name = "radioButton2"
      Me.radioButton2.Size = New System.Drawing.Size(81, 17)
      Me.radioButton2.TabIndex = 5
      Me.radioButton2.TabStop = True
      Me.radioButton2.Text = "AboveRight"
      Me.radioButton2.UseVisualStyleBackColor = True
      ' 
      ' radioButton3
      ' 
      Me.radioButton3.AutoSize = True
      Me.radioButton3.Location = New System.Drawing.Point(24, 78)
      Me.radioButton3.Name = "radioButton3"
      Me.radioButton3.Size = New System.Drawing.Size(72, 17)
      Me.radioButton3.TabIndex = 6
      Me.radioButton3.TabStop = True
      Me.radioButton3.Text = "BelowLeft"
      Me.radioButton3.UseVisualStyleBackColor = True
      ' 
      ' radioButton4
      ' 
      Me.radioButton4.AutoSize = True
      Me.radioButton4.Location = New System.Drawing.Point(24, 102)
      Me.radioButton4.Name = "radioButton4"
      Me.radioButton4.Size = New System.Drawing.Size(79, 17)
      Me.radioButton4.TabIndex = 7
      Me.radioButton4.TabStop = True
      Me.radioButton4.Text = "BelowRight"
      Me.radioButton4.UseVisualStyleBackColor = True
      ' 
      ' radioButton5
      ' 
      Me.radioButton5.AutoSize = True
      Me.radioButton5.Location = New System.Drawing.Point(24, 126)
      Me.radioButton5.Name = "radioButton5"
      Me.radioButton5.Size = New System.Drawing.Size(59, 17)
      Me.radioButton5.TabIndex = 8
      Me.radioButton5.TabStop = True
      Me.radioButton5.Text = "Default"
      Me.radioButton5.UseVisualStyleBackColor = True
      ' 
      ' radioButton6
      ' 
      Me.radioButton6.AutoSize = True
      Me.radioButton6.Location = New System.Drawing.Point(24, 150)
      Me.radioButton6.Name = "radioButton6"
      Me.radioButton6.Size = New System.Drawing.Size(43, 17)
      Me.radioButton6.TabIndex = 9
      Me.radioButton6.TabStop = True
      Me.radioButton6.Text = "Left"
      Me.radioButton6.UseVisualStyleBackColor = True
      ' 
      ' radioButton7
      ' 
      Me.radioButton7.AutoSize = True
      Me.radioButton7.Location = New System.Drawing.Point(24, 174)
      Me.radioButton7.Name = "radioButton7"
      Me.radioButton7.Size = New System.Drawing.Size(50, 17)
      Me.radioButton7.TabIndex = 10
      Me.radioButton7.TabStop = True
      Me.radioButton7.Text = "Right"
      Me.radioButton7.UseVisualStyleBackColor = True
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me.radioButton7)
      Me.groupBox1.Controls.Add(Me.radioButton6)
      Me.groupBox1.Controls.Add(Me.radioButton5)
      Me.groupBox1.Controls.Add(Me.radioButton4)
      Me.groupBox1.Controls.Add(Me.radioButton3)
      Me.groupBox1.Controls.Add(Me.radioButton2)
      Me.groupBox1.Controls.Add(Me.radioButton1)
      Me.groupBox1.Location = New System.Drawing.Point(149, 93)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(131, 212)
      Me.groupBox1.TabIndex = 11
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "DropDown Direction"
      ' 
      ' showButton
      ' 
      Me.showButton.Location = New System.Drawing.Point(12, 172)
      Me.showButton.Name = "showButton"
      Me.showButton.Size = New System.Drawing.Size(95, 23)
      Me.showButton.TabIndex = 12
      Me.showButton.Text = "Show"
      Me.showButton.UseVisualStyleBackColor = True
      ' 
      ' showAtPointButton
      ' 
      Me.showAtPointButton.Location = New System.Drawing.Point(12, 201)
      Me.showAtPointButton.Name = "showAtPointButton"
      Me.showAtPointButton.Size = New System.Drawing.Size(95, 23)
      Me.showAtPointButton.TabIndex = 13
      Me.showAtPointButton.Text = "Show Relative"
      Me.showAtPointButton.UseVisualStyleBackColor = True
      ' 
      ' contextMenuStrip1
      ' 
      Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.item1ToolStripMenuItem})
      Me.contextMenuStrip1.Name = "contextMenuStrip1"
      Me.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.contextMenuStrip1.ShowCheckMargin = True
      Me.contextMenuStrip1.ShowImageMargin = False
      Me.contextMenuStrip1.Size = New System.Drawing.Size(114, 26)
      ' 
      ' item1ToolStripMenuItem
      ' 
      Me.item1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.subItem1ToolStripMenuItem, Me.subItem2ToolStripMenuItem, Me.doneToolStripMenuItem})
      Me.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem"
      Me.item1ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.item1ToolStripMenuItem.Text = "Item1"
      ' 
      ' subItem1ToolStripMenuItem
      ' 
      Me.subItem1ToolStripMenuItem.Name = "subItem1ToolStripMenuItem"
      Me.subItem1ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
      Me.subItem1ToolStripMenuItem.Text = "Check This Item"
      ' 
      ' subItem2ToolStripMenuItem
      ' 
      Me.subItem2ToolStripMenuItem.Name = "subItem2ToolStripMenuItem"
      Me.subItem2ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
      Me.subItem2ToolStripMenuItem.Text = "Check This Item"
      ' 
      ' doneToolStripMenuItem
      ' 
      Me.doneToolStripMenuItem.Enabled = False
      Me.doneToolStripMenuItem.Name = "doneToolStripMenuItem"
      Me.doneToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
      Me.doneToolStripMenuItem.Text = "Done"
      ' 
      ' button1
      ' 
      Me.button1.Location = New System.Drawing.Point(66, 35)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(150, 23)
      Me.button1.TabIndex = 15
      Me.button1.Text = "Button with DropDown"
      Me.button1.UseVisualStyleBackColor = True
      ' 
      ' button2
      ' 
      Me.button2.Location = New System.Drawing.Point(12, 231)
      Me.button2.Name = "button2"
      Me.button2.Size = New System.Drawing.Size(95, 23)
      Me.button2.TabIndex = 16
      Me.button2.Text = "Show At Point"
      Me.button2.UseVisualStyleBackColor = True
      ' 
      ' Form1
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(292, 342)
      Me.Controls.Add(button2)
      Me.Controls.Add(showAtPointButton)
      Me.Controls.Add(showButton)
      Me.Controls.Add(button1)
      Me.Controls.Add(groupBox1)
      Me.Controls.Add(statusStrip1)
      Me.Controls.Add(closeButton)
      Me.Controls.Add(autoCloseCheckBox)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.statusStrip1.ResumeLayout(False)
      Me.statusStrip1.PerformLayout()
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
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
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>