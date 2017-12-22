---
title: "&lt;bindingElementExtensions&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bb597fc0-c947-451c-afda-bf23d42f4f4d
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;bindingElementExtensions&gt;
This section enables the use of a custom binding element from a machine or application configuration file. You can add a custom binding element to this collection by using the `add` keyword, and setting the `type` attribute of the element to a binding element extension, as well as the `name` attribute to the custom binding element.  
  
 Binding extensions enable the user to create user-defined binding elements for use as part of custom bindings. Programmatically, a binding extension is a type that implements the abstract class <xref:System.ServiceModel.Channels.BindingElement>. In the configuration file, the `bindingElementExtensions` section is used to define an extension element.  
  
 The following example uses the `add` element, as well as the `name` attribute to add a binding extension to the `bindingElementExtensions` section of the configuration file.  
  
```xml  
<system.serviceModel>  
    <extensions>  
        <bindingElementExtensions>  
           <add name="udpTransport" type="Microsoft.ServiceModel.Samples.UdpTransportSection, UdpTransport,  
                Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />  
        </bindingElementExtensions>  
    </extensions>  
</system.serviceModel>  
```  
  
 To add configuration abilities to the element, the user needs to write and register a `bindingElementExtensionSection` element. For more information on this, see the <xref:System.Configuration> documentation.  
  
 After the element and its configuration type are defined, the extension can be used as part of a custom binding as shown in the following example.  
  
```xml  
<customBinding>  
     <binding name="test2">  
         <udpTransport />  
         <binaryMessageEncoding maxReadPoolSize="211" maxWritePoolSize="2132"  
             maxSessionSize="3141" />  
         </binding>  
</customBinding>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.BindingElementExtensionElement>  
 [Extending Bindings](../../../../../docs/framework/wcf/extending/extending-bindings.md)
