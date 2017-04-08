using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.CodeDom;
using System.CodeDom.Compiler;

// System.Xml.Serialization.Advanced.SchemaImporterExtension
public class Test
{
   static void Main()
   {
      Console.WriteLine("started");
   }
}

// Replace MyFakeAbstract with System.Xml.Serialization.Advanced.SchemaImporterExtension
// when it becomes integrated into Main. This fake class is only to get the
// implementation to compile.

public abstract class MyFakeAbstract
{
        public virtual string ImportSchemaType(string name, string ns, XmlSchemaObject context, XmlSchemas schemas, XmlSchemaImporter importer, 
            CodeCompileUnit compileUnit, CodeNamespace mainNamespace, CodeGenerationOptions options, CodeDomProvider codeProvider) {
            return null;
        }
}



public class MyExtension: MyFakeAbstract
{
//<snippet1>
public override string ImportSchemaType(string name, string ns, 
    XmlSchemaObject context, XmlSchemas schemas, 
    XmlSchemaImporter importer, 
    CodeCompileUnit compileUnit, CodeNamespace codeNamespace, 
    CodeGenerationOptions options, CodeDomProvider codeGenerator)
    {
        if (name.Equals("Order") && ns.Equals("http://orders/"))
        {
            compileUnit.ReferencedAssemblies.Add("Order.dll");
            codeNamespace.Imports.Add
               (new CodeNamespaceImport("Microsoft.Samples"));
             return "Order";
        }
        return null;
    }
//</snippet1>
}
