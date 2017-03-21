   ' This function prints the value of the current host's Any address in  
   ' standard compressed format. The Any address is used by the host to enable
   ' listening to client activities on all the interfaces for a given port.
   Private Shared Sub printIPv6AnyAddress()
      Try
         ' Get the Any address.
         Dim any As IPAddress = IPAddress.IPv6Any
         
         ' Transform the Any address to a string using the overladed
         ' ToString() method. Note that the resulting string is in the compact 
         ' form: "::".
         Dim ipv6Any As String = any.ToString()
         
         ' Display the Any address.
         Console.WriteLine(("The IPv6 Any address is: " + ipv6Any))
      Catch e As Exception
         Console.WriteLine(("[printIPv6AnyAddress] Exception: " + e.ToString()))
      End Try
   End Sub 'printIPv6AnyAddress
   