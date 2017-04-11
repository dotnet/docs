' <Snippet1>
' <Snippet11>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module Binomial

    ' args(0) is the number of possibilities for binomial coefficients.
    ' args(1) is the file specification for the trace log file.
    Sub Main(ByVal args() As String)

        ' <Snippet2>
        Dim possibilities As Decimal
        Dim iter As Decimal
        ' </Snippet2>

        ' <Snippet3>
        ' Remove the original default trace listener.
        Trace.Listeners.RemoveAt(0)

        ' <Snippet4>
        ' Create and add a new default trace listener.
        ' <Snippet5>
        Dim defaultListener As DefaultTraceListener
        ' </Snippet5>
        defaultListener = New DefaultTraceListener
        Trace.Listeners.Add(defaultListener)

        ' Assign the log file specification from the command line, if entered.
        If args.Length >= 2 Then
            defaultListener.LogFileName = args(1)
        End If
        ' </Snippet4>
        ' </Snippet3>

        ' Validate the number of possibilities argument.
        If args.Length >= 1 Then

            ' Verify that the argument is a number within the correct range.
            Try
                Const MAX_POSSIBILITIES As Decimal = 99
                possibilities = Decimal.Parse(args(0))
                If possibilities < 0 Or possibilities > MAX_POSSIBILITIES Then
                    Throw New Exception( _
                        String.Format("The number of possibilities must " & _
                            "be in the range 0..{0}.", MAX_POSSIBILITIES))
                End If
            Catch ex As Exception
                Dim failMessage As String = String.Format("""{0}"" " & _
                    "is not a valid number of possibilities.", args(0))
                defaultListener.Fail(failMessage, ex.Message)
                If Not defaultListener.AssertUiEnabled Then
                    Console.WriteLine(failMessage & vbCrLf & ex.Message)
                End If
                Return
            End Try
        Else
            ' <Snippet6>
            ' Report that the required argument is not present.
            Const ENTER_PARAM As String = "Enter the number of " & _
                "possibilities as a command line argument."
            defaultListener.Fail(ENTER_PARAM)
            If Not defaultListener.AssertUiEnabled Then
                Console.WriteLine(ENTER_PARAM)
            End If
            ' </Snippet6>
            Return
        End If

        For iter = 0 To possibilities
            ' <Snippet7>
            Dim result As Decimal
            Dim binomial As String

            ' </Snippet7>
            ' <Snippet8>
            ' Compute the next binomial coefficient and handle all exceptions.
            Try
                ' <Snippet9>
                result = CalcBinomial(possibilities, iter)
                ' </Snippet9>
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
            ' </Snippet8>
            ' <Snippet10>

            ' Format the trace and console output.
            binomial = String.Format("Binomial( {0}, {1} ) = ", _
                            possibilities, iter)
            defaultListener.Write(binomial)
            defaultListener.WriteLine(result.ToString)
            Console.WriteLine("{0} {1}", binomial, result)
            ' </Snippet10>
        Next
    End Sub

    Function CalcBinomial(ByVal possibilities As Decimal, _
                        ByVal outcomes As Decimal) As Decimal

        ' Calculate a binomial coefficient, and minimize the chance of overflow.
        Dim result As Decimal = 1
        Dim iter As Decimal
        For iter = 1 To possibilities - outcomes
            result *= outcomes + iter
            result /= iter
        Next
        Return result
    End Function
End Module
' </Snippet11>
' </Snippet1>
