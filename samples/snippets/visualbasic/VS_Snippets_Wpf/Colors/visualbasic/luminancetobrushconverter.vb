Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Globalization
Imports System.Reflection
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media


Namespace SDKSample
	' One-way conversion between Luminance and Brush - used to draw text in
	' a color tile using a color that contrasts with the background

	Public Class LuminanceToBrushConverter
		Implements IValueConverter
		Private Function Convert(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim luminance As Double = CDbl(o)
			Return If((luminance < 0.5), Brushes.White, Brushes.Black)
		End Function

		Private Function ConvertBack(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
End Namespace
