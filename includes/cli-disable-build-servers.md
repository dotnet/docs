---
ms.date: 09/26/2025
ms.topic: include
---
- **`--disable-build-servers`**

  Forces the command to ignore any persistent build servers. This option provides a consistent way to disable all use of build caching, which forces a build from scratch. A build that doesn't rely on caches is useful when the caches might be corrupted or incorrect for some reason. Available since .NET 7 SDK.
