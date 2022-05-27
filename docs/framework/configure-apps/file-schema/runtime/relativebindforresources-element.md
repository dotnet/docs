---
description: "Learn more about: <relativeBindForResources> Element"
title: "<relativeBindForResources> Element"
ms.date: "03/30/2017"
helpviewer_keywords:
    - "RelativeBindForResources element"
    - "<relativeBindForResources> element"
ms.assetid: 846ffa47-7257-4ce3-8cac-7ff627e0e34f
---

# \<relativeBindForResources> Element

Optimizes the probe for satellite assemblies.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<relativeBindForResources>**

## Syntax

```xml
<relativeBindForResources
   enabled="true|false" />
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

| Attribute | Description |
|--|--|
| `enabled` | Required attribute.<br /><br /> Specifies whether the common language runtime optimizes the probe for satellite assemblies. |

## enabled Attribute

| Value   | Description                                                                                  |
|---------|----------------------------------------------------------------------------------------------|
| `false` | The runtime does not optimize the probe for satellite assemblies. This is the default value. |
| `true`  | The runtime optimizes the probe for satellite assemblies.                                    |

### Child Elements

None.

### Parent Elements

| Element | Description |
|--|--|
| `configuration` | The root element in every configuration file used by the common language runtime and .NET Framework applications. |
| `runtime` | Contains information about runtime initialization options. |

## Remarks

In general, Resource Manager probes for resources, as documented in the [Package and Deploy resources](../../../../core/extensions/package-and-deploy-resources.md) topic. This means that when Resource Manager probes for a particular localized version of a resource, it may look in the global assembly cache, look in a culture-specific folder in the application's code base, query Windows Installer for satellite assemblies, and raise the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event. The `<relativeBindForResources>` element optimizes the way in which Resource Manager probes for satellite assemblies. It can improve performance when probing for resources under the following conditions:

- When the satellite assembly is deployed in the same location as the code assembly. In other words, if the code assembly is installed in the global assembly cache, the satellite assemblies must also be installed there. If the code assembly is installed in the application's code base, the satellite assemblies must also be installed in a culture-specific folder in the code base.
- When Windows Installer is not used or is used only rarely for on-demand installation of satellite assemblies.
- When application code does not handle the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

Setting the `enabled` attribute of the `<relativeBindForResources>` element to `true` optimizes Resource Manager's probe for satellite assemblies as follows:

- It uses the location of the parent code assembly to probe for the satellite assembly.
- It does not query Windows Installer for satellite assemblies.
- It does not raise the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

## See also

- [Configure apps by using configuration files](../../index.md)
- [Package and deploy resources](../../../../core/extensions/package-and-deploy-resources.md)
- [Runtime settings schema](index.md)
- [Configuration file schema](../index.md)
