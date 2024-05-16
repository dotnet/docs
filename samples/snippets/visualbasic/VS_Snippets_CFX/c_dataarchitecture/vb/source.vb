Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Security.Permissions
Imports System.Security
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security.Tokens
Imports System.ServiceModel.Description

Namespace Samples
    Public Class Test
        Public Sub New()
            ' Do nothing.
        End Sub

        Public Sub Main()
            ' Do nothing. This is to satisfy the compiler's need for Sub Main.

        End Sub
    End Class

    '<snippet1>
    <ServiceContract()> _
    Public Interface IAirfareFinderService

        <OperationContract()> _
        Function FindAirfare(ByVal FromCity As String, _
        ByVal ToCity As String, ByRef IsDirectFlight As Boolean) As Integer

    End Interface
    '</snippet1>

    '<snippet2>
    Public Class AirfareRequestMessage
        Inherits Message

        Public fromCity As String = "Tokyo"
        Public toCity As String = "London"
        ' Code omitted…
        Protected Overrides Sub OnWriteBodyContents(ByVal w As XmlDictionaryWriter)
            w.WriteStartElement("airfareRequest")
            w.WriteElementString("from", fromCity)
            w.WriteElementString("to", toCity)
            w.WriteEndElement()
        End Sub

        Public Overrides ReadOnly Property Version() As MessageVersion
            Get
                Throw New NotImplementedException("The method is not implemented.")
            End Get
        End Property

        Public Overrides ReadOnly Property Properties() As MessageProperties
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Public Overrides ReadOnly Property Headers() As MessageHeaders
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property


        Public Overrides ReadOnly Property IsEmpty() As Boolean
            Get
                Return MyBase.IsEmpty
            End Get
        End Property

        Public Overrides ReadOnly Property IsFault() As Boolean
            Get
                Return MyBase.IsFault
            End Get
        End Property
    End Class
    '</snippet2>

    Public Interface Weather
        '<snippet3>
        <OperationContract()> Function GetCurrentTemperature() As Integer
        '</snippet3>

        '<snippet4>
        <OperationContract()> Sub SetDesiredTemperature(ByVal t As Integer)
        '</snippet4>

        '<snippet5>
        <OperationContract(IsOneWay:=True)> Sub SetLightbulb(ByVal isOn As Boolean)
        '</snippet5>
    End Interface

    '<snippet6>
    Public Class FileMessage
        Inherits Message
        ' Code not shown.
        '</snippet6>

        Sub New(ByVal someFileName As String)
            Throw New NotImplementedException()
        End Sub


        Public Overrides ReadOnly Property Version() As MessageVersion
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Public Overrides ReadOnly Property Properties() As MessageProperties
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Protected Overrides Sub OnWriteBodyContents(ByVal writer As XmlDictionaryWriter)
            Throw New Exception("The method or operation is not implemented.")
        End Sub

        Public Overrides ReadOnly Property Headers() As MessageHeaders
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Public Overrides ReadOnly Property IsEmpty() As Boolean

            Get
                Return MyBase.IsEmpty
            End Get
        End Property

        Public Overrides ReadOnly Property IsFault() As Boolean
            Get
                Return MyBase.IsFault
            End Get
        End Property
    End Class
    'Elsewhere in the code, a part of some service:

    Public Class SomeClass
        '<snippet7>
        <OperationContract()> Public Function GetFile() As FileMessage
            'code omitted…
            Dim fm As New FileMessage("myFile.xml")
            Return fm
        End Function
        '</snippet7>
    End Class

    '<snippet8>
    <ServiceContract()> _
    Public Interface IForwardingService
        <OperationContract(Action:="*")> Sub ForwardMessage(ByVal m As Message)
    End Interface
    '</snippet8>

    '<snippet9>
    <MessageContract(IsWrapped:=True, WrapperName:="Order")> _
    Public Class SubmitOrderMessage
        <MessageHeader()> Public customerID As String
        <MessageBodyMember()> Public item As String
        <MessageBodyMember()> Public quantity As Integer
    End Class

    '</snippet9>
    'Elsewhere in the code, a part of some service contract:
    Public Interface AnotherClass
        '<snippet10>
        <OperationContract()> Sub SubmitOrder(ByVal m As SubmitOrderMessage)
        '</snippet10>
    End Interface
    Public Interface three
        '<snippet11>
        <OperationContract()> _
        Sub SubmitOrder( _
            ByVal customerID As String, _
            ByVal item As String, _
            ByVal quantity As Integer)
        '</snippet11>
    End Interface
End Namespace
