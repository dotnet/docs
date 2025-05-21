---
title: System.Runtime.InteropServices.ComWrappers class
description: Learn about the System.Runtime.InteropServices.ComWrappers class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Runtime.InteropServices.ComWrappers class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.InteropServices.ComWrappers> API provides support for the `IUnknown` API independent of the built-in COM interoperability support. The `ComWrappers` API exposes the minimal runtime support that's needed for developers to replace the built-in version in an efficient manner.

Traditionally in the runtime, a native proxy to managed object is called a COM Callable Wrapper (CCW), and a managed proxy to a native object is called a Runtime Callable Wrapper (RCW). However, when used here, those terms should not be confused with the built-in features of the same name (that is, [CCW](../../standard/native-interop/com-callable-wrapper.md) and [RCW](../../standard/native-interop/runtime-callable-wrapper.md)). Unlike the built-in features, a majority of the responsibility for accurate lifetime management, dispatching methods, and marshalling of arguments and return values is left to the `ComWrappers` implementer.

"Minimal support" is defined by the following features:

1. Efficient mapping between a managed object and a native proxy (for example, CCW).
2. Efficient mapping between a native `IUnknown` and its managed proxy (for example, RCW).
3. Integration with the garbage collector through the [IReferenceTrackerHost](/windows/win32/api/windows.ui.xaml.hosting.referencetracker/nn-windows-ui-xaml-hosting-referencetracker-ireferencetrackerhost) interface contract.

Leveraging this is an advanced scenario.

## Proxy state

This section provides descriptions and illustrations of native and managed proxy state after their respective creation.

In the following illustrations, a strong reference is depicted as a solid line (`===`) and a weak reference is depicted as a dashed line (`= = =`). The terms "strong reference" and "weak reference" should be interpreted as "extending lifetime" and "not extending lifetime", as opposed to implying a specific implementation.

The following illustration shows the state of the managed object and native proxy after a call to <xref:System.Runtime.InteropServices.ComWrappers.GetOrCreateComInterfaceForObject(System.Object,System.Runtime.InteropServices.CreateComInterfaceFlags)?displayProperty=nameWithType>.

```
 --------------------                  ----------------------
|   Managed object   |                |     Native proxy     |
|                    |                | Ref count: 1         |
|  ----------------  |                |  ------------------  |
| | Weak reference |=| = = = = = = = >| | Strong reference | |
| |    to proxy    | |<===============|=|    to object     | |
|  ----------------  |                |  ------------------  |
 --------------------                  ----------------------
```

The next illustration shows the state of the native object and managed proxy after a call to <xref:System.Runtime.InteropServices.ComWrappers.GetOrCreateObjectForComInstance(System.IntPtr,System.Runtime.InteropServices.CreateObjectFlags)?displayProperty=nameWithType>. The concept of "identity" follows the [rules for `IUnknown`](/windows/win32/com/rules-for-implementing-queryinterface#objects-must-have-identity).

```
 ------------------               ------------------
|  Native object   |< = = = = = =|                  |
| Ref count: +1    |             | Mapping from     |
 ------------------              | native identity  |
 ------------------------        | to managed proxy |
|   Managed proxy        |< = = =|                  |
| Created by ComWrappers |        ------------------
|   implementer.        |
| Optional AddRef() on   |
|   native object.      |
 ------------------------
```

Observe that only weak references exist from the runtime perspective. The `+1` reference count on the native object is assumed to be performed by the managed proxy creator (that is, the `ComWrappers` implementer) to ensure the associated lifetime between the native object and its managed proxy. There is an optional strong reference (that is, `AddRef()`) mentioned in the managed proxy, which is used to support scenario (3) mentioned earlier. See <xref:System.Runtime.InteropServices.CreateObjectFlags.TrackerObject?displayProperty=nameWithType>. With this optional strong reference, the reference count would be `+2`.
