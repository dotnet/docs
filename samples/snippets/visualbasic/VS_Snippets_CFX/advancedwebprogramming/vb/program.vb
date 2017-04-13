Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Web

Module Program

    Sub Main()
        Using host As New WebServiceHost(GetType(Service), New Uri("http://localhost:8000/Customers"))
            ' WebServiceHost will automatically create a default endpoint at the base address imports the WebHttpBinding
            ' and the WebHttpBehavior, so there's no need to set it up explicitly
            host.Open()

            Dim baseAddress As New Uri("http://localhost:8000/Customers")

            Using cf As New WebChannelFactory(Of ICustomerCollection)(baseAddress)

                ' WebChannelFactory will default to imports the WebHttpBinding with the WebHttpBehavior,
                ' so there's no need to set up the endpoint explicitly

                Dim channel As ICustomerCollection = cf.CreateChannel()
                Dim template As New UriTemplate("{id}")

                Console.WriteLine("Adding some customers with POST:")

                Dim alice As New Customer("Alice", "123 Pike Place", Nothing)
                alice = channel.AddCustomer(alice)
                Console.WriteLine(alice.ToString())

                Dim bob As New Customer("Bob", "2323 Lake Shore Drive", Nothing)
                bob = channel.AddCustomer(bob)
                Console.WriteLine(bob.ToString())

                Console.WriteLine("")
                Console.WriteLine("imports PUT to update a customer")

                alice.Name = "Charlie"

                Dim match As UriTemplateMatch = template.Match(baseAddress, alice.Uri)
                alice = channel.UpdateCustomer(match.BoundVariables("id"), alice)
                Console.WriteLine(alice.ToString())

                Console.WriteLine("")
                Console.WriteLine("imports GET to retrieve the list of customers")

                Dim customers As List(Of Customer) = channel.GetCustomers()

                For Each c As Customer In customers
                    Console.WriteLine(c.ToString())
                Next

                Console.WriteLine("")
                Console.WriteLine("imports DELETE to delete a customer")

                match = template.Match(baseAddress, bob.Uri)
                channel.DeleteCustomer(match.BoundVariables("id"))

                Console.WriteLine("")
                Console.WriteLine("Final list of customers: ")

                customers = channel.GetCustomers()

                For Each c As Customer In customers
                    Console.WriteLine(c.ToString())
                Next

                Console.WriteLine("")
            End Using


            Console.WriteLine("Press any key to terminate")
            Console.ReadLine()
        End Using
    End Sub

End Module
