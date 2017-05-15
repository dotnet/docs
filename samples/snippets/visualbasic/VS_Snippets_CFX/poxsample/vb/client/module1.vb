
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.ServiceModel.Channels
Imports System.Net
Imports System.IO

Namespace Microsoft.ServiceModel.Samples
    Module Module1
        Sub Main(ByVal args() As String)
            Dim collectionUri As New Uri("http://localhost:8100/customers/")
            Dim requestUri As Uri
            Dim response As Message
            Dim aCustomer As Customer

            'We pass false to the constructor of HttpClient in order to
            'disable HTTP connection reuse. In a production application
            'KeepAlive would normally be enabled for performance reasons.
            'However, HTTP KeepAlive breaks wire-level HTTP tracing tools
            'such as Microsoft Fiddler (http://www.fiddlertool.com). Since
            'it may be instructive to view the output of this sample in 
            'such a tool, we disable KeepAlive here.
            Dim client As New HttpClient(collectionUri, False)

            'Get Customer 1 by doing an HTTP GET to the customer's URI
            requestUri = New Uri(collectionUri, "1")
            Console.WriteLine("GET " & requestUri.ToString())
            response = client.Get(requestUri)
            Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))
            aCustomer = response.GetBody(Of Customer)()
            Console.WriteLine(aCustomer.ToString())
            Console.WriteLine("")

            'Use POST to update the customer's name.
            aCustomer.Name = "Robert"
            Console.WriteLine("POST " & requestUri.ToString())
            Console.WriteLine(aCustomer.ToString())
            response = client.Post(requestUri, aCustomer)
            Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))

            Console.WriteLine("")

            'Get Customer 1 again to show that the server's state has changed
            requestUri = New Uri(collectionUri, "1")
            Console.WriteLine("GET " & requestUri.ToString())
            response = client.Get(requestUri)
            Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))
            aCustomer = response.GetBody(Of Customer)()
            Console.WriteLine(aCustomer.ToString())

            Console.WriteLine("")

            'Use HTTP PUT to add a customer to the collection
            requestUri = collectionUri
            aCustomer = New Customer()
            aCustomer.Name = "Alice"
            aCustomer.Address = "2323 Lake Shore Drive"

            Console.WriteLine("PUT " & requestUri.ToString())
            Console.WriteLine(aCustomer.ToString())
            response = client.Put(requestUri, aCustomer)
            Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))

            'This customer is now addressable on the server the URI that came back
            'in the HTTP Location header
            Dim location As Uri = client.GetLocation(response)
            Console.WriteLine("Location: " & location.ToString())

            Console.WriteLine("")

            'Add another customer in the same way
            aCustomer = New Customer()
            aCustomer.Name = "Charlie"
            aCustomer.Address = "123 Fourth Street"

            Console.WriteLine("PUT " & requestUri.ToString())
            Console.WriteLine(aCustomer.ToString())
            response = client.Put(requestUri, aCustomer)
            Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))
            location = client.GetLocation(response)
            Console.WriteLine("Location: " & location.ToString())

            Console.WriteLine("")

            'Delete customer 1
            requestUri = New Uri(collectionUri, "1")
            Console.WriteLine("DELETE " & requestUri.ToString())
            response = client.Delete(requestUri)
            Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))

            Console.WriteLine("")

            'Once a customer's deleted, GET's to the customer's URI
            'will result in EndpointNotFound exceptions.
            requestUri = New Uri(collectionUri, "1")
            Console.WriteLine("GET " & requestUri.ToString())

            Try
                response = client.Get(requestUri)
                Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))
            Catch ex As EndpointNotFoundException
                Console.WriteLine("Endpoint not found")
            End Try

            Console.WriteLine("")

            'Doing an HTTP GET on the customer collection URI will
            'return the contents of the collection, reflecting
            'the state modifications made during the execution
            'of this sample.
            Console.WriteLine("GET " & collectionUri.ToString())
            response = client.Get(collectionUri)
            Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))
            Dim links As List(Of Uri) = response.GetBody(Of List(Of Uri))()

            Console.WriteLine(links.Count & " links were returned")

            Console.WriteLine("")

            'Now that we have a link to each customer in the collection,
            'we can enumerate the collection contents using GET
            For Each customerUri As Uri In links
                Console.WriteLine("GET " & customerUri.ToString())
                response = client.Get(customerUri)
                Console.WriteLine(CInt(Fix(client.GetStatusCode(response))) & " " & client.GetStatusDescription(response))

                aCustomer = response.GetBody(Of Customer)()
                Console.WriteLine(aCustomer.ToString())

                Console.WriteLine("")
            Next customerUri

            Console.WriteLine()
            Console.WriteLine("Press any key to exit")
            Console.ReadLine()

        End Sub
    End Module
End Namespace
