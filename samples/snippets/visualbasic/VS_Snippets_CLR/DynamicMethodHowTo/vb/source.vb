'<Snippet1>
Imports System.Reflection
Imports System.Reflection.Emit

Public Class Example

    ' The following constructor and private field are used to
    ' demonstrate a method bound to an object.
    '
    Private test As Integer
    Public Sub New(ByVal test As Integer)
        Me.test = test
    End Sub

    ' Declare delegates that can be used to execute the completed 
    ' SquareIt dynamic method. The OneParameter delegate can be 
    ' used to execute any method with one parameter and a return
    ' value, or a method with two parameters and a return value
    ' if the delegate is bound to an object.
    '
    '<Snippet2>
    Private Delegate Function _
        SquareItInvoker(ByVal input As Integer) As Long

    '<Snippet12>
    Private Delegate Function _
        OneParameter(Of TReturn, TParameter0) _
        (ByVal p0 As TParameter0) As TReturn
    '</Snippet12>
    '</Snippet2>

    Public Shared Sub Main()

        ' Example 1: A simple dynamic method.
        '
        ' Create an array that specifies the parameter types for the
        ' dynamic method. In this example the only parameter is an 
        ' Integer, so the array has only one element.
        '
        '<Snippet3>
        Dim methodArgs As Type() = {GetType(Integer)}
        '</Snippet3>

        ' Create a DynamicMethod. In this example the method is
        ' named SquareIt. It is not necessary to give dynamic 
        ' methods names. They cannot be invoked by name, and two
        ' dynamic methods can have the same name. However, the 
        ' name appears in calls stacks and can be useful for
        ' debugging. 
        '
        ' In this example the return type of the dynamic method
        ' is Long. The method is associated with the module that 
        ' contains the Example class. Any loaded module could be
        ' specified. The dynamic method is like a module-level
        ' Shared method.
        '
        '<Snippet4>
        Dim squareIt As New DynamicMethod( _
            "SquareIt", _
            GetType(Long), _
            methodArgs, _
            GetType(Example).Module)
        '</Snippet4>

        ' Emit the method body. In this example ILGenerator is used
        ' to emit the MSIL. DynamicMethod has an associated type
        ' DynamicILInfo that can be used in conjunction with 
        ' unmanaged code generators.
        '
        ' The MSIL loads the argument, which is an Integer, onto the 
        ' stack, converts the Integer to a Long, duplicates the top
        ' item on the stack, and multiplies the top two items on the
        ' stack. This leaves the squared number on the stack, and 
        ' all the method has to do is return.
        '
        '<Snippet5>
        Dim il As ILGenerator = squareIt.GetILGenerator()
        il.Emit(OpCodes.Ldarg_0)
        il.Emit(OpCodes.Conv_I8)
        il.Emit(OpCodes.Dup)
        il.Emit(OpCodes.Mul)
        il.Emit(OpCodes.Ret)
        '</Snippet5>

        ' Create a delegate that represents the dynamic method. 
        ' Creating the delegate completes the method, and any further 
        ' attempts to change the method (for example, by adding more
        ' MSIL) are ignored. The following code uses a generic 
        ' delegate that can produce delegate types matching any
        ' single-parameter method that has a return type.
        '
        '<Snippet6>
        Dim invokeSquareIt As OneParameter(Of Long, Integer) = _
            CType( _
                squareIt.CreateDelegate( _
                    GetType(OneParameter(Of Long, Integer))), _
                OneParameter(Of Long, Integer) _
            )

        Console.WriteLine("123456789 squared = {0}", _
            invokeSquareIt(123456789))
        '</Snippet6>


        ' Example 2: A dynamic method bound to an instance.
        '
        ' Create an array that specifies the parameter types for a
        ' dynamic method. If the delegate representing the method
        ' is to be bound to an object, the first parameter must 
        ' match the type the delegate is bound to. In the following
        ' code the bound instance is of the Example class. 
        '
        '<Snippet13>
        Dim methodArgs2 As Type() = _
            {GetType(Example), GetType(Integer)}
        '</Snippet13>

        ' Create a DynamicMethod. In this example the method has no
        ' name. The return type of the method is Integer. The method 
        ' has access to the protected and private members of the 
        ' Example class. 
        '
        '<Snippet14>
        Dim multiplyPrivate As New DynamicMethod( _
            "", _
            GetType(Integer), _
            methodArgs2, _
            GetType(Example))
        '</Snippet14>

        ' Emit the method body. In this example ILGenerator is used
        ' to emit the MSIL. DynamicMethod has an associated type
        ' DynamicILInfo that can be used in conjunction with 
        ' unmanaged code generators.
        '
        ' The MSIL loads the first argument, which is an instance of
        ' the Example class, and uses it to load the value of a 
        ' private instance field of type Integer. The second argument 
        ' is loaded, and the two numbers are multiplied. If the result
        ' is larger than Integer, the value is truncated and the most 
        ' significant bits are discarded. The method returns, with
        ' the return value on the stack.
        '
        '<Snippet15>
        Dim ilMP As ILGenerator = multiplyPrivate.GetILGenerator()
        ilMP.Emit(OpCodes.Ldarg_0)

        Dim testInfo As FieldInfo = _
            GetType(Example).GetField("test", _
                BindingFlags.NonPublic Or BindingFlags.Instance)

        ilMP.Emit(OpCodes.Ldfld, testInfo)
        ilMP.Emit(OpCodes.Ldarg_1)
        ilMP.Emit(OpCodes.Mul)
        ilMP.Emit(OpCodes.Ret)
        '</Snippet15>

        ' Create a delegate that represents the dynamic method. 
        ' Creating the delegate completes the method, and any further 
        ' attempts to change the method  for example, by adding more
        ' MSIL  are ignored. 
        ' 
        ' The following code binds the method to a new instance
        ' of the Example class whose private test field is set to 42.
        ' That is, each time the delegate is invoked the instance of
        ' Example is passed to the first parameter of the method.
        '
        ' The delegate OneParameter is used, because the first
        ' parameter of the method receives the instance of Example.
        ' When the delegate is invoked, only the second parameter is
        ' required. 
        '
        '<Snippet16>
        Dim invoke As OneParameter(Of Integer, Integer) = _
            CType( _
                multiplyPrivate.CreateDelegate( _
                    GetType(OneParameter(Of Integer, Integer)), _
                    new Example(42) _
                ), _
                OneParameter(Of Integer, Integer) _
            )

        Console.WriteLine("3 * test = {0}", invoke(3))
        '</Snippet16>

    End Sub

End Class

' This code example produces the following output:
'
'123456789 squared = 15241578750190521
'3 * test = 126
' 
'</Snippet1>
