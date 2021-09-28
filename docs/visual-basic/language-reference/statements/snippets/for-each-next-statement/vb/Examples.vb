Module Module1

    Public Sub Process()

        '<init>
        ' Create a list of strings by using a
        ' collection initializer.
        Dim lst As New List(Of String) _
            From {"abc", "def", "ghi"}

        ' Iterate through the list.
        For Each item As String In lst
            Debug.Write(item & " ")
        Next
        Debug.WriteLine("")
        'Output: abc def ghi
        '</init>


        '<nested>
        ' Create lists of numbers and letters
        ' by using array initializers.
        Dim numbers() As Integer = {1, 4, 7}
        Dim letters() As String = {"a", "b", "c"}

        ' Iterate through the list by using nested loops.
        For Each number As Integer In numbers
            For Each letter As String In letters
                Debug.Write(number.ToString & letter & " ")
            Next
        Next
        Debug.WriteLine("")
        'Output: 1a 1b 1c 4a 4b 4c 7a 7b 7c 
        '</nested>


        '<exitcontinue>
        Dim numberSeq() As Integer =
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}

        For Each number As Integer In numberSeq
            ' If number is between 5 and 8, continue
            ' with the next iteration.
            If number >= 5 And number <= 8 Then
                Continue For
            End If

            ' Display the number.
            Debug.Write(number.ToString & " ")

            ' If number is 10, exit the loop.
            If number = 10 Then
                Exit For
            End If
        Next
        Debug.WriteLine("")
        ' Output: 1 2 3 4 9 10
        '</exitcontinue>


        '<foreachdir>
        Dim dInfo As New System.IO.DirectoryInfo("c:\")
        For Each dir As System.IO.DirectoryInfo In dInfo.GetDirectories()
            Debug.WriteLine(dir.Name)
        Next
        '</foreachdir>
    End Sub



    '<sort>
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
            Debug.Write(thisCar.Color.PadRight(5) & " ")
            Debug.Write(thisCar.Speed.ToString & " ")
            Debug.Write(thisCar.Name)
            Debug.WriteLine("")
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
    '</sort>

    '<iterator>
    Public Sub ListEvenNumbers()
        For Each number As Integer In EvenSequence(5, 18)
            Debug.Write(number & " ")
        Next
        Debug.WriteLine("")
        ' Output: 6 8 10 12 14 16 18
    End Sub

    Private Iterator Function EvenSequence(
    ByVal firstNumber As Integer, ByVal lastNumber As Integer) _
    As System.Collections.Generic.IEnumerable(Of Integer)

        ' Yield even numbers in the range.
        For number = firstNumber To lastNumber
            If number Mod 2 = 0 Then
                Yield number
            End If
        Next
    End Function
    '</iterator>

End Module
