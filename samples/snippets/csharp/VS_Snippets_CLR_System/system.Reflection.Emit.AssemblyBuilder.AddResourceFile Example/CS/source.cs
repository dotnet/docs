// <Snippet1>

using System;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class AsmBuilderGetFileDemo

{
   private static string myResourceFileName = "MyResource.txt";

   private static FileInfo CreateResourceFile() 
   {

     	FileInfo f = new FileInfo(myResourceFileName); 
	StreamWriter sw = f.CreateText();

	sw.WriteLine("Hello, world!");

	sw.Close();

	return f;

   }

   private static AssemblyBuilder BuildDynAssembly()
   {

	string myAsmFileName = "MyAsm.dll";
	
	AppDomain myDomain = Thread.GetDomain();
	AssemblyName myAsmName = new AssemblyName();
	myAsmName.Name = "MyDynamicAssembly";	

	AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
						myAsmName,
						AssemblyBuilderAccess.RunAndSave);

	myAsmBuilder.AddResourceFile("MyResource", myResourceFileName);

	// To confirm that the resource file has been added to the manifest,
	// we will save the assembly as MyAsm.dll. You can view the manifest
	// and confirm the presence of the resource file by running 
	// "ildasm MyAsm.dll" from the prompt in the directory where you executed
	// the compiled code. 

	myAsmBuilder.Save(myAsmFileName);	

	return myAsmBuilder;

   }

   public static void Main() 
   {

	FileStream myResourceFS = null;

	CreateResourceFile();

	Console.WriteLine("The contents of MyResource.txt, via GetFile:");

	AssemblyBuilder myAsm = BuildDynAssembly();

	try 
        {
	   myResourceFS = myAsm.GetFile(myResourceFileName);
        }
	catch (NotSupportedException)
	{
	   Console.WriteLine("---");
	   Console.WriteLine("System.Reflection.Emit.AssemblyBuilder.GetFile\nis not supported " +
			     "in this SDK build.");
	   Console.WriteLine("The file data will now be retrieved directly, via a new FileStream.");
	   Console.WriteLine("---");
	   myResourceFS = new FileStream(myResourceFileName, 
					 FileMode.Open);
	}
	 
	StreamReader sr = new StreamReader(myResourceFS, System.Text.Encoding.ASCII);
	Console.WriteLine(sr.ReadToEnd());
	sr.Close();

   }

}

// </Snippet1>
