---
description: "Learn more about: ServiceDebugBehavior"
title: "ServiceDebugBehavior"
ms.date: "03/30/2017"
ms.assetid: a5ec9061-1e95-43fb-b0d9-dbd0a7bc3c44
---
# ServiceDebugBehavior

ServiceDebugBehavior  
  
## Syntax  
  
```csharp
class ServiceDebugBehavior : Behavior  
{  
  boolean HttpHelpPageEnabled;  
  string HttpHelpPageUrl;  
  boolean HttpsHelpPageEnabled;  
  string HttpsHelpPageUrl;  
  boolean IncludeExceptionDetailInFaults;  
};  
```  
  
## Methods  

 The ServiceDebugBehavior class does not define any methods.  
  
## Properties  

 The ServiceDebugBehavior class has the following properties:  
  
### HttpHelpPageEnabled  

 Data type: boolean  
  
 Access type: Read-only  
  
 Controls whether the service publishes its WSDL at the address controlled by the `HttpGetUrl` attribute.  
  
### HttpHelpPageUrl  

 Data type: string  
  
 Access type: Read-only  
  
 Sets the location at which the service WSDL is published for retrieval using HTTP.  
  
### HttpsHelpPageEnabled  

 Data type: boolean  
  
 Access type: Read-only  
  
 Controls whether the service publishes its WSDL over HTTPS at the address controlled by the `HttpsGetUrl` attribute.  
  
### HttpsHelpPageUrl  

 Data type: string  
  
 Access type: Read-only  
  
 Sets the location at which the service WSDL is published for retrieval using HTTPS.  
  
### IncludeExceptionDetailInFaults  

 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether to include managed exception information in the detail of SOAP faults returned to the clients for debugging purposes.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Description.ServiceDebugBehavior>
