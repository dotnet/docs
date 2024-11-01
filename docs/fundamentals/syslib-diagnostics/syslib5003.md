---
title: SYSLIB5003 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB5003.
ms.date: 11/01/2024
f1_keywords:
  - syslib5003
---

# SYSLIB5003: SVE is a preview feature can be used by enabling EnablePreviewFeatures flag

In .NET 9 first set of non-streaming SVE APIs were introduced as [[Experimental]](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.experimentalattribute?view=net-9.0). This indicates that both the internal implementation and the generated code for SVE may undergo changes. This includes potential modifications to method signatures, parameters, or namespaces in future updates, aimed at ensuring robust support for upcoming SVE technologies and streaming SVE designs. If you are using these APIs in your project, enable the preview mode in your project using `EnablePreviewFeatures`.

```csharp
<PropertyGroup>    
    <EnablePreviewFeatures>True</EnablePreviewFeatures>
  </PropertyGroup>
```

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]

## See also

- [Future work](https://devblogs.microsoft.com/dotnet/engineering-sve-in-dotnet/#8.-future)
