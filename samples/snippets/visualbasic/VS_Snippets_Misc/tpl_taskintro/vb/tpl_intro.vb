Imports System.Threading

Namespace Introduction
    Class Program

        Public Shared Sub Main()
            SimpleTaskCreation()
            ChildTaskSnippets()
            TaskDemo2()
            Console.ReadKey()
        End Sub


        Shared Sub SimpleTaskCreation()
            '<snippet01>
            ' Create a task and supply a user delegate by using a lambda expression.
            Dim taskA = New Task(Sub() Console.WriteLine("Hello from taskA."))

            ' Start the task.
            taskA.Start()

            ' Output a message from the calling thread.
            Console.WriteLine("Hello from the calling thread.")

            ' Output:
            ' Hello from the calling thread.
            ' Hello from taskA.

            '</snippet01>
        End Sub

        Sub SimpleStartNew()

            '<snippet09>
            ' Better: Create and start the task in one operation.
            Dim taskA = Task.Factory.StartNew(Sub() Console.WriteLine("Hello from taskA."))

            ' Output a message from the calling thread.
            Console.WriteLine("Hello from the calling thread.")
            '</snippet09>
        End Sub


        '<snippet02>

        Class MyCustomData

            Public CreationTime As Long
            Public Name As Integer
            Public ThreadNum As Integer
        End Class

        Shared Sub TaskDemo2()
            ' Create the task object by using an Action(Of Object) to pass in custom data
            ' in the Task constructor. This is useful when you need to capture outer variables
            ' from within a loop.
            ' As an experiment, try modifying this code to capture i directly in the lambda,
            ' and compare results.
            Dim taskArray() As Task
            ReDim taskArray(10)
            For i As Integer = 0 To taskArray.Length - 1
                taskArray(i) = New Task(Sub(obj As Object)
                                            Dim mydata = CType(obj, MyCustomData)
                                            mydata.ThreadNum = Environment.CurrentManagedThreadId
                                            Console.WriteLine("Hello from Task #{0} created at {1} running on thread #{2}.",
                                                            mydata.Name, mydata.CreationTime, mydata.ThreadNum)
                                        End Sub,
                New MyCustomData With {.Name = i, .CreationTime = Date.Now.Ticks}
                )
                taskArray(i).Start()
            Next

        End Sub

        '</snippet02>

        Sub TaskDemo3()
            '<snippet03>

            Dim task3 = New Task(Sub() MyLongRunningMethod(),
                                    TaskCreationOptions.LongRunning Or TaskCreationOptions.PreferFairness)
            task3.Start()
            '</snippet03>

        End Sub

        ' dummy methods
        Sub MyLongRunningMethod()
        End Sub
        Function DoComputation1() As Double
            Return 1.0
        End Function
        Function DoComputation2() As Double
            DoComputation2 = 1.0
        End Function
        Function DoComputation3() As Double
            DoComputation3 = 1.0
        End Function
        Function GetFileData() As Byte()
            Dim filedata As Byte() = {10}
            Return filedata
        End Function
        Function Analyze(ByVal input() As Byte) As Double()
            Dim result As Double() = {1.0}
            Return result
        End Function
        Function Summarize(ByVal d As Double) As String
            Return "Looks good."
        End Function

        Sub MethodA()
        End Sub
        Sub MethodB()
        End Sub

        Sub MethodC()
        End Sub

        Sub MoreSimple()

            '<snippet04>
            Dim taskArray() = {Task(Of Double).Factory.StartNew(Function() DoComputation1()),
                Task(Of Double).Factory.StartNew(Function() DoComputation2()),
                Task(Of Double).Factory.StartNew(Function() DoComputation3())}


            Dim results() As Double
            ReDim results(taskArray.Length)
            For i As Integer = 0 To taskArray.Length
                results(i) = taskArray(i).Result
            Next
            '</snippet04>

            '<snippet05>
            Dim getData As Task(Of Byte()) = New Task(Of Byte())(Function() GetFileData())
            Dim analyzeData As Task(Of Double()) = getData.ContinueWith(Function(x) Analyze(x.Result))
            Dim reportData As Task(Of String) = analyzeData.ContinueWith(Function(y As Task(Of Double)) Summarize(y.Result))

            getData.Start()

            IO.File.WriteAllText("C:\reportFolder\report.txt", reportData.Result)

            '</snippet05>


            '<snippet06>
            Dim tasks() =
            {
                Task.Factory.StartNew(Sub() MethodA()),
                Task.Factory.StartNew(Sub() MethodB()),
                Task.Factory.StartNew(Sub() MethodC())
            }

            ' Block until all tasks complete.
            Task.WaitAll(tasks)

            ' Continue on this thread...
            '</snippet06>

        End Sub

        Shared Sub ChildTaskSnippets()

            '<snippet07>
            Dim outer = Task.Factory.StartNew(Sub()
                                                  Console.WriteLine("Outer task beginning.")
                                                  Dim child = Task.Factory.StartNew(Sub()
                                                                                        Thread.SpinWait(5000000)
                                                                                        Console.WriteLine("Detached task completed.")
                                                                                    End Sub)
                                              End Sub)
            outer.Wait()
            Console.WriteLine("Outer task completed.")
            ' The example displays the following output:
            '     Outer task beginning.
            '     Outer task completed.
            '    Detached child completed.
            '</snippet07>

            '<snippet08>
            Dim parent = Task.Factory.StartNew(Sub()
                                                   Console.WriteLine("Parent task beginning.")
                                                   Dim child = Task.Factory.StartNew(Sub()
                                                                                         Thread.SpinWait(5000000)
                                                                                         Console.WriteLine("Attached task completed.")
                                                                                     End Sub,
                                                        TaskCreationOptions.AttachedToParent)

                                               End Sub)
            outer.Wait()
            Console.WriteLine("Parent task completed.")

            ' Output:
            '     Parent task beginning.
            '     Attached task completed.
            '     Parent task completed.
            '</snippet08>



            Dim t = Task(Of Integer).Factory.StartNew(Function() 1)


        End Sub


    End Class
End Namespace
