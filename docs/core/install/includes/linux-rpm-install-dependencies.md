---
author: adegeo
ms.author: adegeo
ms.date: 11/11/2024
ms.topic: include
ms.custom: linux-related-content
---

When you install with a package manager, these libraries are installed for you. But, if you manually install .NET or you publish a self-contained app, you'll need to make sure these libraries are installed:

- krb5-libs
- libicu
- openssl-libs
- zlib

If the target runtime environment's OpenSSL version is 1.1 or newer, you'll need to install `compat-openssl10`.

Dependencies can be installed with the `yum install` command. The following snippet demonstrates installing the `libicu` library:

```bash
sudo yum install libicu
```

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/main/Documentation/self-contained-linux-apps.md).
