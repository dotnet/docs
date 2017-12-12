---
title: "How to: Raise Base Class Events in Derived Classes (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "events [C#], in derived classes"
ms.assetid: 2d20556a-0aad-46fc-845e-f85d86ea617a
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Raise Base Class Events in Derived Classes (C# Programming Guide)
The following simple example shows the standard way to declare events in a base class so that they can also be raised from derived classes. This pattern is used extensively in Windows Forms classes in the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] class library.  
  
 When you create a class that can be used as a base class for other classes, you should consider the fact that events are a special type of delegate that can only be invoked from within the class that declared them. Derived classes cannot directly invoke events that are declared within the base class. Although sometimes you may want an event that can only be raised by the base class, most of the time, you should enable the derived class to invoke base class events. To do this, you can create a protected invoking method in the base class that wraps the event. By calling or overriding this invoking method, derived classes can invoke the event indirectly.  
  
> [!NOTE]
>  Do not declare virtual events in a base class and override them in a derived class. The C# compiler does not handle these correctly and it is unpredictable whether a subscriber to the derived event will actually be subscribing to the base class event.  
  
## Example  
 [!code-csharp[csProgGuideEvents#1](../../../csharp/programming-guide/events/codesnippet/CSharp/how-to-raise-base-class-events-in-derived-classes_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Events](../../../csharp/programming-guide/events/index.md)  
 [Delegates](../../../csharp/programming-guide/delegates/index.md)  
 [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md)  
 [Creating Event Handlers in Windows Forms](../../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md)
