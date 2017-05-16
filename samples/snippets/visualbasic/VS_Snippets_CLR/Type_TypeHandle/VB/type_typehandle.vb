' <Snippet1>	
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic
Class [MyClass]
    Public myField As Integer = 10
End Class '[MyClass]
Class Type_TypeHandle
    Public Shared Sub Main()
        Try
            Dim [myClass] As New [MyClass]()

            ' Get the type of MyClass.
            Dim myClassType As Type = [myClass].GetType()

            ' Get the runtime handle of MyClass.
            Dim myClassHandle As RuntimeTypeHandle = myClassType.TypeHandle

            DisplayTypeHandle(myClassHandle)
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main

    Public Shared Sub DisplayTypeHandle(ByVal myTypeHandle As RuntimeTypeHandle)
        ' Get the type from the handle.
        Dim myType As Type = Type.GetTypeFromHandle(myTypeHandle)
        ' Display the type.
        Console.WriteLine(ControlChars.NewLine + "Displaying the type from the handle:" + ControlChars.NewLine)
        Console.WriteLine("The type is {0}.", myType.ToString())
    End Sub 'DisplayTypeHandle
End Class 'Type_TypeHandle
' </Snippet1>