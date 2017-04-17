' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Dim _asyncLocalString As New AsyncLocal(Of String)()

    Dim _threadLocalString As New ThreadLocal(Of String)()

    Async Function AsyncMethodA() As Task
        ' Start multiple async method calls, with different AsyncLocal values.
        ' We also set ThreadLocal values, to demonstrate how the two mechanisms differ.
        _asyncLocalString.Value = "Value 1"
        _threadLocalString.Value = "Value 1"
        Dim t1 = AsyncMethodB("Value 1")

        _asyncLocalString.Value = "Value 2"
        _threadLocalString.Value = "Value 2"
        Dim t2 = AsyncMethodB("Value 2")

        ' Await both calls
        await t1
        await t2
     End Function

    Async Function AsyncMethodB(expectedValue As String) As Task
        Console.WriteLine("Entering AsyncMethodB.")
        Console.WriteLine("   Expected '{0}', AsyncLocal value is '{1}', ThreadLocal value is '{2}'", 
                          expectedValue, _asyncLocalString.Value, _threadLocalString.Value)
        await Task.Delay(100)
        Console.WriteLine("Exiting AsyncMethodB.")
        Console.WriteLine("   Expected '{0}', got '{1}', ThreadLocal value is '{2}'", 
                          expectedValue, _asyncLocalString.Value, _threadLocalString.Value)
    End Function

   Public Sub Main()
       AsyncMethodA.Wait()
   End Sub
End Module
' The example displays the following output:
'   Entering AsyncMethodB.
'      Expected 'Value 1', AsyncLocal value is 'Value 1', ThreadLocal value is 'Value 1'
'   Entering AsyncMethodB.
'      Expected 'Value 2', AsyncLocal value is 'Value 2', ThreadLocal value is 'Value 2'
'   Exiting AsyncMethodB.
'      Expected 'Value 2', got 'Value 2', ThreadLocal value is ''
'   Exiting AsyncMethodB.
'      Expected 'Value 1', got 'Value 1', ThreadLocal value is ''
' </Snippet1>

