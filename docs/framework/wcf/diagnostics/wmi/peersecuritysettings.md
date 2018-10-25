---
title: "PeerSecuritySettings"
ms.date: "03/30/2017"
ms.assetid: 24ae0d35-f3a3-419b-afd6-686e22aae27b
---
# PeerSecuritySettings
PeerSecuritySettings  
  
## Syntax  
  
```csharp
class PeerSecuritySettings  
{  
  string Mode;  
  PeerTransportSecuritySettings Transport;  
};  
```  
  
## Methods  
 The PeerSecuritySettings class does not define any methods.  
  
## Properties  
 The PeerSecuritySettings class has the following properties:  
  
### Mode  
 Data type: string  
  
 Access type: Read-only  
  
 Whether message-level and transport-level security are used by an endpoint configured with the binding.  
  
### Transport  
 Data type: PeerTransportSecuritySettings  
  
 Access type: Read-only  
  
 Transport security settings.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.PeerSecuritySettings>
