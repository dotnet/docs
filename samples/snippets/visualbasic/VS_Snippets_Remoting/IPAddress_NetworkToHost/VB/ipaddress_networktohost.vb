'
'   This program demonstrates 'NetworkToHostOrder(short)', 'NetworkToHostOrder(int)' and 
'   'NetworkToHostOrder(long)' methods of 'IPAddress' class.
'   It takes a string from commandline for each of above cases and convert it to the corresponding
'   primitive type(i.e. short,int,long) value. Alternatively it uses default values for each cases.
'   Then these values are converted from  network byte order to host byte order by  calling the 
'   overloaded 'NetworkToHostOrder' methods of 'IPAddress' class. 
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Class NetworkToHostByteSample
    
    Public Shared Sub Main()
        Try
            Dim networkByteShort As Short = 4365
            Dim networkByteInt As Integer = 286064640
            Dim networkByteLong As Long = 1228638273342013440
            Dim networkByteString As [String] = ""
            
            Dim networkToHostByteSampleObj As New NetworkToHostByteSample()
            
            Console.Write("'Program converts Network byte order to Host byte order for short, int and long values'")
            Console.Write(ControlChars.Cr + "Enter a short value for Convertion(press Enter for default, default is '4365') : ")
            networkByteString = Console.ReadLine()
            If networkByteString.Length > 0 Then
                networkByteShort = Convert.ToInt16(networkByteString)
            End If
            networkToHostByteSampleObj.NetworkToHostOrder_Short(networkByteShort)
            
            networkByteString = ""
            Console.Write(ControlChars.Cr + "Enter an Integer value for Convertion(press Enter for default, default is '286064640') : ")
            networkByteString = Console.ReadLine()
            If networkByteString.Length > 0 Then
                networkByteInt = Convert.ToInt32(networkByteString)
            End If
            networkToHostByteSampleObj.NetworkToHostOrder_Integer(networkByteInt)
            
            networkByteString = ""
            Console.Write(ControlChars.Cr + "Enter a long value for Convertion(press Enter for default, default is '1228638273342013440') : ")
            networkByteString = Console.ReadLine()
            If networkByteString.Length > 0 Then
                networkByteLong = Convert.ToInt64(networkByteString)
            End If
            networkToHostByteSampleObj.NetworkToHostOrder_Long(networkByteLong)
        Catch e As FormatException
            Console.WriteLine("FormatException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 'Main
    
    
' <Snippet1>	
    Public Sub NetworkToHostOrder_Short(networkByte As Short)
        Dim hostByte As Short
        ' Converts a short value from network byte order to host byte order.
        hostByte = IPAddress.NetworkToHostOrder(networkByte)
        Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte)
    End Sub 'NetworkToHostOrder_Short    
' </Snippet1>	

' <Snippet2>	
    Public Sub NetworkToHostOrder_Integer(networkByte As Integer)
        Dim hostByte As Integer
        ' Converts an integer value from network byte order to host byte order.
        hostByte = IPAddress.NetworkToHostOrder(networkByte)
        Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte)
    End Sub 'NetworkToHostOrder_Integer
' </Snippet2>	    

' <Snippet3>	
    Public Sub NetworkToHostOrder_Long(networkByte As Long)
        Dim hostByte As Long
        ' Converts a long value from network byte order to host byte order.
        hostByte = IPAddress.NetworkToHostOrder(networkByte)
        Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte)
    End Sub 'NetworkToHostOrder_Long
' </Snippet3>	
End Class 'NetworkToHostByteSample 