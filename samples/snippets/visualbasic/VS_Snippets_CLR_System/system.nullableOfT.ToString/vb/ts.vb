'<snippet1>
' This code example demonstrates the 
' Nullable<T>.ToString method.

Imports System

Class Sample
    Public Shared Sub Main() 
        Dim nullableDate As Nullable(Of DateTime)
    ' Display the current date and time.
        nullableDate = DateTime.Now
        Display("1)", nullableDate)
        
    ' Assign null (Nothing in Visual Basic) to nullableDate, then 
    ' display its value.
        nullableDate = Nothing
        Display("2)", nullableDate)
    End Sub 'Main

    '  Display the text representation of a nullable DateTime.
    Public Shared Sub Display(ByVal title As String, _
                              ByVal dspDT As Nullable(Of DateTime))
        Dim msg As String = dspDT.ToString()

        Console.Write("{0} ", title)
        If String.IsNullOrEmpty(msg) Then
            Console.WriteLine("The nullable DateTime has no defined value.")
        Else
            Console.WriteLine("The current date and time is {0}.", msg)
        End If
    End Sub 'Display 
End Class 'Sample

'This code example produces the following results:
'
'1) The current date and time is 4/19/2005 8:28:14 PM.
'2) The nullable DateTime has no defined value.
'
'</snippet1>