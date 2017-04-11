

' This example shows how to use the ServicePoint and ServicePointManager classes.
' The ServicePointManager class uses the ServicePoint class to manage connections
' to a remote host. The networking classes reuse service points for all 
' requests to a given URI. In fact, the same ServicePoint object 
' is used to issue requests to Internet resources identified by the same
' scheme identifier (for example,  HTTP) and host fragment (for example,  www.contoso.com).  
' Reusing service points in this way can help improve application  performance.

Imports System
Imports System.Net
Imports System.Threading
Imports System.Text.RegularExpressions

Namespace Mssc.Services.ConnectionManagement
    Module M_TestServicePoint

        Class TestServicePoint
            Private Shared Sub ShowProperties(ByVal sp As ServicePoint)

                Console.WriteLine("Done calling FindServicePoint")

                ' Display the ServicePoint Internet resource address.
                Console.WriteLine(("Address = " + sp.Address.ToString()))

                ' Display the date and time that the ServicePoint was last 
                ' connected to a host.
                Console.WriteLine(("IdleSince = " + sp.IdleSince.ToString()))


                ' Display the maximum length of time that the ServicePoint instance 
                ' is allowed to maintain an idle connection to an Internet  
                ' resource before it is recycled for use in another connection.
                Console.WriteLine(("MaxIdleTime = " + sp.MaxIdleTime.ToString()))

                Console.WriteLine(("ConnectionName = " + sp.ConnectionName))

                ' Display the maximum number of connections allowed on this 
                ' ServicePoint instance.
                Console.WriteLine(("ConnectionLimit = " + sp.ConnectionLimit.ToString()))

                ' Display the number of connections associated with this 
                ' ServicePoint instance.
                Console.WriteLine(("CurrentConnections = " + sp.CurrentConnections.ToString()))

                If sp.Certificate Is Nothing Then
                    Console.WriteLine("Certificate = (null)")
                Else
                    Console.WriteLine(("Certificate = " + sp.Certificate.ToString()))
                End If

                If sp.ClientCertificate Is Nothing Then
                    Console.WriteLine("ClientCertificate = (null)")
                Else
                    Console.WriteLine(("ClientCertificate = " + sp.ClientCertificate.ToString()))
                End If

                Console.WriteLine("ProtocolVersion = " + sp.ProtocolVersion.ToString())
                Console.WriteLine(("SupportsPipelining = " + sp.SupportsPipelining.ToString()))

                Console.WriteLine("UseNagleAlgorithm = " + sp.UseNagleAlgorithm.ToString())
                Console.WriteLine("Expect 100-continue = " + sp.Expect100Continue.ToString())
            End Sub 'ShowProperties





            Private Shared Sub makeWebRequest(ByVal hashCode As Integer, ByVal Uri As String)
                Dim res As HttpWebResponse = Nothing

                ' Make sure that the idle time has elapsed, so that a new 
                ' ServicePoint instance is created.
                Console.WriteLine("Sleeping for 2 sec.")
                Thread.Sleep(2000)

                Try
                    ' Create a request to the passed URI.
                    Dim req As HttpWebRequest = CType(WebRequest.Create(Uri), HttpWebRequest)
                    Console.WriteLine((ControlChars.Lf + "Connecting to " + Uri + " ............"))

                    ' Get the response object.
                    res = CType(req.GetResponse(), HttpWebResponse)
                    Console.WriteLine("Connected." + ControlChars.Lf)
                    Dim currentServicePoint As ServicePoint = req.ServicePoint

                    ' Display new service point properties.
                    Dim currentHashCode As Integer = currentServicePoint.GetHashCode()
                    Console.WriteLine(("New service point hashcode: " + currentHashCode.ToString()))
                    Console.WriteLine(("New service point max idle time: " + currentServicePoint.MaxIdleTime.ToString()))
                    Console.WriteLine(("New service point is idle since " + currentServicePoint.IdleSince))

                    ' Check that a new ServicePoint instance has been created.
                    If hashCode = currentHashCode Then
                        Console.WriteLine("Service point reused.")
                    Else
                        Console.WriteLine("A new service point created.")
                    End If
                Catch e As Exception
                    Console.WriteLine(("Source : " + e.Source))
                    Console.WriteLine(("Message : " + e.Message))
                Finally
                    If Not (res Is Nothing) Then
                        res.Close()
                    End If
                End Try
            End Sub 'makeWebRequest


            ' Show the user how to use this program when wrong inputs are entered.
            Private Shared Sub showUsage()
                Console.WriteLine("Enter the proxy name as follows:")
                Console.WriteLine(ControlChars.Tab + "vb_servicepoint proxyName")
            End Sub 'showusage

            ' This is the program entry point. It allows the user to enter 
            ' a server name that is used to locate its current homepage.
            Public Shared Sub Main(ByVal args() As String)
                Dim proxy As String = Nothing
                Dim port As Integer = 80

                ' Define a regular expression to parse the user's input.
                ' This is a security check. It allows only
                ' alphanumeric input strings between 2 to 40 characters long.
                Dim rex As New Regex("^[a-zA-Z]\w{1,39}$")

                If args.Length = 0 Then
                    ' Show how to use this program.
                    showUsage()
                    Return
                End If

                proxy = args(0)
                If (Not (rex.Match(proxy)).Success) Then
                    Console.WriteLine("Input string format not allowed.")
                    Return
                End If

                ' Create a proxy object.  
                Dim proxyAdd As String
                proxyAdd = "http://" + proxy + ":" + port.ToString()


                Dim DefaultProxy As New WebProxy(proxyAdd, True)

                ' Set the proxy that all HttpWebRequest instances use.
                GlobalProxySelection.Select = DefaultProxy

                ' Get the base interface for proxy access for the 
                ' WebRequest-based classes.
                Dim Iproxy As IWebProxy = GlobalProxySelection.Select

                ' Set the maximum number of ServicePoint instances to maintain.
                ' Note that, if a ServicePoint instance for that host already 
                ' exists when your application requests a connection to
                ' an Internet resource, the ServicePointManager object
                ' returns this existing ServicePoint. If none exists 
                ' for that host, it creates a new ServicePoint instance.
                ServicePointManager.MaxServicePoints = 4

                ' Set the maximum idle time of a ServicePoint instance to 10 seconds.
                ' After the idle time expires, the ServicePoint object is eligible for
                ' garbage collection and cannot be used by the ServicePointManager.
                ServicePointManager.MaxServicePointIdleTime = 1000

                ' <Snippet1>
                ServicePointManager.UseNagleAlgorithm = True
                ServicePointManager.Expect100Continue = True
                ServicePointManager.CheckCertificateRevocationList = True
                ServicePointManager.DefaultConnectionLimit = _
                    ServicePointManager.DefaultPersistentConnectionLimit
                ServicePointManager.EnableDnsRoundRobin = True
                ServicePointManager.DnsRefreshTimeout = 4*60*1000
                ' </Snippet1>
                ' Create the Uri object for the resource you want to access.
                Dim MS As New Uri("http://msdn.microsoft.com/")

                ' Use the FindServicePoint method to find an existing 
                ' ServicePoint object or to create a new one.   
                Dim servicePoint As ServicePoint = ServicePointManager.FindServicePoint(MS, Iproxy)
                ShowProperties(servicePoint)
                Dim hashCode As Integer = servicePoint.GetHashCode()
                Console.WriteLine(("Service point hashcode: " + hashCode.ToString()))

                ' Make a request with the same scheme identifier and host fragment
                ' used to create the previous ServicePoint object.
                makeWebRequest(hashCode, "http://msdn.microsoft.com/library/")

            End Sub 'Main

        End Class 'TestServicePoint

    End Module
End Namespace
