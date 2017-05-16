' System.Reflection.Emit.ModuleBuilder.GetArrayMethod
' System.Reflection.Emit.ModuleBuilder.GetArrayMethodToken

' The following example demonstrates 'GetArrayMethod' and 'GetArrayMethodToken'
' methods of 'ModuleBuilder' class.
' A dynamic assembly with a module having a runtime class, 'TempClass' is created. 
' This class defines a method, 'SortArray', which sorts the elements of the array 
' passed to it.The 'GetArrayMethod' method is used to obtain the 'MethodInfo' object 
' corresponding to the 'Sort' method of the 'Array' .The token used to identify the 'Sort' 
' method in dynamic module is displayed using 'GetArrayMethodToken' method.

Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions

Friend Class CodeGenerator
   Private myAssemblyBuilder As AssemblyBuilder
   Friend Sub New()
      Dim myCurrentDomain As AppDomain = AppDomain.CurrentDomain
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Define a dynamic assembly in the current application domain.
      myAssemblyBuilder = _
            myCurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave)
' <Snippet1>
' <Snippet2>
      ' Define a dynamic module in "TempAssembly" assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      ' Define a runtime class with specified name and attributes.
      Dim myTypeBuilder As TypeBuilder = _
                  myModuleBuilder.DefineType("TempClass", TypeAttributes.Public)
      Dim myParamArray() As Type = New Type() {GetType(Array)}
      ' Add 'SortArray' method to the class, with the given signature.
      Dim myMethod As MethodBuilder = _
         myTypeBuilder.DefineMethod("SortArray", MethodAttributes.Public, _
         GetType(Array), myParamArray)

      Dim myArrayClass(0) As Type
      Dim parameterTypes() As Type = New Type() {GetType(Array)}
      ' Get the 'MethodInfo' object corresponding to 'Sort' method of 'Array' class.
      Dim myMethodInfo As MethodInfo = _
         myModuleBuilder.GetArrayMethod(myArrayClass.GetType(), "Sort", _
         CallingConventions.Standard, Nothing, parameterTypes)
      ' Get the token corresponding to 'Sort' method of 'Array' class.
      Dim myMethodToken As MethodToken = _
            myModuleBuilder.GetArrayMethodToken(myArrayClass.GetType(), _
            "Sort", CallingConventions.Standard, Nothing, parameterTypes)
      Console.WriteLine("Token used by module to identify the 'Sort' method" + _
                        " of 'Array' class is : {0:x} ", myMethodToken.Token)
      Dim methodIL As ILGenerator = myMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldarg_1)
      methodIL.Emit(OpCodes.Call, myMethodInfo)
      methodIL.Emit(OpCodes.Ldarg_1)
      methodIL.Emit(OpCodes.Ret)
      ' Complete the creation of type.
      myTypeBuilder.CreateType()
' </Snippet1>
' </Snippet2>
   End Sub 'New

   Public ReadOnly Property MyBuilder() As AssemblyBuilder
      Get
         Return Me.myAssemblyBuilder
      End Get
   End Property
End Class 'CodeGenerator

Public Class TestClass
   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Dim myCodeGenerator As New CodeGenerator()
      Dim myAssemblyBuilder As AssemblyBuilder = myCodeGenerator.MyBuilder
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.GetDynamicModule("TempModule")
      Dim myType As Type = myModuleBuilder.GetType("TempClass")
      Dim myObject As Object = Activator.CreateInstance(myType)
      Dim sortArray As MethodInfo = myType.GetMethod("SortArray")
      If Not sortArray Is Nothing Then
         Dim arrayToSort As String() =  {"I", "am", "not", "sorted"}
         Console.WriteLine("Array elements before sorting ")
         Dim i As Integer
         For i = 0 To arrayToSort.Length - 1
            Console.WriteLine("Array element {0} : {1} ", i, arrayToSort(i))
         Next i
         Dim arguments() As Object = New Object() {arrayToSort}
         Console.WriteLine("Invoking our dynamically " + _
                           "created SortArray method...")
         Dim myOutput As Object = sortArray.Invoke(myObject, arguments)
         Dim mySortedArray As String() = CType(myOutput, String())
         Console.WriteLine("Array elements after sorting ")
         Dim j As Integer
         For j = 0 To mySortedArray.Length - 1
            Console.WriteLine("Array element {0} : {1} ", j, mySortedArray(j))
         Next j
      End If
   End Sub 'Main
End Class 'TestClass
