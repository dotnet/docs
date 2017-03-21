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
                WebRequest.DefaultWebProxy = DefaultProxy


                ' Get the base interface for proxy access for the 
                ' WebRequest-based classes.
                Dim Iproxy As IWebProxy = WebRequest.DefaultWebProxy

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
                ServicePointManager.MaxServicePointIdleTime = 10000


                ServicePointManager.UseNagleAlgorithm = True
                ServicePointManager.Expect100Continue = True
                ServicePointManager.CheckCertificateRevocationList = True
                ServicePointManager.DefaultConnectionLimit = _
                    ServicePointManager.DefaultPersistentConnectionLimit
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
