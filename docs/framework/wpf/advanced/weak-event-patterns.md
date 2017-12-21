---
title: "Weak Event Patterns"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "weak event pattern implementation [WPF]"
  - "event handlers [WPF], weak event pattern"
  - "IWeakEventListener interface [WPF]"
ms.assetid: e7c62920-4812-4811-94d8-050a65c856f6
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Weak Event Patterns
In applications, it is possible that handlers that are attached to event sources will not be destroyed in coordination with the listener object that attached the handler to the source. This situation can lead to memory leaks. [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] introduces a design pattern that can be used to address this issue, by providing a dedicated manager class for particular events and implementing an interface on listeners for that event. This design pattern is known as the *weak event pattern*.  
  
## Why Implement the Weak Event Pattern?  
 Listening for events can lead to memory leaks. The typical technique for listening to an event is to use the language-specific syntax that attaches a handler to an event on a source. For example, in [!INCLUDE[TLA#tla_cshrp](../../../../includes/tlasharptla-cshrp-md.md)], that syntax is: `source.SomeEvent += new SomeEventHandler(MyEventHandler)`.  
  
 This technique creates a strong reference from the event source to the event listener. Ordinarily, attaching an event handler for a listener causes the listener to have an object lifetime that is influenced by the object lifetime of the source (unless the event handler is explicitly removed). But in certain circumstances, you might want the object lifetime of the listener to be controlled by other factors, such as whether it currently belongs to the visual tree of the application, and not by the lifetime of the source. Whenever the source object lifetime extends beyond the object lifetime of the listener, the normal event pattern leads to a memory leak: the listener is kept alive longer than intended.  
  
 The weak event pattern is designed to solve this memory leak problem. The weak event pattern can be used whenever a listener needs to register for an event, but the listener does not explicitly know when to unregister. The weak event pattern can also be used whenever the object lifetime of the source exceeds the useful object lifetime of the listener. (In this case, *useful* is determined by you.) The weak event pattern allows the listener to register for and receive the event without affecting the object lifetime characteristics of the listener in any way. In effect, the implied reference from the source does not determine whether the listener is eligible for garbage collection. The reference is a weak reference, thus the naming of the weak event pattern and the related [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)]. The listener can be garbage collected or otherwise destroyed, and the source can continue without retaining noncollectible handler references to a now destroyed object.  
  
## Who Should Implement the Weak Event Pattern?  
 Implementing the weak event pattern is interesting primarily for control authors. As a control author, you are largely responsible for the behavior and containment of your control and the impact it has on applications in which it is inserted. This includes the control object lifetime behavior, in particular the handling of the described memory leak problem.  
  
 Certain scenarios inherently lend themselves to the application of the weak event pattern. One such scenario is data binding. In data binding, it is common for the source object to be completely independent of the listener object, which is a target of a binding. Many aspects of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] data binding already have the weak event pattern applied in how the events are implemented.  
  
## How to Implement the Weak Event Pattern  
 There are three ways to implement weak event pattern. The following table lists the three approaches and provides some guidance for when you should use each.  
  
|Approach|When to Implement|  
|--------------|-----------------------|  
|Use an existing weak event manager class|If the event you want to subscribe to has a corresponding <xref:System.Windows.WeakEventManager>, use the existing weak event manager. For a list of weak event managers that are included with WPF, see the inheritance hierarchy in the <xref:System.Windows.WeakEventManager> class. Note, however, that there are relatively few weak event managers that are included with WPF, so you will probably need to choose one of the other approaches.|  
|Use a generic weak event manager class|Use a generic <xref:System.Windows.WeakEventManager%602> when an existing <xref:System.Windows.WeakEventManager> is not available, you want an easy way to implement, and you are not concerned about efficiency. The generic <xref:System.Windows.WeakEventManager%602> is less efficient than an existing or custom weak event manager. For example, the generic class does more reflection to discover the event given the event's name. Also, the code to register the event by using the generic <xref:System.Windows.WeakEventManager%602> is more verbose than using an existing or custom <xref:System.Windows.WeakEventManager>.|  
|Create a custom weak event manager class|Create a custom <xref:System.Windows.WeakEventManager> when an existing <xref:System.Windows.WeakEventManager> is not available and you want the best efficiency. Using a custom <xref:System.Windows.WeakEventManager> to subscribe to an event will be more efficient, but you do incur the cost of writing more code at the beginning.|  
  
 The following sections describe how to implement the weak event pattern.  For purposes of this discussion, the event to subscribe to has the following characteristics.  
  
-   The event name is `SomeEvent`.  
  
-   The event is raised by the `EventSource` class.  
  
-   The event handler has type: `SomeEventEventHandler` (or `EventHandler<SomeEventEventArgs>`).  
  
-   The event passes a parameter of type `SomeEventEventArgs` to the event handlers.  
  
### Using an Existing Weak Event Manager Class  
  
1.  Find an existing weak event manager.  
  
     For a list of weak event managers that are included with WPF, see the inheritance hierarchy in the <xref:System.Windows.WeakEventManager> class.  
  
2.  Use the new weak event manager instead of the normal event hookup.  
  
     For example, if your code uses the following pattern to subscribe to an event:  
  
    ```  
    source.SomeEvent += new SomeEventEventHandler(OnSomeEvent);  
    ```  
  
     Change it to the following pattern:  
  
    ```  
    SomeEventWeakEventManager.AddHandler(source, OnSomeEvent);  
    ```  
  
     Similarly, if your code uses the following pattern to unsubscribe to an event:  
  
    ```  
    source.SomeEvent -= new SomeEventEventHandler(OnSome);  
    ```  
  
     Change it to the following pattern:  
  
    ```  
    SomeEventWeakEventManager.RemoveHandler(source, OnSomeEvent);  
    ```  
  
### Using the Generic Weak Event Manager Class  
  
1.  Use the generic <xref:System.Windows.WeakEventManager%602> class instead of the normal event hookup.  
  
     When you use <xref:System.Windows.WeakEventManager%602> to register event listeners, you supply the event source and <xref:System.EventArgs> type as the type parameters to the class and call <xref:System.Windows.WeakEventManager%602.AddHandler%2A> as shown in the following code:  
  
    ```  
    WeakEventManager<EventSource, SomeEventEventArgs>.AddHandler(source, "SomeEvent", source_SomeEvent);  
    ```  
  
### Creating a Custom Weak Event Manager Class  
  
1.  Copy the following class template to your project.  
  
     This class inherits from the <xref:System.Windows.WeakEventManager> class.  
  
     [!code-csharp[WeakEvents#WeakEventManagerTemplate](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WeakEvents/CSharp/WeakEventManagerTemplate.cs#weakeventmanagertemplate)]  
  
2.  Replace the `SomeEventWeakEventManager` name with your own name.  
  
3.  Replace the three names described previously with the corresponding names for your event. (`SomeEvent`, `EventSource`, and `SomeEventEventArgs`)  
  
4.  Set the visibility (public / internal / private) of the weak event manager class to the same visibility as event it manages.  
  
5.  Use the new weak event manager instead of the normal event hookup.  
  
     For example, if your code uses the following pattern to subscribe to an event:  
  
    ```  
    source.SomeEvent += new SomeEventEventHandler(OnSomeEvent);  
    ```  
  
     Change it to the following pattern:  
  
    ```  
    SomeEventWeakEventManager.AddHandler(source, OnSomeEvent);  
    ```  
  
     Similarly, if your code uses the following pattern to unsubscribe to an event:  
  
    ```  
    source.SomeEvent -= new SomeEventEventHandler(OnSome);  
    ```  
  
     Change it to the following pattern:  
  
    ```  
    SomeEventWeakEventManager.RemoveHandler(source, OnSomeEvent);  
    ```  
  
## See Also  
 <xref:System.Windows.WeakEventManager>  
 <xref:System.Windows.IWeakEventListener>  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)
