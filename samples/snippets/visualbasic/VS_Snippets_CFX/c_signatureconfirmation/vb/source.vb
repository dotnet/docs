Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Security.Tokens
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Text

Public Class Test

    '<snippet1>
    Private Function CreateBinding() As Binding
        Dim bindings As New BindingElementCollection()
        Dim tokens As New KerberosSecurityTokenParameters()

        Dim security As New SymmetricSecurityBindingElement(tokens)

        ' Require that every request and return be correlated.
        security.RequireSignatureConfirmation = True

        bindings.Add(security)
        Dim encoding As New TextMessageEncodingBindingElement()
        bindings.Add(encoding)
        Dim transport As New HttpTransportBindingElement()
        bindings.Add(transport)
        Dim myBinding As New CustomBinding(bindings)
        Return myBinding
    End Function
    '</snippet1>

    Private Sub Create()
        '<snippet2>
        Dim sec As SymmetricSecurityBindingElement = CType(SecurityBindingElement.CreateMutualCertificateBindingElement(), SymmetricSecurityBindingElement)
        '</snippet2>

    End Sub

    Shared Sub Main()

    End Sub
End Class
