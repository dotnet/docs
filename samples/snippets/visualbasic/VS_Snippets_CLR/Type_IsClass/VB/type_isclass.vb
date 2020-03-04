' <Snippet1>
Imports System.Reflection

Public Class MyDemoClass
End Class

Public Class MyTypeClass
    Public Shared Sub Main()
        Try
            Dim myType As Type = GetType(MyDemoClass)
            ' Get and display the 'IsClass' property of the 'MyDemoClass' instance.
            Console.WriteLine(ControlChars.Cr + "Is the specified type a class? {0}.", myType.IsClass.ToString())
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "An exception occurred: {0}.", e.Message.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
