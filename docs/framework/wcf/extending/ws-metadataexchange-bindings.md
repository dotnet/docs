---
title: "WS-MetadataExchange Bindings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 10f8de5d-b81d-4ea7-b37e-7f2c00c39714
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WS-MetadataExchange Bindings
This topic describes how the default metadata exchange bindings are constructed for various transports.  
  
## The Default Bindings  
  
|Default Binding Name|How the binding is constructed|  
|--------------------------|------------------------------------|  
|MexHttpBinding|A <xref:System.ServiceModel.WSHttpBinding> with transport-level security disabled.|  
|MexHttpsBinding|A <xref:System.ServiceModel.WSHttpBinding> that supports transport-level security.|  
|MexNamedPipeBinding|A  <xref:System.ServiceModel.Channels.CustomBinding> with a <xref:System.ServiceModel.Channels.NamedPipeTransportBindingElement> using the default values.|  
|MexTcpBinding|A <xref:System.ServiceModel.Channels.CustomBinding> with a <xref:System.ServiceModel.Channels.TcpTransportBindingElement> using default values.|
