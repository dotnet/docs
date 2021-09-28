---
description: "Learn more about: Object or class does not support the set of events"
title: "Object or class does not support the set of events"
ms.date: 07/20/2015
f1_keywords:
  - "vbrID459"
ms.assetid: 785df3f3-2aae-4a25-af36-1f9879d4e5fd
---
# Object or class does not support the set of events

You tried to use a `WithEvents` variable with a component that cannot work as an event source for the specified set of events. For example, you wanted to sink the events of an object, then create another object that `Implements` the first object. Although you might think you could sink the events from the implemented object, this is not always the case. `Implements` only implements an interface for methods and properties. `WithEvents` is not supported for private `UserControls`, because the type info needed to raise the `ObjectEvent` is not available at run time.

## To correct this error

- You cannot sink events for a component that does not source events.

## See also

- [WithEvents](../modifiers/withevents.md)
- [Implements Statement](../statements/implements-statement.md)
