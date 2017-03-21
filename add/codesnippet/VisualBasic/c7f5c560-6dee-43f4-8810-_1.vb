        Dim ints() As Integer = {4, 8, 8, 3, 9, 0, 7, 8, 2}

        ' Count the even numbers in the array, using a seed value of 0.
        Dim numEven As Integer = _
            ints.AsQueryable().Aggregate( _
                0, _
                Function(ByVal total, ByVal number) _
                    IIf(number Mod 2 = 0, total + 1, total) _
            )

        MsgBox(String.Format("The number of even integers is: {0}", numEven))

        ' This code produces the following output:
        '
        ' The number of even integers is: 6 
