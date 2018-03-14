 '
'   This program demonstrates the  'Loopback' and 'Broadcast' field of 'IPAddress' class.
'   It prints the loopback IP address 127.0.0.1 and Broadcast IP address 255.255.255.255
'


Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Class LoopbackBroadcastSample
    
    Public Shared Sub Main()
        Dim loopbackBroadcastSampleObj As New LoopbackBroadcastSample()
        loopbackBroadcastSampleObj.PrintLoopbackAddress()
        loopbackBroadcastSampleObj.PrintBroadcastAddress()
    End Sub 'Main
    
    
' <Snippet1>
    Public Sub PrintLoopbackAddress()
        ' Gets the IP loopback address and converts it to a string.
        Dim IpAddressString As [String] = IPAddress.Loopback.ToString()
        Console.WriteLine(("Loopback IP address : " + IpAddressString))
    End Sub 'PrintLoopbackAddress
' </Snippet1>	

' <Snippet2>	
    Public Sub PrintBroadcastAddress()
        ' gets the IP Broadcast address and convert it to string.
        Dim IpAddressString As [String] = IPAddress.Broadcast.ToString()
        Console.WriteLine((ControlChars.Cr + "Broadcast IP address : " + IpAddressString))
    End Sub 'PrintBroadcastAddress
' </Snippet2>	

End Class 'LoopbackBroadcastSample 
