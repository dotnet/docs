' <snippet3>
Imports System
Imports System.Collections

Public Class ExampleClass
    NotInheritable Public Class Path
        Private Sub New()
        End Sub

        Private Shared badChars() As Char = {Chr(34),"<",">"}

        Public Shared Function GetInvalidPathChars() As Char()
            Return badChars
        End Function
    End Class

    Public Shared Sub Main()
        ' The following code displays the elements of the
        ' array as expected.
        Dim c As Char
        For Each c In  Path.GetInvalidPathChars()
            Console.Write(c)
        Next c
        Console.WriteLine()

        ' The following code sets all the values to A.
        Path.GetInvalidPathChars()(0) = "A"
        Path.GetInvalidPathChars()(1) = "A"
        Path.GetInvalidPathChars()(2) = "A"

        ' The following code displays the elements of the array to the
        ' console. Note that the values have changed.
        For Each c In  Path.GetInvalidPathChars()
            Console.Write(c)
        Next c
    End Sub
End Class
' </snippet3>

Public Class DummyColl
    Public myObj As ArrayList

    Public Sub New()
        myObj = New ArrayList(0)
    End Sub
End Class

Public Class Path2
    Private Shared badChars() As Char = {Chr(34),"<",">"}

    ' <snippet4>
    Public Shared Function GetInvalidPathChars() As Char()
        Return CType(badChars.Clone(), Char())
    End Function
    ' </snippet4>

    Public Shared Sub DoSomething(objItem As Object)
    End Sub

    Public Shared Sub Dummy(obj As DummyColl)
        ' <snippet5>
        For i As Integer =0 To obj.myObj.Count -1
            DoSomething(obj.myObj(i))
        Next i
        ' </snippet5>
    End Sub
End Class

Public Class ExampleClass2
    ' <snippet6>
    NotInheritable Public Class Path
        Private Sub New()
        End Sub

        Public Shared InvalidPathChars() As Char = {Chr(34),"<",">","|"}
    End Class
    ' </snippet6>

    Public Class PathTester
        Public Sub Dummy()
            ' <snippet7>
            ' The following code can be used to change the values in the array.
            Path.InvalidPathChars(0) = "A"
            ' </snippet7>
        End Sub

        Public Function SomeOtherFunc() As String
            Return New String("A", 128)
        End Function

        ' <snippet8>
        Public Sub DoSomething()
            Dim s As string = SomeOtherFunc()
            If  s.Length > 0 Then
                ' Do something else.
            End If
        End Sub
        ' </snippet8>
    End Class
End Class
