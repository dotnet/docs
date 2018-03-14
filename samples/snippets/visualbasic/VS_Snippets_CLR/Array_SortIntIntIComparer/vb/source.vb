' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class ReverseComparer
    Implements IComparer(Of String)

    Public Function Compare(ByVal x As String, _
        ByVal y As String) As Integer _
        Implements IComparer(Of String).Compare

        ' Compare y and x in reverse order.
        Return y.CompareTo(x)

    End Function
End Class

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs() As String = { _
            "Pachycephalosaurus", _
            "Amargasaurus", _
            "Mamenchisaurus", _
            "Tarbosaurus", _
            "Tyrannosaurus", _
            "Albertasaurus"  }

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "Sort(dinosaurs, 3, 3)")
        Array.Sort(dinosaurs, 3, 3)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Dim rc As New ReverseComparer()

        Console.WriteLine(vbLf & "Sort(dinosaurs, 3, 3, rc)")
        Array.Sort(dinosaurs, 3, 3, rc)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

    End Sub

End Class

' This code example produces the following output:
'
'Pachycephalosaurus
'Amargasaurus
'Mamenchisaurus
'Tarbosaurus
'Tyrannosaurus
'Albertasaurus
'
'Sort(dinosaurs, 3, 3)
'
'Pachycephalosaurus
'Amargasaurus
'Mamenchisaurus
'Albertasaurus
'Tarbosaurus
'Tyrannosaurus
'
'Sort(dinosaurs, 3, 3, rc)
'
'Pachycephalosaurus
'Amargasaurus
'Mamenchisaurus
'Tyrannosaurus
'Tarbosaurus
'Albertasaurus
' </Snippet1>