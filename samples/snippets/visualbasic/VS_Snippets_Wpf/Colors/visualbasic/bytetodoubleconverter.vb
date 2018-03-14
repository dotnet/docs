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
	' Two-way conversion between byte and double (TypeConverter for double should provide this)

	Public Class ByteToDoubleConverter
		Implements IValueConverter
		Private Function Convert(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return System.Convert.ChangeType(o, GetType(Double))
		End Function

		Private Function ConvertBack(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Dim d As Double = CDbl(o)
            Return If((d < 0.0), CByte(0), If((d > 255.0), CByte(255), System.Convert.ChangeType(o, GetType(Byte))))
		End Function
	End Class
End Namespace
