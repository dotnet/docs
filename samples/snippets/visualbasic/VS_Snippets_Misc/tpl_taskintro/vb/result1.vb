' Visual Basic .NET Document
Option Strict On

' <Snippet4>

Namespace Result
    Module Example
        Public Sub Main()
            Dim taskArray() = {Task(Of Double).Factory.StartNew(Function() DoComputation(1.0)),
                Task(Of Double).Factory.StartNew(Function() DoComputation(100.0)),
                Task(Of Double).Factory.StartNew(Function() DoComputation(1000.0))}

            Dim results(taskArray.Length - 1) As Double
            Dim sum As Double

            For i As Integer = 0 To taskArray.Length - 1
                results(i) = taskArray(i).Result
                Console.Write("{0:N1} {1}", results(i),
                    If(i = taskArray.Length - 1, "= ", "+ "))
                sum += results(i)
            Next
            Console.WriteLine("{0:N1}", sum)
        End Sub

        Private Function DoComputation(start As Double) As Double
            Dim sum As Double
            For value As Double = start To start + 10 Step .1
                sum += value
            Next
            Return sum
        End Function
    End Module
    ' The example displays the following output:
    '       606.0 + 10,605.0 + 100,495.0 = 111,706.0
End Namespace
' </Snippet4>

