
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.Threading;
using System.IO;
using System.Text;
using System.Globalization;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    //<snippet4>
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);

        [OperationContract]
        double Subtract(double n1, double n2);

        //Multiply involves some file I/O so we'll make it Async.
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginMultiply(double n1, double n2, AsyncCallback callback, object state);
        double EndMultiply(IAsyncResult ar);

        //Divide involves some file I/O so we'll make it Async.
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginDivide(double n1, double n2, AsyncCallback callback, object state);
        double EndDivide(IAsyncResult ar);
    }
    //</snippet4>

}
