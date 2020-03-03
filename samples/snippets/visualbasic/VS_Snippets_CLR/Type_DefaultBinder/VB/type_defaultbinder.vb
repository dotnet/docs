' <Snippet1>
Imports System.Reflection

Public Class MyDefaultBinderSample
    Public Shared Sub Main()
        Try
            Dim defaultBinder As Binder = Type.DefaultBinder
            Dim [myClass] As New [MyClass]()
            ' Invoke the HelloWorld method of MyClass.
            [myClass].GetType().InvokeMember("HelloWorld", BindingFlags.InvokeMethod, defaultBinder, [myClass], New Object() {})
        Catch e As Exception
            Console.WriteLine("Exception :" + e.Message.ToString())
        End Try
    End Sub

    Class [MyClass]

        Public Sub HelloWorld()
            Console.WriteLine("Hello World")
        End Sub
    End Class
End Class
' </Snippet1>
