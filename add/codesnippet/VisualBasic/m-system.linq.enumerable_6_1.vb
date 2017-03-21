            ' This class implements IComparable 
            ' and has a custom 'CompareTo' implementation.
            Class Pet
                Implements IComparable(Of Pet)

                Public Name As String
                Public Age As Integer

                ''' <summary>
                ''' Compares Pet objects by the sum of their age and name length.
                ''' </summary>
                ''' <param name="other">The Pet to compare this Pet to.</param>
                ''' <returns>-1 if this Pet's sum is 'less' than the other Pet,
                ''' 0 if they are equal,
                ''' or 1 if this Pet's sum is 'greater' than the other Pet.</returns>
                Function CompareTo(ByVal other As Pet) As Integer _
                Implements IComparable(Of Pet).CompareTo

                    If (other.Age + other.Name.Length > Me.Age + Me.Name.Length) Then
                        Return -1
                    ElseIf (other.Age + other.Name.Length = Me.Age + Me.Name.Length) Then
                        Return 0
                    Else
                        Return 1
                    End If
                End Function
            End Class

            Sub MaxEx3()
                ' Create an array of Pet objects.
                Dim pets() As Pet = {New Pet With {.Name = "Barley", .Age = 8},
                                 New Pet With {.Name = "Boots", .Age = 4},
                                 New Pet With {.Name = "Whiskers", .Age = 1}}

                ' Find the "maximum" pet according to the 
                ' custom CompareTo() implementation.
                Dim max As Pet = pets.Max()

                ' Display the result.
                MsgBox("The 'maximum' animal is " & max.Name)
            End Sub

            ' This code produces the following output:
            '
            ' The 'maximum' animal is Barley
