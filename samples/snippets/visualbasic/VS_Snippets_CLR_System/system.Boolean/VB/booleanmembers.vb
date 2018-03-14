
Imports System

Public Class BooleanMembers
    
    Public Shared Sub Main()
        ' <Snippet1>
        Dim raining As Boolean = False
        Dim busLate As Boolean = True
        
        Console.WriteLine("raining.ToString() returns {0}", raining)
        Console.WriteLine("busLate.ToString() returns {0}", busLate)
        ' The example displays the following output:
        '       raining.ToString() returns False
        '       busLate.ToString() returns True
        ' </Snippet1>

        ' <Snippet2>
        Dim val As Boolean
        Dim input As String
        
        input = Boolean.TrueString
        val = Boolean.Parse(input)
        Console.WriteLine("'{0}' parsed as {1}", input, val)
        ' The example displays the following output:
        '       'True' parsed as True
        ' </Snippet2>
    End Sub 
End Class 
