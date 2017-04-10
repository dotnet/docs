' REDMOND\glennha
' <Snippet1>
Imports System

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs() As String = { "Tyrannosaurus", _
            "Amargasaurus", _
            "Mamenchisaurus", _
            "Brachiosaurus", _
            "Deinonychus", _
            "Tyrannosaurus", _
            "Compsognathus" }

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & _
            "Array.LastIndexOf(dinosaurs, ""Tyrannosaurus""): {0}", _
            Array.LastIndexOf(dinosaurs, "Tyrannosaurus"))

        Console.WriteLine(vbLf & _
            "Array.LastIndexOf(dinosaurs, ""Tyrannosaurus"", 3): {0}", _
            Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 3))

        Console.WriteLine(vbLf & _
            "Array.LastIndexOf(dinosaurs, ""Tyrannosaurus"", 4, 4): {0}", _
            Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 4, 4))

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
'Array.LastIndexOf(dinosaurs, "Tyrannosaurus"): 5
'
'Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 3): 0
'
'Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 4, 4): -1
' </Snippet1>