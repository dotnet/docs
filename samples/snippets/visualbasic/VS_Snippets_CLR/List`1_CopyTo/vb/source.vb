' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs As New List(Of String)

        dinosaurs.Add("Tyrannosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Brachiosaurus")
        dinosaurs.Add("Compsognathus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        ' Declare an array with 15 elements (0 through 14).
        Dim array(14) As String

        dinosaurs.CopyTo(array)
        dinosaurs.CopyTo(array, 6)
        dinosaurs.CopyTo(2, array, 12, 3)

        Console.WriteLine(vbLf & "Contents of the array:")
        For Each dinosaur As String In array
            Console.WriteLine(dinosaur)
        Next

    End Sub
End Class

' This code example produces the following output:
'
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Brachiosaurus
'Compsognathus
'
'Contents of the array:
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Brachiosaurus
'Compsognathus
'
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Brachiosaurus
'Compsognathus
'
'Mamenchisaurus
'Brachiosaurus
'Compsognathus
' </Snippet1>