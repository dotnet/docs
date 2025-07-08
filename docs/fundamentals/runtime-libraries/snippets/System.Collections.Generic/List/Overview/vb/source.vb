' <Snippet1>
Public Class Example2

    Public Shared Sub Main()
        ' <snippet2>
        Dim dinosaurs As New List(Of String)

        Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)

        dinosaurs.Add("Tyrannosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Deinonychus")
        dinosaurs.Add("Compsognathus")
        ' </snippet2>

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        Console.WriteLine(vbLf & "Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)

        Console.WriteLine(vbLf & "Contains(""Deinonychus""): {0}",
            dinosaurs.Contains("Deinonychus"))

        Console.WriteLine(vbLf & "Insert(2, ""Compsognathus"")")
        dinosaurs.Insert(2, "Compsognathus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next
        ' <snippet3>
        ' Shows how to access the list using the Item property.
        Console.WriteLine(vbLf & "dinosaurs(3): {0}", dinosaurs(3))
        ' </snippet3>
        Console.WriteLine(vbLf & "Remove(""Compsognathus"")")
        dinosaurs.Remove("Compsognathus")

        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next

        dinosaurs.TrimExcess()
        Console.WriteLine(vbLf & "TrimExcess()")
        Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)

        dinosaurs.Clear()
        Console.WriteLine(vbLf & "Clear()")
        Console.WriteLine("Capacity: {0}", dinosaurs.Capacity)
        Console.WriteLine("Count: {0}", dinosaurs.Count)
    End Sub
End Class

' This code example produces the following output:
'
'Capacity: 0
'
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Deinonychus
'Compsognathus
'
'Capacity: 8
'Count: 5
'
'Contains("Deinonychus"): True
'
'Insert(2, "Compsognathus")
'
'Tyrannosaurus
'Amargasaurus
'Compsognathus
'Mamenchisaurus
'Deinonychus
'Compsognathus
'
'dinosaurs(3): Mamenchisaurus
'
'Remove("Compsognathus")
'
'Tyrannosaurus
'Amargasaurus
'Mamenchisaurus
'Deinonychus
'Compsognathus
'
'TrimExcess()
'Capacity: 5
'Count: 5
'
'Clear()
'Capacity: 5
'Count: 0
' </Snippet1>
