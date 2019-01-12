---
title: "Tutorial: Host and run a basic Windows Communication Foundation service"
ms.date: 01/10/2019
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "WCF services [WCF]"
  - "WCF services [WCF], running"
ms.assetid: 31774d36-923b-4e2d-812e-aa190127266f
---
# Tutorial: Host and run a basic Windows Communication Foundation service

This tutorial describes the third of six tasks required to create a basic Windows Communication Foundation (WCF) application. For an overview of the tutorials, see [Getting started tutorial](getting-started-tutorial.md).

The next step in creating a WCF application is to host a Windows Communication Foundation (WCF) service in a console application. This procedure consists of the following steps:

- Create a console application project for hosting the service.

- Create a service host for the service.

- Enable metadata exchange.

- Open the service host.

A complete listing of the code written in this task is provided in the example following the procedure.

## Create a console application for hosting the service

1. Create a Console Application project in Visual Studio. 
 
    1. Right-click the Getting Started solution and select **Add** > **New Project**. 

    2. In the **Add New Project** window, on the left-hand side, select the **Windows Desktop** category under **Visual C#** or **Visual Basic**. 

    3. Select the **Console App (.NET Framework)** template, and then name the project **GettingStartedHost**.

2. Add a reference to the GettingStartedLib project to the GettingStartedHost project. 

    1. Right-click the **References** folder under the GettingStartedHost project in **Solution Explorer**, and then select **Add Reference**. 

    2. In the **Add Reference** dialog, select **Solution** on the left side of the window, select **GettingStartedLib** in the center section of the window, and then choose **Add**. This action makes the types defined in GettingStartedLib available to the GettingStartedHost project.

3. Add a reference to System.ServiceModel to the GettingStartedHost project. 

    1. Right-click the **References** folder under the GettingStartedHost project in **Solution Explorer** and select **Add Reference**.
    
    2. In the **Add Reference** window, select **Framework** under **Assemblies** on the left side of the window. 

    3. Find and select **System.ServiceModel**, and then choose **OK**. 
    
    4. Save the solution by selecting **File** > **Save All**.

## Host the service

Open the Program.cs or Module.vb file and enter the following code:

```csharp
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using GettingStartedLib;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            // Step 2 Create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                // Step 4 Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
```

```vb
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports GettingStartedLibVB.GettingStartedLib

Module Service

    Class Program
        Shared Sub Main()
            ' Step 1 Create a URI to serve as the base address
            Dim baseAddress As New Uri("http://localhost:8000/ServiceModelSamples/Service")

            ' Step 2 Create a ServiceHost instance
            Dim selfHost As New ServiceHost(GetType(CalculatorService), baseAddress)
           Try

                ' Step 3 Add a service endpoint
                ' Add a service endpoint
                selfHost.AddServiceEndpoint( _
                    GetType(ICalculator), _
                    New WSHttpBinding(), _
                    "CalculatorService")

                ' Step 4 Enable metadata exchange.
                Dim smb As New ServiceMetadataBehavior()
                smb.HttpGetEnabled = True
                selfHost.Description.Behaviors.Add(smb)

                ' Step 5 Start the service
                selfHost.Open()
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHostBase to shutdown the service.
                selfHost.Close()
            Catch ce As CommunicationException
                Console.WriteLine("An exception occurred: {0}", ce.Message)
                selfHost.Abort()
            End Try
        End Sub
    End Class

End Module
```

**Step 1** - Creates an instance of the `Uri` class to hold the base address of the service. A URL that contains a base address and an optional URI identifies a service. The base address is formatted as follows: <transport>://<machine-name or domain><:optional port #>/<optional URI segment>. The base address for the calculator service uses the HTTP transport, localhost, port 8000, and the URI segment, GettingStarted.

**Step 2** – Creates an instance of the <xref:System.ServiceModel.ServiceHost> class to host the service. The constructor takes two parameters, the type of the class that implements the service contract, and the base address of the service.

**Step 3** – Creates a <xref:System.ServiceModel.Description.ServiceEndpoint> instance. A service endpoint is composed of an address, a binding, and a service contract. The <xref:System.ServiceModel.Description.ServiceEndpoint> constructor is composed of the service contract interface type, a binding, and an address. The service contract is `ICalculator`, which you defined and implement in the service type. The binding for this sample is <xref:System.ServiceModel.WSHttpBinding>. It's a built-in binding and connects to endpoints that conform to the WS-* specifications. For more information about WCF bindings, see [WCF Bindings Overview](bindings-overview.md). The address is appended to the base address to identify the endpoint. The address specified in this code is CalculatorService and the fully qualified address for the endpoint is `"http://localhost:8000/GettingStarted/CalculatorService"`.

    > [!IMPORTANT]
    > Adding a service endpoint is optional for .NET Framework Version 4 or later. In these versions, if you don't add in your code or configuration, WCF adds one default endpoint for each combination of base address and contract implemented by the service. For more information about default endpoints see [Specifying an Endpoint Address](specifying-an-endpoint-address.md). For more information about default endpoints, bindings, and behaviors, see [Simplified Configuration](simplified-configuration.md) and [Simplified Configuration for WCF Services](samples/simplified-configuration-for-wcf-services.md).

**Step 4** – Enable metadata exchange. Clients use metadata exchange to generate proxies that are used to call the service operations. To enable metadata exchange create a <xref:System.ServiceModel.Description.ServiceMetadataBehavior> instance, set its <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpGetEnabled%2A> property to `true`, and add the behavior to the <!--zz <xref:System.ServiceModel.ServiceHost.Behaviors%2A>  -->`System.ServiceModel.ServiceHost.Behaviors%2A` collection of the <xref:System.ServiceModel.ServiceHost> instance.

**Step 5** – Open the <xref:System.ServiceModel.ServiceHost> to listen for incoming messages. Notice the code waits for the user to press enter. If you don't press enter, the app closes immediately and the service shuts down. Also, notice a try/catch block is used. After the <xref:System.ServiceModel.ServiceHost> has been instantiated, all other code is placed in a try/catch block. For more information about safely catching exceptions thrown by <xref:System.ServiceModel.ServiceHost>, see [Use Close and Abort to release WCF client resources](samples/use-close-abort-release-wcf-client-resources.md).

> [!IMPORTANT]
> Edit App.config in GettingStartedLib to reflect the changes made in code:
> 1. Change line 14 to `<service name="GettingStartedLib.CalculatorService">`
> 2. Change line 17 to `<add baseAddress = "http://localhost:8000/GettingStarted/CalculatorService" />`
> 3. Change line 22 to `<endpoint address="" binding="wsHttpBinding" contract="GettingStartedLib.ICalculator">`

## Verify the service is working

1. Run the GettingStartedHost console application from inside Visual Studio.

   Run the service with administrator privileges. Because you opened Visual Studio with administrator privileges, you should also run GettingStartedHost with administrator privileges. As an alternative, you can open a new command prompt by using **Run as administrator** and run service.exe within it.

2. Open a web browser and browse to the service's debug page at `http://localhost:8000/GettingStarted/CalculatorService`.

## Example

The following example includes the service contract and implementation from previous steps in the tutorial and hosts the service in a console application.

To compile them with a command-line compiler, compile IService1.cs and Service1.cs into a class library that references `System.ServiceModel.dll`. Compile Program.cs as a console application.

```csharp
using System;
using System.ServiceModel;

namespace GettingStartedLib
{
        [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
        public interface ICalculator
        {
            [OperationContract]
            double Add(double n1, double n2);
            [OperationContract]
            double Subtract(double n1, double n2);
            [OperationContract]
            double Multiply(double n1, double n2);
            [OperationContract]
            double Divide(double n1, double n2);
        }
}
```

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

```csharp
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using GettingStartedLib;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/Service");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                // Step 4 of the hosting procedure: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
```

```vb
Imports System.ServiceModel

Namespace GettingStartedLib

    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface
End Namespace
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

```vb
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports GettingStartedLibVB.GettingStartedLib

Module Service

    Class Program
        Shared Sub Main()
            ' Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Dim baseAddress As New Uri("http://localhost:8000/ServiceModelSamples/Service")

            ' Step 2 of the hosting procedure: Create ServiceHost
            Dim selfHost As New ServiceHost(GetType(CalculatorService), baseAddress)
            Try

                ' Step 3 of the hosting procedure: Add a service endpoint.
                ' Add a service endpoint
                selfHost.AddServiceEndpoint( _
                    GetType(ICalculator), _
                    New WSHttpBinding(), _
                    "CalculatorService")

                ' Step 4 of the hosting procedure: Enable metadata exchange.
                ' Enable metadata exchange
                Dim smb As New ServiceMetadataBehavior()
                smb.HttpGetEnabled = True
                selfHost.Description.Behaviors.Add(smb)

                ' Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open()
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHostBase to shutdown the service.
                selfHost.Close()
            Catch ce As CommunicationException
                Console.WriteLine("An exception occurred: {0}", ce.Message)
                selfHost.Abort()
            End Try
        End Sub
    End Class

End Module
```

> [!NOTE]
> Services such as this one require permission to register HTTP addresses on the machine for listening. Administrator accounts have this permission, but non-administrator accounts must be granted permission for HTTP namespaces. For more information about how to configure namespace reservations, see [Configuring HTTP and HTTPS](../../../docs/framework/wcf/feature-details/configuring-http-and-https.md). When running under Visual Studio, the service.exe must be run with administrator privileges.

## Next steps

Now the service is running. In the next task, you create a WCF client.

> [!div class="nextstepaction"]
> [How to: Create a WCF client](how-to-create-a-wcf-client.md)

For troubleshooting information, see [Troubleshooting the Getting Started Tutorial](troubleshooting-the-getting-started-tutorial.md).

## See also

- [Getting started sample](samples/getting-started-sample.md)
- [Self-Host](samples/self-host.md)