' <Snippet5>
' The following example demonstrates using asynchronous methods to
' get Domain Name System information for the specified host computer.

Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Collections

Namespace Examples.AdvancedProgramming.AsynchronousOperations
    ' Create a state object that holds each requested host name, 
    ' an associated IPHostEntry object or a SocketException.
    Public Class HostRequest
        ' Stores the requested host name.
        Dim hostNameValue as string
        ' Stores any SocketException returned by the Dns EndGetHostByName method.
        Dim e as SocketException
        ' Stores an IPHostEntry returned by the Dns EndGetHostByName method.
        Dim entry as IPHostEntry

        Public Sub New(name as String)
            hostNameValue = name
        End Sub

        ReadOnly Public Property HostName as String
            Get
                return hostNameValue
            End Get
        End Property

        Public Property ExceptionObject as SocketException
            Get
                return e
            End Get
            Set
                e = value
            End Set
        End Property

        Public Property HostEntry as IPHostEntry
            Get
                return entry
            End Get
            Set
                entry = value
            End Set
        End Property
    End Class

    Public Class UseDelegateAndStateForAsyncCallback
        ' The number of pending requests.
        Dim Shared requestCounter as Integer
        Dim Shared hostData as ArrayList = new ArrayList()

        Shared Sub UpdateUserInterface()
            ' Print a message to indicate that the application
            ' is still working on the remaining requests.
            Console.WriteLine("{0} requests remaining.", requestCounter)
        End Sub

        Public Shared Sub Main()
            ' Create the delegate that will process the results of the 
            ' asynchronous request.
            Dim callBack as AsyncCallback = AddressOf ProcessDnsInformation
            Dim host as string

            Do
                Console.Write(" Enter the name of a host computer or <enter> to finish: ")
                host = Console.ReadLine()
                If host.Length > 0
                    ' Increment the request counter in a thread safe manner.
                    Interlocked.Increment(requestCounter)
                    ' Create and store the state object for this request.
                    Dim request as HostRequest = new HostRequest(host)
                    hostData.Add(request)
                    ' Start the asynchronous request for DNS information.
                    Dns.BeginGetHostEntry(host, callBack, request)
                End If
            Loop While host.Length > 0

            ' The user has entered all of the host names for lookup.
            ' Now wait until the threads complete.
            Do While requestCounter > 0
                UpdateUserInterface()
            Loop

            ' Display the results.
            For Each r as HostRequest In hostData
                If IsNothing(r.ExceptionObject) = False
                    Console.WriteLine( _
                      "Request for host {0} returned the following error: {1}.", _
                      r.HostName, r.ExceptionObject.Message)
                Else
                    ' Get the results.
                    Dim h as IPHostEntry = r.HostEntry
                    Dim aliases() as String = h.Aliases
                    Dim addresses() as IPAddress = h.AddressList
                    Dim j, k as Integer

                    If aliases.Length > 0
                        Console.WriteLine("Aliases for {0}", r.HostName)
                        For j = 0 To aliases.Length - 1
                            Console.WriteLine("{0}", aliases(j))
                        Next j
                    End If
                    If addresses.Length > 0
                        Console.WriteLine("Addresses for {0}", r.HostName)
                        For k = 0 To addresses.Length - 1
                            Console.WriteLine("{0}", addresses(k).ToString())
                        Next k
                    End If
                End If
            Next r
        End Sub

        ' The following method is invoked when each asynchronous operation completes.
        Shared Sub ProcessDnsInformation(result as IAsyncResult)
            ' Get the state object associated with this request.
            Dim request as HostRequest = CType(result.AsyncState, HostRequest)
            Try
                ' Get the results and store them in the state object.
                Dim host as IPHostEntry = Dns.EndGetHostEntry(result)
                request.HostEntry = host
            Catch e as SocketException
                ' Store any SocketExceptions.
                request.ExceptionObject = e
            Finally
                ' Decrement the request counter in a thread-safe manner.
                Interlocked.Decrement(requestCounter)
            End Try
        End Sub
    End Class
End Namespace
' </Snippet5>


