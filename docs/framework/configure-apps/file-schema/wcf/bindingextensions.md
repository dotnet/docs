---
title: "&lt;bindingExtensions&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8373f94d-d095-486f-8f1e-4ac2f72b58c7
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;bindingExtensions&gt;
This section enables the use of a user defined binding from a machine or application configuration file. You can add a user defined binding to this collection by using the `add` keyword, and setting the `type` attribute of the element to a user defined binding, as well as the `name` attribute to the name of the user defined binding.  
  
 Binding extensions enable the user to create user-defined bindings for use as part an endpoint configuration. Programmatically, a binding extension is a type that implements the abstract class <xref:System.ServiceModel.Channels.Binding>.  
  
 The following example uses the `add` element, as well as the `name` attribute to add a binding extension to the `bindingElementExtensions` section of the configuration file.  
  
```xml  
<system.serviceModel>  
    <extensions>  
        <bindingExtensions>  
           <add name="MyBinding" type="Microsoft.ServiceModel.Samples.MyBinding, MyBinding,  
                Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />  
        </bindingExtensions>  
    </extensions>  
</system.serviceModel>  
```  
  
 To add configuration abilities to the element, the user needs to write and register a `bindingSection` element. For more information on this, see the <xref:System.Configuration> documentation.  
  
 After the element and its configuration type are defined, the extension can be used as part of an endpoint as shown in the following example.  
  
```xml  
<services>  
    <service name="MyService">  
        <endpoint address="myAddress" binding="MyBinding" />  
    </service>  
</services>  
```  
  
## See Also  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)
