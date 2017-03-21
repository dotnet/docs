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