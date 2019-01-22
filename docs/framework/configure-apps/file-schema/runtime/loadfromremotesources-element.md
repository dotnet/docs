---
title: "&lt;loadFromRemoteSources&gt; Element"
ms.date: "05/24/2018"
helpviewer_keywords: 
  - "loadFromRemoteSources element"
  - "<loadFromRemoteSources> element"
ms.assetid: 006d1280-2ac3-4db6-a984-a3d4e275046a
author: "rpetrusha"
ms.author: "ronpet"
---
# &lt;loadFromRemoteSources&gt; element
Specifies whether assemblies loaded from remote sources should be granted full trust in .NET Framework 4 and later.
  
> [!NOTE]
>  If you were directed to this topic because of an error message in the Visual Studio project error list or a build error, see [How to: Use an Assembly from the Web in Visual Studio](https://msdn.microsoft.com/library/d8635b63-89a0-41aa-90f4-f351b2111070).  
  
 \<configuration>  
\<runtime>  
\<loadFromRemoteSources>  
  
## Syntax  
  
```xml  
<loadFromRemoteSources    
   enabled="true|false"/>  
```  
  
## Attributes and elements
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`enabled`|Required attribute.<br /><br /> Specifies whether an assembly that is loaded from a remote source should be granted full trust.|  
  
## enabled attribute  
  
|Value|Description|  
|-----------|-----------------|  
|`false`|Do not grant full trust to applications from remote sources. This is the default.|  
|`true`|Grant full trust to applications from remote sources.|  
  
### Child elements  
 None.  
  
### Parent elements  
  
|Element|Description|  
|-------------|-----------------|  
|`configuration`|The root element in every configuration file used by the common language runtime and .NET Framework applications.|  
|`runtime`|Contains information about runtime initialization options.|  
  
## Remarks

In the .NET Framework 3.5 and earlier versions, if you load an assembly from a remote location, code in the assembly runs in partial trust with a grant set that depends on the zone from which it is loaded. For example, if you load an assembly from a website, it is loaded into the Internet zone and granted the Internet permission set. In other words, it executes in an Internet sandbox.

Starting with the .NET Framework 4, code access security (CAS) policy is disabled and assemblies are loaded in full trust. Ordinarily, this would grant full trust to assemblies loaded with the <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> method that previously had been sandboxed. To prevent this, the ability to run code in assemblies loaded from a remote source is disabled by default. By default, if you attempt to load a remote assembly, a <xref:System.IO.FileLoadException> with an exception message like the following is thrown:

```text
System.IO.FileNotFoundException: Could not load file or assembly 'file:assem.dll' or one of its dependencies. Operation is not supported. 
(Exception from HRESULT: 0x80131515)
File name: 'file:assem.dll' ---> 
System.NotSupportedException: An attempt was made to load an assembly from a network location which would have caused the assembly 
to be sandboxed in previous versions of the .NET Framework. This release of the .NET Framework does not enable CAS policy by default, 
so this load may be dangerous. If this load is not intended to sandbox the assembly, please enable the loadFromRemoteSources switch. 
```

To load the assembly and execute its code, you must either:

- Explicitly create a sandbox for the assembly (see [How to: Run Partially Trusted Code in a Sandbox](../../../../../docs/framework/misc/how-to-run-partially-trusted-code-in-a-sandbox.md)).

- Run the assembly's code in full trust. You do this by configuring the `<loadFromRemoteSources>` element. It lets you specify that the assemblies that run in partial trust in earlier versions of the .NET Framework now run in full trust in the .NET Framework 4 and later versions.

> [!IMPORTANT]
> If the assembly should not run in full trust, do not set this configuration element. Instead, create a sandboxed <xref:System.AppDomain> in which to load the assembly.

The `enabled` attribute for the `<loadFromRemoteSources>` element is effective only when code access security (CAS) is disabled. By default, CAS policy is disabled in the .NET Framework 4 and later versions. If you set `enabled` to `true`, remote assemblies are granted full trust.

If `enabled` is not set to `true`, a <xref:System.IO.FileLoadException> is thrown under the either of the following conditions:

- The sandboxing behavior of the current domain is different from its behavior in the .NET Framework 3.5. This requires CAS policy to be disabled, and the current domain not to be sandboxed.

- The assembly being loaded is not from the `MyComputer` zone.

Setting the `<loadFromRemoteSources>` element to `true` prevents this exception from being thrown. It enables you to specify that you are not relying on the common language runtime to sandbox the loaded assemblies for security, and that they can be allowed to execute in full trust.

## Notes

- In the .NET Framework 4.5 and later versions, assemblies on local network shares run in full trust by default; you do not have to enable the `<loadFromRemoteSources>` element.

- If an application has been copied from the web, it is flagged by Windows as being a web application, even if it resides on the local computer. You can change that designation by changing its file properties, or you can use the `<loadFromRemoteSources>` element to grant the assembly full trust. As an alternative, you can use the <xref:System.Reflection.Assembly.UnsafeLoadFrom%2A> method to load a local assembly that the operating system has flagged as having been loaded from the web.

- You may get a <xref:System.IO.FileLoadException> in an application that is running in a Windows Virtual PC application. This can happen when you try to load a file from linked folders on the hosting computer. It can also occur when you try to load a file from a folder linked over [Remote Desktop Services](https://go.microsoft.com/fwlink/?LinkId=182775) (Terminal Services). To avoid the exception, set `enabled` to `true`.

## Configuration file

This element is typically used in the application configuration file, but can be used in other configuration files depending upon the context. For more information, see the article [More Implicit Uses of CAS Policy: loadFromRemoteSources](https://go.microsoft.com/fwlink/p/?LinkId=266839) in the .NET Security blog.  

## Example

The following example shows how to grant full trust to assemblies loaded from remote sources.

```xml
<configuration>  
   <runtime>  
      <loadFromRemoteSources enabled="true"/>  
   </runtime>  
</configuration>  
```

## See also

- [More Implicit Uses of CAS Policy: loadFromRemoteSources](https://go.microsoft.com/fwlink/p/?LinkId=266839)
- [How to: Run Partially Trusted Code in a Sandbox](../../../../../docs/framework/misc/how-to-run-partially-trusted-code-in-a-sandbox.md)
- [Runtime Settings Schema](../../../../../docs/framework/configure-apps/file-schema/runtime/index.md)
- [Configuration File Schema](../../../../../docs/framework/configure-apps/file-schema/index.md)
- <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType>
