' REDMOND\glennha
' <Snippet1>
Imports System

Public Class DinoDiscoverySet

    Public Shared Sub Main()
        Dim dinosaurs() As String = { "Compsognathus", _
            "Amargasaurus",   "Oviraptor",      "Velociraptor", _
            "Deinonychus",    "Dilophosaurus",  "Gallimimus", _
            "Triceratops" }

        Dim GoMesozoic As New DinoDiscoverySet(dinosaurs)

        GoMesozoic.DiscoverAll()
        GoMesozoic.DiscoverByEnding("saurus")
    End Sub

    Private dinosaurs As String()

    Public Sub New(items() As String)
        dinosaurs = items
    End Sub

    Public Sub DiscoverAll()
        Console.WriteLine()
        For Each dinosaur As String In dinosaurs
            Console.WriteLine(dinosaur)
        Next dinosaur
    End Sub

    Public Sub DiscoverByEnding(Ending As String)
        Dim dinoType As Predicate(Of String)

        Select Case Ending.ToLower()
            Case "raptor"
                dinoType = AddressOf EndsWithRaptor
            Case "tops"
                dinoType = AddressOf EndsWithTops
            Case "saurus"
                dinoType = AddressOf EndsWithSaurus
            Case Else
                dinoType = AddressOf EndsWithSaurus
        End Select

        Console.WriteLine(vbNewLine + _
            "Array.Exists(dinosaurs, ""{0}""): {1}", _
            Ending, _
            Array.Exists(dinosaurs, dinoType))

        Console.WriteLine(vbNewLine + _
            "Array.TrueForAll(dinosaurs, ""{0}""): {1}", _
            Ending, _
            Array.TrueForAll(dinosaurs, dinoType))

        Console.WriteLine(vbNewLine + _
            "Array.Find(dinosaurs, ""{0}""): {1}", _
            Ending, _
            Array.Find(dinosaurs, dinoType))

        Console.WriteLine(vbNewLine + _
            "Array.FindLast(dinosaurs, ""{0}""): {1}", _
            Ending, _
            Array.FindLast(dinosaurs, dinoType))

        Console.WriteLine(vbNewLine + _
            "Array.FindAll(dinosaurs, ""{0}""):", Ending)

        Dim subArray() As String = _
            Array.FindAll(dinosaurs, dinoType)

        For Each dinosaur As String In subArray
            Console.WriteLine(dinosaur)
        Next dinosaur
    End Sub

    ' Search predicate returns true if a string ends in "saurus".
    Private Function EndsWithSaurus(s As String) As Boolean
        ' AndAlso prevents evaluation of the second Boolean
        ' expression if the string is so short that an error
        ' would occur.
        If (s.Length > 5) AndAlso _
            (s.ToLower().EndsWith("saurus")) Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Search predicate returns true if a string ends in "raptor".
    Private Function EndsWithRaptor(s As String) As Boolean
        ' AndAlso prevents evaluation of the second Boolean
        ' expression if the string is so short that an error
        ' would occur.
        If (s.Length > 5) AndAlso _
            (s.ToLower().EndsWith("raptor")) Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Search predicate returns true if a string ends in "tops".
    Private Function EndsWithTops(s As String) As Boolean
        ' AndAlso prevents evaluation of the second Boolean
        ' expression if the string is so short that an error
        ' would occur.
        If (s.Length > 3) AndAlso _
            (s.ToLower().EndsWith("tops")) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

' This code example produces the following output:
'
' Compsognathus
' Amargasaurus
' Oviraptor
' Velociraptor
' Deinonychus
' Dilophosaurus
' Gallimimus
' Triceratops
'
' Array.Exists(dinosaurs, "saurus"): True
'
' Array.TrueForAll(dinosaurs, "saurus"): False
'
' Array.Find(dinosaurs, "saurus"): Amargasaurus
'
' Array.FindLast(dinosaurs, "saurus"): Dilophosaurus
'
' Array.FindAll(dinosaurs, "saurus"):
' Amargasaurus
' Dilophosaurus
' </Snippet1>


