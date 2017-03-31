// <Snippet1>
// <Snippet2>
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
		// Set the compiler to use Visual Basic.
		_compilerType = GetDefaultCompilerTypeForLanguage("C#");
	}

    // Return the internal CompilerType member 
    // defined in this implementation.
    public override CompilerType CodeCompilerType
    {
        get { return _compilerType; }
    }

    // Define a method that returns details for the 
    // code compiler for this build provider.
    public string GetCompilerTypeDetails()
    {
        StringBuilder details = new StringBuilder("");

        if (_compilerType != null)
        {
            // Format a string that contains the code compiler
            // implementation, and various compiler details.

            details.AppendFormat("CodeDomProvider type: {0}; \n",
                _compilerType.CodeDomProviderType.ToString());
            details.AppendFormat("Compiler debug build = {0}; \n",
                _compilerType.CompilerParameters.IncludeDebugInformation.ToString());
            details.AppendFormat("Compiler warning level = {0}; \n",
                _compilerType.CompilerParameters.WarningLevel.ToString());

            if (_compilerType.CompilerParameters.CompilerOptions != null)
            {
                details.AppendFormat("Compiler options: {0}; \n",
                    _compilerType.CompilerParameters.CompilerOptions.ToString());
            }
        }
        return details.ToString();
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
                provider.CreateGenerator().GenerateCodeFromCompileUnit(compileUnit, tw, null);
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
// </Snippet2>

// Define a class that generates a type using CodeDOM.
public class SampleClassGenerator
{
    private static string genNamespace = "HelloWorldSample";
    private static string genClassName = "HelloWorldClass";
    private static string genTypeName = genNamespace + "." + genClassName;

    // Define the public property that returns the type name.
    public static string TypeName
    {
        get { return genTypeName; }
    }

    // Build a Hello World program graph using System.CodeDom types.
    // For simplicity, this method builds a fixed code compile unit.
    // In most scenarios, this method would use the virtual path,
    // and build a code compile unit from the parsed file.

    public static CodeCompileUnit BuildCompileUnitFromPath(string virtualPath)
    {
        // Create a new CodeCompileUnit to contain the program graph
        CodeCompileUnit compileUnit = new CodeCompileUnit();

        // Declare the HelloWorldSample namespace.
        CodeNamespace helloNamespace = new CodeNamespace(genNamespace);
        // Add the new namespace to the compile unit.
        compileUnit.Namespaces.Add(helloNamespace);

        // Add the new namespace import for the System namespace.
        helloNamespace.Imports.Add(new CodeNamespaceImport("System"));

        // Declare a class named HelloWorldClass.
        CodeTypeDeclaration helloClass = new CodeTypeDeclaration(genClassName);

        // Add the HelloWorldClass to the namespace.
        helloNamespace.Types.Add(helloClass);

        // Declare the Main method of the class.
        CodeEntryPointMethod helloMain = new CodeEntryPointMethod();

        // Add the code entry point method to the Members
        // collection of the type.
        helloClass.Members.Add(helloMain);

        // Create a type reference for the System.Console class.
        CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");

        // Build Console.WriteLine("Hello World!").
        CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
            csSystemConsoleType, "WriteLine",
            new CodePrimitiveExpression("Hello World!"));

        // Add the WriteLine call to the statement collection.
        helloMain.Statements.Add(cs1);

        // Build another Console.WriteLine statement.
        CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
            csSystemConsoleType, "WriteLine",
            new CodePrimitiveExpression("Press the Enter key to continue."));

        // Add the new code statement.
        helloMain.Statements.Add(cs2);

        // Build a call to Console.ReadLine.
        CodeMethodInvokeExpression csReadLine = new CodeMethodInvokeExpression(
            csSystemConsoleType, "ReadLine");

        // Add the new code statement.
        helloMain.Statements.Add(csReadLine);

        return compileUnit;
    }
}

// Define a simple class that test methods on the other classes.
public class SampleTest
{
    public static void Main()
        {
            SampleBuildProvider mainTest = new SampleBuildProvider();
            Console.WriteLine(mainTest.GetCompilerTypeDetails());

            //AssemblyBuilder myBuilder = new AssemblyBuilder();
            //mainTest.GenerateCode(myBuilder);
        }
}
// </Snippet1>
