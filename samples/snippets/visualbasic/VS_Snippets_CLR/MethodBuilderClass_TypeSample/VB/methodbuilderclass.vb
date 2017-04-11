' System.Reflection.Emit.MethodBuilder

' This program demonstrates 'MethodBuilder' class.  A dynamic class 'myTypeBuilder'
' is created in which a constructor 'myConstructorBuilder' and a method 'myMethodBuilder'
' are created dynamically. Their IL's are generated. The Non-Public methods of the class
' are printed on the console. The attributes and signature of 'MyDynamicMethod' are displayed
' on the console using 'Attributes' and 'Signature' properties of the 'MethodBuilder' class.

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports MicroSoft.VisualBasic

Public Class MethodBuilderClass

   Public Shared Sub Main()
      Try
         ' Get the current AppDomain.
         Dim myAppDomain As AppDomain = AppDomain.CurrentDomain
         Dim myAssemblyName As New AssemblyName()
         myAssemblyName.Name = "MyDynamicAssembly"

         ' Create the dynamic assembly and set its access mode to 'Save'.
         Dim myAssemblyBuilder As AssemblyBuilder = myAppDomain.DefineDynamicAssembly _
                                                      (myAssemblyName, AssemblyBuilderAccess.Save)
         ' Create a dynamic module 'myModuleBuilder'.
         Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule _
                                                                     ("MyDynamicModule", True)
         ' Define a public class 'MyDynamicClass'.
         Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType _
                                                      ("MyDynamicClass", TypeAttributes.Public)
         ' Define a public string field named 'myField'.
         Dim myField As FieldBuilder = myTypeBuilder.DefineField("MyDynamicField", _
                                                   GetType(String), FieldAttributes.Public)
         ' Define the dynamic method 'MyDynamicMethod'.
         Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod("MyDynamicMethod", _
                                 MethodAttributes.Private, GetType(Integer), New Type() {})
         ' Generate the IL for 'myMethodBuilder'.
         Dim myMethodIL As ILGenerator = myMethodBuilder.GetILGenerator()
         ' Emit the necessary opcodes.
         myMethodIL.Emit(OpCodes.Ldarg_0)
         myMethodIL.Emit(OpCodes.Ldfld, myField)
         myMethodIL.Emit(OpCodes.Ret)

         ' Create 'myTypeBuilder' class.
         Dim myType1 As Type = myTypeBuilder.CreateType()

         ' Get the method information of 'myTypeBuilder'.
         Dim myInfo As MethodInfo() = myType1.GetMethods(BindingFlags.NonPublic Or _
                                                         BindingFlags.Instance)
         ' Print non-public methods present of 'myType1'.
         Console.WriteLine(ControlChars.Newline + "The Non-Public methods present in 'myType1' are:" + _
                                                                           ControlChars.NewLine)
         Dim i As Integer
         For i = 0 To myInfo.Length - 1
            Console.WriteLine(myInfo(i).Name)
         Next i
         ' Print the 'Attribute', 'Signature' of 'myMethodBuilder'.
         Console.WriteLine(ControlChars.Newline + "The Attribute of 'MyDynamicMethod' is :{0}", _
                                                                        myMethodBuilder.Attributes)
         Console.WriteLine(ControlChars.Newline + "The Signature of 'MyDynamicMethod' is : " + _
                                                ControlChars.Newline + myMethodBuilder.Signature)
      Catch e As Exception
         Console.WriteLine("Exception :{0}", e.Message)
      End Try
   End Sub 'Main
End Class 'MethodBuilderClass
' </Snippet1>