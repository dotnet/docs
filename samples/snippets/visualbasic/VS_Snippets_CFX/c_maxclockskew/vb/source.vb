Imports System.ServiceModel
Imports System.Security.Permissions
'Imports System.Runtime.Serialization
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
'Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel.Security.Tokens

Namespace Examples

    Public Class Program

        Shared Sub Main()

            Dim p As Program = New Program()
            p.Run()

        End Sub

        '<snippet1>
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

        '</snippet1>

        Private Sub PrintValue(ByVal b As Binding)
            Dim bec As BindingElementCollection = b.CreateBindingElements()
            Dim sbe As SymmetricSecurityBindingElement = CType(bec.Find(Of SecurityBindingElement)(), SymmetricSecurityBindingElement)
            Console.WriteLine("skew {0}", sbe.LocalServiceSettings.MaxClockSkew.ToString())
            Dim secureTokenParams As SecureConversationSecurityTokenParameters = _
                CType(sbe.ProtectionTokenParameters, SecureConversationSecurityTokenParameters)
            Dim bootstrap As SecurityBindingElement = secureTokenParams.BootstrapSecurityBindingElement
            Console.WriteLine("skew 2 {0}", bootstrap.LocalServiceSettings.MaxClockSkew.ToString())

        End Sub



    End Class

    <ServiceContract()> _
    Public Interface ICalculator
        <OperationContract()> _
        Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
    End Interface


    Public Class Calculator
        Implements ICalculator

        Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICalculator.Add

            Return a + b
        End Function

    End Class
End Namespace
