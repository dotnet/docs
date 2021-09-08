---
author: tdykstra
ms.author: tdykstra
ms.date: 08/04/2021
ms.topic: include
---
- **`--add-source <SOURCE>`**

  Adds an additional NuGet package source to use during installation. Feeds are accessed in parallel, not sequentially in some order of precedence. If the same package and version is in multiple feeds, the fastest feed wins. For more information, see [What happens when a NuGet package is installed?](/nuget/concepts/package-installation-process).
