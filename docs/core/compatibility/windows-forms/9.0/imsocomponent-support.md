---
title: "Breaking change: IMsoComponent support is opt-in"
description: Learn about the breaking change in .NET 9 for Windows Forms where IMsoComponent support is now opt-in.
ms.date: 09/05/2024
ms.topic: concept-article
---
# IMsoComponent support is opt-in

A change was made to avoid Windows Forms threads always registering with existing [IMsoComponentManager](/previous-versions/office/developer/office-2007/ff518963(v=office.12)) instances. However, you can opt in to register existing `IMsoComponentManager` instances to your Windows Forms threads.

## Version introduced

.NET 9 Preview 2

## Previous behavior

Previously, Windows Forms threads always registered with existing `IMsoComponentManager` instances.

## New behavior

Starting in .NET 9, Windows Forms threads don't automatically integrate with process-registered `IMsoComponentManagers`. To get the previous behavior back, set the switch `Switch.System.Windows.Forms.EnableMsoComponentManager`.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

This change was made for performance and efficiency. The previous behavior presented a lot of overhead as it used COM, and not all developers need this behavior.

## Recommended action

If you wish to revert to the previous behavior, you can opt in to `IMsoComponent` support using a switch in the *runtimeconfig.json* file or as a `RuntimeHostConfigurationOption` item in the project file.

*runtimeconfig.json* file:

```json
{
  "configProperties": {
    "Switch.System.Windows.Forms.EnableMsoComponentManager": true
 }
}
```

Project file:

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="Switch.System.Windows.Forms.EnableMsoComponentManager" Value="true" />
</ItemGroup>
```

## Affected APIs

- [IMsoComponent interface](/previous-versions/office/developer/office-2007/ff518955(v=office.12))
- [IMsoComponentManager interface](/previous-versions/office/developer/office-2007/ff518963(v=office.12))
