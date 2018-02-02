---
title: "MissingMetadataException Class (.NET Native)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 408f25c4-6d60-475c-92b1-7b52b777c6db
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# MissingMetadataException Class (.NET Native)
**.NET for Windows apps for Windows 10, [!INCLUDE[net_native](../../../includes/net-native-md.md)] only**  
  
 The exception that is thrown when reflection is used to retrieve metadata that isn't present.  
  
 **Namespace:** System.Reflection  
  
> [!IMPORTANT]
>  The `MissingMetadataException` class is intended solely for internal use by the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain. It is not intended for use in third-party code, nor should you handle the exception in your application code. Instead, you eliminate the exception by adding entries to your [runtime directives file](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md). For more information, see the Remarks section.  
  
## Syntax  
 [!code-csharp[ProjectN#4](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/missingmetadataexception_syntax1.cs#4)]  
  
 Note that the `MissingMetadataException` class derives from <xref:System.TypeAccessException>.  
  
 The `MissingMetadataException` class has the following members:  
  
## Constructors  
  
|Constructor|Description|  
|-----------------|-----------------|  
|`public MissingMetadataException()`|Initializes a new instance of the `MissingMetadataException` class by using a system-supplied message that describes the error.<br /><br /> This constructor is for internal use by the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain only.|  
|`public MissingMetadataException(String message)`|Initializes a new instance of the `MissingMetadataException` class with a specified error message.<br /><br /> This constructor is for internal use by the [!INCLUDE[net_native](../../../includes/net-native-md.md)] torol chain only.|  
  
## Properties  
  
|Property|Description|  
|--------------|-----------------|  
|`public IDictionary Data { get; }`|Gets a collection of key/value pairs that provide additional user-defined information about the exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public string HelpLink { get; set; }`|Gets or sets a link to the help file associated with this exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public int HResult { get; protected set; }`|Gets or sets the `HRESULT`, a coded numeric value that is assigned to a specific exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public Exception InnerException { get; }`|Gets the exception that caused the current exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public string Message { get; }`|Gets a message that describes the current exception. (Inherited from <xref:System.TypeLoadException>.)|  
|`public string Source { get; set; }`|Gets or sets the name of the application or object that caused the error. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public string StackTrace { get; }`|Gets a string representation of the immediate frames on the call stack. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public MethodBase TargetSite { get; }`|Gets the method that threw the current exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public string TypeName { get; ]`|Gets the fully qualified name of the type whose metadata is missing. (Inherited from <xref:System.TypeLoadException>.)|  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`public bool Equals(Object obj)`|Determines whether the specified object is equal to the current object.  (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`protected void Finalize()`|Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. (Inherited from <xref:System.Object>.)|  
|`public Exception GetBaseException()`|Returns the exception that is the root cause of one or more subsequent exceptions. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`public int GetHashCode()`|Returns a hash code for a `MissingMetadataException` instance.   (Inherited from <xref:System.Object>.)|  
|`public void GetObjectData(SerializationInfo info, StreamingContext context)`|Sets a <xref:System.Runtime.Serialization.SerializationInfo> object with information about the exception.  (Inherited from <xref:System.TypeLoadException>.)|  
|`public Type GetType()`|Gets the runtime type of the current instance. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
|`protected Object MemberwiseClone()`|Creates a shallow copy of the current object. (Inherited from <xref:System.Object>.)|  
|`public string ToString()`|Returns the string representation of the current exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
  
## Events  
  
|Event|Description|  
|-----------|-----------------|  
|`protected event EventHandler<SafeSerializationEventArgs> SerializeObjectState`|Occurs when an exception is serialized to create an exception state object that contains serialized data about the exception. (Inherited from <xref:System.Exception?displayProperty=nameWithType>.)|  
  
## Usage Details  
 The `MissingMetadataException` exception is thrown when reflection is used to access metadata that isn’t available in an assembly.  
  
 The metadata that is available to an app at run time is defined by the runtime directives (XML configuration) file, *.rd.xml. To prevent your app from throwing this exception, you must modify \*.rd.xml to define the metadata that must be present at run time. For information about the format of the \*.rd.xml file, see [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md).  
  
> [!IMPORTANT]
>  Because this exception indicates that metadata needed by your application isn’t available at run time, you shouldn’t handle this exception in a `try`/`catch` block. Instead, you should diagnose the cause of the exception and eliminate it by using a runtime directives file. To get the entry that you can add to your runtime directives file that eliminates the exception, you can use one of two troubleshooters:  
>   
>  -   The [MissingMetadataException troubleshooter](http://dotnet.github.io/native/troubleshooter/type.html) for types.  
> -   The [MissingMetadataException troubleshooter](http://dotnet.github.io/native/troubleshooter/method.html) for methods.  
  
 The `MissingMetadataException` class contains no unique members; all of its members are inherited from its base class, <xref:System.TypeAccessException>.  
  
## See Also  
 <xref:System.Exception?displayProperty=nameWithType>  
 <xref:System.TypeAccessException>  
 [MissingInteropDataException Class](../../../docs/framework/net-native/missinginteropdataexception-class-net-native.md)  
 [MissingRuntimeArtifactException Class](../../../docs/framework/net-native/missingruntimeartifactexception-class-net-native.md)  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)
