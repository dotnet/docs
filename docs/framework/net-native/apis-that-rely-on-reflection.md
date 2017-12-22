---
title: "APIs That Rely on Reflection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f9532629-6594-4a41-909f-d083f30a42f3
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# APIs That Rely on Reflection
In some cases, the use of reflection in code isn't obvious, and so the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain doesn't preserve metadata that is needed at run time. This topic covers some common APIs or common programming patterns that aren't considered part of the reflection API but that rely on reflection to execute successfully. If you use them in your source code, you can add information about them to the runtime directives (.rd.xml) file so that calls to these APIs do not throw a [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) exception or some other exception at run time.  
  
## Type.MakeGenericType method  
 You can dynamically instantiate a generic type `AppClass<T>` by calling the <xref:System.Type.MakeGenericType%2A?displayProperty=nameWithType> method by using code like this:  
  
 [!code-csharp[ProjectN#1](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/type_makegenerictype1.cs#1)]  
  
 For this code to succeed at run time, several items of metadata are required. The first is `Browse` metadata for the uninstantiated generic type, `AppClass<T>`:  
  
```xml  
<Type Name="App1.AppClass`1" Browse="Required PublicAndInternal" />  
```  
  
 This allows the <xref:System.Type.GetType%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> method call to succeed and return a valid <xref:System.Type> object.  
  
 But even when you add metadata for the uninstantiated generic type, calling the <xref:System.Type.MakeGenericType%2A?displayProperty=nameWithType> method throws a [MissingMetadataException](../../../docs/framework/net-native/missingmetadataexception-class-net-native.md) exception:  
  
```  
This operation cannot be carried out as metadata for the following type was removed for performance reasons:  
  
App1.AppClass`1<System.Int32>.  
```  
  
 You can add the following run-time directive to the runtime directives file to add `Activate` metadata for the specific instantiation over `AppClass<T>` of <xref:System.Int32?displayProperty=nameWithType>:  
  
```xml  
<TypeInstantiation Name="App1.AppClass" Arguments="System.Int32"   
                   Activate="Required Public" />  
```  
  
 Each different instantiation over `AppClass<T>` requires a separate directive if it is being created with the <xref:System.Type.MakeGenericType%2A?displayProperty=nameWithType> method and not used statically.  
  
## MethodInfo.MakeGenericMethod method  
 Given a class `Class1` with a generic method `GetMethod<T>(T t)`, `GetMethod` can be invoked through reflection by using code like this:  
  
 [!code-csharp[ProjectN#2](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/makegenericmethod1.cs#2)]  
  
 To run successfully, this code requires several items of metadata:  
  
-   `Browse` metadata for the type whose method you want to call.  
  
-   `Browse` metadata for the method you want to call.  If it is a public method, adding public `Browse` metadata for the containing type includes the method, too.  
  
-   Dynamic metadata for the method you want to call, so that the reflection invocation delegate is not removed by the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain. If dynamic metadata is missing for the method, the following exception is thrown when the <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A?displayProperty=nameWithType> method is called:  
  
    ```  
    MakeGenericMethod() cannot create this generic method instantiation because the instantiation was not metadata-enabled: 'App1.Class1.GenMethod<Int32>(Int32)'.  
    ```  
  
 The following runtime directives ensure that all required metadata is available:  
  
```xml  
<Type Name="App1.Class1" Browse="Required PublicAndInternal">  
   <MethodInstantiation Name="GenMethod" Arguments="System.Int32" Dynamic="Required"/>  
</Type>  
```  
  
 A `MethodInstantiation` directive is required for each different instantiation of the method that is dynamically invoked, and the `Arguments` element is updated to reflect each different instantiation argument.  
  
## Array.CreateInstance and Type.MakeTypeArray methods  
 The following example calls the <xref:System.Type.MakeArrayType%2A?displayProperty=nameWithType> and <xref:System.Array.CreateInstance%2A?displayProperty=nameWithType> methods on a type, `Class1`.  
  
 [!code-csharp[ProjectN#3](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/array1.cs#3)]  
  
 If no array metadata is present, the following error results:  
  
```  
This operation cannot be carried out as metadata for the following type was removed for performance reasons:  
  
App1.Class1[]  
  
Unfortunately, no further information is available.  
```  
  
 `Browse` metadata for the array type is required to dynamically instantiate it.  The following runtime directive allows dynamic instantiation of `Class1[]`.  
  
```xml  
<Type Name="App1.Class1[]" Browse="Required Public" />  
```  
  
## See Also  
 [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md)  
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)
