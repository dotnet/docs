' <Snippet4>

'The following example demonstrates using asynchronous methods to
'get Domain Name System information for the specified host computers.
'This example uses a delegate to obtain the results of each asynchronous 
'operation.

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Collections.Specialized
Imports System.Collections

Namespace Examples.AdvancedProgramming.AsynchronousOperations

    Public Class UseDelegateForAsyncCallback
    
        Dim Shared requestCounter as Integer
        Dim Shared hostData as ArrayList = new ArrayList()
        Dim Shared hostNames as StringCollection = new StringCollection()
        Shared Sub UpdateUserInterface()
        
            ' Print a message to indicate that the application
            ' is still working on the remaining requests.
            Console.WriteLine("{0} requests remaining.", requestCounter)
        End Sub
        Public Shared Sub Main()
            ' Create the delegate that will process the results of the 
            ' asynchronous request.
            Dim callBack as AsyncCallback
            Dim host as string
            Dim i, j, k as Integer
            callback = AddressOf ProcessDnsInformation
            Do
                Console.Write(" Enter the name of a host computer or <enter> to finish: ")
                host = Console.ReadLine()
                If host.Length > 0
                    ' Increment the request counter in a thread safe manner.
                    Interlocked.Increment(requestCounter)
                    ' Start the asynchronous request for DNS information.
                    Dns.BeginGetHostEntry(host, callBack, host)
                End If
            Loop While (host.Length > 0)
            
            ' The user has entered all of the host names for lookup.
            ' Now wait until the threads complete.
            Do While requestCounter > 0
            
                UpdateUserInterface()
            Loop
            
            ' Display the results.
            For i = 0 To hostNames.Count -1
                Dim dataObject as Object = hostData (i)
                Dim message as String 
                
                ' Was a SocketException was thrown?
                If TypeOf dataObject is String
                    message = CType(dataObject, String)
                    Console.WriteLine("Request for {0} returned message: {1}", _ 
                        hostNames(i), message)
                Else
                    ' Get the results.
                    Dim h as IPHostEntry = CType(dataObject, IPHostEntry) 
                    Dim aliases() as String = h.Aliases
                    Dim addresses() as IPAddress = h.AddressList
                    If aliases.Length > 0
                        Console.WriteLine("Aliases for 0}", hostNames(i))
                        For j = 0 To aliases.Length -1
                            Console.WriteLine("{0}", aliases(j))
                        Next j
                    End If
                    If addresses.Length > 0
                        Console.WriteLine("Addresses for {0}", hostNames(i))
                        For k = 0 To addresses.Length -1
                            Console.WriteLine("{0}",addresses(k).ToString())
                        Next k
                    End If
                End If
            Next i
       End Sub

        ' The following method is called when each asynchronous operation completes.
        Shared Sub ProcessDnsInformation(result as IAsyncResult)
        
            Dim hostName as String = CType(result.AsyncState, String)
            hostNames.Add(hostName)
            Try 
                ' Get the results.
                Dim host as IPHostEntry = Dns.EndGetHostEntry(result)
                hostData.Add(host)
            ' Store the exception message.
            Catch e as SocketException
                hostData.Add(e.Message)
            Finally 
                ' Decrement the request counter in a thread-safe manner.
                Interlocked.Decrement(requestCounter)
            End Try
        End Sub
    End Class
End Namespace
'</Snippet4>


