//<Snippet1>
using System;
using System.CodeDom;

namespace CodeDomSamples
{
    public class CodeNamespaceImportExample
    {
        public CodeNamespaceImportExample()
        {
            //<Snippet2>
            // Declares a compile unit to contain a namespace.
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            // Declares a namespace named TestNamespace.
            CodeNamespace testNamespace = new CodeNamespace("TestNamespace");
            // Adds the namespace to the namespace collection of the compile unit.
            compileUnit.Namespaces.Add(testNamespace);

            // Declares a namespace import of the System namespace.
            CodeNamespaceImport import1 = new CodeNamespaceImport("System");
            // Adds the namespace import to the namespace imports collection of the namespace.
            testNamespace.Imports.Add(import1);
            
            // A C# code generator produces the following source code for the preceeding example code:
            
            //    namespace TestNamespace {        
            //        using System;
            //
            //  }

            //</Snippet2>
        }
    }
}
//</Snippet1>