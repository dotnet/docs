' System.Reflection.Emit.EnumBuilder
' System.Reflection.Emit.EnumBuilder.IsDefined()
' System.Reflection.Emit.EnumBuilder.GetCustomAttributes(Type, Boolean)
' System.Reflection.Emit.EnumBuilder.SetCustomAttribute(CustomAttributeBuilder)

' The following program demonstrates the EnumBuilder class and
' its methods  'IsDefined', 'GetCustomAttributes(Type, Boolean)' and
' 'SetCustomAttribute(CustomAttributeBuilder)'. It defines a 'MyAttribute'
' class which is derived from 'System.Attribute' class. It builds an Enum
' and sets 'MyAttribute' as  custom attribute to the Enum.It gets the
' custom attributes of the Enum type and displays its contents on the console.

' <Snippet1>

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
' <Snippet2>
<AttributeUsage(AttributeTargets.All, AllowMultiple := False)>  _
Public Class MyAttribute
   Inherits Attribute
   Public myString As String
   Public myInteger As Integer

   Public Sub New(myString1 As String, myInteger1 As Integer)
      Me.myString = myString1
      Me.myInteger = myInteger1
   End Sub 'New
End Class 'MyAttribute

Class MyApplication
   Private Shared myAssemblyBuilder As AssemblyBuilder
   Private Shared myEnumBuilder As EnumBuilder

   Public Shared Sub Main()
      Try
         CreateCallee(Thread.GetDomain())
         If myEnumBuilder.IsDefined(GetType(MyAttribute), False) Then
            Dim myAttributesArray As Object() = myEnumBuilder.GetCustomAttributes _
                                                      (GetType(MyAttribute), False)
            Console.WriteLine("Custom attribute contains: ")
            ' Read the attributes and display them on the console.
            Dim index As Integer
            For index = 0 To myAttributesArray.Length - 1
               If TypeOf myAttributesArray(index) Is MyAttribute Then
                  Console.WriteLine("The value of myString  is: " + CType(myAttributesArray(index), _
                                                                           MyAttribute).myString)
                  Console.WriteLine("The value of myInteger is: " + CType(myAttributesArray(index), _
                                                               MyAttribute).myInteger.ToString())
               End If
            Next index
         Else
            Console.WriteLine("Custom Attributes are not set for the EnumBuilder")
         End If
      Catch e As Exception
         Console.WriteLine("The following exception is raised:" + e.Message)
      End Try
   End Sub 'Main

   Private Shared Sub CreateCallee(domain As AppDomain)
      ' Create a name for the assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"

      ' Create the dynamic assembly.
      myAssemblyBuilder = domain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)

      Dim myType As Type = GetType(MyAttribute)
      Dim myInfo As ConstructorInfo = myType.GetConstructor(New Type(1) {GetType(String), _
                                                                           GetType(Integer)})
      Dim myCustomAttributeBuilder As New CustomAttributeBuilder(myInfo, New Object(1) {"Hello", 2})

      ' Create a dynamic module.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("EmittedModule")

      ' Create a dynamic Enum.
      myEnumBuilder = myModuleBuilder.DefineEnum("MyNamespace.MyEnum", TypeAttributes.Public, _
                                                                                 GetType(Int32))

      Dim myFieldBuilder1 As FieldBuilder = myEnumBuilder.DefineLiteral("FieldOne", 1)
      Dim myFieldBuilder2 As FieldBuilder = myEnumBuilder.DefineLiteral("FieldTwo", 2)

      myEnumBuilder.CreateType()
      myEnumBuilder.SetCustomAttribute(myCustomAttributeBuilder)
   End Sub 'CreateCallee
End Class 'MyApplication
' </Snippet2>
' </Snippet1>