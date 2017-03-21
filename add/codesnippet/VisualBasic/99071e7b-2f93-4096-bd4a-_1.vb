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
            
        Public Property host As [String]
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

        Console.WriteLine("EndGetHostEntry(" + ioContext.host + ") returns:")

        Dim ip As IPAddress() = ioContext.IPs.AddressList
        Dim index As Integer
        For index = 0 To ip.Length - 1
            Console.WriteLine(ip(index))
        Next index
          
    End Sub
  