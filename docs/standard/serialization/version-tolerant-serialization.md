---
title: "Version tolerant serialization"
ms.date: "08/08/2017"
ms.prod: ".net"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "version tolerant serialization"
  - "serialization, custom serialization"
  - "serialization, version tolerant"
  - "serialization, controlling"
  - "versions and serialization"
  - "BinaryFormatter class, samples"
  - "serialization, attributes"
ms.assetid: bea0ffe3-2708-4a16-ac7d-e586ed6b8e8d
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Version tolerant serialization
In version 1.0 and 1.1 of the .NET Framework, creating serializable types that would be reusable from one version of an application to the next was problematic. If a type was modified by adding extra fields, the following problems would occur:  
  
-   Older versions of an application would throw exceptions when asked to deserialize new versions of the old type.  
  
-   Newer versions of an application would throw exceptions when deserializing older versions of a type with missing data.  
  
 Version Tolerant Serialization (VTS) is a set of features introduced in .NET Framework 2.0 that makes it easier, over time, to modify serializable types. Specifically, the VTS features are enabled for classes to which the <xref:System.SerializableAttribute> attribute has been applied, including generic types. VTS makes it possible to add new fields to those classes without breaking compatibility with other versions of the type. For a working sample application, see [Version Tolerant Serialization Technology Sample](../../../docs/standard/serialization/version-tolerant-serialization-technology-sample.md).  
  
 The VTS features are enabled when using the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>. Additionally, all features except extraneous data tolerance are also enabled when using the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>. For more information about using these classes for serialization, see [Binary Serialization](binary-serialization.md).  
  
[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]

## Feature list  
 The set of features includes the following:  
  
-   Tolerance of extraneous or unexpected data. This enables newer versions of the type to send data to older versions.  
  
-   Tolerance of missing optional data. This enables older versions to send data to newer versions.  
  
-   Serialization callbacks. This enables intelligent default value setting in cases where data is missing.  
  
 In addition, there is a feature for declaring when a new optional field has been added. This is the <xref:System.Runtime.Serialization.OptionalFieldAttribute.VersionAdded%2A> property of the <xref:System.Runtime.Serialization.OptionalFieldAttribute> attribute.  
  
 These features are discussed in greater detail below.  
  
## Tolerance of extraneous or unexpected data  
 In the past, during deserialization, any extraneous or unexpected data caused exceptions to be thrown. With VTS, in the same situation, any extraneous or unexpected data is ignored instead of causing exceptions to be thrown. This enables applications that use newer versions of a type (that is, a version that includes more fields) to send information to applications that expect older versions of the same type.  
  
 In the following example, the extra data contained in the `CountryField` of version 2.0 of the `Address` class is ignored when an older application deserializes the newer version.  
  
```csharp  
// Version 1 of the Address class.  
[Serializable]  
public class Address  
{  
    public string Street;  
    public string City;  
}  
// Version 2.0 of the Address class.  
[Serializable]  
public class Address  
{  
    public string Street;  
    public string City;  
    // The older application ignores this data.  
    public string CountryField;  
}  
```  
  
```vb  
' Version 1 of the Address class.  
<Serializable> _  
Public Class Address  
    Public Street As String  
    Public City As String  
End Class  
  
' Version 2.0 of the Address class.  
<Serializable> _  
Public Class Address  
    Public Street As String  
    Public City As String  
    ' The older application ignores this data.  
    Public CountryField As String  
End Class  
```  
  
## Tolerance of missing data  
 Fields can be marked as optional by applying the <xref:System.Runtime.Serialization.OptionalFieldAttribute> attribute to them. During deserialization, if the optional data is missing, the serialization engine ignores the absence and does not throw an exception. Thus, applications that expect older versions of a type can send data to applications that expect newer versions of the same type.  
  
 The following example shows version 2.0 of the `Address` class with the `CountryField` field marked as optional. If an older application sends version 1 to a newer application that expects version 2.0, the absence of the data is ignored.  
  
```csharp  
[Serializable]  
public class Address  
{  
    public string Street;  
    public string City;  
  
    [OptionalField]  
    public string CountryField;  
}  
```  
  
```vb  
<Serializable> _  
Public Class Address  
    Public Street As String  
    Public City As String  
  
    <OptionalField> _  
    Public CountryField As String  
End Class  
```  
  
## Serialization callbacks  
 Serialization callbacks are a mechanism that provides hooks into the serialization/deserialization process at four points.  
  
|Attribute|When the Associated Method is Called|Typical Use|  
|---------------|------------------------------------------|-----------------|  
|<xref:System.Runtime.Serialization.OnDeserializingAttribute>|Before deserialization.*|Initialize default values for optional fields.|  
|<xref:System.Runtime.Serialization.OnDeserializedAttribute>|After deserialization.|Fix optional field values based on contents of other fields.|  
|<xref:System.Runtime.Serialization.OnSerializingAttribute>|Before serialization.|Prepare for serialization. For example, create optional data structures.|  
|<xref:System.Runtime.Serialization.OnSerializedAttribute>|After serialization.|Log serialization events.|  
  
 \* This callback is invoked before the deserialization constructor, if one is present.  
  
### Using callbacks  
 To use callbacks, apply the appropriate attribute to a method that accepts a <xref:System.Runtime.Serialization.StreamingContext> parameter. Only one method per class can be marked with each of these attributes. For example:  
  
```csharp  
[OnDeserializing]  
private void SetCountryRegionDefault(StreamingContext sc)  
{  
    CountryField = "Japan";  
}  
```  
  
```vb  
<OnDeserializing>  
Private Sub SetCountryRegionDefault(StreamingContext sc)  
    CountryField = "Japan";  
End Sub  
```  
  
 The intended use of these methods is for versioning. During deserialization, an optional field may not be correctly initialized if the data for the field is missing. This can be corrected by creating the method that assigns the correct value, then applying either the **OnDeserializingAttribute** or **OnDeserializedAttribute** attribute to the method.  
  
 The following example shows the method in the context of a type. If an earlier version of an application sends an instance of the `Address` class to a later version of the application, the `CountryField` field data will be missing. But after deserialization, the field will be set to a default value "Japan."  
  
```csharp  
[Serializable]  
public class Address  
{  
    public string Street;  
    public string City;  
    [OptionalField]  
    public string CountryField;  
  
    [OnDeserializing]  
    private void SetCountryRegionDefault (StreamingContext sc)  
    {  
        CountryField = "Japan";  
    }  
}  
```  
  
```vb  
<Serializable> _  
Public Class Address  
    Public Street As String  
    Public City As String  
    <OptionalField> _  
    Public CountryField As String  
  
    <OnDeserializing> _  
    Private Sub SetCountryRegionDefault(StreamingContext sc)  
        CountryField = "Japan";  
    End Sub  
End Class  
```  
  
## The VersionAdded property  
 The **OptionalFieldAttribute** has the **VersionAdded** property. In version 2.0 of the .NET Framework, this isn't used. However, it's important to set this property correctly to ensure that the type will be compatible with future serialization engines.  
  
 The property indicates which version of a type a given field has been added. It should be incremented by exactly one (starting at 2) every time the type is modified, as shown in the following example:  
  
```csharp  
// Version 1.0  
[Serializable]  
public class Person  
{  
    public string FullName;  
}  
  
// Version 2.0  
[Serializable]  
public class Person  
{  
    public string FullName;  
  
    [OptionalField(VersionAdded = 2)]  
    public string NickName;  
    [OptionalField(VersionAdded = 2)]  
    public DateTime BirthDate;  
}  
  
// Version 3.0  
[Serializable]  
public class Person  
{  
    public string FullName;  
  
    [OptionalField(VersionAdded=2)]  
    public string NickName;  
    [OptionalField(VersionAdded=2)]  
    public DateTime BirthDate;  
  
    [OptionalField(VersionAdded=3)]  
    public int Weight;  
}  
```  
  
```vb  
' Version 1.0  
<Serializable> _  
Public Class Person  
    Public FullName  
End Class  
  
' Version 2.0  
<Serializable> _  
Public Class Person  
    Public FullName As String  
  
    <OptionalField(VersionAdded := 2)> _  
    Public NickName As String  
    <OptionalField(VersionAdded := 2)> _  
    Public BirthDate As DateTime  
End Class  
  
' Version 3.0  
<Serializable> _  
Public Class Person  
    Public FullName As String  
  
    <OptionalField(VersionAdded := 2)> _  
    Public NickName As String  
    <OptionalField(VersionAdded := 2)> _  
    Public BirthDate As DateTime  
  
    <OptionalField(VersionAdded := 3)> _  
    Public Weight As Integer  
End Class  
```  
  
## SerializationBinder  
 Some users may need to control which class to serialize and deserialize because a different version of the class is required on the server and client. <xref:System.Runtime.Serialization.SerializationBinder> is an abstract class used to control the actual types used during serialization and deserialization.  To use this class, derive a class from <xref:System.Runtime.Serialization.SerializationBinder> and override the <xref:System.Runtime.Serialization.SerializationBinder.BindToName%2A> and <xref:System.Runtime.Serialization.SerializationBinder.BindToType%2A> methods. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Controlling Serialization and Deserialization with SerializationBinder](../../../docs/framework/wcf/feature-details/controlling-serialization-and-deserialization-with-serializationbinder.md).  
  
## Best practices  
 To ensure proper versioning behavior, follow these rules when modifying a type from version to version:  
  
-   Never remove a serialized field.  
  
-   Never apply the <xref:System.NonSerializedAttribute> attribute to a field if the attribute was not applied to the field in the previous version.  
  
-   Never change the name or the type of a serialized field.  
  
-   When adding a new serialized field, apply the **OptionalFieldAttribute** attribute.  
  
-   When removing a **NonSerializedAttribute** attribute from a field (that was not serializable in a previous version), apply the **OptionalFieldAttribute** attribute.  
  
-   For all optional fields, set meaningful defaults using the serialization callbacks unless 0 or **null** as defaults are acceptable.  
  
 To ensure that a type will be compatible with future serialization engines, follow these guidelines:  
  
-   Always set the **VersionAdded** property on the **OptionalFieldAttribute** attribute correctly.  
  
-   Avoid branched versioning.  
  
## See also  
 <xref:System.SerializableAttribute>  
 <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>  
 <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>  
 <xref:System.Runtime.Serialization.OptionalFieldAttribute.VersionAdded%2A>  
 <xref:System.Runtime.Serialization.OptionalFieldAttribute>  
 <xref:System.Runtime.Serialization.OnDeserializingAttribute>  
 <xref:System.Runtime.Serialization.OnDeserializedAttribute>  
 <xref:System.Runtime.Serialization.OnDeserializingAttribute>  
 <xref:System.Runtime.Serialization.OnSerializedAttribute>  
 <xref:System.Runtime.Serialization.StreamingContext>  
 <xref:System.NonSerializedAttribute>  
 [Binary Serialization](binary-serialization.md)
