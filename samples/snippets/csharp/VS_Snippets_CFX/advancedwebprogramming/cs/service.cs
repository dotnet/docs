//  Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Net;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Microsoft.WebProgrammingModel.Samples
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : ICustomerCollection
    {
        int counter = 0;
        Hashtable customers = new Hashtable();
        object writeLock = new Object();

        public Customer AddCustomer(Customer customer)
        {
            Snippets.Snippet2();
            lock (writeLock)
            {
                // <Snippet0>
                counter++;
                
                UriTemplateMatch match = WebOperationContext.Current.IncomingRequest.UriTemplateMatch;

                UriTemplate template = new UriTemplate("{id}");
                customer.Uri = template.BindByPosition(match.BaseUri, counter.ToString());

                customers[counter.ToString()] = customer;
                
                WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(customer.Uri);
                
                // </Snippet0>
            }

            return customer;
        }

        public void DeleteCustomer(string id)
        {
            if (!customers.ContainsKey(id))
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
            }
            else
            {
                lock (writeLock)
                {
                    customers.Remove(id);
                }
            }
        }

        public Customer GetCustomer(string id)
        {
            Customer c = this.customers[id] as Customer;

            if (c == null)
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
                return null;
            }

            return c;
        }


        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

            lock (writeLock)
            {
                foreach (Customer c in this.customers.Values)
                {
                    list.Add(c);
                }
            }

            return list;
        }

        public Customer UpdateCustomer(string id, Customer newCustomer)
        {
            if (!customers.ContainsKey(id))
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
                return null;
            }

            lock (writeLock)
            {
                customers[id] = newCustomer;
            }

            return newCustomer;
        }

    }
}
