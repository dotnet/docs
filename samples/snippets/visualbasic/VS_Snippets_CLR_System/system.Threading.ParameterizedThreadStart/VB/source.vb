' <Snippet1>
Imports System.Threading

Public Class Work
    Shared Sub Main()
        ' Start a thread that calls a parameterized static method.
        Dim newThread As New Thread(AddressOf Work.DoWork)
        newThread.Start(42)

        ' Start a thread that calls a parameterized instance method.
        Dim w As New Work()
        newThread = New Thread(AddressOf w.DoMoreWork)
        newThread.Start("The answer.")
    End Sub
 
    Public Shared Sub DoWork(ByVal data As Object)
        Console.WriteLine("Static thread procedure. Data='{0}'",
                          data)
    End Sub

    Public Sub DoMoreWork(ByVal data As Object) 
        Console.WriteLine("Instance thread procedure. Data='{0}'",
                          data)
    End Sub
End Class
' This example displays output like the following:
'    Static thread procedure. Data='42'
'    Instance thread procedure. Data='The answer.'
' </Snippet1>