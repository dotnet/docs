' System.Reflection.Emit.ILGenerator.BeginExceptFilterBlock()
' System.Reflection.Emit.ILGenerator.BeginFinallyBlock()

' The following program demonstrates the 'BeginExceptFilterBlock()' method and
' 'BeginFinallyBlock()' of 'ILGenerator' class. Exception is raised by passing
' two integer values which are out of range, the same is caught in the
' 'BeginExceptionBlock' which is non-filtered and then emits the MSIL
' instructions in 'BeginExceptFilterBlock' and 'BeginFinallyBlock'.

' <Snippet1>
' <Snippet2>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Public Class ILGenerator_BeginFinallyBlock
   Public Shared Function AddType() As Type
      ' Create an assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "AdderExceptionAsm"

      ' Create dynamic assembly.
      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAssemblyBuilder As AssemblyBuilder = _
            myAppDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)

      ' Create a dynamic module.
      Dim myModuleBuilder As ModuleBuilder = _
            myAssemblyBuilder.DefineDynamicModule("AdderExceptionMod")
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("Adder")
      Dim adderParams() As Type = {GetType(Integer), GetType(Integer)}

      ' Define method to add two numbers.
      Dim myMethodBuilder As MethodBuilder = _
            myTypeBuilder.DefineMethod("DoAdd", MethodAttributes.Public Or _
            MethodAttributes.Static, GetType(Integer), adderParams)
      Dim myAdderIL As ILGenerator = myMethodBuilder.GetILGenerator()

      ' Create constructor.
      Dim myConstructorInfo As ConstructorInfo = _
            GetType(OverflowException).GetConstructor(New Type() {GetType(String)})
      Dim myExToStrMI As MethodInfo = GetType(OverflowException).GetMethod("ToString")
      Dim myWriteLineMI As MethodInfo = _
            GetType(Console).GetMethod("WriteLine", New Type() {GetType(String), GetType(Object)})

      ' Declare local variable.
      Dim myLocalBuilder1 As LocalBuilder = myAdderIL.DeclareLocal(GetType(Integer))
      Dim myLocalBuilder2 As LocalBuilder = myAdderIL.DeclareLocal(GetType(OverflowException))

      ' Define label.
      Dim myFailedLabel As Label = myAdderIL.DefineLabel()
      Dim myEndOfMethodLabel As Label = myAdderIL.DefineLabel()

      ' Begin exception block.
      Dim myLabel As Label = myAdderIL.BeginExceptionBlock()

      myAdderIL.Emit(OpCodes.Ldarg_0)
      myAdderIL.Emit(OpCodes.Ldc_I4_S, 10)
      myAdderIL.Emit(OpCodes.Bgt_S, myFailedLabel)

      myAdderIL.Emit(OpCodes.Ldarg_1)
      myAdderIL.Emit(OpCodes.Ldc_I4_S, 10)
      myAdderIL.Emit(OpCodes.Bgt_S, myFailedLabel)

      myAdderIL.Emit(OpCodes.Ldarg_0)
      myAdderIL.Emit(OpCodes.Ldarg_1)
      myAdderIL.Emit(OpCodes.Add_Ovf_Un)
      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder1)
      myAdderIL.Emit(OpCodes.Br_S, myEndOfMethodLabel)

      myAdderIL.MarkLabel(myFailedLabel)
      myAdderIL.Emit(OpCodes.Ldstr, "Cannot accept values over 10 for add.")
      myAdderIL.Emit(OpCodes.Newobj, myConstructorInfo)

      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder2)
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder2)

      ' Throw the exception.
      myAdderIL.ThrowException(GetType(OverflowException))

      ' Call 'BeginExceptFilterBlock'.
      myAdderIL.BeginExceptFilterBlock()
      myAdderIL.EmitWriteLine("Except filter block called.")

      ' Call catch block.
      myAdderIL.BeginCatchBlock(Nothing)

      ' Call other catch block.
      myAdderIL.BeginCatchBlock(GetType(OverflowException))

      myAdderIL.Emit(OpCodes.Ldstr, "{0}")
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder2)
      myAdderIL.EmitCall(OpCodes.Callvirt, myExToStrMI, Nothing)
      myAdderIL.EmitCall(OpCodes.Call, myWriteLineMI, Nothing)
      myAdderIL.Emit(OpCodes.Ldc_I4_M1)
      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder1)

      ' Call finally block.
      myAdderIL.BeginFinallyBlock()
      myAdderIL.EmitWriteLine("Finally block called.")

      ' End the exception block.
      myAdderIL.EndExceptionBlock()

      myAdderIL.MarkLabel(myEndOfMethodLabel)
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder1)
      myAdderIL.Emit(OpCodes.Ret)

      Return myTypeBuilder.CreateType()
   End Function 'AddType

   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myAddType As Type = AddType()
      Dim myObject1 As Object = Activator.CreateInstance(myAddType)
      Dim myObject2() As Object = {15, 15}
      myAddType.InvokeMember("DoAdd", BindingFlags.InvokeMethod, Nothing, myObject1, myObject2)
   End Sub 'Main
End Class 'ILGenerator_BeginFinallyBlock
' </Snippet2>
' </Snippet1>