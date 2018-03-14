---
title: "How to: Improve the Startup Time of WCF Client Applications using the XmlSerializer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 21093451-0bc3-4b1a-9a9d-05f7f71fa7d0
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Improve the Startup Time of WCF Client Applications using the XmlSerializer
Services and client applications that use data types that are serializable using the <xref:System.Xml.Serialization.XmlSerializer> generate and compile serialization code for those data types at runtime, which can result in slow start-up performance.  
  
> [!NOTE]
>  Pre-generated serialization code can only be used in client applications and not in services.  
  
 The [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) can improve start-up performance for these applications by generating the necessary serialization code from the compiled assemblies for the application. Svcutil.exe generates serialization code for all data types used in service contracts in the compiled application assembly that can be serialized using the <xref:System.Xml.Serialization.XmlSerializer>. Service and operation contracts that use the <xref:System.Xml.Serialization.XmlSerializer> are marked with the <xref:System.ServiceModel.XmlSerializerFormatAttribute>.  
  
### To generate XmlSerializer serialization code  
  
1.  Compile your service or client code into one or more assemblies.  
  
2.  Open an SDK command prompt.  
  
3.  At the command prompt, launch the Svcutil.exe tool using the following format.  
  
    ```  
    svcutil.exe /t:xmlSerializer  <assemblyPath>*  
    ```  
  
     The `assemblyPath` argument specifies the path to an assembly that contains service contract types. Svcutil.exe generates serialization code for all data types used in service contracts in the compiled application assembly that can be serialized using the <xref:System.Xml.Serialization.XmlSerializer>.  
  
     Svcutil.exe can only generate C# serialization code. One source code file is generated for each input assembly. You cannot use the **/language** switch to change the language of the generated code.  
  
     To specify the path to dependent assemblies, use the **/reference** option.  
  
4.  Make the generated serialization code available to your application by using one of the following options:  
  
    1.  Compile the generated serialization code into a separate assembly with the name [*original assembly*].XmlSerializers.dll (for example, MyApp.XmlSerializers.dll). Your application must be able to load the assembly, which must be signed with the same key as the original assembly. If you recompile the original assembly, you must regenerate the serialization assembly.  
  
    2.  Compile the generated serialization code into a separate assembly and use the <xref:System.Xml.Serialization.XmlSerializerAssemblyAttribute> on the service contract that uses the <xref:System.ServiceModel.XmlSerializerFormatAttribute>. Set the <xref:System.Xml.Serialization.XmlSerializerAssemblyAttribute.AssemblyName%2A> or <xref:System.Xml.Serialization.XmlSerializerAssemblyAttribute.CodeBase%2A> properties to point to the compiled serialization assembly.  
  
    3.  Compile the generated serialization code into your application assembly and add the <xref:System.Xml.Serialization.XmlSerializerAssemblyAttribute> to the service contract that uses the <xref:System.ServiceModel.XmlSerializerFormatAttribute>. Do not set the <xref:System.Xml.Serialization.XmlSerializerAssemblyAttribute.AssemblyName%2A> or <xref:System.Xml.Serialization.XmlSerializerAssemblyAttribute.CodeBase%2A> properties. The default serialization assembly is assumed to be the current assembly.  
  
### To generate XmlSerializer serialization code in Visual Studio  
  
1.  Create the WCF service and client projects in Visual Studio. Then, add a service reference to the client project.  
  
2.  Add an <xref:System.ServiceModel.XmlSerializerFormatAttribute> to the service contract in the *reference.cs* file in the client app project under **serviceReference** -> **reference.svcmap**. Note that you need to show all files in **Solution Explorer** to see these files.  
  
3.  Build the client app.  
  
4.  Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to create a pre-generated serializer *.cs* file by using the command:  
  
    ```  
    svcutil.exe /t:xmlSerializer  <assemblyPath>*  
    ```  
  
     The assemblyPath argument specifies the path to the WCF client assembly.  
  
     Such as:  
  
    ```  
    svcutil.exe /t:xmlSerializer wcfclient.exe  
    ```  
  
     The *WCFClient.XmlSerializers.dll.cs* file will be generated.  
  
5.  Compile the pre-generated serialization assembly.  
  
     Based on the example in the previous step, the compile command would be the following:  
  
    ```  
    csc /r:wcfclient.exe /out:WCFClient.XmlSerializers.dll /t:library WCFClient.XmlSerializers.dll.cs  
    ```  
  
     Make sure the generated *WCFClient.XmlSerializers.dll* is in the same directory as the client app, which is *WCFClient.exe* in this case.  
  
6.  Run the client app as usual. The pre-generated serialization assembly will be used.  
  
## Example  
 The following command generates serialization types for `XmlSerializer` types that any service contracts in the assembly use.  
  
```  
svcutil /t:xmlserializer myContractLibrary.exe  
```  
  
## See Also  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)
