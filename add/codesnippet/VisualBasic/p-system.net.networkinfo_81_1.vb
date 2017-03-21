    Public Shared Sub ShowIcmpV6BigPacketData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine(" Too Big Packet ........................ Sent: {0,-10}   Received: {1,-10}", statistics.PacketTooBigMessagesSent, statistics.PacketTooBigMessagesReceived)
    
    End Sub 'ShowIcmpV6BigPacketData
    
    