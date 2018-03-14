
'This program checks if whether address entered by the user is a loopback address.  
'The program invokes the IPAddress.Parse method to translate the address 
'input string into the correct internal format.
'The IP address string must be in dotted-quad notation for IPv4 or in 
'colon-hexadecimal notation for IPv6. 


' <Snippet1>
Imports System
Imports System.Net
Imports System.Net.Sockets

 _

Class IsLoopbackTest
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   
   Overloads Private Shared Sub Main(args() As String)
      
       If args.Length = 1 Then
         ' No parameters entered. Display program usage.
         Console.WriteLine("Please enter an IP address.")
         Console.WriteLine("Usage:   >ipaddress_isloopback any IPv4 or IPv6 address.")
         Console.WriteLine("Example: >ipaddress_isloopback 127.0.0.1")
         Console.WriteLine("Example: >ipaddress_isloopback 0:0:0:0:0:0:0:1")
         Return
      ' Parse the address string entered by the user.
      Else
        parse(args(1))
      End If 
   End Sub 'Main
   
   
   ' This method calls the IPAddress.Parse method to check whether the 
   ' passed ipAddress parameter is in the correct format.
   ' Then it checks whether it represents a loopback address.
   ' Finally, it displays the results.
   Private Shared Sub parse(ipAdd As String)
      Dim loopBack As String = " is not a loopback address."
      
      Try
         ' Perform syntax check by parsing the address string entered by the user.
         Dim address As IPAddress = IPAddress.Parse(ipAdd)
         
         ' Perform semantic check by verifying that the address is a valid IPv4 
         ' or IPv6 loopback address. 
         If IPAddress.IsLoopback(address) And address.AddressFamily = AddressFamily.InterNetworkV6 Then
            loopBack = " is an IPv6 loopback address " + "whose internal format is: " + address.ToString() + "."
         Else
            If IPAddress.IsLoopback(address) And address.AddressFamily = AddressFamily.InterNetwork Then
               loopBack = " is an IPv4 loopback address " + "whose internal format is: " + address.ToString() + "."
            End If
         End If 
         ' Display the results.
         Console.WriteLine(("Your input address: " + """" + ipAdd + """" + loopBack))
      
      Catch e As FormatException
         Console.WriteLine("FormatException caught!!!")
         Console.WriteLine(("Source : " + e.Source))
         Console.WriteLine(("Message : " + e.Message))
      
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine(("Source : " + e.Source))
         Console.WriteLine(("Message : " + e.Message))
      End Try
   End Sub 'parse 
End Class 'IsLoopbackTest
' </Snippet1>