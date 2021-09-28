---
title: "How to: Handle Multiple Events Using Event Properties"
description: Learn how to handle many events by using event properties. Define delegate collections, event keys, & event properties. Implement add & remove accessor methods.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "event properties [.NET]"
  - "multiple events [.NET]"
  - "event handling [.NET], with multiple events"
  - "events [.NET], multiple"
ms.assetid: 30047cba-e2fd-41c6-b9ca-2ad7a49003db
---
# How to: Handle Multiple Events Using Event Properties

To use event properties, you define the event properties in the class that raises the events, and then set the delegates for the event properties in classes that handle the events. To implement multiple event properties in a class, the class should internally store and maintain the delegate defined for each event. For each field-like-event, a corresponding backing-field reference type is generated. This can lead to unnecessary allocations when the number of events increases. As an alternative, a common approach is to maintain an <xref:System.ComponentModel.EventHandlerList> which stores events by key.
  
 To store the delegates for each event, you can use the <xref:System.ComponentModel.EventHandlerList> class, or implement your own collection. The collection class must provide methods for setting, accessing, and retrieving the event handler delegate based on the event key. For example, you could use a <xref:System.Collections.Hashtable> class, or derive a custom class from the <xref:System.Collections.DictionaryBase> class. The implementation details of the delegate collection do not need to be exposed outside your class.  
  
 Each event property within the class defines an add accessor method and a remove accessor method. The add accessor for an event property adds the input delegate instance to the delegate collection. The remove accessor for an event property removes the input delegate instance from the delegate collection. The event property accessors use the predefined key for the event property to add and remove instances from the delegate collection.  
  
### To handle multiple events using event properties  
  
1. Define a delegate collection within the class that raises the events.  
  
2. Define a key for each event.  
  
3. Define the event properties in the class that raises the events.  
  
4. Use the delegate collection to implement the add and remove accessor methods for the event properties.  
  
5. Use the public event properties to add and remove event handler delegates in the classes that handle the events.  
  
## Example  

 The following C# example implements the event properties `MouseDown` and `MouseUp`, using an <xref:System.ComponentModel.EventHandlerList> to store each event's delegate. The keywords of the event property constructs are in bold type.  
  
 [!code-cpp[Conceptual.Events.Other#31](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.events.other/cpp/example3.cpp#31)]
 [!code-csharp[Conceptual.Events.Other#31](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.events.other/cs/example3.cs#31)]
 [!code-vb[Conceptual.Events.Other#31](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.events.other/vb/example3.vb#31)]  
  
## See also

- <xref:System.ComponentModel.EventHandlerList?displayProperty=nameWithType>
- [Events](index.md)
- <xref:System.Web.UI.Control.Events%2A?displayProperty=nameWithType>
- [How to: Declare Custom Events To Conserve Memory](../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-conserve-memory.md)
