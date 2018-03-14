' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs As New List(Of String)

        dinosaurs.Add("Pachycephalosaurus")
        dinosaurs.Add("Parasauralophus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Coelophysis")
        dinosaurs.Add("Oviraptor")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        dinosaurs.Reverse()

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        dinosaurs.Reverse(1, 4)

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

    End Sub
End Class

' This code example produces the following output:
'
'Pachycephalosaurus
'Parasauralophus
'Mamenchisaurus
'Amargasaurus
'Coelophysis
'Oviraptor
'
'Oviraptor
'Coelophysis
'Amargasaurus
'Mamenchisaurus
'Parasauralophus
'Pachycephalosaurus
'
'Oviraptor
'Parasauralophus
'Mamenchisaurus
'Amargasaurus
'Coelophysis
'Pachycephalosaurus
' </Snippet1>