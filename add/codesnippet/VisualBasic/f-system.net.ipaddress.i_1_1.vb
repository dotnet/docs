   ' This methods prints the value of the current host loopback address in  
   ' standard compressed format. 
   Private Shared Sub printIPv6LoopBackAddress()
      Try
         ' Get the loopback address.
         Dim loopBack As IPAddress = IPAddress.IPv6Loopback
         
         ' Transform the loop-back address to a string using the overloaded
         ' ToString() method. Note that the resulting string is in the compact 
         ' form: "::1".
         Dim ipv6LoopBack As String = loopBack.ToString()
         Console.WriteLine(("The IPv6 Loopback address is: " + ipv6LoopBack))
      Catch e As Exception
         Console.WriteLine(("[printIPv6LoopBackAddress] Exception: " + e.ToString()))
      End Try
   End Sub 'printIPv6LoopBackAddress
   