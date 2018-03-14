' Collections (C# and Visual Basic)
' e76533a9-5033-4a0b-b003-9c2be60d185b

Option Strict On

Imports System.Collections.Generic
Imports System.Linq

Public Class Class4

    Public Sub Process()
        ShowLINQ()
    End Sub


    '<Snippet41>
    Private Sub ShowLINQ()
        Dim elements As List(Of Element) = BuildList()

        ' LINQ Query.
        Dim subset = From theElement In elements
                      Where theElement.AtomicNumber < 22
                      Order By theElement.Name

        For Each theElement In subset
            Console.WriteLine(theElement.Name & " " & theElement.AtomicNumber)
        Next

        ' Output:
        '  Calcium 20
        '  Potassium 19
        '  Scandium 21
    End Sub

    Private Function BuildList() As List(Of Element)
        Return New List(Of Element) From
            {
                {New Element With
                    {.Symbol = "K", .Name = "Potassium", .AtomicNumber = 19}},
                {New Element With
                    {.Symbol = "Ca", .Name = "Calcium", .AtomicNumber = 20}},
                {New Element With
                    {.Symbol = "Sc", .Name = "Scandium", .AtomicNumber = 21}},
                {New Element With
                    {.Symbol = "Ti", .Name = "Titanium", .AtomicNumber = 22}}
            }
    End Function

    Public Class Element
        Public Property Symbol As String
        Public Property Name As String
        Public Property AtomicNumber As Integer
    End Class
    '</Snippet41>

End Class
