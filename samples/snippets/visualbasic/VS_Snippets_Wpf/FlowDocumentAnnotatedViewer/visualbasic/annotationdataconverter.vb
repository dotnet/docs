Imports System.Globalization
Imports System.IO
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Markup

Namespace FlowDocumentAnnotatedReader
	Public Class AnnotationDataConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			' Convert 64 bit binary data into an 8 bit byte array and load
			' it into a memory buffer
			Dim data() As Byte = System.Convert.FromBase64String(TryCast(value, String))
			Using buffer As New MemoryStream(data)
				' Convert memory buffer to object and return text
				Dim section As Section = CType(XamlReader.Load(buffer), Section)
				Dim range As New TextRange(section.ContentStart, section.ContentEnd)
				Return range.Text
			End Using
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
End Namespace