---
title: "Mitigation: Deserialization of Objects Across App Domains"
description: Learn how to diagnose and mitigate an issue where an attempt to deserialize objects in the logical call context across app domains throws an exception.
ms.date: "03/02/2026"
ai-usage: ai-assisted
ms.assetid: 30c2d66c-04a8-41a5-ad31-646b937f61b5
---
# Mitigation: Deserialization of Objects Across App Domains

In some cases, when an app uses two or more app domains with different application bases, the attempt to deserialize objects in the logical call context across app domains throws an exception.

## Diagnose the issue

The issue arises under the following sequence of conditions:

1. An app uses two or more app domains with different application bases.

1. Some types are explicitly added to the <xref:System.Runtime.Remoting.Messaging.LogicalCallContext> by calling a method such as <xref:System.Runtime.Remoting.Messaging.LogicalCallContext.SetData%2A?displayProperty=nameWithType> or <xref:System.Runtime.Remoting.Messaging.CallContext.LogicalSetData%2A?displayProperty=nameWithType>. These types aren't marked as serializable and aren't stored in the global assembly cache.

1. Later, code running in the non-default app domain tries to read a value from a configuration file or use XML to deserialize an object.

1. To read from a configuration file or deserialize the object, an <xref:System.Xml.XmlReader> object tries to access the configuration system.

1. If the configuration system hasn't already been initialized, it must complete its initialization. This means, among other things, that the runtime has to create a stable path for a configuration system, which it does as follows:

    1. It looks for evidence for the non-default app domain.

    1. It tries to calculate the evidence for the non-default app domain based on the default app domain.

    1. The call to get evidence for the default app domain triggers a cross-app domain call from the non-default app domain to the default app domain.

    1. As part of the cross-app domain contract in the .NET Framework, the contents of the logical call context also have to be marshaled across app domain boundaries.

1. Because the types in the logical call context can't be resolved in the default app domain, an exception is thrown.

## Mitigation

To work around this issue:

1. Look for the following calls in the call stack when the exception is thrown. Different exception types might appear, including <xref:System.IO.FileNotFoundException> and <xref:System.Runtime.Serialization.SerializationException>.

   - On earlier versions of .NET Framework, look for `get_Evidence`.
   - On .NET Framework 4.7.2 and later, look for `GetHostEvidence` or `GetEvidenceInfo`.

1. Choose a mitigation based on how the exception occurs:

   - **If objects added to the logical call context later cause an exception during configuration system initialization or a cross-app domain call**: Identify the place in the app where objects are added to the logical call context and add the following code before that point:

     ```csharp
     System.Configuration.ConfigurationManager.GetSection("system.xml/xmlReader");
     ```

   - **If the exception occurs due to a cross-app domain call** (as indicated by `GetHostEvidence` or `GetEvidenceInfo` in the stack trace): In the non-default app domain, initialize the configuration system by calling the following code before any cross-app domain calls:

     ```csharp
     System.Configuration.ConfigurationManager.GetSection("system.xml/xmlReader");
     ```

## See also

- [Application compatibility](application-compatibility.md)
