' <Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet

' The DropDownNavigationPath is a class that extends the SiteMapPath
' control and renders a DropDownList after the CurrentNode. The
' DropDownList displays a list of pages found further down the site map
' hierarchy from the current one. Selecting an item in the DropDownList
' redirects to that page.
'
' For simplicity, the DropDownNavigationPath assumes the
' RootToCurrent PathDirection, and does not apply styles
' or templates the current node.
'
<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
Public Class DropDownNavigationPath
   Inherits SiteMapPath

   ' <Snippet2>
   ' Override the InitializeItem method to add a PathSeparator
   ' and DropDownList to the current node.
   Protected Overrides Sub InitializeItem(item As SiteMapNodeItem)

      ' The only node that must be handled is the CurrentNode.
      If item.ItemType = SiteMapNodeItemType.Current Then
         Dim hLink As New HyperLink()

         ' No Theming for the HyperLink.
         hLink.EnableTheming = False
         ' Enable the link of the SiteMapPath is enabled.
         hLink.Enabled = Me.Enabled

         ' Set the properties of the HyperLink to
         ' match those of the corresponding SiteMapNode.
         hLink.NavigateUrl = item.SiteMapNode.Url
         hLink.Text = item.SiteMapNode.Title
         If ShowToolTips Then
            hLink.ToolTip = item.SiteMapNode.Description
         End If

         ' Apply styles or templates to the HyperLink here.
         ' ...
         ' ...
         ' Add the item to the Controls collection.
         item.Controls.Add(hLink)

         AddDropDownListAfterCurrentNode(item)
      Else
         MyBase.InitializeItem(item)
      End If
   End Sub 'InitializeItem

   ' </Snippet2>
   ' <Snippet3>
   Private Sub AddDropDownListAfterCurrentNode(item As SiteMapNodeItem)

      Dim childNodes As SiteMapNodeCollection = item.SiteMapNode.ChildNodes

      ' Only do this work if there are child nodes.
      If Not (childNodes Is Nothing) Then

         ' Add another PathSeparator after the CurrentNode.
         Dim finalSeparator As New SiteMapNodeItem(item.ItemIndex, SiteMapNodeItemType.PathSeparator)

         Dim eventArgs As New SiteMapNodeItemEventArgs(finalSeparator)

         InitializeItem(finalSeparator)
         ' Call OnItemCreated every time a SiteMapNodeItem is
         ' created and initialized.
         OnItemCreated(eventArgs)

         ' The pathSeparator does not bind to any SiteMapNode, so
         ' do not call DataBind on the SiteMapNodeItem.
         item.Controls.Add(finalSeparator)

         ' Create a DropDownList and populate it with the children of the
         ' CurrentNode. There are no styles or templates that are applied
         ' to the DropDownList control. If OnSelectedIndexChanged is raised,
         ' the event handler redirects to the page selected.
         ' The CurrentNode has child nodes.
         Dim ddList As New DropDownList()
         ddList.AutoPostBack = True

         AddHandler ddList.SelectedIndexChanged, AddressOf Me.DropDownNavPathEventHandler

         ' Add a ListItem to the DropDownList for every node in the
         ' SiteMapNodes collection.
         Dim node As SiteMapNode
         For Each node In  childNodes
            ddList.Items.Add(New ListItem(node.Title, node.Url))
         Next node

         item.Controls.Add(ddList)
      End If
   End Sub 'AddDropDownListAfterCurrentNode

   ' </Snippet3>
   ' The sender is the DropDownList.
   Private Sub DropDownNavPathEventHandler(sender As Object, e As EventArgs)
      Dim ddL As DropDownList = CType(sender, DropDownList)

      ' Redirect to the page the user chose.
      If Not (Context Is Nothing) Then
         Context.Response.Redirect(ddL.SelectedValue)
      End If

   End Sub 'DropDownNavPathEventHandler
End Class 'DropDownNavigationPath
End Namespace
' </Snippet1>