Module Module1

    Sub Main()

    End Sub

    Sub method2()
        ' <Snippet2>
        Dim i? As Integer = Nothing
        Dim j? As Integer = Nothing
        If i = j Then
            '  This branch is executed.
        End If
        ' </Snippet2>

    End Sub

    Sub method3()
        Dim i As Integer = 0
        Dim j As Integer = 0

        ' <Snippet3>
        If (i = j) Or (i <> j) Then ' Redundant condition.
            ' ...
        End If
        ' </Snippet3>

    End Sub

    Sub method5()
        ' <Snippet5>
        ' Does not apply.
        ' Visual Basic overflow in absence of implicit check
        ' (turn off overflow checks in compiler options)
        Dim I As Integer = Int32.MaxValue
        Dim j As Integer = 5
        If I + j < 0 Then
            ' This code prints the overflow message.
            Console.WriteLine("Overflow!")
        End If
        ' </Snippet5>

    End Sub

    Sub method6()
        ' <Snippet6>
        ' Visual Basic equivalent on collections of Strings in place of
        ' nvarchars.
        Dim strings() As String = {"food", "FOOD"}
        For Each s As String In strings
            If s = "food" Then
                Console.WriteLine(s)
            End If
        Next
        ' Only "food" is returned.
        ' </Snippet6>

    End Sub

    Sub method7()
        ' <Snippet7>
        ' Assume Like(String, String) method.
        Dim s As String    ' Map to T4.Col1.
        If s Like (System.Data.Linq.SqlClient.SqlMethods.Like(s, "%1")) Then
            Console.WriteLine(s)
        End If
        ' Expected to return true for both "21" and "1021".
        ' </Snippet7>


    End Sub

End Module

' <Snippet1>
Class C1
    Dim x As Integer        ' Map to T1.Col1
    Dim y As Integer        ' Map to T1.Col2
End Class
' </Snippet1>

' <Snippet4>
Class C
    Dim s1 As String    ' Map to T2.Col1.
    Dim s2 As String    ' Map to T2.Col2.
    Sub Compare()
        If s1 = s2 Then ' This is correct.
            ' ...
        End If
    End Sub
End Class
' </Snippet4>

Namespace ns
    ' <Snippet8>
    Class C
        Dim x As Integer        ' Map to T5.Col1.
        Dim y As Integer        ' Map to T5.Col2.

        Sub Casting()
            ' Intended predicate.
            If (x + y) > 4 Then
                ' Valid for the data above.
            End If
        End Sub
    End Class
    ' </Snippet8>


End Namespace

Namespace ns3
    ' <Snippet9>
    Class C5
        Dim s As String ' Map to T5.Col1.
    End Class
    ' </Snippet9>

End Namespace
