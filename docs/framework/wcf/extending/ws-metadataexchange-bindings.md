---
description: "Learn more about: WS-MetadataExchange Bindings"
title: "WS-MetadataExchange Bindings"
ms.date: "03/30/2017"
ms.topic: reference
---
# WS-MetadataExchange Bindings

This topic describes how the default metadata exchange bindings are constructed for various transports.  
  
## The Default Bindings  
  
|Default Binding Name|How the binding is constructed|  
|--------------------------|------------------------------------|  
|mexHttpBinding|A <xref:System.ServiceModel.WSHttpBinding> with transport-level security disabled.|  
|mexHttpsBinding|A <xref:System.ServiceModel.WSHttpBinding> that supports transport-level security.|  
|mexNamedPipeBinding|A  <xref:System.ServiceModel.Channels.CustomBinding> with a <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement> using the default values.|  
|mexTcpBinding|A <xref:System.ServiceModel.Channels.CustomBinding> with a <xref:System.ServiceModel.Channels.TcpTransportBindingElement> using default values.|
