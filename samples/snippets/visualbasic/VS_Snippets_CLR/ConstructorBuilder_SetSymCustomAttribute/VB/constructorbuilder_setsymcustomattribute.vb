' System.Reflection.Emit.ConstructorBuilder.SetSymCustomAttribute()

' The following program demonstrates the 'SetSymCustomAttribute' method
' of ConstructorBuilder class. It creates an assembly in the current 
' domain with dynamic module in the assembly. Constructor builder is
' used in conjunction with the 'TypeBuilder' class to create constructor
' at run time. It then sets this constructor's custom attribute associated
' with symbolic information.


Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Friend Class MyConstructorBuilder
   Private myType1 As Type
   Private myModuleBuilder As ModuleBuilder = Nothing
   Private myAssemblyBuilder As AssemblyBuilder = Nothing
   
   Friend Sub New()
' <Snippet1>
      Dim myMethodBuilder As MethodBuilder = Nothing
      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      ' Create assembly in current CurrentDomain.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Create a dynamic assembly.
      myAssemblyBuilder = myCurrentDomain.DefineDynamicAssembly(myAssemblyName, _
                 AssemblyBuilderAccess.Run)
      ' Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule", True)
      Dim myFieldInfo As FieldInfo = myModuleBuilder.DefineUninitializedData("myField", 2, _
                 FieldAttributes.Public)
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = myTypeBuilder.DefineField("Greeting", GetType(String), _
                 FieldAttributes.Public)
      Dim myConstructorArgs() As Type = { GetType(String) }
      ' Define a constructor of the dynamic class.
      Dim myConstructor As ConstructorBuilder = _
                myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _
                 myConstructorArgs)
      ' Display the name of the constructor.
      Console.WriteLine("The constructor name is  : " + myConstructor.Name)
      myConstructor.SetSymCustomAttribute("MySimAttribute", New Byte() {01, 00,00})
' </Snippet1>
      ' Generate the IL for the method and call its superclass constructor.
      Dim myILGenerator3 As ILGenerator = myConstructor.GetILGenerator()
      myILGenerator3.Emit(OpCodes.Ldarg_0)
      Dim myConstructorInfo As ConstructorInfo = GetType(Object).GetConstructor(New Type() {})
      myILGenerator3.Emit(OpCodes.Call, myConstructorInfo)
      myILGenerator3.Emit(OpCodes.Ldarg_0)
      myILGenerator3.Emit(OpCodes.Ldarg_1)
      myILGenerator3.Emit(OpCodes.Stfld, myGreetingField)
      myILGenerator3.Emit(OpCodes.Ret)
      ' Add a method to the type.
      myMethodBuilder = myTypeBuilder.DefineMethod("HelloWorld", MethodAttributes.Public, _
                 Nothing, Nothing)
      ' Generate IL for the method.
      Dim myILGenerator2 As ILGenerator = myMethodBuilder.GetILGenerator()
      myILGenerator2.EmitWriteLine("Hello World from global")
      myILGenerator2.Emit(OpCodes.Ret)
      myModuleBuilder.CreateGlobalFunctions()
      myType1 = myTypeBuilder.CreateType()
   End Sub 'New
   
   Friend ReadOnly Property MyTypeProperty() As Type
      Get
         Return Me.myType1
      End Get
   End Property
   
   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myConstructorBuilder As New MyConstructorBuilder()
      Dim myType1 As Type = myConstructorBuilder.MyTypeProperty
      If Not Nothing Is myType1 Then
         Console.WriteLine("Instantiating the new type...")
         Dim myObject()  As Object = { "hello"}
         Dim myObject1 As Object = Activator.CreateInstance(myType1, myObject, Nothing)
         Dim myMethodInfo As MethodInfo = myType1.GetMethod("HelloWorld")
         If Not Nothing  Is  myMethodInfo Then
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