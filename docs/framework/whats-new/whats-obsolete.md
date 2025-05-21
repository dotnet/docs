---
title: What's obsolete in .NET Framework
description: See how the .NET Framework class library marks members as obsolete. Understand the ObsoleteAttribute attribute, how to handle obsolete types and members, and more.
ms.date: 04/26/2023
helpviewer_keywords: 
  - "obsolete [.NET Framework]"
  - "what's obsolete [.NET Framework]"
  - "deprecated [.NET Framework]"
ms.assetid: d356a43a-73df-4ae2-a457-b9628074c7cd
ms.topic: article
---
# Obsoletions in the .NET Framework class library

.NET Framework changed over time. Each new version added new types and type members that provided new functionality. Existing types and their members also changed over time. For example, some types became less important as the technology they supported was replaced by a new technology, and some methods were superseded by newer methods that are superior in some way.

.NET Framework and the common language runtime strive to support backward compatibility (allowing applications that were developed with one version of .NET Framework to run on the next version of .NET Framework). This makes it difficult to simply remove a type or a type member. Instead, .NET Framework indicated that a type or a type member should no longer be used by marking it as *obsolete* or *deprecated*. By obsoleting a type or a member, developers were aware that it would go away and had time to respond to its removal. However, existing code that uses the type or member continued to run in the new version of .NET.

> [!NOTE]
> In .NET (Core), obsoleting an API doesn't necessarily mean that the API will be removed. For more information, see [API removal in .NET](../../core/compatibility/api-removal.md).

## The ObsoleteAttribute attribute

.NET Framework indicates that a type or type member is obsolete by marking it with the <xref:System.ObsoleteAttribute> attribute. Applying the attribute to a type or member indicates that type or member will be removed in some future version without breaking compiled code that uses that member.

In addition to indicating that a type or a type member is obsolete, <xref:System.ObsoleteAttribute> defines how the compiler handles source code that includes that type or member. The compiler can compile the code but emit a warning message, or it can treat the use of the type or member as an error. In the first case, the code can successfully compile, but a warning message indicates that the type or member is obsolete. In the second case, compilation fails.

Even if compilation produces an error instead of a warning message, <xref:System.ObsoleteAttribute> does not affect run-time behavior. That is, applications that use the type or member and that have compiled successfully will always run successfully. Only the attempt to recompile an application that uses the type or member fails.

## How to handle obsolete types and members

When you upgrade and recompile existing code, using an obsolete type or member that produces a compiler warning in your application is acceptable. However, you should review the compiler warning message to determine whether you should change your application code. If the message does not point to a suitable alternative, you should do either of the following:

- Change your code by removing the use of the type or member, if possible.

     -or-

- Review the documentation for this technology area to determine how to respond to the deprecation.

You may choose not to recompile existing code against a later version of .NET Framework. Instead, you can specify the version of .NET Framework against which your existing compiled code runs. For example, suppose you have an application named *app1.exe* that was compiled against .NET Framework 3.5, but you want the application to run against .NET Framework 4.5. This requires the following steps:

1. Create a configuration file for your main executable and name it *appName*.exe.config, where *appName* is the name of the application executable. For the application named *app1.exe* in our example, you would create a configuration file named *app1.exe.config*.

2. Add the following to the configuration file.

    ```xml
    <configuration>
       <startup>
          <supportedRuntime version="v4.0" />
       </startup>
    </configuration>
    ```

To target a specific version of .NET Framework, assign one of the following string values to the `version` attribute:

|.NET Framework version|`version` string|
|-|-|
|4.8 (including 4.8.1)|v4.0|
|4.7 (including 4.7.1 and 4.7.2)|v4.0|
|4.6 (including 4.6.1 and 4.6.2)|v4.0|
|4.5 (including 4.5.1 and 4.5.2)|v4.0|
|4|v4.0|
|3.5|v2.0.50727|
|2.0|v2.0.50727|
|1.1|v1.1.4322|
|1.0|v1.0.3705|

## Obsolete APIs for .NET Framework 4.5 and later versions

- [Obsolete Types](obsolete-types.md)
- [Obsolete Members](obsolete-members.md)

## Obsolete APIs for previous versions

- [Obsolete Types in .NET Framework 4](/previous-versions/dotnet/netframework-4.0/ee461503(v=vs.100))
- [Obsolete Members in .NET Framework 4](/previous-versions/dotnet/netframework-4.0/ee471421(v=vs.100))
- [.NET Framework 3.5 Obsolete List](/previous-versions/cc835481(v=msdn.10))
- [.NET Framework 2.0 Obsolete List](/previous-versions/aa497286(v=msdn.10))

## See also

- [\<supportedRuntime> Element](../configure-apps/file-schema/startup/supportedruntime-element.md)
