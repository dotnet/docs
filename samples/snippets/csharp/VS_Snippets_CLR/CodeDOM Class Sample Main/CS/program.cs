//<Snippet1>
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;

namespace SampleCodeDom
{
    class Sample
    {
        CodeCompileUnit targetUnit;
        CodeTypeDeclaration targetClass;
        private const string outputFileName = "SampleCode.cs";
        static void Main(string[] args)
        {
        }
    }
}
//</Snippet1>
