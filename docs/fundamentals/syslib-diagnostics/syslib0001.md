---
title: SYSLIB0001 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0001.
ms.date: 10/20/2020
---
# SYSLIB0001: The UTF-7 encoding is insecure

The UTF-7 encoding is no longer in wide use among applications, and many specs now [forbid its use](https://security.stackexchange.com/a/68609/3573) in interchange. It's also occasionally [used as an attack vector](https://cve.mitre.org/cgi-bin/cvekey.cgi?keyword=utf-7) in applications that don't anticipate encountering UTF-7-encoded data. Microsoft warns against use of <xref:System.Text.UTF7Encoding?displayProperty=nameWithType> because it doesn't provide error detection.

Consequently, the following APIs are marked obsolete, starting in .NET 5. Use of these APIs generates warning `SYSLIB0001` at compile time.

- <xref:System.Text.Encoding.UTF7?displayProperty=nameWithType> property
- <xref:System.Text.UTF7Encoding.%23ctor%2A> constructors

## Workarounds

- If you're using <xref:System.Text.Encoding.UTF7?displayProperty=nameWithType> or <xref:System.Text.UTF7Encoding> within your own protocol or file format:

  Switch to using <xref:System.Text.Encoding.UTF8?displayProperty=nameWithType> or <xref:System.Text.UTF8Encoding>. UTF-8 is an industry standard and is widely supported across languages, operating systems, and runtimes. Using UTF-8 eases future maintenance of your code and makes it more interoperable with the rest of the ecosystem.

- If you're comparing an <xref:System.Text.Encoding> instance against <xref:System.Text.Encoding.UTF7?displayProperty=nameWithType>:

  Instead, consider performing a check against the well-known UTF-7 code page, which is `65000`. By comparing against the code page, you avoid the warning and also handle some edge cases, such as if somebody called `new UTF7Encoding()` or subclassed the type.

  ```csharp
  void DoSomething(Encoding enc)
  {
      // Don't perform the check this way.
      // It produces a warning and misses some edge cases.
      if (enc == Encoding.UTF7)
      {
          // Encoding is UTF-7.
      }

      // Instead, perform the check this way.
      if (enc != null && enc.CodePage == 65000)
      {
          // Encoding is UTF-7.
      }
  }
  ```

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

- [UTF-7 code paths are obsolete](../../core/compatibility/core-libraries/5.0/utf-7-code-paths-obsolete.md)
