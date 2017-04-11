'<snippet1>
' The following code example demonstrates using the MenuItem 
' Merge-Order property to control the way a merged menu is displayed.



Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    'Declare a MainMenu object and its items.
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents fileItem As System.Windows.Forms.MenuItem
    Friend WithEvents newItem As System.Windows.Forms.MenuItem
    Friend WithEvents openItem As System.Windows.Forms.MenuItem
    Friend WithEvents saveItem As System.Windows.Forms.MenuItem
    Friend WithEvents optionsMenu As System.Windows.Forms.MenuItem
    Friend WithEvents viewItem As System.Windows.Forms.MenuItem
    Friend WithEvents toolsItem As System.Windows.Forms.MenuItem

    ' Declare a ContextMenu object and its items.
    Friend WithEvents contextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents cutItem As System.Windows.Forms.MenuItem
    Friend WithEvents copyItem As System.Windows.Forms.MenuItem
    Friend WithEvents pasteItem As System.Windows.Forms.MenuItem

   
    Public Sub New()
        MyBase.New()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.fileItem = New System.Windows.Forms.MenuItem
        Me.newItem = New System.Windows.Forms.MenuItem
        Me.openItem = New System.Windows.Forms.MenuItem
        Me.saveItem = New System.Windows.Forms.MenuItem

        Me.viewItem = New System.Windows.Forms.MenuItem
        Me.toolsItem = New System.Windows.Forms.MenuItem


        Me.optionsMenu = New System.Windows.Forms.MenuItem
        Me.toolsItem = New System.Windows.Forms.MenuItem
        Me.viewItem = New System.Windows.Forms.MenuItem

        Me.contextMenu1 = New System.Windows.Forms.ContextMenu
        Me.cutItem = New System.Windows.Forms.MenuItem
        Me.copyItem = New System.Windows.Forms.MenuItem
        Me.pasteItem = New System.Windows.Forms.MenuItem

        'Add file menu item and options menu item to the MainMenu.
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
             {Me.fileItem, Me.optionsMenu})

        ' Initialize the file menu and its contents.
        Me.fileItem.Index = 0
        Me.fileItem.Text = "File"
        Me.newItem.Index = 0
        Me.newItem.Text = "New"
        Me.openItem.Index = 1
        Me.openItem.Text = "Open"
        Me.saveItem.Index = 2
        Me.saveItem.Text = "Save"


        ' Set the merge order of fileItem to 2 so it has a lower priority 
        ' on the merged menu.
        Me.fileItem.MergeOrder = 2

        'Add the new items to the fileItem menu item collection.
        Me.fileItem.MenuItems.AddRange(New MenuItem() _
           {Me.newItem, Me.openItem, Me.saveItem})
        '

        ' Initalize the optionsMenu item and its contents.
        Me.optionsMenu.Index = 1
        Me.optionsMenu.Text = "Options"

        Me.viewItem.Index = 0
        Me.viewItem.Text = "View"
        Me.toolsItem.Index = 1
        Me.toolsItem.Text = "Tools"

        ' Set mergeOrder property to 1, so it has a higher priority than
        ' the fileItem on the merged menu.
        Me.optionsMenu.MergeOrder = 1

        'Add view and tool items to the optionsItem menu item.
        Me.optionsMenu.MenuItems.AddRange _
            (New MenuItem() {Me.viewItem, Me.toolsItem})

        ' Initialize the menu items for the shortcut menu.
        Me.cutItem.Index = 0
        Me.cutItem.Text = "Cut"
        Me.cutItem.MergeOrder = 0
        Me.copyItem.Index = 1
        Me.copyItem.Text = "Copy"
        Me.copyItem.MergeOrder = 0
        Me.pasteItem.Index = 2
        Me.pasteItem.Text = "Paste"
        Me.pasteItem.MergeOrder = 0

        ' Add menu items to the shortcut menu.
        contextMenu1.MenuItems.AddRange _
            (New MenuItem() {cutItem, copyItem, pasteItem})

        ' Add the mainMenu1 items to the shortcut menu as well, by
        ' calling the MergeMenu method.
        contextMenu1.MergeMenu(mainMenu1)

        'Initialize the form.
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Right click on form for merged menu."

        ' Add mainMenu1 to the form.
        Me.Menu = mainMenu1


    End Sub


    Private Sub Form1_MouseDown(ByVal sender As Object, _
        ByVal e As MouseEventArgs) Handles MyBase.MouseDown

        ' Check for a right mouse click.
        If (e.Button = MouseButtons.Right) Then

            ' Display a merged menu containing items from mainMenu1 
            ' and contextMenu1.
            contextMenu1.Show(Me, New System.Drawing.Point(30, 30))
        End If
    End Sub

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub


    

End Class
'</snippet1>
