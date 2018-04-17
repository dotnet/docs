---
title: "Serialization concepts"
ms.date: "08/07/2017"
ms.prod: ".net"
ms.topic: "article"
ms.assetid: e1ff4740-20a1-4c76-a8ad-d857db307054
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Serialization concepts
Why would you want to use serialization? The two most important reasons are to persist the state of an object to a storage medium so an exact copy can be re-created at a later stage, and to send the object by value from one application domain to another. For example, serialization is used to save session state in ASP.NET and to copy objects to the Clipboard in Windows Forms. It is also used by remoting to pass objects by value from one application domain to another.

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]

## Persistent storage
It is often necessary to store the value of the fields of an object to disk and then, later, retrieve this data. Although this is easy to achieve without relying on serialization, this approach is often cumbersome and error prone, and becomes progressively more complex when you need to track a hierarchy of objects. Imagine writing a large business application, that contains thousands of objects, and having to write code to save and restore the fields and properties to and from disk for each object. Serialization provides a convenient mechanism for achieving this objective.

The common language runtime manages how objects are stored in memory and provides an automated serialization mechanism by using [reflection](../../../docs/framework/reflection-and-codedom/reflection.md). When an object is serialized, the name of the class, the assembly, and all the data members of the class instance are written to storage. Objects often store references to other instances in member variables. When the class is serialized, the serialization engine tracks referenced objects, already serialized, to ensure that the same object is not serialized more than once. The serialization architecture provided with the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] correctly handles object graphs and circular references automatically. The only requirement placed on object graphs is that all objects, referenced by the serialized object, must also be marked as `Serializable` (for more information, see [Basic Serialization](basic-serialization.md)). If this is not done, an exception will be thrown when the serializer attempts to serialize the unmarked object.

When the serialized class is deserialized, the class is recreated and the values of all the data members are automatically restored.

## Marshal by value
Objects are valid only in the application domain where they are created. Any attempt to pass the object as a parameter or return it as a result will fail unless the object derives from `MarshalByRefObject` or is marked as `Serializable`. If the object is marked as `Serializable`, the object will automatically be serialized, transported from the one application domain to the other, and then deserialized to produce an exact copy of the object in the second application domain. This process is typically referred to as marshal-by-value.
 
When an object derives from `MarshalByRefObject`, an object reference is passed from one application domain to another, rather than the object itself. You can also mark an object that derives from `MarshalByRefObject` as `Serializable`. When this object is used with remoting, the formatter responsible for serialization, which has been preconfigured with a surrogate selector (`SurrogateSelector`), takes control of the serialization process, and replaces all objects derived from `MarshalByRefObject` with a proxy. Without the `SurrogateSelector` in place, the serialization architecture follows the standard serialization rules described in [Steps in the Serialization Process](steps-in-the-serialization-process.md).  

## Related sections  
 [Binary Serialization](../../../docs/standard/serialization/binary-serialization.md)  
 Describes the binary serialization mechanism that is included with the common language runtime.  
  
 [Remote Objects](https://msdn.microsoft.com/library/515686e6-0a8d-42f7-8188-73abede57c58)  
 Describes the various communications methods available in the .NET Framework for remote communications.  
  
 [XML and SOAP Serialization](../../../docs/standard/serialization/xml-and-soap-serialization.md)  
 Describes the XML and SOAP serialization mechanism that is included with the common language runtime.
