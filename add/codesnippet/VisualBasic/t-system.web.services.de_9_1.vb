      Dim myDisplay As [String]
      ' Read wsdl file.
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read(myWSDLFileName)
      
      Dim myServiceDescriptionImporter As New ServiceDescriptionImporter()
      
      ' Add 'myServiceDescription' to 'myServiceDescriptionImporter'.
      myServiceDescriptionImporter.AddServiceDescription(myServiceDescription, "", "")
      
      myServiceDescriptionImporter.ProtocolName = "HttpGet"
      Dim myCodeNamespace As New CodeNamespace()
      Dim myCodeCompileUnit As New CodeCompileUnit()
      
      ' Invoke 'Import' method.
      Dim myWarning As ServiceDescriptionImportWarnings = myServiceDescriptionImporter.Import(myCodeNamespace, myCodeCompileUnit)
      
      Select Case myWarning
         Case ServiceDescriptionImportWarnings.NoCodeGenerated
            myDisplay = "NoCodeGenerated"
         Case ServiceDescriptionImportWarnings.NoMethodsGenerated
            myDisplay = "NoMethodsGenerated"
         Case ServiceDescriptionImportWarnings.UnsupportedOperationsIgnored
            myDisplay = "UnsupportedOperationsIgnored"
         Case ServiceDescriptionImportWarnings.OptionalExtensionsIgnored
            myDisplay = "OptionalExtensionsIgnored"
         Case ServiceDescriptionImportWarnings.RequiredExtensionsIgnored
            myDisplay = "RequiredExtensionsIgnored"
         Case ServiceDescriptionImportWarnings.UnsupportedBindingsIgnored
            myDisplay = "UnsupportedBindingsIgnored"
         Case Else
            myDisplay = "General Warning"
      End Select
      Console.WriteLine("Warning : " + myDisplay)