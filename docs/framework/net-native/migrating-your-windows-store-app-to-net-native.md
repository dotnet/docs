---
title: "Migrating Your Windows Store App to .NET Native | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4153aa18-6f56-4a0a-865b-d3da743a1d05
caps.latest.revision: 29
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Migrating Your Windows Store App to .NET Native
[!INCLUDE[net_native](../../../includes/net-native-md.md)] provides static compilation of apps in the Windows Store or on the developer’s computer. This differs from the dynamic compilation performed for Windows Store apps by the just-in-time (JIT) compiler or the [Native Image Generator (Ngen.exe)](../../../docs/framework/tools/ngen-exe-native-image-generator.md) on the device. Despite the differences, [!INCLUDE[net_native](../../../includes/net-native-md.md)] tries to maintain compatibility with the [.NET for Windows Store apps](http://msdn.microsoft.com/library/windows/apps/br230302.aspx). For the most part, things that work on the .NET for Windows Store apps also work with [!INCLUDE[net_native](../../../includes/net-native-md.md)].  However, in some cases, you may encounter behavioral changes. This document discusses these differences between the standard .NET for Windows Store apps and [!INCLUDE[net_native](../../../includes/net-native-md.md)] in the following areas:  
  
-   [General runtime differences](#Runtime)  
  
-   [Dynamic programming differences](#Dynamic)  
  
-   [Other reflection-related differences](#Reflection)  
  
-   [Unsupported scenarios and APIs](#Unsupported)  
  
-   [Visual Studio differences](#VS)  
  
<a name="Runtime"></a>   
## General runtime differences  
  
-   Exceptions, such as <xref:System.TypeLoadException>, that are thrown by the JIT compiler when an app runs on the common language runtime (CLR) generally result in compile-time errors when processed by [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
-   Don't call the <xref:System.GC.WaitForPendingFinalizers%2A?displayProperty=fullName> method from an app's UI thread. This can result in a deadlock on [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
-   Don't rely on static class constructor invocation ordering. In [!INCLUDE[net_native](../../../includes/net-native-md.md)], the invocation order is different from the order on the standard runtime. (Even with the standard runtime, you shouldn't rely on the order of execution of static class constructors.)  
  
-   Infinite looping without making a call (for example, `while(true);`) on any thread may bring the app to a halt. Similarly, large or infinite waits may bring the app to a halt.  
  
-   Certain generic initialization cycles don't throw exceptions in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. For example, the following code throws a <xref:System.TypeLoadException> exception on the standard CLR. In [!INCLUDE[net_native](../../../includes/net-native-md.md)], it doesn't.  
  
     [!code-csharp[ProjectN#8](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/compat1.cs#8)]  
  
-   In some cases, [!INCLUDE[net_native](../../../includes/net-native-md.md)] provides different implementations of .NET Framework class libraries. An object returned from a method will always implement the members of the returned type. However, since its backing implementation is different, you may not be able to cast it to the same set of types as you could on other .NET Framework platforms. For example, in some cases, you may not be able to cast the <xref:System.Collections.Generic.IEnumerable%601> interface object returned by methods such as <xref:System.Reflection.TypeInfo.DeclaredMembers%2A?displayProperty=fullName> or <xref:System.Reflection.TypeInfo.DeclaredProperties%2A?displayProperty=fullName> to `T[]`.  
  
-   The WinInet cache isn't enabled by default on .NET for Windows Store apps, but it is on [!INCLUDE[net_native](../../../includes/net-native-md.md)]. This improves performance but has working set implications. No developer action is necessary.  
  
<a name="Dynamic"></a>   
## Dynamic programming differences  
 [!INCLUDE[net_native](../../../includes/net-native-md.md)] statically links in code from the .NET Framework to make the code app-local for maximum performance. However, binary sizes have to remain small, so the entire .NET Framework can't be brought in. The [!INCLUDE[net_native](../../../includes/net-native-md.md)] compiler resolves this limitation by using a dependency reducer that removes references to unused code. However, [!INCLUDE[net_native](../../../includes/net-native-md.md)] might not maintain or generate some type information and code when that information can't be inferred statically at compile time, but instead is retrieved dynamically at runtime.  
  
 [!INCLUDE[net_native](../../../includes/net-native-md.md)] does enable reflection and dynamic programming. However, not all types can be marked for reflection, because this would make the generated code size too large (especially because reflecting on public APIs in the .NET Framework is supported). The [!INCLUDE[net_native](../../../includes/net-native-md.md)] compiler makes smart choices about which types should support reflection, and it keeps the metadata and generates code only for those types.  
  
 For example, data binding requires an app to be able to map property names to functions. In .NET for Windows Store apps, the common language runtime automatically uses reflection to provide this capability for managed types and publicly available native types. In [!INCLUDE[net_native](../../../includes/net-native-md.md)], the compiler automatically includes metadata for types to which you bind data.  
  
 The [!INCLUDE[net_native](../../../includes/net-native-md.md)] compiler can also handle commonly used generic types such as <xref:System.Collections.Generic.List%601> and <xref:System.Collections.Generic.Dictionary%602>, which work without requiring any hints or directives. The [dynamic](~/docs/csharp/language-reference/keywords/dynamic.md) keyword is also supported within certain limits.  
  
> [!NOTE]
>  You should test all dynamic code paths thoroughly when porting your app to [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 The default configuration for [!INCLUDE[net_native](../../../includes/net-native-md.md)] is sufficient for most developers, but some developers might want to fine- tune their configurations by using a runtime directives (.rd.xml) file. In addition, in some cases, the [!INCLUDE[net_native](../../../includes/net-native-md.md)] compiler is unable to determine which metadata must be available for reflection and relies on hints, particularly in the following cases:  
  
-   Some constructs like <xref:System.Type.MakeGenericType%2A?displayProperty=fullName> and <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A?displayProperty=fullName> can't be determined statically.  
  
-   Because the compiler can't determine the instantiations, a generic type that you want to reflect on has to be specified by runtime directives. This isn't just because all code must be included, but because reflection on generic types can form an infinite cycle (for example, when a generic method is invoked on a generic type).  
  
> [!NOTE]
>  Runtime directives are defined in a runtime directives (.rd.xml) file. For general information about using this file, see [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md). For information about the runtime directives, see [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md).  
  
 [!INCLUDE[net_native](../../../includes/net-native-md.md)] also includes profiling tools that help the developer determine which types outside the default set should support reflection.  
  
<a name="Reflection"></a>   
## Other reflection-related differences  
 There are a number of other individual reflection-related differences in behavior between the .NET for Windows Store apps and [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 In [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
-   Private reflection over types and members in the .NET Framework class library is not supported. You can, however, reflect over your own private types and members, as well as types and members in third-party libraries.  
  
-   The <xref:System.Reflection.ParameterInfo.HasDefaultValue%2A?displayProperty=fullName> property correctly returns `false` for a <xref:System.Reflection.ParameterInfo> object that represents a return value. In the .NET for Windows Store apps, it returns `true`. Intermediate language (IL) doesn’t support this directly, and interpretation is left to the language.  
  
-   Public members on the <xref:System.RuntimeFieldHandle> and <xref:System.RuntimeMethodHandle> structures aren't supported. These types are supported only for LINQ, expression trees, and static array initialization.  
  
-   <xref:System.Reflection.RuntimeReflectionExtensions.GetRuntimeProperties%2A?displayProperty=fullName> and <xref:System.Reflection.RuntimeReflectionExtensions.GetRuntimeEvents%2A?displayProperty=fullName> include hidden members in base classes and thus may be overridden without explicit overrides. This is also true of other [RuntimeReflectionExtensions.GetRuntime*](http://msdn.microsoft.com/library/system.reflection.runtimereflectionextensions_methods.aspx) methods.  
  
-   <xref:System.Type.MakeArrayType%2A?displayProperty=fullName> and <xref:System.Type.MakeByRefType%2A?displayProperty=fullName> don't fail when you try to create certain combinations (for example, an array of byrefs).  
  
-   You can't use reflection to invoke members that have pointer parameters.  
  
-   You can't use reflection to get or set a pointer field.  
  
-   When the argument count is wrong and the type of one of the arguments is incorrect, [!INCLUDE[net_native](../../../includes/net-native-md.md)] throws an <xref:System.ArgumentException> instead of a <xref:System.Reflection.TargetParameterCountException>.  
  
-   Binary serialization of exceptions is generally not supported. As a result, non-serializable objects can be added to the <xref:System.Exception.Data%2A?displayProperty=fullName> dictionary.  
  
<a name="Unsupported"></a>   
## Unsupported scenarios and APIs  
 The following sections list unsupported scenarios and APIs for general development, interop, and technologies such as HTTPClient and Windows Communication Foundation (WCF):  
  
-   [General development](#General)  
  
-   [HttpClient](#HttpClient)  
  
-   [Interop](#Interop)  
  
-   [Unsupported APIs](#APIs)  
  
<a name="General"></a>   
### General development differences  
 **Value types**  
  
-   If you override the <xref:System.ValueType.Equals%2A?displayProperty=fullName> and <xref:System.ValueType.GetHashCode%2A?displayProperty=fullName> methods for a value type, don't call the base class implementations. In .NET for Windows Store apps, these methods rely on reflection. At compile time, [!INCLUDE[net_native](../../../includes/net-native-md.md)] generates an implementation that doesn't rely on runtime reflection. This means that if you don't override these two methods, they will work as expected, because [!INCLUDE[net_native](../../../includes/net-native-md.md)] generates the implementation at compile time. However, overriding these methods but calling the base class implementation results in an exception.  
  
-   Value types larger than one megabyte aren't supported.  
  
-   Value types can't have a default constructor in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. (C# and Visual Basic prohibit default constructors on value types. However, these can be created in IL.)  
  
 **Arrays**  
  
-   Arrays with a lower bound other than zero aren't supported. Typically, these arrays are created by calling the <xref:System.Array.CreateInstance%28System.Type%2CSystem.Int32%5B%5D%2CSystem.Int32%5B%5D%29?displayProperty=fullName> overload.  
  
-   Dynamic creation of multidimensional arrays isn't supported. Such arrays are typically created by calling an overload of the <xref:System.Array.CreateInstance%2A?displayProperty=fullName> method that includes a `lengths` parameter, or by calling the <xref:System.Type.MakeArrayType%28System.Int32%29?displayProperty=fullName> method.  
  
-   Multidimensional arrays that have four or more dimensions aren't supported; that is, their <xref:System.Array.Rank%2A?displayProperty=fullName> property value is four or greater. Use [jagged arrays](~/docs/csharp/programming-guide/arrays/jagged-arrays.md) (an array of arrays) instead. For example, `array[x,y,z]` is invalid, but `array[x][y][z]` isn't.  
  
-   Variance for multidimensional arrays isn't supported and causes an <xref:System.InvalidCastException> exception at run time.  
  
 **Generics**  
  
-   Infinite generic type expansion results in a compiler error. For example, this code fails to compile:  
  
     [!code-csharp[ProjectN#9](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/compat2.cs#9)]  
  
 **Pointers**  
  
-   Arrays of pointers aren't supported.  
  
-   You can't use reflection to get or set a pointer field.  
  
 **Serialization**  
  
 The <xref:System.Runtime.Serialization.KnownTypeAttribute.%23ctor%28System.String%29> attribute isn't supported. Use the <xref:System.Runtime.Serialization.KnownTypeAttribute.%23ctor%28System.Type%29> attribute instead.  
  
 **Resources**  
  
 The use of localized resources with the <xref:System.Diagnostics.Tracing.EventSource> class isn't supported. The <xref:System.Diagnostics.Tracing.EventSourceAttribute.LocalizationResources%2A?displayProperty=fullName> property doesn't define localized resources.  
  
 **Delegates**  
  
 `Delegate.BeginInvoke` and `Delegate.EndInvoke` aren't supported.  
  
 **Async**  
  
 Threading logic in overloads of Task IAsync isn't supported.  
  
 **Miscellaneous APIs**  
  
-   The <xref:System.Reflection.TypeInfo.GUID%2A?displayProperty=fullName> property throws a <xref:System.PlatformNotSupportedException> exception if a <xref:System.Runtime.InteropServices.GuidAttribute> attribute isn't applied to the type. The GUID is used primarily for COM support.  
  
-   The <xref:System.DateTime.Parse%2A?displayProperty=fullName> method correctly parses strings that contain short dates in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. However, it doesn't maintain compatibility with the changes in date and time parsing described in the Microsoft Knowledge Base articles [KB2803771](http://support.microsoft.com/kb/2803771) and [KB2803755](http://support.microsoft.com/kb/2803755).  
  
-   <xref:System.Numerics.BigInteger.ToString%2A?displayProperty=fullName> `("E")` is correctly rounded in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. In some versions of the CLR, the result string is truncated instead of rounded.  
  
<a name="HttpClient"></a>   
### HttpClient differences  
 In [!INCLUDE[net_native](../../../includes/net-native-md.md)], the <xref:System.Net.Http.HttpClientHandler> class internally uses WinINet (through the [HttpBaseProtocolFilter](http://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx) class) instead of the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes used in the standard .NET for Windows Store apps.  WinINet doesn't support all the configuration options that the <xref:System.Net.Http.HttpClientHandler> class supports.  As a result:  
  
-   Some of the capability properties on <xref:System.Net.Http.HttpClientHandler> return `false` on [!INCLUDE[net_native](../../../includes/net-native-md.md)], whereas they return `true` in the standard .NET for Windows Store apps.  
  
-   Some of the configuration property `get` accessors always return a fixed value on [!INCLUDE[net_native](../../../includes/net-native-md.md)] that is different than the default configurable value in .NET for Windows Store apps.  
  
 Some additional behavior differences are covered in the following subsections.  
  
 **Proxy**  
  
 The [HttpBaseProtocolFilter](http://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx) class doesn’t support configuring or overriding the proxy on a per-request basis.  This means that all requests on [!INCLUDE[net_native](../../../includes/net-native-md.md)] use the system-configured proxy server or no proxy server, depending on the value of the <xref:System.Net.Http.HttpClientHandler.UseProxy%2A?displayProperty=fullName> property.  In .NET for Windows Store apps, the proxy server is defined by the <xref:System.Net.Http.HttpClientHandler.Proxy%2A?displayProperty=fullName> property.  On [!INCLUDE[net_native](../../../includes/net-native-md.md)], setting the <xref:System.Net.Http.HttpClientHandler.Proxy%2A?displayProperty=fullName> to a value other than `null` throws a <xref:System.PlatformNotSupportedException> exception.  The <xref:System.Net.Http.HttpClientHandler.SupportsProxy%2A?displayProperty=fullName> property returns `false` on [!INCLUDE[net_native](../../../includes/net-native-md.md)], whereas it returns `true` in the standard .NET Framework for Windows Store apps.  
  
 **Automatic redirection**  
  
 The [HttpBaseProtocolFilter](http://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx) class doesn't allow the maximum number of automatic redirections to be configured.  The value of the <xref:System.Net.Http.HttpClientHandler.MaxAutomaticRedirections%2A?displayProperty=fullName> property is 50 by default in the standard .NET for Windows Store apps and can be modified. On [!INCLUDE[net_native](../../../includes/net-native-md.md)], the value of this property is 10, and trying to modify it throws a <xref:System.PlatformNotSupportedException> exception.  The <xref:System.Net.Http.HttpClientHandler.SupportsRedirectConfiguration%2A?displayProperty=fullName> property returns `false` on [!INCLUDE[net_native](../../../includes/net-native-md.md)], whereas it returns `true` in .NET for Windows Store apps.  
  
 **Automatic decompression**  
  
 .NET for Windows Store apps allows you to set the <xref:System.Net.Http.HttpClientHandler.AutomaticDecompression%2A?displayProperty=fullName> property to <xref:System.Net.DecompressionMethods>, <xref:System.Net.DecompressionMethods>, both <xref:System.Net.DecompressionMethods> and <xref:System.Net.DecompressionMethods>, or <xref:System.Net.DecompressionMethods>.  [!INCLUDE[net_native](../../../includes/net-native-md.md)] only supports <xref:System.Net.DecompressionMethods> together with <xref:System.Net.DecompressionMethods>, or <xref:System.Net.DecompressionMethods>.  Trying to set the <xref:System.Net.Http.HttpClientHandler.AutomaticDecompression%2A> property to either <xref:System.Net.DecompressionMethods> or <xref:System.Net.DecompressionMethods> alone silently sets it to both <xref:System.Net.DecompressionMethods> and <xref:System.Net.DecompressionMethods>.  
  
 **Cookies**  
  
 Cookie handling is performed simultaneously by <xref:System.Net.Http.HttpClient> and WinINet.  Cookies from the <xref:System.Net.CookieContainer> are combined with cookies in the WinINet cookie cache.  Removing a cookie from <xref:System.Net.CookieContainer> prevents <xref:System.Net.Http.HttpClient> from sending the cookie, but if the cookie was already seen by WinINet, and cookies weren't deleted by the user, WinINet sends it.  It isn't possible to programmatically remove a cookie from WinINet by using the <xref:System.Net.Http.HttpClient>, <xref:System.Net.Http.HttpClientHandler>, or <xref:System.Net.CookieContainer> API.  Setting the <xref:System.Net.Http.HttpClientHandler.UseCookies%2A?displayProperty=fullName> property to `false` causes only <xref:System.Net.Http.HttpClient> to stop sending cookies; WinINet might still include its cookies in the request.  
  
 **Credentials**  
  
 In .NET for Windows Store apps, the <xref:System.Net.Http.HttpClientHandler.UseDefaultCredentials%2A?displayProperty=fullName> and <xref:System.Net.Http.HttpClientHandler.Credentials%2A?displayProperty=fullName> properties work independently.  Additionally, the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property accepts any object that implements the <xref:System.Net.ICredentials> interface.  In [!INCLUDE[net_native](../../../includes/net-native-md.md)], setting the <xref:System.Net.Http.HttpClientHandler.UseDefaultCredentials%2A> property to `true` causes the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property to become `null`.  In addition, the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property can be set only to `null`, <xref:System.Net.CredentialCache.DefaultCredentials%2A>, or an object of type <xref:System.Net.NetworkCredential>.  Assigning any other <xref:System.Net.ICredentials> object, the most popular of which is <xref:System.Net.CredentialCache>, to the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property throws a <xref:System.PlatformNotSupportedException>.  
  
 **Other unsupported or unconfigurable features**  
  
 In [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
-   The value of the <xref:System.Net.Http.HttpClientHandler.ClientCertificateOptions%2A?displayProperty=fullName> property is always <xref:System.Net.Http.ClientCertificateOption>.  In .NET for Windows Store apps, the default is <xref:System.Net.Http.ClientCertificateOption>.  
  
-   The <xref:System.Net.Http.HttpClientHandler.MaxRequestContentBufferSize%2A?displayProperty=fullName> property isn't configurable.  
  
-   The <xref:System.Net.Http.HttpClientHandler.PreAuthenticate%2A?displayProperty=fullName> property is always `true`.  In .NET for Windows Store apps, the default is `false`.  
  
-   The `SetCookie2` header in responses is ignored as obsolete.  
  
<a name="Interop"></a>   
### Interop differences  
 **Deprecated APIs**  
  
 A number of infrequently used APIs for interoperability with managed code have been deprecated. When used with [!INCLUDE[net_native](../../../includes/net-native-md.md)], these APIs may throw a <xref:System.NotImplementedException> or <xref:System.PlatformNotSupportedException> exception, or result in a compiler error. In .NET for Windows Store apps, these APIs are marked as obsolete, although calling them generates a compiler warning rather than a compiler error.  
  
 Deprecated APIs for `VARIANT` marshaling:  
  
||  
|-|  
|<xref:System.Runtime.InteropServices.BStrWrapper?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.CurrencyWrapper?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.DispatchWrapper?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.ErrorWrapper?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.UnknownWrapper?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.VariantWrapper?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.VarEnum?displayProperty=fullName>|  
  
 <xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName> is supported, but it throws an exception in some scenarios, such as when it is used with [IDispatch](http://msdn.microsoft.com/library/windows/apps/ms221608.aspx) or byref variants.  
  
 Deprecated APIs for [IDispatch](http://msdn.microsoft.com/library/windows/apps/ms221608.aspx) support:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.ClassInterfaceType?displayProperty=fullName>|<xref:System.Runtime.InteropServices.ClassInterfaceType>|  
|<xref:System.Runtime.InteropServices.ClassInterfaceType?displayProperty=fullName>|<xref:System.Runtime.InteropServices.ClassInterfaceType>|  
|<xref:System.Runtime.InteropServices.ComDefaultInterfaceAttribute?displayProperty=fullName>|Attribute isn't supported|  
  
 Deprecated APIs for classic COM events:  
  
||  
|-|  
|<xref:System.Runtime.InteropServices.ComEventsHelper?displayProperty=fullName>|  
|<xref:System.Runtime.InteropServices.ComSourceInterfacesAttribute>|  
  
 Deprecated APIs in the <xref:System.Runtime.InteropServices.ICustomQueryInterface?displayProperty=fullName> interface, which isn't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.ICustomQueryInterface?displayProperty=fullName>|All members.|  
|<xref:System.Runtime.InteropServices.CustomQueryInterfaceMode?displayProperty=fullName>|All members.|  
|<xref:System.Runtime.InteropServices.CustomQueryInterfaceResult?displayProperty=fullName>|All members.|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.GetComInterfaceForObject%28System.Object%2CSystem.Type%2CSystem.Runtime.InteropServices.CustomQueryInterfaceMode%29?displayProperty=fullName>|  
  
 Other unsupported interop features:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.ICustomAdapter?displayProperty=fullName>|All members.|  
|<xref:System.Runtime.InteropServices.SafeBuffer?displayProperty=fullName>|All members.|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>|<xref:System.Runtime.InteropServices.UnmanagedType>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>|<xref:System.Runtime.InteropServices.UnmanagedType>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>|<xref:System.Runtime.InteropServices.UnmanagedType>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>|<xref:System.Runtime.InteropServices.UnmanagedType>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>|<xref:System.Runtime.InteropServices.UnmanagedType>|  
  
 Rarely used marshalling APIs:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.ReadByte%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.ReadInt16%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.ReadInt32%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.ReadInt64%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.ReadIntPtr%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.WriteByte%28System.Object%2CSystem.Int32%2CSystem.Byte%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.WriteInt16%28System.Object%2CSystem.Int32%2CSystem.Int16%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.WriteInt32%28System.Object%2CSystem.Int32%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.WriteInt64%28System.Object%2CSystem.Int32%2CSystem.Int64%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=fullName>|<xref:System.Runtime.InteropServices.Marshal.WriteIntPtr%28System.Object%2CSystem.Int32%2CSystem.IntPtr%29>|  
  
 **Platform invoke and COM interop compatibility**  
  
 Most platform invoke and COM interop scenarios are still supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. In particular, all interoperability with Windows Runtime (WinRT) APIs and all marshaling required for the Windows Runtime is supported. This includes marshaling support for:  
  
-   Arrays (including <xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=fullName>)  
  
-   `BStr`  
  
-   Delegates  
  
-   Strings (Unicode, Ansi, and HSTRING)  
  
-   Structs (`byref` and `byval`)  
  
-   Unions  
  
-   Win32 handles  
  
-   All WinRT constructs  
  
-   Partial support for marshaling variant types. The following are supported:  
  
    -   <xref:System.Boolean>  
  
    -   <xref:System.Byte>  
  
    -   <xref:System.Decimal>  
  
    -   <xref:System.Double>  
  
    -   <xref:System.Int16>  
  
    -   <xref:System.Int32>  
  
    -   <xref:System.Int64>  
  
    -   <xref:System.SByte>  
  
    -   <xref:System.Single>  
  
    -   <xref:System.UInt16>  
  
    -   <xref:System.UInt32>  
  
    -   <xref:System.UInt64>  
  
    -   `BStr`  
  
    -   [IUnknown](http://msdn.microsoft.com/library/windows/desktop/ms680509.aspx)  
  
 However, [!INCLUDE[net_native](../../../includes/net-native-md.md)] doesn't support the following:  
  
-   Using classic COM events  
  
-   Implementing the <xref:System.Runtime.InteropServices.ICustomQueryInterface?displayProperty=fullName> interface on a managed type  
  
-   Implementing the [IDispatch](http://msdn.microsoft.com/library/windows/apps/ms221608.aspx) interface on a managed type through the <xref:System.Runtime.InteropServices.ComDefaultInterfaceAttribute?displayProperty=fullName> attribute. However, note that you can't call COM objects through `IDispatch`, and your managed object can't implement `IDispatch`.  
  
 Using reflection to invoke a platform invoke method isn't supported. You can work around this limitation by wrapping the method call in another method and using reflection to call the wrapper instead.  
  
<a name="APIs"></a>   
### Other differences from .NET APIs for Windows Store apps  
 This section lists the remaining APIs that aren't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. The largest set of the unsupported APIs are Windows Communication Foundation (WCF) APIs.  
  
 **DataAnnotations (System.ComponentModel.DataAnnotations)**  
  
 The types in the <xref:System.ComponentModel.DataAnnotations> and <xref:System.ComponentModel.DataAnnotations.Schema> namespaces aren't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. These include the following types that are present in the .NET for Windows Store apps for Windows 8:  
  
||  
|-|  
|<xref:System.ComponentModel.DataAnnotations.AssociationAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.ConcurrencyCheckAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.CustomValidationAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.DataType?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.DataTypeAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.DisplayAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.DisplayColumnAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.DisplayFormatAttribute>|  
|<xref:System.ComponentModel.DataAnnotations.EditableAttribute>|  
|<xref:System.ComponentModel.DataAnnotations.EnumDataTypeAttribute>|  
|<xref:System.ComponentModel.DataAnnotations.FilterUIHintAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.KeyAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.RangeAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.RequiredAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.StringLengthAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.TimestampAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.UIHintAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationContext?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationException?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationResult?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.Validator?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute?displayProperty=fullName>|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption?displayProperty=fullName>|  
  
 **Visual Basic**  
  
 Visual Basic isn't currently supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. The following types in the <xref:Microsoft.VisualBasic> and <xref:Microsoft.VisualBasic.CompilerServices> namespaces aren't available in [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
||  
|-|  
|<xref:Microsoft.VisualBasic.CallType?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.Constants?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.HideModuleNameAttribute?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.Strings?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.Conversions?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.DesignerGeneratedAttribute?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.IncompleteInitialization?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.NewLateBinding?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.ObjectFlowControl?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.ObjectFlowControl.ForLoopControl?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.Operators?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.OptionCompareAttribute?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.OptionTextAttribute?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.ProjectData?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag?displayProperty=fullName>|  
|<xref:Microsoft.VisualBasic.CompilerServices.Utils?displayProperty=fullName>|  
  
 **Reflection Context (System.Reflection.Context namespace)**  
  
 The <xref:System.Reflection.Context.CustomReflectionContext?displayProperty=fullName> class isn't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 **RTC (System.Net.Http.Rtc)**  
  
 The <xref:System.Net.Http.RtcRequestFactory?displayProperty=fullName> class isn't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 **Windows Communication Foundation (WCF) (System.ServiceModel.\*)**  
  
 The types in the [System.ServiceModel.* namespaces](http://msdn.microsoft.com/library/gg145010.aspx) aren't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. These includes the following types:  
  
||  
|-|  
|<xref:System.ServiceModel.ActionNotSupportedException?displayProperty=fullName>|  
|<xref:System.ServiceModel.BasicHttpBinding?displayProperty=fullName>|  
|<xref:System.ServiceModel.BasicHttpMessageCredentialType?displayProperty=fullName>|  
|<xref:System.ServiceModel.BasicHttpSecurity?displayProperty=fullName>|  
|<xref:System.ServiceModel.BasicHttpSecurityMode?displayProperty=fullName>|  
|<xref:System.ServiceModel.CallbackBehaviorAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.ChannelFactory?displayProperty=fullName>|  
|<xref:System.ServiceModel.ChannelFactory%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.ClientBase%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.ClientBase%601.BeginOperationDelegate?displayProperty=fullName>|  
|<xref:System.ServiceModel.ClientBase%601.ChannelBase%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.ClientBase%601.EndOperationDelegate?displayProperty=fullName>|  
|<xref:System.ServiceModel.ClientBase%601.InvokeAsyncCompletedEventArgs?displayProperty=fullName>|  
|<xref:System.ServiceModel.CommunicationException?displayProperty=fullName>|  
|<xref:System.ServiceModel.CommunicationObjectAbortedException?displayProperty=fullName>|  
|<xref:System.ServiceModel.CommunicationObjectFaultedException?displayProperty=fullName>|  
|<xref:System.ServiceModel.CommunicationState?displayProperty=fullName>|  
|<xref:System.ServiceModel.DataContractFormatAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.DnsEndpointIdentity?displayProperty=fullName>|  
|<xref:System.ServiceModel.DuplexChannelFactory%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.DuplexClientBase%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.EndpointAddress?displayProperty=fullName>|  
|<xref:System.ServiceModel.EndpointAddressBuilder?displayProperty=fullName>|  
|<xref:System.ServiceModel.EndpointIdentity?displayProperty=fullName>|  
|<xref:System.ServiceModel.EndpointNotFoundException?displayProperty=fullName>|  
|<xref:System.ServiceModel.EnvelopeVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.ExceptionDetail?displayProperty=fullName>|  
|<xref:System.ServiceModel.FaultCode?displayProperty=fullName>|  
|<xref:System.ServiceModel.FaultContractAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.FaultException?displayProperty=fullName>|  
|<xref:System.ServiceModel.FaultException%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.FaultReason?displayProperty=fullName>|  
|<xref:System.ServiceModel.FaultReasonText?displayProperty=fullName>|  
|<xref:System.ServiceModel.HttpBindingBase?displayProperty=fullName>|  
|<xref:System.ServiceModel.HttpClientCredentialType?displayProperty=fullName>|  
|<xref:System.ServiceModel.HttpTransportSecurity?displayProperty=fullName>|  
|<xref:System.ServiceModel.IClientChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.ICommunicationObject?displayProperty=fullName>|  
|<xref:System.ServiceModel.IContextChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.IDefaultCommunicationTimeouts?displayProperty=fullName>|  
|<xref:System.ServiceModel.IExtensibleObject%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.IExtension%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.IExtensionCollection%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.InstanceContext?displayProperty=fullName>|  
|<xref:System.ServiceModel.InvalidMessageContractException?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageBodyMemberAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageContractAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageContractMemberAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageCredentialType?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageHeader%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageHeaderException?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageParameterAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageSecurityOverTcp?displayProperty=fullName>|  
|<xref:System.ServiceModel.MessageSecurityVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.NetHttpBinding?displayProperty=fullName>|  
|<xref:System.ServiceModel.NetHttpMessageEncoding?displayProperty=fullName>|  
|<xref:System.ServiceModel.NetTcpBinding?displayProperty=fullName>|  
|<xref:System.ServiceModel.NetTcpSecurity?displayProperty=fullName>|  
|<xref:System.ServiceModel.OperationContext?displayProperty=fullName>|  
|<xref:System.ServiceModel.OperationContextScope?displayProperty=fullName>|  
|<xref:System.ServiceModel.OperationContractAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.OperationFormatStyle?displayProperty=fullName>|  
|<xref:System.ServiceModel.ProtocolException?displayProperty=fullName>|  
|<xref:System.ServiceModel.QuotaExceededException?displayProperty=fullName>|  
|<xref:System.ServiceModel.SecurityMode?displayProperty=fullName>|  
|<xref:System.ServiceModel.ServerTooBusyException?displayProperty=fullName>|  
|<xref:System.ServiceModel.ServiceActivationException?displayProperty=fullName>|  
|<xref:System.ServiceModel.ServiceContractAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.ServiceKnownTypeAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.SpnEndpointIdentity?displayProperty=fullName>|  
|<xref:System.ServiceModel.TcpClientCredentialType?displayProperty=fullName>|  
|<xref:System.ServiceModel.TcpTransportSecurity?displayProperty=fullName>|  
|<xref:System.ServiceModel.TransferMode?displayProperty=fullName>|  
|<xref:System.ServiceModel.UnknownMessageReceivedEventArgs?displayProperty=fullName>|  
|<xref:System.ServiceModel.UpnEndpointIdentity?displayProperty=fullName>|  
|<xref:System.ServiceModel.XmlSerializerFormatAttribute?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.AddressHeader?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.AddressHeaderCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.AddressingVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.ChannelManagerBase?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.ChannelParameterCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.CommunicationObject?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.CompressionFormat?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.CustomBinding?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.FaultConverter?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.HttpRequestMessageProperty?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.HttpResponseMessageProperty?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.HttpsTransportBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.HttpTransportBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IChannelFactory?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IChannelFactory%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IDuplexChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IDuplexSession?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IDuplexSessionChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IHttpCookieContainerManager?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IInputChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IInputSession?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IInputSessionChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IMessageProperty?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IOutputChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IOutputSession?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IOutputSessionChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IRequestChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.IRequestSessionChannel?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.ISession?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.ISessionChannel%601?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.LocalClientSecuritySettings?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.Message?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageBuffer?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageEncoder?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageEncoderFactory?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageEncodingBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageFault?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageHeader?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageHeaderInfo?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageHeaders?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageProperties?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageState?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.MessageVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.RequestContext?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.SecurityBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.SecurityHeaderLayout?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.TcpConnectionPoolSettings?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.TcpTransportBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.TransportBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.TransportSecurityBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.WebSocketTransportSettings?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.WebSocketTransportUsage?displayProperty=fullName>|  
|<xref:System.ServiceModel.Channels.WindowsStreamSecurityBindingElement?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.ClientCredentials?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.ContractDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.FaultDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.FaultDescriptionCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.IContractBehavior?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.IEndpointBehavior?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.IOperationBehavior?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessageBodyDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessageDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessageDescriptionCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessageDirection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessageHeaderDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessageHeaderDescriptionCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessagePartDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessagePartDescriptionCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessagePropertyDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.MessagePropertyDescriptionCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.OperationDescription?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.OperationDescriptionCollection?displayProperty=fullName>|  
|<xref:System.ServiceModel.Description.ServiceEndpoint?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.ClientOperation?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.ClientRuntime?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.DispatchOperation?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.DispatchRuntime?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.EndpointDispatcher?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageFormatter?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageInspector?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.IClientOperationSelector?displayProperty=fullName>|  
|<xref:System.ServiceModel.Dispatcher.IParameterInspector?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.BasicSecurityProfileVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.HttpDigestClientCredential?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.MessageSecurityException?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.SecureConversationVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.SecurityAccessDeniedException?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.SecurityPolicyVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.SecurityVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.TrustVersion?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.UserNamePasswordClientCredential?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.WindowsClientCredential?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.Tokens.SupportingTokenParameters?displayProperty=fullName>|  
|<xref:System.ServiceModel.Security.Tokens.UserNameSecurityTokenParameters?displayProperty=fullName>|  
  
### Differences in serializers  
 The following differences concern serialization and deserialization with the <xref:System.Runtime.Serialization.DataContractSerializer>, <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>, and <xref:System.Xml.Serialization.XmlSerializer> classes:  
  
-   In [!INCLUDE[net_native](../../../includes/net-native-md.md)], <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> fail to serialize or deserialize a derived class that has a base class member whose type isn't a root serialization type. For example, in the following code, trying to serialize or deserialize `Y` results in an error:  
  
     [!code-csharp[ProjectN#10](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/compat3.cs#10)]  
  
     Type `InnerType` isn't known to the serializer, because the members of the base class aren't traversed during serialization.  
  
-   <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> fail to serialize a class or structure that implements the <xref:System.Collections.Generic.IEnumerable%601> interface. For example, the following types fail to serialize or deserialize:  
  
  
  
-   <xref:System.Xml.Serialization.XmlSerializer> fails to serialize the following object value, because it doesn't know the exact type of the object to be serialized:  
  
  
  
-   <xref:System.Xml.Serialization.XmlSerializer> fails to serialize or deserialize if the type of the serialized object is <xref:System.Xml.XmlQualifiedName>.  
  
-   All serializers (<xref:System.Runtime.Serialization.DataContractSerializer>, <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>, and <xref:System.Xml.Serialization.XmlSerializer>) fail to generate serialization code for type <xref:System.Xml.Linq.XElement?displayProperty=fullName> or for a type that contains <xref:System.Xml.Linq.XElement>. They display build-time errors instead.  
  
-   The following constructors of the serialization types aren't guaranteed to work as expected:  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=fullName>  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.Runtime.Serialization.DataContractSerializerSettings%29?displayProperty=fullName>  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.String%2CSystem.String%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=fullName>  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.Xml.XmlDictionaryString%2CSystem.Xml.XmlDictionaryString%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=fullName>  
  
    -   <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.%23ctor%28System.Type%2CSystem.Runtime.Serialization.Json.DataContractJsonSerializerSettings%29?displayProperty=fullName>  
  
    -   <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.%23ctor%28System.Type%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=fullName>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.String%29?displayProperty=fullName>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Type%5B%5D%29?displayProperty=fullName>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Xml.Serialization.XmlAttributeOverrides%29?displayProperty=fullName>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Xml.Serialization.XmlRootAttribute%29?displayProperty=fullName>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Xml.Serialization.XmlAttributeOverrides%2CSystem.Type%5B%5D%2CSystem.Xml.Serialization.XmlRootAttribute%2CSystem.String%29?displayProperty=fullName>  
  
-   <xref:System.Xml.Serialization.XmlSerializer> fails to generate code for a type that has methods attributed with any of the following attributes:  
  
    -   <xref:System.Runtime.Serialization.OnSerializingAttribute>  
  
    -   <xref:System.Runtime.Serialization.OnSerializedAttribute>  
  
    -   <xref:System.Runtime.Serialization.OnDeserializingAttribute>  
  
    -   <xref:System.Runtime.Serialization.OnDeserializedAttribute>  
  
-   <xref:System.Xml.Serialization.XmlSerializer> doesn't honor the <xref:System.Xml.Serialization.IXmlSerializable> custom serialization interface. If you have a class that implements this interface, <xref:System.Xml.Serialization.XmlSerializer> considers the type a plain old CLR object (POCO) type and serializes only its public properties.  
  
-   Serializing a plain <xref:System.Exception> object, such as the following, doesn't work well with <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>:  
  
  
  
<a name="VS"></a>   
## Visual Studio differences  
 **Exceptions and debugging**  
  
 When you're running apps compiled by using [!INCLUDE[net_native](../../../includes/net-native-md.md)] in the debugger, first-chance exceptions are enabled for the following exception types:  
  
-   <xref:System.MemberAccessException>  
  
-   <xref:System.TypeAccessException>  
  
 **Building apps**  
  
 Use the x86 build tools that are used by default by Visual Studio. We don't recommend using the AMD64 MSBuild tools, which are found in C:\Program Files (x86)\MSBuild\12.0\bin\amd64; these may create build problems.  
  
 **Profilers**  
  
-   The Visual Studio CPU Profiler and XAML Memory Profiler don't display Just-My-Code correctly.  
  
-   The XAML Memory Profiler doesn't accurately display managed heap data.  
  
-   The CPU Profiler doesn't correctly identify modules, and displays prefixed function names.  
  
 **Unit Test Library projects**  
  
 Enabling [!INCLUDE[net_native](../../../includes/net-native-md.md)] on a Unit Test Library for a Windows Store apps project isn't supported and causes the project to fail to build.  
  
## See Also  
 [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md)   
 [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md)   
 [.NET For Windows Store apps overview](http://msdn.microsoft.com/library/windows/apps/br230302.aspx)   
 [.NET Framework Support for Windows Store Apps and Windows Runtime](../../../docs/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md)