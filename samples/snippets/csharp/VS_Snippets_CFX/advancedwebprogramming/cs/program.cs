//  Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Microsoft.WebProgrammingModel.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000/Customers")))
            {
                //WebServiceHost will automatically create a default endpoint at the base address using the WebHttpBinding
                //and the WebHttpBehavior, so there's no need to set it up explicitly
                host.Open();

                Uri baseAddress = new Uri("http://localhost:8000/Customers");

                using (WebChannelFactory<ICustomerCollection> cf = new WebChannelFactory<ICustomerCollection>(baseAddress))
                {
                    //WebChannelFactory will default to using the WebHttpBinding with the WebHttpBehavior,
                    //so there's no need to set up the endpoint explicitly

                    ICustomerCollection channel = cf.CreateChannel();

                    UriTemplate template = new UriTemplate("{id}");

                    Console.WriteLine("Adding some customers with POST:");

                    Customer alice = new Customer("Alice", "123 Pike Place", null);
                    alice = channel.AddCustomer(alice);
                    Console.WriteLine(alice.ToString());

                    Customer bob = new Customer("Bob", "2323 Lake Shore Drive", null);
                    bob = channel.AddCustomer(bob);
                    Console.WriteLine(bob.ToString());

                    Console.WriteLine("");
                    Console.WriteLine("Using PUT to update a customer");

                    alice.Name = "Charlie";

                    UriTemplateMatch match = template.Match(baseAddress, alice.Uri);
                    alice = channel.UpdateCustomer(match.BoundVariables["id"], alice);
                    Console.WriteLine(alice.ToString());

                    Console.WriteLine("");
                    Console.WriteLine("Using GET to retrieve the list of customers");

                    List<Customer> customers = channel.GetCustomers();

                    foreach (Customer c in customers)
                    {
                        Console.WriteLine(c.ToString());
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Using DELETE to delete a customer");

                    match = template.Match(baseAddress, bob.Uri);
                    channel.DeleteCustomer(match.BoundVariables["id"]);

                    Console.WriteLine("");
                    Console.WriteLine("Final list of customers: ");

                    customers = channel.GetCustomers();

                    foreach (Customer c in customers)
                    {
                        Console.WriteLine(c.ToString());
                    }


                    Console.WriteLine("");
                }


                Console.WriteLine("Press any key to terminate");
                Console.ReadLine();
            }
        }
    }
}
