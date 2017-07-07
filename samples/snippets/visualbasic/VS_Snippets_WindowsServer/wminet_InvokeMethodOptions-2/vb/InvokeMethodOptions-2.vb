'<Snippet1>
Imports System
Imports System.Management

' This sample demonstrates invoking
' a WMI method using parameter objects
Class InvokeMethod
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the object on which the
        ' method will be invoked
        Dim processClass As _
            New ManagementClass("root\CIMV2", _
            "Win32_Process", _
            Nothing)

        ' Get an input parameters object for this method
        Dim inParams As ManagementBaseObject = _
            processClass.GetMethodParameters("Create")

        ' Fill in input parameter values
        inParams("CommandLine") = "calc.exe"

        ' Method Options
        Dim methodOptions As New InvokeMethodOptions( _
            Nothing, System.TimeSpan.MaxValue)

        ' Execute the method
        Dim outParams As ManagementBaseObject = _
            processClass.InvokeMethod( _
            "Create", inParams, methodOptions)

        ' Display results
        ' Note: The return code of the method 
        ' is provided in the "returnValue" property
        ' of the outParams object
        Console.WriteLine( _
            "Creation of calculator process returned: {0}", _
            outParams("returnValue"))
        Console.WriteLine("Process ID: {0}", _
            outParams("processId"))

        Return 0
    End Function
End Class
'</Snippet1>