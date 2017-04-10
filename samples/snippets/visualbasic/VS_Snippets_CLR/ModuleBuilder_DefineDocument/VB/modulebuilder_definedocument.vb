' System.Reflection.Emit.ModuleBuilder.DefineDocument

' The following example demonstrates the 'DefineDocument' method
' of 'ModuleBuilder' class.
' A dynamic assembly with a module in it is created in 'CodeGenerator' class.
' It gets the object representing the defined document using the method
' 'DefineDocument'.
' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Resources
Imports System.Diagnostics.SymbolStore

Namespace ILGenServer

   Public Class CodeGenerator
      Private myModuleBuilder As ModuleBuilder
      Private myAssemblyBuilder As AssemblyBuilder

      Public Sub New()

         ' Get the current application domain for the current thread.
         Dim currentDomain As AppDomain = AppDomain.CurrentDomain
         Dim myAssemblyName As New AssemblyName()
         myAssemblyName.Name = "TempAssembly"

         ' Define a dynamic assembly in the current domain.
         myAssemblyBuilder = currentDomain.DefineDynamicAssembly(myAssemblyName, _
                                                         AssemblyBuilderAccess.RunAndSave)
         ' Define a dynamic module in "TempAssembly" assembly.
         myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule", "Resource.mod", True)

         ' Define a document for source.on 'TempModule' module.
         Dim myDocument As ISymbolDocumentWriter = myModuleBuilder.DefineDocument("RTAsm.il", _
                     SymDocumentType.Text, SymLanguageType.ILAssembly, SymLanguageVendor.Microsoft)
         Console.WriteLine("The object representing the defined document is:" + _
                                                             CObj(myDocument).ToString())

      End Sub 'New
   End Class 'CodeGenerator

   Public Class CallerClass

      Public Shared Sub Main()
         Dim myGenerator As New CodeGenerator()
      End Sub 'Main
   End Class 'CallerClass
End Namespace 'ILGenServer
' </Snippet1>