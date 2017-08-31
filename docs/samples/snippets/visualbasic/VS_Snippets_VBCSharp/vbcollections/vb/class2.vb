' Collections (C# and Visual Basic)
' e76533a9-5033-4a0b-b003-9c2be60d185b

Option Strict On

Imports System.Collections.Generic


Public Class Class2

    Public Sub Process()
        IterateThroughDictionary()
        Console.WriteLine()
        FindInDictionary("Ca")
        FindInDictionary("ca")
        FindInDictionary2("Ca")
        FindInDictionary2("ca")
        Console.WriteLine()
    End Sub


    '<Snippet21>
    Private Sub IterateThroughDictionary()
        Dim elements As Dictionary(Of String, Element) = BuildDictionary()

        For Each kvp As KeyValuePair(Of String, Element) In elements
            Dim theElement As Element = kvp.Value

            Console.WriteLine("key: " & kvp.Key)
            With theElement
                Console.WriteLine("values: " & .Symbol & " " &
                    .Name & " " & .AtomicNumber)
            End With
        Next
    End Sub

    Private Function BuildDictionary() As Dictionary(Of String, Element)
        Dim elements As New Dictionary(Of String, Element)

        AddToDictionary(elements, "K", "Potassium", 19)
        AddToDictionary(elements, "Ca", "Calcium", 20)
        AddToDictionary(elements, "Sc", "Scandium", 21)
        AddToDictionary(elements, "Ti", "Titanium", 22)

        Return elements
    End Function

    Private Sub AddToDictionary(ByVal elements As Dictionary(Of String, Element),
    ByVal symbol As String, ByVal name As String, ByVal atomicNumber As Integer)
        Dim theElement As New Element

        theElement.Symbol = symbol
        theElement.Name = name
        theElement.AtomicNumber = atomicNumber

        elements.Add(Key:=theElement.Symbol, value:=theElement)
    End Sub

    Public Class Element
        Public Property Symbol As String
        Public Property Name As String
        Public Property AtomicNumber As Integer
    End Class
    '</Snippet21>


    '<Snippet22>
    Private Function BuildDictionary2() As Dictionary(Of String, Element)
        Return New Dictionary(Of String, Element) From
            {
                {"K", New Element With
                    {.Symbol = "K", .Name = "Potassium", .AtomicNumber = 19}},
                {"Ca", New Element With
                    {.Symbol = "Ca", .Name = "Calcium", .AtomicNumber = 20}},
                {"Sc", New Element With
                    {.Symbol = "Sc", .Name = "Scandium", .AtomicNumber = 21}},
                {"Ti", New Element With
                    {.Symbol = "Ti", .Name = "Titanium", .AtomicNumber = 22}}
            }
    End Function
    '</Snippet22>


    '<Snippet23>
    Private Sub FindInDictionary(ByVal symbol As String)
        Dim elements As Dictionary(Of String, Element) = BuildDictionary()

        If elements.ContainsKey(symbol) = False Then
            Console.WriteLine(symbol & " not found")
        Else
            Dim theElement = elements(symbol)
            Console.WriteLine("found: " & theElement.Name)
        End If
    End Sub
    '</Snippet23>


    '<Snippet24>
    Private Sub FindInDictionary2(ByVal symbol As String)
        Dim elements As Dictionary(Of String, Element) = BuildDictionary()

        Dim theElement As Element = Nothing
        If elements.TryGetValue(symbol, theElement) = False Then
            Console.WriteLine(symbol & " not found")
        Else
            Console.WriteLine("found: " & theElement.Name)
        End If
    End Sub
    '</Snippet24>

End Class
