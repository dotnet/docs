' <Snippet1>   

Imports System
Imports System.Reflection
Module Module1
    Public Class MyClass1
        Private myProperty1 As Integer
        ' Declare MyProperty.
        Public Property MyProperty() As Integer
            Get
                Return myProperty1
            End Get
            Set(ByVal Value As Integer)
                myProperty1 = Value
            End Set
        End Property
        Public Shared Sub Main()
            Try
                ' Get a Type object corresponding to MyClass.
                Dim myType As Type = GetType(MyClass1)
                ' Get a PropertyInfo object by passing property name and specifying BindingFlags.
                Dim myPropInfo As PropertyInfo = myType.GetProperty("MyProperty", BindingFlags.Public Or BindingFlags.Instance)
                ' Display the Name property.
                Console.WriteLine("{0} is a property of MyClass.", myPropInfo.Name)
            Catch e As NullReferenceException
                Console.WriteLine("MyProperty does not exist in MyClass.", e.Message.ToString())
            End Try
        End Sub 'Main
    End Class 'MyClass1
End Module 'Module1
' </Snippet1>