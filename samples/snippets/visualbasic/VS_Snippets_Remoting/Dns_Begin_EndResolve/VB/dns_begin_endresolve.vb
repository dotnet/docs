 '
'   This program demonstrates 'BeginResolve' and 'EndResolve' methods of Dns class.
'   It obtains the 'IPHostEntry' object by calling 'BeginResolve' and 'EndResolve' method 
'   of 'Dns' class by passing a URL, a callback function and an instance of 'RequestState'
'   class.Then prints host name, IP address list and aliases.         
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic



' <Snippet1>
' <Snippet2>
Class DnsBeginGetHostByName
    
    Class RequestState
        Public host As IPHostEntry
        
        Public Sub New()
            host = Nothing
        End Sub 'New
    End Class 'RequestState
    
    
    Public Shared Sub Main()
     Try
        ' Create an instance of the RequestState class.
        Dim myRequestState As New RequestState()
        
        ' Begin an asynchronous request for information such as the host name, IP addresses, 
        ' or aliases for the specified URI.
        Dim asyncResult As IAsyncResult = CType(Dns.BeginResolve("www.contoso.com", AddressOf RespCallback, myRequestState),IAsyncResult)

        ' Wait until asynchronous call completes.
        While asyncResult.IsCompleted <> True
        End While
        
        Console.WriteLine(("Host name : " + myRequestState.host.HostName))
        Console.WriteLine(ControlChars.Cr + "IP address list : ")
        Dim index As Integer
        For index = 0 To myRequestState.host.AddressList.Length - 1
            Console.WriteLine(myRequestState.host.AddressList(index))
        Next index
        Console.WriteLine(ControlChars.Cr + "Aliases : ")

        For index = 0 To myRequestState.host.Aliases.Length - 1
            Console.WriteLine(myRequestState.host.Aliases(index))
        Next index
    catch e as Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
    End Try
    End Sub 'Main
    
    
    Private Shared Sub RespCallback(ar As IAsyncResult)
        Try
            ' Convert the IAsyncResult object to a RequestState object.
            Dim tempRequestState As RequestState = CType(ar.AsyncState, RequestState)

            ' End the asynchronous request.
            tempRequestState.host = Dns.EndResolve(ar)
            Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
            Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 'RespCallback
' </Snippet2>
' </Snippet1>

End Class 'DnsBeginGetHostByName 
