Imports System
Imports System.Data
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected textBox1 As TextBox
    Protected menuItemBlue As MenuItem
    Protected menuItemRed As MenuItem
    Protected menuItemGreen As MenuItem    
    
' <Snippet1>
 ' The following event handler would be connected to three menu items.
 Private Sub MyMenuClick(sender As Object, e As EventArgs)
     ' Determine if clicked menu item is the Blue menu item.
     If sender Is menuItemBlue Then
         ' Set the checkmark for the menuItemBlue menu item.
         menuItemBlue.Checked = True
         ' Uncheck the menuItemRed and menuItemGreen menu items.
         menuItemRed.Checked = False
         menuItemGreen.Checked = False
         ' Set the color of the text in the TextBox control to Blue.
         textBox1.ForeColor = Color.Blue
     Else
         If sender Is menuItemRed Then
             ' Set the checkmark for the menuItemRed menu item.
             menuItemRed.Checked = True
             ' Uncheck the menuItemBlue and menuItemGreen menu items.
             menuItemBlue.Checked = False
             menuItemGreen.Checked = False
             ' Set the color of the text in the TextBox control to Red.
             textBox1.ForeColor = Color.Red
         Else
             ' Set the checkmark for the menuItemGreen.
             menuItemGreen.Checked = True
             ' Uncheck the menuItemRed and menuItemBlue menu items.
             menuItemBlue.Checked = False
             menuItemRed.Checked = False
             ' Set the color of the text in the TextBox control to Blue.
             textBox1.ForeColor = Color.Green
         End If
     End If
 End Sub

' </Snippet1>
End Class
