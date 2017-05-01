//<Snippet11>
#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::IO;
using namespace Microsoft::CSharp;

public ref class CodeDOMSample
{
public:
    static void Main()
    {
        String^ sourceFile;
        int dotSpot;

        CodeCompileUnit^ cu = gcnew CodeCompileUnit();
        sourceFile = GenerateCSharpCode(cu);
        Console::WriteLine("CS source file: {0}", sourceFile);
        dotSpot = sourceFile->IndexOf('.');
        CompileCSharpCode(sourceFile, sourceFile->Substring(0, dotSpot) + ".exe");
    }

    // <snippet13>
    static String^ GenerateCSharpCode(CodeCompileUnit^ compileunit)
    {
        // Generate the code with the C# code provider.
        // <snippet12>
        CSharpCodeProvider^ provider = gcnew CSharpCodeProvider();
        // </snippet12>

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
        IndentedTextWriter^ tw = gcnew IndentedTextWriter(
                gcnew StreamWriter(sourceFile, false), "    ");

        // Generate source code using the code provider.
        provider->GenerateCodeFromCompileUnit(compileunit, tw,
               gcnew CodeGeneratorOptions());

        // Close the output file.
        tw->Close();

        return sourceFile;
    }
    // </snippet13>

    // <snippet14>
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
    // </snippet14>
};

int main()
{
    CodeDOMSample::Main();
}
//</Snippet11>
