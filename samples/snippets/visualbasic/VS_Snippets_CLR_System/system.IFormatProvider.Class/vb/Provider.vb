' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Public Enum DaysOfWeek As Long
   Monday = 1
   Tuesday = 2
End Enum

Module TestFormatting
   Public Sub Main()
      Dim acctNumber As Long, balance As Double 
      Dim wday As DaysOfWeek 
      Dim output As String

      acctNumber = 104254567890
      balance = 16.34
      wday = DaysOfWeek.Monday

      output = String.Format(New AcctNumberFormat(), "On {2}, the balance of account {0:H} was {1:C2}.", acctNumber, balance, wday)
      Console.WriteLine(output)

      wday = DaysOfWeek.Tuesday
      output = String.Format(New AcctNumberFormat(), "On {2}, the balance of account {0:I} was {1:C2}.", acctNumber, balance, wday)
      Console.WriteLine(output)
   End Sub
End Module
' The example displays the following output:
'    On Monday, the balance of account 10425-456-7890 was $16.34.
'    On Tuesday, the balance of account 104254567890 was $16.34.
' </Snippet1>

' <Snippet2>
Public Class AcctNumberFormat : Implements IFormatProvider, ICustomFormatter

   Private Const ACCT_LENGTH As Integer = 12
   
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      Else
         Return Nothing
      End If
   End Function
   
   Public Function Format(fmt As String, arg As Object, formatProvider As IFormatProvider) As String _
                          Implements ICustomFormatter.Format

      ' Provide default formatting if arg is not an Int64.
       If Not TypeOf arg Is Int64 Then
         Try 
            Return HandleOtherFormats(fmt, arg) 
         Catch e As FormatException 
            Throw New FormatException(String.Format("The format of '{0}' is invalid.", fmt), e)
         End Try
       End If   
                     
      ' Provider default formatting for unsupported format strings.
      Dim ufmt As String = fmt.ToUpper(CultureInfo.InvariantCulture)
      If Not (ufmt = "H" Or ufmt = "I") Then
         Try
            Return HandleOtherFormats(fmt, arg)
         Catch e As FormatException 
            Throw New FormatException(String.Format("The format of '{0}' is invalid.", fmt), e)
         End Try
      End If   

      ' Convert argument to a string.
      Dim result As String = arg.ToString()
      
      ' If account number is less than 12 characters, pad with leading zeroes.
      If result.Length < ACCT_LENGTH Then result = result.PadLeft(ACCT_LENGTH, "0"c)
      ' If account number is more than 12 characters, truncate to 12 characters.
      If result.Length > ACCT_LENGTH Then result = Left(result, ACCT_LENGTH)   
      
      If ufmt = "I"                              ' Integer-only format.
         Return result
      ' Add hyphens for H format specifier.
      Else                                       ' Hypenated format.
         Return Left(result, 5) & "-" & Mid(result, 6, 3) & "-" & Right(result, 4)
      End If   
   End Function   

   Private Function HandleOtherFormats(fmt As String, arg As Object) As String
      If TypeOf arg Is IFormattable Then
         Return DirectCast(arg, IFormattable).ToString(fmt, CultureInfo.CurrentCulture)
      ElseIf arg IsNot Nothing Then
         Return arg.ToString()
      Else
         Return String.Empty
      End If
   End Function
End Class
' </Snippet2>

