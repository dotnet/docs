'<Snippet1>
Imports System.Reflection.Emit
Imports System.Reflection
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Policy
Imports System.Collections
Imports System.Diagnostics

' This code example works properly only if it is run from a fully 
' trusted location, such as your local computer.

' Delegates used to execute the dynamic methods.
'
Public Delegate Sub Test(ByVal w As Worker) 
Public Delegate Sub Test1() 
Public Delegate Function Test2(ByVal instance As String) As Char 

' The Worker class must inherit MarshalByRefObject so that its public 
' methods can be invoked across application domain boundaries.
'
'<Snippet10>
Public Class Worker
    Inherits MarshalByRefObject
'</Snippet10>
    
    Private Sub PrivateMethod() 
        Console.WriteLine("Worker.PrivateMethod()")
    End Sub 

    '<Snippet11>
    Public Sub SimpleEmitDemo()
    
        '<Snippet15>
        Dim meth As DynamicMethod = new DynamicMethod("", Nothing, Nothing)
        Dim il As ILGenerator = meth.GetILGenerator()
        il.EmitWriteLine("Hello, World!")
        il.Emit(OpCodes.Ret)
        '</Snippet15>

        Dim t1 As Test1 = CType(meth.CreateDelegate(GetType(Test1)), Test1)
        t1()
    End Sub
    '</Snippet11>
    
    ' This overload of AccessPrivateMethod emits a dynamic method and
    ' specifies whether to skip JIT visiblity checks. It creates a 
    ' delegate for the method and invokes the delegate. The dynamic 
    ' method calls a private method of the Worker class.
    Overloads Public Sub AccessPrivateMethod( _
                       ByVal restrictedSkipVisibility As Boolean) 

        ' Create an unnamed dynamic method that has no return type,
        ' takes one parameter of type Worker, and optionally skips JIT
        ' visiblity checks.
        Dim meth As New DynamicMethod("", _
                                      Nothing, _
                                      New Type() { GetType(Worker) }, _
                                      restrictedSkipVisibility)
        
        ' Get a MethodInfo for the private method.
        Dim pvtMeth As MethodInfo = GetType(Worker).GetMethod( _
            "PrivateMethod", _
            BindingFlags.NonPublic Or BindingFlags.Instance)
        
        ' Get an ILGenerator and emit a body for the dynamic method.
        Dim il As ILGenerator = meth.GetILGenerator()
        
        ' Load the first argument, which is the target instance, onto the
        ' execution stack, call the private method, and return.
        il.Emit(OpCodes.Ldarg_0)
        il.EmitCall(OpCodes.Call, pvtMeth, Nothing)
        il.Emit(OpCodes.Ret)
        
        ' Create a delegate that represents the dynamic method, and 
        ' invoke it. 
        Try
            Dim t As Test = CType(meth.CreateDelegate(GetType(Test)), Test)
            Try
                t(Me)
            Catch ex As Exception
                Console.WriteLine("{0} was thrown when the delegate was invoked.", _
                    ex.GetType().Name)
            End Try
        Catch ex As Exception
            Console.WriteLine("{0} was thrown when the delegate was compiled.", _
                ex.GetType().Name)
        End Try
    
    End Sub 
    
    
    ' This overload of AccessPrivateMethod emits a dynamic method that takes
    ' a string and returns the first character, using a private field of the 
    ' String class. The dynamic method skips JIT visiblity checks.
    Overloads Public Sub AccessPrivateMethod() 

        '<Snippet16>
        Dim meth As New DynamicMethod("", _
                                      GetType(Char), _
                                      New Type() {GetType(String)}, _
                                      True)
        '</Snippet16>
        
        ' Get a MethodInfo for the 'get' accessor of the private property.
        Dim pi As PropertyInfo = GetType(String).GetProperty( _
            "FirstChar", _
            BindingFlags.NonPublic Or BindingFlags.Instance) 
        Dim pvtMeth As MethodInfo = pi.GetGetMethod(True)
        
        ' Get an ILGenerator and emit a body for the dynamic method.
        Dim il As ILGenerator = meth.GetILGenerator()
        
        ' Load the first argument, which is the target string, onto the
        ' execution stack, call the 'get' accessor to put the result onto 
        ' the execution stack, and return.
        il.Emit(OpCodes.Ldarg_0)
        il.EmitCall(OpCodes.Call, pvtMeth, Nothing)
        il.Emit(OpCodes.Ret)
        
        ' Create a delegate that represents the dynamic method, and 
        ' invoke it. 
        Try
            Dim t As Test2 = CType(meth.CreateDelegate(GetType(Test2)), Test2)
            Dim first As Char = t("Hello, World!")
            Console.WriteLine("{0} is the first character.", first)
        Catch ex As Exception
            Console.WriteLine("{0} was thrown when the delegate was compiled.", _
                ex.GetType().Name)
        End Try
    
    End Sub 
End Class

Friend Class Example

    ' The entry point for the code example.
    Shared Sub Main() 

        ' Get the display name of the executing assembly, to use when
        ' creating objects to run code in application domains.
        '<Snippet14>
        Dim asmName As String = GetType(Worker).Assembly.FullName
        '</Snippet14>
        
        ' Create the permission set to grant to other assemblies. In this
        ' case they are the permissions found in the Internet zone.
        '<Snippet2>
        Dim ev As New Evidence()
        ev.AddHostEvidence(new Zone(SecurityZone.Internet))
        Dim pset As New NamedPermissionSet("Internet", SecurityManager.GetStandardSandbox(ev))
        '</Snippet2>

        ' For simplicity, set up the application domain to use the 
        ' current path as the application folder, so the same executable
        ' can be used in both trusted and untrusted scenarios. Normally
        ' you would not do this with real untrusted code.
        '<Snippet3>
        Dim adSetup As New AppDomainSetup()
        adSetup.ApplicationBase = "."
        '</Snippet3>

        ' Create an application domain in which all code that executes is 
        ' granted the permissions of an application run from the Internet.
        '<Snippet5>
        Dim ad As AppDomain = AppDomain.CreateDomain("Sandbox", ev, adSetup, pset, Nothing)
        '</Snippet5>
        
        ' Create an instance of the Worker class in the partially trusted 
        ' domain. Note: If you build this code example in Visual Studio, 
        ' you must change the name of the class to include the default 
        ' namespace, which is the project name. For example, if the project
        ' is "AnonymouslyHosted", the class is "AnonymouslyHosted.Worker".
        '<Snippet12>
        Dim w As Worker = _
            CType(ad.CreateInstanceAndUnwrap(asmName, "Worker"), Worker)
        '</Snippet12>

        ' Emit a simple dynamic method that prints "Hello, World!"
        '<Snippet13>
        w.SimpleEmitDemo()
        '</Snippet13>
        
        ' Emit and invoke a dynamic method that calls a private method
        ' of Worker, with JIT visibility checks enforced. The call fails 
        ' when the delegate is invoked.
        w.AccessPrivateMethod(False)
        
        ' Emit and invoke a dynamic method that calls a private method
        ' of Worker, skipping JIT visibility checks. The call fails when
        ' the method is compiled.
        w.AccessPrivateMethod(True)
        
        
        ' Unload the application domain. Add RestrictedMemberAccess to the
        ' grant set, and use it to create an application domain in which
        ' partially trusted code can call private members, as long as the 
        ' trust level of those members is equal to or lower than the trust 
        ' level of the partially trusted code. 
        AppDomain.Unload(ad)
        '<Snippet7>
        pset.SetPermission( _
            New ReflectionPermission( _
                ReflectionPermissionFlag.RestrictedMemberAccess))
        '</Snippet7>
        '<Snippet8>
        ad = AppDomain.CreateDomain("Sandbox2", ev, adSetup, pset, Nothing)
        '</Snippet8>
        
        ' Create an instance of the Worker class in the partially trusted 
        ' domain. 
        w = CType(ad.CreateInstanceAndUnwrap(asmName, "Worker"), Worker)
        
        ' Again, emit and invoke a dynamic method that calls a private method
        ' of Worker, skipping JIT visibility checks. This time compilation 
        ' succeeds because of the grant for RestrictedMemberAccess.
        w.AccessPrivateMethod(True)
        
        ' Finally, emit and invoke a dynamic method that calls an internal 
        ' method of the String class. The call fails, because the trust level
        ' of the assembly that contains String is higher than the trust level
        ' of the assembly that emits the dynamic method.
        w.AccessPrivateMethod()
    
    End Sub 
End Class 

' This code example produces the following output:
'
'Hello, World!
'MethodAccessException was thrown when the delegate was invoked.
'MethodAccessException was thrown when the delegate was invoked.
'Worker.PrivateMethod()
'MethodAccessException was thrown when the delegate was compiled.
' 
'</Snippet1>