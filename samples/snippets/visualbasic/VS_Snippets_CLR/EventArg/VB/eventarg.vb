' <Snippet1>
Imports System.Reflection

Public Delegate Sub MyDelegate(ByVal i As Integer)

Public Class MainClass
    Public Event ev As MyDelegate

    Public Shared Sub Main()
        Dim delegateType As Type = GetType(MainClass).GetEvent("ev").EventHandlerType
        Dim invoke As MethodInfo = delegateType.GetMethod("Invoke")
        Dim pars As ParameterInfo() = invoke.GetParameters()
        For Each p As ParameterInfo In pars
            Console.WriteLine(p.ParameterType)
        Next 
    End Sub 
End Class 
' The example displays the following output:
'     System.Int32
' </Snippet1>