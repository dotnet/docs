Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Configuration
Imports System.ComponentModel
Imports System.Windows.Media
Imports System.Windows.Data

Namespace ColorPickerApp
	''' <summary>
	''' Interaction logic for MyApp.xaml
	''' </summary>

	Partial Public Class MyApp
		Inherits Application
		Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()
		End Sub



	End Class
	Public Class ColorGradientConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
			Dim param As String = TryCast(parameter, String)
			Dim color As Color = CType(value, Color)
			If param IsNot Nothing Then
				Select Case param
					Case "Red"
						Return New LinearGradientBrush(Color.FromRgb(0, color.G, color.B), Color.FromRgb(255, color.G, color.B), 0)
					Case "Green"
						Return New LinearGradientBrush(Color.FromRgb(color.R, 0, color.B), Color.FromRgb(color.R, 255, color.B), 0)
					Case "Blue"
						Return New LinearGradientBrush(Color.FromRgb(color.R, color.G, 0), Color.FromRgb(color.R, color.G, 255), 0)
					Case Else
						Throw New ArgumentException("not valid value", "parameter")
				End Select
			End If
			Throw New ArgumentException("parameter not a string")
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotSupportedException()
		End Function

	End Class
End Namespace