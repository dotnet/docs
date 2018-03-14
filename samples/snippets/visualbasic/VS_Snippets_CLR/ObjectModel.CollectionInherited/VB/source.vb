' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Public Class Dinosaurs
    Inherits Collection(Of String)

    Public Event Changed As EventHandler(Of DinosaursChangedEventArgs)

    Protected Overrides Sub InsertItem( _
        ByVal index As Integer, ByVal newItem As String)

        MyBase.InsertItem(index, newItem)

        RaiseEvent Changed(Me, New DinosaursChangedEventArgs( _
            ChangeType.Added, newItem, Nothing))
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, _
        ByVal newItem As String)

        Dim replaced As String = Items(index)
        MyBase.SetItem(index, newItem)

        RaiseEvent Changed(Me, New DinosaursChangedEventArgs( _
            ChangeType.Replaced, replaced, newItem))
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)

        Dim removedItem As String = Items(index)
        MyBase.RemoveItem(index)

        RaiseEvent Changed(Me, New DinosaursChangedEventArgs( _
            ChangeType.Removed, removedItem, Nothing))
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()

        RaiseEvent Changed(Me, New DinosaursChangedEventArgs( _
            ChangeType.Cleared, Nothing, Nothing))
    End Sub

End Class

' Event argument for the Changed event.
'
Public Class DinosaursChangedEventArgs
    Inherits EventArgs

    Public ReadOnly ChangedItem As String
    Public ReadOnly ChangeType As ChangeType
    Public ReadOnly ReplacedWith As String

    Public Sub New(ByVal change As ChangeType, ByVal item As String, _
        ByVal replacement As String)

        ChangeType = change
        ChangedItem = item
        ReplacedWith = replacement
    End Sub
End Class

Public Enum ChangeType
    Added
    Removed
    Replaced
    Cleared
End Enum

Public Class Demo
    
    Public Shared Sub Main() 

        Dim dinosaurs As New Dinosaurs

        AddHandler dinosaurs.Changed, AddressOf ChangedHandler

        dinosaurs.Add("Psitticosaurus")
        dinosaurs.Add("Caudipteryx")
        dinosaurs.Add("Compsognathus")
        dinosaurs.Add("Muttaburrasaurus")

        Display(dinosaurs)
    
        Console.WriteLine(vbLf & "IndexOf(""Muttaburrasaurus""): {0}", _
            dinosaurs.IndexOf("Muttaburrasaurus"))

        Console.WriteLine(vbLf & "Contains(""Caudipteryx""): {0}", _
            dinosaurs.Contains("Caudipteryx"))

        Console.WriteLine(vbLf & "Insert(2, ""Nanotyrannus"")")
        dinosaurs.Insert(2, "Nanotyrannus")

        Console.WriteLine(vbLf & "dinosaurs(2): {0}", dinosaurs(2))

        Console.WriteLine(vbLf & "dinosaurs(2) = ""Microraptor""")
        dinosaurs(2) = "Microraptor"

        Console.WriteLine(vbLf & "Remove(""Microraptor"")")
        dinosaurs.Remove("Microraptor")

        Console.WriteLine(vbLf & "RemoveAt(0)")
        dinosaurs.RemoveAt(0)

        Display(dinosaurs)
 
    End Sub
    
    Private Shared Sub Display(ByVal cs As Collection(Of String)) 
        Console.WriteLine()
        For Each item As String In cs
            Console.WriteLine(item)
        Next item
    End Sub

    Private Shared Sub ChangedHandler(ByVal source As Object, _
        ByVal e As DinosaursChangedEventArgs)

        If e.ChangeType = ChangeType.Replaced Then
            Console.WriteLine("{0} was replaced with {1}", _
                e.ChangedItem, e.ReplacedWith)

        ElseIf e.ChangeType = ChangeType.Cleared Then
            Console.WriteLine("The dinosaur list was cleared.")

        Else
            Console.WriteLine("{0} was {1}.", _
                e.ChangedItem, e.ChangeType)
        End If
    End Sub

End Class

' This code example produces the following output:
'
'Psitticosaurus was Added.
'Caudipteryx was Added.
'Compsognathus was Added.
'Muttaburrasaurus was Added.
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
'Nanotyrannus was Added.
'
'dinosaurs(2): Nanotyrannus
'
'dinosaurs(2) = "Microraptor"
'Nanotyrannus was replaced with Microraptor
'
'Remove("Microraptor")
'Microraptor was Removed.
'
'RemoveAt(0)
'Psitticosaurus was Removed.
'
'Caudipteryx
'Compsognathus
'Muttaburrasaurus
'</Snippet1>