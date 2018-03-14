' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs As New List(Of String)

        dinosaurs.Add("Pachycephalosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Deinonychus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "Sort")
        dinosaurs.Sort

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "BinarySearch and Insert ""Coelophysis"":")
        Dim index As Integer = dinosaurs.BinarySearch("Coelophysis")
        If index < 0 Then
            index = index Xor -1
            dinosaurs.Insert(index, "Coelophysis")
        End If

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "BinarySearch and Insert ""Tyrannosaurus"":")
        index = dinosaurs.BinarySearch("Tyrannosaurus")
        If index < 0 Then
            index = index Xor -1
            dinosaurs.Insert(index, "Tyrannosaurus")
        End If

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
'Deinonychus
'
'Sort
'
'Amargasaurus
'Deinonychus
'Mamenchisaurus
'Pachycephalosaurus
'
'BinarySearch and Insert "Coelophysis":
'
'Amargasaurus
'Coelophysis
'Deinonychus
'Mamenchisaurus
'Pachycephalosaurus
'
'BinarySearch and Insert "Tyrannosaurus":
'
'Amargasaurus
'Coelophysis
'Deinonychus
'Mamenchisaurus
'Pachycephalosaurus
'Tyrannosaurus
' </Snippet1>