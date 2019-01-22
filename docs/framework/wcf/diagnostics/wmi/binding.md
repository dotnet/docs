---
title: "Binding2"
ms.date: "03/30/2017"
ms.assetid: 09511c6c-5749-4bb0-874e-0f0be36bfe04
---
# Binding
wmi Binding  
  
## Syntax  
  
```csharp
class Binding  
{  
  BindingElement BindingElements[];  
  datetime CloseTimeout;  
  string Name;  
  string Namespace;  
  datetime OpenTimeout;  
  datetime ReceiveTimeout;  
  string Scheme;  
  datetime SendTimeout;  
};  
```  
  
## Methods  
 The Binding class does not define any methods.  
  
## Properties  
 The Binding class has the following properties.  
  
### BindingElements  
 Data type: BindingElement array  
  
 Access type: Read-only  
  
 The collection of binding elements implemented by the binding.  
  
### CloseTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The interval of time provided for a close operation to complete.  
  
### Name  
 Data type: string  
  
 Access type: Read-only  
  
 The name of the binding.  
  
### Namespace  
 Data type: string  
  
 Access type: Read-only  
  
 The XML namespace of the binding.  
  
### OpenTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The interval of time provided for an open operation to complete.  
  
### ReceiveTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The interval of time provided for a receive operation to complete.  
  
### Scheme  
 Data type: string  
  
 Access type: Read-only  
  
 The URI transport scheme that is used by the channel and listener factories that are built by the binding.  
  
### SendTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The interval of time provided for a send operation to complete.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also
 <xref:System.ServiceModel.Channels.Binding>
