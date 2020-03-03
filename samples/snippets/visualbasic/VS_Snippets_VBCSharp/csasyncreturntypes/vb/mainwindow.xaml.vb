
'<snippet9>
Class MainWindow

    '<snippet8>
    ' SUB EXAMPLE
    Async Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click

        textBox1.Clear()

        ' Start the process and await its completion. DriverAsync is a 
        ' Task-returning async method.
        Await DriverAsync()

        ' Say goodbye.
        textBox1.Text &= vbCrLf & "All done, exiting button-click event handler."
    End Sub
    '</snippet8>


    Async Function DriverAsync() As Task

        ' Task(Of T) 
        '<snippet2>
        ' Call and await the Task(Of T)-returning async method in the same statement.
        Dim result1 As Integer = Await TaskOfT_MethodAsync()
        '</snippet2>

        '<snippet3>
        ' Call and await in separate statements.
        Dim integerTask As Task(Of Integer) = TaskOfT_MethodAsync()

        ' You can do other work that does not rely on resultTask before awaiting.
        textBox1.Text &= String.Format("Application can continue working while the Task(Of T) runs. . . . " & vbCrLf)

        Dim result2 As Integer = Await integerTask
        '</snippet3>

        '<snippet4>
        ' Display the values of the result1 variable, the result2 variable, and
        ' the resultTask.Result property.
        textBox1.Text &= String.Format(vbCrLf & "Value of result1 variable:   {0}" & vbCrLf, result1)
        textBox1.Text &= String.Format("Value of result2 variable:   {0}" & vbCrLf, result2)
        textBox1.Text &= String.Format("Value of resultTask.Result:  {0}" & vbCrLf, integerTask.Result)
        '</snippet4>

        ' Task 
        '<snippet6>
        ' Call and await the Task-returning async method in the same statement.
        Await Task_MethodAsync()
        '</snippet6>

        '<snippet7>
        ' Call and await in separate statements.
        Dim simpleTask As Task = Task_MethodAsync()

        ' You can do other work that does not rely on simpleTask before awaiting.
        textBox1.Text &= String.Format(vbCrLf & "Application can continue working while the Task runs. . . ." & vbCrLf)

        Await simpleTask
        '</snippet7>
    End Function


    '<snippet1>
    ' TASK(OF T) EXAMPLE
    Async Function TaskOfT_MethodAsync() As Task(Of Integer)

        ' The body of an async method is expected to contain an awaited 
        ' asynchronous call.
        ' Task.FromResult is a placeholder for actual work that returns a string.
        Dim today As String = Await Task.FromResult(Of String)(DateTime.Now.DayOfWeek.ToString())

        ' The method then can process the result in some way.
        Dim leisureHours As Integer
        If today.First() = "S" Then
            leisureHours = 16
        Else
            leisureHours = 5
        End If

        ' Because the return statement specifies an operand of type Integer, the 
        ' method must have a return type of Task(Of Integer). 
        Return leisureHours
    End Function
    '</snippet1>


    '<snippet5>
    ' TASK EXAMPLE
    Async Function Task_MethodAsync() As Task

        ' The body of an async method is expected to contain an awaited 
        ' asynchronous call.
        ' Task.Delay is a placeholder for actual work.
        Await Task.Delay(2000)
        textBox1.Text &= String.Format(vbCrLf & "Sorry for the delay. . . ." & vbCrLf)

        ' This method has no return statement, so its return type is Task. 
    End Function
    '</snippet5>

End Class
'</snippet9>


' Output:

'<snippet10>
'Application can continue working while the Task(Of T) runs. . . . 

'Value of result1 variable:   5
'Value of result2 variable:   5
'Value of resultTask.Result:  5

'Sorry for the delay. . . .

'Application can continue working while the Task runs. . . .

'Sorry for the delay. . . .

'All done, exiting button-click event handler.
'</snippet10>