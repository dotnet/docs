    Public Shared Sub ShowIcmpV6MembershipData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Queries .............................. Sent: {0,-10}   Received: {1,-10}", statistics.MembershipQueriesSent, statistics.MembershipQueriesReceived)
        Console.WriteLine("  Reductions ........................... Sent: {0,-10}   Received: {1,-10}", statistics.MembershipReductionsSent, statistics.MembershipReductionsReceived)
        Console.WriteLine("  Reports .............................. Sent: {0,-10}   Received: {1,-10}", statistics.MembershipReportsSent, statistics.MembershipReportsReceived)
    
    End Sub 'ShowIcmpV6MembershipData
    
    