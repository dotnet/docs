'<snippet1>
' This code example demonstrates the Nullable(Of T).Equals 
' methods.

Imports System

Class Sample
    Public Shared Sub Main() 
        Dim nullInt1 As Nullable(Of Integer) = 100 
        Dim nullInt2 As Nullable(Of Integer) = 200
        Dim myObj As Object
        
    ' Determine if two nullable of System.Int32 values are equal. 
    ' The nullable objects have different values.
        Console.Write("1) nullInt1 and nullInt2 ")
        If nullInt1.Equals(nullInt2) Then
            Console.Write("are")
        Else
            Console.Write("are not")
        End If
        Console.WriteLine(" equal.")
        
    ' Determine if a nullable of System.Int32 and an object 
    ' are equal. The object contains the boxed value of the
    ' nullable object.
        myObj = CType(nullInt1, Object)
        Console.Write("2) nullInt1 and myObj ")
        If nullInt1.Equals(myObj) Then
            Console.Write("are")
        Else
            Console.Write("are not")
        End If
        Console.WriteLine(" equal.")
    End Sub 'Main 
End Class 'Sample

'
'This code example produces the following results:
'
'1) nullInt1 and nullInt2 are not equal.
'2) nullInt1 and myObj are equal.
'
'</snippet1>