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

	' One-way conversion between ColorItem.Source and bool -
	' used to disable editing for builtin colors

	Public Class SourceToBoolConverter
		Implements IValueConverter
		Private Function Convert(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim source As ColorItem.Sources = CType(o, ColorItem.Sources)
			Return (source <> ColorItem.Sources.BuiltIn)
		End Function

		Private Function ConvertBack(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
End Namespace
