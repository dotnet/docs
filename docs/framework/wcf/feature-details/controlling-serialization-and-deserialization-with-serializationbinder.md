---
title: "Controlling Serialization and Deserialization with SerializationBinder"
ms.date: "03/30/2017"
ms.assetid: ba8dcecf-acc7-467c-939d-021bbac797d4
---
# Controlling Serialization and Deserialization with SerializationBinder
During serialization, a formatter transmits the information required to create an instance of an object of the correct type and version. This information generally includes the full type name and assembly name of the object. By default, deserialization uses this information to create an instance of an identical object. Some users may need to control which class to serialize and deserialize, either because the original class may not exist on the machine performing deserialization, the original class has moved between assemblies, or a different version of the class is required on the server and client. For more information, see [Usage of Serialization Binder](../../../../docs/framework/wcf/samples/usage-of-serialization-binder.md).  
  
> [!WARNING]
>  This functionality is only available when using the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> or the <xref:System.Runtime.Serialization.NetDataContractSerializer>.  
  
## Using SerializationBinder  
 <xref:System.Runtime.Serialization.SerializationBinder> is an abstract class used to control the actual types used during serialization and deserialization. To control the types used during serialization and deserialization, derive a class from <xref:System.Runtime.Serialization.SerializationBinder> and override the <xref:System.Runtime.Serialization.SerializationBinder.BindToName(System.Type,System.String@,System.String@)> and <xref:System.Runtime.Serialization.SerializationBinder.BindToType(System.String,System.String)> methods. The <xref:System.Runtime.Serialization.SerializationBinder.BindToName(System.Type,System.String@,System.String@)> method takes a <xref:System.Type> and returns an assembly and type name. The <xref:System.Runtime.Serialization.SerializationBinder.BindToType(System.String,System.String)> method takes an assembly and type name and returns a <xref:System.Type>.  
  
## See also

- [Serialization and Deserialization](../../../../docs/framework/wcf/feature-details/serialization-and-deserialization.md)
- [Usage of Serialization Binder](../../../../docs/framework/wcf/samples/usage-of-serialization-binder.md)
