' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class TelephoneFormatter : Implements IFormatProvider, ICustomFormatter
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If               
   End Function               

   Public Function Format(fmt As String, arg As Object, _
                          formatProvider As IFormatProvider) As String _
                   Implements ICustomFormatter.Format
      ' Check whether this is an appropriate callback             
      If Not Me.Equals(formatProvider) Then Return Nothing 

      ' Set default format specifier             
      If String.IsNullOrEmpty(fmt) Then fmt = "N"

      Dim numericString As String = arg.ToString
      
      If fmt = "N" Then
         Select Case numericString.Length
            Case <= 4 
               Return numericString
            Case 7
               Return Left(numericString, 3) & "-" & Mid(numericString, 4) 
            Case 10
               Return "(" & Left(numericString, 3) & ") " & _
                      Mid(numericString, 4, 3) & "-" & Mid(numericString, 7)   
            Case Else
               Throw New FormatException( _
                         String.Format("'{0}' cannot be used to format {1}.", _
                                       fmt, arg.ToString()))
         End Select
      ElseIf fmt = "I" Then
         If numericString.Length < 10 Then
            Throw New FormatException(String.Format("{0} does not have 10 digits.", arg.ToString()))
         Else
            numericString = "+1 " & Left(numericString, 3) & " " & Mid(numericString, 4, 3) & " " & Mid(numericString, 7)
         End If      
      Else
         Throw New FormatException(String.Format("The {0} format specifier is invalid.", fmt))
      End If 
      Return numericString  
   End Function
End Class

Public Module TestTelephoneFormatter
   Public Sub Main
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0}", 0))
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0}", 911))
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0}", 8490216))
      ' <Snippet3>
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0}", 4257884748))
      ' </Snippet3>
      
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0:N}", 0))
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0:N}", 911))
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0:N}", 8490216))
      ' <Snippet2>
      Console.WriteLine(String.Format(New TelephoneFormatter, "{0:N}", 4257884748))
      ' </Snippet2>

      Console.WriteLine(String.Format(New TelephoneFormatter, "{0:I}", 4257884748))
   End Sub
End Module
' </Snippet1>


