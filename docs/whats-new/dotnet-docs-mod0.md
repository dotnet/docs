---
title: ".NET docs: What's new for September 2022"
description: "What's new in the .NET docs for September 2022."
ms.custom: September-2022
ms.date: 10/01/2022
---

# .NET docs: What's new for September 2022

Welcome to what's new in the .NET docs for September 2022. This article lists some of the major changes to docs during this period.

## .NET breaking changes

### New articles

- [Library support for older frameworks](../core/compatibility/core-libraries/7.0/old-framework-support.md)
- [MSBuild property `TrimmerDefaultAction` is deprecated](../core/compatibility/deployment/7.0/deprecated-trimmer-default-action.md)
- [.version file includes build version](../core/compatibility/sdk/6.0/version-file-entries.md)
- [Socket.End methods don't throw ObjectDisposedException](../core/compatibility/networking/7.0/socket-end-closed-sockets.md)
- [AuthenticateAsync for remote auth providers](../core/compatibility/aspnet-core/7.0/authenticateasync-anonymous-request.md)
- [RuntimeInformation.OSArchitecture under emulation](../core/compatibility/interop/7.0/osarchitecture-emulation.md)
- [JsonSerializerOptions copy constructor includes JsonSerializerContext](../core/compatibility/serialization/7.0/jsonserializeroptions-copy-constructor.md)
- [Polymorphic serialization for object types](../core/compatibility/serialization/7.0/polymorphic-serialization.md)
- [System.Text.Json source generator fallback](../core/compatibility/serialization/7.0/reflection-fallback.md)
- [Windows Forms obsoletions and warnings (.NET 7)](../core/compatibility/windows-forms/7.0/obsolete-apis.md)
- [DataContractSerializer retains sign when deserializing -0](../core/compatibility/serialization/7.0/datacontractserializer-negative-sign.md)
- [XmlSecureResolver is obsolete](../core/compatibility/xml/7.0/xmlsecureresolver-obsolete.md)
- [Maximum precision for numeric format strings](../core/compatibility/core-libraries/7.0/max-precision-numeric-format-strings.md)
- [Globalization APIs use ICU libraries on Windows Server](../core/compatibility/globalization/7.0/icu-globalization-api.md)

## .NET Framework

### New articles

- [ICorDebugModule4 Interface](../framework/unmanaged-api/debugging/icordebugmodule4-interface.md)
- [ICorDebugModule4::IsMappedLayout Method](../framework/unmanaged-api/debugging/icordebugmodule4-ismappedlayout-method.md)
- [ICorDebugProcess11::EnumerateLoaderHeapMemoryRegions Method](../framework/unmanaged-api/debugging/icordebugprocess11-enumerateloaderheapmemoryregions-method.md)
- [ICorDebugProcess11 Interface](../framework/unmanaged-api/debugging/icordebugprocess11-interface.md)

## .NET fundamentals

### New articles

- [Customize a JSON contract](../standard/serialization/system-text-json/custom-contracts.md)
- [SYSLIB0045: Some cryptographic factory methods are obsolete](../fundamentals/syslib-diagnostics/syslib0045.md)
- [Required properties (System.Text.Json)](../standard/serialization/system-text-json/required-properties.md)
- [IL2117: Methods 'method1' and 'method2' are both associated with lambda or local function 'method'. This is currently unsupported and may lead to incorrectly reported warnings.](../core/deploying/trimming/trim-warnings/il2117.md)
- [Rate limit an HTTP handler in .NET](../core/extensions/http-ratelimiter.md)
- [SYSLIB0047: XmlSecureResolver is obsolete](../fundamentals/syslib-diagnostics/syslib0047.md)
- [FAQ for dumps](../core/diagnostics/faq-dumps.yml)
- [Introduction to AOT warnings](../core/deploying/native-aot/fixing-warnings.md)
- [Upgrade a WCF Server-side Project to use CoreWCF on .NET 6](../core/porting/upgrade-assistant-wcf.md)
- [IL3050: Avoid calling members annotated with 'RequiresDynamicCodeAttribute' when publishing as native AOT](../core/deploying/native-aot/warnings/il3050.md)
- [IL3051: 'RequiresDynamicCodeAttribute' attribute must be consistently applied on virtual and interface methods](../core/deploying/native-aot/warnings/il3051.md)
- [IL3052: COM interop is not supported with full ahead of time compilation](../core/deploying/native-aot/warnings/il3052.md)
- [IL3053: Assembly produced AOT warnings](../core/deploying/native-aot/warnings/il3053.md)
- [IL3054: Generic expansion to a method or type was aborted due to generic recursion](../core/deploying/native-aot/warnings/il3054.md)
- [IL3055: P/Invoke method declares a parameter with an abstract delegate](../core/deploying/native-aot/warnings/il3055.md)
- [IL3056: `RequiresDynamicCodeAttribute` cannot be placed directly on a static constructor](../core/deploying/native-aot/warnings/il3056.md)

### Updated articles

- [How to serialize properties of derived classes with System.Text.Json](../standard/serialization/system-text-json/polymorphism.md) - `System.Text.Json` polymorphism updates for .NET 7
- [.NET SDK error list](../core/tools/sdk-errors/index.md) - Add F1 keywords

## C# language

### New articles

- [yield statement (C# reference)](../csharp/language-reference/statements/yield.md)
- [file (C# Reference)](../csharp/language-reference/keywords/file.md)
- [fixed statement (C# reference)](../csharp/language-reference/statements/fixed.md)
- [`ref` Structure types (C# reference)](../csharp/language-reference/builtin-types/ref-struct.md)
- [Declaration statements](../csharp/language-reference/statements/declarations.md)
- [Compiler Error CS0181](../csharp/language-reference/compiler-messages/cs0181.md)
- [Compiler Error CS0767](../csharp/language-reference/compiler-messages/cs0767.md)
- [Compiler Error CS0846](../csharp/language-reference/compiler-messages/cs0846.md)
- [Compiler Error CS0854](../csharp/language-reference/compiler-messages/cs0854.md)
- [Compiler Error CS1063](../csharp/language-reference/compiler-messages/cs1063.md)
- [Compiler Error CS1065](../csharp/language-reference/compiler-messages/cs1065.md)
- [Compiler Error CS1736](../csharp/language-reference/compiler-messages/cs1736.md)
- [Compiler Error CS1737](../csharp/language-reference/compiler-messages/cs1737.md)
- [Compiler Error CS1739](../csharp/language-reference/compiler-messages/cs1739.md)
- [Compiler Error CS1740](../csharp/language-reference/compiler-messages/cs1740.md)
- [Compiler Error CS1741](../csharp/language-reference/compiler-messages/cs1741.md)
- [Compiler Error CS1742](../csharp/language-reference/compiler-messages/cs1742.md)
- [Compiler Error CS1750](../csharp/language-reference/compiler-messages/cs1750.md)
- [Compiler Error CS1763](../csharp/language-reference/compiler-messages/cs1763.md)
- [Compiler Error CS1983](../csharp/language-reference/compiler-messages/cs1983.md)
- [Compiler Error CS1986](../csharp/language-reference/compiler-messages/cs1986.md)
- [Compiler Error CS1988](../csharp/language-reference/compiler-messages/cs1988.md)
- [Compiler Error CS1994](../csharp/language-reference/compiler-messages/cs1994.md)
- [Compiler Error CS1996](../csharp/language-reference/compiler-messages/cs1996.md)
- [Compiler Error CS1997](../csharp/language-reference/compiler-messages/cs1997.md)
- [Compiler Error CS4004](../csharp/language-reference/compiler-messages/cs4004.md)
- [Compiler Error CS4008](../csharp/language-reference/compiler-messages/cs4008.md)
- [Compiler Error CS4013](../csharp/language-reference/compiler-messages/cs4013.md)
- [Compiler Error CS4032](../csharp/language-reference/compiler-messages/cs4032.md)
- [Compiler Error CS4033](../csharp/language-reference/compiler-messages/cs4033.md)
- [Compiler Error CS7000](../csharp/language-reference/compiler-messages/cs7000.md)
- [Compiler Error CS8141](../csharp/language-reference/compiler-messages/cs8141.md)
- [Compiler Error CS8145](../csharp/language-reference/compiler-messages/cs8145.md)
- [Compiler Error CS8146](../csharp/language-reference/compiler-messages/cs8146.md)
- [Compiler Error CS8147](../csharp/language-reference/compiler-messages/cs8147.md)
- [Compiler Error CS8148](../csharp/language-reference/compiler-messages/cs8148.md)
- [Compiler Error CS8149](../csharp/language-reference/compiler-messages/cs8149.md)
- [Compiler Error CS8150](../csharp/language-reference/compiler-messages/cs8150.md)
- [Compiler Error CS8151](../csharp/language-reference/compiler-messages/cs8151.md)
- [Compiler Error CS8152](../csharp/language-reference/compiler-messages/cs8152.md)
- [Compiler Error CS8153](../csharp/language-reference/compiler-messages/cs8153.md)
- [Compiler Error CS8154](../csharp/language-reference/compiler-messages/cs8154.md)
- [Compiler Error CS8155](../csharp/language-reference/compiler-messages/cs8155.md)
- [Compiler Error CS8156](../csharp/language-reference/compiler-messages/cs8156.md)
- [Compiler Error CS8157](../csharp/language-reference/compiler-messages/cs8157.md)
- [Compiler Error CS8158](../csharp/language-reference/compiler-messages/cs8158.md)
- [Compiler Error CS8159](../csharp/language-reference/compiler-messages/cs8159.md)
- [Compiler Error CS8160](../csharp/language-reference/compiler-messages/cs8160.md)
- [Compiler Error CS8161](../csharp/language-reference/compiler-messages/cs8161.md)
- [Compiler Error CS8162](../csharp/language-reference/compiler-messages/cs8162.md)
- [Compiler Error CS8163](../csharp/language-reference/compiler-messages/cs8163.md)
- [Compiler Error CS8166](../csharp/language-reference/compiler-messages/cs8166.md)
- [Compiler Error CS8167](../csharp/language-reference/compiler-messages/cs8167.md)
- [Compiler Error CS8168](../csharp/language-reference/compiler-messages/cs8168.md)
- [Compiler Error CS8169](../csharp/language-reference/compiler-messages/cs8169.md)
- [Compiler Error CS8170](../csharp/language-reference/compiler-messages/cs8170.md)
- [Compiler Error CS8171](../csharp/language-reference/compiler-messages/cs8171.md)
- [Compiler Error CS8172](../csharp/language-reference/compiler-messages/cs8172.md)
- [Compiler Error CS8173](../csharp/language-reference/compiler-messages/cs8173.md)
- [Compiler Error CS8174](../csharp/language-reference/compiler-messages/cs8174.md)
- [Compiler Error CS8175](../csharp/language-reference/compiler-messages/cs8175.md)
- [Compiler Error CS8176](../csharp/language-reference/compiler-messages/cs8176.md)
- [Compiler Error CS8177](../csharp/language-reference/compiler-messages/cs8177.md)
- [Compiler Error CS8178](../csharp/language-reference/compiler-messages/cs8178.md)
- [Compiler Error CS8333](../csharp/language-reference/compiler-messages/cs8333.md)
- [Compiler Error CS8334](../csharp/language-reference/compiler-messages/cs8334.md)
- [Compiler Error CS8354](../csharp/language-reference/compiler-messages/cs8354.md)
- [Compiler Error CS8373](../csharp/language-reference/compiler-messages/cs8373.md)
- [Compiler Error CS8374](../csharp/language-reference/compiler-messages/cs8374.md)
- [Compiler Error CS8803](../csharp/language-reference/compiler-messages/cs8803.md)
- [Compiler Error CS8812](../csharp/language-reference/compiler-messages/cs8812.md)
- [Compiler Error CS9043](../csharp/language-reference/compiler-messages/cs9043.md)
- [Compiler Error CS9050](../csharp/language-reference/compiler-messages/cs9050.md)

### Updated articles

- [Method Parameters (C# Reference)](../csharp/language-reference/keywords/method-parameters.md) - `ref` fields and `scoped`. Modify pages on struct creation, variable declaration, and ref struct.

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [peteraritchie](https://github.com/peteraritchie) - Peter Ritchie ![There were 70 pull requests merged by Peter Ritchie.](https://img.shields.io/badge/Merged%20Pull%20Requests-70-green)
- [GitHubPang](https://github.com/GitHubPang) ![There were 16 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-16-green)
- [pkulikov](https://github.com/pkulikov) - Petr Kulikov ![There were 10 pull requests merged by Petr Kulikov.](https://img.shields.io/badge/Merged%20Pull%20Requests-10-green)
- [bergerb](https://github.com/bergerb) - Brent ![There were 2 pull requests merged by Brent.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [Bielmartin](https://github.com/Bielmartin) - Felipe Martins ![There were 2 pull requests merged by Felipe Martins.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [hyoshioka0128](https://github.com/hyoshioka0128) - Hiroshi Yoshioka ![There were 2 pull requests merged by Hiroshi Yoshioka.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [marc-chevalier](https://github.com/marc-chevalier) - Marc Chevalier ![There were 2 pull requests merged by Marc Chevalier.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [Youssef1313](https://github.com/Youssef1313) - Youssef Victor ![There were 2 pull requests merged by Youssef Victor.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [3obby](https://github.com/3obby) ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [alkaberov](https://github.com/alkaberov) ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [amolenk](https://github.com/amolenk) - Sander Molenkamp ![There were 1 pull requests merged by Sander Molenkamp.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Anumania](https://github.com/Anumania) - Anumania ![There were 1 pull requests merged by Anumania.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Anusha1907](https://github.com/Anusha1907) - Anusha Kodavati ![There were 1 pull requests merged by Anusha Kodavati.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [atmozki](https://github.com/atmozki) - Dennis Jojo Kuriakose ![There were 1 pull requests merged by Dennis Jojo Kuriakose.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [BorisGerretzen](https://github.com/BorisGerretzen) - Boris Gerretzen ![There were 1 pull requests merged by Boris Gerretzen.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [bschaeublin](https://github.com/bschaeublin) - Benjamin Schäublin ![There were 1 pull requests merged by Benjamin Schäublin.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Chrizine](https://github.com/Chrizine) ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Dan54](https://github.com/Dan54) ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [dragmz](https://github.com/dragmz) - Marcin Zawiejski ![There were 1 pull requests merged by Marcin Zawiejski.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Ericles-Porty](https://github.com/Ericles-Porty) - Éricles Dos Santos ![There were 1 pull requests merged by Éricles Dos Santos.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [f3](https://github.com/f3) - Frank Alvaro ![There were 1 pull requests merged by Frank Alvaro.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [florimm](https://github.com/florimm) - Florim Maxhuni ![There were 1 pull requests merged by Florim Maxhuni.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [grantwinney](https://github.com/grantwinney) - Grant ![There were 1 pull requests merged by Grant.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [initram](https://github.com/initram) - Martin Midtgaard ![There were 1 pull requests merged by Martin Midtgaard.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [jdholly](https://github.com/jdholly) ![There was 1 pull request merged by jdholly](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [kant2002](https://github.com/kant2002) - Andrii Kurdiumov ![There were 1 pull requests merged by Andrii Kurdiumov.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ktarbet](https://github.com/ktarbet) - Karl Tarbet ![There were 1 pull requests merged by Karl Tarbet.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [KyleMit](https://github.com/KyleMit) - Kyle ![There were 1 pull requests merged by Kyle.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [MarnickvdA](https://github.com/MarnickvdA) - Marnick van der Arend ![There were 1 pull requests merged by Marnick van der Arend.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [matkoch](https://github.com/matkoch) - Matthias Koch ![There were 1 pull requests merged by Matthias Koch.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [mcm2020](https://github.com/mcm2020) - Max Chen Morrison ![There were 1 pull requests merged by Max Chen Morrison.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [meziantou](https://github.com/meziantou) - Gérald Barré ![There were 1 pull requests merged by Gérald Barré.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [miles170](https://github.com/miles170) - miles ![There were 1 pull requests merged by miles.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [MSDN-WhiteKnight](https://github.com/MSDN-WhiteKnight) - MSDN.WhiteKnight ![There were 1 pull requests merged by MSDN.WhiteKnight.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Niravprajapati1](https://github.com/Niravprajapati1) - Nirav_Prajapati ![There were 1 pull requests merged by Nirav_Prajapati.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [OOberoi](https://github.com/OOberoi) - Obi Oberoi ![There were 1 pull requests merged by Obi Oberoi.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [PropzSaladaz](https://github.com/PropzSaladaz) - Sidnei Teixeira ![There were 1 pull requests merged by Sidnei Teixeira.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [rafcon-dev](https://github.com/rafcon-dev) - Rafael C ![There were 1 pull requests merged by Rafael C.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [redconOne](https://github.com/redconOne) - Ming Lee Ng ![There were 1 pull requests merged by Ming Lee Ng.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [rosstimo](https://github.com/rosstimo) - Tim Rossiter ![There were 1 pull requests merged by Tim Rossiter.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [sergeipetrashko8](https://github.com/sergeipetrashko8) - Sergei Petrashko ![There were 1 pull requests merged by Sergei Petrashko.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [SimonaLiao](https://github.com/SimonaLiao) - Simona Liao ![There were 1 pull requests merged by Simona Liao.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [smoothdeveloper](https://github.com/smoothdeveloper) - Gauthier Segay ![There were 1 pull requests merged by Gauthier Segay.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [teknixstuff](https://github.com/teknixstuff) - Tech Stuff ![There were 1 pull requests merged by Tech Stuff.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [vanillajonathan](https://github.com/vanillajonathan) - Jonathan ![There were 1 pull requests merged by Jonathan.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [vcrobe](https://github.com/vcrobe) ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [WAftring](https://github.com/WAftring) - Will Aftring ![There were 1 pull requests merged by Will Aftring.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [xtqqczze](https://github.com/xtqqczze) ![There were 1 pull requests merged by .](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
