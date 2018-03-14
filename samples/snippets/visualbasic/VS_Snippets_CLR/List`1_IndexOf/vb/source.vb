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
            "IndexOf(""Tyrannosaurus""): {0}", _
            dinosaurs.IndexOf("Tyrannosaurus"))

        Console.WriteLine(vbLf & _
            "IndexOf(""Tyrannosaurus"", 3): {0}", _
            dinosaurs.IndexOf("Tyrannosaurus", 3))

        Console.WriteLine(vbLf & _
            "IndexOf(""Tyrannosaurus"", 2, 2): {0}", _
            dinosaurs.IndexOf("Tyrannosaurus", 2, 2))

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
'IndexOf("Tyrannosaurus"): 0
'
'IndexOf("Tyrannosaurus", 3): 5
'
'IndexOf("Tyrannosaurus", 2, 2): -1
' </Snippet1>