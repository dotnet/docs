Imports System.Net.NetworkInformation

Namespace My

  Partial Class MyComputer
    Friend ReadOnly Property DnsServerIPAddresses() As IPAddressCollection
      Get
        Dim dnsAddressList As IPAddressCollection = Nothing

        For Each adapter In System.Net.NetworkInformation.
          NetworkInterface.GetAllNetworkInterfaces()

          Dim adapterProperties = adapter.GetIPProperties()
          Dim dnsServers As IPAddressCollection = adapterProperties.DnsAddresses
          If dnsAddressList Is Nothing Then
            dnsAddressList = dnsServers
          Else
            dnsAddressList.Union(dnsServers)
          End If
        Next adapter

        Return dnsAddressList
      End Get
    End Property
  End Class

End Namespace