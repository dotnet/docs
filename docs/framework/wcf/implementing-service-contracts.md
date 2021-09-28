---
description: "Learn more about: Implementing Service Contracts"
title: "Implementing Service Contracts"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "implementing service contracts [WCF]"
ms.assetid: aefb6f56-47e3-4f24-ab0a-9bc07bf9885f
---
# Implementing Service Contracts

A service is a class that exposes functionality available to clients at one or more endpoints. To create a service, write a class that implements a Windows Communication Foundation (WCF) contract. You can do this in one of two ways. You can define the contract separately as an interface and then create a class that implements that interface. Alternatively, you can create the class and contract directly by placing the <xref:System.ServiceModel.ServiceContractAttribute> attribute on the class itself and the <xref:System.ServiceModel.OperationContractAttribute> attribute on the methods available to the clients of the service.  
  
## Creating a service class  

 The following is an example of a service that implements an `IMath` contract that has been defined separately.  
  
```csharp  
// Define the IMath contract.  
[ServiceContract]  
public interface IMath  
{  
    [OperationContract]
    double Add(double A, double B);  
  
    [OperationContract]  
    double Multiply (double A, double B);  
}  
  
// Implement the IMath contract in the MathService class.  
public class MathService : IMath  
{  
    public double Add (double A, double B) { return A + B; }  
    public double Multiply (double A, double B) { return A * B; }  
}  
```  
  
 Alternatively, a service can expose a contract directly. The following is an example of a service class that defines and implements a `MathService` contract.  
  
```csharp  
// Define the MathService contract directly on the service class.  
[ServiceContract]  
class MathService  
{  
    [OperationContract]  
    public double Add(double A, double B) { return A + B; }  
    [OperationContract]  
    private double Multiply (double A, double B) { return A * B; }  
}  
```  
  
 Note that the preceding services expose different contracts because the contract names are different. In the first case, the exposed contract is named "`IMath`" while in the second case the contract is named "`MathService`".  
  
 You can set a few things at the service and operation implementation levels, such as concurrency and instancing. For more information, see [Designing and Implementing Services](designing-and-implementing-services.md).  
  
 After implementing a service contract, you must create one or more endpoints for the service. For more information, see [Endpoint Creation Overview](endpoint-creation-overview.md). For more information about how to run a service, see [Hosting Services](hosting-services.md).  
  
## See also

- [Designing and Implementing Services](designing-and-implementing-services.md)
- [How to: Create a Service with a Contract Class](./feature-details/how-to-create-a-wcf-contract-with-a-class.md)
- [How to: Create a Service with a Contract Interface](./feature-details/how-to-create-a-service-with-a-contract-interface.md)
- [Specifying Service Run-Time Behavior](specifying-service-run-time-behavior.md)
