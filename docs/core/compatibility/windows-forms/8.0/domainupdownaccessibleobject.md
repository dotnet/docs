---
title: "Breaking change: WFDEV002 obsoletion is now an error"
description: Learn about the breaking change in .NET 8 for Windows Forms where the compile-time diagnostic WFDEV002 has been promoted from a warning to an error.
ms.date: 01/30/2023
ms.topic: concept-article
---
# WFDEV002 obsoletion is now an error

The WFDEV002 obsoletion has been promoted from a warning to an error in .NET 8. Any reference to <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject> will result in a compilation error that can't be suppressed. In addition, <xref:System.Windows.Forms.DomainUpDown.CreateAccessibilityInstance?displayProperty=nameWithType> now returns an object of the internal type `UpDownBase.UpDownBaseAccessibleObject`.

## Version introduced

.NET 8 Preview 1

## Previous behavior

Previously, if you referenced the <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject> type, you got compile-time warning [WFDEV002](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev002).

Also, <xref:System.Windows.Forms.DomainUpDown.CreateAccessibilityInstance?displayProperty=nameWithType> returned an object of type <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject>.

## New behavior

If you reference the <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject> type, you'll get a compile-time error with the same diagnostic ID ([WFDEV002](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev002)).

In addition, since the type has been removed, <xref:System.Windows.Forms.DomainUpDown.CreateAccessibilityInstance?displayProperty=nameWithType> now returns an object of type `UpDownBase.UpDownBaseAccessibleObject` (which is an internal type).

## Change category

This change can affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

The <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject> class has always been documented as "internal use only". All functionality of the class was moved to the base class.

## Recommended action

Update your code to use <xref:System.Windows.Forms.Control.ControlAccessibleObject?displayProperty=nameWithType> or <xref:System.Windows.Forms.AccessibleObject> instead of <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject>.

## Affected APIs

- <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject?displayProperty=fullName>
- <xref:System.Windows.Forms.DomainUpDown.CreateAccessibilityInstance?displayProperty=fullName>
