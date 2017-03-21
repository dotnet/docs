using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Security;
using System.Security.Permissions;

// Define a simple build provider implementation.
[PermissionSet(SecurityAction.Demand, Unrestricted = true)]
public class SampleBuildProvider : BuildProvider
{
    // Define an internal member for the compiler type.
    protected CompilerType _compilerType = null;

    public SampleBuildProvider()
    {
        _compilerType = GetDefaultCompilerTypeForLanguage("C#");
    }

    // Return the internal CompilerType member 
    // defined in this implementation.
    public override CompilerType CodeCompilerType
    {
        get { return _compilerType; }
    }


    // Define the build provider implementation of the GenerateCode method.
    public override void GenerateCode(AssemblyBuilder assemBuilder)
    {
        // Generate a code compile unit, and add it to
        // the assembly builder.

        TextWriter tw = assemBuilder.CreateCodeFile(this);
        if (tw != null)
        {
            try
            {
                // Generate the code compile unit from the virtual path.
                CodeCompileUnit compileUnit = SampleClassGenerator.BuildCompileUnitFromPath(VirtualPath);

                // Generate the source for the code compile unit, 
                // and write it to a file specified by the assembly builder.
                CodeDomProvider provider = assemBuilder.CodeDomProvider;
                provider.GenerateCodeFromCompileUnit(compileUnit, tw, null);
            }
            finally
            {
                tw.Close();
            }
        }
    }

    public override System.Type GetGeneratedType(CompilerResults results)
    {
        string typeName = SampleClassGenerator.TypeName;

        return results.CompiledAssembly.GetType(typeName);
    }
}