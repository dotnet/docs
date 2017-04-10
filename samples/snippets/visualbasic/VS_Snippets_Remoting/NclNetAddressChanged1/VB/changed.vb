' <snippet1>
Imports System
Imports System.Net
Imports System.Net.NetworkInformation

Public Class NetworkingExample
    Public Shared Sub Main()
        AddHandler NetworkChange.NetworkAddressChanged, AddressOf AddressChangedCallback
        Console.WriteLine("Listening for address changes. Press any key to exit.")
        Console.ReadLine()
    End Sub 'Main
    Private Shared Sub AddressChangedCallback(ByVal sender As Object, ByVal e As EventArgs)

        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim n As NetworkInterface
        For Each n In adapters
            Console.WriteLine("   {0} is {1}", n.Name, n.OperationalStatus)
        Next n
    End Sub
End Class
' </snippet1>