---
title: System.Reflection.Emit.DynamicMethod.IsSecurity* properties
description: Learn about the System.Reflection.Emit.DynamicMethod.IsSecurity* properties.
ms.date: 02/10/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicMethod.IsSecurity\* properties

[!INCLUDE [context](includes/context.md)]

> [!NOTE]
> The remarks in this article apply only to .NET Framework and not to modern .NET.

The <xref:System.Reflection.Emit.DynamicMethod.IsSecurityCritical*>, <xref:System.Reflection.Emit.DynamicMethod.IsSecuritySafeCritical*>, and <xref:System.Reflection.Emit.DynamicMethod.IsSecurityTransparent*> properties report the transparency level of the dynamic method as determined by the common language runtime (CLR). The combinations of these properties are shown in the following table:

| Security level | IsSecurityCritical | IsSecuritySafeCritical | IsSecurityTransparent |
|----------------|--------------------|-----------------------|-----------------------|
| Critical       | `true`             | `false`               | `false`               |
| Safe critical  | `true`             | `true`                | `false`               |
| Transparent    | `false`            | `false`               | `true`                |

Using these properties is much simpler than examining the security annotations of an assembly and its types, checking the current trust level, and attempting to duplicate the runtime's rules.

The transparency of a dynamic method depends on the module it's associated with. If the dynamic method is associated with a type rather than a module, its transparency depends on the module that contains the type. Dynamic methods don't have security annotations, so they're assigned the default transparency for the associated module.

- Anonymously hosted dynamic methods are always transparent, because the system-provided module that contains them is transparent.

- The transparency of a dynamic method that's associated with a trusted assembly (that is, a strong-named assembly that's installed in the global assembly cache) is described in the following table.

   | Assembly annotation | Level 1 transparency | Level 2 transparency |
   |---------------------|----------------------|----------------------|
   | Fully transparent   | Transparent          | Transparent          |
   | Fully critical      | Critical             | Critical             |
   | Mixed transparency  | Transparent          | Transparent          |
   | Security-agnostic   | Safe-critical        | Critical             |

   For example, if you associate a dynamic method with a type that's in mscorlib.dll, which has level 2 mixed transparency, the dynamic method is transparent and can't execute critical code. For information about transparency levels, see [Security-Transparent Code, Level 1](/dotnet/framework/misc/security-transparent-code-level-1) and [Security-Transparent Code, Level 2](/dotnet/framework/misc/security-transparent-code-level-2).

   > [!NOTE]
   > Associating a dynamic method with a module in a trusted level 1 assembly that's security-agnostic, such as System.dll, doesn't permit elevation of trust. If the grant set of the code that calls the dynamic method doesn't include the grant set of System.dll (that is, full trust), <xref:System.Security.SecurityException> is thrown when the dynamic method is called.

- The transparency of a dynamic method that's associated with a partially trusted assembly depends on how the assembly is loaded. If the assembly is loaded with partial trust (for example, into a sandboxed application domain), the runtime ignores the security annotations of the assembly. The assembly and all its types and members, including dynamic methods, are treated as transparent. The runtime pays attention to security annotations only if the partial-trust assembly is loaded with full trust (for example, into the default application domain of a desktop application). In that case, the runtime assigns the dynamic method the default transparency for methods according to the assembly's annotations.

For more information about reflection emit and transparency, see [Security Issues in Reflection Emit](../../framework/reflection-and-codedom/security-issues-in-reflection-emit.md). For information about transparency, see [Security Changes](/dotnet/framework/security/security-changes).
