Imports System
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Collections.Generic
Imports System.Xml
Imports System.ServiceModel.Channels
Imports System.Security.Permissions


Namespace Samples
    
    Public Class Test
        
        Shared Sub Main() 
        
        End Sub
    End Class
    
    '<snippet1>
    <ServiceContract()>  _
    Public Interface IMyService
        <OperationContract()>  _
        Function GetData() As Message 
        
        <OperationContract()>  _
        Sub PutData(ByVal m As Message) 
    End Interface
    '</snippet1>
    
    '<snippet2>    
    Public Class MyService1
        Implements IMyService
        
        Public Function GetData() As Message _
         Implements IMyService.GetData
            Dim p As New Person()
            p.name = "John Doe"
            p.age = 42
            Dim ver As MessageVersion = _
              OperationContext.Current.IncomingMessageVersion
            Return Message.CreateMessage(ver, "GetDataResponse", p)

        End Function
        
        
        Public Sub PutData(ByVal m As Message) _
        Implements IMyService.PutData
            ' Not implemented.
        End Sub
    End Class
    <DataContract()>  _
    Public Class Person
        <DataMember()>  _
        Public name As String
        <DataMember()>  _
        Public age As Integer
    End Class
    '</snippet2>

    '<snippet3>    
    Public Class MyService2
        Implements IMyService
        
        Public Function GetData() As Message Implements IMyService.GetData
            Dim stream As New FileStream("myfile.xml", FileMode.Open)
            Dim xdr As XmlDictionaryReader = _
            XmlDictionaryReader.CreateTextReader(stream, New XmlDictionaryReaderQuotas())
            Dim ver As MessageVersion = OperationContext.Current.IncomingMessageVersion
            Return Message.CreateMessage(ver, "GetDataResponse", xdr)

        End Function
        
        
        Public Sub PutData(ByVal m As Message) Implements IMyService.PutData

        End Sub
    End Class
    '</snippet3>

    '<snippet4>
    Public Class MyService3
        Implements IMyService

        Public Function GetData() As Message Implements IMyService.GetData
            Dim fc As New FaultCode("Receiver")
            Dim ver As MessageVersion = OperationContext.Current.IncomingMessageVersion
            Return Message.CreateMessage(ver, fc, "Bad data", "GetDataResponse")

        End Function


        Public Sub PutData(ByVal m As Message) Implements IMyService.PutData

        End Sub
    End Class
    '</snippet4>

    '<snippet5>    
    Public Class MyService4
        Implements IMyService
        
        Public Sub PutData(ByVal m As Message) Implements IMyService.PutData
            Dim stream As New FileStream("myfile.xml", FileMode.Create)
            Dim xdw As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(stream)
            m.WriteBodyContents(xdw)
            xdw.Flush()

        End Sub
        
        
        Public Function GetData() As Message Implements IMyService.GetData
            Throw New NotImplementedException()

        End Function
    End Class
    '</snippet5>

    '<snippet6>
    Public Class MyService5
        Implements IMyService

        Public Sub PutData(ByVal m As Message) Implements IMyService.PutData
            Dim p As Person = m.GetBody(Of Person)()
            Console.WriteLine(p.name)

        End Sub


        Public Function GetData() As Message Implements IMyService.GetData
            Throw New NotImplementedException()

        End Function
    End Class
End Namespace
Namespace Samples2
    <ServiceContract()>  _
    Public Interface IMyService
        <OperationContract()>  _
        Function GetData() As Message 
        
        <OperationContract()>  _
        Sub PutData(ByVal m As Message) 
    End Interface

    <DataContract()>  _
    Public Class Person
        <DataMember()>  _
        Public name As String
        <DataMember()>  _
        Public age As Integer
    End Class
    '</snippet6>

    '<snippet7>
    <ServiceContract()>  _
    Public Class ForwardingService
        Private forwardingAddresses As List(Of IOutputChannel)

        <OperationContract()> _
        Public Sub ForwardMessage(ByVal m As Message)
            'Copy the message to a buffer.
            Dim mb As MessageBuffer = m.CreateBufferedCopy(65536)

            'Forward to multiple recipients.
            Dim channel As IOutputChannel
            For Each channel In forwardingAddresses
                Dim copy As Message = mb.CreateMessage()
                channel.Send(copy)
            Next channel

            'Log to a file.
            Dim stream As New FileStream("log.xml", FileMode.Append)
            mb.WriteMessage(stream)
            stream.Flush()

        End Sub
    End Class
    '</snippet7>

    '<snippet8>
    Public Class MyService6
        Implements IMyService

        Public Sub PutData(ByVal m As Message) Implements IMyService.PutData
            Dim mhi As MessageHeaderInfo
            For Each mhi In m.Headers
                Console.WriteLine(mhi.Name)
            Next mhi

        End Sub


        Public Function GetData() As Message Implements IMyService.GetData
            Throw New NotImplementedException()

        End Function
    End Class
    '</snippet8>

    '<snippet9>
    Public Class RandomMessage
        Inherits Message

        Protected Overrides Sub OnWriteBodyContents( _
                ByVal writer As XmlDictionaryWriter)
            Dim r As New Random()
            Dim i As Integer
            For i = 0 To 99999
                writer.WriteStartElement("number")
                writer.WriteValue(r.Next(1, 20))
                writer.WriteEndElement()
            Next i

        End Sub
        ' Code omitted.

        '</snippet9>

        '<snippet10>
        Public Overrides ReadOnly Property Headers() As MessageHeaders
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Public Overrides ReadOnly Property Properties() As MessageProperties
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Public Overrides ReadOnly Property Version() As MessageVersion
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
    End Class
    
    Public Class RandomMessage2
        Inherits Message
        
        Protected Overrides Function OnGetReaderAtBodyContents() As XmlDictionaryReader 
            Return New RandomNumbersXmlReader()
        
        End Function
        
        
        Protected Overrides Sub OnWriteBodyContents(ByVal writer As XmlDictionaryWriter) 
            Dim xdr As XmlDictionaryReader = OnGetReaderAtBodyContents()
            writer.WriteNode(xdr, True)
        
        End Sub
        
        Public Overrides ReadOnly Property Headers() As MessageHeaders 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property Properties() As MessageProperties 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property Version() As MessageVersion 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
    End Class
    
    Public Class RandomNumbersXmlReader
        Inherits XmlDictionaryReader
        'code to serve up 100000 random numbers in XML form omitted
        '</snippet10>
        
        Public Overrides ReadOnly Property AttributeCount() As Integer 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property BaseURI() As String 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
         
        Public Overrides Sub Close() 
            Throw New Exception("The method or operation is not implemented.")
        
        End Sub
        
        
        Public Overrides ReadOnly Property Depth() As Integer 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property EOF() As Boolean 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
         
        Overloads Public Overrides Function GetAttribute(ByVal i As Integer) As String 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Overloads Public Overrides Function GetAttribute(ByVal name As String, ByVal namespaceURI As String) As String 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Overloads Public Overrides Function GetAttribute(ByVal name As String) As String 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Public Overrides ReadOnly Property HasValue() As Boolean 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property IsEmptyElement() As Boolean 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property LocalName() As String 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
         
        Public Overrides Function LookupNamespace(ByVal prefix As String) As String 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Overloads Public Overrides Function MoveToAttribute(ByVal name As String, ByVal ns As String) As Boolean 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Overloads Public Overrides Function MoveToAttribute(ByVal name As String) As Boolean 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Public Overrides Function MoveToElement() As Boolean 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Public Overrides Function MoveToFirstAttribute() As Boolean 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Public Overrides Function MoveToNextAttribute() As Boolean 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Public Overrides ReadOnly Property NameTable() As XmlNameTable 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property NamespaceURI() As String 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property NodeType() As XmlNodeType 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property 
        
        Public Overrides ReadOnly Property Prefix() As String 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
         
        Public Overrides Function Read() As Boolean 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Public Overrides Function ReadAttributeValue() As Boolean 
            Throw New Exception("The method or operation is not implemented.")
        
        End Function
        
        
        Public Overrides ReadOnly Property ReadState() As ReadState 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
         
        Public Overrides Sub ResolveEntity() 
            Throw New Exception("The method or operation is not implemented.")
        
        End Sub
        
        
        Public Overrides ReadOnly Property Value() As String 
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
    End Class
End Namespace