---
title: "Breaking change: Blazor: Byte Array Interop"
description: "Learn about the breaking change in ASP.NET Core 6.0 titled Blazor: Byte Array Interop"
no-loc: [ Blazor ]
ms.author: tanayparikh
ms.date: 06/21/2021
---
# Blazor: Byte Array Interop

Blazor Server & WebAssembly now supports optimized byte array interop which avoids encoding/decoding byte arrays into Base64, facilitating a more efficient interop process.

## Version introduced

ASP.NET Core 6.0 Preview 6

## Returning byte array from JS to .NET
### Old behavior

```csharp
function someJSMethodReturningAByteArray() {
    const data = new Uint8Array([ 1, 2, 3 ]);
    const base64EncodedData = btoa(String.fromCharCode.apply(null, data as unknown as number[]));
    return base64EncodedData;
}
```

### New behavior

```csharp
function someJSMethodReturningAByteArray() {
    const data = new Uint8Array([ 1, 2, 3 ]);
    return data;
}
```

## Receiving byte array in JS from .NET
### Old behavior
```js
function ReceivesByteArray(data)
{
	// Previously data was a Base 64 encoded string representing the byte array
}
```

### New behavior
```js
function ReceivesByteArray(data)
{
	// 6.0 Preview 6 and beyond, it'll be a Uint8Array (no longer requires processing the Base 64 encoding)
}
```

## Reason for change

Create a more efficient interop mechanism for byte arrays.

## Recommended action
### Receiving byte array in JS from .NET
If you sent a byte array from .NET:

```csharp
var bytes = new byte[] { 1, 5, 7 };
await _jsRuntime.InvokeVoidAsync("ReceivesByteArray", bytes);
```

Then treat the incoming parameter in JS as a byte array instead of a Base64 encoded string.

### Returning byte array from JS to .NET
If .NET is expecting a `byte[]` JS must provide a `Uint8Array`. Previously, it was possible to provide a Base64 encoded array using `btoa`.

For example, if you have something like this:

```csharp
var bytes = await _jsRuntime.InvokeAsync<byte[]>("someJSMethodReturningAByteArray");
```

then you must provide a Uint8Array from JS (must not be Base 64 encoded). 


<!--## Affected APIs

<xref:Microsoft.AspNetCore.Components.Forms.BrowserFileExtensions.RequestImageFileAsync%2A?displayProperty=nameWithType>



## Category

ASP.NET Core

## Affected APIs

`Overload:Microsoft.AspNetCore.Components.Forms.BrowserFileExtensions.RequestImageFileAsync`

-->
