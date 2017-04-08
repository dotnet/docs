' System.Reflection.Emit.ConstructorBuilder.GetModule()
' System.Reflection.Emit.ConstructorBuilder.GetToken()
' System.Reflection.Emit.ConstructorBuilder.GetMethodImplementationFlags()
' System.Reflection.Emit.ConstructorBuilder.GetParameters()

' The following program demonstrates the 'GetModule','GetToken',
' 'GetMethodImplementationFlags' and 'GetParameters'  
' methods of 'ConstructorBuilder' class.  Create the assembly 
' in the current domain with dynamic module in the assembly. Constructor 
' builder is used in conjunction with the 'TypeBuilder' class to create 
' constructor at run time. Set a custom attribute using a custom attribute 
' builder and displays module name, Token id and parameter info of this class.

Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security
Imports System.Security.Permissions

Friend Class MyConstructorBuilder
   Private myType1 As Type
   Private myModuleBuilder As ModuleBuilder = Nothing
   Private myAssemblyBuilder As AssemblyBuilder = Nothing
   
   Friend Sub New()
' <Snippet1>
' <Snippet3>
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
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = _ 
                   myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = _ 
               myTypeBuilder.DefineField("Greeting", GetType(String), FieldAttributes.Public)
       Dim myConstructorArgs As Type() = {GetType(String)}
' <Snippet2>
' <Snippet4>
      ' Define a constructor of the dynamic class.
      Dim myConstructorBuilder As ConstructorBuilder = _ 
          myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _ 
                                          myConstructorArgs)
      ' Get a reference to the module that contains this constructor.
      Dim myModule As [Module] = myConstructorBuilder.GetModule()
      Console.WriteLine("Module Name : " + myModule.Name)
      ' Get the 'MethodToken' that represents the token for this constructor.
      Dim myMethodToken As MethodToken = myConstructorBuilder.GetToken()
      Console.WriteLine("Constructor Token is : " + myMethodToken.Token.ToString())
      ' Get the method implementation flags for this constructor.
      Dim myMethodImplAttributes As MethodImplAttributes = _
          myConstructorBuilder.GetMethodImplementationFlags()
      Console.WriteLine("MethodImplAttributes : " + myMethodImplAttributes.ToString())
' </Snippet3>
' </Snippet2>
' </Snippet1>
      ' Generate IL for the method, call its base class constructor and store the arguments
      ' in the private field.
      Dim myILGenerator3 As ILGenerator = myConstructorBuilder.GetILGenerator()
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

      ' Get the parameters of this constructor.
      Dim myParameterInfo As ParameterInfo() = myConstructorBuilder.GetParameters()
      Dim i As Integer
      For i = 0 To myParameterInfo.Length - 1
         Console.WriteLine _ 
                 ("Declaration type : " + myParameterInfo(i).Member.DeclaringType.ToString())
      Next i
' </Snippet4>
   End Sub 'New 
   
   Friend ReadOnly Property MyTypeProperty() As Type
      Get
         Return Me.myType1
      End Get
   End Property
   
   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myConstructorBuilder1 As New MyConstructorBuilder()
      Dim myTypeProperty As Type = myConstructorBuilder1.MyTypeProperty
      If Not Nothing Is myTypeProperty Then
         Dim myObject As Object() ={"Hello"}
         Dim myObject1 As Object = Activator.CreateInstance(myTypeProperty, myObject, Nothing)
         Dim myMethodInfo As MethodInfo = myTypeProperty.GetMethod("HelloWorld")
         
         If Not Nothing Is myMethodInfo Then
            myMethodInfo.Invoke(myObject1, Nothing)
         Else
            Console.WriteLine("Could not locate HelloWorld method")
         End If
      Else
         Console.WriteLine("Could not access Type.")
      End If
   End Sub 'Main
End Class 'MyConstructorBuilder
