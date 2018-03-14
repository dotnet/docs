' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs() As String = { _
            "Pachycephalosaurus", _
            "Amargasaurus", _
            "Tyrannosaurus", _
            "Mamenchisaurus", _
            "Deinonychus", _
            "Edmontosaurus"  }

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "Sort")
        Array.Sort(dinosaurs)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "BinarySearch for 'Coelophysis':")
        Dim index As Integer = _
            Array.BinarySearch(dinosaurs, "Coelophysis")
        ShowWhere(dinosaurs, index)

        Console.WriteLine(vbLf & _
            "BinarySearch for 'Tyrannosaurus':")
        index = Array.BinarySearch(dinosaurs, "Tyrannosaurus")
        ShowWhere(dinosaurs, index)

    End Sub

    Private Shared Sub ShowWhere(Of T) _
        (ByVal array() As T, ByVal index As Integer) 

        If index < 0 Then
            ' If the index is negative, it represents the bitwise
            ' complement of the next larger element in the array.
            '
            index = index Xor -1

            Console.Write("Not found. Sorts between: ")

            If index = 0 Then
                Console.Write("beginning of array and ")
            Else
                Console.Write("{0} and ", array(index - 1))
            End If 

            If index = array.Length Then
                Console.WriteLine("end of array.")
            Else
                Console.WriteLine("{0}.", array(index))
            End If 
        Else
            Console.WriteLine("Found at index {0}.", index)
        End If

    End Sub

End Class

' This code example produces the following output:
'
'Pachycephalosaurus
'Amargasaurus
'Tyrannosaurus
'Mamenchisaurus
'Deinonychus
'Edmontosaurus
'
'Sort
'
'Amargasaurus
'Deinonychus
'Edmontosaurus
'Mamenchisaurus
'Pachycephalosaurus
'Tyrannosaurus
'
'BinarySearch for 'Coelophysis':
'Not found. Sorts between: Amargasaurus and Deinonychus.
'
'BinarySearch for 'Tyrannosaurus':
'Found at index 5.
' </Snippet1>