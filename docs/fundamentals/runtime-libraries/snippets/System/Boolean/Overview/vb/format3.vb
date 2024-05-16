' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example4
    Public Sub Main()
        Dim cultureNames() As String = {"", "en-US", "fr-FR", "ru-RU"}
        For Each cultureName In cultureNames
            Dim value As Boolean = True
            Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture(cultureName)
            Dim formatter As New BooleanFormatter(culture)

            Dim result As String = String.Format(formatter, "Value for '{0}': {1}", culture.Name, value)
            Console.WriteLine(result)
        Next
    End Sub
End Module

Public Class BooleanFormatter 
   Implements ICustomFormatter, IFormatProvider
   
   Private culture As CultureInfo
   
   Public Sub New()
      Me.New(CultureInfo.CurrentCulture)
   End Sub
   
   Public Sub New(culture As CultureInfo)
      Me.culture = culture 
   End Sub
   
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If                
   End Function
   
   Public Function Format(fmt As String, arg As Object, 
                          formatProvider As IFormatProvider) As String _
                   Implements ICustomFormatter.Format
      ' Exit if another format provider is used.
      If Not formatProvider.Equals(Me) Then Return Nothing
      
      ' Exit if the type to be formatted is not a Boolean
      If Not TypeOf arg Is Boolean Then Return Nothing
      
      Dim value As Boolean = CBool(arg)
      Select culture.Name
         Case "en-US"
            Return value.ToString()
         Case "fr-FR"
            If value Then
               Return "vrai"
            Else
               Return "faux"
            End If      
         Case "ru-RU"
            If value Then
               Return "верно"
            Else
               Return "неверно"
            End If   
         Case Else
            Return value.ToString()  
      End Select
   End Function
End Class
' The example displays the following output:
'          Value for '': True
'          Value for 'en-US': True
'          Value for 'fr-FR': vrai
'          Value for 'ru-RU': верно
' </Snippet5>   
