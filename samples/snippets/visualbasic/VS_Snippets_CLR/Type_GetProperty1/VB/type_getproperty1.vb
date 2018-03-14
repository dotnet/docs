' <Snippet1>   
Imports System
Imports System.Reflection
Class MyClass1
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
End Class 'MyClass1

Public Class MyTypeClass
    Public Shared Sub Main(ByVal args() As String)
        Try
            ' Get Type Object corresponding to MyClass.
            Dim myType As Type = GetType(MyClass1)
            ' Get PropertyInfo object by passing property name.
            Dim myPropInfo As PropertyInfo = myType.GetProperty("MyProperty")
            ' Display Name propety to console.
            Console.WriteLine("The {0} property exists in MyClass.", myPropInfo.Name)
        Catch e As NullReferenceException
            Console.WriteLine("The property does not exist in MyClass.", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyTypeClass 
' </Snippet1>





