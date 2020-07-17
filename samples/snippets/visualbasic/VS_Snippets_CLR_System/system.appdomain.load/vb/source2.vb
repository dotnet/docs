'<snippet2>
Imports System.Reflection

Public Class Asmload0
    Public Shared Sub Main()
        ' Use the file name to load the assembly into the current
        ' application domain.
        Dim a As Assembly = Assembly.Load("example")
        ' Get the type to use.
        Dim myType As Type = a.GetType("Example")
        ' Get the method to call.
        Dim myMethod As MethodInfo = myType.GetMethod("MethodA")
        ' Create an instance.
        Dim obj As Object = Activator.CreateInstance(myType)
        ' Execute the method.
        myMethod.Invoke(obj, Nothing)
    End Sub
End Class
'</snippet2>
