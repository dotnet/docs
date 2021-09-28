---
title: "Mitigation: PNG Frames in Icon Objects"
description: Learn how to configure the behavior of PNG frames in icon objects if the new behavior included in .NET Framework 4.6 and later is undesirable.
ms.date: "03/30/2017"
ms.assetid: ca87fefb-7144-4b4e-8832-5a939adbb4b2
---
# Mitigation: PNG Frames in Icon Objects

Starting with the .NET Framework 4.6, the <xref:System.Drawing.Icon.ToBitmap%2A?displayProperty=nameWithType> method successfully converts icons with PNG frames into <xref:System.Drawing.Bitmap> objects.  
  
 In apps that target the .NET Framework 4.5.2 and earlier versions, the <xref:System.Drawing.Icon.ToBitmap%2A?displayProperty=nameWithType> method throws an <xref:System.ArgumentOutOfRangeException> exception if the <xref:System.Drawing.Icon> object has PNG frames.  
  
## Impact  

 This change affects apps that are recompiled to target the .NET Framework 4.6 and that implement special handling for the <xref:System.ArgumentOutOfRangeException> that is thrown when an <xref:System.Drawing.Icon> object has PNG frames. When running under the .NET Framework 4.6, the conversion is successful, an <xref:System.ArgumentOutOfRangeException> is no longer thrown, and therefore the exception handler is no longer invoked.  
  
### Mitigation  

 If this behavior is undesirable, you can retain the previous behavior by adding the following element to the [\<runtime>](../configure-apps/file-schema/runtime/runtime-element.md) section of your app.config file:  
  
```xml  
<AppContextSwitchOverrides
      value="Switch.System.Drawing.DontSupportPngFramesInIcons=true" />  
```  
  
 If the app.config file already contains the `AppContextSwitchOverrides` element, the new value should be merged with the `value` attribute like this:  
  
```xml  
<AppContextSwitchOverrides
      value="Switch.System.Drawing.DontSupportPngFramesInIcons=true;previous key=previous-value" />
```
  
## See also

- [Application compatibility](application-compatibility.md)
