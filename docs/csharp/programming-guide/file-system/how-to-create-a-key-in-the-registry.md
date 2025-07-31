---
title: "How to create a key in the registry"
description: Learn how to create registry keys in C#, including important permissions considerations and security requirements for registry access.
ms.date: 01/16/2025
helpviewer_keywords:
  - "registry keys [C#]"
  - "registries [C#], creating keys"
  - "permissions [C#], registry"
  - "Windows Registry [C#]"
ms.topic: how-to
---
# How to create a key in the registry (C# Programming Guide)

This example creates a key in the current user's registry and stores a value in it. This example demonstrates how to work with the Windows Registry using C#, including important considerations about permissions and security.

## Prerequisites and Permissions

Before working with the Windows Registry, it's important to understand the permission requirements:

- **Administrator privileges**: Some registry operations require elevated permissions. Writing to `HKEY_LOCAL_MACHINE` or other system-wide registry hives typically requires administrator privileges.
- **User-specific access**: Writing to `HKEY_CURRENT_USER` generally doesn't require administrator privileges and is the recommended approach for application settings.
- **Production considerations**: Applications should be designed to work without requiring administrator privileges for routine operations.

## Example

The following example creates a key under `HKEY_CURRENT_USER`, which is accessible without administrator privileges:

:::code language="csharp" source="snippets/how-to-create-a-key-in-the-registry/Program.cs" id="CreateRegistryKey":::

## Robust Programming

A more robust version should include error handling and proper resource disposal:

:::code language="csharp" source="snippets/how-to-create-a-key-in-the-registry/Program.cs" id="RobustRegistryAccess":::

## Registry Locations and Permissions

Different registry locations have different permission requirements:

| Registry Hive | Permission Required | Use Case |
|---------------|-------------------|----------|
| `HKEY_CURRENT_USER` | User permissions | User-specific settings |
| `HKEY_LOCAL_MACHINE` | Administrator | System-wide settings |
| `HKEY_CLASSES_ROOT` | Administrator | File associations, COM registration |

## Best Practices for Applications

When designing applications that use the registry:

1. **Prefer user-specific storage**: Use `HKEY_CURRENT_USER` for application settings when possible.
2. **Handle permission failures gracefully**: Your application should continue to function even if registry access fails.
3. **Consider alternatives**: For many scenarios, configuration files or application data folders are better choices than the registry.
4. **Use read-only access when possible**: Open registry keys with the minimum required permissions.

## Security Considerations

- Always validate data before writing to the registry
- Be cautious about what information you store in the registry, as it might be accessible to other applications
- Consider the security implications of storing sensitive information in the registry

## See also

- <xref:Microsoft.Win32.Registry?displayProperty=nameWithType>
- <xref:Microsoft.Win32.RegistryKey?displayProperty=nameWithType>
- [Security and the Registry (Visual Basic)](/dotnet/visual-basic/developing-apps/programming/computer-resources/security-and-the-registry)
