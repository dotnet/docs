---
title: Serialization of control characters with DataContractJsonSerializer
description: Learn about the way control characters serialization has changed to conform to ECMAScript V6 and V8 in .NET Framework 4.7.
ms.date: 04/07/2017
helpviewer_keywords: 
  - ".NET Framework 4.7 retargeting changes"
  - "retargeting changes"
  - "DataContractJsonSerializer changes"
  - "serialization changes"
ms.assetid: e065d458-a128-44f2-9f17-66af9d5be954
---
# Mitigation: Serialization of control characters with the DataContractJsonSerializer

Starting with .NET Framework 4.7, the way in which control characters are serialized with the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> has changed to conform to ECMAScript V6 and V8.

## Impact

In .NET Framework 4.6.2 and earlier versions, the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> did not serialize some special control characters, such as `\b`, `\f`, and `\t`, in a way that was compatible with the ECMAScript V6 and V8 standards.

For apps that target versions of .NET Framework starting with .NET Framework 4.7, serialization of these control characters is compatible with ECMAScript V6 and V8. The following APIs are affected:

- <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject%2A>

## Mitigation

For apps that target versions of .NET Framework starting with .NET Framework 4.7, this behavior is enabled by default.

If this behavior is not desirable, you can opt out of this feature by adding the following line to the `<runtime>` section of the app.config or web.config file:

```xml
<runtime>
   <AppContextSwitchOverrides value="Switch.System.Runtime.Serialization.DoNotUseECMAScriptV6EscapeControlCharacter=false" />
</runtime>
```

## See also

- [Application compatibility](application-compatibility.md)
