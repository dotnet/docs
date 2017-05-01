' <Snippet1>
Imports System
Imports System.Reflection

' This sample class has a field, constructor, method, and property.
Class MyType
    Private myField As Int32

    Public Sub New(ByRef x As Int32)
        x *= 5
    End Sub 'New

    Public Overrides Function ToString() As [String]
        Return myField.ToString()
    End Function 'ToString

    Public Property MyProp() As Int32
        Get
            Return myField
        End Get
        Set(ByVal Value As Int32)
            If Value < 1 Then
                Throw New ArgumentOutOfRangeException("value", Value, "value must be > 0")
            End If
            myField = Value
        End Set
    End Property
End Class 'MyType

Class MyApp

    Shared Sub Main()
        Dim t As Type = GetType(MyType)
        ' Create an instance of a type.
        Dim args() As [Object] = {8}
        Console.WriteLine("The value of x before the constructor is called is {0}.", args(0))
        Dim obj As [Object] = t.InvokeMember(Nothing, BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.CreateInstance, Nothing, Nothing, args)
        Console.WriteLine("Type: {0}", obj.GetType().ToString())
        Console.WriteLine("The value of x after the constructor returns is {0}.", args(0))

        ' Read and write to a field.
        t.InvokeMember("myField", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetField, Nothing, obj, New [Object]() {5})
        Dim v As Int32 = CType(t.InvokeMember("myField", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, obj, Nothing), Int32)
        Console.WriteLine("myField: {0}", v)

        ' Call a method.
        Dim s As [String] = CType(t.InvokeMember("ToString", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, obj, Nothing), [String])
        Console.WriteLine("ToString: {0}", s)

        ' Read and write a property. First, attempt to assign an
        ' invalid value; then assign a valid value; finally, get
        ' the value.
        Try
            ' Assign the value zero to MyProp. The Property Set 
            ' throws an exception, because zero is an invalid value.
            ' InvokeMember catches the exception, and throws 
            ' TargetInvocationException. To discover the real cause
            ' you must catch TargetInvocationException and examine
            ' the inner exception. 
            t.InvokeMember("MyProp", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty, Nothing, obj, New [Object]() {0})
        Catch e As TargetInvocationException
            ' If the property assignment failed for some unexpected
            ' reason, rethrow the TargetInvocationException.
            If Not e.InnerException.GetType() Is GetType(ArgumentOutOfRangeException) Then
                Throw
            End If
            Console.WriteLine("An invalid value was assigned to MyProp.")
        End Try
        t.InvokeMember("MyProp", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty, Nothing, obj, New [Object]() {2})
        v = CType(t.InvokeMember("MyProp", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetProperty, Nothing, obj, Nothing), Int32)
        Console.WriteLine("MyProp: {0}", v)
    End Sub 'Main
End Class 'MyApp
' </Snippet1>