imports System
imports System.Data
imports System.ComponentModel
imports System.Windows.Forms


Public Class Form1: Inherits Form

' <Snippet1>
 Public Sub CreateMyMenuItem()
    ' Submenu item array.
    Dim SubMenus(3) as MenuItem
    ' Create three menu items to add to the submenu item array.
    Dim SubMenuItem1, SubMenuItem2, SubMenuItem3 as MenuItem
    SubMenuItem1 = New MenuItem ("Red")
    SubMenuItem2 = New MenuItem ("Blue")
    SubMenuItem3 = New MenuItem ("Green")
    ' Add the submenu items to the array.
    SubMenus(0) = SubMenuItem1
    SubMenus(1) = SubMenuItem2
    SubMenus(2) = SubMenuItem3
    ' Create a MenuItem with caption, shortcut key, 
    ' a Click, Popup, and Select event handler, menu merge type and order, and an 
    ' array of submenu items specified.
    Dim MenuItem1 As MenuItem
    MenuItem1 = New MenuItem(MenuMerge.Add, 0, Shortcut.CtrlShiftC, "&Colors", _
       AddressOf Me.MenuItem1_Click, _
       AddressOf Me.MenuItem1_Popup, _
       AddressOf Me.MenuItem1_Select, SubMenus)
 End Sub
 
 ' The following method is an event handler for MenuItem1 to use  when connecting the Click event.
 Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal  e as System.EventArgs)
    ' Code goes here that handles the Click event.
 End Sub
 
 ' The following method is an event handler for MenuItem1 to use  when connecting the Popup event.
 Private Sub MenuItem1_Popup(ByVal sender As System.Object, ByVal  e as System.EventArgs)
    ' Code goes here that handles the Click event.
 End Sub
 
 ' The following method is an event handler for MenuItem1 to use  when connecting the Select event
 Private Sub MenuItem1_Select(ByVal sender As System.Object, ByVal  e as System.EventArgs)
    ' Code goes here that handles the Click event.
 End Sub

' </Snippet1>
End Class
