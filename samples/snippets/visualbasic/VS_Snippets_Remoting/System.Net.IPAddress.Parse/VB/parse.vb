

' <Snippet1>
Imports System
Imports System.Net



Class ParseAddress
   
   'Entry point which delegates to C-style main Private Function
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   
   Overloads Private Shared Sub Main(args() As String)
      Dim IPaddress As String
      
      If args.Length = 1 Then
         Console.WriteLine("Please enter an IP address.")
         Console.WriteLine("Usage:   >cs_parse any IPv4 or IPv6 address.")
         Console.WriteLine("Example: >cs_parse 127.0.0.1")
         Console.WriteLine("Example: >cs_parse 0:0:0:0:0:0:0:1")
         Return
      Else
         IPaddress = args(1)
      End If 
      ' Get the list of the IPv6 addresses associated with the requested host.
      parse(IPaddress)
   End Sub 'Main
    
   
   ' This method calls the IPAddress.Parse method to check the ipAddress 
   ' input string. If the ipAddress argument represents a syntatical correct IPv4 or
   ' IPv6 address, the method displays the Parse output into quad-notation or
   ' colon-hexadecimal notation, respectively. Otherwise, it displays an 
   ' error message.
   Private Shared Sub parse(ipAddr As String)
      Try
         ' Create an instance of IPAddress for the specified address string (in 
         ' dotted-quad, or colon-hexadecimal notation).
         Dim address As IPAddress = IPAddress.Parse(ipAddr)
         
         ' Display the address in standard notation.
         Console.WriteLine(("Parsing your input string: " + """" + ipAddr + """" + " produces this address (shown in its standard notation): " + address.ToString()))
      
      Catch e As ArgumentNullException
         Console.WriteLine("ArgumentNullException caught!!!")
         Console.WriteLine(("Source : " + e.Source))
         Console.WriteLine(("Message : " + e.Message))
      
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
End Class 'ParseAddress
' </Snippet1>