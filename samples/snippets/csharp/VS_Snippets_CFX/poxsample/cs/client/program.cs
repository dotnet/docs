using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Net;
using System.IO;

namespace Microsoft.ServiceModel.Samples
{
	class Program
	{
		static void Main(string[] args)
		{            
            Uri collectionUri = new Uri( "http://localhost:8100/customers/" );
            Uri requestUri;
            Message response;
            Customer aCustomer;
			
            //We pass false to the constructor of HttpClient in order to
            //disable HTTP connection reuse. In a production application
            //KeepAlive would normally be enabled for performance reasons.
            //However, HTTP KeepAlive breaks wire-level HTTP tracing tools
            //such as Microsoft Fiddler (http://www.fiddlertool.com). Since
            //it may be instructive to view the output of this sample in 
            //such a tool, we disable KeepAlive here.
            HttpClient client = new HttpClient( collectionUri, false );

            //Get Customer 1 by doing an HTTP GET to the customer's URI
            requestUri = new Uri( collectionUri, "1" );
            Console.WriteLine( "GET " + requestUri );
            response = client.Get( requestUri );
            Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );
            aCustomer = response.GetBody<Customer>();
            Console.WriteLine( aCustomer.ToString() );
            Console.WriteLine( "" );

            //Use POST to update the customer's name.
            aCustomer.Name = "Robert";
            Console.WriteLine( "POST " + requestUri );
            Console.WriteLine( aCustomer.ToString() );
            response = client.Post( requestUri, aCustomer );
            Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );

            Console.WriteLine("");

            //Get Customer 1 again to show that the server's state has changed
            requestUri = new Uri( collectionUri, "1" );
            Console.WriteLine( "GET " + requestUri );
            response = client.Get( requestUri );
            Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );
            aCustomer = response.GetBody<Customer>();
            Console.WriteLine( aCustomer.ToString() );

            Console.WriteLine( "" );

            //Use HTTP PUT to add a customer to the collection
            requestUri = collectionUri;
            aCustomer = new Customer();
            aCustomer.Name = "Alice";
            aCustomer.Address = "2323 Lake Shore Drive";

            Console.WriteLine( "PUT " + requestUri );
            Console.WriteLine( aCustomer.ToString() );
            response = client.Put( requestUri, aCustomer );
            Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );
            
            //This customer is now addressable on the server the URI that came back
            //in the HTTP Location header
            Uri location = client.GetLocation( response );
            Console.WriteLine( "Location: " + location );
            
            Console.WriteLine("");

            //Add another customer in the same way
            aCustomer = new Customer();
            aCustomer.Name = "Charlie";
            aCustomer.Address = "123 Fourth Street";

            Console.WriteLine( "PUT " + requestUri );
            Console.WriteLine( aCustomer.ToString() );
            response = client.Put( requestUri, aCustomer );
            Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );
            location = client.GetLocation( response );
            Console.WriteLine( "Location: " + location );

            Console.WriteLine("");

            //Delete customer 1
            requestUri = new Uri( collectionUri, "1" );
            Console.WriteLine( "DELETE " + requestUri );
            response = client.Delete( requestUri );
            Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );
            
            Console.WriteLine( "" );

            //Once a customer's deleted, GET's to the customer's URI
            //will result in EndpointNotFound exceptions.
            requestUri = new Uri( collectionUri, "1" );
            Console.WriteLine( "GET " + requestUri );

            try
            {
                response = client.Get( requestUri );
                Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );
            }
            catch( EndpointNotFoundException ex )
            {
                Console.WriteLine( "Endpoint not found" );
            }
            
            Console.WriteLine( "" );

            //Doing an HTTP GET on the customer collection URI will
            //return the contents of the collection, reflecting
            //the state modifications made during the execution
            //of this sample.
            Console.WriteLine( "GET " + collectionUri );
            response = client.Get( collectionUri );
            Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );
            List<Uri> links = response.GetBody<List<Uri>>();

            Console.WriteLine( links.Count + " links were returned" );
            
            Console.WriteLine( "" );

            //Now that we have a link to each customer in the collection,
            //we can enumerate the collection contents using GET
            foreach( Uri customerUri in links )
            {
                Console.WriteLine( "GET " + customerUri );
                response = client.Get( customerUri );
                Console.WriteLine( (int) client.GetStatusCode( response ) + " " + client.GetStatusDescription( response ) );

                aCustomer = response.GetBody<Customer>();
                Console.WriteLine( aCustomer.ToString() );

                Console.WriteLine( "" );
            }

            Console.WriteLine();
            Console.WriteLine( "Press any key to exit" );
			Console.ReadLine();
            
		}
	}
}
