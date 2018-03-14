' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs As New List(Of String)(4)

        Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)

        dinosaurs.Add("Tyrannosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Deinonychus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "Dim roDinosaurs As IList(Of String) = dinosaurs.AsReadOnly")
        Dim roDinosaurs As IList(Of String) = dinosaurs.AsReadOnly

        Console.WriteLine(vbLf & "Elements in the read-only IList:")
        For Each dinosaur As String In roDinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "dinosaurs(2) = ""Coelophysis""")
        dinosaurs(2) = "Coelophysis"

        Console.WriteLine(vbLf & "Elements in the read-only IList:")
        For Each dinosaur As String In roDinosaurs
            Console.WriteLine(dinosaur)
        Next

    End Sub
End Class

' This code example produces the following output:
'
'Capacity: 4
'
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Deinonychus
'
'Dim roDinosaurs As IList(Of String) = dinosaurs.AsReadOnly
'
'Elements in the read-only IList:
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Deinonychus
'
'dinosaurs(2) = "Coelophysis"
'
'Elements in the read-only IList:
'Tyrannosaurus
'Amargasaurus
'Coelophysis
'Deinonychus
' </Snippet1>