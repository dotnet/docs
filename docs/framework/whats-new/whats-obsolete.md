---
title: "What's Obsolete in the .NET Framework class library"
ms.custom: "updateeachrelease"
ms.date: "04/02/2019"
helpviewer_keywords: 
  - "obsolete [.NET Framework]"
  - "what's obsolete [.NET Framework]"
  - "deprecated [.NET Framework]"
ms.assetid: d356a43a-73df-4ae2-a457-b9628074c7cd
author: "rpetrusha"
ms.author: "ronpet"
---
# What's obsolete in the .NET Framework class library

The .NET Framework changes over time. Each new version adds new types and type members that provide new functionality. Existing types and their members also change over time. For example, some types become less important as the technology they support is replaced by a new technology, and some methods are superseded by newer methods that are either more convenient or more full-featured.

The .NET Framework and the common language runtime strive to support backward compatibility (allowing applications that were developed with one version of the .NET Framework to run on the next version of the .NET Framework). This makes it difficult to simply remove a type or a type member. Instead, the .NET Framework indicates that a type or a type member should no longer be used by marking it as obsolete or deprecated. Deprecating a type or a member involves marking it so that developers are aware it will go away and have time to respond to its removal. However, existing code that uses the type or member continues to run in the new version of the .NET Framework.

> [!NOTE]
> The terms *obsolete* and *deprecated* have the same meaning when applied to the types and members of the .NET Framework.

## The ObsoleteAttribute attribute

The .NET Framework indicates that a type or type member is obsolete by marking it with the <xref:System.ObsoleteAttribute> attribute. Applying the attribute to a type or member indicates that type or member will be removed in some future version of the .NET Framework without breaking compiled code that uses that member.

In addition to indicating that a type or a type member is obsolete, <xref:System.ObsoleteAttribute> defines how the compiler handles source code that includes that type or member. The compiler can compile the code but emit a warning message, or it can treat the use of the type or member as an error. In the first case, the code can successfully compile, but a warning message indicates that the type or member is obsolete. In the second case, compilation fails.

Even if compilation produces an error instead of a warning message, <xref:System.ObsoleteAttribute> does not affect run-time behavior. That is, applications that use the type or member and that have compiled successfully will always run successfully. Only the attempt to recompile an application that uses the type or member fails.

## How to handle obsolete types and members

When you upgrade and recompile existing code, using an obsolete type or member that produces a compiler warning in your application is perfectly acceptable. However, you should review the compiler warning message to determine whether you should change your application code. If the message does not point to a suitable alternative, you should do either of the following:

- Change your code by removing the use of the type or member, if possible.

     -or-

- Review the documentation for this technology area to determine how to respond to the deprecation.

You may choose not to recompile existing code against a later version of the .NET Framework. Instead, you can specify the version of the .NET Framework against which your existing compiled code runs. For example, suppose that you have an application named app1.exe that was compiled against the .NET Framework 3.5, but you want the application to run against the .NET Framework 4.5. This requires the following steps:

1. Create a configuration file for your main executable and name it *appName*.exe.config, where *appName* is the name of the application executable. For the application named app1.exe in our example, you would create a configuration file named app1.exe.config.

2. Add the following to the configuration file.

    ```xml
    <configuration>
       <startup> 
          <supportedRuntime version="v4.0" />
       </startup>
    </configuration>
    ```

The following table lists the string values that you can assign to the `version` attribute to target a specific version of the .NET Framework:

|.NET Framework version|`version` string|
|-|-|
|4.8|v4.0|
|4.7 (including 4.7.1 and 4.7.2)|v4.0|
|4.6 (including 4.6.1 and 4.6.2)|v4.0|
|4.5 (including 4.5.1 and 4.5.2)|v4.0|
|4|v4.0|
|3.5|v2.0.50727|
|2.0|v2.0.50727|
|1.1|v1.1.4322|
|1.0|v1.0.3705|

## Obsolete lists for the .NET Framework 4.5 and later versions

- [Obsolete Types](obsolete-types.md)
- [Obsolete Members](obsolete-members.md)

## Obsolete lists for previous versions

- [Obsolete Types in the .NET Framework 4](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/ee461503(v=vs.100))

- [Obsolete Members in the .NET Framework 4](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/ee471421(v=vs.100))

- [.NET Framework 3.5 Obsolete List](https://docs.microsoft.com/previous-versions/cc835481(v=msdn.10))

- [.NET Framework 2.0 Obsolete List](https://docs.microsoft.com/previous-versions/aa497286(v=msdn.10))

## See also

- [\<supportedRuntime> Element](../configure-apps/file-schema/startup/supportedruntime-element.md)
