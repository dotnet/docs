   ' This function prints the value of the current host's None address in  
   ' standard compressed format. The None address is used by the host to disable
   ' listening to client activities on all the interfaces.
   Private Shared Sub printIPv6NoneAddress()
      Try
         
         ' Get the None address.
         Dim none As IPAddress = IPAddress.IPv6None
         
         ' Transform the None address to a string using the overloaded
         ' ToString() method. Note that the resulting string is in the compact 
         ' form: "::".
         Dim ipv6None As String = none.ToString()
         
         Console.WriteLine(("The IPv6 None address is: " + ipv6None))
      Catch e As Exception
         Console.WriteLine(("[printIPv6NoneAddress] Exception: " + e.ToString()))
      End Try
   End Sub 'printIPv6NoneAddress
   