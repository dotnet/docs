---
title: "Tutorial: Use a Windows Communication Foundation client"
ms.date: 01/25/2019
helpviewer_keywords:
  - "WCF clients [WCF], using"
dev_langs:
 - CSharp
 - VB
ms.assetid: 190349fc-0573-49c7-bb85-8e316df7f31f
---
# Tutorial: Use a Windows Communication Foundation client

This tutorial describes the last of five tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

After you've created and configured a Windows Communication Foundation (WCF) proxy, create a client instance and compile the client application. You then use it to communicate with the WCF service. The client code does the following steps:
- Instantiates the WCF client.
- Calls the service operations from the generated proxy.
- Closes the client after the operation call is completed.

In this tutorial, you learn how to:
> [!div class="checklist"]
> - Add code to use the WCF client.
> - Test the WCF client.

## Add code to use the WCF client

Open the *Program.cs* (or *Module1.vb*) file from the **GettingStartedClient** project and replace the existing code with the following code:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettingStartedClient.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create an instance of the WCF proxy.
            CalculatorClient client = new CalculatorClient();

            // Step 2: Call the service operations.
            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            // Step 3: Close the client to gracefully close the connection and clean up resources.
            Console.WriteLine("\nPress <Enter> to terminate client.");
            Console.ReadLine();
            client.Close();
        }
    }
}
```

```vb
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports GettingStartedClient.ServiceReference1

Module Module1

    Sub Main()
        ' Step 1: Create an instance of the WCF proxy.
        Dim Client As New CalculatorClient()

        ' Step 2: Call the service operations.
        ' Call the Add service operation.
        Dim value1 As Double = 100D
        Dim value2 As Double = 15.99D
        Dim result As Double = Client.Add(value1, value2)
        Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

        ' Call the Subtract service operation.
        value1 = 145D
        value2 = 76.54D
        result = Client.Subtract(value1, value2)
        Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

        ' Call the Multiply service operation.
        value1 = 9D
        value2 = 81.25D
        result = Client.Multiply(value1, value2)
        Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

        ' Call the Divide service operation.
        value1 = 22D
        value2 = 7D
        result = Client.Divide(value1, value2)
        Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

        ' Step 3: Close the client to gracefully close the connection and clean up resources.
        Console.WriteLine()
        Console.WriteLine("Press <Enter> to terminate client.")
        Console.ReadLine()
        Client.Close()

    End Sub

End Module
```

Notice the `using` (for Visual C#) or `Imports` (for Visual Basic) statement that imports `GettingStartedClient.ServiceReference1`. This statement imports the code that Visual Studio generated with the **Add Service Reference** function. The code instantiates the WCF proxy and calls each of the service operations that the calculator service exposes. It then closes the proxy and ends the program.

## Test the WCF client

To test the application:
1. Save and build the solution.
2. Run *GettingStartedHost.exe* to start the service.
3. Run *GettingStartedClient.exe* to start the client.

*GettingStartedHost.exe* produces the following output:

```text
The service is ready.
Press <Enter> to terminate service.

Received Add(100,15.99)
Return: 115.99
Received Subtract(145,76.54)
Return: 68.46
Received Multiply(9,81.25)
Return: 731.25
Received Divide(22,7)
Return: 3.14285714285714
```

*GettingStartedClient.exe* produces the following output:

```text
Add(100,15.99) = 115.99
Subtract(145,76.54) = 68.46
Multiply(9,81.25) = 731.25
Divide(22,7) = 3.14285714285714

Press <Enter> to terminate client.
```

## Next steps

You've now completed all the tasks in the WCF get started tutorial. In this tutorial, you learned how to:

In this tutorial, you learn how to:
> [!div class="checklist"]
> - Add code to use the WCF client.
> - Test the WCF client.

If you have problems or errors in any of the steps, follow the steps in the troubleshooting article to fix them.

> [!div class="nextstepaction"]
> [Troubleshoot the Get started with WCF tutorials](troubleshooting-the-getting-started-tutorial.md)

