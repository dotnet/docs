' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs As New List(Of String)

        dinosaurs.Add("Tyrannosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Deinonychus")
        dinosaurs.Add("Compsognathus")

        Dim readOnlyDinosaurs As _
            New ReadOnlyCollection(Of String)(dinosaurs)

        Console.WriteLine()
        For Each dinosaur As String In readOnlyDinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "Count: {0}", _
            readOnlyDinosaurs.Count)

        Console.WriteLine(vbLf & "Contains(""Deinonychus""): {0}", _
            readOnlyDinosaurs.Contains("Deinonychus"))

        Console.WriteLine(vbLf & _
            "readOnlyDinosaurs(3): {0}", readOnlyDinosaurs(3))

        Console.WriteLine(vbLf & "IndexOf(""Compsognathus""): {0}", _
            readOnlyDinosaurs.IndexOf("Compsognathus"))

        Console.WriteLine(vbLf & "Insert into the wrapped List:")
        Console.WriteLine("Insert(2, ""Oviraptor"")")
        dinosaurs.Insert(2, "Oviraptor")

        Console.WriteLine()
        For Each dinosaur As String In readOnlyDinosaurs
            Console.WriteLine(dinosaur)
        Next

        Dim dinoArray(readOnlyDinosaurs.Count + 1) As String
        readOnlyDinosaurs.CopyTo(dinoArray, 1)

        Console.WriteLine(vbLf & "Copied array has {0} elements:", _
            dinoArray.Length)
        For Each dinosaur As String In dinoArray
            Console.WriteLine("""{0}""", dinosaur)
        Next

   End Sub
End Class

' This code example produces the following output:
'
'Tyrannosaurus
'Amargasaurus
'Deinonychus
'Compsognathus
'
'Count: 4
'
'Contains("Deinonychus"): True
'
'readOnlyDinosaurs(3): Compsognathus
'
'IndexOf("Compsognathus"): 3
'
'Insert into the wrapped List:
'Insert(2, "Oviraptor")
'
'Tyrannosaurus
'Amargasaurus
'Oviraptor
'Deinonychus
'Compsognathus
'
'Copied array has 7 elements:
'""
'"Tyrannosaurus"
'"Amargasaurus"
'"Oviraptor"
'"Deinonychus"
'"Compsognathus"
'""
' </Snippet1>