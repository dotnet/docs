---
title: "How to: Create a Request-Reply Contract"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 801d90da-3d45-4284-9c9f-56c8aadb4060
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Request-Reply Contract
A request-reply contract specifies a method that returns a reply. The reply must be sent and correlated to the request under the terms of this contract. Even if the method returns no reply (`void` in C#, or a `Sub` in Visual Basic), the infrastructure creates and sends an empty message to the caller. To prevent the sending of an empty reply message, use a one-way contract for the operation.  
  
### To create a request-reply contract  
  
1.  Create an interface in the programming language of your choice.  
  
2.  Apply the <xref:System.ServiceModel.ServiceContractAttribute> attribute to the interface.  
  
3.  Apply the <xref:System.ServiceModel.OperationContractAttribute> attribute to each method that clients can invoke.  
  
4.  Optional. Set the value of the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property to `true` to prevent the sending of an empty reply message. By default, all operations are request-reply contracts.  
  
## Example  
 The following sample defines a contract for a calculator service that provides `Add` and `Subtract` methods. The `Multiply` method is not part of the contract because it is not marked by the <xref:System.ServiceModel.OperationContractAttribute> class and so it is not accessible to clients.  
  
```
using System.ServiceModel;

[ServiceContract]
public interface ICalculator
{
    [OperationContract]
    // It would be equivalent to write explicitly:
    // [OperationContract(IsOneWay=false)]
    int Add(int a, int b);
    
    [OperationContract]
    int Subtract(int a, int b);
    
    int Multiply(int a, int b)
}
```
  
-   [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to specify operation contracts, see the <xref:System.ServiceModel.OperationContractAttribute> class and the <xref:System.ServiceModel.OperationContractAttribute.IsOneWay%2A> property.  
  
-   Applying the <xref:System.ServiceModel.ServiceContractAttribute> and <xref:System.ServiceModel.OperationContractAttribute> attributes causes the automatic generation of service contract definitions in a Web Services Description Language (WSDL) document once the service is deployed. The document is downloaded by appending `?wsdl` to the HTTP base address for the service. For example, `http://microsoft/CalculatorService?wsdl`  
  
## See Also  
 <xref:System.ServiceModel.OperationContractAttribute>  
 [Designing Service Contracts](../../../../docs/framework/wcf/designing-service-contracts.md)  
 [How to: Create a Duplex Contract](../../../../docs/framework/wcf/feature-details/how-to-create-a-duplex-contract.md)
