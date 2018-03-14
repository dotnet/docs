Imports System
Imports System.Windows
Imports System.Data
Imports System.Xml
Imports System.Configuration
Imports System.Diagnostics
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents

Namespace SDKSample
	Partial Public Class app
		Inherits Application
		Protected Overrides Sub OnStartup(ByVal args As StartupEventArgs)
			Dim w As New Window()
			w.Width = 640
			w.Height = 480

			Dim panel As New StackPanel()

			Dim richTextBox As New RichTextBox()
			richTextBox.ContextMenu = New MyContextMenu(richTextBox)
			richTextBox.Document.Blocks.Clear()
			richTextBox.Document.Blocks.Add(New Paragraph(New Run("Right-click or use the Shift-F10 context menu shortcut to open the custom context menu.")))

			' When custom context menu is invoked via keyboard {Shift+F10} or properties key,
			' default ContextMenuOpening event places it in center of the RichTextBox window.
			' Listen to the ContextMenuOpening event to override this behavior.
			' <Snippet_AddListener>
			AddHandler richTextBox.ContextMenuOpening, AddressOf richTextBox_ContextMenuOpening
			' </Snippet_AddListener>

			panel.Children.Add(richTextBox)
			w.Content = panel
			w.Show()
		End Sub

		' <Snippet_ListenerBody>
		' This method is intended to listen for the ContextMenuOpening event from a RichTextBox.
		' It will position the custom context menu at the end of the current selection.
		Private Sub richTextBox_ContextMenuOpening(ByVal sender As Object, ByVal e As ContextMenuEventArgs)
			' Sender must be RichTextBox.
			Dim rtb As RichTextBox = TryCast(sender, RichTextBox)
			If rtb Is Nothing Then
				Return
			End If

			Dim contextMenu As ContextMenu = rtb.ContextMenu
			contextMenu.PlacementTarget = rtb

			' This uses HorizontalOffset and VerticalOffset properties to position the menu,
			' relative to the upper left corner of the parent element (RichTextBox in this case).
			contextMenu.Placement = PlacementMode.RelativePoint

			' Compute horizontal and vertical offsets to place the menu relative to selection end.
			Dim position As TextPointer = rtb.Selection.End

			If position Is Nothing Then
				Return
			End If

			Dim positionRect As Rect = position.GetCharacterRect(LogicalDirection.Forward)
			contextMenu.HorizontalOffset = positionRect.X
			contextMenu.VerticalOffset = positionRect.Y

			' Finally, mark the event has handled.
			contextMenu.IsOpen = True
			e.Handled = True
		End Sub
		' </Snippet_ListenerBody>
	End Class

	Public Class MyContextMenu
		Inherits ContextMenu
		Private _rtb As RichTextBox

		Public Sub New(ByVal rtb As RichTextBox)
			MyBase.New()
			_rtb = rtb

			' Add menu items for formatting selected text
			Dim menuItemBold As New MenuItem()
			menuItemBold.Header = "Bold"
			menuItemBold.Command = EditingCommands.ToggleBold
			Me.Items.Add(menuItemBold)

			Dim menuItemItalic As New MenuItem()
			menuItemItalic.Header = "Italic"
			menuItemItalic.Command = EditingCommands.ToggleItalic
			Me.Items.Add(menuItemItalic)

			Dim menuItemUnderline As New MenuItem()
			menuItemUnderline.Header = "Underline"
			menuItemUnderline.Command = EditingCommands.ToggleUnderline
			Me.Items.Add(menuItemUnderline)
		End Sub
	End Class
End Namespace
