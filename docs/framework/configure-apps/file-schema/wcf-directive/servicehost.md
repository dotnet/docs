---
description: "Learn more about: @ServiceHost"
title: "@ServiceHost"
ms.date: "03/30/2017"
ms.assetid: 96ba6967-00f2-422f-9aa7-15de4d33ebf3
---
# \@ServiceHost

Associates the factory used to produce the service host with the service to be hosted and other programming aspects required to access or compile the hosting code provided in the .svc file.

## Syntax

```aspx-csharp
<% @ServiceHost
Service = "Service, ServiceNamespace"
Factory = "Factory, FactoryNamespace"
Debug = "Debug"
Language = "Language"
CodeBehind = "CodeBehind"
%>
```

## Attributes

### Service

The CLR type name of the service hosted. This should be a qualified name of a type that implements one or more of the service contacts.

### Factory

The CLR type name of the service host factory used to instantiate the service host. This attribute is optional. If unspecified, the default <xref:System.ServiceModel.Activation.ServiceHostFactory> is used, which returns an instance of <xref:System.ServiceModel.ServiceHost>.

### Debug

Indicates whether the Windows Communication Foundation (WCF) service should be compiled with debug symbols. `true` if the WCF service should be compiled with debug symbols; otherwise, `false`.

### Language

Specifies the language used when compiling all the inline code within file (.svc). The values can represent any .NET-supported language, including `C#`, `VB`, and `JS`, which refer to C#, Visual Basic, and JScript .NET, respectively. This attribute is optional.

### CodeBehind

Specifies the source file that implements the XML Web service, when the class that implements the XML Web service does not reside in the same file and has not been compiled into an assembly and placed in the *\Bin* directory.

## Remarks

The <xref:System.ServiceModel.ServiceHost> used to host the service is a point of extensibility within the Windows Communication Foundation (WCF) programming model. A factory pattern is used to instantiate the <xref:System.ServiceModel.ServiceHost> because it is, potentially, a polymorphic type that the hosting environment should not instantiate directly.

The default implementation uses <xref:System.ServiceModel.Activation.ServiceHostFactory> to create an instance of <xref:System.ServiceModel.ServiceHost>. But you can provide your own factory (one that returns your derived host) by specifying the CLR type name of your factory implementation in the `@ServiceHost` directive.

To use you own custom service host factory instead of the default factory, just provide the type name in the `@ServiceHost` directive as follows.

```xml
<% @ServiceHost Factory="DerivedFactory" Service="MyService" %>
```

Keep the factory implementations as light as possible. If you have lots of custom logic, your code is more reusable if you put that logic inside your host instead of inside the factory.

For example, to enable an AJAX-enabled endpoint for `MyService`, specify the <xref:System.ServiceModel.Activation.WebScriptServiceHostFactory> for the value of the `Factory` attribute, instead of the default <xref:System.ServiceModel.Activation.ServiceHostFactory>, in the `@ServiceHost` directive as shown in the following example:

```aspx-csharp
<% @ServiceHost
Service="MyService"
Language="C#"
Debug="true"
Factory="WebScriptServiceHostFactory"
%>
```

## See also

- [Custom Service Host](../../../wcf/samples/custom-service-host.md)
