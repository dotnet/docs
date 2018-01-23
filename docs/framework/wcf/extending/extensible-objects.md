---
title: "Extensible Objects"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "extensible objects [WCF]"
ms.assetid: bc88cefc-31fb-428e-9447-6d20a7d452af
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Extensible Objects
The extensible object pattern is used to either extend existing runtime classes with new functionality or to add new state to an object. Extensions, attached to one of the extensible objects, enable behaviors at very different stages in processing to access shared state and functionality attached to a common extensible object that they can access.  
  
## The IExtensibleObject\<T> Pattern  
 There are three interfaces in the extensible object pattern: <xref:System.ServiceModel.IExtensibleObject%601>, <xref:System.ServiceModel.IExtension%601>, and <xref:System.ServiceModel.IExtensionCollection%601>.  
  
 The <xref:System.ServiceModel.IExtensibleObject%601> interface is implemented by types that allow <xref:System.ServiceModel.IExtension%601> objects to customize their functionality.  
  
 Extensible objects allow dynamic aggregation of <xref:System.ServiceModel.IExtension%601> objects. <xref:System.ServiceModel.IExtension%601> objects are characterized by the following interface:  
  
```  
public interface IExtension<T>  
where T : IExtensibleObject<T>  
{  
    void Attach(T owner);  
    void Detach(T owner);  
}  
```  
  
 The type restriction guarantees that extensions can only be defined for classes that are <xref:System.ServiceModel.IExtensibleObject%601>. <xref:System.ServiceModel.IExtension%601.Attach%2A> and <xref:System.ServiceModel.IExtension%601.Detach%2A> provide notification of aggregation or disaggregation.  
  
 It is valid for implementations to restrict when they may be added and removed from an owner. For example, you can disallow removal entirely, disallowing adding or removing extensions when the owner or extension are in a certain state, disallow adding to multiple owners concurrently, or allow only a single addition followed by a single remove.  
  
 <xref:System.ServiceModel.IExtension%601> does not imply any interactions with other standard managed interfaces. Specifically, the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> method on the owner object does not normally detach its extensions.  
  
 When an extension is added to the collection, <xref:System.ServiceModel.IExtension%601.Attach%2A> is called before it goes into the collection. When an extension is removed from the collection, <xref:System.ServiceModel.IExtension%601.Detach%2A> is called after it is removed. This means (assuming appropriate synchronization) an extension can count on only being found in the collection while it is between <xref:System.ServiceModel.IExtension%601.Attach%2A> and <xref:System.ServiceModel.IExtension%601.Detach%2A>.  
  
 The object passed to <xref:System.ServiceModel.IExtensionCollection%601.FindAll%2A> or <xref:System.ServiceModel.IExtensionCollection%601.Find%2A> need not be <xref:System.ServiceModel.IExtension%601> (for example, you can pass any object), but the returned extension is an <xref:System.ServiceModel.IExtension%601>.  
  
 If no extension in the collection is an <xref:System.ServiceModel.IExtension%601>, <xref:System.ServiceModel.IExtensionCollection%601.Find%2A> returns null, and <xref:System.ServiceModel.IExtensionCollection%601.FindAll%2A> returns an empty collection. If multiple extensions implement <xref:System.ServiceModel.IExtension%601>, <xref:System.ServiceModel.IExtensionCollection%601.Find%2A> returns one of them. The value returned from <xref:System.ServiceModel.IExtensionCollection%601.FindAll%2A> is a snapshot.
  
 There are two main scenarios. The first scenario uses the <xref:System.ServiceModel.IExtensibleObject%601.Extensions%2A> property as a type-based dictionary to insert state on an object to enable another component to look it up using the type.  
  
 The second scenario uses the <xref:System.ServiceModel.IExtension%601.Attach%2A> and <xref:System.ServiceModel.IExtension%601.Detach%2A> properties to enable an object to participate in custom behavior, such as registering for events, watching state transitions, and so on.  
  
 The <xref:System.ServiceModel.IExtensionCollection%601> interface is a collection of the <xref:System.ServiceModel.IExtension%601> objects that allow for retrieving the <xref:System.ServiceModel.IExtension%601> by its type. <xref:System.ServiceModel.IExtensionCollection%601.Find%2A?displayProperty=nameWithType> returns the most recently added object that is an <xref:System.ServiceModel.IExtension%601> of that type.  
  
### Extensible Objects in Windows Communication Foundation  
 There are four extensible objects in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)]:  
  
-   <xref:System.ServiceModel.ServiceHostBase> – This is the base class for the service’s host.  Extensions of this class can be used to extend the behavior of the <xref:System.ServiceModel.ServiceHostBase> itself or to store the state for each service.  
  
-   <xref:System.ServiceModel.InstanceContext> – This class connects an instance of the service’s type with the service runtime.  It contains information about the instance as well as a reference to the <xref:System.ServiceModel.InstanceContext>'s containing <xref:System.ServiceModel.ServiceHostBase>. Extensions of this class can be used to extend the behavior of the <xref:System.ServiceModel.InstanceContext> or to store the state for each service.  
  
-   <xref:System.ServiceModel.OperationContext> – This class represents the operation information that the runtime gathers for each operation.  This includes information such as the incoming message headers, the incoming message properties, the incoming security identity, and other information.  Extensions of this class can either extend the behavior of <xref:System.ServiceModel.OperationContext> or store the state for each operation.  
  
-   <xref:System.ServiceModel.IContextChannel> – This interface allows for the inspection of each state for the channels and proxies built by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime.  Extensions of this class can either extend the behavior of <xref:System.ServiceModel.IClientChannel> or can use it to store the state for each channel.  
  
-  
  
 The following code example shows the use of a simple extension to track <xref:System.ServiceModel.InstanceContext> objects.  
  
 [!code-csharp[IInstanceContextInitializer#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/iinstancecontextinitializer/cs/initializer.cs#1)]  
  
## See Also  
 <xref:System.ServiceModel.IExtensibleObject%601>  
 <xref:System.ServiceModel.IExtension%601>  
 <xref:System.ServiceModel.IExtensionCollection%601>
