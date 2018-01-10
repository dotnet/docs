---
title: "Handling and Raising Events"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "delegate model for events"
  - "application development [.NET Framework], events"
  - "events [.NET Framework]"
ms.assetid: b6f65241-e0ad-4590-a99f-200ce741bb1f
caps.latest.revision: 23
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Handling and Raising Events
Events in the .NET Framework are based on the delegate model. The delegate model follows the observer design pattern, which enables a subscriber to register with, and receive notifications from, a provider. An event sender pushes a notification that an event has happened, and an event receiver receives that notification and defines a response to it. This article describes the major components of the delegate model, how to consume events in applications, and how to implement events in your code.  
  
 For information about handling events in [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps, see [Events and routed events overview (Windows store apps)](http://go.microsoft.com/fwlink/p/?LinkId=261485).  
  
## Events  
 An event is a message sent by an object to signal the occurrence of an action. The action could be caused by user interaction, such as a button click, or it could be raised by some other program logic, such as changing a property’s value. The object that raises the event is called the *event sender*. The event sender doesn't know which object or method will receive (handle) the events it raises. The event is typically a member of the event sender; for example, the <xref:System.Web.UI.WebControls.Button.Click> event is a member of the <xref:System.Web.UI.WebControls.Button> class, and the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event is a member of the class that implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface.  
  
 To define an event, you use the `event` (in C#) or `Event` (in Visual Basic) keyword in the signature of your event class, and specify the type of delegate for the event. Delegates are described in the next section.  
  
 Typically, to raise an event, you add a method that is marked as `protected` and `virtual` (in C#) or `Protected` and `Overridable` (in Visual Basic). Name this method `On`*EventName*; for example, `OnDataReceived`. The method should take one parameter that specifies an event data object. You provide this method to enable derived classes to override the logic for raising the event. A derived class should always call the `On`*EventName* method of the base class to ensure that registered delegates receive the event.  
  
 The following example shows how to declare an event named `ThresholdReached`. The event is associated with the <xref:System.EventHandler> delegate and raised in a method named `OnThresholdReached`.  
  
 [!code-csharp[EventsOverview#1](../../../samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#1)]
 [!code-vb[EventsOverview#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#1)]  
  
## Delegates  
 A delegate is a type that holds a reference to a method. A delegate is declared with a signature that shows the return type and parameters for the methods it references, and can hold references only to methods that match its signature. A delegate is thus equivalent to a type-safe function pointer or a callback. A delegate declaration is sufficient to define a delegate class.  
  
 Delegates have many uses in the .NET Framework. In the context of events, a delegate is an intermediary (or pointer-like mechanism) between the event source and the code that handles the event. You associate a delegate with an event by including the delegate type in the event declaration, as shown in the example in the previous section. For more information about delegates, see the <xref:System.Delegate> class.  
  
 The .NET Framework provides the <xref:System.EventHandler> and <xref:System.EventHandler%601> delegates to support most event scenarios. Use the <xref:System.EventHandler> delegate for all events that do not include event data. Use the <xref:System.EventHandler%601> delegate for events that include data about the event. These delegates have no return type value and take two parameters (an object for the source of the event and an object for event data).  
  
 Delegates are multicast, which means that they can hold references to more than one event-handling method. For details, see the <xref:System.Delegate> reference page. Delegates provide flexibility and fine-grained control in event handling. A delegate acts as an event dispatcher for the class that raises the event by maintaining a list of registered event handlers for the event.  
  
 For scenarios where the <xref:System.EventHandler> and <xref:System.EventHandler%601> delegates do not work, you can define a delegate. Scenarios that require you to define a delegate are very rare, such as when you must work with code that does not recognize generics. You mark a delegate with the `delegate` in (C#) and `Delegate` (in Visual Basic) keyword in the declaration. The following example shows how to declare a delegate named `ThresholdReachedEventHandler`.  
  
 [!code-csharp[EventsOverview#4](../../../samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#4)]
 [!code-vb[EventsOverview#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#4)]  
  
## Event Data  
 Data that is associated with an event can be provided through an event data class. The .NET Framework provides many event data classes that you can use in your applications. For example, the <xref:System.IO.Ports.SerialDataReceivedEventArgs> class is the event data class for the <xref:System.IO.Ports.SerialPort.DataReceived?displayProperty=nameWithType> event. The .NET Framework follows a naming pattern of ending all event data classes with `EventArgs`. You determine which event data class is associated with an event by looking at the delegate for the event. For example, the <xref:System.IO.Ports.SerialDataReceivedEventHandler> delegate includes the <xref:System.IO.Ports.SerialDataReceivedEventArgs> class as one of its parameters.  
  
 The <xref:System.EventArgs> class is the base type for all event data classes. <xref:System.EventArgs> is also the class you use when an event does not have any data associated with it. When you create an event that is only meant to notify other classes that something happened and does not need to pass any data, include the <xref:System.EventArgs> class as the second parameter in the delegate. You can pass the <xref:System.EventArgs.Empty?displayProperty=nameWithType> value when no data is provided. The <xref:System.EventHandler> delegate includes the <xref:System.EventArgs> class as a parameter.  
  
 When you want to create a customized event data class, create a class that derives from <xref:System.EventArgs>, and then provide any members needed to pass data that is related to the event. Typically, you should use the same naming pattern as the .NET Framework and end your event data class name with `EventArgs`.  
  
 The following example shows an event data class named `ThresholdReachedEventArgs`. It contains properties that are specific to the event being raised.  
  
 [!code-csharp[EventsOverview#3](../../../samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#3)]
 [!code-vb[EventsOverview#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#3)]  
  
## Event Handlers  
 To respond to an event, you define an event handler method in the event receiver. This method must match the signature of the delegate for the event you are handling. In the event handler, you perform the actions that are required when the event is raised, such as collecting user input after the user clicks a button. To receive notifications when the event occurs, your event handler method must subscribe to the event.  
  
 The following example shows an event handler method named `c_ThresholdReached` that matches the signature for the <xref:System.EventHandler> delegate. The method subscribes to the `ThresholdReached` event.  
  
 [!code-csharp[EventsOverview#2](../../../samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programtruncated.cs#2)]
 [!code-vb[EventsOverview#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1truncated.vb#2)]  
  
## Static and Dynamic Event Handlers  
 The .NET Framework allows subscribers to register for event notifications either statically or dynamically. Static event handlers are in effect for the entire life of the class whose events they handle. Dynamic event handlers are explicitly activated and deactivated during program execution, usually in response to some conditional program logic. For example, they can be used if event notifications are needed only under certain conditions or if an application provides multiple event handlers and run-time conditions define the appropriate one to use. The example in the previous section shows how to dynamically add an event handler. For more information, see [Events](../../visual-basic/programming-guide/language-features/events/index.md) and [Events](../../csharp/programming-guide/events/index.md).  
  
## Raising Multiple Events  
 If your class raises multiple events, the compiler generates one field per event delegate instance. If the number of events is large, the storage cost of one field per delegate may not be acceptable. For those situations, the .NET Framework provides event properties that you can use with another data structure of your choice to store event delegates.  
  
 Event properties consist of event declarations accompanied by event accessors. Event accessors are methods that you define to add or remove event delegate instances from the storage data structure. Note that event properties are slower than event fields, because each event delegate must be retrieved before it can be invoked. The trade-off is between memory and speed. If your class defines many events that are infrequently raised, you will want to implement event properties. For more information, see [How to: Handle Multiple Events Using Event Properties](../../../docs/standard/events/how-to-handle-multiple-events-using-event-properties.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How to: Raise and Consume Events](../../../docs/standard/events/how-to-raise-and-consume-events.md)|Contains examples of raising and consuming events.|  
|[How to: Handle Multiple Events Using Event Properties](../../../docs/standard/events/how-to-handle-multiple-events-using-event-properties.md)|Shows how to use event properties to handle multiple events.|  
|[Observer Design Pattern](../../../docs/standard/events/observer-design-pattern.md)|Describes the design pattern that enables a subscriber to register with, and receive notifications from, a provider.|  
|[How to: Consume Events in a Web Forms Application](../../../docs/standard/events/how-to-consume-events-in-a-web-forms-application.md)|Shows how to handle an event that is raised by a Web Forms control.|  
  
## See Also  
 <xref:System.EventHandler>  
 <xref:System.EventHandler%601>  
 <xref:System.EventArgs>  
 <xref:System.Delegate>  
 [Events and routed events overview (UWP apps)](/windows/uwp/xaml-platform/events-and-routed-events-overview)  
 [Events (Visual Basic)](../../visual-basic/programming-guide/language-features/events/index.md)  
 [Events (C# Programming Guide)](../../csharp/programming-guide/events/index.md)
