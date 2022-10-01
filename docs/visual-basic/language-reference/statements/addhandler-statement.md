---
description: "Learn more about: AddHandler Statement"
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
AddHandler event, {AddressOf eventhandler | expression }
```

## Parts

| Part           | Description                                     |
| -------------- | ----------------------------------------------- |
| `event`        | The name of the event to handle.                |
| `eventhandler` | The name of a procedure that handles the event. |
| `expression`   | A lambda expression that handles the event.     |

The parts `AddressOf eventhandler` and `expression` are mutually exclusive.

## Remarks

 The `AddHandler` and `RemoveHandler` statements allow you to start and stop event handling at any time during program execution.

 The signature of the new event handler (the `eventhandler` procedure or the `expression` lambda) must match the signature of the event `event`.

 The `Handles` keyword and the `AddHandler` statement both allow you to specify that particular procedures handle particular events, but there are differences. The `AddHandler` statement connects procedures to events at run time. Use the `Handles` keyword when defining a procedure to specify that it handles a particular event. For more information, see [Handles](handles-clause.md).

 A handler added with an explicit lambda CANNOT be removed later (using `RemoveHandler`). Indeed, if the lambda is not given a name, it is not possible to reference it later. But assigning the lambda to a variable and adding the handler through this variable allows to remove the handler using this variable.

> [!NOTE]
> For custom events, the `AddHandler` statement invokes the event's `AddHandler` accessor. For more information on custom events, see [Event Statement](event-statement.md).

## Example

 [!code-vb[VbVbalrEvents#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#17)]

## See also

- [RemoveHandler Statement](removehandler-statement.md)
- [Handles](handles-clause.md)
- [Event Statement](event-statement.md)
- [Events](../../programming-guide/language-features/events/index.md)
