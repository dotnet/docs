Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.CustomControls
	''' <summary>
	''' Interaction logic for ColorPickerDialog.xaml
	''' </summary>

	Partial Public Class ColorPickerDialog
		Inherits Window


		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub okButtonClicked(ByVal sender As Object, ByVal e As RoutedEventArgs)

			OKButton.IsEnabled = False
            _color = cPicker.SelectedColor
			DialogResult = True
			Hide()

		End Sub


		Private Sub cancelButtonClicked(ByVal sender As Object, ByVal e As RoutedEventArgs)

			OKButton.IsEnabled = False
			DialogResult = False

		End Sub

		Private Sub onSelectedColorChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Color))

            If e.NewValue <> _color Then
                OKButton.IsEnabled = True
            End If
		End Sub

		Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)

			OKButton.IsEnabled = False
			MyBase.OnClosing(e)
		End Sub


        Private _color As New Color()
        Private _startingColor As New Color()

		Public ReadOnly Property SelectedColor() As Color
			Get
                Return _color
			End Get

		End Property

		Public Property StartingColor() As Color
			Get
                Return _startingColor
			End Get
			Set(ByVal value As Color)
				'cPicker.SelectedColor = value
				OKButton.IsEnabled = False
			End Set

		End Property


	End Class
End Namespace