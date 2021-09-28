---
title: "Mitigation: ZipArchiveEntry.FullName Path Separator"
description: Learn how the path separator for the ZipArchiveEntry.FullName property has changed starting with apps that target .NET Framework 4.6.1.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "application compatibility"
  - ",NET Framework application compatibility"
  - ".NET Framework 4.6.1"
  - ".NET Framework 4.6.1 retargeting changes"
  - "retargeting changes"
ms.assetid: 8d575722-4fb6-49a2-8a06-f72d62dc3766
---
# Mitigation: ZipArchiveEntry.FullName Path Separator

Starting with apps that target the .NET Framework 4.6.1, the path separator used in the <xref:System.IO.Compression.ZipArchiveEntry.FullName%2A?displayProperty=nameWithType> property has changed from the backslash ("\\") used in previous versions of .NET Framework to a forward slash ("/"). <xref:System.IO.Compression.ZipArchiveEntry?displayProperty=nameWithType> objects are created by calling one of the overloads of the <xref:System.IO.Compression.ZipFile.CreateFromDirectory%2A?displayProperty=nameWithType> method.  
  
## Impact  

 The change brings the .NET implementation into conformity with section 4.4.17.1 of the [.ZIP File Format Specification](https://pkware.cachefly.net/webdocs/casestudies/APPNOTE.TXT) and allows .ZIP archives to be decompressed on non-Windows systems.  
  
 Decompressing a zip file created by an app that targets a previous version of .NET Framework on non-Windows operating systems such as MacOS fails to preserve the directory structure. For example, on MacOS, it creates a set of files whose file name concatenates the directory path, any backslash ("\\") characters, and the filename. As a result, the directory structure of decompressed files is not preserved.  
  
 The impact of this change on .ZIP files that are decompressed on the Windows operating system by APIs in .NET Framework <xref:System.IO> namespace should be minimal, since these APIs can seamlessly handle either a slash ("/") or a backslash ("\\") as the path separator character.  
  
## Mitigation  

 If this behavior is undesirable, you can opt out of by adding a configuration setting to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of your application configuration file. The following shows both the `<runtime>` section and the opt-out switch.  
  
```xml  
<runtime>  
   <AppContextSwitchOverrides value="Switch.System.IO.Compression.ZipFile.UseBackslash=true" />  
</runtime>  
```  
  
 In addition, apps that target previous versions of .NET Framework but are running on .NET Framework 4.6.1 and later versions can opt in to this behavior by adding a configuration setting to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of the application configuration file. The following shows both the `<runtime>` section and the opt-in switch.  
  
```xml  
<runtime>  
   <AppContextSwitchOverrides value="Switch.System.IO.Compression.ZipFile.UseBackslash=false" />  
</runtime>  
```  
  
## See also

- [Application compatibility](application-compatibility.md)
