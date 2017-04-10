Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media

Namespace ContextMenus

	Partial Public Class Pane1
		Private FlagForCustomContextMenu As Boolean
'<SnippetBuildMenu>
		Private Function BuildMenu() As ContextMenu
			Dim theMenu As New ContextMenu()
			Dim mia As New MenuItem()
			mia.Header = "Item1"
			Dim mib As New MenuItem()
			mib.Header = "Item2"
			Dim mic As New MenuItem()
			mic.Header = "Item3"
			theMenu.Items.Add(mia)
			theMenu.Items.Add(mib)
			theMenu.Items.Add(mic)
			Return theMenu
		End Function
'</SnippetBuildMenu>
'<SnippetAddItemNoHandle>
		Private Sub AddItemToCM(ByVal sender As Object, ByVal e As ContextMenuEventArgs)
			'check if Item4 is already there, this will probably run more than once
			Dim fe As FrameworkElement = TryCast(e.Source, FrameworkElement)
			Dim cm As ContextMenu = fe.ContextMenu
			For Each mi As MenuItem In cm.Items
				If CType(mi.Header, String) = "Item4" Then
					Return
				End If
			Next mi
			Dim mi4 As New MenuItem()
			mi4.Header = "Item4"
			fe.ContextMenu.Items.Add(mi4)
		End Sub
'</SnippetAddItemNoHandle>
'<SnippetReplaceNoReopen>
		Private Sub HandlerForCMO(ByVal sender As Object, ByVal e As ContextMenuEventArgs)
			Dim fe As FrameworkElement = TryCast(e.Source, FrameworkElement)
			fe.ContextMenu = BuildMenu()
		End Sub
'</SnippetReplaceNoReopen>
'<SnippetReplaceReopen>
		Private Sub HandlerForCMO2(ByVal sender As Object, ByVal e As ContextMenuEventArgs)
			If Not FlagForCustomContextMenu Then
				e.Handled = True 'need to suppress empty menu
				Dim fe As FrameworkElement = TryCast(e.Source, FrameworkElement)
				fe.ContextMenu = BuildMenu()
				FlagForCustomContextMenu = True
				fe.ContextMenu.IsOpen = True
			End If
		End Sub
	End Class
'</SnippetReplaceReopen>
'<SnippetClassHandler>
	Public Class MyButton
		Inherits Button
		Protected Overrides Sub OnContextMenuOpening(ByVal e As ContextMenuEventArgs)
			MyBase.OnContextMenuOpening(e)
			Dim buttonMenu As New ContextMenu()
			Dim mia As New MenuItem()
			mia.Header = "Item1"
			Dim mib As New MenuItem()
			mib.Header = "Item2"
			Dim mic As New MenuItem()
			mic.Header = "Item3"
			buttonMenu.Items.Add(mia)
			buttonMenu.Items.Add(mib)
			buttonMenu.Items.Add(mic)
			Dim fe As FrameworkElement = TryCast(e.Source, FrameworkElement)
			fe.ContextMenu = buttonMenu
		End Sub
	End Class
'</SnippetClassHandler>
End Namespace