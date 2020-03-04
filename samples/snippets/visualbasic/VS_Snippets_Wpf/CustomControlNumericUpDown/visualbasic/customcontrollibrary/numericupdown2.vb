Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace CustomControlLibrary
	Public Partial Class NumericUpDown
		Inherits Control

		Shared Sub New()
			InitializeCommands()

			' Listen to MouseLeftButtonDown event to determine if slide should move focus to itself
			EventManager.RegisterClassHandler(GetType(NumericUpDown), Mouse.MouseDownEvent, New MouseButtonEventHandler(AddressOf NumericUpDown.OnMouseLeftButtonDown), True)

			DefaultStyleKeyProperty.OverrideMetadata(GetType(NumericUpDown), New FrameworkPropertyMetadata(GetType(NumericUpDown)))
		End Sub
	End Class
End Namespace
