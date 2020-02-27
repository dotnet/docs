' Collections (C# and Visual Basic)
' e76533a9-5033-4a0b-b003-9c2be60d185b

Option Strict On

Imports System.Collections.Generic


Public Class Class3

    Public Sub Process()
        ListCars()
        Console.WriteLine()
        ListColors()
        Console.WriteLine()
        ListEvenNumbers()
        Console.WriteLine()
    End Sub


    '<Snippet31>
    Public Sub ListCars()

        ' Create some new cars.
        Dim cars As New List(Of Car) From
        {
            New Car With {.Name = "car1", .Color = "blue", .Speed = 20},
            New Car With {.Name = "car2", .Color = "red", .Speed = 50},
            New Car With {.Name = "car3", .Color = "green", .Speed = 10},
            New Car With {.Name = "car4", .Color = "blue", .Speed = 50},
            New Car With {.Name = "car5", .Color = "blue", .Speed = 30},
            New Car With {.Name = "car6", .Color = "red", .Speed = 60},
            New Car With {.Name = "car7", .Color = "green", .Speed = 50}
        }

        ' Sort the cars by color alphabetically, and then by speed
        ' in descending order.
        cars.Sort()

        ' View all of the cars.
        For Each thisCar As Car In cars
            Console.Write(thisCar.Color.PadRight(5) & " ")
            Console.Write(thisCar.Speed.ToString & " ")
            Console.Write(thisCar.Name)
            Console.WriteLine()
        Next

        ' Output:
        '  blue  50 car4
        '  blue  30 car5
        '  blue  20 car1
        '  green 50 car7
        '  green 10 car3
        '  red   60 car6
        '  red   50 car2
    End Sub

    Public Class Car
        Implements IComparable(Of Car)

        Public Property Name As String
        Public Property Speed As Integer
        Public Property Color As String

        Public Function CompareTo(ByVal other As Car) As Integer _
            Implements System.IComparable(Of Car).CompareTo
            ' A call to this method makes a single comparison that is
            ' used for sorting.

            ' Determine the relative order of the objects being compared.
            ' Sort by color alphabetically, and then by speed in
            ' descending order.

            ' Compare the colors.
            Dim compare As Integer
            compare = String.Compare(Me.Color, other.Color, True)

            ' If the colors are the same, compare the speeds.
            If compare = 0 Then
                compare = Me.Speed.CompareTo(other.Speed)

                ' Use descending order for speed.
                compare = -compare
            End If

            Return compare
        End Function
    End Class
    '</Snippet31>



    '<Snippet32>
    Public Sub ListColors()
        Dim colors As New AllColors()

        For Each theColor As Color In colors
            Console.Write(theColor.Name & " ")
        Next
        Console.WriteLine()
        ' Output: red blue green
    End Sub

    ' Collection class.
    Public Class AllColors
        Implements System.Collections.IEnumerable

        Private _colors() As Color =
        {
            New Color With {.Name = "red"},
            New Color With {.Name = "blue"},
            New Color With {.Name = "green"}
        }

        Public Function GetEnumerator() As System.Collections.IEnumerator _
            Implements System.Collections.IEnumerable.GetEnumerator

            Return New ColorEnumerator(_colors)

            ' Instead of creating a custom enumerator, you could
            ' use the GetEnumerator of the array.
            'Return _colors.GetEnumerator
        End Function

        ' Custom enumerator.
        Private Class ColorEnumerator
            Implements System.Collections.IEnumerator

            Private _colors() As Color
            Private _position As Integer = -1

            Public Sub New(ByVal colors() As Color)
                _colors = colors
            End Sub

            Public ReadOnly Property Current() As Object _
                Implements System.Collections.IEnumerator.Current
                Get
                    Return _colors(_position)
                End Get
            End Property

            Public Function MoveNext() As Boolean _
                Implements System.Collections.IEnumerator.MoveNext
                _position += 1
                Return (_position < _colors.Length)
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                _position = -1
            End Sub
        End Class
    End Class

    ' Element class.
    Public Class Color
        Public Property Name As String
    End Class
    '</Snippet32>


    '<Snippet33>
    Public Sub ListEvenNumbers()
        For Each number As Integer In EvenSequence(5, 18)
            Console.Write(number & " ")
        Next
        Console.WriteLine()
        ' Output: 6 8 10 12 14 16 18
    End Sub

    Private Iterator Function EvenSequence(
    ByVal firstNumber As Integer, ByVal lastNumber As Integer) _
    As IEnumerable(Of Integer)

    ' Yield even numbers in the range.
        For number = firstNumber To lastNumber
            If number Mod 2 = 0 Then
                Yield number
            End If
        Next
    End Function
    '</Snippet33>


End Class
