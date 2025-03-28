---
author: adegeo
ms.author: adegeo
ms.date: 03/19/2024
ms.topic: include
ms.custom: linux-related-content
---

.NET 8.0 isn't available in the Ubuntu package repository. [Register the Microsoft package repository](../linux-ubuntu-decision.md#register-the-microsoft-package-repository) and use that feed to install .NET through APT. If you use the Microsoft package repository to install .NET, you should deprioritize .NET packages from the Ubuntu repository. For more information, see [I need a version of .NET that isn't provided by my Linux distribution](../linux-package-mixup.md?pivots=os-linux-ubuntu#i-need-a-version-of-net-that-isnt-provided-by-my-linux-distribution).
