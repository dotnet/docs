' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Public Class Example1
    Shared test As New TestClass(3)

    Public Shared Sub Main()
        Dim ex As New Example1()
        Console.WriteLine(test.Value)
    End Sub
End Class

Public Class TestClass
   Public ReadOnly Value As Integer
   
   Public Sub New(value As Integer)
        If value < 0 Or value > 1 Then Throw New ArgumentOutOfRangeException(NameOf(value))
        value = value
   End Sub
End Class
' The example displays the following output:
'    Unhandled Exception: System.TypeInitializationException: 
'       The type initializer for 'Example' threw an exception. ---> 
'       System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
'       at TestClass..ctor(Int32 value)
'       at Example..cctor()
'       --- End of inner exception stack trace ---
'       at Example.Main()
' </Snippet3>

