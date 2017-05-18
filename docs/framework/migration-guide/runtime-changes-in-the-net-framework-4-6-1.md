---
title: "Runtime Changes in the .NET Framework 4.6.1 | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "runtime changes, .NET Framework"
  - "runtime changes, .NET Framework 4.6.1"
  - "application compatibility"
ms.assetid: 9d97421c-5fee-4523-98c9-a158e7e6a1ee
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Runtime Changes in the .NET Framework 4.6.1
In rare cases, runtime changes may affect existing apps that target the previous versions of the .NET Framework but run on a later version of the .NET Framework runtime. They also include differences in behavior between applications that run on different .NET Framework runtime environments. The [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] includes changes in the following areas:  
  
-   [Windows Communication Foundation (WCF)](#WCF)  
  
-   [Windows Presentation Foundation (WPF)](#WPF)  
  
<a name="WCF"></a>   
## Windows Communication Foundation (WCF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|WCF binding with the `TransportWithMessageCredential`  security mode|By default, WCF binding that uses the `TransportWithMessageCredential` security mode does not allow messages with an unsigned "to" header for asymmetric security keys. Starting with apps that run under the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)], it is possible to relax this requirement and receive messages that do not have signed "to" headers.|This is an opt-in behavior. To allow messages with unsigned "to" headers, add the following configuration setting to the [\<runtime>](../../../docs/framework/configure-apps/file-schema/runtime/runtime-element.md) section of the app’s configuration file:<br /><br /> `<runtime>     <AppContextSwitchOverrides value="Switch.System.ServiceModel.AllowUnsignedToHeader=true" />  </runtime>`<br /><br /> Because this is an opt-in feature, it should not affect the behavior of existing apps.|Edge|  
  
<a name="WPF"></a>   
## Windows Presentation Foundation (WPF)  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Windows.Controls.VirtualizingStackPanel?displayProperty=fullName>|When an <xref:System.Windows.Controls.ItemsControl> displays a collection using virtualization (<xref:System.Windows.Controls.VirtualizingStackPanel.IsVirtualizing%2A> = `true`) and item-scrolling (<xref:System.Windows.Controls.VirtualizingPanel.ScrollUnit%2A>=<xref:System.Windows.Controls.ScrollUnit?displayProperty=fullName>), and when the control scrolls to display an item whose height in pixels differs from its neighbors, the <xref:System.Windows.Controls.VirtualizingStackPanel?displayProperty=fullName> iterates over all items in the collection.   The UI is unresponsive during this iteration;  if the collection is large, this can be perceived as a hang.<br /><br /> This iteration occurs in other circumstances, even in releases prior to the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)]. For example, it occurs when pixel-scrolling (<xref:System.Windows.Controls.VirtualizingPanel.ScrollUnit%2A>=<xref:System.Windows.Controls.ScrollUnit?displayProperty=fullName>) upon encountering an item with a different pixel height, and when item-scrolling hierarchical data (such as in a <xref:System.Windows.Controls.TreeView> control or an <xref:System.Windows.Controls.ItemsControl> with grouping enabled) upon encountering an item with a different number of descendant items than its neighbors.<br /><br /> For the case of item-scrolling and different pixel heights, the iteration was introduced in the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] to fix bugs in the layout of hierarchical data.  It is not needed if the data is flat (has no hierarchy), and the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] does not do it in that case.|If the iteration occurs in the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)] but not in earlier releases -- that is, if the <xref:System.Windows.Controls.ItemsControl> is item-scrolling a flat list with items of different pixel height -- there are two remedies:<br /><br /> Install the  [.NET Framework 4.6.2](../../../docs/framework/install/guide-for-developers.md).<br /><br /> Install [hotfix HR 1605](https://support.microsoft.com/en-us/kb/3154529) for the [!INCLUDE[net_v461](../../../includes/net-v461-md.md)].|Minor|  
## See Also  
 [Application Compatibility in 4.6.1](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-6-1.md)