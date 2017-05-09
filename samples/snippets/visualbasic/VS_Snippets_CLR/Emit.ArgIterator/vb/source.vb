' Created 4-5-2006 by GlennHa from sample code by HaiboLuo...Thx, Haibo!
'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Class Example
    
    Shared Sub Main() 

        Dim name As String = "InMemory"
        
        Dim asmBldr As AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly( _
            New AssemblyName(name), AssemblyBuilderAccess.Run)
        Dim modBldr As ModuleBuilder = asmBldr.DefineDynamicModule(name)
        
        Dim tb As TypeBuilder = modBldr.DefineType("DemoVararg")
        
        ' Create a vararg method with no return value and one 
        ' string argument. (The string argument type is the only
        ' element of an array of Type objects.)
        '
        Dim mb1 As MethodBuilder = tb.DefineMethod("VarargMethod", _
            MethodAttributes.Public Or MethodAttributes.Static, _
            CallingConventions.VarArgs, _
            Nothing, _
            New Type() {GetType(String)})
        
        Dim il1 As ILGenerator = mb1.GetILGenerator()
        
        Dim locAi As LocalBuilder = il1.DeclareLocal(GetType(ArgIterator))
        Dim locNext As LocalBuilder = il1.DeclareLocal(GetType(Boolean))
        
        Dim labelCheckCondition As Label = il1.DefineLabel()
        Dim labelNext As Label = il1.DefineLabel()
        
        ' Load the fixed argument and print it.
        il1.Emit(OpCodes.Ldarg_0)
        il1.Emit(OpCodes.Call, GetType(Console).GetMethod("Write", _
            New Type() {GetType(String)}))
        
        ' Load the address of the local variable represented by
        ' locAi, which will hold the ArgIterator.
        il1.Emit(OpCodes.Ldloca_S, locAi)
        
        ' Load the address of the argument list, and call the 
        ' ArgIterator constructor that takes an array of runtime
        ' argument handles. 
        il1.Emit(OpCodes.Arglist)
        il1.Emit(OpCodes.Call, GetType(ArgIterator).GetConstructor( _
            New Type() {GetType(RuntimeArgumentHandle)}))
        
        ' Enter the loop at the point where the remaining argument
        ' count is tested.
        il1.Emit(OpCodes.Br_S, labelCheckCondition)
        
        ' At the top of the loop, call GetNextArg to get the next 
        ' argument from the ArgIterator. Convert the typed reference
        ' to an object reference and write the object to the console.
        il1.MarkLabel(labelNext)
        il1.Emit(OpCodes.Ldloca_S, locAi)
        il1.Emit(OpCodes.Call, _
            GetType(ArgIterator).GetMethod("GetNextArg", Type.EmptyTypes))
        il1.Emit(OpCodes.Call, GetType(TypedReference).GetMethod("ToObject"))
        il1.Emit(OpCodes.Call, _
            GetType(Console).GetMethod("Write", New Type() {GetType(Object)}))
        
        il1.MarkLabel(labelCheckCondition)
        il1.Emit(OpCodes.Ldloca_S, locAi)
        il1.Emit(OpCodes.Call, _
            GetType(ArgIterator).GetMethod("GetRemainingCount"))
        
        ' If the remaining count is greater than zero, go to
        ' the top of the loop.
        il1.Emit(OpCodes.Ldc_I4_0)
        il1.Emit(OpCodes.Cgt)
        il1.Emit(OpCodes.Stloc_1)
        il1.Emit(OpCodes.Ldloc_1)
        il1.Emit(OpCodes.Brtrue_S, labelNext)
        
        il1.Emit(OpCodes.Ret)
        
        ' Create a method that contains a call to the vararg 
        ' method.
        Dim mb2 As MethodBuilder = tb.DefineMethod("CallVarargMethod", _
            MethodAttributes.Public Or MethodAttributes.Static, _
            CallingConventions.Standard, _
            Nothing, _
            Type.EmptyTypes)

        Dim il2 As ILGenerator = mb2.GetILGenerator()
        
        ' Push arguments on the stack: one for the fixed string
        ' parameter, and two for the list.
        il2.Emit(OpCodes.Ldstr, "Hello ")
        il2.Emit(OpCodes.Ldstr, "world ")
        il2.Emit(OpCodes.Ldc_I4, 2006)
        
        ' Call the vararg method, specifying the types of the 
        ' arguments in the list.
        il2.EmitCall(OpCodes.Call, mb1, _
            New Type() {GetType(String), GetType(Integer)})
        
        il2.Emit(OpCodes.Ret)
        
        Dim myType As Type = tb.CreateType()
        myType.GetMethod("CallVarargMethod").Invoke(Nothing, Nothing)
    
    End Sub 
End Class 

' This code example produces the following output:
'
'Hello world 2006
' 
'</Snippet1>
