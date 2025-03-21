//<snippet20>
using System;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

class Example
{
    public static void Main()
    {
        string sourcefile;
        string exefile;

        CodeCompileUnit codeUnit = new CodeCompileUnit();
        sourcefile = GenerateCSharpCode(codeUnit);
        exefile = sourcefile.Substring(0, sourcefile.LastIndexOf('.')) + ".exe";
        Console.WriteLine($"outfile: {exefile}");
        CompileCSharpCode(sourcefile, exefile);
    }

    //<snippet22>
    public static string GenerateCSharpCode(CodeCompileUnit compileunit)
    {
        // Generate the code with the C# code provider.
        //<snippet21>
        CSharpCodeProvider provider = new CSharpCodeProvider();
        //</snippet21>

        // Build the output file name.
        string sourceFile;
        if (provider.FileExtension[0] == '.')
        {
           sourceFile = "HelloWorld" + provider.FileExtension;
        }
        else
        {
           sourceFile = "HelloWorld." + provider.FileExtension;
        }

        // Create a TextWriter to a StreamWriter to the output file.
        using (StreamWriter sw = new StreamWriter(sourceFile, false))
        {
            IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

            // Generate source code using the code provider.
            provider.GenerateCodeFromCompileUnit(compileunit, tw,
                new CodeGeneratorOptions());

            // Close the output file.
            tw.Close();
        }

        return sourceFile;
    }
    //</snippet22>

    //<snippet23>
    public static bool CompileCSharpCode(string sourceFile, string exeFile)
    {
        CSharpCodeProvider provider = new CSharpCodeProvider();

        // Build the parameters for source compilation.
        CompilerParameters cp = new CompilerParameters();

        // Add an assembly reference.
        cp.ReferencedAssemblies.Add( "System.dll" );

        // Generate an executable instead of
        // a class library.
        cp.GenerateExecutable = true;

        // Set the assembly file name to generate.
        cp.OutputAssembly = exeFile;

        // Save the assembly as a physical file.
        cp.GenerateInMemory = false;

        // Invoke compilation.
        CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);

       if (cr.Errors.Count > 0)
       {
           // Display compilation errors.
            Console.WriteLine($"Errors building {sourceFile} into {cr.PathToAssembly}");
            foreach (CompilerError ce in cr.Errors)
            {
                Console.WriteLine("  {0}", ce.ToString());
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Source {sourceFile} built into {cr.PathToAssembly} successfully.");
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
    //</snippet23>
}
//</snippet20>
