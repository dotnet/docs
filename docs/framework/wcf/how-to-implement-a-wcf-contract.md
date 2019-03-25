---
title: "Tutorial: Implement a Windows Communication Foundation service contract"
ms.date: 03/19/2019
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "service contracts [WCF], implementing"
ms.assetid: d5ab51ba-61ae-403e-b3c8-e2669e326806
---
# Tutorial: Implement a Windows Communication Foundation service contract

This tutorial describes the second of five tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Tutorial: Get started with Windows Communication Foundation applications](getting-started-tutorial.md).

The next step for creating a WCF application is to add code to implement the WCF service interface that you created in the previous step. In this step, you create a class named `CalculatorService` that implements the user-defined `ICalculator` interface. Each method in the following code calls a calculator operation and writes text to the console to test it. 

In this tutorial, you learn how to:
> [!div class="checklist"]
> - Add code to implement the WCF service contract.
> - Build the solution.

## Add code to implement the WCF service contract

In **GettingStartedLib**, open the **Service1.cs** or **Service1.vb** file and replace its code with the following code:

```csharp
using System;
using System.ServiceModel;

namespace GettingStartedLib
{
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            // Code added to write output to the console window.
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }
    }
}
```

```vb
Imports System.ServiceModel

Namespace GettingStartedLib

    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result As Double = n1 + n2
            ' Code added to write output to the console window.
            Console.WriteLine("Received Add({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Dim result As Double = n1 - n2
            Console.WriteLine("Received Subtract({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result

        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Dim result As Double = n1 * n2
            Console.WriteLine("Received Multiply({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result

        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Dim result As Double = n1 / n2
            Console.WriteLine("Received Divide({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result

        End Function
    End Class
End Namespace
```

## Edit App.config

Edit **App.config** in **GettingStartedLib** to reflect the changes you made to the code.
- For Visual C# projects:
  - Change line 14 to `<service name="GettingStartedLib.CalculatorService">`
  - Change line 17 to `<add baseAddress = "http://localhost:8000/GettingStarted/CalculatorService" />`
  - Change line 22 to `<endpoint address="" binding="wsHttpBinding" contract="GettingStartedLib.ICalculator">`

- For Visual Basic projects:
  - Change line 14 to `<service name="GettingStartedLib.GettingStartedLib.CalculatorService">`
  - Change line 17 to `<add baseAddress = "http://localhost:8000/GettingStarted/CalculatorService" />`
  - Change line 22 to `<endpoint address="" binding="wsHttpBinding" contract="GettingStartedLib.GettingStartedLib.ICalculator">`

## Compile the code

Build the solution to verify there aren't any compilation errors. If you're using Visual Studio, on the **Build** menu select **Build Solution** (or press **Ctrl**+**Shift**+**B**).

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> - Add code to implement the WCF service contract.
> - Build the solution.

Advance to the next tutorial to learn how to run the WCF service.

> [!div class="nextstepaction"]
> [Tutorial: Host and run a basic WCF service](how-to-host-and-run-a-basic-wcf-service.md)
