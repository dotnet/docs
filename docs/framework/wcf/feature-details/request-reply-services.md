---
description: "Learn more about: Request-Reply Services"
title: "Request-Reply Services"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Communication Foundation [WCF], request-reply services"
  - "contracts [WCF], request-reply services"
  - "WCF [WCF], request-reply services"
  - "request-reply contracts [WCF]"
ms.assetid: 2fa710f1-47f4-4598-b063-3ab3bd22ebba
---
# Request-Reply Services

Request-reply services are the default type of operation contract in Windows Communication Foundation (WCF). Clients make calls to service operations and wait for a response from the service. You can perform calls to a service operation either synchronously, where the client blocks until it receives a response from the service or the call times, or asynchronously, where the client makes a call to the service operation, continues working, and receives the response from the service on another thread.  
  
 To create a request-reply service contract, define your service contract, and apply the <xref:System.ServiceModel.OperationContractAttribute> class to each operation, as shown in the following sample code.  
  
```csharp
[ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]  
public interface IRequestReplyCalculator  
{  
    [OperationContract]  
    double Add(double n1, double n2);  
}  
```  
  
 You do not have to set the  <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property to `false` because this is the default behavior.  
  
## See also

- [One-Way Services](one-way-services.md)
- [Duplex Services](duplex-services.md)
