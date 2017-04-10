'<Snippet1>
Imports System
Imports System.Security.Permissions
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports System.Text
Imports System.Web.Services.Configuration
Imports System.Web.Services.Description
Imports System.Xml.Serialization
Imports System.CodeDom

' The YMLAttribute allows a developer to specify that the YML SOAP
' extension run on a per-method basis.  The disabled property
' turns reversing the XML on and off. 

<AttributeUsage(AttributeTargets.Method, AllowMultiple:=False)> _
Public Class YMLAttribute
    Inherits SoapExtensionAttribute
    Dim _priority As Integer = 0
    Dim _disabled As Boolean = False

    Public Sub New()
        Me.New(False)
    End Sub

    Public Sub New(ByVal Disabled As Boolean)
        _disabled = Disabled
    End Sub

    Public Overrides ReadOnly Property ExtensionType() As Type
        Get
            Return GetType(YMLExtension)
        End Get
    End Property

    Public Overrides Property Priority() As Integer
        Get
            Return _priority
        End Get
        Set(ByVal Value As Integer)
            _priority = Value
        End Set
    End Property

    Public Property Disabled() As Boolean
        Get
            Return _disabled
        End Get
        Set(ByVal Value As Boolean)
            _disabled = Value
        End Set
    End Property
End Class

Public Class YMLExtension
    Inherits SoapExtension
    Dim _disabled As Boolean = False
    Dim oldStream As Stream
    Dim newStream As Stream

    Public Overloads Overrides Function GetInitializer( _
        ByVal methodInfo As LogicalMethodInfo, _
        ByVal attribute As SoapExtensionAttribute) As Object

        Dim attr As YMLAttribute = attribute
        If (Not attr Is Nothing) Then
            Return attr.Disabled
        End If
        Return False
    End Function

    Public Overloads Overrides Function GetInitializer( _
        ByVal WebServiceType As Type) As Object
        Return False
    End Function

    Public Overrides Sub Initialize(ByVal initializer As Object)
        If (TypeOf initializer Is Boolean) Then
            _disabled = CBool(initializer)
        End If
    End Sub

    Public Overrides Function ChainStream(ByVal streamref As Stream) As Stream
        If (_disabled) Then
            Return CType(Me, SoapExtension).ChainStream(streamref)
        End If
        oldStream = streamref
        newStream = New MemoryStream()
        Return newStream
    End Function

    Public Overrides Sub ProcessMessage(ByVal message As SoapMessage)
        If (_disabled) Then Return
        Select Case (message.Stage)
            Case SoapMessageStage.BeforeSerialize
                Encode(message)
            Case SoapMessageStage.AfterSerialize
                newStream.Position = 0
                Reverse(newStream, oldStream)
            Case SoapMessageStage.BeforeDeserialize
                Decode(message)
            Case SoapMessageStage.AfterDeserialize
        End Select
    End Sub

    Sub Encode(ByRef message As SoapMessage)
        message.ContentType = "text/yml"
    End Sub

    Sub Decode(ByVal message As SoapMessage)
        If (message.ContentType <> "text/yml") Then
            Throw New Exception("invalid content type:" & message.ContentType)
        End If
        Reverse(oldStream, newStream)
        newStream.Position = 0
        message.ContentType = "text/xml"
    End Sub

    Sub Reverse(ByVal source As Stream, ByVal dest As Stream)
        Dim reader As TextReader = New StreamReader(source)
        Dim writer As TextWriter = New StreamWriter(dest)
        Dim line As String
        line = reader.ReadLine()
        While (Not line Is Nothing)
            writer.WriteLine(StrReverse(line))
            line = reader.ReadLine()
        End While
        writer.Flush()
    End Sub
End Class


' The YMLReflector class is part of the YML SDFE, as it is
' called during the service description generation process.
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class YMLReflector
    Inherits SoapExtensionReflector
    Public Overrides Sub ReflectMethod()
        Dim reflector As ProtocolReflector = ReflectionContext
        Dim attr As YMLAttribute = _
            reflector.Method.GetCustomAttribute(GetType(YMLAttribute))
        ' If the YMLAttribute has been applied to this XML Web service 
        ' method, add the XML defined in the YMLOperationBinding class.
        If (Not attr Is Nothing) Then
            Dim yml As YMLOperationBinding = New YMLOperationBinding()
            yml.Reverse = Not attr.Disabled
            reflector.OperationBinding.Extensions.Add(yml)
        End If
    End Sub
End Class

' The YMLImporter class is part of the YML SDFE, as it is called when a
' proxy class is generated for each XML Web service method the proxy class
' communicates with. The class checks whether the service description
' contains the XML that this SDFE adds to a service description. If it 
' exists, then the YMLExtension is applied to the method in the proxy class.
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class YMLImporter
    Inherits SoapExtensionImporter
    Public Overrides Sub ImportMethod( _
        ByVal metadata As CodeAttributeDeclarationCollection)
        Dim importer As SoapProtocolImporter = ImportContext
        ' Check whether the XML specified in the YMLOperationBinding is 
        ' in the service description.
        Dim yml As YMLOperationBinding = _
            importer.OperationBinding.Extensions.Find( _
            GetType(YMLOperationBinding))
        If (Not yml Is Nothing) Then
            ' Only apply the YMLAttribute to the method when the XML 
            ' should be reversed.
            If (yml.Reverse) Then
                Dim attr As CodeAttributeDeclaration = _
                    New CodeAttributeDeclaration(GetType(YMLAttribute).FullName)
                attr.Arguments.Add( _
                    New CodeAttributeArgument(New CodePrimitiveExpression(True)))
                metadata.Add(attr)
            End If
        End If
    End Sub
End Class

'<Snippet2>
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
'</Snippet2>
'</Snippet1>

