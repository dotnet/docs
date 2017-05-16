' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim input() As String = { "Brachiosaurus", _
                                  "Amargasaurus", _
                                  "Mamenchisaurus" }

        Dim dinosaurs As New List(Of String)(input)

        Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "AddRange(dinosaurs)")
        dinosaurs.AddRange(dinosaurs)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "RemoveRange(2, 2)")
        dinosaurs.RemoveRange(2, 2)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        input = New String() { "Tyrannosaurus", _
                               "Deinonychus", _
                               "Velociraptor" }

        Console.WriteLine(vbLf & "InsertRange(3, input)")
        dinosaurs.InsertRange(3, input)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "output = dinosaurs.GetRange(2, 3).ToArray")
        Dim output() As String = dinosaurs.GetRange(2, 3).ToArray()
        
        Console.WriteLine()
        For Each dinosaur As String In output
            Console.WriteLine(dinosaur)
        Next

    End Sub
End Class

' This code example produces the following output:
'
'Capacity: 3
'
'Brachiosaurus
'Amargasaurus
'Mamenchisaurus
'
'AddRange(dinosaurs)
'
'Brachiosaurus
'Amargasaurus
'Mamenchisaurus
'Brachiosaurus
'Amargasaurus
'Mamenchisaurus
'
'RemoveRange(2, 2)
'
'Brachiosaurus
'Amargasaurus
'Amargasaurus
'Mamenchisaurus
'
'InsertRange(3, input)
'
'Brachiosaurus
'Amargasaurus
'Amargasaurus
'Tyrannosaurus
'Deinonychus
'Velociraptor
'Mamenchisaurus
'
'output = dinosaurs.GetRange(2, 3).ToArray
'
'Amargasaurus
'Tyrannosaurus
'Deinonychus
' </Snippet1>