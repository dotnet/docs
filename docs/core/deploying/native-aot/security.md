---
title: Security
description: Learn about security features available with native AOT.
author: MichalStrehovsky
ms.author: michals
ms.date: 09/11/2024
ms.topic: article
---

# Security features

.NET offers many facilities to help address security concerns when building apps. Native AOT deployment builds on top of these facilities and provides several that can help harden your apps.

## No run-time code generation

Since native AOT generates all code at the time of publishing the app, no new executable code needs to be generated at run time. This allows running your apps in environments that disallow creation of new executable code pages at run time. All the code that the CPU executes can be digitally signed.

## Restricted reflection surface

When apps are published with native AOT, the compiler analyzes the usage of reflection within the app. Only the program elements that were deemed to be targets of reflection are available for reflection at run time. Places within the program that attempt to do unconstrained reflection are flagged using [trimming warnings](../trimming/fixing-warnings.md). Program elements that weren't intended to be targets of reflection cannot be reflected on. This restriction can prevent a class of issues where a malicious actor gets in control of what the program reflects on and invokes unintended code. This restriction includes approaches that use `Assembly.LoadFrom` or `Reflection.Emit` - neither of those work with native AOT, and their use is flagged with a warning at build time.

## Control Flow Guard

[Control Flow Guard](/windows/win32/secbp/control-flow-guard) is a highly optimized platform security feature on Windows that was created to combat memory corruption vulnerabilities. By placing tight restrictions on where an application can execute code from, it makes it much harder for exploits to execute arbitrary code through vulnerabilities such as buffer overflows.

To enable Control Flow Guard on your native AOT app, set the `ControlFlowGuard` property in the published project.

```xml
<PropertyGroup>
  <!-- Enable control flow guard -->
  <ControlFlowGuard>Guard</ControlFlowGuard>
</PropertyGroup>
```

## Control-flow Enforcement Technology Shadow Stack (.NET 9+)

Control-flow Enforcement Technology (CET) Shadow Stack is a computer processor feature. It provides capabilities to defend against return-oriented programming (ROP) based malware attacks.

CET is enabled by default when publishing for Windows. To disable CET, set the `CetCompat` property in the published project.

```xml
<PropertyGroup>
  <!-- Disable Control-flow Enforcement Technology -->
  <CetCompat>false</CetCompat>
</PropertyGroup>
```
