' <snippet1>
Imports System.ServiceModel
Imports System.Threading

Namespace Microsoft.WCF.Documentation
    <ServiceContract(Name:="SampleHello", Namespace:="http://microsoft.wcf.documentation")> _
    Public Interface IHello
        <OperationContract> _
        Function Hello(ByVal greeting As String) As String
    End Interface

    Public Class HelloService
        Implements IHello

        Public Sub New()
            Console.WriteLine("Service object created: " & Me.GetHashCode().ToString())
        End Sub

        Protected Overrides Sub Finalize()
            Console.WriteLine("Service object destroyed: " & Me.GetHashCode().ToString())
        End Sub

        <OperationBehavior(Impersonation:=ImpersonationOption.Required)> _
        Public Function Hello(ByVal greeting As String) As String Implements IHello.Hello
            Console.WriteLine("Called by: " & Thread.CurrentPrincipal.Identity.Name)
            Console.WriteLine("IsAuthenticated: " & Thread.CurrentPrincipal.Identity.IsAuthenticated.ToString())
            Console.WriteLine("AuthenticationType: " & Thread.CurrentPrincipal.Identity.AuthenticationType.ToString())

            Console.WriteLine("Caller sent: " & greeting)
            Console.WriteLine("Sending back: Hi, " & Thread.CurrentPrincipal.Identity.Name)
            Return "Hi, " & Thread.CurrentPrincipal.Identity.Name
        End Function
    End Class
End Namespace
' </snippet1>
