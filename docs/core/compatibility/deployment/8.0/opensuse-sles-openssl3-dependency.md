---
title: "Breaking change: .NET packages for openSUSE and SLES depend on OpenSSL 3.x"
description: "Learn about the breaking change in .NET 8 where .NET packages for openSUSE and SLES distributions now depend on OpenSSL 3.x instead of OpenSSL 1.x."
ms.date: 01/05/2026
ai-usage: ai-assisted
---
# .NET packages for openSUSE and SLES depend on OpenSSL 3.x

The dependency requirements for .NET packages on openSUSE and SUSE Enterprise Linux Server (SLES) distributions have been updated to depend on OpenSSL 3.x instead of OpenSSL 1.x. This change applies to .NET 6, 7, 8, and later versions installed via package managers on these distributions.

## Version introduced

.NET 8 (also applies to .NET 6 and .NET 7)

## Previous behavior

Previously, .NET packages for openSUSE and SLES distributions specified OpenSSL 1.x as a package dependency. When you installed .NET via the package manager, the system required OpenSSL 1.x libraries to be present.

## New behavior

Starting in .NET 8, .NET packages for openSUSE and SLES distributions specify OpenSSL 3.x as a package dependency. When you install .NET via the package manager, the system requires OpenSSL 3.x libraries to be present. This change has also been applied to .NET 6 and .NET 7 packages.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Some newer versions of openSUSE and SLES distributions no longer offer OpenSSL 1.x in their package repositories, which broke the dependency requirements for .NET packages. Since .NET 6 and later versions already support OpenSSL 3.x at runtime, updating the package dependencies to require OpenSSL 3.x instead of 1.x resolves installation issues on these newer distributions.

For more information, see [dotnet/runtime#122443](https://github.com/dotnet/runtime/issues/122443).

## Recommended action

Most users don't need to take any action. The package manager automatically installs the correct OpenSSL 3.x dependencies when you install or update .NET packages.

However, if your system has both OpenSSL 1.x and OpenSSL 3.x installed, and this change causes issues with other software on your system, you might need to:

- Adjust your system configuration to accommodate both versions.
- Update other software that depends on OpenSSL 1.x to use OpenSSL 3.x.
- Stop installing .NET via packages and use an alternative installation method, such as manual installation from tarballs.

If you encounter issues, consult your distribution's documentation for managing multiple OpenSSL versions.

## Affected APIs

None.

## See also

- [dotnet/runtime#122443](https://github.com/dotnet/runtime/issues/122443)
- [dotnet/runtime#122653](https://github.com/dotnet/runtime/issues/122653)
