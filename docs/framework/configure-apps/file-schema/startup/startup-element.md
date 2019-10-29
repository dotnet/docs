---
title: "<startup> element"
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/startup"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#startup"
helpviewer_keywords: 
  - "container tags, <startup> element"
  - "<startup> element"
  - "startup element"
ms.assetid: 536acfd8-f827-452f-838a-e14fa3b87621
---
# \<startup> element

Specifies common language runtime startup information.

[**\<configuration>**](../configuration-element.md)  
&nbsp;&nbsp;**\<startup>**  

## Syntax

```xml
<startup useLegacyV2RuntimeActivationPolicy="true|false" > 
</startup>
```

## Attributes and elements

 The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`useLegacyV2RuntimeActivationPolicy`|Optional attribute.<br /><br /> Specifies whether to enable the .NET Framework 2.0 runtime activation policy or to use the .NET Framework 4 activation policy.|

## useLegacyV2RuntimeActivationPolicy attribute

|Value|Description|
|-----------|-----------------|
|`true`|Enable .NET Framework 2.0 runtime activation policy for the chosen runtime, which is to bind legacy runtime activation techniques (such as the [CorBindToRuntimeEx function](../../../unmanaged-api/hosting/corbindtoruntimeex-function.md)) to the runtime chosen from the configuration file instead of capping them at CLR version 2.0. Thus, if CLR version 4 or later is chosen from the configuration file, mixed-mode assemblies created with earlier versions of the .NET Framework are loaded with the chosen CLR version. Setting this value prevents CLR version 1.1 or CLR version 2.0 from loading into the same process, effectively disabling the in-process side-by-side feature.|
|`false`|Use the default activation policy for the .NET Framework 4 and later, which is to allow legacy runtime activation techniques to load CLR version 1.1 or 2.0 into the process. Setting this value prevents mixed-mode assemblies from loading into the .NET Framework 4 or later unless they were built with the .NET Framework 4 or later. This value is the default.|

### Child elements

|Element|Description|
|-------------|-----------------|
|[\<requiredRuntime>](requiredruntime-element.md)|Specifies that the application supports only version 1.0 of the common language runtime. Applications built with runtime version 1.1 or later should use the **\<supportedRuntime>** element.|
|[\<supportedRuntime>](supportedruntime-element.md)|Specifies which versions of the common language runtime the application supports.|

### Parent elements

|Element|Description|
|-------------|-----------------|
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|

## Remarks

 The **\<supportedRuntime>** element should be used by all applications built using version 1.1 or later of the runtime. Applications built to support only version 1.0 of the runtime must use the **\<requiredRuntime>** element.

 The startup code for an application hosted in Microsoft Internet Explorer ignores the **\<startup>** element and its child elements.

## The useLegacyV2RuntimeActivationPolicy attribute

 This attribute is useful if your application uses legacy activation paths, such as the [CorBindToRuntimeEx function](../../../unmanaged-api/hosting/corbindtoruntimeex-function.md), and you want those paths to activate version 4 of the CLR instead of an earlier version, or if your application is built with the .NET Framework 4 but has a dependency on a mixed-mode assembly built with an earlier version of the .NET Framework. In those scenarios, set the attribute to `true`.

> [!NOTE]
> Setting the attribute to `true` prevents CLR version 1.1 or CLR version 2.0 from loading into the same process, effectively disabling the in-process side-by-side feature (see [Side-by-Side Execution for COM Interop](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/8t8td04t(v=vs.100))).

## Example

 The following example shows how to specify the runtime version in a configuration file.

```xml
<!-- When used with version 1.0 of the .NET Framework runtime -->
<configuration>
   <startup>
      <requiredRuntime version="v1.0.3705" safemode="true"/>
   </startup>
</configuration>
<!-- When used with version 1.1 (or later) of the runtime -->
<configuration>
   <startup>
      <supportedRuntime version="v1.1.4322"/>
      <supportedRuntime version="v1.0.3705"/>
   </startup>
</configuration>
```

## See also

- [Startup Settings Schema](index.md)
- [Configuration File Schema](../index.md)
- [How to: Configure an app to support .NET Framework 4 or later versions](../../../migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5.md)
- [Side-by-Side Execution for COM Interop](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/8t8td04t(v=vs.100))
- [In-Process Side-by-Side Execution](../../../deployment/in-process-side-by-side-execution.md)
