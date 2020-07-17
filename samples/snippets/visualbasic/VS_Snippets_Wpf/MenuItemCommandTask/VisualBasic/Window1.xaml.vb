Namespace SDKSamples
	Partial Public Class Window1
		Inherits Window
		'<SnippetMenuItemCommandingCodeBehind>
		' Window1 constructor
		Public Sub New()
			InitializeComponent()

			' Instantiating UIElements.
			Dim mainPanel As New DockPanel()
			Dim mainMenu As New Menu()
			Dim pasteMenuItem As New MenuItem()
			Dim mainTextBox As New TextBox()

			' Associating the MenuItem with the Paste command.
			pasteMenuItem.Command = ApplicationCommands.Paste

			' Setting properties on the TextBox.
			mainTextBox.Text = "The MenuItem will not be enabled until this TextBox receives keyboard focus."
			mainTextBox.Margin = New Thickness(25)
			mainTextBox.BorderBrush = Brushes.Black
			mainTextBox.BorderThickness = New Thickness(2)
			mainTextBox.TextWrapping = TextWrapping.Wrap

			' Attaching UIElements to the Window.
			Me.AddChild(mainPanel)
			mainMenu.Items.Add(pasteMenuItem)
			mainPanel.Children.Add(mainMenu)
			mainPanel.Children.Add(mainTextBox)

			' Defining DockPanel layout.
			DockPanel.SetDock(mainMenu, Dock.Top)
			DockPanel.SetDock(mainTextBox, Dock.Bottom)
		End Sub
		'</SnippetMenuItemCommandingCodeBehind>

	End Class
End Namespace