 ' System.Reflection.AssemblyName.SetPublicKey(byte[])
' System.Reflection.AssemblyName.SetPublicKeyToken(byte[])
' The following example demonstrates the 'SetPublicKey(byte[])' 
' and the 'SetPublicKeyToken(byte[])' methods of the 'AssemblyName' class.
' Creates   a dynamic assembly named 'MyAssembly' with a module named 'MyModule' and  
' a type within the module named 'MyType'. The type 'MyType' has a single   method called 'Main' 
' which is also the entry point to the assembly. The creation of the dynamic assembly is carried 
' out by the method called   'MakeAssembly'. After the assembly is created with the help of 
' 'MakeAssembly'   the assemblies currently loaded are found and the dynamic assembly that we  
' have created is searched for, which is displayed to the console. 
' The dynamic assembly is also saved to a file named 'MyAssembly.exe'. 
' The assembly is   provided with a strong name. This is done by getting the public key and 
' the public key token from the 'KeyPair.snk' (private and public key file).
' The public key is stored in 'PublicKey.snk' and the public key token is 
' stored in 'PublicKeyToken.snk' with the help of the tool named 'sn.exe'.
' Note : Running 'MyAssembly.exe' with this example does not display 'Hello World!'
'since this assembly has been stongly signed.
' <Snippet1>
' <Snippet2>
Imports System
Imports System.Reflection
Imports System.Threading
Imports System.IO
Imports System.Globalization
Imports System.Reflection.Emit
Imports System.Configuration.Assemblies
Imports System.Text
Imports Microsoft.VisualBasic

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
      myAssemblyName.VersionCompatibility = AssemblyVersionCompatibility.SameProcess
      myAssemblyName.Flags = AssemblyNameFlags.PublicKey
      ' Get the whole contents of the 'PublicKey.snk' into a byte array.
      Dim publicKeyStream As FileStream = File.Open("PublicKey.snk", FileMode.Open)
      Dim publicKey(publicKeyStream.Length) As Byte
      publicKeyStream.Read(publicKey, 0, CInt(publicKeyStream.Length))
      ' Provide the assembly with a public key.
      myAssemblyName.SetPublicKey(publicKey)
      ' Get the whole contents of the 'PublicKeyToken.snk' into a byte array.
      Dim publicKeyTokenStream As FileStream = File.Open("PublicKeyToken.snk", FileMode.Open)
      Dim publicKeyToken() As Byte = New [Byte](publicKeyTokenStream.Length) {}
      publicKeyTokenStream.Read(publicKeyToken, 0, CInt(publicKeyToken.Length))
      ' Provide the assembly with a public key token.
      myAssemblyName.SetPublicKeyToken(publicKeyToken)
      myAssemblyName.Name = "MyAssembly"
      myAssemblyName.Version = New Version("1.0.0.2001")
      MakeAssembly(myAssemblyName, "MyAssembly.exe")
      
      ' Get the assemblies loaded in the current application domain.
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
         Console.WriteLine(ControlChars.Cr + "Displaying the full assembly name" + ControlChars.Cr)
         Dim assemblyName As String = myAssembly.GetName().FullName
         Console.WriteLine(assemblyName)
         Console.WriteLine(ControlChars.Cr + "Displaying the public key for the assembly" + ControlChars.Cr)
         Dim publicKeyBytes As Byte() = myAssembly.GetName().GetPublicKey()
         Console.WriteLine(Encoding.ASCII.GetString(publicKeyBytes))
         Console.WriteLine(ControlChars.Cr + "Displaying the public key token for the assembly" + ControlChars.Cr)
         Dim publicKeyTokenBytes As Byte() = myAssembly.GetName().GetPublicKeyToken()
         Console.WriteLine(Encoding.ASCII.GetString(publicKeyTokenBytes))
      End If
   End Sub 'Main 
End Class 'AssemblyName_CodeBase 
' </Snippet2>
' </Snippet1>