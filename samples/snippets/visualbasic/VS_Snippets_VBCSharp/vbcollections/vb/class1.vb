' Collections (C# and Visual Basic)
' e76533a9-5033-4a0b-b003-9c2be60d185b

Option Strict On

Imports System.Collections.Generic


Public Class Class1

    Public Sub Process()
        CreateList()
        Console.WriteLine()
        UseCollectionInitializer()
        Console.WriteLine()
        IterateUsingForNext()
        Console.WriteLine()
        RemoveBySpecifyingObject()
        Console.WriteLine()
        RemoveUsingForNext()
        Console.WriteLine()
        IterateThroughList()
        Console.WriteLine()
    End Sub


    Private Sub CreateList()
        '<Snippet11>
        ' Create a list of strings.
        Dim salmons As New List(Of String)
        salmons.Add("chinook")
        salmons.Add("coho")
        salmons.Add("pink")
        salmons.Add("sockeye")

        ' Iterate through the list.
        For Each salmon As String In salmons
            Console.Write(salmon & " ")
        Next
        'Output: chinook coho pink sockeye
        '</Snippet11>
    End Sub

    Private Sub UseCollectionInitializer()
        '<Snippet12>
        ' Create a list of strings by using a
        ' collection initializer.
        Dim salmons As New List(Of String) From
            {"chinook", "coho", "pink", "sockeye"}

        For Each salmon As String In salmons
            Console.Write(salmon & " ")
        Next
        'Output: chinook coho pink sockeye
        '</Snippet12>
    End Sub


    Private Sub IterateUsingForNext()
        '<Snippet13>
        Dim salmons As New List(Of String) From
            {"chinook", "coho", "pink", "sockeye"}

        For index = 0 To salmons.Count - 1
            Console.Write(salmons(index) & " ")
        Next
        'Output: chinook coho pink sockeye
        '</Snippet13>
    End Sub


    Private Sub RemoveBySpecifyingObject()
        '<Snippet14>
        ' Create a list of strings by using a
        ' collection initializer.
        Dim salmons As New List(Of String) From
            {"chinook", "coho", "pink", "sockeye"}

        ' Remove an element in the list by specifying
        ' the object.
        salmons.Remove("coho")

        For Each salmon As String In salmons
            Console.Write(salmon & " ")
        Next
        'Output: chinook pink sockeye
        '</Snippet14>
    End Sub

    Private Sub RemoveUsingForNext()
        '<Snippet15>
        Dim numbers As New List(Of Integer) From
            {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}

        ' Remove odd numbers.
        For index As Integer = numbers.Count - 1 To 0 Step -1
            If numbers(index) Mod 2 = 1 Then
                ' Remove the element by specifying
                ' the zero-based index in the list.
                numbers.RemoveAt(index)
            End If
        Next

        ' Iterate through the list.
        ' A lambda expression is placed in the ForEach method
        ' of the List(T) object.
        numbers.ForEach(
            Sub(number) Console.Write(number & " "))
        ' Output: 0 2 4 6 8
        '</Snippet15>
    End Sub


    '<Snippet16>
    Private Sub IterateThroughList()
        Dim theGalaxies As New List(Of Galaxy) From
            {
                New Galaxy With {.Name = "Tadpole", .MegaLightYears = 400},
                New Galaxy With {.Name = "Pinwheel", .MegaLightYears = 25},
                New Galaxy With {.Name = "Milky Way", .MegaLightYears = 0},
                New Galaxy With {.Name = "Andromeda", .MegaLightYears = 3}
            }

        For Each theGalaxy In theGalaxies
            With theGalaxy
                Console.WriteLine(.Name & "  " & .MegaLightYears)
            End With
        Next

        ' Output:
        '  Tadpole  400
        '  Pinwheel  25
        '  Milky Way  0
        '  Andromeda  3
    End Sub

    Public Class Galaxy
        Public Property Name As String
        Public Property MegaLightYears As Integer
    End Class
    '</Snippet16>


    'Private Sub UseArrayList()
    '    ' Create an ArrayList by using a
    '    ' collection initializer.
    '    Dim salmons As New ArrayList From
    '        {"chinook", "coho", "pink", "sockeye"}

    '    For Each salmon As String In salmons
    '        console.write(salmon & " ")
    '    Next
    '    'Output: chinook coho pink sockeye
    'End Sub

    'Private Sub UseVBCollection()

    '    Dim salmons As New Microsoft.VisualBasic.Collection
    '    salmons.Add("chinook")
    '    salmons.Add("coho")
    '    salmons.Add("pink")
    '    salmons.Add("sockeye")

    '    ' Iterate through the list.
    '    For Each salmon As String In salmons
    '        console.write(salmon & " ")
    '    Next
    '    'Output: chinook coho pink sockeye
    'End Sub



End Class
