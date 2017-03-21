    Public Shared Sub ShowAddressMaskData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Address Mask Requests ............... Sent: {0,-10}   Received: {1,-10}", statistics.AddressMaskRequestsSent, statistics.AddressMaskRequestsReceived)
        Console.WriteLine("  Address Mask Replies ................ Sent: {0,-10}   Received: {1,-10}", statistics.AddressMaskRepliesSent, statistics.AddressMaskRepliesReceived)
    
    End Sub 'ShowAddressMaskData
    
    