---
title: "marshalCleanupError MDA"
description: Review the marshalCleanupError managed debugging assistant (MDA), which is invoked because an unexpected error occurred while cleaning up temporary structures.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "cleanup operations"
  - "marshaling, run-time errors"
  - "managed debugging assistants (MDAs), marshalling"
  - "MDAs (managed debugging assistants), marshalling"
  - "marshaling cleanup error"
  - "MarshalCleanupError MDA"
  - "memory, cleanup errors"
ms.assetid: 2f5d9e7c-ae51-4155-a435-54347aa1f091
---
# marshalCleanupError MDA

[!INCLUDE [net-framework-specific](../includes/net-framework-specific.md)]

The `marshalCleanupError` managed debugging assistant (MDA) is activated when the common language runtime (CLR) encounters an error while attempting to clean up temporary structures and memory used for marshalling data types between native and managed code boundaries.

## Symptoms

 A memory leak occurs when making native and managed code transitions, runtime state such as thread culture is not restored, or errors occur in <xref:System.Runtime.InteropServices.SafeHandle> cleanup.

## Cause

 An unexpected error occurred while cleaning up temporary structures.

## Resolution

 Review all <xref:System.Runtime.InteropServices.SafeHandle> destructor, finalizer, and custom marshaller implementations for errors.

## Effect on the Runtime

 This MDA has no effect on the CLR.

## Output

 A message reporting the operation that failed during cleanup.

## Configuration

```xml
<mdaConfig>
  <assistants>
    <marshalCleanupError />
  </assistants>
</mdaConfig>
```

## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshalling.md)
