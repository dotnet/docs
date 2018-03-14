' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs As New List(Of String)

        dinosaurs.Add("Compsognathus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Oviraptor")
        dinosaurs.Add("Velociraptor")
        dinosaurs.Add("Deinonychus")
        dinosaurs.Add("Dilophosaurus")
        dinosaurs.Add("Gallimimus")
        dinosaurs.Add("Triceratops")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "TrueForAll(AddressOf EndsWithSaurus: {0}", _
            dinosaurs.TrueForAll(AddressOf EndsWithSaurus))

        Console.WriteLine(vbLf & _
            "Find(AddressOf EndsWithSaurus): {0}", _
            dinosaurs.Find(AddressOf EndsWithSaurus))

        Console.WriteLine(vbLf & _
            "FindLast(AddressOf EndsWithSaurus): {0}", _
            dinosaurs.FindLast(AddressOf EndsWithSaurus))

        Console.WriteLine(vbLf & _
            "FindAll(AddressOf EndsWithSaurus):")
        Dim sublist As List(Of String) = _
            dinosaurs.FindAll(AddressOf EndsWithSaurus)

        For Each dinosaur As String In sublist
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "{0} elements removed by RemoveAll(AddressOf EndsWithSaurus).", _
            dinosaurs.RemoveAll(AddressOf EndsWithSaurus))

        Console.WriteLine(vbLf & "List now contains:")
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "Exists(AddressOf EndsWithSaurus): {0}", _
            dinosaurs.Exists(AddressOf EndsWithSaurus))
        
    End Sub

    ' Search predicate returns true if a string ends in "saurus".
    Private Shared Function EndsWithSaurus(ByVal s As String) _
        As Boolean

        Return s.ToLower().EndsWith("saurus")
    End Function
End Class

' This code example produces the following output:
'
'Compsognathus
'Amargasaurus
'Oviraptor
'Velociraptor
'Deinonychus
'Dilophosaurus
'Gallimimus
'Triceratops
'
'TrueForAll(AddressOf EndsWithSaurus: False
'
'Find(AddressOf EndsWithSaurus): Amargasaurus
'
'FindLast(AddressOf EndsWithSaurus): Dilophosaurus
'
'FindAll(AddressOf EndsWithSaurus):
'Amargasaurus
'Dilophosaurus
'
'2 elements removed by RemoveAll(AddressOf EndsWithSaurus).
'
'List now contains:
'Compsognathus
'Oviraptor
'Velociraptor
'Deinonychus
'Gallimimus
'Triceratops
'
'Exists(AddressOf EndsWithSaurus): False
' </Snippet1>