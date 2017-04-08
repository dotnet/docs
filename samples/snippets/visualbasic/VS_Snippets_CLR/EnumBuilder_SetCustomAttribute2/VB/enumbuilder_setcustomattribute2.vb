' System.Reflection.Emit.EnumBuilder.GetCustomAttributes(Boolean)
' System.Reflection.Emit.EnumBuilder.SetCustomAttribute(ConstructorInfo, Byte())

' The following program demonstrates 'GetCustomAttributes(Boolean)'
' and 'SetCustomAttribute(ConstructorInfo, Byte())' methods of 
' 'System.Reflection.Emit.EnumBuilder' class. It defines 'MyAttribute' 
' class which is derived from 'System.Attribute' class. It builds an 
' Enum and sets 'MyAttribute' as  custom attribute to the Enum. 
' It gets the custom attributes of the Enum type and displays its contents 
' on the console.


' <Snippet1>
' <Snippet2>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

<AttributeUsage(AttributeTargets.All, AllowMultiple := False)>  _
Public Class MyAttribute
   Inherits Attribute
   Public myBoolValue As Boolean
   
   Public Sub New(myBool As Boolean)
      Me.myBoolValue = myBool
   End Sub 'New
End Class 'MyAttribute

Class MyApplication
   Private Shared myEnumBuilder As EnumBuilder
   
   Public Shared Sub Main()
      Try
         CreateCallee(Thread.GetDomain())
         Dim myAttributesArray As Object() = myEnumBuilder.GetCustomAttributes(True)
         
         ' Read the attributes and display them on the console.
         Console.WriteLine("Custom attribute contains: ")
         Dim index As Integer
         For index = 0 To myAttributesArray.Length - 1
            If TypeOf myAttributesArray(index) Is MyAttribute Then
               Console.WriteLine("myBoolValue: " + CType(myAttributesArray(index), MyAttribute). _
                                                                           myBoolValue.ToString())
            End If
         Next index
      Catch e As Exception
         Console.WriteLine("The following exception is raised:" + e.Message)
      End Try
   End Sub 'Main
   
   Private Shared Sub CreateCallee(domain As AppDomain)
      Dim myAssemblyName As New AssemblyName()
      ' Create a name for the assembly.
      myAssemblyName.Name = "EmittedAssembly"
      
      ' Create the dynamic assembly.
      Dim myAssemblyBuilder As AssemblyBuilder = domain.DefineDynamicAssembly(myAssemblyName, _
                                                                  AssemblyBuilderAccess.Run)
      
      Dim myType As Type = GetType(MyAttribute)
      Dim myInfo As ConstructorInfo = myType.GetConstructor(New Type() {GetType(Boolean)})
      
      ' Create a dynamic module.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule")
      
      ' Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder.DefineEnum("MyNamespace.MyEnum", TypeAttributes.Public, _
                                                                              GetType(Int32))
      
      Dim myFieldBuilder1 As FieldBuilder = myEnumBuilder.DefineLiteral("FieldOne", 1)
      Dim myFieldBuilder2 As FieldBuilder = myEnumBuilder.DefineLiteral("FieldTwo", 2)
      
      myEnumBuilder.CreateType()
      myEnumBuilder.SetCustomAttribute(myInfo, New Byte() {1, 0, 1})
   End Sub 'CreateCallee 
End Class 'MyApplication
' </Snippet2>
' </Snippet1>