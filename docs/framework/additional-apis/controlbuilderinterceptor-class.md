---
description: "Learn more about: ControlBuilderInterceptor class"
title: ControlBuilderInterceptor class
ms.date: 08/11/2020
api_name: 
  - System.Web.Compilation.ControlBuilderInterceptor
api_location: 
  - "System.Web.dll"
api_type: 
  - "Assembly"
topic_type: 
  - "apiref"
---
# ControlBuilderInterceptor class

The `ControlBuilderInterceptor` class allows the compilation process to be customized or controlled.

## Syntax

```csharp
internal class ControlBuilderInterceptor
```

> [!WARNING]
> The `ControlBuilderInterceptor` class is internal and is not meant to be used directly in your code.
>
> As described in the Remarks section, the existence of this type can be checked to determine whether interceptor type support is present. Microsoft does not support any other use of this class in a production application under any circumstance.

## Remarks

In .NET Framework 2.0 and .NET Framework 3.5, the [August 2020](https://portal.msrc.microsoft.com/security-guidance/releasenotedetail/2020-Aug) updates added support for using an interceptor type to customize or control the compilation process. You can determine whether this support is present by using <xref:System.Type.GetType?displayProperty=nameWithType> to check the existence of the `ControlBuilderInterceptor` type, as demonstrated in the following code.

```csharp
Type type = Type.GetType("System.Web.Compilation.ControlBuilderInterceptor, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
```

If the return value is non-null, then interceptor support is present. If the return value is `null`, or if an exception is thrown, then the August 2020 updates have not been installed, and interceptor support is absent.

If interceptor support is present, you can write and register an interceptor type that will interact with the compilation process in exactly the same way that <xref:System.Web.Compilation.ControlBuilderInterceptor> does on later versions of .NET Framework. In .NET Framework 2.0 and .NET Framework 3.5, the interceptor type can be any class that meets the following requirements:

* Has a public, parameterless constructor.
* Has public, non-static methods named `PreControlBuilderInit` and `OnProcessGeneratedCode` that have the same signature and semantics as the <xref:System.Web.Compilation.ControlBuilderInterceptor.PreControlBuilderInit(System.Web.UI.ControlBuilder,System.Web.UI.TemplateParser,System.Web.UI.ControlBuilder,System.Type,System.String,System.String,System.Collections.IDictionary,System.Collections.IDictionary)> and <xref:System.Web.Compilation.ControlBuilderInterceptor.OnProcessGeneratedCode(System.Web.UI.ControlBuilder,System.CodeDom.CodeCompileUnit,System.CodeDom.CodeTypeDeclaration,System.CodeDom.CodeTypeDeclaration,System.CodeDom.CodeMemberMethod,System.CodeDom.CodeMemberMethod,System.Collections.IDictionary)> methods, which exist in later versions of .NET Framework.

Register the interceptor type by using the `aspnet:20ControlBuilderInterceptor` key in ASP.NET application settings (`<appSettings>`). This application setting must be listed in your computer or application *web.config* file. Specify the interceptor type by using its assembly-qualified type name. The following example shows how to register an interceptor type named `Fabrikam.Interceptor`.

```xml
<configuration>
  ...
  <appSettings>
    ...
    <add key="aspnet:20ControlBuilderInterceptor"
         value="Fabrikam.Interceptor, Fabrikam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2b3831f2f2b744f7" />
  </appSettings>
</configuration>
```

To retrieve the assembly-qualified name of a type, use the <xref:System.Type.AssemblyQualifiedName?displayProperty=nameWithType> property, as demonstrated in the following code.

```csharp
string assemblyQualifiedName = typeof(Fabrikam.Interceptor).AssemblyQualifiedName;
```

When interceptor support is present, the compilation process interacts with the listed type in the manner described above. When interceptor support is absent, the application setting is ignored and has no effect.

## Requirements

**Namespace:** System.Web.Compilation

**Assembly:** System.Web (in System.Web.dll)

**.NET Framework versions:** 3.5, 2.0
