---
title: "Mitigation: Path Normalization"
description: Learn how path normalization in .NET Framework has changed beginning with apps that target .NET Framework 4.6.2.
ms.date: "03/30/2017"
ms.assetid: 158d47b1-ba6d-4fa6-8963-a012666bdc31
---
# Mitigation: Path Normalization

Starting with apps that target .NET Framework 4.6.2, path normalization in the .NET Framework has changed.  
  
## What is path normalization?  

 Normalizing a path involves modifying the string that identifies a path or file so that it conforms to a valid path on the target operating system. Normalization typically involves:  
  
- Canonicalizing component and directory separators.  
  
- Applying the current directory to a relative path.  
  
- Evaluating the relative directory (`.`) or the parent directory (`..`) in a path.  
  
- Trimming specified characters.  
  
## The changes  

 Starting with apps that target the .NET Framework 4.6.2, path normalization has changed in the following ways:  
  
- The runtime defers to the operating system's [GetFullPathName](/windows/desktop/api/fileapi/nf-fileapi-getfullpathnamea) function to normalize paths.  
  
- Normalization no longer involves trimming the end of directory segments (such as a space at the end of a directory name).  
  
- Support for device path syntax in full trust, including  `\\.\` and, for file I/O APIs   in mscorlib.dll, `\\?\`.  
  
- The runtime does not validate device syntax paths.  
  
- The use of device syntax to access alternate data streams is supported.  
  
## Impact  

For apps that target the .NET Framework 4.6.2 or later, these changes are on  by default. They should improve performance while allowing methods to access previously inaccessible paths.  
  
Apps that target the .NET Framework 4.6.1 and earlier versions but are running under the .NET Framework 4.6.2 or later are unaffected by this change.  
  
## Mitigation  

 Apps that target the .NET Framework 4.6.2 or later can opt out of this change and use legacy normalization by adding the following to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of the application configuration file:  
  
```xml  
<runtime>  
    <AppContextSwitchOverrides value="Switch.System.IO.UseLegacyPathHandling=true" />
</runtime>  
```  
  
Apps that target the .NET Framework 4.6.1 or earlier but are running on the .NET Framework 4.6.2 or later can enable the changes to path normalization by adding the following line to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of the application .configuration file:  
  
```xml  
<runtime>  
    <AppContextSwitchOverrides value="Switch.System.IO.UseLegacyPathHandling=false" />
</runtime>  
```  
  
## See also

- [Application compatibility](application-compatibility.md)
