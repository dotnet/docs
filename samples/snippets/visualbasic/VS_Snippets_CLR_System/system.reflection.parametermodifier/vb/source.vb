
Imports System
Imports System.Reflection

Class ParmInfoTest
    Public Shared Sub Main()
        Dim obj As Object = New ParmInfoTest()

        ' <Snippet1>
        ' Create an array containing the arguments.
        Dim args As Object = {"Argument 1", "Argument 2", "Argument 3" }

        ' Initialize a ParameterModifier with the number of parameters.
        Dim p As New ParameterModifier(3)

        ' Pass the first and third parameters by reference.
        p(0) = True
        p(2) = True

        ' The ParameterModifier must be passed as the single element
        ' of an array.
        Dim mods() As ParameterModifier = { p }

        ' Invoke the method late bound.
        obj.GetType().InvokeMember("MethodName", BindingFlags.InvokeMethod, _
             Nothing, obj, args, mods, Nothing, Nothing)
        ' </Snippet1>
    End Sub

    Public Sub MethodName(ByRef str1 As String, ByVal str2 As String, ByRef str3 As String)
        Console.WriteLine("Called 'MethodName'")
    End Sub
End Class





