---
title: "System.Reflection namespaces for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1b1f0441-c45e-4930-84ab-019f61802cea
caps.latest.revision: 5
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.Reflection namespaces for UWP apps
The `System.Reflection`, `System.Reflection.Context`, and `System.Reflection.Emit` namespaces contain types that provide a managed view of loaded types, methods, and fields, and that enable customized reflection contexts.  
  
 This topic displays the types in the `System.Reflection`, `System.Reflection.Context`, and `System.Reflection.Emit` namespaces that are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]. Note that [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.Reflection namespace  
  
|Types supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Reflection.AmbiguousMatchException>|The exception that is thrown when binding to a member results in more than one member matching the binding criteria. This class cannot be inherited.|  
|<xref:System.Reflection.Assembly>|Represents an assembly, which is a reusable, versionable, and self-describing building block of a common language runtime application.|  
|<xref:System.Reflection.AssemblyCompanyAttribute>|Defines a company name custom attribute for an assembly manifest.|  
|<xref:System.Reflection.AssemblyConfigurationAttribute>|Specifies the build configuration, such as retail or debug, for an assembly.|  
|<xref:System.Reflection.AssemblyContentType>|Provides information about the type of code contained in an assembly.|  
|<xref:System.Reflection.AssemblyCopyrightAttribute>|Defines a copyright custom attribute for an assembly manifest.|  
|<xref:System.Reflection.AssemblyCultureAttribute>|Specifies which culture the assembly supports.|  
|<xref:System.Reflection.AssemblyDefaultAliasAttribute>|Defines a friendly default alias for an assembly manifest.|  
|<xref:System.Reflection.AssemblyDelaySignAttribute>|Specifies that the assembly is not fully signed when created.|  
|<xref:System.Reflection.AssemblyDescriptionAttribute>|Provides a text description for an assembly.|  
|<xref:System.Reflection.AssemblyExtensions>|For more information, see <xref:System.Reflection.AssemblyExtensions>.|  
|<xref:System.Reflection.AssemblyFileVersionAttribute>|Instructs a compiler to use a specific version number for the Win32 file version resource. The Win32 file version is not required to be the same as the assembly's version number.|  
|<xref:System.Reflection.AssemblyFlagsAttribute>|Specifies a bitwise combination of AssemblyNameFlags flags for an assembly, describing just-in-time (JIT) compiler options, whether the assembly is retargetable, and whether it has a full or tokenized public key. This class cannot be inherited.|  
|<xref:System.Reflection.AssemblyInformationalVersionAttribute>|Defines additional version information for an assembly manifest.|  
|<xref:System.Reflection.AssemblyKeyFileAttribute>|Specifies the name of a file containing the key pair used to generate a strong name.|  
|<xref:System.Reflection.AssemblyKeyNameAttribute>|Specifies the name of a key container within the CSP containing the key pair used to generate a strong name.|  
|<xref:System.Reflection.AssemblyMetadataAttribute>|Defines a key/value metadata pair for the decorated assembly.|  
|<xref:System.Reflection.AssemblyName>|Describes an assembly's unique identity in full.|  
|<xref:System.Reflection.AssemblyNameFlags>|Provides information about an Assembly reference.|  
|<xref:System.Reflection.AssemblyProductAttribute>|Defines a product name custom attribute for an assembly manifest.|  
|<xref:System.Reflection.AssemblySignatureKeyAttribute>|Specifies the signature key for the assembly.|  
|<xref:System.Reflection.AssemblyTitleAttribute>|Specifies a description for an assembly.|  
|<xref:System.Reflection.AssemblyTrademarkAttribute>|Defines a trademark custom attribute for an assembly manifest.|  
|<xref:System.Reflection.AssemblyVersionAttribute>|Specifies the version of the assembly being attributed.|  
|<xref:System.Reflection.BindingFlags>|Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.|  
|<xref:System.Reflection.CallingConventions>|Defines the valid calling conventions for a method.|  
|<xref:System.Reflection.ConstructorInfo>|Discovers the attributes of a class constructor and provides access to constructor metadata.|  
|<xref:System.Reflection.CustomAttributeData>|Provides access to custom attribute data for assemblies, modules, types, members and parameters that are loaded into the reflection-only context.|  
|<xref:System.Reflection.CustomAttributeExtensions>|Contains static methods for retrieving custom attributes.|  
|<xref:System.Reflection.CustomAttributeNamedArgument>|Represents a named argument of a custom attribute in the reflection-only context.|  
|<xref:System.Reflection.CustomAttributeTypedArgument>|Represents an argument of a custom attribute in the reflection-only context, or an element of an array argument.|  
|<xref:System.Reflection.DefaultMemberAttribute>|Defines the member of a type that is the default member used by InvokeMember.|  
|<xref:System.Reflection.DispatchProxy>|For more information, see <xref:System.Reflection.DispatchProxy>.|  
|<xref:System.Reflection.EventAttributes>|Specifies the attributes of an event.|  
|<xref:System.Reflection.EventInfo>|Discovers the attributes of an event and provides access to event metadata.|  
|<xref:System.Reflection.EventInfoExtensions>|Extensions to <xref:System.Reflection.EventInfo>.|  
|<xref:System.Reflection.FieldAttributes>|Specifies flags that describe the attributes of a field.|  
|<xref:System.Reflection.FieldInfo>|Discovers the attributes of a field and provides access to field metadata.|  
|<xref:System.Reflection.GenericParameterAttributes>|Describes the constraints on a generic type parameter of a generic type or method.|  
|<xref:System.Reflection.InterfaceMapping>|Retrieves the mapping of an interface into the actual methods on a class that implements that interface.|  
|<xref:System.Reflection.IntrospectionExtensions>|Contains methods for converting System.Type objects.|  
|<xref:System.Reflection.IReflectableType>|Represents a type that you can reflect over.|  
|<xref:System.Reflection.LocalVariableInfo>|Discovers the attributes of a local variable and provides access to local variable metadata.|  
|<xref:System.Reflection.ManifestResourceInfo>|Provides access to manifest resources, which are XML files that describe application dependencies.|  
|<xref:System.Reflection.MemberInfo>|Obtains information about the attributes of a member and provides access to member metadata.|  
|<xref:System.Reflection.MethodAttributes>|Specifies flags for method attributes. These flags are defined in the corhdr.h file.|  
|<xref:System.Reflection.MethodBase>|Provides information about methods and constructors.|  
|<xref:System.Reflection.MethodImplAttributes>|Specifies flags for the attributes of a method implementation.|  
|<xref:System.Reflection.MethodInfo>|Discovers the attributes of a method and provides access to method metadata.|  
|<xref:System.Reflection.MethodInfoExtensions>|Extensions to <xref:System.Reflection.MethodInfo>.|  
|<xref:System.Reflection.Missing>|Represents a missing Object. This class cannot be inherited.|  
|<xref:System.Reflection.Module>|Performs reflection on a module.|  
|<xref:System.Reflection.ParameterAttributes>|Defines the attributes that can be associated with a parameter. These are defined in CorHdr.h.|  
|<xref:System.Reflection.ParameterInfo>|Discovers the attributes of a parameter and provides access to parameter metadata.|  
|<xref:System.Reflection.ProcessorArchitecture>|Identifies the processor and bits-per-word of the platform targeted by an executable.|  
|<xref:System.Reflection.PropertyAttributes>|Defines the attributes that can be associated with a property. These attribute values are defined in corhdr.h.|  
|<xref:System.Reflection.PropertyInfo>|Discovers the attributes of a property and provides access to property metadata.|  
|<xref:System.Reflection.PropertyInfoExtensions>|Extensions to <xref:System.Reflection.PropertyInfo>.|  
|<xref:System.Reflection.ReflectionContext>|Represents a context that can provide reflection objects.|  
|<xref:System.Reflection.ReflectionTypeLoadException>|The exception that is thrown by the ModuleGetTypes() method if any of the classes in a module cannot be loaded. This class cannot be inherited.|  
|<xref:System.Reflection.ResourceLocation>|Specifies the resource location.|  
|<xref:System.Reflection.RuntimeReflectionExtensions>|Provides methods that retrieve information about types at run time.|  
|<xref:System.Reflection.TargetInvocationException>|The exception that is thrown by methods invoked through reflection. This class cannot be inherited.|  
|<xref:System.Reflection.TargetParameterCountException>|The exception that is thrown when the number of parameters for an invocation does not match the number expected. This class cannot be inherited.|  
|<xref:System.Reflection.TypeAttributes>|Specifies type attributes.|  
|<xref:System.Reflection.TypeExtensions>|For more information, see <xref:System.Reflection.TypeExtensions>.|  
|<xref:System.Reflection.TypeInfo>|Represents type declarations: class types, interface types, array types, value types, enumeration types, type parameters, generic type definitions, and open or closed constructed generic types.|  
  
## System.Reflection.Context namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Reflection.Context.CustomReflectionContext>|Represents a customizable reflection context.|  
  
## System.Reflection.Emit namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Reflection.Emit.FlowControl>|Describes how an instruction alters the flow of control.|  
|<xref:System.Reflection.Emit.OpCode>|Describes a Microsoft intermediate language (MSIL) instruction.|  
|<xref:System.Reflection.Emit.OpCodes>|Provides field representations of the Microsoft Intermediate Language (MSIL) instructions for emission by the ILGenerator class members (such as Emit).|  
|<xref:System.Reflection.Emit.OpCodeType>|Describes the types of the Microsoft intermediate language (MSIL) instructions.|  
|<xref:System.Reflection.Emit.OperandType>|Describes the operand type of Microsoft intermediate language (MSIL) instruction.|  
|<xref:System.Reflection.Emit.PackingSize>|Specifies one of two factors that determine the memory alignment of fields when a type is marshaled.|  
|<xref:System.Reflection.Emit.StackBehaviour>|Describes how values are pushed onto a stack or popped off a stack.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)