---
title: "Breaking change: Parameters renamed in Stream-derived types"
description: Learn about the .NET 6 breaking change in core .NET libraries where some parameter names in methods of Stream-derived types were changed.
ms.date: 03/04/2021
---
# Some parameters in Stream-derived types are renamed

In .NET 6, some parameters of methods on types derived from <xref:System.IO.Stream?displayProperty=fullName> have been renamed to match the base class.

## Change description

In previous .NET versions, several types derived from <xref:System.IO.Stream> override methods but use different parameter names than those used by the base type. For example, the byte array parameter of <xref:System.IO.Compression.DeflateStream.Read(System.Byte[],System.Int32,System.Int32)?displayProperty=nameWithType> is named `array` while the corresponding argument in the base class method is named `buffer`.

In .NET 6, all types that derive from <xref:System.IO.Stream?displayProperty=fullName> that had mismatched parameter names have been brought into conformance with the base type by using the same parameter names as the base type.

## Version introduced

.NET 6

## Reason for change

There are several reasons for the change:

- If an invalid argument was passed and an exception was thrown, that exception might have contained the base parameter's name or the derived parameter's name, depending on the implementation. Since the caller may have been using a reference typed as the base or as the derived type, it's impossible for the argument name in the exception to always be correct.
- Having different parameter names makes it harder to consistently validate behavior across all <xref:System.IO.Stream> implementations.
- .NET 6 adds a public method on <xref:System.IO.Stream> for validating arguments, and that methods needs to have a consistent parameter name to use.

## Recommended action

The effect of this breaking change is minimal:

- For existing binaries, its impact is limited to code that uses reflection to examine the names of parameters on the affected derived types.
- For source code, its impact is limited to code that uses named parameters to invoke methods on the derived stream type using a variable typed as that derived type.

In both cases, the recommended action is to consistently use the base parameter name.

## Affected APIs

- <xref:System.IO.BufferedStream.Read(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.IO.BufferedStream.Write(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.IO.Compression.DeflateStream.BeginWrite(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.Compression.DeflateStream.Read(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.IO.Compression.DeflateStream.ReadAsync(System.Byte[],System.Int32,System.Int32,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.IO.Compression.DeflateStream.Write(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.IO.Compression.DeflateStream.WriteAsync(System.Byte[],System.Int32,System.Int32,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.BeginWrite(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.Read(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.ReadAsync(System.Byte[],System.Int32,System.Int32,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.Write(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.IO.Compression.GZipStream.WriteAsync(System.Byte[],System.Int32,System.Int32,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.IO.FileStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.FileStream.BeginWrite(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.IO.FileStream.Read(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.IO.FileStream.Write(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.Net.Sockets.NetworkStream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.Net.Sockets.NetworkStream.BeginWrite(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)?displayProperty=fullName>
- <xref:System.Net.Sockets.NetworkStream.Read(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.Net.Sockets.NetworkStream.ReadAsync(System.Byte[],System.Int32,System.Int32,System.Threading.CancellationToken)?displayProperty=fullName>
- <xref:System.Net.Sockets.NetworkStream.Write(System.Byte[],System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.Net.Sockets.NetworkStream.WriteAsync(System.Byte[],System.Int32,System.Int32,System.Threading.CancellationToken)?displayProperty=fullName>

## See also

- [Parameter names changed in .NET 6](parameter-name-changes.md)
