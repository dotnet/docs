---
title: "MissingInteropDataException Class (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: eab4bcf8-9f5f-4731-87d8-842748a6062a
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# MissingInteropDataException Class (.NET Native)
**.NET for Windows apps for Windows 10, [!INCLUDE[net_native](../../../includes/net-native-md.md)] only**  
  
 The exception that is thrown when a manual marshaling method is called, but metadata for a type isn't found by static analysis or in a runtime directives file.  
  
 **Namespace:** System.Runtime.CompilerServices  
  
> [!IMPORTANT]
>  The `MissingInteropDataException` class is intended solely for internal use by the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain. It is not intended for use in third-party code, nor should you handle the exception in your application code. Instead, you eliminate the exception by adding entries to your [runtime directives file](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md). For more information, see the Remarks section.  
  
## Syntax  
 [!code-csharp[ProjectN#21](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/missinginteropdataexception_syntax1.cs#21)]
 [!code-vb[ProjectN#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/projectn/vb/missinginteropdataexception_syntax1.vb#21)]  
  
 The `MissingInteropDataException` class has the following members:  
  
## Constructors  
  
|Constructor|Description|  
|-----------------|-----------------|  
|`public MissingInteropDataException(String resourceId, Type pertinentType)`|Initializes a new instance of the `MissingInteropDataException` class by using the ID of a system-supplied message that describes the error and the type whose data is missing. This constructor is for internal use by the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain only.|  
  
## Properties  
  
|Property|Description|  
|--------------|-----------------|  
|`public IDictionary Data { get; }`|Gets a collection of key/value pairs that provide additional user-defined information about the exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public string HelpLink { get; set; }`|Gets or sets a link to the help file associated with this exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public int HResult { get; protected set; }`|Gets or sets the `HRESULT`, which is a coded numeric value that is assigned to a specific exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public Exception InnerException { get; }`|Gets the exception that caused the current exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public string Message { get; }`|Gets a message that describes the current exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public Type MissingType { get; private set; }`|Gets or sets the type whose data is missing.|  
|`public string Source { get; set; }`|Gets or sets the name of the app or object that caused the error. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public string StackTrace { get; }`|Gets a string representation of the immediate frames on the call stack. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public MethodBase TargetSite { get; }`|Gets the method that threw the current exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`public bool Equals(Object obj)`|Determines whether the specified object is equal to the current object.  (Inherited from <xref:System.Object>.)|  
|`protected void Finalize()`|Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. (Inherited from <xref:System.Object>.)|  
|`public Exception GetBaseException()`|Returns the exception that is the root cause of one or more subsequent exceptions. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public int GetHashCode()`|Returns a hash code for a `MissingInteropDataException` instance.   (Inherited from <xref:System.Object>.)|  
|`public void GetObjectData(SerializationInfo info, StreamingContext context)`|Sets a <xref:System.Runtime.Serialization.SerializationInfo> object with information about the exception.  (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public Type GetType()`|Gets the runtime type of the current instance. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`protected Object MemberwiseClone()`|Creates a shallow copy of the current object. (Inherited from <xref:System.Object>.)|  
|`public string ToString()`|Returns the string representation of the current exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
  
## Events  
  
|Event|Description|  
|-----------|-----------------|  
|`protected event EventHandler<SafeSerializationEventArgs> SerializeObjectState`|Occurs when an exception is serialized to create an exception state object that contains serialized data about the exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
  
## Usage Details  
 The `MissingInteropDataException` exception is thrown when a method call to a COM or Windows Runtime component cannot be made successfully because type information isn't available.  
  
 The metadata that is available to an app at run time is defined by the runtime directives (XML configuration) file, *.rd.xml. To prevent your app from throwing this exception, you must modify this file to define the metadata that must be present at run time. Most commonly, you address this error by adding a `MarshalObject`, `MarshalDelegate`, or `MarshalStructure` attribute to an appropriate program element in the runtime directives file. For information about the format of this file, see [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md).  
  
> [!IMPORTANT]
>  Because this exception indicates that metadata needed by your application isn’t available at run time, you shouldn’t handle this exception in a `try`/`catch` block. Instead, you should diagnose the cause of the exception and eliminate it by adding the appropriate entry to a runtime directives file.  
  
 The `MissingInteropDataException` class contains a single unique member, the `MissingType` property, that indicates the type whose metadata is needed for a successful method call. All remaining members are inherited from the base class, <xref:System.Exception?displayProperty=nameWithType>.  
  
## See Also  
 <xref:System.Exception?displayProperty=nameWithType>  
 [MissingMetadataException Class](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md)  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)
