---
title: ".NET docs: What's new for May 2023"
description: "What's new in the .NET docs for May 2023."
ms.custom: May-2023
ms.date: 06/01/2023
---

# .NET docs: What's new for May 2023

Welcome to what's new in the .NET docs for May 2023. This article lists some of the major changes to docs during this period.

## .NET breaking changes

### New articles

- [Rate-limiting middleware requires AddRateLimiter](../core/compatibility/aspnet-core/8.0/addratelimiter-requirement.md)
- [ISystemClock is obsolete](../core/compatibility/aspnet-core/8.0/isystemclock-obsolete.md)
- [System.Drawing.Common config switch removed](../core/compatibility/core-libraries/7.0/system-drawing.md)
- [Date and time converters honor culture argument](../core/compatibility/globalization/8.0/typeconverter-cultureinfo.md)
- [ConcurrencyLimiterMiddleware is obsolete](../core/compatibility/aspnet-core/8.0/concurrencylimitermiddleware-obsolete.md)
- [Custom converters for serialization removed](../core/compatibility/aspnet-core/8.0/problemdetails-custom-converters.md)
- [StripSymbols defaults to true](../core/compatibility/deployment/8.0/stripsymbols-default.md)
- [GC.GetGeneration might return Int32.MaxValue](../core/compatibility/core-libraries/8.0/getgeneration-return-value.md)
- [API obsoletions with non-default diagnostic IDs (.NET 8)](../core/compatibility/core-libraries/8.0/obsolete-apis-with-custom-diagnostics.md)
- [BinaryFormatter disabled across most project types](../core/compatibility/serialization/8.0/binaryformatter-disabled.md)

### Updated articles

- [Breaking changes in .NET 7](../core/compatibility/7.0.md) - System.Drawing.Common config switch removal

## .NET Framework

### Updated articles

- [Managing Claims and Authorization with the Identity Model](../framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md) - Re-enable MD034
- [Durable Duplex Correlation](../framework/wcf/feature-details/durable-duplex-correlation.md) - Acrolinx 5/23
- [Certmgr.exe (Certificate Manager Tool)](../framework/tools/certmgr-exe-certificate-manager-tool.md) - Clarify installation location for certmgr.exe

## .NET fundamentals

### New articles

- [How to use a JSON document in System.Text.Json](../standard/serialization/system-text-json/use-dom.md)
- [How to use Utf8JsonReader in System.Text.Json](../standard/serialization/system-text-json/use-utf8jsonreader.md)
- [How to use Utf8JsonWriter in System.Text.Json](../standard/serialization/system-text-json/use-utf8jsonwriter.md)
- [Troubleshoot QUIC issues in .NET](../fundamentals/networking/quic/quic-troubleshooting.md)
- [Install .NET SDK or .NET Runtime on Ubuntu 23.04](../core/install/linux-ubuntu-2304.md)

### Updated articles

- [What's new in .NET 8](../core/whats-new/dotnet-8.md)
  - What's new and double words
  - Update What's new in .NET 8 for Preview 4
- [Grouping constructs in regular expressions](../standard/base-types/grouping-constructs-in-regular-expressions.md) - Clarify named capture group order

## .NET tools and diagnostics

### New articles

- [SYSLIB diagnostics for COM interop source generation](../fundamentals/syslib-diagnostics/syslib1090-1099.md)
- [SYSLIB diagnostics for configuration binder source generation](../fundamentals/syslib-diagnostics/syslib1100-1118.md)
- [SYSLIB0050: Formatter-based serialization is obsolete](../fundamentals/syslib-diagnostics/syslib0050.md)
- [SYSLIB0051: Legacy serialization support APIs are obsolete](../fundamentals/syslib-diagnostics/syslib0051.md)
- [CA1859: Use concrete types when possible for improved performance](../fundamentals/code-analysis/quality-rules/ca1859.md)
- [CA1861: Avoid constant arrays as arguments](../fundamentals/code-analysis/quality-rules/ca1861.md)

### Updated articles

- [Source-generator diagnostics in .NET 6+](../fundamentals/syslib-diagnostics/source-generator-overview.md) - Add redirects for SYSLIB warnings

## C# language

### New articles

- [Resolve errors and warnings in constructor declarations](../csharp/language-reference/compiler-messages/constructor-errors.md)
- [Errors and warnings when using lambda expressions and anonymous functions](../csharp/language-reference/compiler-messages/lambda-expression-errors.md)
- [Resolve warnings related using namespaces](../csharp/language-reference/compiler-messages/using-directive-errors.md)

### Updated articles

- [Using Constructors (C# Programming Guide)](../csharp/programming-guide/classes-and-structs/using-constructors.md) - Ret con primary record constructors

## DevOps and testing in .NET

### New articles

- [Native code interop with native AOT](../core/deploying/native-aot/interop.md)

## Microsoft Orleans

### New articles

- [Grain extensions](../orleans/grains/grain-extensions.md)

## Migration to .NET

### New articles

- [Install the .NET Upgrade Assistant](../core/porting/upgrade-assistant-install.md)

### Updated articles

- [Overview of the .NET Upgrade Assistant](../core/porting/upgrade-assistant-overview.md)
  - Add UA CLI area to docs
  - Add the upgrade assistant docs for Visual Studio

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [cartermp](https://github.com/cartermp) - Phillip Carter ![There were 9 pull requests merged by Phillip Carter.](https://img.shields.io/badge/Merged%20Pull%20Requests-9-green)
- [pkulikov](https://github.com/pkulikov) - Petr Kulikov ![There were 8 pull requests merged by Petr Kulikov.](https://img.shields.io/badge/Merged%20Pull%20Requests-8-green)
- [ShinyZero0](https://github.com/ShinyZero0) -  ![There were 3 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-3-green)
- [ali50m](https://github.com/ali50m) -  ![There were 2 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [BartoszKlonowski](https://github.com/BartoszKlonowski) - Bartosz Klonowski ![There were 2 pull requests merged by Bartosz Klonowski.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [cid25](https://github.com/cid25) -  ![There were 2 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [mahab339](https://github.com/mahab339) - Muhab Abdelreheem ![There were 2 pull requests merged by Muhab Abdelreheem.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [tonesoutherland](https://github.com/tonesoutherland) - Tone Southerland ![There were 2 pull requests merged by Tone Southerland.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [ablanchet](https://github.com/ablanchet) - Antoine Blanchet ![There were 1 pull requests merged by Antoine Blanchet.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ACGNnsj](https://github.com/ACGNnsj) - Shijie Ni ![There were 1 pull requests merged by Shijie Ni.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Adi9235](https://github.com/Adi9235) - Aditya Tomar ![There were 1 pull requests merged by Aditya Tomar.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [andreycha](https://github.com/andreycha) - Andrei Chasovskikh ![There were 1 pull requests merged by Andrei Chasovskikh.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ardalis](https://github.com/ardalis) - Steve Smith ![There were 1 pull requests merged by Steve Smith.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [bartelink](https://github.com/bartelink) - Ruben Bartelink ![There were 1 pull requests merged by Ruben Bartelink.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [chrisxfire](https://github.com/chrisxfire) - Christian ![There were 1 pull requests merged by Christian.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [cmeeren](https://github.com/cmeeren) - Christer van der Meeren ![There were 1 pull requests merged by Christer van der Meeren.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [dahermansson](https://github.com/dahermansson) - Hermansson ![There were 1 pull requests merged by Hermansson.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Davi-Gray](https://github.com/Davi-Gray) - Davi Gray ![There were 1 pull requests merged by Davi Gray.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [dawedawe](https://github.com/dawedawe) - dawe ![There were 1 pull requests merged by dawe.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [DickBaker](https://github.com/DickBaker) - Dick Baker ![There were 1 pull requests merged by Dick Baker.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ericmutta](https://github.com/ericmutta) - Eric Mutta ![There were 1 pull requests merged by Eric Mutta.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [galvesribeiro](https://github.com/galvesribeiro) - Gutemberg Ribeiro ![There were 1 pull requests merged by Gutemberg Ribeiro.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [haoguanjun](https://github.com/haoguanjun) -  ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [jeanrp](https://github.com/jeanrp) - Jean Pinto ![There were 1 pull requests merged by Jean Pinto.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [just-a-hriday](https://github.com/just-a-hriday) - Hriday A ![There were 1 pull requests merged by Hriday A.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [marleypowell](https://github.com/marleypowell) - Marley ![There were 1 pull requests merged by Marley.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Smaug123](https://github.com/Smaug123) - Patrick Stevens ![There were 1 pull requests merged by Patrick Stevens.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [startewho](https://github.com/startewho) -  ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [steveberdy](https://github.com/steveberdy) - Steve Berdy ![There were 1 pull requests merged by Steve Berdy.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [taibu](https://github.com/taibu) - ISABIRYE TAIBU ![There were 1 pull requests merged by ISABIRYE TAIBU.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Zerthz](https://github.com/Zerthz) - Felix ![There were 1 pull requests merged by Felix.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
