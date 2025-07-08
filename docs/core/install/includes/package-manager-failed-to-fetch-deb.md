---
author: adegeo
ms.author: adegeo
ms.date: 11/14/2023
ms.topic: include
---

While installing the .NET package, you may see an error similar to `Failed to fetch ... File has unexpected size ... Mirror sync in progress?`. This error could mean that the package feed for .NET is being upgraded with newer package versions, and that you should try again later. During an upgrade, the package feed shouldn't be unavailable for more than 30 minutes. If you continually receive this error for more than 30 minutes, please file an issue at <https://github.com/dotnet/core/issues>.
