Imports System

Namespace ca2200

    Class TestsRethrow

        Shared Sub Main2200()
            Dim testRethrow As New TestsRethrow()
            testRethrow.CatchException()
        End Sub

        Sub CatchException()

            Try
                CatchAndRethrowExplicitly()
            Catch e As ArithmeticException
                Console.WriteLine("Explicitly specified:{0}{1}",
               Environment.NewLine, e.StackTrace)
            End Try

            Try
                CatchAndRethrowImplicitly()
            Catch e As ArithmeticException
                Console.WriteLine("{0}Implicitly specified:{0}{1}",
               Environment.NewLine, e.StackTrace)
            End Try

        End Sub

        Sub CatchAndRethrowExplicitly()

            Try
                ThrowException()
            Catch e As ArithmeticException

                ' Violates the rule.
                Throw e
            End Try

        End Sub

        Sub CatchAndRethrowImplicitly()

            Try
                ThrowException()
            Catch e As ArithmeticException

                ' Satisfies the rule.
                Throw
            End Try

        End Sub

        Sub ThrowException()
            Throw New ArithmeticException("illegal expression")
        End Sub

    End Class

End Namespace
