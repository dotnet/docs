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
            ManagementClass cls1 = new ManagementClass(
                null, "Win32_LogicalDisk",null);
            cls1.GetStronglyTypedClassCode(
                CodeLanguage.CSharp,
                "C:\\temp\\Logicaldisk.cs",
                String.Empty);
        }
    }
}
//</Snippet1>