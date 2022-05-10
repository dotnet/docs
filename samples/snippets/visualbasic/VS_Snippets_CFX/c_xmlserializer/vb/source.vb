Imports System.ServiceModel
Imports System.Security.Permissions
Imports System.Runtime.Serialization
Imports System.ServiceModel.Description
Imports System.Xml.Serialization
Imports UsingXml1

Namespace UsingXml1

    Public Class Test

        Shared Sub Main()

        End Sub
    End Class

    '<snippet1>
    <ServiceContract(), XmlSerializerFormat()> _
    Public Class BankingService
        <OperationContract()> _
        Public Sub ProcessTransaction(ByVal bt As BankingTransaction)
            ' Code not shown.
        End Sub
    End Class


    ' BankingTransaction is not a data contract class,
    ' but is an XmlSerializer-compatible class instead.

    Public Class BankingTransaction
        <XmlAttribute()> _
        Public Operation As String
        <XmlElement()> _
        Public fromAccount As Account
        <XmlElement()> _
        Public toAccount As Account
        <XmlElement()> _
        Public amount As Integer
    End Class
    'Notice that the Account class must also be XmlSerializer-compatible.
    '</snippet1>

    Public Class Account
        Public AcctNumber As String
    End Class


    '<snippet2>
    <DataContract()> _
    Public Class Customer
        <DataMember()> _
        Public firstName As String
        <DataMember()> _
        Public lastName As String
        Public creditCardNumber As String
    End Class
    '</snippet2>
End Namespace

Namespace UsingXml2

    '<snippet3>
    <ServiceContract(), XmlSerializerFormat()> _
    Public Class BankingService
        <OperationContract()> _
        Public Sub ProcessTransaction(ByVal bt As BankingTransaction)
            'Code not shown.
        End Sub
    End Class

    <MessageContract()> _
    Public Class BankingTransaction
        <MessageHeader()> _
        Public Operation As String
        <XmlElement(), MessageBodyMember()> _
        Public fromAccount As Account
        <XmlElement(), MessageBodyMember()> _
        Public toAccount As Account
        <XmlAttribute(), MessageBodyMember()> _
        Public amount As Integer
    End Class
    '</snippet3>
End Namespace

Namespace UsingXml3

    '<snippet4>
    <MessageContract()> _
    Public Class BankingTransaction
        <MessageHeader()> _
        Public Operation As String

        'This element will be <fromAcct> and not <from>:
        <XmlElement(ElementName:="fromAcct"), _
            MessageBodyMember(Name:="from")> _
        Public fromAccount As Account

        <XmlElement(), MessageBodyMember()> _
        Public toAccount As Account

        <XmlAttribute(), MessageBodyMember()> _
        Public amount As Integer
    End Class
    '</snippet4>
End Namespace
