---
title: "invalidFunctionPointerInDelegate MDA"
description: Review the invalidFunctionPointerInDelegate managed debugging assistant (MDA), which is invoked if an invalid function pointer is passed in to make a delegate.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "invalidFunctionPointerInDelegate MDA"
  - "managed debugging assistants (MDAs), invalid function pointer to delegates"
  - "MDAs (managed debugging assistants), invalid function pointer to delegates"
  - "function pointers, invalid"
  - "marshaling, run-time errors"
  - "managed debugging assistants (MDAs), marshalling"
  - "MDAs (managed debugging assistants), marshalling"
  - "invalid function pointers"
ms.assetid: 99ae44f1-783e-49a9-9009-24f54bbd0f09
---
# invalidFunctionPointerInDelegate MDA

[!INCLUDE [net-framework-specific](../includes/net-framework-specific.md)]

The `invalidFunctionPointerInDelegate` managed debugging assistant (MDA) is activated when an invalid function pointer is passed in to construct a delegate over a native function pointer.

## Symptoms

 Access violations or unexpected memory corruption when using a delegate over a function pointer.

## Cause

 An invalid function pointer was specified.

## Resolution

 Specify a valid function pointer

## Effect on the Runtime

 This MDA has no effect on the CLR.

## Output

 The invalid function pointer.

## Configuration

```xml
<mdaConfig>
  <assistants>
    <invalidFunctionPointerInDelegate />
  </assistants>
</mdaConfig>
```

## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshalling.md)
