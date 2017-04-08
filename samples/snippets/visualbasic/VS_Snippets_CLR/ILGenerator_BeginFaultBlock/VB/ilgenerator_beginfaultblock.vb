' System.Reflection.Emit.ILGenerator.BeginFaultBlock()

' The following program demonstrates the 'BeginFaultBlock()' method of 'ILGenerator'
' class. Exception is raised by passing two integer values which are out of range,
' the same is caught in the 'BeginExceptionBlock' which is non-filtered. First it
' checks for the exception thrown in the 'BeginFaultBlock' and then emits the MSIL
' instructions in 'BeginExceptFilterBlock'. 

' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Public Class ILGenerator_BeginFaultBlock
   Public Shared Function AddType() As Type
      ' Create an assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "AdderExceptionAsm"
      
      ' Create dynamic assembly.
      Dim myAppDomain As AppDomain = Thread.GetDomain()
      Dim myAssemblyBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly _ 
                                              (myAssemblyName, AssemblyBuilderAccess.Run)
      
      ' Create a dynamic module.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule _ 
                                                ("AdderExceptionMod")
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("Adder")
      Dim myAdderParams() As Type = {GetType(Integer), GetType(Integer)}
      
      ' Method to add two numbers.
      Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod _ 
               ("DoAdd", MethodAttributes.Public Or MethodAttributes.Static, GetType(Integer), _
                                                  myAdderParams)
      Dim myAdderIL As ILGenerator = myMethodBuilder.GetILGenerator()
      
      ' Create constructor.
      Dim myConstructorInfo As ConstructorInfo = GetType(OverflowException).GetConstructor _ 
                                                   (New Type() {GetType(String)})
      Dim myExToStrMI As MethodInfo = GetType(OverflowException).GetMethod("ToString")
      Dim myWriteLineMI As MethodInfo = GetType(Console).GetMethod _ 
                                  ("WriteLine", New Type() {GetType(String), GetType(Object)})
      
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
      myAdderIL.Emit(OpCodes.Ldstr, "Cannot accept values over 10 for addition.")
      myAdderIL.Emit(OpCodes.Newobj, myConstructorInfo)
      
      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder2)
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder2)
      
      ' Call fault block.
      myAdderIL.BeginFaultBlock()
      Console.WriteLine("Fault block called.")
      'Throw exception.
      myAdderIL.ThrowException(GetType(NotSupportedException))
      
      ' Call finally block.
      myAdderIL.BeginFinallyBlock()
      
      myAdderIL.Emit(OpCodes.Ldstr, "{0}")
      myAdderIL.Emit(OpCodes.Ldloc_S, myLocalBuilder2)
      myAdderIL.EmitCall(OpCodes.Callvirt, myExToStrMI, Nothing)
      myAdderIL.EmitCall(OpCodes.Call, myWriteLineMI, Nothing)
      myAdderIL.Emit(OpCodes.Ldc_I4_M1)
      myAdderIL.Emit(OpCodes.Stloc_S, myLocalBuilder1)
      
      ' End exception block.
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
      Dim myObject2() As Object = {11, 12}
      
      ' Invoke member.
      myAddType.InvokeMember("DoAdd", BindingFlags.InvokeMethod, Nothing, myObject1, myObject2)
   End Sub 'Main
End Class 'ILGenerator_BeginFaultBlock
' </Snippet1>