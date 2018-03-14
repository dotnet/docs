Imports System
Imports System.Net
Imports System.Net.Sockets

 _

Class IPv6Adresses
   
   ' Entry point which delegates to C-style main Private Function
  Public Overloads Shared Sub Main()
    Main(System.Environment.GetCommandLineArgs())
  End Sub

   ' <Snippet1>
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
   
   ' </Snippet1>
   ' <Snippet2>
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
   
   ' </Snippet2>
   ' <Snippet3>
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
   
   ' </Snippet3>
   ' <Snippet4>
   ' This function checks whether the passed string represents a loop-back address.
   Private Shared Sub checkIPv6LoopBackAddress(ipAdd As String)
      Try
         ' Parse the passed string to obtain the internal address
         ' representation.
         Dim loopBack As IPAddress = IPAddress.Parse(ipAdd)
         
         ' Verify that the address is a loopback address.
         Dim isLoopBack As Boolean = IPAddress.IsLoopback(loopBack)
         
         ' Build the message.
         Dim msg As String
         If isLoopBack Then
            msg = " is a loop back address."
         Else
            msg = " is not a loop back address."
         End If 
         ' Display the results.
         Console.WriteLine((ipAdd + msg))
      Catch e As Exception
         Console.WriteLine(("[printIPv6LoopBackAddress] Exception: " + e.ToString()))
      End Try
   End Sub 'checkIPv6LoopBackAddress
   
   ' </Snippet4>
   Overloads Private Shared Sub Main(args() As String)
  
      ' Verify that the current host supports IPv6 and also call WSAStartup. 
      ' If you do not use any IPv6 methods that call WSAStartup, you will get a 
      ' SocketException when using IPv6Loopback, IPv6Any or IPv6None. 
      Dim ipv6Supported As Boolean = Socket.SupportsIPv6
      
      ' Display the current host's Loopback address.
      printIPv6LoopBackAddress()
      
      ' Display the current host's Any address.
      printIPv6AnyAddress()
      
      ' Display the current host's  None address.
      printIPv6NoneAddress()
      
      ' Check that this is a loopback address.
      checkIPv6LoopBackAddress("0::1")
   End Sub 'Main 
End Class 'IPv6Adresses