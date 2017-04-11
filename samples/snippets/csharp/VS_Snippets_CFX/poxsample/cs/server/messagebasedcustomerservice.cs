using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Prefix)]
    class MessageBasedCustomerService : IUniversalContract
    {
        Dictionary<string, Customer> customerList;
        int nextId;

        MessageBasedCustomerService()
        {
            customerList = new Dictionary<string, Customer>();
            // Default customer
            Customer customer = new Customer();
            customer.Name = "Bob";
            customer.Address = "100 Main Street";
            customerList.Add( "1", customer);

            nextId = 1;
        }

        #region IUniversalContract Members
        // <snippet0>
        public Message ProcessMessage(Message request)
        {
            Message response = null;

            //The HTTP Method (e.g. GET) from the incoming HTTP request
            //can be found on the HttpRequestMessageProperty. The MessageProperty
            //is added by the HTTP Transport when the message is received.
            HttpRequestMessageProperty requestProperties =
                (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

            //Here we dispatch to different internal implementation methods
            //based on the incoming HTTP verb.
            if (requestProperties != null)
            {
                if (String.Equals("GET", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = GetCustomer(request);
                }
                else if (String.Equals("POST", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = UpdateCustomer(request);
                }
                else if (String.Equals("PUT", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = AddCustomer(request);
                }
                else if (String.Equals("DELETE", requestProperties.Method,
                    StringComparison.OrdinalIgnoreCase))
                {
                    response = DeleteCustomer(request);
                }
                else
                {
                    //This service doesn't implement handlers for other HTTP verbs (such as HEAD), so we
                    //construct a response message and use the HttpResponseMessageProperty to
                    //set the HTTP status code to 405 (Method Not Allowed) which indicates the client 
                    //used an HTTP verb not supported by the server.
                    response = Message.CreateMessage(MessageVersion.None, String.Empty, String.Empty);

                    HttpResponseMessageProperty responseProperty = new HttpResponseMessageProperty();
                    responseProperty.StatusCode = HttpStatusCode.MethodNotAllowed;

                    response.Properties.Add( HttpResponseMessageProperty.Name, responseProperty );
                }
            }
            else
            {
                throw new InvalidOperationException( "This service requires the HTTP transport" );
            }

            return response;
        }
        // </snippet0>

        #endregion

        Message GetCustomer(Message message)
        {
            Message response = null;

            HttpRequestMessageProperty requestProperties = message.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            HttpResponseMessageProperty responseProperties = new HttpResponseMessageProperty();

            Customer customer = null;
            Console.WriteLine("Received GET for " + message.Properties.Via);
            
            Uri endpointUri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri;
            string id = CustomerIdFromRequestUri( message.Properties.Via, endpointUri );

            if( id != null )
            {
                customerList.TryGetValue( id, out customer);
            }
            else
            {
                //No customer was specified, so return the contents of the collection as links
                List<Uri> links = new List<Uri>();

                foreach( string customerId in this.customerList.Keys )
                {
                    links.Add( new Uri( endpointUri.ToString() + "/" + customerId ) );
                }

                responseProperties.StatusCode = HttpStatusCode.OK;
                response = Message.CreateMessage(message.Version, message.Headers.Action, links);
                response.Properties[HttpResponseMessageProperty.Name] = responseProperties;
                return response;
            }

            if (customer == null)
            {
                responseProperties.StatusCode = HttpStatusCode.NotFound;
                response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty);
            }
            else
            {
                responseProperties.StatusCode = HttpStatusCode.OK;
                response = Message.CreateMessage(message.Version, message.Headers.Action, customer);
            }

            response.Properties[HttpResponseMessageProperty.Name] = responseProperties;

            return response;
        }

        Message UpdateCustomer(Message message)
        {
            Message response = null;

            HttpRequestMessageProperty requestProperties = message.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            HttpResponseMessageProperty responseProperties = new HttpResponseMessageProperty();

            Uri endpointUri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri;
            string id = CustomerIdFromRequestUri( message.Properties.Via, endpointUri );

            Console.WriteLine("Received " + requestProperties.Method + " for Customer.");
            Customer customer = message.GetBody<Customer>();
            Console.WriteLine("\tCustomer Data - Name: " + customer.Name + " Address: " + customer.Address);
            
            if (customer != null)
            {
                if (!customerList.ContainsKey(id))
                {
                    responseProperties.StatusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    customerList[id] = customer;
                    responseProperties.StatusCode = HttpStatusCode.OK;
                }
            }
            else
            {
                responseProperties.StatusCode = HttpStatusCode.BadRequest;
            }

            responseProperties.SuppressEntityBody = true;
            response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty);
            response.Properties[HttpResponseMessageProperty.Name] = responseProperties;

            return response;
        }

        Message AddCustomer(Message message)
        {
            Message response = null;
            HttpRequestMessageProperty requestProperties = message.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;

            HttpResponseMessageProperty responseProperties = new HttpResponseMessageProperty();

            Console.WriteLine("Received " + requestProperties.Method + " for Customer.");
            Customer customer = message.GetBody<Customer>();

            Console.WriteLine("\tCustomer Data - Name: " + customer.Name + " Address: " + customer.Address);
            if (customer != null)
            {
                this.nextId += 1;
                this.customerList[nextId.ToString()] = customer;

                Uri collectionUri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri;
                responseProperties.StatusCode = HttpStatusCode.Created;
                responseProperties.Headers[ HttpResponseHeader.Location ] = new Uri( collectionUri, this.nextId.ToString() ).ToString();
            }
            else
            {
                responseProperties.StatusCode = HttpStatusCode.BadRequest;
            }

            responseProperties.SuppressEntityBody = true;
            response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty);
            response.Properties[HttpResponseMessageProperty.Name] = responseProperties;

            return response;

        }

        Message DeleteCustomer(Message message)
        {
            Message response = null;
            HttpRequestMessageProperty requestProperties = message.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;

            HttpResponseMessageProperty responseProperties = new HttpResponseMessageProperty();

            Console.WriteLine("Received DELETE for Customer");

            Uri endpointUri = OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri;
            string id = CustomerIdFromRequestUri( message.Properties.Via, endpointUri );

            if (customerList.ContainsKey(id))
            {
                customerList.Remove(id);
                responseProperties.StatusCode = HttpStatusCode.OK;
                responseProperties.SuppressEntityBody = true;
            }
            else
            {
                responseProperties.StatusCode = HttpStatusCode.NotFound;
                responseProperties.SuppressEntityBody = true;
            }

            responseProperties.SuppressEntityBody = true;
            response = Message.CreateMessage(message.Version, message.Headers.Action, String.Empty);
            response.Properties[HttpResponseMessageProperty.Name] = responseProperties;

            return response;
        }

        string CustomerIdFromRequestUri( Uri via, Uri endpoint )
        {
            int customerNameSegmentIndex = endpoint.Segments.Length;
            return ( customerNameSegmentIndex < via.Segments.Length) ? via.Segments[ customerNameSegmentIndex ] : null;
        }
    }
}
