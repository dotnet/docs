Imports System
Imports System.Reflection
Imports System.Security

' <Snippet1>
Public Class MyClass1
    Public Sub New(ByVal i As Integer)
    End Sub
    Public Shared Sub Main()
        Try
            Dim myType As Type = GetType(MyClass1)
            Dim types(0) As Type
            types(0) = GetType(Integer)
            ' Get the public instance constructor that takes an integer parameter.
            Dim constructorInfoObj As ConstructorInfo = _
                        myType.GetConstructor(BindingFlags.Instance Or _
                        BindingFlags.Public, Nothing, _
                        CallingConventions.HasThis, types, Nothing)
            If Not (constructorInfoObj Is Nothing) Then
                Console.WriteLine("The constructor of MyClass1 that " + _
                                  "is a public instance method and takes an " + _
                                  "integer as a parameter is: ")
                Console.WriteLine(constructorInfoObj.ToString())
            Else
                Console.WriteLine("The constructor MyClass1 that " + _
                                  "is a public instance method and takes an " + _
                                  "integer as a parameter is not available.")
            End If
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException: " + e.Message)
        Catch e As ArgumentException
            Console.WriteLine("ArgumentException: " + e.Message)
        Catch e As SecurityException
            Console.WriteLine("SecurityException: " + e.Message)
        Catch e As Exception
            Console.WriteLine("Exception: " + e.Message)
        End Try
    End Sub
End Class
' </Snippet1>