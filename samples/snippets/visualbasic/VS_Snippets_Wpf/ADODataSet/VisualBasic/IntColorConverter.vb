Imports System.Collections.Generic
Imports System.Windows.Data
Imports System.Globalization

Namespace SDKSample
	Public Class IntColorConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim numValue As Integer = CInt(Fix(value))
			If numValue < 350 Then
				Return System.Windows.Media.Brushes.Green
			Else
				Return System.Windows.Media.Brushes.Red
			End If
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
End Namespace
