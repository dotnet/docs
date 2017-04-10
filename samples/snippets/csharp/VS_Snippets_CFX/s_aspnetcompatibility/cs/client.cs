
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a proxy with given client endpoint configuration.
            using (CalculatorSessionClient proxy = new CalculatorSessionClient())
            {
                proxy.Clear();
                proxy.AddTo(100.0D);
                proxy.SubtractFrom(50.0D);
                proxy.MultiplyBy(17.65D);
                proxy.DivideBy(2.0D);
                double result = proxy.Equals();
                Console.WriteLine("0, + 100, - 50, * 17.65, / 2 = {0}", result);

      
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
