---
title: "How to: Use Svcutil.exe to Export Metadata from Compiled Service Code"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 95d0aed3-16a2-4398-89bb-39418eeb7355
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Use Svcutil.exe to Export Metadata from Compiled Service Code
Svcutil.exe can export metadata for services, contracts, and data types in compiled assemblies, as follows:  
  
-   To export metadata for all compiled service contracts for a set of assemblies using Svcutil.exe, specify the assemblies as input parameters. This is the default behavior.  
  
-   To export metadata for a compiled service using Svcutil.exe, specify the service assembly or assemblies as input parameters. You must use the `/serviceName` option to indicate the configuration name of the service you want to export. Svcutil.exe automatically loads the configuration file for the specified executable assembly.  
  
-   To export all data contract types within a set of assemblies, use the `/dataContractOnly` option.  
  
> [!NOTE]
>  Use the `/reference` option to specify the file paths to any dependent assemblies.  
  
### To export metadata for compiled service contracts  
  
1.  Compile your service contract implementations into one or more class libraries.1  
  
2.  Run Svcutil.exe on the compiled assemblies.  
  
    > [!NOTE]
    >  You might need to use the `/reference` switch to specify the file path to any dependent assemblies.  
  
    ```  
    svcutil.exe Contracts.dll  
    ```  
  
### To export metadata for a compiled service  
  
1.  Compile your service implementation into an executable assembly.  
  
2.  Create a configuration file for your service executable and add a service configuration.  
  
    ```xml  
    <?xml version="1.0" encoding="utf-8" ?>  
    <configuration>  
      <system.serviceModel>  
        <services>  
          <service name="MyService" >  
            <endpoint address="finder" contract="IPeopleFinder" binding="wsHttpBinding" />  
          </service>  
        </services>  
      </system.serviceModel>  
    </configuration>  
    ```  
  
3.  Run Svcutil.exe on the compiled service executable using the `/serviceName` switch to specify the configuration name of the service.  
  
    > [!NOTE]
    >  You might need to use the `/reference` switch to specify the file path to any dependent assemblies.  
  
    ```  
    svcutil.exe /serviceName:MyService Service.exe /reference:path/Contracts.dll  
    ```  
  
### To export metadata for compiled data contracts  
  
1.  Compile your data contract implementations into one or more class libraries.  
  
2.  Run Svcutil.exe on the compiled assemblies using the `/dataContract` switch to specify that only metadata for data contracts should be generated.  
  
    > [!NOTE]
    >  You might need to use the `/reference` switch to specify the file path to any dependent assemblies.  
  
    ```  
    svcutil.exe /dataContractOnly Contracts.dll  
    ```  
  
## Example  
 The following example demonstrates how to generate metadata for a simple service implementation and configuration.  
  
 To export metadata for the service contract.  
  
```  
svcutil.exe Contracts.dll  
```  
  
 To export metadata for the data contracts.  
  
```  
svcutil.exe /dataContractOnly Contracts.dll  
```  
  
 To export metadata for the service implementation.  
  
```  
svcutil.exe /serviceName:MyService Service.exe /reference:<path>/Contracts.dll  
```  
  
 The `<path>` is the path to Contracts.dll.  
  
```  
// The following service contract and data contracts are compiled into   
// Contracts.dll.  
[ServiceContract(ConfigurationName="IPeopleFinder")]  
public interface IPersonFinder  
{  
    [OperationContract]  
    Address GetAddress(Person s);  
}  
  
[DataContract]  
public class Person  
{  
    [DataMember]  
    public string firstName;  
    [DataMember]  
    public string lastName;  
    [DataMember]  
    public int age;  
}  
  
[DataContract]  
public class Address  
{  
    [DataMember]  
    public string city;  
    [DataMember]  
    public string state;  
    [DataMember]  
    public string street;  
    [DataMember]  
    public int zipCode;  
    [DataMember]  
    public Person person;  
}  
  
// The following service implementation is compiled into Service.exe.     
// This service uses the contracts specified in Contracts.dll.  
[ServiceBehavior(ConfigurationName = "MyService")]  
public class MyService : IPersonFinder  
{  
    public Address GetAddress(Person person)  
    {  
        Address address = new Address();  
        address.person = person;  
        return address;  
    }  
}  
  
<!-- The following is the configuration file for Service.exe. -->  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  <system.serviceModel>  
    <services>  
      <service name="MyService">  
         <endpoint  address="finder"  
                    binding="basicHttpBinding"  
                    contract="IPeopleFinder"/>  
      </service>  
    </services>  
  </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)  
 [Exporting and Importing Metadata](../../../../docs/framework/wcf/feature-details/exporting-and-importing-metadata.md)
