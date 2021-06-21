---
title: "Breaking change: Blazor: Byte Array Interop"
description: "Learn about the breaking change in ASP.NET Core 6.0 titled Blazor: Byte Array Interop"
no-loc: [ Blazor ]
ms.author: tanayparikh
ms.date: 06/21/2021
---
# Blazor: Byte-array interop

Blazor now supports optimized byte array interop which avoids encoding/decoding byte arrays into Base64, facilitating a more efficient interop process. This applies to both Blazor Server and Blazor WebAssembly.

## Version introduced

ASP.NET Core 6.0 Preview 6

## Return byte array from JavaScript to .NET

### Old behavior

```typescript
function someJSMethodReturningAByteArray() {
    const data = new Uint8Array([ 1, 2, 3 ]);
    const base64EncodedData = btoa(String.fromCharCode.apply(null, data as unknown as number[]));
    return base64EncodedData;
}
```

### New behavior

```typescript
function someJSMethodReturningAByteArray() {
    const data = new Uint8Array([ 1, 2, 3 ]);
    return data;
}
```

## Receive byte array in JavaScript from .NET

### Old behavior

```typescript
function receivesByteArray(data) {
    // Previously, data was a Base64-encoded string representing the byte array.
}
```

### New behavior

```typescript
function receivesByteArray(data) {
    // Data is a Uint8Array (no longer requires processing the Base64 encoding).
}
```

## Reason for change

This change was made to create a more efficient interop mechanism for byte arrays.

## Recommended action

### Receive byte array in JavaScript from .NET

Consider this .NET interop, where you call into JavaScript passing a byte array:

```csharp
var bytes = new byte[] { 1, 5, 7 };
await _jsRuntime.InvokeVoidAsync("receivesByteArray", bytes);
```

In the preceding code example, you'd treat the incoming parameter in JavaScript as a byte array instead of a Base64 encoded string.

### Return byte array from JavaScript to .NET

If .NET expects a `byte[]`, JS must provide a `Uint8Array`. Previously, it was possible to provide a Base64-encoded array using `btoa`.

For example, consider the following JavaScript interop call from .NET:

```csharp
var bytes = await _jsRuntime.InvokeAsync<byte[]>("someJSMethodReturningAByteArray");
```

In the preceding code, the `Uint8Array` is returned from JavaScript and must _not_ be Base 64 encoded.
