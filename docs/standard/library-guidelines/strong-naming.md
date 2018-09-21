---
title: SourceLink
description: Best practice recommendations for strong-naming .NET libraries.
author: jamesnk
ms.author: jamesnk
ms.date: 09/20/2018
---
# Strong Naming

Strong naming refers to signing an assembly with a key, producing a strong named assembly. When an assembly is strong-named, it creates a unique identity based on the name and assembly version number, and can help prevent assembly conflicts.

The downside to strong-naming is that the .NET Framework on Windows enables strict loading of assemblies once an assembly is strong named. A strong-named assembly reference must exactly match the version referenced by an assembly, forcing developers to [configure binding redirects](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/redirect-assembly-versions) when using the assembly:

```xml
<configuration>
   <runtime>
      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
         <dependentAssembly>
            <assemblyIdentity name="myAssembly" publicKeyToken="32ab4ba45e0a69a1" culture="neutral" />
            <bindingRedirect oldVersion="1.0.0.0" newVersion="2.0.0.0"/>
         </dependentAssembly>
      </assemblyBinding>
   </runtime>
</configuration>
```

When .NET developers complain about strong-naming, what they are usually complaining about is strict assembly loading. Fortunately, this issue is isolated to the .NET Framework. .NET Core, Xamarin, UWP and most other .NET implementations do not have strict assembly loading and removes the main downside of strong-naming.

One important aspect of strong naming is it is viral: a strong named assembly can only reference other strong named assemblies. If your library is not strong named then developers who are building an application or library that needs strong naming are excluded from using it.

The benefits of strong naming are:

1. The assembly can be referenced and used by other strong-named assemblies.
2. The assembly can be stored in the Global Assembly Cache (GAC).
3. The assembly can be loaded side-by-side with other versions of the assembly. This is commonly required by applications with plug-in architectures.

## What should I do?

Applications don't need to strong name most of the time, but strong naming is recommended for .NET OSS libraries. Strong-naming a library's assembly ensures that the most people can use it, and only the .NET Framework is effected by strict assembly loading.

**✔️ CONSIDER** strong-naming your library's assemblies.

**✔️ CONSIDER** checking in the key used to strong-name into your source control system.

> A publicly available key lets developers modify and recompile your library source code with the same key.

> [!NOTE]
> When a cryptographic identity is desired, [Authenticode](https://docs.microsoft.com/en-us/windows-hardware/drivers/install/authenticode) and [NuGet Package Signing](https://docs.microsoft.com/en-us/nuget/create-packages/sign-a-package) are recommended. Strong naming should not be used for security considerations.

**✔️ CONSIDER** incrementing the assembly version on only major version changes to help users reduce binding redirects, and how often they are updated.

**❌ DO NOT** publish strong-named and non-strong-named versions of your project, e.g. `Contoso.Api` and `Contoso.Api.StrongNamed`.

> Publishing two packages forks your developer eco-system. Also if an application ends up depending on both packages the developer can encounter type name conflicts. As far as .NET is concerned they are different types in different assemblies.

**More Information**

* [Strong-Named Assemblies](https://docs.microsoft.com/en-us/dotnet/framework/app-domains/strong-named-assemblies)
* [Redirecting Assembly Versions](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/redirect-assembly-versions)