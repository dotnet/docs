'<Snippet1>
Imports System
Imports System.Management

' This sample demonstrates invoking a WMI method
' using an array of arguments.
Class InvokeMethod
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the object on which the method will be invoked
        Dim processClass As _
            New ManagementClass("Win32_Process")

        ' Create an array containing all arguments 
        ' for the method
        Dim methodArgs() As Object = _
            {"notepad.exe", Nothing, Nothing, 0}

        ' Execute the method
        Dim result As Object = _
            processClass.InvokeMethod("Create", methodArgs)

        ' Display results
        Console.WriteLine( _
            "Creation of process returned: {0}", result)
        Console.WriteLine( _
            "Process id: {0}", methodArgs(3))
        Return 0
    End Function
End Class
'</Snippet1>