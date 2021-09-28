//<Snippet11>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;

public class CodeDOMSample
{
    public static void Main()
    {
        string sourceFile;
        int dotSpot;

        CodeCompileUnit cu = new CodeCompileUnit();
        sourceFile = GenerateCSharpCode(cu);
        Console.WriteLine("CS source file: {0}", sourceFile);
        dotSpot = sourceFile.IndexOf('.');
        CompileCSharpCode(sourceFile, sourceFile.Substring(0, dotSpot) + ".exe");
    }

    // <snippet13>
    public static string GenerateCSharpCode(CodeCompileUnit compileunit)
    {
        // Generate the code with the C# code provider.
        // <snippet12>
        CSharpCodeProvider provider = new CSharpCodeProvider();
        // </snippet12>

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
        IndentedTextWriter tw = new IndentedTextWriter(
                new StreamWriter(sourceFile, false), "    ");

        // Generate source code using the code provider.
        provider.GenerateCodeFromCompileUnit(compileunit, tw,
               new CodeGeneratorOptions());

        // Close the output file.
        tw.Close();

        return sourceFile;
    }
    // </snippet13>

    // <snippet14>
    public static bool CompileCSharpCode(string sourceFile,
        string exeFile)
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
    // </snippet14>
}
//</Snippet11>
