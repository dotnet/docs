' <SNIPPET1>
Imports System
Imports System.Reflection
Imports System.Security.Policy

Class ADGetAssemblies
   
   
   Public Shared Sub Main()
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      'Provide the current application domain evidence for the assembly.
      Dim asEvidence As Evidence = currentDomain.Evidence
      'Load the assembly from the application directory using a simple name.
     
      'Create an assembly called CustomLibrary to run this sample.
      currentDomain.Load("CustomLibrary", asEvidence)
      
      'Make an array for the list of assemblies.
      Dim assems As [Assembly]() = currentDomain.GetAssemblies()
      
      'List the assemblies in the current application domain.
      Console.WriteLine("List of assemblies loaded in current appdomain:")
      Dim assem As [Assembly]
      For Each assem In  assems
         Console.WriteLine(assem.ToString())
      Next assem
   End Sub 'Main 
End Class 'ADGetAssemblies 
' </SNIPPET1>