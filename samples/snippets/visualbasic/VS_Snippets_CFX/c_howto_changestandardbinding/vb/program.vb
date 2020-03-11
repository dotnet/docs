'<snippet0>


Imports System.ServiceModel
Imports System.ServiceModel.Channels

Namespace Samples
    Friend Class ChangeStandardBinding
        Shared Sub Main(ByVal args() As String)
            '<snippet1>
            '  Create an instance of the T:System.ServiceModel.BasicHttpBinding 
            '  class and set its security mode to message-level security.
            Dim binding As New BasicHttpBinding()
            With binding.Security
                .Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate
                .Mode = BasicHttpSecurityMode.Message
            End With
            '</snippet1>

            '<snippet2>
            '  Create a custom binding from the binding 
            Dim cb As New CustomBinding(binding)
            '  Get the BindingElementCollection from this custom binding 
            Dim bec = cb.Elements
            '</snippet2>

            '<snippet3>
            '  Loop through the collection, and when you find the HTTP binding element
            '  set its KeepAliveEnabled property to false
            For Each be In bec
                Dim thisType = be.GetType()
                Console.WriteLine(thisType)
                If TypeOf be Is HttpTransportBindingElement Then
                    Dim httpElement As HttpTransportBindingElement = CType(be, HttpTransportBindingElement)
                    Console.WriteLine(Constants.vbTab & "Before: HttpTransportBindingElement.KeepAliveEnabled = {0}", httpElement.KeepAliveEnabled)
                    httpElement.KeepAliveEnabled = False
                    Console.WriteLine(vbTab & "After:  HttpTransportBindingElement.KeepAliveEnabled = {0}", httpElement.KeepAliveEnabled)
                End If
            Next be
            '</snippet3>

        End Sub
    End Class
End Namespace
'</snippet0>
