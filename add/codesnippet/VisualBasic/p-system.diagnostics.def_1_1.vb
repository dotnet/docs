            ' Compute the next binomial coefficient and handle all exceptions.
            Try
                result = CalcBinomial(possibilities, iter)
            Catch ex As Exception
                Dim failMessage As String = String.Format( _
                        "An exception was raised when " & _
                        "calculating Binomial( {0}, {1} ).", _
                        possibilities, iter)
                defaultListener.Fail(failmessage, ex.Message)
                If Not defaultListener.AssertUiEnabled Then
                    Console.WriteLine(failMessage & vbCrLf & ex.Message)
                End If
                Return
            End Try