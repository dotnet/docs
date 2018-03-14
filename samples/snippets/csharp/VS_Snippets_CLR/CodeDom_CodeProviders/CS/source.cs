// The following example illustrates using the C# or Visual Basic 
// code providers to compile a source file.  The example program takes
// a source file as input and attempts to compile the code into an executable.
// If the source file has a .vb extension, it is compiled with the Visual Basic
// code provider.  If it has a .cs extension, it is compiled with the CSharp 
// code provider.

// <Snippet1>
using System;
using System.IO;
using System.Globalization;
using System.CodeDom.Compiler;
using System.Text;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace CodeProviders
{
	class CompileSample
	{
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                //  First parameter is the source file name.
                if (File.Exists(args[0]))
                {
                    CompileExecutable(args[0]);
                }
                else 
                {
                    Console.WriteLine("Input source file not found - {0}",
                        args[0]);
                }
            }
            else 
            {
                Console.WriteLine("Input source file not specified on command line!");
            }
        }

        //<Snippet2>
        public static bool CompileExecutable(String sourceName)
        {
            FileInfo sourceFile = new FileInfo(sourceName);
            CodeDomProvider provider = null;
            bool compileOk = false;

            // Select the code provider based on the input file extension.
            if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".CS")
            {
                provider = CodeDomProvider.CreateProvider("CSharp");
            }
            else if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".VB")
            {
                provider = CodeDomProvider.CreateProvider("VisualBasic");
            }
            else 
            {
                Console.WriteLine("Source file must have a .cs or .vb extension");
            }

            if (provider != null)
            {

                // Format the executable file name.
                // Build the output assembly path using the current directory
                // and <source>_cs.exe or <source>_vb.exe.
 
                String exeName = String.Format(@"{0}\{1}.exe", 
                    System.Environment.CurrentDirectory, 
                    sourceFile.Name.Replace(".", "_"));

                CompilerParameters cp = new CompilerParameters();

                // Generate an executable instead of 
                // a class library.
                cp.GenerateExecutable = true;

                // Specify the assembly file name to generate.
                cp.OutputAssembly = exeName;
    
                // Save the assembly as a physical file.
                cp.GenerateInMemory = false;
    
                // Set whether to treat all warnings as errors.
                cp.TreatWarningsAsErrors = false;
 
                // Invoke compilation of the source file.
                CompilerResults cr = provider.CompileAssemblyFromFile(cp, 
                    sourceName);
    
                if(cr.Errors.Count > 0)
                {
                    // Display compilation errors.
                    Console.WriteLine("Errors building {0} into {1}",  
                        sourceName, cr.PathToAssembly);
                    foreach(CompilerError ce in cr.Errors)
                    {
                        Console.WriteLine("  {0}", ce.ToString());
                        Console.WriteLine();
                    }
                }
                else
                {
                    // Display a successful compilation message.
                    Console.WriteLine("Source {0} built into {1} successfully.",
                        sourceName, cr.PathToAssembly);
                }
              
                // Return the results of the compilation.
                if (cr.Errors.Count > 0)
                {
                    compileOk = false;
                }
                else 
                {
                    compileOk = true;
                }
            }
            return compileOk;
        }
        //</Snippet2>
	}
}
// </Snippet1>
