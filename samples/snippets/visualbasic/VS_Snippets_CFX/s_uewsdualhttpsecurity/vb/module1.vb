
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security
Imports System.Runtime.Serialization

Namespace CS
    Module Module1
        ' from http://blogs.msdn.com/drnick/archive/2006/07/19/670789.aspx
        Private Sub WSDualHttpMain()
            ' <Snippet1>
            Dim binding As New WSDualHttpBinding()
            ' </Snippet1>


            ' <Snippet2>
            Dim configName As String = "string"
            Dim bindingString As New WSDualHttpBinding(configName)
            ' </Snippet2>

            ' <Snippet3>
            Dim bindingSecurityMode As New WSDualHttpBinding(WSDualHttpSecurityMode.Message)
            ' </Snippet3>

            ' <Snippet8>
            Dim dualBinding As New WSDualHttpBinding()
            Dim endptadr As New EndpointAddress("http://localhost:12000/DuplexTestUsingCode/Server")
            dualBinding.ClientBaseAddress = New Uri("http://localhost:8000/DuplexTestUsingCode/Client/")

            ' </Snippet8>

            ' <Snippet9>
            ' Set to StrongWildCard
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            ' </Snippet9>

            ' <Snippet10>
            binding.MaxBufferPoolSize = 900000
            ' </Snippet10>

            ' <Snippet11>
            binding.MessageEncoding = WSMessageEncoding.Mtom
            ' </Snippet11>

            ' <Snippet12>
            Dim proxyAddressString As String = "http://localhost:5049"
            Dim proxyBaseAddressUri As New Uri(proxyAddressString)
            binding.ProxyAddress = proxyBaseAddressUri
            ' </Snippet12>

            ' <Snippet13>
            Dim readerQuotas As XmlDictionaryReaderQuotas = binding.ReaderQuotas
            ' </Snippet13>

            ' <Snippet14>
            Dim reliableSession As ReliableSession = binding.ReliableSession
            ' </Snippet14>

            ' <Snippet15>
            Dim scheme As String = binding.Scheme
            ' </Snippet15>

            ' <Snippet16>
            Dim security As WSDualHttpSecurity = binding.Security
            ' </Snippet16>

            ' <Snippet17>
            Dim bindingEncoding As Encoding = binding.TextEncoding
            ' </Snippet17>

            ' <Snippet18>
            binding.TransactionFlow = True
            ' </Snippet18>

            ' <Snippet19>
            binding.UseDefaultWebProxy = True
            ' </Snippet19>

            ' <Snippet20>
            Dim bec As BindingElementCollection = binding.CreateBindingElements()
            ' </Snippet20>

            ' <Snippet21>
            Dim envelopeversion As EnvelopeVersion = binding.EnvelopeVersion
            ' </Snippet21>

            ' <Snippet22>
            Dim maxReceivedMessageSize = binding.MaxReceivedMessageSize
            ' </Snippet22>




            binding.Security.Mode = WSDualHttpSecurityMode.None
            '<snippet30>
            Dim binding3 As New WSDualHttpBinding()
            binding3.Security.Mode = WSDualHttpSecurityMode.None
            binding3.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Basic256
            binding3.MessageEncoding = WSMessageEncoding.Mtom
            '</snippet30>

            ' <Snippet6>
            Dim BypassProxyOnLocalBinding As New WSDualHttpBinding()
            BypassProxyOnLocalBinding.BypassProxyOnLocal = True
            ' <//Snippet6>

        End Sub
        Sub Main(ByVal args() As String)
            ' <Snippet24>
            Dim tcb As New TcpChunkingBinding()
            Dim isSynchronous As Boolean = tcb.ReceiveSynchronously
            ' </Snippet24>
        End Sub
    End Module

    ' <Snippet23>
    Public Class TcpChunkingBinding
        Implements IBindingRuntimePreferences
        ' </Snippet23>

        Public Sub New()
            MyBase.New()
            Initialize()
        End Sub
        
       
        Public Property MaxBufferedChunks() As Integer
            
            Get
                Return 0
            End Get
            
            Set(ByVal value As Integer)
            End Set
        End Property

        Private Sub Initialize()
           
        End Sub

#Region "IBindingRuntimePreferences Members"

        Public ReadOnly Property ReceiveSynchronously() As Boolean Implements IBindingRuntimePreferences.ReceiveSynchronously
            Get
                Return True
            End Get
        End Property

#End Region
    End Class

    '    
    '     //<snippet134>
    '      <client>
    '        <endpoint 
    '          name ="ServerEndpoint" 
    '          address="http://localhost:12000/DuplexUsingConfig/Server"
    '          bindingConfiguration="WSDualHttpBinding_IDuplex" 
    '          binding="wsDualHttpBinding"
    '          contract="IDuplex" 
    '      />
    '      </client>
    '      <bindings>
    '        <wsDualHttpBinding>
    '          <binding 
    '            name="WSDualHttpBinding_IDuplex"  
    '            clientBaseAddress="http://localhost:8000/myClient/" 
    '          />
    '        </wsDualHttpBinding>
    '      </bindings>
    '     //</snippet134>
    '    
End Namespace
