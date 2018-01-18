---
title: "Runtime Directives (rd.xml) Configuration File Reference"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8241523f-d8e1-4fb6-bf6a-b29bfe07b38a
caps.latest.revision: 27
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runtime Directives (rd.xml) Configuration File Reference
A runtime directives (.rd.xml) file is an XML configuration file that specifies whether designated program elements are available for reflection. Here’s an example of a runtime directives file:  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
<Application>  
  <Namespace Name="Contoso.Cloud.AppServices" Serialize="Required Public" />  
  <Namespace Name="ContosoClient.ViewModels" Serialize="Required Public" />  
  <Namespace Name="ContosoClient.DataModel" Serialize="Required Public" />  
  <Namespace Name="Contoso.Reader.UtilityLib" Serialize="Required Public" />  
  
  <Namespace Name="System.Collections.ObjectModel" >  
    <TypeInstantiation Name="ObservableCollection"   
          Arguments="ContosoClient.DataModel.ProductItem" Serialize="Public" />  
    <TypeInstantiation Name="ReadOnlyObservableCollection"   
          Arguments="ContosoClient.DataModel.ProductGroup" Serialize="Public" />  
  </Namespace>  
</Application>  
</Directives>  
```  
  
## The structure of a runtime directives file  
 The runtime directives file uses the `http://schemas.microsoft.com/netfx/2013/01/metadata` namespace.  
  
 The root element is the [Directives](../../../docs/framework/net-native/directives-element-net-native.md) element. It can contain zero or more [Library](../../../docs/framework/net-native/library-element-net-native.md) elements, and zero or one [Application](../../../docs/framework/net-native/application-element-net-native.md) element, as shown in the following structure. The attributes of the [Application](../../../docs/framework/net-native/application-element-net-native.md) element can define application-wide runtime reflection policy, or it can serve as a container for child elements. The [Library](../../../docs/framework/net-native/library-element-net-native.md) element, on the other hand, is simply a container. The children of the [Application](../../../docs/framework/net-native/application-element-net-native.md) and [Library](../../../docs/framework/net-native/library-element-net-native.md) elements define the types, methods, fields, properties, and events that are available for reflection.  
  
 For reference information, choose elements from the following structure or see [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md). In the following hierarchy, the ellipsis marks a recursive structure. The information in brackets indicates whether that element is optional or required, and if it is used, how many instances (one or many) are allowed.  
  
 [Directives](../../../docs/framework/net-native/directives-element-net-native.md) [1:1]  
 [Application](../../../docs/framework/net-native/application-element-net-native.md) [0:1]  
 [Assembly](../../../docs/framework/net-native/assembly-element-net-native.md) [0:M]  
 [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md) [0:M]  
 . . .  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md) [0:M]  
 [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md) [0:M]  
 . . .  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 [Subtypes](../../../docs/framework/net-native/subtypes-element-net-native.md) (subclasses of the containing type) [O:1]  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [AttributeImplies](../../../docs/framework/net-native/attributeimplies-element-net-native.md) (containing type is an attribute) [O:1]  
 [GenericParameter](../../../docs/framework/net-native/genericparameter-element-net-native.md) [0:M]  
 [Method](../../../docs/framework/net-native/method-element-net-native.md) [0:M]  
 [Parameter](../../../docs/framework/net-native/parameter-element-net-native.md) [0:M]  
 [TypeParameter](../../../docs/framework/net-native/typeparameter-element-net-native.md) [0:M]  
 [GenericParameter](../../../docs/framework/net-native/genericparameter-element-net-native.md) [0:M]  
 [MethodInstantiation](../../../docs/framework/net-native/methodinstantiation-element-net-native.md) (constructed generic method) [0:M]  
 [Property](../../../docs/framework/net-native/property-element-net-native.md) [0:M]  
 [Field](../../../docs/framework/net-native/field-element-net-native.md) [0:M]  
 [Event](../../../docs/framework/net-native/event-element-net-native.md) [0:M]  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [Method](../../../docs/framework/net-native/method-element-net-native.md) [0:M]  
 [Parameter](../../../docs/framework/net-native/parameter-element-net-native.md) [0:M]  
 [TypeParameter](../../../docs/framework/net-native/typeparameter-element-net-native.md) [0:M]  
 [GenericParameter](../../../docs/framework/net-native/genericparameter-element-net-native.md) [0:M]  
 [MethodInstantiation](../../../docs/framework/net-native/methodinstantiation-element-net-native.md) (constructed generic method) [0:M]  
 [Property](../../../docs/framework/net-native/property-element-net-native.md) [0:M]  
 [Field](../../../docs/framework/net-native/field-element-net-native.md) [0:M]  
 [Event](../../../docs/framework/net-native/event-element-net-native.md) [0:M]  
 [Library](../../../docs/framework/net-native/library-element-net-native.md) [0:M]  
 [Assembly](../../../docs/framework/net-native/assembly-element-net-native.md) [0:M]  
 [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md) [0:M]  
 . . .  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md) [0:M]  
 [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md) [0:M]  
 . . .  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 [Subtypes](../../../docs/framework/net-native/subtypes-element-net-native.md) (subclasses of the containing type) [O:1]  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [AttributeImplies](../../../docs/framework/net-native/attributeimplies-element-net-native.md) (containing type is an attribute) [O:1]  
 [GenericParameter](../../../docs/framework/net-native/genericparameter-element-net-native.md) [0:M]  
 [Method](../../../docs/framework/net-native/method-element-net-native.md) [0:M]  
 [MethodInstantiation](../../../docs/framework/net-native/methodinstantiation-element-net-native.md) (constructed generic method) [0:M]  
 [Property](../../../docs/framework/net-native/property-element-net-native.md) [0:M]  
 [Field](../../../docs/framework/net-native/field-element-net-native.md) [0:M]  
 [Event](../../../docs/framework/net-native/event-element-net-native.md) [0:M]  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 [Type](../../../docs/framework/net-native/type-element-net-native.md) [0:M]  
 . . .  
 [TypeInstantiation](../../../docs/framework/net-native/typeinstantiation-element-net-native.md) (constructed generic type) [0:M]  
 . . .  
 [Method](../../../docs/framework/net-native/method-element-net-native.md) [0:M]  
 [MethodInstantiation](../../../docs/framework/net-native/methodinstantiation-element-net-native.md) (constructed generic method) [0:M]  
 [Property](../../../docs/framework/net-native/property-element-net-native.md) [0:M]  
 [Field](../../../docs/framework/net-native/field-element-net-native.md) [0:M]  
 [Event](../../../docs/framework/net-native/event-element-net-native.md) [0:M]  
  
 The [Application](../../../docs/framework/net-native/application-element-net-native.md) element can have no attributes, or it can have the policy attributes discussed in the [Runtime directive and policy section](#Directives).  
  
 A [Library](../../../docs/framework/net-native/library-element-net-native.md) element has a single attribute, `Name`, that specifies the name of a library or assembly, without its file extension. For example, the following [Library](../../../docs/framework/net-native/library-element-net-native.md) element applies to an assembly named Extensions.dll.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
  <Application>  
     <!-- Child elements go here -->    
  </Application>  
  <Library Name="Extensions">  
     <!-- Child elements go here -->    
  </Library>  
</Directives>  
```  
  
<a name="Directives"></a>   
## Runtime directives and policy  
 The [Application](../../../docs/framework/net-native/application-element-net-native.md) element itself and the child elements of the [Library](../../../docs/framework/net-native/library-element-net-native.md) and [Application](../../../docs/framework/net-native/application-element-net-native.md) elements express policy; that is, they define the way in which an app can apply reflection to a program element. The policy type is defined by an attribute of the element (for example, `Serialize`). The policy value is defined by the attribute’s value (for example, `Serialize="Required"`).  
  
 Any policy specified by an attribute of an element applies to all child elements that don’t specify a value for that policy. For example, if a policy is specified by a [Type](../../../docs/framework/net-native/type-element-net-native.md) element, that policy applies to all contained types and members for which a policy is not explicitly specified.  
  
 The policy that can be expressed by the [Application](../../../docs/framework/net-native/application-element-net-native.md), [Assembly](../../../docs/framework/net-native/assembly-element-net-native.md), [AttributeImplies](../../../docs/framework/net-native/attributeimplies-element-net-native.md), [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md), [Subtypes](../../../docs/framework/net-native/subtypes-element-net-native.md), and [Type](../../../docs/framework/net-native/type-element-net-native.md) elements differs from the policy that can be expressed for individual members (by the [Method](../../../docs/framework/net-native/method-element-net-native.md), [Property](../../../docs/framework/net-native/property-element-net-native.md), [Field](../../../docs/framework/net-native/field-element-net-native.md), and [Event](../../../docs/framework/net-native/event-element-net-native.md) elements).  
  
### Specifying policy for assemblies, namespaces, and types  
 The [Application](../../../docs/framework/net-native/application-element-net-native.md), [Assembly](../../../docs/framework/net-native/assembly-element-net-native.md), [AttributeImplies](../../../docs/framework/net-native/attributeimplies-element-net-native.md), [Namespace](../../../docs/framework/net-native/namespace-element-net-native.md), [Subtypes](../../../docs/framework/net-native/subtypes-element-net-native.md), and [Type](../../../docs/framework/net-native/type-element-net-native.md) elements support the following policy types:  
  
-   `Activate`. Controls runtime access to constructors, to enable activation of instances.  
  
-   `Browse`. Controls querying for information about program elements but does not enable any runtime access.  
  
-   `Dynamic`. Controls runtime access to all type members, including constructors, methods, fields, properties, and events, to enable dynamic programming.  
  
-   `Serialize`. Controls runtime access to constructors, fields, and properties, to enable type instances to be serialized and serialized by third-party libraries such as the Newtonsoft JSON serializer.  
  
-   `DataContractSerializer`. Controls policy for serialization that uses the <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType> class.  
  
-   `DataContractJsonSerializer`. Controls policy for JSON serialization that uses the <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=nameWithType> class.  
  
-   `XmlSerializer`. Controls policy for XML serialization that uses the <xref:System.Xml.Serialization.XmlSerializer?displayProperty=nameWithType> class.  
  
-   `MarshalObject`. Controls policy for marshaling reference types to WinRT and COM.  
  
-   `MarshalDelegate`. Controls policy for marshaling delegate types as function pointers to native code.  
  
-   `MarshalStructure` . Controls policy for marshaling structures to native code.  
  
 The settings associated with these policy types are:  
  
-   `All`. Enable the policy for all types and members that the tool chain does not remove.  
  
-   `Auto`. Use the default behavior. (Not specifying a policy is equivalent to setting that policy to `Auto` unless that policy is overridden, for example by a parent element.)  
  
-   `Excluded`. Disable the policy for the program element.  
  
-   `Public`. Enable the policy for public types or members unless the tool chain determines that the member is unnecessary and therefore removes it. (In the latter case, you must use `Required Public` to ensure that the member is kept and has reflection capabilities.)  
  
-   `PublicAndInternal`. Enable the policy for public and internal types or members if the tool chain doesn't remove them.  
  
-   `Required Public`. Require the tool chain to keep public types and members whether or not they are used, and enable the policy for them.  
  
-   `Required PublicAndInternal`. Require the tool chain to keep both public and internal types and members whether or not they are used, and enable the policy for them.  
  
-   `Required All`. Require the tool chain to keep all types and members whether or not they are used, and enable the policy for them.  
  
 For example, the following runtime directives file defines policy for all types and members in the assembly DataClasses.dll. It enables reflection for serialization of all public properties, enables browsing for all types and type members, enables activation for all types (because of the `Dynamic` attribute), and enables reflection for all public types and members.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Application>  
      <Assembly Name="DataClasses" Serialize="Required Public"   
                Browse="All" Activate="PublicAndInternal"   
                Dynamic="Public"  />  
   </Application>  
   <Library Name="UtilityLibrary">  
     <!-- Child elements go here -->    
   </Library>  
</Directives>  
```  
  
### Specifying policy for members  
 The [Property](../../../docs/framework/net-native/property-element-net-native.md) and [Field](../../../docs/framework/net-native/field-element-net-native.md) elements support the following policy types:  
  
-   `Browse` - Controls querying for information about this member but does not enable any runtime access.  
  
-   `Dynamic` - Controls runtime access to all type members, including constructors, methods, fields, properties, and events, to enable dynamic programming. Also controls querying for information about the containing type.  
  
-   `Serialize` - Controls runtime access to the member to enable type instances to be serialized and deserialized by libraries such as the Newtonsoft JSON serializer. This policy can be applied to constructors, fields, and properties.  
  
 The [Method](../../../docs/framework/net-native/method-element-net-native.md) and [Event](../../../docs/framework/net-native/event-element-net-native.md) elements support the following policy types:  
  
-   `Browse` - Controls querying for information about this member but doesn’t enable any runtime access.  
  
-   `Dynamic` - Controls runtime access to all type members, including constructors, methods, fields, properties, and events, to enable dynamic programming. Also controls querying for information about the containing type.  
  
 The settings associated with these policy types are:  
  
-   `Auto` - Use the default behavior. (Not specifying a policy is equivalent to setting that policy to `Auto` unless something overrides it.)  
  
-   `Excluded` - Never include metadata for the member.  
  
-   `Included` - Enable the policy if the parent type is present in the output.  
  
-   `Required` - Require the tool chain to keep this member even if appears to be unused, and enable policy for it.  
  
## Runtime directives file semantics  
 Policy can be defined simultaneously for both higher-level and lower-level elements. For example, policy can be defined for an assembly, and for some of the types contained in that assembly. If a particular lower-level element is not represented, it inherits the policy of its parent. For example, if an `Assembly` element is present but `Type` elements are not, the policy specified in the `Assembly` element applies to each type in the assembly. Multiple elements can also apply policy to the same program element. For example, separate [Assembly](../../../docs/framework/net-native/assembly-element-net-native.md) elements might define the same policy element for the same assembly differently. The following sections explain how the policy for a particular type is resolved in those cases.  
  
 A [Type](../../../docs/framework/net-native/type-element-net-native.md) or [Method](../../../docs/framework/net-native/method-element-net-native.md) element of a generic type or method applies its policy to all instantiations that do not have their own policy. For example, a `Type` element that specifies policy for <xref:System.Collections.Generic.List%601> applies to all constructed instances of that generic type, unless it's overridden for a particular constructed generic type (such as a `List<Int32>`) by a `TypeInstantiation` element. Otherwise, elements define policy for the program element named.  
  
 When an element is ambiguous, the engine looks for matches, and if it finds an exact match, it will use it. If it finds multiple matches, there will be a warning or error.  
  
### If two directives apply policy to the same program element  
 If two elements in different runtime directives files try to set the same policy type for the same program element (such as an assembly or type) to different values, the conflict is resolved as follows:  
  
1.  If the `Excluded` element is present, it has precedence.  
  
2.  `Required` has precedence over not `Required`.  
  
3.  `All` has precedence over `PublicAndInternal`, which has precedence over `Public`.  
  
4.  Any explicit setting has precedence over `Auto`.  
  
 For example, if a single project includes the following two runtime directives files, the serialization policy for DataClasses.dll is set to both `Required Public` and `All`. In this case, the serialization policy would be resolved as `Required All`.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Application>  
      <Assembly Name="DataClasses" Serialize="Required Public"/>  
   </Application>  
   <Library Name="DataClasses">  
      <!-- any other elements -->  
   </Library>  
</Directives>  
```  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Application>  
      <Assembly Name="DataClasses" Serialize="All" />  
   </Application>  
   <Library Name="DataClasses">  
      <!-- any other elements -->  
   </Library>  
</Directives>  
```  
  
 However, if two directives in a single runtime directives file try to set the same policy type for the same program element, the XML Scheme Definition tool displays an error message.  
  
### If child and parent elements apply the same policy type  
 Child elements override their parent elements, including the `Excluded` setting. Overriding is the main reason you would want to specify `Auto`.  
  
 In the following example, the serialization policy setting for everything in `DataClasses` that’s not in `DataClasses.ViewModels` would be `Required Public`, and everything that's in both `DataClasses` and `DataClasses.ViewModels` would be `All`.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Application>  
      <Assembly Name="DataClasses" Serialize="Required Public" >  
         <Namespace Name="DataClasses.ViewModels" Seralize="All" />  
      </Assembly>  
   </Appliction>  
   <Library Name="DataClasses">  
      <!-- any other elements -->  
   </Library>  
</Directives>  
```  
  
### If open generics and instantiated elements apply the same policy type  
 In the following example, `Dictionary<int,int>` is assigned the `Browse` policy only if the engine has another reason to give it the `Browse` policy (which would otherwise be the default behavior); every other instantiation of <xref:System.Collections.Generic.Dictionary%602> will have all of its members browsable.  
  
```xml  
<Directives xmlns="http://schemas.microsoft.com/netfx/2013/01/metadata">  
   <Application>  
      <Assembly Name="DataClasses" Serialize="Required Public" >  
         <Namespace Name="DataClasses.ViewModels" Seralize="All" />  
      </Assembly>  
      <Namespace Name="DataClasses.Generics" />  
      <Type Name="Dictionary" Browse="All" />  
      <TypeInstantiation Name="Dictionary"   
                         Arguments="System.Int32,System.Int32" Browse="Auto" />  
   </Application>  
   <Library Name="DataClasses">  
      <!-- any other elements -->  
   </Library>  
</Directives>  
```  
  
### How policy is inferred  
 Each policy type has a different set of rules that determine how the presence of that policy type affects other constructs.  
  
#### The effect of Browse policy  
 Applying the `Browse` policy to a type involves the following policy changes:  
  
-   The base type of the type is marked with the `Browse` policy.  
  
-   If the type is an instantiated generic, the uninstantiated version of the type is marked with the `Browse` policy.  
  
-   If the type is a delegate, the `Invoke` method on the type is marked with the `Dynamic` policy.  
  
-   Each interface of the type is marked with the `Browse` policy.  
  
-   The type of each attribute applied to the type is marked with the `Browse` policy.  
  
-   If the type is generic, each constraint type is marked with the `Browse` policy.  
  
-   If the type is generic, the types over which the type is instantiated are marked with the `Browse` policy.  
  
 Applying the `Browse` policy to a method involves the following policy changes:  
  
-   Each parameter type of the method is marked with the `Browse` policy.  
  
-   The return type of the method is marked with the `Browse` policy.  
  
-   The containing type of the method is marked with the `Browse` policy.  
  
-   If the method is an instantiated generic method, the uninstantiated generic method is marked with the `Browse` policy.  
  
-   The type of each attribute applied to the method is marked with the `Browse` policy.  
  
-   If the method is generic, each constraint type is marked with the `Browse` policy.  
  
-   If the method is generic, the types over which the method is instantiated are marked with the `Browse` policy.  
  
 Applying the `Browse` policy to a field involves the following policy changes:  
  
-   The type of each attribute applied to the field is marked with the `Browse` policy.  
  
-   The type of the field is marked with the `Browse` policy.  
  
-   The type to which the field belongs is marked with the `Browse` policy.  
  
#### The effect of Dynamic policy  
 Applying the `Dynamic` policy to a type involves the following policy changes:  
  
-   The base type of the type is marked with the `Dynamic` policy.  
  
-   If the type is an instantiated generic, the uninstantiated version of the type is marked with the `Dynamic` policy.  
  
-   If the type is a delegate type, the `Invoke` method on the type is marked with the `Dynamic` policy.  
  
-   Each interface of the type is marked with the `Browse` policy.  
  
-   The type of each attribute applied to the type is marked with the `Browse` policy.  
  
-   If the type is generic, each constraint type is marked with the `Browse` policy.  
  
-   If the type is generic, the types over which the type is instantiated are marked with the `Browse` policy.  
  
 Applying the `Dynamic` policy to a method involves the following policy changes:  
  
-   Each parameter type of the method is marked with the `Browse` policy.  
  
-   The return type of the method is marked with the `Dynamic` policy.  
  
-   The containing type of the method is marked with the `Dynamic` policy.  
  
-   If the method is an instantiated generic method, the uninstantiated generic method is marked with the `Browse` policy.  
  
-   The type of each attribute applied to the method is marked with the `Browse` policy.  
  
-   If the method is generic, each constraint type is marked with the `Browse` policy.  
  
-   If the method is generic, the types over which the method is instantiated are marked with the `Browse` policy.  
  
-   The method can be invoked by `MethodInfo.Invoke`, and delegate creation becomes possible by <xref:System.Reflection.MethodInfo.CreateDelegate%2A?displayProperty=nameWithType>.  
  
 Applying the `Dynamic` policy to a field involves the following policy changes:  
  
-   The type of each attribute applied to the field is marked with the `Browse` policy.  
  
-   The type of the field is marked with the `Dynamic` policy.  
  
-   The type to which the field belongs is marked with the `Dynamic` policy.  
  
#### The effect of Activation policy  
 Applying the Activation policy to a type involves the following policy changes:  
  
-   If the type is an instantiated generic, the uninstantiated version of the type is marked with the `Browse` policy.  
  
-   If the type is a delegate type, the `Invoke` method on the type is marked with the `Dynamic` policy.  
  
-   Constructors of the type are marked with the `Activation` policy.  
  
 Applying the `Activation` policy to a method involves the following policy change:  
  
-   The constructor can be invoked by the <xref:System.Reflection.ConstructorInfo.Invoke%2A?displayProperty=nameWithType> and <xref:System.Activator.CreateInstance%2A?displayProperty=nameWithType> methods. For methods, the `Activation` policy affects constructors only.  
  
 Applying the `Activation` policy to a field has no effect.  
  
#### The effect of Serialize policy  
 The `Serialize` policy enables the use of common reflection-based serializers. However, because the exact reflection access patterns of non-Microsoft serializers are not known to Microsoft, this policy may not be entirely effective.  
  
 Applying the `Serialize` policy to a type involves the following policy changes:  
  
-   The base type of the type is marked with the `Serialize` policy.  
  
-   If the type is an instantiated generic, the uninstantiated version of the type is marked with the `Browse` policy.  
  
-   If the type is a delegate type, the `Invoke` method on the type is marked with the `Dynamic` policy.  
  
-   If the type is an enumeration, an array of the type is marked with the `Serialize` policy.  
  
-   If the type implements <xref:System.Collections.Generic.IEnumerable%601>, `T` is marked with the `Serialize` policy.  
  
-   If the type is <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.Generic.IList%601>, <xref:System.Collections.Generic.ICollection%601>, <xref:System.Collections.Generic.IReadOnlyCollection%601>, or <xref:System.Collections.Generic.IReadOnlyList%601>, then `T[]` and <xref:System.Collections.Generic.List%601> marked with the `Serialize` policy., but no members of the interface type are marked with the `Serialize` policy.  
  
-   If the type is <xref:System.Collections.Generic.List%601>, no members of the type are marked with the `Serialize` policy.  
  
-   If the type is <xref:System.Collections.Generic.IDictionary%602>, <xref:System.Collections.Generic.Dictionary%602> is marked with the `Serialize` policy. but no members of the type are marked with the `Serialize` policy.  
  
-   If the type is <xref:System.Collections.Generic.Dictionary%602>, no members of the type are marked with the `Serialize` policy.  
  
-   If the type implements <xref:System.Collections.Generic.IDictionary%602>, `TKey` and `TValue` are marked with the `Serialize` policy.  
  
-   Each constructor, each property accessor, and each field is marked with the `Serialize` policy.  
  
 Applying the `Serialize` policy to a method involves the following policy changes:  
  
-   The containing type is marked with the `Serialize` policy.  
  
-   The return type of the method is marked with the `Serialize` policy.  
  
 Applying the `Serialize` policy to a field involves the following policy changes:  
  
-   The containing type is marked with the `Serialize` policy.  
  
-   The type of the field is marked with the `Serialize` policy.  
  
#### The effect of XmlSerializer, DataContractSerializer, and DataContractJsonSerialier policies  
 Unlike the `Serialize` policy, which is intended for reflection-based serializers, the `XmlSerializer`, `DataContractSerializer`, and `DataContractJsonSerializer` policies are used to enable a set of serializers that are known to the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain. These serializers are not implemented by using reflection, but the set of types that can be serialized at run time is determined in a similar manner as types that are reflectable.  
  
 Applying one of these policies to a type enables the type to be serialized with the matching serializer. Also, any types that the serialization engine can statically determine as needing serialization will also be serializable.  
  
 These policies have no effect on methods or fields.  
  
 For more information, see the "Differences in Serializers" section in [Migrating Your Windows Store App to .NET Native](../../../docs/framework/net-native/migrating-your-windows-store-app-to-net-native.md).  
  
## See Also  
 [Runtime Directive Elements](../../../docs/framework/net-native/runtime-directive-elements.md)  
 [Reflection and .NET Native](../../../docs/framework/net-native/reflection-and-net-native.md)
