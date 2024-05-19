' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module TestFormatter
   Public Sub Main()
      Dim acctNumber As Integer = 79203159
      Console.WriteLine(String.Format(New CustomerFormatter, "{0}", acctNumber))
      Console.WriteLine(String.Format(New CustomerFormatter, "{0:G}", acctNumber))
      Console.WriteLine(String.Format(New CustomerFormatter, "{0:S}", acctNumber))
      Console.WriteLine(String.Format(New CustomerFormatter, "{0:P}", acctNumber))
      Try
         Console.WriteLine(String.Format(New CustomerFormatter, "{0:X}", acctNumber))
      Catch e As FormatException
         Console.WriteLine(e.Message)
      End Try   
   End Sub
End Module

Public Class CustomerFormatter : Implements IFormatProvider, ICustomFormatter
   Public Function GetFormat(type As Type) As Object  _
                   Implements IFormatProvider.GetFormat
      If type Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If
   End Function
   
   Public Function Format(fmt As String, _
	                       arg As Object, _
	                       formatProvider As IFormatProvider) As String _
	                Implements ICustomFormatter.Format
      If Not Me.Equals(formatProvider) Then
         Return Nothing
      Else
         If String.IsNullOrEmpty(fmt) Then fmt = "G"
         
         Dim customerString As String = arg.ToString()
         if customerString.Length < 8 Then _
            customerString = customerString.PadLeft(8, "0"c)
         
         Select Case fmt
            Case "G"
               Return customerString.Substring(0, 1) & "-" & _
                                     customerString.Substring(1, 5) & "-" & _
                                     customerString.Substring(6)
            Case "S"                         
               Return customerString.Substring(0, 1) & "/" & _
                                     customerString.Substring(1, 5) & "/" & _
                                     customerString.Substring(6)
            Case "P"
               Return customerString.Substring(0, 1) & "." & _
                                     customerString.Substring(1, 5) & "." & _
                                     customerString.Substring(6)
            Case Else
               Throw New FormatException( _
                         String.Format("The '{0}' format specifier is not supported.", fmt))
         End Select                                                     
      End If   
   End Function
End Class
' The example displays the following output:
'       7-92031-59
'       7-92031-59
'       7/92031/59
'       7.92031.59
'       The 'X' format specifier is not supported.
' </Snippet2>
