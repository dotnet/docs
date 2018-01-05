---
title: "Deciding When to Implement the Event-based Asynchronous Pattern"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Event-based Asynchronous Pattern"
  - "ProgressChangedEventArgs class"
  - "BackgroundWorker component"
  - "events [.NET Framework], asynchronous"
  - "AsyncOperationManager class"
  - "threading [.NET Framework], asynchronous features"
  - "AsyncOperation class"
  - "AsyncCompletedEventArgs class"
ms.assetid: a00046aa-785d-4f7f-a8e5-d06475ea50da
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Deciding When to Implement the Event-based Asynchronous Pattern
The Event-based Asynchronous Pattern provides a pattern for exposing the asynchronous behavior of a class. With the introduction of this pattern, the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] defines two patterns for exposing asynchronous behavior: the Asynchronous Pattern based on the <xref:System.IAsyncResult?displayProperty=nameWithType> interface, and the event-based pattern. This topic describes when it is appropriate for you to implement both patterns.  
  
 For more information about asynchronous programming with the <xref:System.IAsyncResult> interface, see [Event-based Asynchronous Pattern (EAP)](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap.md).  
  
## General Principles  
 In general, you should expose asynchronous features using the Event-based Asynchronous Pattern whenever possible. However, there are some requirements that the event-based pattern cannot meet. In those cases, you may need to implement the <xref:System.IAsyncResult> pattern in addition to the event-based pattern.  
  
> [!NOTE]
>  It is rare for the <xref:System.IAsyncResult> pattern to be implemented without the event-based pattern also being implemented.  
  
## Guidelines  
 The following list describes the guidelines for when you should implement Event-based Asynchronous Pattern:  
  
-   Use the event-based pattern as the default API to expose asynchronous behavior for your class.  
  
-   Do not expose the <xref:System.IAsyncResult> pattern when your class is primarily used in a client application, for example Windows Forms.  
  
-   Only expose the <xref:System.IAsyncResult> pattern when it is necessary for meeting your requirements. For example, compatibility with an existing API may require you to expose the <xref:System.IAsyncResult> pattern.  
  
-   Do not expose the <xref:System.IAsyncResult> pattern without also exposing the event-based pattern.  
  
-   If you must expose the <xref:System.IAsyncResult> pattern, do so as an advanced option. For example, if you generate a proxy object, generate the event-based pattern by default, with an option to generate the <xref:System.IAsyncResult> pattern.  
  
-   Build your event-based pattern implementation on your <xref:System.IAsyncResult> pattern implementation.  
  
-   Avoid exposing both the event-based pattern and the <xref:System.IAsyncResult> pattern on the same class. Expose the event-based pattern on "higher level" classes and the <xref:System.IAsyncResult> pattern on "lower level" classes. For example, compare the event-based pattern on the <xref:System.Net.WebClient> component with the <xref:System.IAsyncResult> pattern on the <xref:System.Web.HttpRequest> class.  
  
    -   Expose the event-based pattern and the <xref:System.IAsyncResult> pattern on the same class when compatibility requires it. For example, if you have already released an API that uses the <xref:System.IAsyncResult> pattern, you would need to retain the <xref:System.IAsyncResult> pattern for backward compatibility.  
  
    -   Expose the event-based pattern and the <xref:System.IAsyncResult> pattern on the same class if the resulting object model complexity outweighs the benefit of separating the implementations. It is better to expose both patterns on a single class than to avoid exposing the event-based pattern.  
  
    -   If you must expose both the event-based pattern and <xref:System.IAsyncResult> pattern on a single class, use <xref:System.ComponentModel.EditorBrowsableAttribute> set to <xref:System.ComponentModel.EditorBrowsableState.Advanced> to mark the <xref:System.IAsyncResult> pattern implementation as an advanced feature. This indicates to design environments, such as [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] IntelliSense, not to display the <xref:System.IAsyncResult> properties and methods. These properties and methods are still fully usable, but the developer working through IntelliSense has a clearer view of the API.  
  
## Criteria for Exposing the IAsyncResult Pattern in Addition to the Event-based Pattern  
 While the Event-based Asynchronous Pattern has many benefits under the previously mentioned scenarios, it does have some drawbacks, which you should be aware of if performance is your most important requirement.  
  
 There are three scenarios that the event-based pattern does not address as well as the <xref:System.IAsyncResult> pattern:  
  
-   Blocking wait on one <xref:System.IAsyncResult>  
  
-   Blocking wait on many <xref:System.IAsyncResult> objects  
  
-   Polling for completion on the <xref:System.IAsyncResult>  
  
 You can address these scenarios by using the event-based pattern, but doing so is more cumbersome than using the <xref:System.IAsyncResult> pattern.  
  
 Developers often use the <xref:System.IAsyncResult> pattern for services that typically have very high performance requirements. For example, the polling for completion scenario is a high-performance server technique.  
  
 Additionally, the event-based pattern is less efficient than the <xref:System.IAsyncResult> pattern because it creates more objects, especially <xref:System.EventArgs>, and because it synchronizes across threads.  
  
 The following list shows some recommendations to follow if you decide to use the <xref:System.IAsyncResult> pattern:  
  
-   Only expose the <xref:System.IAsyncResult> pattern when you specifically require support for <xref:System.Threading.WaitHandle> or <xref:System.IAsyncResult> objects.  
  
-   Only expose the <xref:System.IAsyncResult> pattern when you have an existing API that uses the <xref:System.IAsyncResult> pattern.  
  
-   If you have an existing API based on the <xref:System.IAsyncResult> pattern, consider also exposing the event-based pattern in your next release.  
  
-   Only expose <xref:System.IAsyncResult> pattern if you have high performance requirements which you have verified cannot be met by the event-based pattern but can be met by the <xref:System.IAsyncResult> pattern.  
  
## See Also  
 [Walkthrough: Implementing a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md)  
 [Event-based Asynchronous Pattern (EAP)](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap.md)  
 [Multithreaded Programming with the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/multithreaded-programming-with-the-event-based-asynchronous-pattern.md)  
 [Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/implementing-the-event-based-asynchronous-pattern.md)  
 [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md)  
 [Event-based Asynchronous Pattern Overview](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md)
