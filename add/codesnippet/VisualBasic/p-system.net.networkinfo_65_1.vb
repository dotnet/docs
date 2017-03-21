    Public Shared Sub ShowInterfaceSpeedAndQueue() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim stats As IPv4InterfaceStatistics = adapter.GetIPv4Statistics()
            Console.WriteLine(adapter.Description)
            Console.WriteLine("     Speed .................................: {0}", adapter.Speed)
            Console.WriteLine("     Output queue length....................: {0}", stats.OutputQueueLength)
        Next adapter
    
    End Sub 'ShowInterfaceSpeedAndQueue
    