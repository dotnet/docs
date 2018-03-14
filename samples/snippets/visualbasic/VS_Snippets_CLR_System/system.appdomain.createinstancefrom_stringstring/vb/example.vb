'<Snippet1>
Imports System

Public Interface ITest

    Sub Test(ByVal greeting As String)
End Interface

Public Class MarshallableExample 
    Inherits MarshalByRefObject
    Implements ITest

    Shared Sub Main()
    
        ' Construct a path to the current assembly.
        Dim assemblyPath As String = Environment.CurrentDirectory & "\" &
            GetType(MarshallableExample).Assembly.GetName().Name & ".exe"

        Dim ad As AppDomain = AppDomain.CreateDomain("MyDomain")
 
        Dim oh As System.Runtime.Remoting.ObjectHandle = 
            ad.CreateInstanceFrom(assemblyPath, "MarshallableExample")

        Dim obj As Object = oh.Unwrap()


        ' Three ways to use the newly created object, depending on how
        ' much is known about the type: Late bound, early bound through 
        ' a mutually known interface, or early binding of a known type.
        '
        obj.GetType().InvokeMember("Test", 
            System.Reflection.BindingFlags.InvokeMethod, 
            Type.DefaultBinder, obj, New Object() { "Hello" })

        Dim it As ITest = CType(obj, ITest) 
        it.Test("Hi")

        Dim ex As MarshallableExample = CType(obj, MarshallableExample) 
        ex.Test("Goodbye")
    End Sub

    Public Sub Test(ByVal greeting As String) Implements ITest.Test
    
        Console.WriteLine("{0} from '{1}'!", greeting,
            AppDomain.CurrentDomain.FriendlyName)
    End Sub
End Class

' This example produces the following output:
'
'Hello from 'MyDomain'!
'Hi from 'MyDomain'!
'Goodbye from 'MyDomain'!
'</Snippet1>
