---
title: "Breaking change - XsltSettings.EnableScript property is obsolete"
description: "Learn about the breaking change in .NET 10 where XsltSettings.EnableScript property is marked as obsolete."
ms.date: 01/14/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47504
---

# XsltSettings.EnableScript property is obsolete

The <xref:System.Xml.Xsl.XsltSettings.EnableScript?displayProperty=nameWithType> property is now marked as obsolete with diagnostic ID `SYSLIB0062`. XSLT script blocks are supported only in .NET Framework and are not supported on .NET Core or .NET 5+.

## Version introduced

.NET 10 Preview 1

## Previous behavior

Previously, the <xref:System.Xml.Xsl.XsltSettings.EnableScript?displayProperty=nameWithType> property could be set without any compiler warnings:

- When set to `false`: script blocks were skipped (expected behavior anyway)
- When set to `true`: a <xref:System.PlatformNotSupportedException> was thrown at runtime because script compilation is not supported

```csharp
using System.Xml.Xsl;

// No compiler warnings in previous versions
XsltSettings settings = new XsltSettings();
settings.EnableScript = true; // Would throw PlatformNotSupportedException at runtime
```

## New behavior

Starting in .NET 10, the <xref:System.Xml.Xsl.XsltSettings.EnableScript?displayProperty=nameWithType> property is marked as obsolete. Setting or accessing this property generates a compile-time warning `SYSLIB0062`.

```csharp
using System.Xml.Xsl;

// Generates SYSLIB0062 warning
XsltSettings settings = new XsltSettings();
settings.EnableScript = true; // Warning: SYSLIB0062: XsltSettings.EnableScript is obsolete
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The property was obsoleted to turn a runtime error into a build warning, providing better guidance for migration. Since XSLT script blocks are not supported on modern .NET implementations, this property had no legitimate use case and would only result in runtime exceptions when set to `true`.

## Recommended action

Call sites should be reviewed for any assumptions made about the behavior of this property. References to the property can most likely be removed since the property did not truly enable script blocks on modern .NET.

Remove any references to `EnableScript` in your code:

```csharp
// Before
XsltSettings settings = new XsltSettings();
settings.EnableScript = true; // Remove this line

// After
XsltSettings settings = new XsltSettings();
// No need to set EnableScript
```

If you need to create XSLT settings with document function enabled but script disabled (which is the default behavior), use:

```csharp
XsltSettings settings = new XsltSettings(enableDocumentFunction: true, enableScript: false);
// Or simply use XsltSettings.Default which has EnableScript = false
XsltSettings settings = XsltSettings.Default;
```

## Affected APIs

- <xref:System.Xml.Xsl.XsltSettings.EnableScript?displayProperty=fullName>
