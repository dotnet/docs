        Sub AggregateEx2()
            ' Create an array of Integers.
            Dim ints() As Integer = {4, 8, 8, 3, 9, 0, 7, 8, 2}

            ' Count the even numbers in the array, using a seed value of 0.
            Dim numEven As Integer =
            ints.Aggregate(0,
                           Function(ByVal total, ByVal number) _
                               IIf(number Mod 2 = 0, total + 1, total))

            ' Display the output.
            MsgBox("The number of even integers is " & numEven)
        End Sub

        ' This code produces the following output:
        '
        'The number of even integers is 6
