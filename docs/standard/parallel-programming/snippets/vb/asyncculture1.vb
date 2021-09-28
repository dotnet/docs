' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub Main()
        Dim values() As Decimal = {163025412.32D, 18905365.59D}
        Dim formatString As String = "C2"
        Dim formatDelegate As Func(Of String) = Function()
                                                    Dim output As String = String.Format("Formatting using the {0} culture on thread {1}.",
                                                                                         CultureInfo.CurrentCulture.Name,
                                                                                         Thread.CurrentThread.ManagedThreadId)
                                                    output += Environment.NewLine
                                                    For Each value In values
                                                        output += String.Format("{0}   ", value.ToString(formatString))
                                                    Next
                                                    output += Environment.NewLine
                                                    Return output
                                                End Function

        Console.WriteLine("The example is running on thread {0}",
                          Thread.CurrentThread.ManagedThreadId)
        ' Make the current culture different from the system culture.
        Console.WriteLine("The current culture is {0}",
                          CultureInfo.CurrentCulture.Name)
        If CultureInfo.CurrentCulture.Name = "fr-FR" Then
            Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Else
            Thread.CurrentThread.CurrentCulture = New CultureInfo("fr-FR")
        End If
        Console.WriteLine("Changed the current culture to {0}.",
                          CultureInfo.CurrentCulture.Name)
        Console.WriteLine()

        ' Execute the delegate synchronously.
        Console.WriteLine("Executing the delegate synchronously:")
        Console.WriteLine(formatDelegate())

        ' Call an async delegate to format the values using one format string.
        Console.WriteLine("Executing a task asynchronously:")
        Dim t1 = Task.Run(formatDelegate)
        Console.WriteLine(t1.Result)

        Console.WriteLine("Executing a task synchronously:")
        Dim t2 = New Task(Of String)(formatDelegate)
        t2.RunSynchronously()
        Console.WriteLine(t2.Result)
    End Sub
End Module

' The example displays the following output:
'
'          The example is running on thread 1
'          The current culture is en-US
'          Changed the current culture to fr-FR.
'
'          Executing the delegate synchronously:
'          Formatting Imports the fr-FR culture on thread 1.
'          163 025 412,32 €   18 905 365,59 €
'
'          Executing a task asynchronously:
'          Formatting Imports the fr-FR culture on thread 3.
'          163 025 412,32 €   18 905 365,59 €
'
'          Executing a task synchronously:
'          Formatting Imports the fr-FR culture on thread 1.
'          163 025 412,32 €   18 905 365,59 €
' </Snippet1>
