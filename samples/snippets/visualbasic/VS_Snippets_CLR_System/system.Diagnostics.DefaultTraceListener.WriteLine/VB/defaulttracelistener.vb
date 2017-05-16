' <Snippet1>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module DefaultTraceListenerMod

    Dim defaultListener As Diagnostics.DefaultTraceListener

    ' <Snippet2>
    ' args(0) is the number of possibilities for binomial coefficients.
    ' args(1) is the file specification for the trace log file.
    Sub Main(ByVal args() As String)

        Dim possibilities As Decimal

        ' <Snippet3>
        ' Remove the original default trace listener.
        Trace.Listeners.RemoveAt(0)

        ' Add a new default trace listener.
        defaultListener = New Diagnostics.DefaultTraceListener
        Trace.Listeners.Add(defaultListener)
        ' </Snippet3>

        ' Assign the log file specification from the command line, if entered.
        If args.Length >= 2 Then
            defaultListener.LogFileName = args(1)
        End If

        ' Validate the number of possibilities argument.
        If args.Length >= 1 Then

            ' <Snippet5>
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
            ' </Snippet5>
        Else
            ' <Snippet6>
            ' Request the required argument if it was not entered 
            ' on the command-line.
            Const ENTER_PARAM As String = "Enter the number of " & _
                "possibilities as a command-line argument."
            defaultListener.Fail(ENTER_PARAM)
            If Not defaultListener.AssertUiEnabled Then
                Console.WriteLine(ENTER_PARAM)
            End If
            ' </Snippet6>
            Return
        End If

        Dim iter As Decimal
        For iter = 0 To possibilities

            ' <Snippet4>
            ' Compute the next binomial coefficient.  
            ' If an exception is thrown, quit.
            Dim result As Decimal = CalcBinomial(possibilities, iter)
            If result = 0 Then Return

            ' Format the trace and console output.
            Dim binomial As String = String.Format( _
                    "Binomial( {0}, {1} ) = ", possibilities, iter)
            defaultListener.Write(binomial)
            defaultListener.WriteLine(result.ToString)
            Console.WriteLine("{0} {1}", binomial, result)
            ' </Snippet4>
        Next
    End Sub
    ' </Snippet2>

    ' <Snippet7>
    Function CalcBinomial(ByVal possibilities As Decimal, _
                        ByVal outcomes As Decimal) As Decimal

        Dim result As Decimal = 1
        Try
            ' Calculate a binomial coefficient, and minimize the chance 
            ' of overflow.
            Dim iter As Decimal
            For iter = 1 To possibilities - outcomes
                result *= outcomes + iter
                result /= iter
            Next
            Return result

        Catch ex As Exception
            Dim failMessage As String = String.Format( _
                    "An exception was raised when " & _
                    "calculating Binomial( {0}, {1} ).", _
                    possibilities, outcomes)
            defaultListener.Fail(failMessage, ex.Message)
            If Not defaultListener.AssertUiEnabled Then
                Console.WriteLine(failMessage & vbCrLf & ex.Message)
            End If
            Return 0
        End Try
    End Function
    ' </Snippet7>
End Module
' </Snippet1>
