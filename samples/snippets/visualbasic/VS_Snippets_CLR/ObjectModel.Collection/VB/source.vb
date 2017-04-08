' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Public Class Demo
    
    Public Shared Sub Main() 

        Dim dinosaurs As New Collection(Of String)

        dinosaurs.Add("Psitticosaurus")
        dinosaurs.Add("Caudipteryx")
        dinosaurs.Add("Compsognathus")
        dinosaurs.Add("Muttaburrasaurus")

        Console.WriteLine("{0} dinosaurs:", dinosaurs.Count)
        Display(dinosaurs)
    
        Console.WriteLine(vbLf & "IndexOf(""Muttaburrasaurus""): {0}", _
            dinosaurs.IndexOf("Muttaburrasaurus"))

        Console.WriteLine(vbLf & "Contains(""Caudipteryx""): {0}", _
            dinosaurs.Contains("Caudipteryx"))

        Console.WriteLine(vbLf & "Insert(2, ""Nanotyrannus"")")
        dinosaurs.Insert(2, "Nanotyrannus")
        Display(dinosaurs)

        Console.WriteLine(vbLf & "dinosaurs(2): {0}", dinosaurs(2))

        Console.WriteLine(vbLf & "dinosaurs(2) = ""Microraptor""")
        dinosaurs(2) = "Microraptor"
        Display(dinosaurs)

        Console.WriteLine(vbLf & "Remove(""Microraptor"")")
        dinosaurs.Remove("Microraptor")
        Display(dinosaurs)

        Console.WriteLine(vbLf & "RemoveAt(0)")
        dinosaurs.RemoveAt(0)
        Display(dinosaurs)
 
        Console.WriteLine(vbLf & "dinosaurs.Clear()")
        dinosaurs.Clear()
        Console.WriteLine("Count: {0}", dinosaurs.Count)

    End Sub
    
    Private Shared Sub Display(ByVal cs As Collection(Of String)) 
        Console.WriteLine()
        For Each item As String In cs
            Console.WriteLine(item)
        Next item
    End Sub
End Class

' This code example produces the following output:
'
'4 dinosaurs:
'
'Psitticosaurus
'Caudipteryx
'Compsognathus
'Muttaburrasaurus
'
'IndexOf("Muttaburrasaurus"): 3
'
'Contains("Caudipteryx"): True
'
'Insert(2, "Nanotyrannus")
'
'Psitticosaurus
'Caudipteryx
'Nanotyrannus
'Compsognathus
'Muttaburrasaurus
'
'dinosaurs(2): Nanotyrannus
'
'dinosaurs(2) = "Microraptor"
'
'Psitticosaurus
'Caudipteryx
'Microraptor
'Compsognathus
'Muttaburrasaurus
'
'Remove("Microraptor")
'
'Psitticosaurus
'Caudipteryx
'Compsognathus
'Muttaburrasaurus
'
'RemoveAt(0)
'
'Caudipteryx
'Compsognathus
'Muttaburrasaurus
'
'dinosaurs.Clear()
'Count: 0
'</Snippet1>