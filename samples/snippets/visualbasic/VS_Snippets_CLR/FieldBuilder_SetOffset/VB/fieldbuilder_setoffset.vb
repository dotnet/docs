' System.Reflection.Emit.FieldBuilder.SetOffset
' System.Reflection.Emit.FieldBuilder.SetMarshal

'  The following program demonstrates 'SetOffset' and 'SetMarshal'
'  methods of 'FieldBuilder' class.A new Class is defined and a
'  'PInvoke' method 'OpenFile' method of 'Kernel32.dll' is defined
'  in the class.Instance of the class is created and the method is invoked.
'  To execute this program, make sure a file named'MyFile.txt' should be there 
'  in the current directory.

' <Snippet1>
Imports System
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security.Permissions
Imports System.Runtime.CompilerServices

Public Class FieldBuilder_Sample

   Public Shared Function CreateType(ByVal currentDomain As AppDomain) As Type

      ' Create an assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "DynamicAssembly"
      Dim myAssembly As AssemblyBuilder = currentDomain.DefineDynamicAssembly(myAssemblyName, _
                                          AssemblyBuilderAccess.RunAndSave)
      ' Create a dynamic module in Dynamic Assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssembly.DefineDynamicModule("MyModule", _
                                            "MyModule.mod")
      ' Define a public class named "MyClass" in the assembly.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("MyClass", _
                                         TypeAttributes.Public)
      Dim myTypeBuilder2 As TypeBuilder = myModuleBuilder.DefineType("MyClass2", _
         TypeAttributes.Public Or TypeAttributes.BeforeFieldInit Or _
         TypeAttributes.SequentialLayout Or TypeAttributes.AnsiClass Or TypeAttributes.Sealed)
      Dim myFieldBuilder1 As FieldBuilder = myTypeBuilder2.DefineField("myBytes1", _
         GetType(Byte), FieldAttributes.Public)
      Dim myFieldBuilder2 As FieldBuilder = myTypeBuilder2.DefineField("myBytes2", _
         GetType(Byte), FieldAttributes.Public)
      Dim myFieldBuilder3 As FieldBuilder = myTypeBuilder2.DefineField("myErrorCode", _
         GetType(Short), FieldAttributes.Public)
      Dim myFieldBuilder4 As FieldBuilder = myTypeBuilder2.DefineField("myReserved1", _
         GetType(Short), FieldAttributes.Public)
      Dim myFieldBuilder5 As FieldBuilder = myTypeBuilder2.DefineField("myReserved2", _
         GetType(Short), FieldAttributes.Public)
      Dim myFieldBuilder6 As FieldBuilder = myTypeBuilder2.DefineField("myPathName", _
         GetType(Char()), FieldAttributes.Public)
      myFieldBuilder6.SetMarshal(UnmanagedMarshal.DefineByValArray(128))
      myFieldBuilder6.SetOffset(4)
      Dim myType1 As Type = myTypeBuilder2.CreateType()
      ' Create the PInvoke method for 'OpenFile' method of 'Kernel32.dll'.
      Dim myParameters As Type() = {GetType(String), myType1, GetType(System.UInt32)}
      Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefinePInvokeMethod("OpenFile", _
         "kernel32.dll", MethodAttributes.Public Or MethodAttributes.Static Or _
         MethodAttributes.HideBySig, CallingConventions.Standard, GetType(IntPtr), _
         myParameters, CallingConvention.Winapi, CharSet.None)
      Dim myAttributeType As Type = GetType(MethodImplAttribute)
      Dim myConstructorInfo As ConstructorInfo = myAttributeType.GetConstructor(New Type(0) _
         {GetType(MethodImplOptions)})
      Dim myAttributeBuilder As New CustomAttributeBuilder(myConstructorInfo, _
         New Object() {MethodImplOptions.PreserveSig})
      myMethodBuilder.SetCustomAttribute(myAttributeBuilder)
      Dim myParameterBuilder2 As ParameterBuilder = myMethodBuilder.DefineParameter(2, _
         ParameterAttributes.Out, "myClass2")
      Dim myType As Type = myTypeBuilder.CreateType()
      myAssembly.Save("EmittedAssembly.dll")
      Return myType
   End Function 'CreateType

   <PermissionSetAttribute(SecurityAction.Demand, Name:="FullTrust")> _
   Public Shared Sub Main()
      Try
         Dim myType As Type = CreateType(Thread.GetDomain())
         Dim myClass2 As Type = myType.Module.GetType("MyClass2")
         Dim myParam2 As Object = Activator.CreateInstance(myClass2)
         Dim myUint As System.UInt32
         myUint.Parse("800")

         Dim myArgs As Object() = {"MyFile.Txt", myParam2, myUint}
         Dim myObject As Object = myType.InvokeMember("OpenFile", _
                                    BindingFlags.Public Or BindingFlags.InvokeMethod Or _
                                    BindingFlags.Static, Nothing, Nothing, myArgs)
         Console.WriteLine("MyClass.OpenFile method returned: '{0}'", myObject)
      Catch e As Exception
         Console.WriteLine("Exception Caught: " & e.Message)
      End Try
   End Sub 'Main
End Class 'FieldBuilder_Sample
' </Snippet1>