
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.Web;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract that uses a session.
    // ICalculatorSession allows you to perform multiple operations on a running result.
    // You can retrieve the current result by calling Equals().
    // You can begin calculating a new result by calling Clear().
    // <Snippet1>
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculatorSession
    {
        [OperationContract]
        void Clear();
        [OperationContract]
        void AddTo(double n);
        [OperationContract]
        void SubtractFrom(double n);
        [OperationContract]
        void MultiplyBy(double n);
        [OperationContract]
        void DivideBy(double n);
        [OperationContract]
        double Equals();
    }
    // </Snippet1>

    // Service class that implements the service contract.
    // Utilize AspSessionState to manage each calculator session.
    // Requiring AspNetCompatibilityMode allows you access to the HttpContext and Session.
    // <Snippet2>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CalculatorService : ICalculatorSession
    {
        double result
        {   // Store result in AspNet session.
            get
            {
                if (HttpContext.Current.Session["Result"] != null)
                    return (double)HttpContext.Current.Session["Result"];
                return 0.0D;
            }
            set
            {
                HttpContext.Current.Session["Result"] = value;
            }
        }

        public void Clear()
        {
            
        }

        public void AddTo(double n)
        {
            result += n;
        }

        public void SubtractFrom(double n)
        {
            result -= n;
        }

        public void MultiplyBy(double n)
        {
            result *= n;
        }

        public void DivideBy(double n)
        {
            result /= n;
        }

        public double Equals()
        {
            return result;
        }
    }
    // </Snippet2>
}
