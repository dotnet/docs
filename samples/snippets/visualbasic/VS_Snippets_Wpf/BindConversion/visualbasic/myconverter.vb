Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Data
Imports System.Windows.Media

Namespace SDKSample
	'<Snippet4>
	Public Class MyConverter
		Implements IValueConverter
		Public Function Convert(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim [date] As Date = CDate(o)
			Select Case culture.TwoLetterISOLanguageName
				Case "en"
					Select Case type.Name
						Case "String"
							Return "Today is " & [date].ToString("F", culture)
						Case "Brush"
							Return Brushes.Blue
					End Select
				Case "es"
					Select Case type.Name
						Case "String"
							Return "Hoy es " & [date].ToString("F", culture)
						Case "Brush"
							Return Brushes.Orange
					End Select
				Case "de"
					Select Case type.Name
						Case "String"
							Return "Heute ist " & [date].ToString("F", culture)
						Case "Brush"
							Return Brushes.Green
					End Select
				Case "fr"
					Select Case type.Name
						Case "String"
							Return "Aujourd'hui est " & [date].ToString("F", culture)
						Case "Brush"
							Return Brushes.Red
					End Select
			End Select
			Return Nothing
		End Function

		Public Function ConvertBack(ByVal o As Object, ByVal type As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
	'</Snippet4>
End Namespace