// <Snippet1>
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Resources.Tools;

public class Example
{
   public static void Main()
   {
      CreateResXFile();
      
      StreamWriter sw = new StreamWriter(@".\DemoResources.cs");
      string[] errors = null;
      CSharpCodeProvider provider = new CSharpCodeProvider();
      CodeCompileUnit code = StronglyTypedResourceBuilder.Create("Demo.resx", "DemoResources", 
                                                                 "DemoApp", provider, 
                                                                 false, out errors);    
      if (errors.Length > 0)
         foreach (var error in errors)
            Console.WriteLine(error); 

      provider.GenerateCodeFromCompileUnit(code, sw, new CodeGeneratorOptions());                                         
      sw.Close();
   }

   private static void CreateResXFile()
   {
      Bitmap logo = new Bitmap(@".\Logo.bmp");

      ResXResourceWriter rw = new ResXResourceWriter(@".\Demo.resx");
      rw.AddResource("Logo", logo); 
      rw.AddResource("AppTitle", "Demo Application");
      rw.Generate();
      rw.Close();
   }
}
// </Snippet1>