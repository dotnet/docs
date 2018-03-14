' MenuEditors.vb
' <snippet1>
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Drawing.Design

Namespace Examples.VB.WebControls.Design

    ' The MyMenuControl has some properties of the Menu.
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyMenuControl
        Inherits WebControl

        ' <snippet2>
        Private localBindings As MenuItemBindingCollection

        ' Associate the MenuBindingsEditor with the DataBindings.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            MenuBindingsEditor), _
            GetType(UITypeEditor))> _
        Public Property DataBindings() As MenuItemBindingCollection
            Get
                Return localBindings
            End Get
            Set
                localBindings = value
            End Set
        End Property ' DataBindings
        ' </snippet2>

        ' <snippet3>
        Private menuItems As MenuItemCollection

        ' Associate the MenuItemCollectionEditor with the Items.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            MenuItemCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property Items() As MenuItemCollection
            Get
                If menuItems Is Nothing Then
                    menuItems = New MenuItemCollection()
                End If
                Return menuItems
            End Get
            Set
                menuItems = value
            End Set
        End Property ' Items
        ' </snippet3>

        ' <snippet4>
        Private menuItemStyles As MenuItemStyleCollection

        ' Associate the MenuItemStyleCollectionEditor with the 
        ' LevelMenuItemStyles.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            MenuItemStyleCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property LevelMenuItemStyles() As MenuItemStyleCollection
            Get
                Return menuItemStyles
            End Get
            Set
                menuItemStyles = value
            End Set
        End Property ' LevelMenuItemStyles
        ' </snippet4>

        ' <snippet5>
        Private subMenuStyles As SubMenuStyleCollection

        ' Associate the SubMenuStyleCollectionEditor with the 
        ' LevelSubMenuStyles.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            SubMenuStyleCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property LevelSubMenuStyles() As SubMenuStyleCollection
            Get
                Return subMenuStyles
            End Get
            Set
                subMenuStyles = value
            End Set
        End Property ' LevelSubMenuStyles
        ' </snippet5>

    End Class ' MyMenuControl
End Namespace ' Examples.VB.WebControls.Design
' </snippet1>
