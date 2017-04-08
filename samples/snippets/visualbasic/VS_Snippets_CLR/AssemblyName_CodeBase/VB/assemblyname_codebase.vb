 ' System.Reflection.AssemblyName.CodeBase
' System.Reflection.AssemblyName.CultureInfo
' System.Reflection.AssemblyName.HashAlgorithm
' System.Reflection.AssemblyName.FullName
' The following example demonstrates the 'CodeBase', 'CultureInfo'
' 'HashAlgorithm' and 'FullName' properties of the 'AssemblyName' class. 
' Creates a dynamic assembly named 'MyAssembly' with a module named 'MyModule' 
' and a type within the module named 'MyType'. The type 'MyType' has a single' method called 
' 'Main' which is also the entry point to the assembly.
' The creation of the dynamic assembly is carried out by the method called'   'MakeAssembly'. After the assembly is created with the help of 'MakeAssembly''   the assemblies currently loaded are found and the dynamic assembly that we'   have created is searched for, which is displayed to the console. The dynamic'   assembly is also saved to a file named 'MyAssembly.exe'.
' Note : Run 'MyAssembly.exe' which this example has created 
' for a simple 'Hello World!" display.'
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>

Imports System
Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.Threading
Imports System.IO
Imports System.Globalization
Imports System.Reflection.Emit
Imports System.Configuration.Assemblies

Public Class AssemblyName_CodeBase
   
   Public Shared Sub MakeAssembly(myAssemblyName As AssemblyName, fileName As String)
      ' Get the assembly builder from the application domain associated with the current thread.
      Dim myAssemblyBuilder As AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave)
      ' Create a dynamic module in the assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("MyModule", fileName)
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("MyType")
      ' Create a method called 'Main'.
      Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod("Main", MethodAttributes.Public Or MethodAttributes.HideBySig Or MethodAttributes.Static, GetType(object), Nothing)
      ' Get the Intermediate Language generator for the method.
      Dim myILGenerator As ILGenerator = myMethodBuilder.GetILGenerator()
      ' Use the utility method to generate the IL instructions that print a string to the console.
      myILGenerator.EmitWriteLine("Hello World!")
      ' Generate the 'ret' IL instruction.
      myILGenerator.Emit(OpCodes.Ret)
      ' End the creation of the type.
      myTypeBuilder.CreateType()
      ' Set the method with name 'Main' as the entry point in the assembly.
      myAssemblyBuilder.SetEntryPoint(myMethodBuilder)
      myAssemblyBuilder.Save(fileName)
   End Sub 'MakeAssembly
   
   
   Public Shared Sub Main()
      
      ' Create a dynamic assembly with name 'MyAssembly' and build version '1.0.0.2001'.
      Dim myAssemblyName As New AssemblyName()
      ' Set the codebase to the physical directory were the assembly resides.
      myAssemblyName.CodeBase = Directory.GetCurrentDirectory()
      ' Set the culture information of the assembly to 'English-American'.
      myAssemblyName.CultureInfo = New CultureInfo("en-US")
      ' Set the hash algoritm to 'SHA1'.
      myAssemblyName.HashAlgorithm = AssemblyHashAlgorithm.SHA1
      myAssemblyName.Name = "MyAssembly"
      myAssemblyName.Version = New Version("1.0.0.2001")
      MakeAssembly(myAssemblyName, "MyAssembly.exe")
      
      ' Get all the assemblies currently loaded in the application domain.
      Dim myAssemblies As [Assembly]() = Thread.GetDomain().GetAssemblies()
      
      ' Get the dynamic assembly named 'MyAssembly'. 
      Dim myAssembly As [Assembly] = Nothing
      Dim i As Integer
      For i = 0 To myAssemblies.Length - 1
         If [String].Compare(myAssemblies(i).GetName().Name, "MyAssembly") = 0 Then
            myAssembly = myAssemblies(i)
         End If
      Next i ' Display the full assembly information to the console.
      If Not (myAssembly Is Nothing) Then
         Console.WriteLine(vbCrLf & "Displaying the full assembly name" & vbCrLf)
         Console.WriteLine(myAssembly.GetName().FullName)
      End If
   End Sub 
End Class 
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>