// The following example builds a CodeDom source graph for a simple
// Hello World program.  The source is then saved to a file,
// compiled into an executable, and run.

// This example is based loosely on the CodeDom example, but its
// primary intent is to illustrate the CompilerParameters class.
//<Snippet1>
using System;
using System.Globalization;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace CompilerParametersExample
{
    class CompileClass
    {
        // Build a Hello World program graph using System.CodeDom types.
        public static CodeCompileUnit BuildHelloWorldGraph()
        {            
            // Create a new CodeCompileUnit to contain the program graph
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // Declare a new namespace called Samples.
            CodeNamespace samples = new CodeNamespace("Samples");
            // Add the new namespace to the compile unit.
            compileUnit.Namespaces.Add( samples );

            // Add the new namespace import for the System namespace.
            samples.Imports.Add( new CodeNamespaceImport("System") );            

            // Declare a new type called Class1.
            CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");
            // Add the new type to the namespace's type collection.
            samples.Types.Add(class1);
            
            // Declare a new code entry point method.
            CodeEntryPointMethod start = new CodeEntryPointMethod();

            // Create a type reference for the System.Console class.
            CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");

            // Build a Console.WriteLine statement.
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression( 
                csSystemConsoleType, "WriteLine", 
                new CodePrimitiveExpression("Hello World!") );

            // Add the WriteLine call to the statement collection.
            start.Statements.Add(cs1);

            // Build another Console.WriteLine statement.
            CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
                csSystemConsoleType, "WriteLine",
                new CodePrimitiveExpression("Press the Enter key to continue.") );
            // Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2);

            // Build a call to System.Console.ReadLine.
            CodeMethodInvokeExpression csReadLine = new CodeMethodInvokeExpression(
                csSystemConsoleType, "ReadLine");

            // Add the ReadLine statement.
            start.Statements.Add(csReadLine);

            // Add the code entry point method to the Members
            // collection of the type.
            class1.Members.Add( start );

            return compileUnit;
        }

        public static String GenerateCode(CodeDomProvider provider, 
                                          CodeCompileUnit compileunit)
        {
            // Build the source file name with the language
            // extension (vb, cs, js).
            String sourceFile;
            if (provider.FileExtension[0] == '.')
            {
                sourceFile = "HelloWorld" + provider.FileExtension;
            }
            else 
            {
                sourceFile = "HelloWorld." + provider.FileExtension;
            }

            // Create a TextWriter to a StreamWriter to an output file.
            IndentedTextWriter tw = new IndentedTextWriter(new StreamWriter(sourceFile, false), "    ");
            // Generate source code using the code provider.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions());
            // Close the output file.
            tw.Close();            

            return sourceFile;
        }
    
        //<Snippet2>
        public static bool CompileCode(CodeDomProvider provider, 
            String sourceFile, 
            String exeFile)
        {

            CompilerParameters cp = new CompilerParameters();

            // Generate an executable instead of 
            // a class library.
            cp.GenerateExecutable = true;

            // Set the assembly file name to generate.
            cp.OutputAssembly = exeFile;

            // Generate debug information.
            cp.IncludeDebugInformation = true;

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add( "System.dll" );

            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Set the level at which the compiler 
            // should start displaying warnings.
            cp.WarningLevel = 3;

            // Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = false;
            
            // Set compiler argument to optimize output.
            cp.CompilerOptions = "/optimize";

            // Set a temporary files collection.
            // The TempFileCollection stores the temporary files
            // generated during a build in the current directory,
            // and does not delete them after compilation.
            cp.TempFiles = new TempFileCollection(".", true);

            if (provider.Supports(GeneratorSupport.EntryPointMethod))
            {
                // Specify the class that contains 
                // the main method of the executable.
                cp.MainClass = "Samples.Class1";
            }
  
            if (Directory.Exists("Resources"))
            {
                if (provider.Supports(GeneratorSupport.Resources))
                {
                    // Set the embedded resource file of the assembly.
                    // This is useful for culture-neutral resources,
                    // or default (fallback) resources.
                    cp.EmbeddedResources.Add("Resources\\Default.resources");

                    // Set the linked resource reference files of the assembly.
                    // These resources are included in separate assembly files,
                    // typically localized for a specific language and culture.
                    cp.LinkedResources.Add("Resources\\nb-no.resources");
                }
            }

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);

            if(cr.Errors.Count > 0)
            {
                // Display compilation errors.
                Console.WriteLine("Errors building {0} into {1}",  
                    sourceFile, cr.PathToAssembly);
                foreach(CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    sourceFile, cr.PathToAssembly);
                Console.WriteLine("{0} temporary files created during the compilation.",
                    cp.TempFiles.Count.ToString());

            }
          
            // Return the results of compilation.
            if (cr.Errors.Count > 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
        //</Snippet2>
 
        [STAThread]
        static void Main() 
        {
            CodeDomProvider provider = null;
            String exeName = "HelloWorld.exe";

            Console.WriteLine("Enter the source language for Hello World (cs, vb, etc):");
            String inputLang = Console.ReadLine();
            Console.WriteLine();

            if (CodeDomProvider.IsDefinedLanguage(inputLang))
            {
                provider = CodeDomProvider.CreateProvider(inputLang);
            }

            if (provider == null)
            {
                Console.WriteLine("There is no CodeDomProvider for the input language.");
            }
            else 
            {
                CodeCompileUnit helloWorld = BuildHelloWorldGraph();

                String sourceFile = GenerateCode(provider, helloWorld);

                Console.WriteLine("HelloWorld source code generated.");

                if (CompileCode(provider, sourceFile, exeName ))
                {
                    Console.WriteLine("Starting HelloWorld executable.");
                    Process.Start(exeName);            
                }
            }

        }
    }
}
//</Snippet1>
