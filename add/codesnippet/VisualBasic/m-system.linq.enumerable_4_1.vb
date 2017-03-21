            ' This class implements IComparable 
            ' and has a custom 'CompareTo' implementation.
            Class Pet
                Implements IComparable(Of Pet)

                Public Name As String
                Public Age As Integer

                ''' <summary>
                ''' Compares this Pet's age to another Pet's age.
                ''' </summary>
                ''' <param name="other">The Pet to compare this Pet to.</param>
                ''' <returns>-1 if this Pet's age is smaller,
                ''' 0 if the Pets' ages are equal,
                ''' or 1 if this Pet's age is greater.</returns>
                Function CompareTo(ByVal other As Pet) As Integer _
                Implements IComparable(Of Pet).CompareTo

                    If (other.Age > Me.Age) Then
                        Return -1
                    ElseIf (other.Age = Me.Age) Then
                        Return 0
                    Else
                        Return 1
                    End If
                End Function
            End Class

            Sub MinEx3()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Determine the "minimum" pet in the array,
                ' according to the custom CompareTo() implementation.
                Dim min As Pet = pets.Min()

                ' Display the result.
                MsgBox("The 'minimum' pet is " & min.Name)
            End Sub

            ' This code produces the following output:
            '
            ' The 'minimum' pet is Whiskers
