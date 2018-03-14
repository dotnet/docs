' System.Reflection.Emit.EnumBuilder.TypeToken
' System.Reflection.Emit.EnumBuilder.UnderlyingField
' System.Reflection.Emit.EnumBuilder.UnderlyingSystemType
' System.Reflection.Emit.EnumBuilder.GUID

' The following program demonstrates 'TypeToken', 'UnderlyingField',
' 'UnderlyingSystemType' and ''GUID' properties of
' 'System.Reflection.Emit.EnumBuilder' class. This example defines
' a class 'MyEnumBuilderSample'. The main function calls the CreateCalle
' method in which the 'EnumBuilder' class and its fields are constructed.
' The output of the 'EnumBuilder' properties are displayed on the console
' in the main method.

' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
Imports System
Imports System.Collections
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

Public Class MyEnumBuilderSample
   Private Shared myAssemblyBuilder As AssemblyBuilder
   Private Shared myModuleBuilder As ModuleBuilder
   Private Shared myEnumBuilder As EnumBuilder
   
   
   Public Shared Sub Main()
      Try
         CreateCallee(Thread.GetDomain(), AssemblyBuilderAccess.Save)
         Dim myTypeArray As Type() = myModuleBuilder.GetTypes()
         Dim myType As Type
         For Each myType In  myTypeArray
            Console.WriteLine("Enum Builder defined in the module builder is: " + myType.Name)
         Next myType
         
         Console.WriteLine("Enum TypeToken is :" + myEnumBuilder.TypeToken.ToString())
         Console.WriteLine("Enum UnderLyingField is :" + myEnumBuilder.UnderlyingField.ToString())
         Console.WriteLine("Enum UnderLyingSystemType is :" + myEnumBuilder.UnderlyingSystemType.ToString())
         Console.WriteLine("Enum GUID is :" + myEnumBuilder.GUID.ToString())
         myAssemblyBuilder.Save("EmittedAssembly.dll")
      Catch ex As NotSupportedException
         Console.WriteLine("The following is the exception is raised: " + ex.Message)
      Catch e As Exception
         Console.WriteLine("The following is the exception raised: " + e.Message)
      End Try
   End Sub 'Main
   
   
   Private Shared Sub CreateCallee(myAppDomain As AppDomain, access As AssemblyBuilderAccess)
      ' Create a name for the assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"
      
      ' Create the dynamic assembly.
      myAssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName, _
                 AssemblyBuilderAccess.Save)
      ' Create a dynamic module.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule", "EmittedModule.mod")
      ' Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder.DefineEnum("MyNamespace.MyEnum", _
                 TypeAttributes.Public, GetType(Int32))
      
      Dim myFieldBuilder1 As FieldBuilder = myEnumBuilder.DefineLiteral("FieldOne", 1)
      Dim myFieldBuilder2 As FieldBuilder = myEnumBuilder.DefineLiteral("FieldTwo", 2)
      
      myEnumBuilder.CreateType()
   End Sub 'CreateCallee
End Class 'MyEnumBuilderSample
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>