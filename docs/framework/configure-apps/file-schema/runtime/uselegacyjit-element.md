---
description: "Learn more about: <useLegacyJit> Element"
title: "<useLegacyJit> Element"
ms.date: "04/26/2017"
ms.assetid: c2cf97f0-9262-4f1f-a754-5568b51110ad
---

# \<useLegacyJit> Element

Determines whether the common language runtime uses the legacy 64-bit JIT compiler for just-in-time compilation.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<runtime>**](runtime-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<useLegacyJit>**  
  
## Syntax  
  
```xml
<useLegacyJit enabled=0|1 />
```

The element name `useLegacyJit` is case-sensitive.
  
## Attributes and elements

The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
| Attribute | Description                                                                                   |  
| --------- | --------------------------------------------------------------------------------------------- |  
| `enabled` | Required attribute.<br><br>Specifies whether the runtime uses the legacy 64-bit JIT compiler. |  
  
### enabled attribute  
  
| Value | Description                                                                                                         |  
| ----- | ------------------------------------------------------------------------------------------------------------------- |  
| 0     | The common language runtime uses the new 64-bit JIT compiler included in the .NET Framework 4.6 and later versions. |  
| 1     | The common language runtime uses the older 64-bit JIT compiler.                                                     |  
  
### Child elements

None
  
### Parent elements  
  
| Element         | Description                                                                                                       |  
| --------------- | ----------------------------------------------------------------------------------------------------------------- |  
| `configuration` | The root element in every configuration file used by the common language runtime and .NET Framework applications. |  
| `runtime`       | Contains information about runtime initialization options.                                                        |  
  
## Remarks  

Starting with the .NET Framework 4.6, the common language runtime uses a new 64-bit compiler for Just-In-Time (JIT) compilation by default. In some cases, this may result in a difference in behavior from application code that was JIT-compiled by the previous version of the 64-bit JIT compiler. By setting the `enabled` attribute of the `<useLegacyJit>` element to `1`, you can disable the new 64-bit JIT compiler and instead compile your app using the legacy 64-bit JIT compiler.  
  
> [!NOTE]
> The `<useLegacyJit>` element affects 64-bit JIT compilation only. Compilation with the 32-bit JIT compiler is unaffected.  
  
Instead of using a configuration file setting, you can enable the legacy 64-bit JIT compiler in two other ways:  
  
- Setting an environment variable

  Set the `COMPLUS_useLegacyJit` environment variable to either `0` (use the new 64-bit JIT compiler) or `1` (use the older 64-bit JIT compiler):
  
  ```env  
  COMPLUS_useLegacyJit=0|1  
  ```  
  
  The environment variable has *global scope*, which means that it affects all applications run on the machine. If set, it can be overridden by the application configuration file setting. The environment variable name is not case-sensitive.
  
- Adding a registry key

  You can enable the legacy 64-bit JIT compiler by adding a `REG_DWORD` value to either the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework` or `HKEY_CURRENT_USER\SOFTWARE\Microsoft\.NETFramework` key in the registry. The value is named `useLegacyJit`. If the value is 0, the new compiler is used. If the value is 1, the legacy 64-bit JIT compiler is enabled. The registry value name is not case-sensitive.
  
  Adding the value to the `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework` key affects all apps running on the machine. Adding the value to the `HKEY_CURRENT_USER\SOFTWARE\Microsoft\.NETFramework` key affects all apps run by the current user. If a machine is configured with multiple user accounts, only apps run by the current user are affected, unless the value is added to the registry keys for other users as well. Adding the `<useLegacyJit>` element to a configuration file overrides the registry settings, if they're present.  
  
## Example  

The following configuration file disables compilation with the new 64-bit JIT compiler and instead uses the legacy 64-bit JIT compiler.  
  
```xml  
<?xml version ="1.0"?>  
<configuration>  
  <runtime>  
    <useLegacyJit enabled="1" />  
  </runtime>  
</configuration>  
```  
  
## See also

- [\<runtime> Element](runtime-element.md)
- [\<configuration> Element](../configuration-element.md)
- [Mitigation: New 64-bit JIT Compiler](../../../migration-guide/mitigation-new-64-bit-jit-compiler.md)
