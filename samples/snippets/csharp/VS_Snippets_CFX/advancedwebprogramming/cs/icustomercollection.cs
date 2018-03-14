//  Copyright (c) Microsoft Corporation. All rights reserved.

using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Microsoft.WebProgrammingModel.Samples
{
    [ServiceContract]
    public interface ICustomerCollection
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "")]
        Customer AddCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}")]
        void DeleteCustomer(string id);

        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        Customer GetCustomer(string id);

        [OperationContract]
        [WebGet(UriTemplate = "")]
        List<Customer> GetCustomers();

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}")]
        Customer UpdateCustomer(string id, Customer newCustomer);
    }

}
