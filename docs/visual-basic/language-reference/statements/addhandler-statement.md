---
title: "AddHandler Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.AddHandlerMethod"
  - "addhandler"
  - "vb.addhandler"
helpviewer_keywords: 
  - "AddHandler statement [Visual Basic]"
ms.assetid: cfe69799-2a0f-42c0-a99e-09fed954da01
---
# AddHandler Statement
Associates an event with an event handler at run time.  
  
## Syntax  
  
```vb  
AddHandler event, AddressOf eventhandler  
```  
  
## Parts  
|||
|---|---|
|event|The name of the event to handle.|  
|`eventhandler`|The name of a procedure that handles the event.|
|||
  
## Remarks  
 The `AddHandler` and `RemoveHandler` statements allow you to start and stop event handling at any time during program execution.  
  
 The signature of the `eventhandler` procedure must match the signature of the event `event`.  
  
 The `Handles` keyword and the `AddHandler` statement both allow you to specify that particular procedures handle particular events, but there are differences. The `AddHandler` statement connects procedures to events at run time. Use the `Handles` keyword when defining a procedure to specify that it handles a particular event. For more information, see [Handles](../../../visual-basic/language-reference/statements/handles-clause.md).  
  
> [!NOTE]
> For custom events, the `AddHandler` statement invokes the event's `AddHandler` accessor. For more information on custom events, see [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md).  
  
## Example  
 [!code-vb[VbVbalrEvents#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#17)]  
  
## See also

- [RemoveHandler Statement](../../../visual-basic/language-reference/statements/removehandler-statement.md)
- [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)
- [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)
- [Events](../../../visual-basic/programming-guide/language-features/events/index.md)
