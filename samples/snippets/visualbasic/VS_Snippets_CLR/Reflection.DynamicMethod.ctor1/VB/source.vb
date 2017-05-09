' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports Microsoft.VisualBasic

Public Class Test
    ' Declare a delegate that will be used to execute the completed
    ' dynamic method. 
    Private Delegate Function HelloInvoker(ByVal msg As String, _
        ByVal ret As Integer) As Integer

    Public Shared Sub Main()
        ' Create an array that specifies the types of the parameters
        ' of the dynamic method. This method has a String parameter
        ' and an Integer parameter.
        Dim helloArgs() As Type = {GetType(String), GetType(Integer)}

        ' Create a dynamic method with the name "Hello", a return type
        ' of Integer, and two parameters whose types are specified by
        ' the array helloArgs. Create the method in the module that
        ' defines the Test class.
        Dim hello As New DynamicMethod("Hello", _
            GetType(Integer), _
            helloArgs, _
            GetType(Test).Module)

        ' <Snippet2>
        ' Create an array that specifies the parameter types of the
        ' overload of Console.WriteLine to be used in Hello.
        Dim writeStringArgs() As Type = {GetType(String)}
        ' Get the overload of Console.WriteLine that has one
        ' String parameter.
        Dim writeString As MethodInfo = GetType(Console). _
            GetMethod("WriteLine", writeStringArgs) 

        ' Get an ILGenerator and emit a body for the dynamic method.
        Dim il As ILGenerator = hello.GetILGenerator()
        ' Load the first argument, which is a string, onto the stack.
        il.Emit(OpCodes.Ldarg_0)
        ' Call the overload of Console.WriteLine that prints a string.
        il.EmitCall(OpCodes.Call, writeString, Nothing)
        ' The Hello method returns the value of the second argument;
        ' to do this, load the onto the stack and return.
        il.Emit(OpCodes.Ldarg_1)
        il.Emit(OpCodes.Ret)
        ' </Snippet2>

        ' <Snippet3>
        ' Create a delegate that represents the dynamic method. This
        ' action completes the method, and any further attempts to
        ' change the method will cause an exception.
	Dim hi As HelloInvoker = _
            hello.CreateDelegate(GetType(HelloInvoker))
        ' </Snippet3>

        ' Use the delegate to execute the dynamic method. Save and
        ' print the return value.
        Dim retval As Integer = hi(vbCrLf & "Hello, World!", 42)
        Console.WriteLine("Executing delegate hi(""Hello, World!"", 42) returned " _
            & retval)

        ' Do it again, with different arguments.
        retval = hi(vbCrLf & "Hi, Mom!", 5280)
        Console.WriteLine("Executing delegate hi(""Hi, Mom!"", 5280) returned " _
            & retval)

        ' <Snippet4>
        ' Create an array of arguments to use with the Invoke method.
        Dim invokeArgs() As Object = {vbCrLf & "Hello, World!", 42}
        ' Invoke the dynamic method using the arguments. This is much
        ' slower than using the delegate, because you must create an
        ' array to contain the arguments, and ValueType arguments
        ' must be boxed. Note that this overload of Invoke is 
        ' inherited from MethodBase, and simply calls the more 
        ' complete overload of Invoke.
        Dim objRet As Object = hello.Invoke(Nothing, invokeArgs)
        Console.WriteLine("hello.Invoke returned " & objRet)
        ' </Snippet4>
    End Sub
End Class

' This code example produces the following output:
'
'Hello, World!
'Executing delegate hi("Hello, World!", 42) returned 42
'
'Hi, Mom!
'Executing delegate hi("Hi, Mom!", 5280) returned 5280
'
'Hello, World!
'hello.Invoke returned 42
'
' </Snippet1>
