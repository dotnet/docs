---
title: "Partial Trust Best Practices"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0d052bc0-5b98-4c50-8bb5-270cc8a8b145
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Partial Trust Best Practices
This topic describes best practices when running [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] in a partial trust environment.  
  
## Serialization  
 Apply the following practices when using the <xref:System.Runtime.Serialization.DataContractSerializer> in a partially-trusted application.  
  
-   All serializable types must be explicitly marked with the `[DataContract]` attribute. The following techniques are not supported in a partial trust environment:  
  
-   Marking classes to be serialized with the <xref:System.SerializableAttribute>.  
  
-   Implementing the <xref:System.Runtime.Serialization.ISerializable> interface to allow a class to control its serialization process.  
  
### Using DataContractSerializer  
  
-   All types marked with the `[DataContract]` attribute must be public. Non-public types cannot be serialized in a partial trust environment.  
  
-   All `[DataContract]` members in a serializable `[DataContract]` type must be public. A type with a non-public `[DataMember]` cannot be serialized in a partial trust environment.  
  
-   Methods that handle serialization events (such as `OnSerializing`, `OnSerialized`, `OnDeserializing`, and `OnDeserialized`) must be declared as public. However, both explicit and implicit implementations of <xref:System.Runtime.Serialization.IDeserializationCallback.OnDeserialization%28System.Object%29> are supported.  
  
-   `[DataContract]` types implemented in assemblies marked with the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> must not perform security-related actions in the type constructor, as the <xref:System.Runtime.Serialization.DataContractSerializer> does not call the constructor of the newly-instantiated object during deserialization. Specifically, the following common security techniques must be avoided for `[DataContract]` types:  
  
-   Attempting to restrict partial trust access by making the type's constructor internal or private.  
  
-   Restricting access to the type by adding a `[LinkDemand]` to the type's constructor.  
  
-   Assuming that because the object has been successfully instantiated, any validation checks enforced by the constructor have passed successfully.  
  
### Using IXmlSerializable  
 The following best practices apply for types that implement <xref:System.Xml.Serialization.IXmlSerializable> and are serialized using the <xref:System.Runtime.Serialization.DataContractSerializer>:  
  
-   The <xref:System.Xml.Serialization.IXmlSerializable.GetSchema%2A> static method implementations must be `public`.  
  
-   The instance methods that implement the <xref:System.Xml.Serialization.IXmlSerializable> interface must be `public`.  
  
## Using WCF from Fully-Trusted Platform Code that Allows Calls from Partially Trusted Callers  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] partial trust security model assumes that any caller of a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] public method or property is running in the code access security (CAS) context of the hosting application. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also assumes that only one application security context exists for each <xref:System.AppDomain>, and that this context is established at <xref:System.AppDomain> creation time by a trusted host (for example, by a call to <xref:System.AppDomain.CreateDomain%2A> or by the ASP.NET Application Manager).  
  
 This security model applies to user-written applications that cannot assert additional CAS permissions, such as user code running in a Medium Trust ASP.NET application. However, fully-trusted platform code (for example, a third-party assembly that is installed in the global assembly cache and accepts calls from partially-trusted code) must take explicit care when calling into [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] on behalf of a partially-trusted application to avoid introducing application-level security vulnerabilities.  
  
 Full-trust code should avoid altering the CAS permission set of the current thread (by calling <xref:System.Security.PermissionSet.Assert%2A>, <xref:System.Security.PermissionSet.PermitOnly%2A>, or <xref:System.Security.PermissionSet.Deny%2A>) prior to calling [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] APIs on behalf of partially-trusted code. Asserting, denying, or otherwise creating a thread-specific permission context that is independent of the application-level security context can result in unexpected behavior. Depending on the application, this behavior may result in application-level security vulnerabilities.  
  
 Code that calls into [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] using a thread-specific permission context must be prepared to handle the following situations that may arise:  
  
-   The thread-specific security context may not be maintained for the duration of the operation, which results in potential security exceptions.  
  
-   Internal [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] code as well as any user-provided callbacks may run in a different security context than the one under which the call was originally initiated. These contexts include:  
  
    -   The application permission context.  
  
    -   Any thread-specific permission context previously created by other user threads used to call into [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] during the lifetime of the currently running <xref:System.AppDomain>.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] guarantees that partially-trusted code cannot obtain full-trust permissions unless such permissions are asserted by a fully-trusted component prior to calling into [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] public APIs. However, it does not guarantee that the effects of asserting full trust is isolated to a particular thread, operation, or user action.  
  
 As a best practice, avoid creating thread-specific permission context by calling <xref:System.Security.PermissionSet.Assert%2A>, <xref:System.Security.PermissionSet.PermitOnly%2A>, or <xref:System.Security.PermissionSet.Deny%2A>. Instead, grant or deny the privilege to the application itself, so that no <xref:System.Security.PermissionSet.Assert%2A>, <xref:System.Security.PermissionSet.Deny%2A>, or <xref:System.Security.PermissionSet.PermitOnly%2A> is required.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Xml.Serialization.IXmlSerializable>
