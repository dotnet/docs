
Imports System
Imports System.Net
Imports Microsoft.VisualBasic

Class IpAddressSample
    
    Public Shared Sub Main()
        Try
            Dim IpAddressString As [String] = ""
            Console.Write("Type an IP address (press Enter for default, default is '64.14.132.100') : ")
            IpAddressString = Console.ReadLine()
            If IpAddressString.Length <= 0 Then
                IpAddressString = "64.14.132.100"
            End If
            Dim IpAddressSampleObj As New IpAddressSample()
            IpAddressSampleObj.PrintAddressFamily(IpAddressString)
            IpAddressSampleObj.PrintAddress(IpAddressString)
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 

'<Snippet1>    

    Public Sub PrintAddressFamily(IpAddressString As [String])
        ' Creates an instance of IPAddress for the specified IP string in dotted-quad notation.
        Dim hostIPAddress As IPAddress = IPAddress.Parse(IpAddressString)
        Console.WriteLine((ControlChars.Cr + "IP address family : " + hostIPAddress.AddressFamily.ToString()))
    End Sub 'PrintAddressFamily

 '</Snippet1>   

 '<Snippet2>   

    Public Sub PrintAddress(IpAddressString As [String])
        ' Creates an instance of the IPAddress' for the specified IP string in dotted-quad notation.
        Dim hostIPAddress As IPAddress = IPAddress.Parse(IpAddressString)
        Console.WriteLine(ControlChars.Cr + "The IP address '" + IpAddressString + "' is {0}", hostIPAddress.ToString())
    End Sub 'PrintAddressFamily

 '</Snippet2>   
	 
End Class 'IpAddressSample 
