---
title: "TransactionFlowBindingElement"
ms.date: "03/30/2017"
ms.assetid: 0a9656fe-2400-45ca-ad79-92715c8cf190
---
# TransactionFlowBindingElement
TransactionFlowBindingElement  
  
## Syntax  
  
```csharp
class TransactionFlowBindingElement : BindingElement  
{  
  string IssuedTokens;  
  string TransactionProtocol;  
  boolean Transactions;  
};  
```  
  
## Methods  
 The TransactionFlowBindingElement class does not define any methods.  
  
## Properties  
 The TransactionFlowBindingElement class has the following properties:  
  
### IssuedTokens  
 Data type: string  
  
 Access type: Read-only  
  
 Specifies the requirement for an issued security tokens header (IssuedTokens from WS-Trust).  
  
### TransactionProtocol  
 Data type: string  
  
 Access type: Read-only  
  
 The transactions protocol used by the service to flow transactions.  
  
### Transactions  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether the incoming transaction is supported.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Channels.TransactionFlowBindingElement>
