' <Snippet1>
Imports System
Imports System.Reflection
Class MyClass1
    Private myMessage As [String] = "Hello World."
    Public Property MyProperty1() As String
        Get
            Return myMessage
        End Get
        Set(ByVal Value As String)
            myMessage = Value
        End Set
    End Property
End Class 'MyClass1

Class TestClass
    Shared Sub Main()
        Try
            Dim myType As Type = GetType(MyClass1)
            ' Get the PropertyInfo object representing MyProperty1. 
            Dim myStringProperties1 As PropertyInfo = myType.GetProperty("MyProperty1", GetType(String))
            Console.WriteLine("The name of the first property of MyClass1 is {0}.", myStringProperties1.Name)
            Console.WriteLine("The type of the first property of MyClass1 is {0}.", myStringProperties1.PropertyType.ToString())
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException :" + e.Message.ToString())
        Catch e As AmbiguousMatchException
            Console.WriteLine("AmbiguousMatchException :" + e.Message.ToString())
        Catch e As NullReferenceException
            Console.WriteLine("Source : {0}", e.Source.ToString())
            Console.WriteLine("Message : {0}", e.Message.ToString())
        End Try
	'Output:
	'The name of the first property of MyClass1 is MyProperty1.
	'The type of the first property of MyClass1 is System.String.

    End Sub 'Main
End Class 'TestClass
' </Snippet1>	
