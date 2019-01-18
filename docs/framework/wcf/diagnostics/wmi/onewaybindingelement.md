---
title: "OneWayBindingElement"
ms.date: "03/30/2017"
ms.assetid: 5c7e17c3-39b9-4214-ae08-9e6141734305
---
# OneWayBindingElement
OneWayBindingElement  
  
## Syntax  
  
```csharp
class OneWayBindingElement : BindingElement  
{  
  ChannelPoolSettings ChannelPoolSettings;  
  sint32 MaxAcceptedChannels;  
  boolean PacketRoutable;  
};  
```  
  
## Methods  
 The OneWayBindingElement class does not define any methods.  
  
## Properties  
 The OneWayBindingElement class has the following properties:  
  
### ChannelPoolSettings  
 Data type: ChannelPoolSettings  
  
 Access type: Read-only  
  
 The channel pool settings.  
  
### MaxAcceptedChannels  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of accepted channels.  
  
### PacketRoutable  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that indicates whether the packet is routable.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.OneWayBindingElement>
