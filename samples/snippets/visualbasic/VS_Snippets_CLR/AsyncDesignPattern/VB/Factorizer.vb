' <Snippet6>
Imports System.Threading
Imports System.Runtime.Remoting.Messaging

Namespace Examples.AdvancedProgramming.AsynchronousOperations

    ' Create a class that factors a number.
    Public Class PrimeFactorFinder
        Public Shared Function Factorize( _
                     ByVal number as Integer, _
                     Byref primefactor1 as Integer, _
                     Byref primefactor2 as Integer) as Boolean
            primefactor1 = 1
            primefactor2 = number

            ' Factorize using a low-tech approach.
            For i as Integer = 2 To number - 1
                If 0 = (number MOD i)
                    primefactor1 = i
                    primefactor2 = number / i
                    Exit For
                End If
            Next i
            If 1 = primefactor1
                Return False
            Else
                Return True
            End If
        End Function
    End Class

    ' Create an asynchronous delegate that matches the Factorize method.
    Public delegate Function AsyncFactorCaller( _
             number as Integer, _
             ByRef primefactor1 as Integer, _
             ByRef primefactor2 as Integer) as Boolean

    Public Class DemonstrateAsyncPattern
        ' The waiter object is used to keep the main application thread
        ' from terminating before the callback method completes.
        Dim waiter as ManualResetEvent
        ' Define the method that is invoked when the results are available.
        Public Sub FactorizedResults(result as IAsyncResult)
            Dim factor1 as Integer = 0
            Dim factor2 as Integer = 0

            ' Extract the delegate from the 
            ' System.Runtime.Remoting.Messaging.AsyncResult.
            Dim ar as AsyncResult = CType(result, AsyncResult)
            Dim delegateObject as Object = ar.AsyncDelegate
            Dim factorDelegate as AsyncFactorCaller = _
                  CType(delegateObject, AsyncFactorCaller)

            Dim number as Integer = CType(result.AsyncState, Integer)
            Dim answer as Boolean

            ' Obtain the result.
            answer = factorDelegate.EndInvoke(factor1, factor2, result)
            ' Output the results.
            Console.WriteLine("On CallBack: Factors of {0} : {1} {2} - {3}", _
                number, factor1, factor2, answer)
            waiter.Set()
        End Sub

        ' The following method demonstrates the asynchronous pattern using a callback method.
        Public Sub FactorizeNumberUsingCallback()
            Dim factorDelegate as AsyncFactorCaller
            Dim result as IAsyncResult
            Dim callback as AsyncCallback
            Dim number as Integer = 1000589023
            Dim temp as Integer = 0

            ' Waiter will keep the main application thread from 
            '' ending before the callback completes because
            ' the main thread blocks until the waiter is signaled
            ' in the callback.
            waiter = new ManualResetEvent(False)
            factorDelegate = AddressOf PrimeFactorFinder.Factorize
            ' Define the AsyncCallback delegate.
            callBack = new AsyncCallback(AddressOf FactorizedResults)

            ' Asynchronously invoke the Factorize method.
            result = factorDelegate.BeginInvoke( _
                                 number, _
                                 temp, _
                                 temp, _
                                 callBack, _
                                 number)
        End Sub

        ' The following method demonstrates the asynchronous pattern 
        ' using a BeginInvoke, followed by waiting with a time-out.
        Public Sub FactorizeNumberAndWait()
            Dim factorDelegate as AsyncFactorCaller
            Dim result as IAsyncResult

            factorDelegate = AddressOf PrimeFactorFinder.Factorize

            Dim number as Integer = 1000589023
            Dim temp as Integer = 0

            ' Asynchronously invoke the Factorize method.
            result = factorDelegate.BeginInvoke( _
                              number, _
                              temp, _
                              temp, _
                              Nothing, _
                              Nothing)

            Do While result.IsCompleted = False
                ' Do any work you can do before waiting.
                result.AsyncWaitHandle.WaitOne(10000, false)
            Loop
            result.AsyncWaitHandle.Close()

            ' The asynchronous operation has completed.
            Dim factor1 as Integer = 0
            Dim factor2 as Integer = 0
            Dim answer as Boolean
            ' Obtain the result.
            answer = factorDelegate.EndInvoke(factor1, factor2, result)

            ' Output the results.
            Console.WriteLine("Sequential : Factors of {0} : {1} {2} - {3}", _
                              number, factor1, factor2, answer)
        End Sub

        Public Shared Sub Main()
            Dim demonstrator as DemonstrateAsyncPattern
            demonstrator = new DemonstrateAsyncPattern()
            demonstrator.FactorizeNumberUsingCallback()
            demonstrator.FactorizeNumberAndWait()
        End Sub
    End Class
End Namespace
' </Snippet6>


