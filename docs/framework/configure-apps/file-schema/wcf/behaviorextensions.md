---
title: "&lt;behaviorExtensions&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 59f2791a-c78f-40d7-aa80-0d9cd10135d9
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;behaviorExtensions&gt;
Behavior extensions enable the user to create user-defined behavior elements. These elements can be used alongside the standard Windows Communication Foundation (WCF) behavior elements. The `behaviorExtensions` section defines the element such that it can be used in configuration. Here is an example of a typical behavior extension.  
  
```xml  
<system.serviceModel>  
    <extensions>  
        <behaviorExtensions>  
            <add name="myBehavior" type="Microsoft.ServiceModel.Samples.MyBehaviorSection, MyBehavior,  
                Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />  
       </behaviorExtensions>  
    </extensions>  
</system.serviceModel>  
```  
  
 To add configuration abilities to the element, you need to write and register a configuration element. For more information on this, see the <xref:System.Configuration> documentation.  
  
 After the element and its configuration type are defined, the extension can be used, as shown in the following example.  
  
```xml  
<behaviors>  
    <behavior configurationName="testChannelBehavior">  
        <myBehavior />  
        <channelSecurity cacheCookies="false" detectReplays="false" maxCachedNonces="9"  
            maxClockSkew="00:00:03" maxCookieCachingTime="00:07:24" replayWindow="00:07:22.2190000" />  
    </behavior>  
</behaviors>  
```  
  
## Security  
 It is strongly recommended that you use fully qualified assembly names when registering types in the `machine.config` and `app.config` files. If the type is not uniquely defined, the CLR type loader searches for it in the following locations in the specified order:  
  
 If the assembly of the type is known, the loader searches the configuration file's redirect locations, GAC, the current assembly using configuration information, and the application base directory. If the assembly is unknown, the loader searches the current assembly, mscorlib, and the location returned by the `TypeResolve` event handler. This CLR search order can be modified with hooks such as the Type Forwarding mechanism and the AppDomain.TypeResolve event.  
  
 An attacker can exploit the CLR search order and execute unauthorized code. Using fully qualified (strong) names uniquely identifies a type and further increases security of your system.  
  
 For more information, see [How the Runtime Locates Assemblies](http://go.microsoft.com/fwlink/?LinkId=95336) and <xref:System.AppDomain.TypeResolve>.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.BehaviorExtensionElement>  
 [Configuring and Extending the Runtime with Behaviors](../../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)
