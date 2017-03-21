' The YMLOperationBinding class is part of the YML SDFE, as it is the
' class that is serialized into XML and is placed in the service
' description.
<XmlFormatExtension("action", YMLOperationBinding.YMLNamespace, _
    GetType(OperationBinding)), _
    XmlFormatExtensionPrefix("yml", YMLOperationBinding.YMLNamespace)> _
Public Class YMLOperationBinding
    Inherits ServiceDescriptionFormatExtension
    Private _reverse As Boolean
    Public Const YMLNamespace As String = "http://www.contoso.com/yml"

    <XmlElement("Reverse")> _
    Public Property Reverse() As Boolean
        Get
            Return _reverse
        End Get
        Set(ByVal Value As Boolean)
            _reverse = Value
        End Set
    End Property

End Class