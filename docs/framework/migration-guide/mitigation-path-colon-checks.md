---
title: "Mitigation: Path Colon Checks"
description: Learn about the changes made in .NET Framework 4.6.2 to support checks for the proper drive separator syntax (the colon).
ms.date: "03/30/2017"
ms.assetid: a0bb52de-d279-419d-8f23-4b12d1a3f36e
---
# Mitigation: Path Colon Checks

Starting with apps that target the .NET Framework 4.6.2, a number of changes were made to support previously unsupported paths (both in terms of length and format). In particular, checks for the proper drive separator syntax (the colon) were made more correct.  
  
## Impact  

 These changes block some URI paths the <xref:System.IO.Path.GetDirectoryName%2A?displayProperty=nameWithType> and <xref:System.IO.Path.GetPathRoot%2A?displayProperty=nameWithType> methods previously supported.  
  
## Mitigation  

 To work around the problem of a previously acceptable path that is no longer supported by the <xref:System.IO.Path.GetDirectoryName%2A?displayProperty=nameWithType> and <xref:System.IO.Path.GetPathRoot%2A?displayProperty=nameWithType> methods, you can do the following:  
  
- Manually remove the scheme from a URL. For example, remove `file://` from a URL.  
  
- Pass the URI to a <xref:System.Uri> constructor,  and retrieve the value of the <xref:System.Uri.LocalPath%2A?displayProperty=nameWithType> property.  
  
- Opt out of the new path normalization by setting the `Switch.System.IO.UseLegacyPathHandling`<xref:System.AppContext> switch to `true`.  
  
    ```xml  
    <runtime>  
        <AppContextSwitchOverrides value="Switch.System.IO.UseLegacyPathHandling=true" />
    </runtime>  
    ```  
  
## See also

- [Application compatibility](application-compatibility.md)
