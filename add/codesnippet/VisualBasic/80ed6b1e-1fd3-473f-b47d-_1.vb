        ' This class provides a custom implementation 
        ' of the IComparer.Compare() method.
        Class SpecialComparer
            Implements IComparer(Of Decimal)
            ''' <summary>
            ''' Compare two decimal numbers by their fractional parts.
            ''' </summary>
            ''' <param name="d1">The first decimal to compare.</param>
            ''' <param name="d2">The second decimal to compare.</param>
            ''' <returns>1 if the first decimal's fractional part is greater than
            ''' the second decimal's fractional part,
            ''' -1 if the first decimal's fractional
            ''' part is less than the second decimal's fractional part,
            ''' or the result of calling Decimal.Compare()
            ''' if the fractional parts are equal.</returns>
            Function Compare(ByVal d1 As Decimal, ByVal d2 As Decimal) As Integer _
            Implements IComparer(Of Decimal).Compare

                Dim fractional1 As Decimal
                Dim fractional2 As Decimal

                ' Get the fractional part of the first number.
                Try
                    fractional1 = Decimal.Remainder(d1, Decimal.Floor(d1))
                Catch ex As DivideByZeroException
                    fractional1 = d1
                End Try

                ' Get the fractional part of the second number.
                Try
                    fractional2 = Decimal.Remainder(d2, Decimal.Floor(d2))
                Catch ex As DivideByZeroException
                    fractional2 = d2
                End Try

                If (fractional1 = fractional2) Then
                    ' The fractional parts are equal, so compare the entire numbers.
                    Return Decimal.Compare(d1, d2)
                ElseIf (fractional1 > fractional2) Then
                    Return 1
                Else
                    Return -1
                End If
            End Function
        End Class

        Sub OrderByDescendingEx1()
            ' Create a list of decimal values.
            Dim decimals As New List(Of Decimal)(New Decimal() _
                                             {6.2D, 8.3D, 0.5D, 1.3D, 6.3D, 9.7D})

            ' Order the elements of the list by passing
            ' in the custom IComparer class.
            Dim query As IEnumerable(Of Decimal) =
            decimals.OrderByDescending(Function(num) num,
                                       New SpecialComparer())

            Dim output As New System.Text.StringBuilder
            For Each num As Decimal In query
                output.AppendLine(num)
            Next

            ' Display the output.
            MsgBox(output.ToString())
        End Sub

        ' This code produces the following output:
        '
        ' 9.7
        ' 0.5
        ' 8.3
        ' 6.3
        ' 1.3
        ' 6.2
