' <Snippet1>

Imports System
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class AsmBuilderGetFileDemo
   
   Private Shared myResourceFileName As String = "MyResource.txt"
   
   
   Private Shared Function CreateResourceFile() As FileInfo
      
      Dim f As New FileInfo(myResourceFileName)
      Dim sw As StreamWriter = f.CreateText()
      
      sw.WriteLine("Hello, world!")
      
      sw.Close()
      
      Return f

   End Function 'CreateResourceFile
    
   
   Private Shared Function BuildDynAssembly() As AssemblyBuilder
      
      Dim myAsmFileName As String = "MyAsm.dll"
      
      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, _
					    AssemblyBuilderAccess.RunAndSave)
      
      myAsmBuilder.AddResourceFile("MyResource", myResourceFileName)
      
      ' To confirm that the resource file has been added to the manifest,
      ' we will save the assembly as MyAsm.dll. You can view the manifest
      ' and confirm the presence of the resource file by running 
      ' "ildasm MyAsm.dll" from the prompt in the directory where you executed
      ' the compiled code. 
      myAsmBuilder.Save(myAsmFileName)
      
      Return myAsmBuilder

   End Function 'BuildDynAssembly
    
   
   Public Shared Sub Main()
      
      Dim myResourceFS As FileStream = Nothing
      
      CreateResourceFile()
      
      Console.WriteLine("The contents of MyResource.txt, via GetFile:")
      
      Dim myAsm As AssemblyBuilder = BuildDynAssembly()
      
      Try

         myResourceFS = myAsm.GetFile(myResourceFileName)

      Catch nsException As NotSupportedException
	 
	 Console.WriteLine("---")
	 Console.WriteLine("System.Reflection.Emit.AssemblyBuilder.GetFile is not supported " + _
			     "in this SDK build.")
	 Console.WriteLine("The file data will now be retrieved directly, via a new FileStream.")
	 Console.WriteLine("---")
	 myResourceFS = New FileStream(myResourceFileName, FileMode.Open) 

      End Try
      
      Dim sr As New StreamReader(myResourceFS, System.Text.Encoding.ASCII)
      Console.WriteLine(sr.ReadToEnd())
      sr.Close()

   End Sub 'Main 

End Class 'AsmBuilderGetFileDemo

' </Snippet1>
