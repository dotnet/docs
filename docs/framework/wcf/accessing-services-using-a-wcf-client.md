---
title: "Accessing Services Using a WCF Client"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "clients [WCF], consuming services"
ms.assetid: d780af9f-73c5-42db-9e52-077a5e4de7fe
caps.latest.revision: 36
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Accessing Services Using a WCF Client
After you create a service, the next step is to create a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client proxy. A client application uses the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client proxy to communicate with the service. Client applications usually import a service's metadata to generate [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client code that can be used to invoke the service.  
  
 The basic steps for creating a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client include the following:  
  
1.  Compile the service code.  
  
2.  Generate the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client proxy.  
  
3.  Instantiate the WCF client proxy.  
  
 The WCF client proxy can be generated manually by using the Service Model Metadata Utility Tool (SvcUtil.exe) for more information see, [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). The WCF client proxy can also be generated within Visual Studio using the Add Service Reference  feature. To generate the WCF client proxy using either method the service must be running. If the service is self-hosted you must run the host. If the service is hosted in IIS/WAS you do not need to do anything else.  
  
## ServiceModel Metadata Utility Tool  
 The [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) is a command-line tool for generating code from metadata. The following use is an example of a basic Svcutil.exe command.  
  
```  
Svcutil.exe <service's Metadata Exchange (MEX) address or HTTP GET address>   
```  
  
 Alternatively, you can use Svcutil.exe with Web Services Description Language (WSDL) and XML Schema definition language (XSD) files on the file system.  
  
```  
Svcutil.exe <list of WSDL and XSD files on file system>  
```  
  
 The result is a code file that contains [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client code that the client application can use to invoke the service.  
  
 You can also use the tool to generate configuration files.  
  
```  
Svcutil.exe <file1 [,file2]>  
```  
  
 If only one file name is given, that is the name of the output file. If two file names are given, then the first file is an input configuration file whose contents are merged with the generated configuration and written out into the second file. [!INCLUDE[crabout](../../../includes/crabout-md.md)] configuration, see [Configuring Bindings for Services](../../../docs/framework/wcf/configuring-bindings-for-wcf-services.md).  
  
> [!IMPORTANT]
>  Unsecured metadata requests pose certain risks in the same way that any unsecured network request does: If you are not certain that the endpoint you are communicating with is who it says it is, the information you retrieve might be metadata from a malicious service.  
  
## Add Service Reference in Visual Studio  
 With the service running, right click the project that will contain the WCF client proxy and select **Add Service Reference**. In the **Add Service Reference Dialog** type in the URL to the service you want to call and click the **Go** button. The dialog will display a list of services available at the address you specify. Double click the service to see the contracts and operations available, specify a namespace for the generated code and click the **OK** button.  
  
## Example  
 The following code example shows a service contract created for a service.  
  
```csharp
// Define a service contract.
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface ICalculator
{
    [OperationContract]
    double Add(double n1, double n2);
    // Other methods are not shown here.
}
```
  
```vb
' Define a service contract.
<ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
Public Interface ICalculator
    <OperationContract()>  _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
    ' Other methods are not shown here.
End Interface
```
  
 The ServiceModel Metadata utility tool and Add Service Reference in Visual Studio generates the following [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client class. The class inherits from the generic <xref:System.ServiceModel.ClientBase%601> class and implements the `ICalculator` interface. The tool also generates the `ICalculator` interface (not shown here).  
  
```csharp
public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
{
    public CalculatorClient()
    {}

    public CalculatorClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {}

    public CalculatorClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {}

    public CalculatorClient(string endpointConfigurationName,
        System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {}

    public CalculatorClient(System.ServiceModel.Channels.Binding binding,
        System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {}

    public double Add(double n1, double n2)
    {
        return base.Channel.Add(n1, n2);
    }
}
```  
  
```vb  
Partial Public Class CalculatorClient
    Inherits System.ServiceModel.ClientBase(Of ICalculator)
    Implements ICalculator

    Public Sub New()
        MyBase.New
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String)
        MyBase.New(endpointConfigurationName)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal endpointConfigurationName As String,
        ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(endpointConfigurationName, remoteAddress)
    End Sub

    Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding,
        ByVal remoteAddress As System.ServiceModel.EndpointAddress)
        MyBase.New(binding, remoteAddress)
    End Sub

    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        Implements ICalculator.Add
        Return MyBase.Channel.Add(n1, n2)
    End Function
End Class
```
  
## Using the WCF Client  
 To use the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client, create an instance of the [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client, and then call its methods, as shown in the following code.  
  
```csharp
// Create a client object with the given client endpoint configuration.
CalculatorClient calcClient = new CalculatorClient("CalculatorEndpoint"));
// Call the Add service operation.
double value1 = 100.00D;
double value2 = 15.99D;
double result = calcClient.Add(value1, value2);
Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
```
  
```vb
' Create a client object with the given client endpoint configuration.
Dim calcClient As CalculatorClient = _
New CalculatorClient("CalculatorEndpoint")

' Call the Add service operation.
Dim value1 As Double = 100.00D
Dim value2 As Double = 15.99D
Dim result As Double = calcClient.Add(value1, value2)
Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)
```
  
## Debugging Exceptions Thrown by a Client  
 Many exceptions thrown by a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] client are caused by an exception on the service. Some examples of this are:  
  
-   <xref:System.Net.Sockets.SocketException>: An existing connection was forcibly closed by the remote host.  
  
-   <xref:System.ServiceModel.CommunicationException>: The underlying connection was closed unexpectedly.  
  
-   <xref:System.ServiceModel.CommunicationObjectAbortedException>: The socket connection was aborted. This could be caused by an error processing your message, a receive time-out being exceeded by the remote host, or an underlying network resource issue.  
  
 When these types of exceptions occur, the best way to solve the problem is to turn on tracing on the service side and determine what exception occurred there. [!INCLUDE[crabout](../../../includes/crabout-md.md)] tracing, see [Tracing](../../../docs/framework/wcf/diagnostics/tracing/index.md) and [Using Tracing to Troubleshoot Your Application](../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md).  
  
## See Also  
 [How to: Create a Client](../../../docs/framework/wcf/how-to-create-a-wcf-client.md)  
 [How to: Access Services with a Duplex Contract](../../../docs/framework/wcf/feature-details/how-to-access-services-with-a-duplex-contract.md)  
 [How to: Call Service Operations Asynchronously](../../../docs/framework/wcf/feature-details/how-to-call-wcf-service-operations-asynchronously.md)  
 [How to: Access Services with One-Way and Request-Reply Contracts](../../../docs/framework/wcf/feature-details/how-to-access-wcf-services-with-one-way-and-request-reply-contracts.md)  
 [How to: Access a WSE 3.0 Service](../../../docs/framework/wcf/feature-details/how-to-access-a-wse-3-0-service-with-a-wcf-client.md)  
 [Understanding Generated Client Code](../../../docs/framework/wcf/feature-details/understanding-generated-client-code.md)  
 [How to: Improve the Startup Time of WCF Client Applications using the XmlSerializer](../../../docs/framework/wcf/feature-details/startup-time-of-wcf-client-applications-using-the-xmlserializer.md)  
 [Specifying Client Run-Time Behavior](../../../docs/framework/wcf/specifying-client-run-time-behavior.md)  
 [Configuring Client Behaviors](../../../docs/framework/wcf/configuring-client-behaviors.md)
