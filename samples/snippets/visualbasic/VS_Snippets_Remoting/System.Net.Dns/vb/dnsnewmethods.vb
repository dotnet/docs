Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports Microsoft.VisualBasic

Namespace DnsNew

    Class DnsChanges
    
        Public Shared Sub Main()

            Dim myDns As New DnsChanges()

            Dim hostName As String = "www.contoso.com"

            myDns.DoGetHostEntry(hostName)
            myDns.DoGetHostEntry(IPAddress.Parse("127.0.0.1"))
            myDns.DoGetHostAddresses(hostName)

        End Sub 'Main
        

    ' <Snippet1>
        Public Sub DoGetHostEntry(hostName As String)

            Dim host as IPHostEntry = Dns.GetHostEntry(hostname)

            Console.WriteLine($"GetHostEntry({hostname}) returns:")

            Dim addresses As IPAddress() = host.AddressList

            Dim index As Integer
            For index = 0 To addresses.Length - 1
                Console.WriteLine($"    {addresses(index)}")
            Next index

        End Sub
    ' </Snippet1>

    ' <Snippet3>
        Public Sub DoGetHostAddresses(hostName As String)

            Dim addresses As IPAddress() = Dns.GetHostAddresses(hostname)

            Console.WriteLine($"GetHostAddresses({hostname}) returns:")

            Dim index As Integer
            For index = 0 To addresses.Length - 1
                Console.WriteLine($"    {addresses(index)}")
            Next index

        End Sub
    ' </Snippet3>

    ' <Snippet4>
        Public Sub DoGetHostEntry(address As IPAddress)

            Dim host as IPHostEntry = Dns.GetHostEntry(address)

            Console.WriteLine($"GetHostEntry({address}) returns HostName: {host.HostName}")

        End Sub
    ' </Snippet4>

    ' <Snippet2>
        ' Signals when the resolve has finished.
        Dim Shared GetHostEntryFinished As ManualResetEvent = New ManualResetEvent(False)

        ' Define the state object for the callback. 
        ' Use hostName to correlate calls with the proper result.
        Class ResolveState
            
            Dim hostName As String
            Dim resolvedIPs As IPHostEntry

            Public Sub New(host As String)
                hostName = host
            End Sub

            Public Property IPs AS IPHostEntry
                Get
                    Return resolvedIPs
                End Get
                Set
                    resolvedIPs = value
                End Set
            End Property

            Public Property host As String
                Get
                    Return hostName
                End Get
                Set
                    hostName = value
                End Set
            End Property

        End Class

        ' Record the IPs in the state object for later use.
        Shared Sub GetHostEntryCallback(ar As IAsyncResult)

            Dim ioContext As ResolveState = ar.AsyncState

            ioContext.IPs = Dns.EndGetHostEntry(ar)
            GetHostEntryFinished.Set()

        End Sub

        ' Determine the Internet Protocol (IP) addresses for 
        ' this host asynchronously.
        Shared Sub DoGetHostEntryAsync(hostname As String)
            
            GetHostEntryFinished.Reset()
            Dim ioContext As ResolveState = New ResolveState(hostname)

            Dns.BeginGetHostEntry(ioContext.host,AddressOf GetHostEntryCallback, ioContext)

            ' Wait here until the resolve completes (the callback 
            ' calls .Set())
            GetHostEntryFinished.WaitOne()

            Console.WriteLine($"EndGetHostEntry({ioContext.host}) returns:")

            Dim addresses As IPAddress() = ioContext.IPs.AddressList

            Dim index As Integer
            For index = 0 To addresses.Length - 1
                Console.WriteLine($"    {addresses(index)}")
            Next index

        End Sub
    ' </Snippet2>

    End Class

End Namespace
