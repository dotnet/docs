---
title: "ConfigurationCodeGenerator"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3913aae8-165f-4014-9262-7fe426f90cb2
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ConfigurationCodeGenerator
The ConfigurationCodeGenerator is a tool that you can use to expose your custom channel implementations to the configuration system. This allows users of your custom channel to configure your channel by using a .config file just as they would configure a system-provided binding such as `NetTcpBinding` or a custom binding using the `TcpTransportBindingElement`.  
  
 When you write a custom channel and expose it to the programming model by using a new `BindingElement` or `Binding`, you must create a set of classes to make the `BindingElement` or `Binding` configurable using a .config file. You can use the ConfigurationCodeGenerator tool to generate these classes and enhance your customer's experience.  
  
### To build the tool  
  
1.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
2.  Building the solution generates one file: ConfigurationCodeGenerator.exe. The file SampleRun.cmd has a sample command line that shows how to use this tool to generate the classes for the [Transport: UDP](../../../../docs/framework/wcf/samples/transport-udp.md) sample.  
  
### To run the tool  
  
1.  At the command prompt type the following if you have both a custom `BindingElement` type and a custom `Binding` type:  
  
    ```  
    ConfigurationCodeGenerator.exe /be:YourCustomBindingElementTypeName /sb:YourCustomStdBindingTypeName /dll:TheAssemblyWhereTheseTypesAreDefined  
    ```  
  
     Or type the following if you have only a custom `BindingElement` type:  
  
    ```  
    ConfigurationCodeGenerator.exe /be:YourCustomBindingElementTypeName /dll: TheAssemblyWhereThisTypeIsDefined  
    ```  
  
     Or type the following if you have only a custom `Binding` type:  
  
    ```  
    ConfigurationCodeGenerator.exe /sb:YourCustomStdBindingTypeName /dll:TheAssemblyWhereThisTypeIsDefined  
    ```  
  
     The command generates three .cs files for the `BindingElement` (if you specified the /be: option), five .cs files for the standard `Binding` (if you specified the /sb: option), and a .xml file.  
  
    1.  If you used the /be option, one of the .cs files implements the `BindingElementExtensionSection` for your binding element. This code exposes your `BindingElement` to the configuration system, so that other custom bindings can use your binding element. The other files have classes that represent defaults and constants. The files have `//TODO` comments to remind you to update the default values.  
  
    2.  If you specified the /sb option, two of the .cs files implement a `StandardBindingElement` and a `StandardBindingCollectionElement` respectively, which exposes your standard binding to the configuration system. The other files have classes that represent defaults and constants. The files have `//TODO` comments to remind you to update the default values.  
  
         If you specified the /sb: option the CodeToAddTo\<*YourStdBinding*>.cs has code that you must manually add into the class that implements your standard binding.  
  
     The SampleConfig.xml file contains the configuration code that you must add to the configuration file that registers the handlers defined in the previous step 1 or 2.  
  
## See Also
