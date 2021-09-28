---
title: "Mitigation: Custom IMessageFilter.PreFilterMessage Implementations"
description: Learn about the custom IMessageFilter.PreFilterMessage implemenation included in Windows Forms apps that target .NET Framework 4.6.1 and later.
ms.date: "03/30/2017"
ms.assetid: 9cf47c5b-0bb2-45df-9437-61cd7e7c2f4d
---
# Mitigation: Custom IMessageFilter.PreFilterMessage Implementations

In Windows Forms apps that target versions of the .NET Framework starting with the .NET Framework 4.6.1, a custom <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A?displayProperty=nameWithType> implementation can safely filter messages when the <xref:System.Windows.Forms.Application.FilterMessage%2A?displayProperty=nameWithType> method is called if the <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A?displayProperty=nameWithType> implementation:

- Does one or both of the following:

  - Adds a message filter by calling the <xref:System.Windows.Forms.Application.AddMessageFilter%2A> method.

  - Removes a message filter by calling the <xref:System.Windows.Forms.Application.RemoveMessageFilter%2A> method. method.

- **And** pumps messages by calling the <xref:System.Windows.Forms.Application.DoEvents%2A?displayProperty=nameWithType> method.

## Impact

This change only affects Windows Forms apps that target versions of the .NET Framework starting with the .NET Framework 4.6.1.

For Windows Forms apps that target previous versions of the .NET Framework, such implementations in some cases throw an <xref:System.IndexOutOfRangeException> exception when the <xref:System.Windows.Forms.Application.FilterMessage%2A?displayProperty=nameWithType> method is called

## Mitigation

If this change is undesirable, apps that target the .NET Framework 4.6.1 or a later version can opt out of it by adding the following configuration setting to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of the app’s configuration file:

```xml
<runtime>
    <AppContextSwitchOverrides value="Switch.System.Windows.Forms.DontSupportReentrantFilterMessage=true" />
</runtime>
```

In addition, apps that target previous versions of the .NET Framework but are running under the .NET Framework 4.6.1 or a later version can opt in to this behavior by adding the following configuration setting to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of the app’s configuration file:

```xml
<runtime>
    <AppContextSwitchOverrides value="Switch.System.Windows.Forms.DontSupportReentrantFilterMessage=false" />
</runtime>
```

## See also

- [Application compatibility](application-compatibility.md)
