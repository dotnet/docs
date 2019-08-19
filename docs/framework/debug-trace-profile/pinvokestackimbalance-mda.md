---
title: "pInvokeStackImbalance MDA"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "signatures, platform invoke"
  - "stack depth"
  - "platform invoke stack imbalance"
  - "MDAs (managed debugging assistants), platform invoke"
  - "platform invoke, run-time errors"
  - "PInvokeStackImbalance MDA"
  - "managed debugging assistants (MDAs), platform invoke"
ms.assetid: 34ddc6bd-1675-4f35-86aa-de1645d5c631
author: "mairaw"
ms.author: "mairaw"
---
# PInvokeStackImbalance MDA

The `PInvokeStackImbalance` managed debugging assistant (MDA) is activated when the CLR detects that the stack depth after a platform invoke call does not match the expected stack depth, given the calling convention specified in the <xref:System.Runtime.InteropServices.DllImportAttribute> attribute and the declaration of the parameters in the managed signature.

The `PInvokeStackImbalance` MDA is implemented only for 32-bit x86 platforms.

> [!NOTE]
> The `PInvokeStackImbalance` MDA is disabled by default. In Visual Studio 2017, The `PInvokeStackImbalance` MDA appears in the **Managed Debugging Assistants** list in the **Exception Settings** dialog box (which is displayed when you select **Debug** > **Windows** > **Exception Settings**). However, selecting or clearing the **Break When Thrown** check box does not enable or disable the MDA; it only controls whether Visual Studio throws an exception when the MDA is activated.

## Symptoms

An application encounters an access violation or memory corruption when making or following a platform invoke call.

## Cause

The managed signature of the platform invoke call might not match the unmanaged signature of the method being called.  This mismatch can be caused by the managed signature not declaring the correct number of parameters or not specifying the appropriate size for the parameters.  The MDA can also activate because the calling convention, possibly specified by the <xref:System.Runtime.InteropServices.DllImportAttribute> attribute, does not match the unmanaged calling convention.

## Resolution

Review the managed platform invoke signature and calling convention to confirm it matches the signature and calling convention of the native target.  Try explicitly specifying the calling convention on both the managed and unmanaged sides. It is also possible, although not as likely, that the unmanaged function unbalanced the stack for some other reason, such as a bug in the unmanaged compiler.

## Effect on the Runtime

Forces all platform invoke calls to take the nonoptimized path in the CLR.

## Output

The MDA message gives the name of the platform invoke method call that is causing the stack imbalance. A sample message of a platform invoke call on method `SampleMethod` is:

**A call to PInvoke function 'SampleMethod' has unbalanced the stack. This is likely because the managed PInvoke signature does not match the unmanaged target signature. Check that the calling convention and parameters of the PInvoke signature match the target unmanaged signature.**

## Configuration

```xml
<mdaConfig>
  <assistants>
    <pInvokeStackImbalance />
  </assistants>
</mdaConfig>
```

## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshaling.md)
