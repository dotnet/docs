using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Diagnostics.SymbolStore;

namespace ILGenServer
{
   public class CodeGenerator
   {
      ModuleBuilder myModuleBuilder ;
      AssemblyBuilder myAssemblyBuilder ;

      public CodeGenerator()
      {

         // Get the current application domain for the current thread.
         AppDomain currentDomain = AppDomain.CurrentDomain;
         AssemblyName myAssemblyName = new AssemblyName();
         myAssemblyName.Name = "TempAssembly";

         // Define a dynamic assembly in the current domain.
         myAssemblyBuilder =
            currentDomain.DefineDynamicAssembly
                        (myAssemblyName, AssemblyBuilderAccess.RunAndSave);
         // Define a dynamic module in "TempAssembly" assembly.
         myModuleBuilder =
            myAssemblyBuilder.DefineDynamicModule("TempModule","Resource.mod",true);

         // Define a document for source.on 'TempModule' module.
         ISymbolDocumentWriter myDocument =
         myModuleBuilder.DefineDocument("RTAsm.il", SymDocumentType.Text,
                  SymLanguageType.ILAssembly,SymLanguageVendor.Microsoft);

         Console.WriteLine("The object representing the defined document is:"+myDocument);

      }
   }
   public class CallerClass
   {
      public static void Main()
      {
         CodeGenerator myGenerator = new CodeGenerator();
      }
   }
}