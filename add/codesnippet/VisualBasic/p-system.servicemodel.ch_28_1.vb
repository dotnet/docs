        ' This method returns a custom binding created from a WSHttpBinding. Alter the method 
        ' to use the appropriate binding for your service, with the appropriate settings.
        Public Shared Function CreateCustomBinding(ByVal clockSkew As TimeSpan) As Binding

            Dim standardBinding As WSHttpBinding = New WSHttpBinding(SecurityMode.Message, True)
            Dim myCustomBinding As CustomBinding = New CustomBinding(standardBinding)
            Dim security As SymmetricSecurityBindingElement = _
                myCustomBinding.Elements.Find(Of SymmetricSecurityBindingElement)()
            security.LocalClientSettings.MaxClockSkew = clockSkew
            security.LocalServiceSettings.MaxClockSkew = clockSkew
            ' Get the System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters 
            Dim secureTokenParams As SecureConversationSecurityTokenParameters = _
                 CType(security.ProtectionTokenParameters, SecureConversationSecurityTokenParameters)
            ' From the collection, get the bootstrap element.
            Dim bootstrap As SecurityBindingElement = secureTokenParams.BootstrapSecurityBindingElement
            ' Set the MaxClockSkew on the bootstrap element.
            bootstrap.LocalClientSettings.MaxClockSkew = clockSkew
            bootstrap.LocalServiceSettings.MaxClockSkew = clockSkew
            Return myCustomBinding
        End Function

        Private Sub Run()

            ' Create a custom binding using the method defined above. The MaxClockSkew is set to 30 minutes. 
            Dim customBinding As Binding = CreateCustomBinding(TimeSpan.FromMinutes(30))

            ' Create a ServiceHost instance, and add a metadata endpoint.
            ' NOTE  When using Visual Studio, you must run as administrator.
            Dim baseUri As New Uri("http://localhost:1008/")
            Dim sh As New ServiceHost(GetType(Calculator), baseUri)

            ' Optional. Add a metadata endpoint. The method is defined below.
            AddMetadataEndpoint(sh)

            ' Add an endpoint using the binding, and open the service.
            sh.AddServiceEndpoint(GetType(ICalculator), customBinding, "myCalculator")

            sh.Open()
            Console.WriteLine("Listening...")
            Console.ReadLine()
        End Sub

        Private Sub AddMetadataEndpoint(ByRef sh As ServiceHost)

            Dim mex As New Uri("http://localhost:1011/metadata/")
            Dim sm As New ServiceMetadataBehavior()
            sm.HttpGetEnabled = True
            sm.HttpGetUrl = mex
            sh.Description.Behaviors.Add(sm)
        End Sub
