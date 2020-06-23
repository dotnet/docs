' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
    Public Sub Main()
        Dim value As String
        ' Define a string of basic Latin digits 1-5.
        value = ChrW(&h31) + ChrW(&h32) + ChrW(&h33) + ChrW(&h34) + ChrW(&h35)
        ParseDigits(value)

        ' Define a string of Fullwidth digits 1-5.
        value = ChrW(&hff11) + ChrW(&hff12) + ChrW(&hff13) + ChrW(&hff14) + ChrW(&hff15)
        ParseDigits(value)

        ' Define a string of Arabic-Indic digits 1-5.
        value = ChrW(&h661) + ChrW(&h662) + ChrW(&h663) + ChrW(&h664) + ChrW(&h665)
        ParseDigits(value)

        ' Define a string of Bangla digits 1-5.
        value = ChrW(&h09e7) + ChrW(&h09e8) + ChrW(&h09e9) + ChrW(&h09ea) + ChrW(&h09eb)
        ParseDigits(value)
    End Sub

    Sub ParseDigits(value As String)
        Try
            Dim number As Integer = Int32.Parse(value)
            Console.WriteLine("'{0}' --> {1}", value, number)
        Catch e As FormatException
            Console.WriteLine("Unable to parse '{0}'.", value)
        End Try
    End Sub
End Module
' The example displays the following output:
'       '12345' --> 12345
'       Unable to parse '１２３４５'.
'       Unable to parse '١٢٣٤٥'.
'       Unable to parse '১২৩৪৫'.
' </Snippet3>

