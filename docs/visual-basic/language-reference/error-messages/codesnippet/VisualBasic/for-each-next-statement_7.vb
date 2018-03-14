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