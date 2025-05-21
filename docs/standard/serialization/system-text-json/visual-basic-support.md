---
title: Visual Basic support for System.Text.Json
description: Learn which parts of the System.Text.Json namespace aren't supported in Visual Basic.
ms.date: 09/21/2022
no-loc: [System.Text.Json, Newtonsoft.Json]
ms.topic: article
---

# Visual Basic support

Parts of <xref:System.Text.Json> use [ref structs](../../../csharp/language-reference/builtin-types/ref-struct.md), which are not supported by Visual Basic. If you try to use System.Text.Json ref struct APIs with Visual Basic, you get BC40000 compiler errors. The error message indicates that the problem is an obsolete API, but the actual issue is lack of ref struct support in the compiler. The following parts of System.Text.Json aren't usable from Visual Basic:

* The <xref:System.Text.Json.Utf8JsonReader> struct. Since the <xref:System.Text.Json.Serialization.JsonConverter%601.Read%2A?displayProperty=nameWithType> method takes a `Utf8JsonReader` parameter, this limitation means you can't use Visual Basic to write custom converters. A workaround for this is to implement custom converters in a C# library assembly, and reference that assembly from your VB project. This assumes that all you do in Visual Basic is register the converters into the serializer. You can't call the `Read` methods of the converters from Visual Basic code.
* Overloads of other APIs that include a <xref:System.ReadOnlySpan%601> type. Most methods include overloads that use `String` instead of `ReadOnlySpan`.

These restrictions are in place because ref structs cannot be used safely without language support, even when just "passing data through." You should not subvert this error. If you do, your Visual Basic code can corrupt memory.
