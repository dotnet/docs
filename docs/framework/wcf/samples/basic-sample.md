---
description: "Learn more about: Basic Sample"
title: "Basic Sample"
ms.date: "03/30/2017"
ms.assetid: c1910bc1-3d0a-4fa6-b12a-4ed6fe759620
---
# Basic Sample

The [Basic discovery sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Discovery/Basic) shows how to make a service discoverable and how to search for and call a discoverable service. This sample is composed of two projects: service and client.

> [!NOTE]
> This sample implements discovery in code. For a sample that implements discovery in configuration, see [Configuration](configuration-sample.md).

## Service

This is a simple calculator service implementation. The discovery related code can be found in `Main` where a <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> is added to the service host and a <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> is added as shown in the following code.

```csharp
using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
{
    serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new
      WSHttpBinding(), String.Empty);

    // Make the service discoverable over UDP multicast
    serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
    serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

    serviceHost.Open();
    // ...
}
```

## Client

The client uses a <xref:System.ServiceModel.Discovery.DynamicEndpoint> to locate the service. The <xref:System.ServiceModel.Discovery.DynamicEndpoint>, a standard endpoint, resolves the endpoint of the service when the client is opened. In this case, the <xref:System.ServiceModel.Discovery.DynamicEndpoint> looks for the service based on the service contract. The <xref:System.ServiceModel.Discovery.DynamicEndpoint> conducts the search over a <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> by default. Once it locates a service endpoint, the client connects to that service over the specified binding.

```csharp
public static void Main()
{
   DynamicEndpoint dynamicEndpoint = new DynamicEndpoint( ContractDescription.GetContract(typeof(ICalculatorService)), new WSHttpBinding());
   // ...
}
```

The client defines a method called `InvokeCalculatorService` that uses the <xref:System.ServiceModel.Discovery.DiscoveryClient> class to search for services. The <xref:System.ServiceModel.Discovery.DynamicEndpoint> inherits from <xref:System.ServiceModel.Description.ServiceEndpoint>, so it can be passed to the `InvokeCalculatorService` method. The example then uses the <xref:System.ServiceModel.Discovery.DynamicEndpoint> to create an instance of `CalculatorServiceClient` and calls the various operations of the calculator service.

```csharp
static void InvokeCalculatorService(ServiceEndpoint serviceEndpoint)
{
   // Create a client
   CalculatorServiceClient client = new CalculatorServiceClient(serviceEndpoint);

   Console.WriteLine("Invoking CalculatorService");
   Console.WriteLine();

   double value1 = 100.00D;
   double value2 = 15.99D;

   // Call the Add service operation.
   double result = client.Add(value1, value2);
   Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

   // Call the Subtract service operation.
   result = client.Subtract(value1, value2);
   Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

   // Call the Multiply service operation.
   result = client.Multiply(value1, value2);
   Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

   // Call the Divide service operation.
   result = client.Divide(value1, value2);
   Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
   Console.WriteLine();

   //Closing the client gracefully closes the connection and cleans up resources
   client.Close();
}
```

#### To use this sample

1. This sample uses HTTP endpoints and to run this sample, proper URL ACLs must be added. For more information, see [Configuring HTTP and HTTPS](../feature-details/configuring-http-and-https.md). Executing the following command at an elevated privilege should add the appropriate ACLs. You may want to substitute your Domain and Username for the following arguments if the command does not work as is. `netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%`

2. Using Visual Studio, open the Basic.sln and build the sample.

3. Run the service.exe application.

4. After the service has started, run the client.exe.

5. Observe that the client was able to find the service without knowing its address.
