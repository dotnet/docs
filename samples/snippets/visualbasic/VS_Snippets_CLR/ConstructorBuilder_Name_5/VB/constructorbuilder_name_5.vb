' System.Reflection.Emit.ConstructorBuilder
' System.Reflection.Emit.ConstructorBuilder.Name
' System.Reflection.Emit.ConstructorBuilder.ReflectedType
' System.Reflection.Emit.ConstructorBuilder.Signature
' System.Reflection.Emit.ConstructorBuilder.ToString()

' The following program demonstrates the 'ConstructorBuilder' class,
'   its 'Name', 'ReflectedType', 'Signature' properties and 'ToString'
'   method. Create the assembly in the current domain with dynamic module 
'   in the assembly. ConstructorBuilder is used in conjunction with the 
'   'TypeBuilder' class to create constructor at run time. Display the
'   'Name', 'Signature' and 'ReflectedType' to the console.

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Public Class MyConstructorBuilder
   Private myType1 As Type
   Private myModuleBuilder As ModuleBuilder = Nothing
   Private myAssemblyBuilder As AssemblyBuilder = Nothing
   
   Public Sub New()
' <Snippet2>
      Dim myMethodBuilder As MethodBuilder = Nothing
      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      ' Create assembly in current CurrentDomain.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Create a dynamic assembly.
      myAssemblyBuilder = _ 
            myCurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)
      ' Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      Dim myFieldInfo As FieldInfo = _ 
          myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public)
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = _ 
          myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = _ 
          myTypeBuilder.DefineField("Greeting", GetType(String), FieldAttributes.Public)
      Dim myConstructorArgs As Type() = {GetType(String)}
      ' Define a constructor of the dynamic class.
      Dim myConstructor As ConstructorBuilder = _ 
          myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _ 
                                          myConstructorArgs)
      ' Display the name of the constructor.
      Console.WriteLine("The constructor name is  : " + myConstructor.Name)
      ' Display the 'Type' object from which this object was obtained.
      Console.WriteLine("The reflected type  is  : " + myConstructor.ReflectedType.ToString())
      ' Display the signature of the field.
      Console.WriteLine(myConstructor.Signature)
      ' Display the constructor builder instance as a string.
      Console.WriteLine(myConstructor.ToString())
' </Snippet2>
      ' Generate IL for the method, call its superclass constructor and store the arguments
      ' in the private field.
      Dim myILGenerator3 As ILGenerator = myConstructor.GetILGenerator()
      myILGenerator3.Emit(OpCodes.Ldarg_0)
      Dim myConstructorInfo As ConstructorInfo = GetType(Object).GetConstructor(New Type() {})
      myILGenerator3.Emit(OpCodes.Call, myConstructorInfo)
      myILGenerator3.Emit(OpCodes.Ldarg_0)
      myILGenerator3.Emit(OpCodes.Ldarg_1)
      myILGenerator3.Emit(OpCodes.Stfld, myGreetingField)
      myILGenerator3.Emit(OpCodes.Ret)
      ' Add a method to the type.
      myMethodBuilder = _ 
             myTypeBuilder.DefineMethod("HelloWorld", MethodAttributes.Public, Nothing, Nothing)
      ' Generate IL for the method.
      Dim myILGenerator2 As ILGenerator = myMethodBuilder.GetILGenerator()
      myILGenerator2.EmitWriteLine("Hello World from global")
      myILGenerator2.Emit(OpCodes.Ret)
      myModuleBuilder.CreateGlobalFunctions()
      myType1 = myTypeBuilder.CreateType()
   End Sub 'New
   
   Public ReadOnly Property MyTypeProperty() As Type
      Get
         Return Me.myType1
      End Get
   End Property
   
   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myConstructorBuilder As New MyConstructorBuilder()
      Dim myType1 As Type = myConstructorBuilder.MyTypeProperty
      If  Not Nothing is myType1 Then
         Console.WriteLine("Instantiating the new type...")
         Dim myObject As Object() = {"hello"}
         Dim myObject1 As Object = Activator.CreateInstance(myType1, myObject, Nothing)
         Dim myMethodInfo As MethodInfo = myType1.GetMethod("HelloWorld")
         If Not Nothing Is myMethodInfo Then
            Console.WriteLine("Invoking dynamically created HelloWorld method...")
            myMethodInfo.Invoke(myObject1, Nothing)
          Else
            Console.WriteLine("Could not locate HelloWorld method")
         End If
       Else
         Console.WriteLine("Could not access Type.")
      End If
   End Sub 'Main
End Class 'MyConstructorBuilder
' </Snippet1>