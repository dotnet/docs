' System.Reflection.Emit.ConstructorBuilder.AddDeclarativeSecurity()
' System.Reflection.Emit.ConstructorBuilder.Attributes
' System.Reflection.Emit.ConstructorBuilder.DeclaringType
' System.Reflection.Emit.ConstructorBuilder.DefineParameter()

' The following program demonstrates the 'AddDeclarativeSecurity',
' 'DefineParameter' methods, and  'Attributes', 'DeclaringType' properties
' of the ConstructorBuilder class. Create the assembly in the current domain
' with dynamic module in the assembly. Constructor  builder is used in
' conjunction with the 'TypeBuilder' class to create constructor at run time.
' Add declarative security to the constructor. Display the 'Attributes',
' 'DeclaringType' and 'DefineParameter'.

Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions
Imports System.Security

Friend Class MyConstructorBuilder
   Private myType1 As Type
   Private myModuleBuilder As ModuleBuilder = Nothing
   Private myAssemblyBuilder As AssemblyBuilder = Nothing

   Friend Sub New()
' <Snippet1>
' <Snippet2>
' <Snippet3>
      Dim myMethodBuilder As MethodBuilder = Nothing

      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      ' Create assembly in current CurrentDomain
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Create a dynamic assembly
      myAssemblyBuilder = _
            myCurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave)
      ' Create a dynamic module in the assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      Dim myFieldInfo As FieldInfo = _
          myModuleBuilder.DefineUninitializedData("myField", 2, FieldAttributes.Public)
      ' Create a type in the module
      Dim myTypeBuilder As TypeBuilder = _
          myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myGreetingField As FieldBuilder = _
         myTypeBuilder.DefineField("Greeting", GetType(String), FieldAttributes.Public)
      Dim myConstructorArgs As Type() = {GetType(String)}
      ' Define a constructor of the dynamic class.
      Dim myConstructor As ConstructorBuilder = _
          myTypeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, _
                                          myConstructorArgs)
      Dim myPset As New PermissionSet(PermissionState.Unrestricted)
      ' Add declarative security to the constructor.
      Console.WriteLine("Adding declarative security to the constructor.....")
      Console.WriteLine("The Security action to be taken is ""DENY"" and" + _
                        " Permission set is ""UNRESTRICTED"".")
      myConstructor.AddDeclarativeSecurity(SecurityAction.Deny, myPset)
' </Snippet3>
      Dim myMethodAttributes As MethodAttributes = myConstructor.Attributes
      Dim myAttributeType As Type = GetType(MethodAttributes)
      Dim myAttribValue As Integer = CInt(myMethodAttributes)
      If Not myAttributeType.IsEnum Then
         Console.WriteLine("This is not an Enum")
      End If
      Dim myFieldInfo1 As FieldInfo() = myAttributeType.GetFields(BindingFlags.Public Or _
                                                                   BindingFlags.Static)
      Console.WriteLine("The Field info names of the Attributes for the constructor are:")
      Dim i As Integer
      For i = 0 To myFieldInfo1.Length - 1
         Dim myFieldValue As Integer = CType(myFieldInfo1(i).GetValue(Nothing), Int32)
         If(myFieldValue And myAttribValue) = myFieldValue Then
            Console.WriteLine("   " + myFieldInfo1(i).Name)
         End If
      Next i

      Dim myType2 As Type = myConstructor.DeclaringType
      Console.WriteLine("The declaring type is : " + myType2.ToString())
' </Snippet2>
      Dim myParameterBuilder1 As ParameterBuilder = _
          myConstructor.DefineParameter(1, ParameterAttributes.Out, "My Parameter Name1")
      Console.WriteLine("The name of the parameter is : " + myParameterBuilder1.Name)
      If myParameterBuilder1.IsIn Then
         Console.WriteLine(myParameterBuilder1.Name + " is Input parameter.")
      Else
         Console.WriteLine(myParameterBuilder1.Name + " is not Input Parameter.")
      End If
      Dim myParameterBuilder2 As ParameterBuilder = _
          myConstructor.DefineParameter(1, ParameterAttributes.In, "My Parameter Name2")
      Console.WriteLine("The Parameter name is : " + myParameterBuilder2.Name)
      If myParameterBuilder2.IsIn Then
         Console.WriteLine(myParameterBuilder2.Name + " is Input parameter.")
      Else
         Console.WriteLine(myParameterBuilder2.Name + " is not Input Parameter.")
      End If
' </Snippet1>
      ' Generate MSIL for the method, call its base class constructor and store the arguments
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
      ' Generate MSIL for the method.
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