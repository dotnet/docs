---
title: "Event '<eventname1>' cannot implement event '<eventname2>' on interface '<interface>' because their delegate types '<delegate1>' and '<delegate2>' do not match"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc31423"
  - "bc31423"
helpviewer_keywords: 
  - "BC31423"
ms.assetid: 2e754b66-5836-48ff-9697-b9c0d7085f18
---
# Event '\<eventname1>' cannot implement event '\<eventname2>' on interface '\<interface>' because their delegate types '\<delegate1>' and '\<delegate2>' do not match
Visual Basic cannot implement an event because the delegate type of the event does not match the delegate type of the event in the interface. This error can occur when you define multiple events in an interface and then attempt to implement them together with the same event. An event can implement two or more events only if all implemented events are declared using the `As` syntax and specify the same delegate type.  
  
 **Error ID:** BC31423  
  
## To correct this error  
  
-   Implement the events separately.  
  
     —or—  
  
-   Define the events in the interface using the `As` syntax and specify the same delegate type.  
  
## See also

- [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)
- [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md)
- [Events](../../../visual-basic/programming-guide/language-features/events/index.md)
