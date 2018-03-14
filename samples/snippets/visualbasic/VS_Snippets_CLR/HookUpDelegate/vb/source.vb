' REDMOND\glennha
'<Snippet1>
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Windows.Forms

'<Snippet2>
Class ExampleForm
    Inherits Form
    
    Public Sub New() 
        Me.Text = "Click me"
    
    End Sub 'New
End Class 'ExampleForm
'</Snippet2>

Class Example
    Public Shared Sub Main() 
        Dim ex As New Example()
        ex.HookUpDelegate()
    End Sub 'Main
        
    Private Sub HookUpDelegate() 
        ' Load an assembly, for example using the Assembly.Load
        ' method. In this case, the executing assembly is loaded, to
        ' keep the demonstration simple.
        '
        '<Snippet3>
        Dim assem As Assembly = GetType(Example).Assembly
        '</Snippet3>

        ' Get the type that is to be loaded, and create an instance 
        ' of it. Activator.CreateInstance also has an overload that
        ' takes an array of types representing the types of the 
        ' constructor parameters, if the type you are creating does
        ' not have a parameterless constructor. The new instance
        ' is stored as type Object, to maintain the fiction that 
        ' nothing is known about the assembly. (Note that you can
        ' get the types in an assembly without knowing their names
        ' in advance.)
        '
        '<Snippet4>
        Dim tExForm As Type = assem.GetType("ExampleForm")
        Dim exFormAsObj As Object = _
            Activator.CreateInstance(tExForm)
        '</Snippet4>

        ' Get an EventInfo representing the Click event, and get the
        ' type of delegate that handles the event.
        '
        '<Snippet5>
        Dim evClick As EventInfo = tExForm.GetEvent("Click")
        Dim tDelegate As Type = evClick.EventHandlerType
        '</Snippet5>

        ' If you already have a method with the correct signature,
        ' you can simply get a MethodInfo for it. 
        '
        '<Snippet6>
        Dim miHandler As MethodInfo = _
            GetType(Example).GetMethod("LuckyHandler", _
                BindingFlags.NonPublic Or BindingFlags.Instance)
        '</Snippet6>
        ' Create an instance of the delegate. Using the overloads
        ' of CreateDelegate that take MethodInfo is recommended.
        '
        '<Snippet7>
        Dim d As [Delegate] = _
            [Delegate].CreateDelegate(tDelegate, Me, miHandler)
        '</Snippet7>

        ' Get the "add" accessor of the event and invoke it late-
        ' bound, passing in the delegate instance. This is equivalent
        ' to using the += operator in C#, or AddHandler in Visual
        ' Basic. The instance on which the "add" accessor is invoked
        ' is the form; the arguments must be passed as an array.
        '
        '<Snippet8>
        Dim miAddHandler As MethodInfo = evClick.GetAddMethod()
        Dim addHandlerArgs() As Object = { d }
        miAddHandler.Invoke(exFormAsObj, addHandlerArgs)
        '</Snippet8>

        ' Event handler methods can also be generated at run time,
        ' using lightweight dynamic methods and Reflection.Emit. 
        ' To construct an event handler, you need the return type
        ' and parameter types of the delegate. These can be obtained
        ' by examining the delegate's Invoke method. 
        '
        ' It is not necessary to name dynamic methods, so the empty 
        ' string can be used. The last argument associates the 
        ' dynamic method with the current type, giving the delegate
        ' access to all the public and private members of Example,
        ' as if it were an instance method.
        '
        '<Snippet9>
        Dim returnType As Type = GetDelegateReturnType(tDelegate)
        If returnType IsNot GetType(Void) Then
            Throw New ApplicationException("Delegate has a return type.")
        End If

        Dim handler As New DynamicMethod( _
            "", _
            Nothing, _
            GetDelegateParameterTypes(tDelegate), _
            GetType(Example) _
        )
        '</Snippet9>

        ' Generate a method body. This method loads a string, calls 
        ' the Show method overload that takes a string, pops the 
        ' return value off the stack (because the handler has no
        ' return type), and returns.
        '
        '<Snippet10>
        Dim ilgen As ILGenerator = handler.GetILGenerator()
        
        Dim showParameters As Type() = { GetType(String) }
        Dim simpleShow As MethodInfo = _
            GetType(MessageBox).GetMethod("Show", showParameters)
        
        ilgen.Emit(OpCodes.Ldstr, _
            "This event handler was constructed at run time.")
        ilgen.Emit(OpCodes.Call, simpleShow)
        ilgen.Emit(OpCodes.Pop)
        ilgen.Emit(OpCodes.Ret)
        '</Snippet10>

        ' Complete the dynamic method by calling its CreateDelegate
        ' method. Use the "add" accessor to add the delegate to
        ' the invocation list for the event.
        '
        '<Snippet11>
        Dim dEmitted As [Delegate] = handler.CreateDelegate(tDelegate)
        miAddHandler.Invoke(exFormAsObj, New Object() { dEmitted })
        '</Snippet11>

        ' Show the form. Clicking on the form causes the two
        ' delegates to be invoked.
        '
        '<Snippet12>
        Application.Run(CType(exFormAsObj, Form))
        '</Snippet12>
    
    End Sub
    
    Private Sub LuckyHandler(ByVal sender As [Object], _
        ByVal e As EventArgs) 

        MessageBox.Show("This event handler just happened to be lying around.")
    End Sub
    
    Private Function GetDelegateParameterTypes(ByVal d As Type) _
        As Type() 

        If d.BaseType IsNot GetType(MulticastDelegate) Then
            Throw New ApplicationException("Not a delegate.")
        End If

        Dim invoke As MethodInfo = d.GetMethod("Invoke")
        If invoke Is Nothing Then
            Throw New ApplicationException("Not a delegate.")
        End If

        Dim parameters As ParameterInfo() = invoke.GetParameters()
        ' Dimension this array Length - 1, because VB adds an extra
        ' element to zero-based arrays.
        Dim typeParameters(parameters.Length - 1) As Type
        For i As Integer = 0 To parameters.Length - 1
            typeParameters(i) = parameters(i).ParameterType
        Next i

        Return typeParameters
    
    End Function 
    
    
    Private Function GetDelegateReturnType(ByVal d As Type) As Type 

        If d.BaseType IsNot GetType(MulticastDelegate) Then
            Throw New ApplicationException("Not a delegate.")
        End If

        Dim invoke As MethodInfo = d.GetMethod("Invoke")
        If invoke Is Nothing Then
            Throw New ApplicationException("Not a delegate.")
        End If

        Return invoke.ReturnType
    
    End Function 
End Class 
'</Snippet1>