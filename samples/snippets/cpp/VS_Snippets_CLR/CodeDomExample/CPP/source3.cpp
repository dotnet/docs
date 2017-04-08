//<snippet20>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace Microsoft::CSharp;

class Example
{
public:
    static void Main()
    {
        String^ sourcefile;
        String^ exefile;

        CodeCompileUnit^ codeUnit = gcnew CodeCompileUnit();
        sourcefile = GenerateCSharpCode(codeUnit);
        exefile = sourcefile->Substring(0, sourcefile->LastIndexOf('.')) + ".exe";
        Console::WriteLine("outfile: {0}", exefile);
        CompileCSharpCode(sourcefile, exefile);
    }

//<snippet22>
public:
    static String^ GenerateCSharpCode(CodeCompileUnit^ compileunit)
    {
        // Generate the code with the C# code provider.
        //<snippet21>
        CSharpCodeProvider^ provider = gcnew CSharpCodeProvider();
        //</snippet21>

        // Build the output file name.
        String^ sourceFile;
        if (provider->FileExtension[0] == '.')
        {
           sourceFile = "HelloWorld" + provider->FileExtension;
        }
        else
        {
           sourceFile = "HelloWorld." + provider->FileExtension;
        }

        // Create a TextWriter to a StreamWriter to the output file.
        StreamWriter^ sw = gcnew StreamWriter(sourceFile, false);
        IndentedTextWriter^ tw = gcnew IndentedTextWriter(sw, "    ");

            // Generate source code using namespace the code provider.
        provider->GenerateCodeFromCompileUnit(compileunit, tw,
            gcnew CodeGeneratorOptions());

        // Close the output file.
        tw->Close();
        sw->Close();

        return sourceFile;
    }
//</snippet22>

//<snippet23>
public:
    static bool CompileCSharpCode(String^ sourceFile, String^ exeFile)
    {
        CSharpCodeProvider^ provider = gcnew CSharpCodeProvider();

        // Build the parameters for source compilation.
        CompilerParameters^ cp = gcnew CompilerParameters();

        // Add an assembly reference.
        cp->ReferencedAssemblies->Add( "System.dll" );

        // Generate an executable instead of
        // a class library.
        cp->GenerateExecutable = true;

        // Set the assembly file name to generate.
        cp->OutputAssembly = exeFile;

        // Save the assembly as a physical file.
        cp->GenerateInMemory = false;

        // Invoke compilation.
        CompilerResults^ cr = provider->CompileAssemblyFromFile(cp, sourceFile);

       if (cr->Errors->Count > 0)
       {
           // Display compilation errors.
            Console::WriteLine("Errors building {0} into {1}",
                sourceFile, cr->PathToAssembly);
            for each (CompilerError^ ce in cr->Errors)
            {
                Console::WriteLine("  {0}", ce->ToString());
                Console::WriteLine();
            }
        }
        else
        {
            Console::WriteLine("Source {0} built into {1} successfully.",
                sourceFile, cr->PathToAssembly);
        }

        // Return the results of compilation.
        if (cr->Errors->Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //</snippet23>
};

int main()
{
    Example::Main();
}
//</snippet20>
