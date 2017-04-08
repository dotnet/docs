' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports Microsoft.VisualBasic
Imports System.Globalization

Public Class Test
    ' Declare a delegate type that can be used to execute the completed
    ' dynamic method. 
    Private Delegate Function HelloDelegate(ByVal msg As String, _
        ByVal ret As Integer) As Integer

    Public Shared Sub Main()
        ' Create an array that specifies the types of the parameters
        ' of the dynamic method. This dynamic method has a String
        ' parameter and an Integer parameter.
        Dim helloArgs() As Type = {GetType(String), GetType(Integer)}

        ' Create a dynamic method with the name "Hello", a return type
        ' of Integer, and two parameters whose types are specified by
        ' the array helloArgs. Create the method in the module that
        ' defines the String class.
        Dim hello As New DynamicMethod("Hello", _
            GetType(Integer), _
            helloArgs, _
            GetType(String).Module)

        ' <Snippet2>
        ' Create an array that specifies the parameter types of the
        ' overload of Console.WriteLine to be used in Hello.
        Dim writeStringArgs() As Type = {GetType(String)}
        ' Get the overload of Console.WriteLine that has one
        ' String parameter.
        Dim writeString As MethodInfo = GetType(Console). _
            GetMethod("WriteLine", writeStringArgs) 

        ' Get an ILGenerator and emit a body for the dynamic method,
        ' using a stream size larger than the IL that will be
        ' emitted.
        Dim il As ILGenerator = hello.GetILGenerator(256)
        ' Load the first argument, which is a string, onto the stack.
        il.Emit(OpCodes.Ldarg_0)
        ' Call the overload of Console.WriteLine that prints a string.
        il.EmitCall(OpCodes.Call, writeString, Nothing)
        ' The Hello method returns the value of the second argument;
        ' to do this, load the onto the stack and return.
        il.Emit(OpCodes.Ldarg_1)
        il.Emit(OpCodes.Ret)
        ' </Snippet2>

        ' <Snippet33>
        ' Add parameter information to the dynamic method. (This is not
        ' necessary, but can be useful for debugging.) For each parameter,
        ' identified by position, supply the parameter attributes and a 
        ' parameter name.
        hello.DefineParameter(1, ParameterAttributes.In, "message")
        hello.DefineParameter(2, ParameterAttributes.In, "valueToReturn")
        ' </Snippet33>

        ' <Snippet3>
        ' Create a delegate that represents the dynamic method. This
        ' action completes the method. Any further attempts to
        ' change the method are ignored.
	Dim hi As HelloDelegate = _
            CType(hello.CreateDelegate(GetType(HelloDelegate)), HelloDelegate)

        ' Use the delegate to execute the dynamic method.
        Console.WriteLine(vbCrLf & "Use the delegate to execute the dynamic method:")
        Dim retval As Integer = hi(vbCrLf & "Hello, World!", 42)
        Console.WriteLine("Invoking delegate hi(""Hello, World!"", 42) returned: " _
            & retval & ".")

        ' Execute it again, with different arguments.
        retval = hi(vbCrLf & "Hi, Mom!", 5280)
        Console.WriteLine("Invoking delegate hi(""Hi, Mom!"", 5280) returned: " _
            & retval & ".")
        ' </Snippet3>

        ' <Snippet4>
        Console.WriteLine(vbCrLf & "Use the Invoke method to execute the dynamic method:")
        ' Create an array of arguments to use with the Invoke method.
        Dim invokeArgs() As Object = {vbCrLf & "Hello, World!", 42}
        ' Invoke the dynamic method using the arguments. This is much
        ' slower than using the delegate, because you must create an
        ' array to contain the arguments, and value-type arguments
        ' must be boxed.
        Dim objRet As Object = hello.Invoke(Nothing, _
            BindingFlags.ExactBinding, Nothing, invokeArgs, _
            New CultureInfo("en-us"))
        Console.WriteLine("hello.Invoke returned: {0}", objRet)
        ' </Snippet4>

        Console.WriteLine(vbCrLf & _
            " ----- Display information about the dynamic method -----")
        ' <Snippet21>
        ' Display MethodAttributes for the dynamic method, set when 
        ' the dynamic method was created.
        Console.WriteLine(vbCrLf & "Method Attributes: {0}", _
            hello.Attributes)
        ' </Snippet21>

        ' <Snippet22>
        ' Display the calling convention of the dynamic method, set when the 
        ' dynamic method was created.
        Console.WriteLine(vbCrLf & "Calling convention: {0}", _ 
            hello.CallingConvention)
        ' </Snippet22>

        ' <Snippet23>
        ' Display the declaring type, which is always Nothing for dynamic
        ' methods.
        If hello.DeclaringType Is Nothing Then
            Console.WriteLine(vbCrLf & "DeclaringType is always Nothing for dynamic methods.")
        Else
            Console.WriteLine("DeclaringType: {0}", hello.DeclaringType)
        End If
        ' </Snippet23>

        ' <Snippet24>
        ' Display the default value for InitLocals.
        If hello.InitLocals Then
            Console.Write(vbCrLf & "This method contains verifiable code.")
        Else
            Console.Write(vbCrLf & "This method contains unverifiable code.")
        End If
        Console.WriteLine(" (InitLocals = {0})", hello.InitLocals)
        ' </Snippet24>

        ' <Snippet26>
        ' Display the module specified when the dynamic method was created.
        Console.WriteLine(vbCrLf & "Module: {0}", hello.Module)
        ' </Snippet26>

        ' <Snippet27>
        ' Display the name specified when the dynamic method was created.
        ' Note that the name can be blank.
        Console.WriteLine(vbCrLf & "Name: {0}", hello.Name)
        ' </Snippet27>

        ' <Snippet28>
        ' For dynamic methods, the reflected type is always Nothing.
        If hello.ReflectedType Is Nothing Then
            Console.WriteLine(vbCrLf & "ReflectedType is Nothing.")
        Else
            Console.WriteLine(vbCrLf & "ReflectedType: {0}", _
                hello.ReflectedType)
        End If
        ' </Snippet28>

        ' <Snippet29>
        If hello.ReturnParameter Is Nothing Then
            Console.WriteLine(vbCrLf & "Method has no return parameter.")
        Else
            Console.WriteLine(vbCrLf & "Return parameter: {0}", _
                hello.ReturnParameter)
        End If
        ' </Snippet29>

        ' <Snippet30>
        ' If the method has no return type, ReturnType is System.Void.
        Console.WriteLine(vbCrLf & "Return type: {0}", hello.ReturnType)           
        ' </Snippet30>

        ' <Snippet31>
        ' ReturnTypeCustomAttributes returns an ICustomeAttributeProvider
        ' that can be used to enumerate the custom attributes of the
        ' return value. At present, there is no way to set such custom
        ' attributes, so the list is empty.
        If hello.ReturnType Is GetType(System.Void) Then
            Console.WriteLine("The method has no return type.")
        Else
            Dim caProvider As ICustomAttributeProvider = _
                hello.ReturnTypeCustomAttributes
            Dim returnAttributes() As Object = _
                caProvider.GetCustomAttributes(True)
            If returnAttributes.Length = 0 Then
                Console.WriteLine(vbCrLf _
                    & "The return type has no custom attributes.")
            Else
                Console.WriteLine(vbCrLf _
                    & "The return type has the following custom attributes:")
                For Each attr As Object In returnAttributes
                    Console.WriteLine(vbTab & attr.ToString())
                Next attr
            End If
        End If
        ' </Snippet31>

        ' <Snippet32>
        Console.WriteLine(vbCrLf & "ToString: " & hello.ToString())
        ' </Snippet32>

        ' <Snippet34>
        ' Display parameter information.
        Dim parameters() As ParameterInfo = hello.GetParameters()
        Console.WriteLine(vbCrLf & "Parameters: name, type, ParameterAttributes")
        For Each p As ParameterInfo In parameters
            Console.WriteLine(vbTab & "{0}, {1}, {2}", _ 
                p.Name, p.ParameterType, p.Attributes)
        Next p
        ' </Snippet34>
    End Sub
End Class

' This code example produces the following output:
'
'Use the delegate to execute the dynamic method:
'
'Hello, World!
'Invoking delegate hi("Hello, World!", 42) returned: 42.
'
'Hi, Mom!
'Invoking delegate hi("Hi, Mom!", 5280) returned: 5280.
'
'Use the Invoke method to execute the dynamic method:
'
'Hello, World!
'hello.Invoke returned: 42
'
' ----- Display information about the dynamic method -----
'
'Method Attributes: PrivateScope, Public, Static
'
'Calling convention: Standard
'
'DeclaringType is always Nothing for dynamic methods.
'
'This method contains verifiable code. (InitLocals = True)
'
'Module: CommonLanguageRuntimeLibrary
'
'Name: Hello
'
'ReflectedType is Nothing.
'
'Method has no return parameter.
'
'Return type: System.Int32
'
'The return type has no custom attributes.
'
'ToString: Int32 Hello(System.String, Int32)
'
'Parameters: name, type, ParameterAttributes
'        message, System.String, In
'        valueToReturn, System.Int32, In
' </Snippet1>
