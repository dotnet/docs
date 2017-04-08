 '  <SNIPPET1>
Imports System
Imports System.Reflection
Imports System.Security.Policy
'Imports System.Data
 'for evidence object

Class ADMultiDomain
   
   ' The following attribute indicates to loader that multiple application 
   ' domains are used in this application.
   <LoaderOptimizationAttribute(LoaderOptimization.MultiDomainHost)>  _
   Public Shared Sub Main()
      ' Create application domain setup information for new application domain.
      Dim domaininfo As New AppDomainSetup()
      domaininfo.ApplicationBase = System.Environment.CurrentDirectory
      domaininfo.ApplicationName = "MyMultiDomain Application"
      
      'Create evidence for the new appdomain from evidence of current application domain.
      Dim adevidence As Evidence = AppDomain.CurrentDomain.Evidence
      
      ' Create appdomain.
      Dim newDomain As AppDomain = AppDomain.CreateDomain("MyMultiDomain", adevidence, domaininfo)
      
      'Load an assembly into the new application domain.
      Dim w As Worker = CType( _
         newDomain.CreateInstanceAndUnwrap( 
            GetType(Worker).Assembly().GetName().Name, "Worker"), 
            Worker) 
      w.TestLoad()
      
      'Unload the application domain, which also unloads the assembly.
      AppDomain.Unload(newDomain)
      
   End Sub 'Main
End Class 'ADMultiDomain

Class Worker
   Inherits MarshalByRefObject

   Friend Sub TestLoad()
      ' You must supply a valid assembly display name here.
      [Assembly].Load("Text assembly name, Culture, PublicKeyToken, Version")

      For Each assem As [Assembly] In AppDomain.CurrentDomain.GetAssemblies()
         Console.WriteLine(assem.FullName)
      Next
   End Sub
End Class
'  </SNIPPET1>