Option Strict On
Option Explicit On

Imports System
Imports System.Security.Policy

Module Test

   Sub Main()
      ' <Snippet1>
      ' Set up the AppDomainSetup
      Dim setup As New AppDomainSetup()
      setup.ApplicationBase = "(some directory)"
      setup.ConfigurationFile = "(some file)"
      
      ' Set up the Evidence
      Dim baseEvidence As Evidence = AppDomain.CurrentDomain.Evidence
      Dim evidence As New Evidence(baseEvidence)
      evidence.AddAssembly("(some assembly)")
      evidence.AddHost("(some host)")
      
      ' Create the AppDomain
      Dim newDomain As AppDomain = AppDomain.CreateDomain("newDomain", evidence, setup)
      ' </Snippet1>
   End Sub 'Main

End Module 'Test