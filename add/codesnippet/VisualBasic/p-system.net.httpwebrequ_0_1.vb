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
                    Console.WriteLine(("New service point is idle since " + currentServicePoint.IdleSince.ToString()))

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
