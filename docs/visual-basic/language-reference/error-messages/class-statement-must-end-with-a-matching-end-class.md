---
description: "Learn more about: BC30481: 'Class' statement must end with a matching 'End Class"
title: "'Class' statement must end with a matching 'End Class'"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30481"
  - "bc30481"
helpviewer_keywords:
  - "BC30481"
ms.assetid: 583f3029-bc3a-4e06-866f-92dbecc46f19
---
# BC30481: 'Class' statement must end with a matching 'End Class'

`Class` is used to initiate a `Class` block; hence it can only appear at the beginning of the block, with a matching `End Class` statement ending the block. Either you have a redundant `Class` statement, or you have not ended your `Class` block with `End Class`.

 **Error ID:** BC30481

## To correct this error

- Locate and remove the unnecessary `Class` statement.

- Conclude the `Class` block with a matching `End Class`.

## See also

- [End \<keyword> Statement](../statements/end-keyword-statement.md)
- [Class Statement](../statements/class-statement.md)
