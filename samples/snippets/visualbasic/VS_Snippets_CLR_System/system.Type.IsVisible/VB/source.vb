'<Snippet1>
Imports System

Friend Class InternalOnly
    Public Class Nested
    End Class
End Class

Public Class Example
    Public Class Nested
    End Class

    Public Shared Sub Main()
        With GetType(InternalOnly.Nested)
            Console.WriteLine("Is the " & .FullName _ 
                & " class visible outside the assembly? " & .IsVisible)
        End With

        With GetType(Example.Nested)
            Console.WriteLine("Is the " & .FullName _ 
                & " class visible outside the assembly? " & .IsVisible)
        End With
    End Sub
End Class

' This example produces the following output:
'
'Is the InternalOnly+Nested class visible outside the assembly? False
'Is the Example+Nested class visible outside the assembly? True
'</Snippet1>
