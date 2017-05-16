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
        dinosaurs.Add("Deinonychus")
        dinosaurs.Add("Tyrannosaurus")
        dinosaurs.Add("Compsognathus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "LastIndexOf(""Tyrannosaurus""): {0}", _
            dinosaurs.LastIndexOf("Tyrannosaurus"))

        Console.WriteLine(vbLf & _
            "LastIndexOf(""Tyrannosaurus"", 3): {0}", _
            dinosaurs.LastIndexOf("Tyrannosaurus", 3))

        Console.WriteLine(vbLf & _
            "LastIndexOf(""Tyrannosaurus"", 4, 4): {0}", _
            dinosaurs.LastIndexOf("Tyrannosaurus", 4, 4))

    End Sub
End Class

' This code example produces the following output:
'
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Brachiosaurus
'Deinonychus
'Tyrannosaurus
'Compsognathus
'
'LastIndexOf("Tyrannosaurus"): 5
'
'LastIndexOf("Tyrannosaurus", 3): 0
'
'LastIndexOf("Tyrannosaurus", 4, 4): -1
' </Snippet1>