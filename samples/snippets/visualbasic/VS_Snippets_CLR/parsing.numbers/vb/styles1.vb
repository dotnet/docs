' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim value As String = "1,304"
        Dim number As Integer
        Dim provider As IFormatProvider = CultureInfo.CreateSpecificCulture("en-US")
        If Int32.TryParse(value, number) Then
            Console.WriteLine("{0} --> {1}", value, number)
        Else
            Console.WriteLine("Unable to convert '{0}'", value)
        End If

        If Int32.TryParse(value, NumberStyles.Integer Or NumberStyles.AllowThousands,
                          provider, number) Then
            Console.WriteLine("{0} --> {1}", value, number)
        Else
            Console.WriteLine("Unable to convert '{0}'", value)
        End If
    End Sub
End Module
' The example displays the following output:
'       Unable to convert '1,304'
'       1,304 --> 1304
' </Snippet2>

