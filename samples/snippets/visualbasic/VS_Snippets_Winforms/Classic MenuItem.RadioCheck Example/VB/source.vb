Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    Protected menuItemRed As MenuItem
    Protected menuItemBlue As MenuItem
    Protected menuItemGreen As MenuItem
    
' <Snippet1>
    ' This method is called from the constructor of the form to set up the menu
    ' items.
    Public Sub ConfigureMyMenus()
        ' Set all of these menu items to Radio-Button check marks so the user
        ' can see that only one color can be selected at a time. 
        menuItemRed.RadioCheck = True
        menuItemBlue.RadioCheck = True
        menuItemGreen.RadioCheck = True
    End Sub    
    
    ' The following event handler would be connected to three menu items.
    Private Sub MyMenuClick(sender As Object, e As EventArgs)
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
                ' Set the checkmark for the menuItemGreen menu item.
                menuItemGreen.Checked = True
                ' Uncheck the menuItemRed and menuItemGreen menu items.
                menuItemBlue.Checked = False
                menuItemRed.Checked = False
                ' Set the color of the text in the TextBox control to Blue.
                textBox1.ForeColor = Color.Green
            End If
        End If
    End Sub

' </Snippet1>

End Class
