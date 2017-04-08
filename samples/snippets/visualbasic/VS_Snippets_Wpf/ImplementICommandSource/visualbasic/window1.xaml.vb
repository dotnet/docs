Imports System.Globalization

Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Shared FontUpdateCommand As New RoutedCommand()

		Public Sub New()
			InitializeComponent()
		End Sub

		' The ExecutedRoutedEvent Handler
		' If the command target is the TextBox, changes the fontsize to that
		' Of the value passed in through the Command Parameter
		Private Sub SliderUpdateExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Dim source As TextBox = TryCast(sender, TextBox)

			If source IsNot Nothing Then
				If e.Parameter IsNot Nothing Then
					Try
						If CInt(Fix(e.Parameter)) > 0 AndAlso CInt(Fix(e.Parameter)) <= 60 Then
							source.FontSize = CInt(Fix(e.Parameter))
						End If
					Catch
                        MessageBox.Show("in Command " & vbLf & " Parameter: " & e.Parameter.ToString)
					End Try

				End If
			End If
		End Sub

		' The CanExecuteRoutedEvent Handler
        ' If the Command Source is a TextBox, then set CanExecute to true
		' Otherwise, set it to false
		Private Sub SliderUpdateCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			Dim source As TextBox = TryCast(sender, TextBox)

			If source IsNot Nothing Then
				If source.IsReadOnly Then
					e.CanExecute = False
				Else
					e.CanExecute = True
				End If

			End If
		End Sub

		' If the Readonly Box is checked, we need to force the CommandManager
		' To raise the RequerySuggested event.  This will cause the Command Source
		' To query the command to see if it can execute or not.
		Private Sub OnReadOnlyChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If txtBoxTarget IsNot Nothing Then
				txtBoxTarget.IsReadOnly = True
				CommandManager.InvalidateRequerySuggested()
			End If
		End Sub

		' If the Readonly Box is checked, we need to force the CommandManager
		' To raise the RequerySuggested event.  This will cause the Command Source
		' To query the command to see if it can execute or not.
		Private Sub OnReadOnlyUnChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If txtBoxTarget IsNot Nothing Then
				txtBoxTarget.IsReadOnly = False
				Me.UpdateLayout()
				CommandManager.InvalidateRequerySuggested()
			End If
		End Sub

		' CanExecute handler for the IncreaseSamll and DescreaseSmall commands.
		' Disables the command sources if the Slider is disabled.  
		Private Sub IncreaseDecreaseCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			Dim target As Slider = TryCast(e.Source, Slider)
			If target IsNot Nothing Then
				If target.IsEnabled = True Then
					e.CanExecute = True
					e.Handled = True
				Else
					e.CanExecute = False
					e.Handled = True
				End If
			End If
		End Sub
	End Class


	' Converter to convert the Slider value property to an int.
	<ValueConversion(GetType(Double), GetType(Integer))>
	Public Class FontStringValueConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim fontSize As String = CStr(value)
			Dim intFont As Integer

			Try
				intFont = Int32.Parse(fontSize)
				Return intFont
			Catch e As FormatException
				Return Nothing
			End Try
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class

	' Converter to convert the Slider value property to an int.
	<ValueConversion(GetType(Double), GetType(Integer))>
	Public Class FontDoubleValueConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim fontSize As Double = CDbl(value)
			Return CInt(fontSize)
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
End Namespace