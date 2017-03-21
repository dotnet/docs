            Class Pet
                Public Name As String
                Public Age As Integer
            End Class

            Sub SequenceEqualEx1()
                ' Create two Pet objects.
                Dim pet1 As New Pet With {.Name = "Turbo", .Age = 2}
                Dim pet2 As New Pet With {.Name = "Peanut", .Age = 8}

                ' Create two lists of pets.
                Dim pets1 As New List(Of Pet)(New Pet() {pet1, pet2})
                Dim pets2 As New List(Of Pet)(New Pet() {pet1, pet2})

                'Determine if the two lists are equal.
                Dim equal As Boolean = pets1.SequenceEqual(pets2)

                ' Display the output.
                Dim text As String = IIf(equal, "are", "are not")
                MsgBox("The lists " & text & " equal.")

            End Sub

            ' This code produces the following output:
            '
            ' The lists are equal.
