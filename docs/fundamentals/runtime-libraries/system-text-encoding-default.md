---
title: System.Text.Encoding.Default property
description: Learn about the System.Text.Encoding.Default property.
ms.date: 01/24/2024
---
# System.Text.Encoding.Default property

[!INCLUDE [context](includes/context.md)]

> [!WARNING]
> Different computers can use different encodings as the default, and the default encoding can change on a single computer. If you use the <xref:System.Text.Encoding.Default?displayProperty=nameWithType> encoding to encode and decode data streamed between computers or retrieved at different times on the same computer, it may translate that data incorrectly. In addition, the encoding returned by the <xref:System.Text.Encoding.Default> property uses best-fit fallback to map unsupported characters to characters supported by the code page. For these reasons, using the default encoding is not recommended. To ensure that encoded bytes are decoded properly, you should use a Unicode encoding, such as <xref:System.Text.UTF8Encoding> or <xref:System.Text.UnicodeEncoding>. You could also use a higher-level protocol to ensure that the same format is used for encoding and decoding.

## .NET Framework

In .NET Framework, the <xref:System.Text.Encoding.Default> property always gets the system's active code page and creates a <xref:System.Text.Encoding> object that corresponds to it. The active code page may be an ANSI code page, which includes the ASCII character set along with additional characters that vary by code page. Because all <xref:System.Text.Encoding.Default%2A> encodings based on ANSI code pages lose data, consider using the <xref:System.Text.Encoding.UTF8%2A?displayProperty=nameWithType> encoding instead. UTF-8 is often identical in the U+00 to U+7F range, but can encode characters outside the ASCII range without loss.

## .NET Core

In .NET Core, the <xref:System.Text.Encoding.Default> property always returns the <xref:System.Text.UTF8Encoding>. UTF-8 is supported on all the operating systems (Windows, Linux, and macOS) on which .NET Core applications run.
