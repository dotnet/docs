//<Snippet1>
using System;
using System.Management; 
using System.CodeDom;
using System.IO;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace ManagementSample
{
    class GenerateCSharpCode
    {
        static void Main(string[] args)
        {
    
            string strFilePath = "C:\\temp\\LogicalDisk.cs";
            CodeTypeDeclaration ClsDom;
    
            ManagementClass cls1 = 
                new ManagementClass(null,"Win32_LogicalDisk",null);
            ClsDom = cls1.GetStronglyTypedClassCode(false,false);
    
            ICodeGenerator cg = 
                (new CSharpCodeProvider()).CreateGenerator ();
            CodeNamespace cn = new CodeNamespace("TestNamespace");
    
            // Add any imports to the code
            cn.Imports.Add(
                new CodeNamespaceImport("System"));
            cn.Imports.Add(
                new CodeNamespaceImport("System.ComponentModel"));
            cn.Imports.Add(
                new CodeNamespaceImport("System.Management"));
            cn.Imports.Add(
                new CodeNamespaceImport("System.Collections"));
   
            // Add class to the namespace
            cn.Types.Add (ClsDom);
    
            // Now create the filestream (output file)
            TextWriter tw = new StreamWriter(new
                FileStream (strFilePath,FileMode.Create));
    
            // And write it to the file
            cg.GenerateCodeFromNamespace(
                cn, tw, new CodeGeneratorOptions());

            tw.Close();
        }
    }
}
//</Snippet1>