---
title: "Migrating Your Windows Store App to .NET Native"
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
ms.workload: 
  - "dotnet"
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
  
-   Don't call the <xref:System.GC.WaitForPendingFinalizers%2A?displayProperty=nameWithType> method from an app's UI thread. This can result in a deadlock on [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
-   Don't rely on static class constructor invocation ordering. In [!INCLUDE[net_native](../../../includes/net-native-md.md)], the invocation order is different from the order on the standard runtime. (Even with the standard runtime, you shouldn't rely on the order of execution of static class constructors.)  
  
-   Infinite looping without making a call (for example, `while(true);`) on any thread may bring the app to a halt. Similarly, large or infinite waits may bring the app to a halt.  
  
-   Certain generic initialization cycles don't throw exceptions in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. For example, the following code throws a <xref:System.TypeLoadException> exception on the standard CLR. In [!INCLUDE[net_native](../../../includes/net-native-md.md)], it doesn't.  
  
     [!code-csharp[ProjectN#8](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/compat1.cs#8)]  
  
-   In some cases, [!INCLUDE[net_native](../../../includes/net-native-md.md)] provides different implementations of .NET Framework class libraries. An object returned from a method will always implement the members of the returned type. However, since its backing implementation is different, you may not be able to cast it to the same set of types as you could on other .NET Framework platforms. For example, in some cases, you may not be able to cast the <xref:System.Collections.Generic.IEnumerable%601> interface object returned by methods such as <xref:System.Reflection.TypeInfo.DeclaredMembers%2A?displayProperty=nameWithType> or <xref:System.Reflection.TypeInfo.DeclaredProperties%2A?displayProperty=nameWithType> to `T[]`.  
  
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
  
-   Some constructs like <xref:System.Type.MakeGenericType%2A?displayProperty=nameWithType> and <xref:System.Reflection.MethodInfo.MakeGenericMethod%2A?displayProperty=nameWithType> can't be determined statically.  
  
-   Because the compiler can't determine the instantiations, a generic type that you want to reflect on has to be specified by runtime directives. This isn't just because all code must be included, but because reflection on generic types can form an infinite cycle (for example, when a generic method is invoked on a generic type).  
  
> [!NOTE]
>  Runtime directives are defined in a runtime directives (.rd.xml) file. For general information about using this file, see [Getting Started](../../../docs/framework/net-native/getting-started-with-net-native.md). For information about the runtime directives, see [Runtime Directives (rd.xml) Configuration File Reference](../../../docs/framework/net-native/runtime-directives-rd-xml-configuration-file-reference.md).  
  
 [!INCLUDE[net_native](../../../includes/net-native-md.md)] also includes profiling tools that help the developer determine which types outside the default set should support reflection.  
  
<a name="Reflection"></a>   
## Other reflection-related differences  
 There are a number of other individual reflection-related differences in behavior between the .NET for Windows Store apps and [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 In [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
-   Private reflection over types and members in the .NET Framework class library is not supported. You can, however, reflect over your own private types and members, as well as types and members in third-party libraries.  
  
-   The <xref:System.Reflection.ParameterInfo.HasDefaultValue%2A?displayProperty=nameWithType> property correctly returns `false` for a <xref:System.Reflection.ParameterInfo> object that represents a return value. In the .NET for Windows Store apps, it returns `true`. Intermediate language (IL) doesn’t support this directly, and interpretation is left to the language.  
  
-   Public members on the <xref:System.RuntimeFieldHandle> and <xref:System.RuntimeMethodHandle> structures aren't supported. These types are supported only for LINQ, expression trees, and static array initialization.  
  
-   <xref:System.Reflection.RuntimeReflectionExtensions.GetRuntimeProperties%2A?displayProperty=nameWithType> and <xref:System.Reflection.RuntimeReflectionExtensions.GetRuntimeEvents%2A?displayProperty=nameWithType> include hidden members in base classes and thus may be overridden without explicit overrides. This is also true of other [RuntimeReflectionExtensions.GetRuntime*](http://msdn.microsoft.com/library/system.reflection.runtimereflectionextensions_methods.aspx) methods.  
  
-   <xref:System.Type.MakeArrayType%2A?displayProperty=nameWithType> and <xref:System.Type.MakeByRefType%2A?displayProperty=nameWithType> don't fail when you try to create certain combinations (for example, an array of byrefs).  
  
-   You can't use reflection to invoke members that have pointer parameters.  
  
-   You can't use reflection to get or set a pointer field.  
  
-   When the argument count is wrong and the type of one of the arguments is incorrect, [!INCLUDE[net_native](../../../includes/net-native-md.md)] throws an <xref:System.ArgumentException> instead of a <xref:System.Reflection.TargetParameterCountException>.  
  
-   Binary serialization of exceptions is generally not supported. As a result, non-serializable objects can be added to the <xref:System.Exception.Data%2A?displayProperty=nameWithType> dictionary.  
  
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
  
-   If you override the <xref:System.ValueType.Equals%2A?displayProperty=nameWithType> and <xref:System.ValueType.GetHashCode%2A?displayProperty=nameWithType> methods for a value type, don't call the base class implementations. In .NET for Windows Store apps, these methods rely on reflection. At compile time, [!INCLUDE[net_native](../../../includes/net-native-md.md)] generates an implementation that doesn't rely on runtime reflection. This means that if you don't override these two methods, they will work as expected, because [!INCLUDE[net_native](../../../includes/net-native-md.md)] generates the implementation at compile time. However, overriding these methods but calling the base class implementation results in an exception.  
  
-   Value types larger than one megabyte aren't supported.  
  
-   Value types can't have a default constructor in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. (C# and Visual Basic prohibit default constructors on value types. However, these can be created in IL.)  
  
 **Arrays**  
  
-   Arrays with a lower bound other than zero aren't supported. Typically, these arrays are created by calling the <xref:System.Array.CreateInstance%28System.Type%2CSystem.Int32%5B%5D%2CSystem.Int32%5B%5D%29?displayProperty=nameWithType> overload.  
  
-   Dynamic creation of multidimensional arrays isn't supported. Such arrays are typically created by calling an overload of the <xref:System.Array.CreateInstance%2A?displayProperty=nameWithType> method that includes a `lengths` parameter, or by calling the <xref:System.Type.MakeArrayType%28System.Int32%29?displayProperty=nameWithType> method.  
  
-   Multidimensional arrays that have four or more dimensions aren't supported; that is, their <xref:System.Array.Rank%2A?displayProperty=nameWithType> property value is four or greater. Use [jagged arrays](~/docs/csharp/programming-guide/arrays/jagged-arrays.md) (an array of arrays) instead. For example, `array[x,y,z]` is invalid, but `array[x][y][z]` isn't.  
  
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
  
 The use of localized resources with the <xref:System.Diagnostics.Tracing.EventSource> class isn't supported. The <xref:System.Diagnostics.Tracing.EventSourceAttribute.LocalizationResources%2A?displayProperty=nameWithType> property doesn't define localized resources.  
  
 **Delegates**  
  
 `Delegate.BeginInvoke` and `Delegate.EndInvoke` aren't supported.  
  
 **Async**  
  
 Threading logic in overloads of Task IAsync isn't supported.  
  
 **Miscellaneous APIs**  
  
-   The <xref:System.Reflection.TypeInfo.GUID%2A?displayProperty=nameWithType> property throws a <xref:System.PlatformNotSupportedException> exception if a <xref:System.Runtime.InteropServices.GuidAttribute> attribute isn't applied to the type. The GUID is used primarily for COM support.  
  
-   The <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> method correctly parses strings that contain short dates in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. However, it doesn't maintain compatibility with the changes in date and time parsing described in the Microsoft Knowledge Base articles [KB2803771](http://support.microsoft.com/kb/2803771) and [KB2803755](http://support.microsoft.com/kb/2803755).  
  
-   <xref:System.Numerics.BigInteger.ToString%2A?displayProperty=nameWithType> `("E")` is correctly rounded in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. In some versions of the CLR, the result string is truncated instead of rounded.  
  
<a name="HttpClient"></a>   
### HttpClient differences  
 In [!INCLUDE[net_native](../../../includes/net-native-md.md)], the <xref:System.Net.Http.HttpClientHandler> class internally uses WinINet (through the [HttpBaseProtocolFilter](http://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx) class) instead of the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes used in the standard .NET for Windows Store apps.  WinINet doesn't support all the configuration options that the <xref:System.Net.Http.HttpClientHandler> class supports.  As a result:  
  
-   Some of the capability properties on <xref:System.Net.Http.HttpClientHandler> return `false` on [!INCLUDE[net_native](../../../includes/net-native-md.md)], whereas they return `true` in the standard .NET for Windows Store apps.  
  
-   Some of the configuration property `get` accessors always return a fixed value on [!INCLUDE[net_native](../../../includes/net-native-md.md)] that is different than the default configurable value in .NET for Windows Store apps.  
  
 Some additional behavior differences are covered in the following subsections.  
  
 **Proxy**  
  
 The [HttpBaseProtocolFilter](http://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx) class doesn’t support configuring or overriding the proxy on a per-request basis.  This means that all requests on [!INCLUDE[net_native](../../../includes/net-native-md.md)] use the system-configured proxy server or no proxy server, depending on the value of the <xref:System.Net.Http.HttpClientHandler.UseProxy%2A?displayProperty=nameWithType> property.  In .NET for Windows Store apps, the proxy server is defined by the <xref:System.Net.Http.HttpClientHandler.Proxy%2A?displayProperty=nameWithType> property.  On [!INCLUDE[net_native](../../../includes/net-native-md.md)], setting the <xref:System.Net.Http.HttpClientHandler.Proxy%2A?displayProperty=nameWithType> to a value other than `null` throws a <xref:System.PlatformNotSupportedException> exception.  The <xref:System.Net.Http.HttpClientHandler.SupportsProxy%2A?displayProperty=nameWithType> property returns `false` on [!INCLUDE[net_native](../../../includes/net-native-md.md)], whereas it returns `true` in the standard .NET Framework for Windows Store apps.  
  
 **Automatic redirection**  
  
 The [HttpBaseProtocolFilter](http://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx) class doesn't allow the maximum number of automatic redirections to be configured.  The value of the <xref:System.Net.Http.HttpClientHandler.MaxAutomaticRedirections%2A?displayProperty=nameWithType> property is 50 by default in the standard .NET for Windows Store apps and can be modified. On [!INCLUDE[net_native](../../../includes/net-native-md.md)], the value of this property is 10, and trying to modify it throws a <xref:System.PlatformNotSupportedException> exception.  The <xref:System.Net.Http.HttpClientHandler.SupportsRedirectConfiguration%2A?displayProperty=nameWithType> property returns `false` on [!INCLUDE[net_native](../../../includes/net-native-md.md)], whereas it returns `true` in .NET for Windows Store apps.  
  
 **Automatic decompression**  
  
 .NET for Windows Store apps allows you to set the <xref:System.Net.Http.HttpClientHandler.AutomaticDecompression%2A?displayProperty=nameWithType> property to <xref:System.Net.DecompressionMethods.Deflate>, <xref:System.Net.DecompressionMethods.GZip>, both <xref:System.Net.DecompressionMethods.Deflate> and <xref:System.Net.DecompressionMethods.GZip>, or <xref:System.Net.DecompressionMethods.None>.  [!INCLUDE[net_native](../../../includes/net-native-md.md)] only supports <xref:System.Net.DecompressionMethods.Deflate> together with <xref:System.Net.DecompressionMethods.GZip>, or <xref:System.Net.DecompressionMethods.None>.  Trying to set the <xref:System.Net.Http.HttpClientHandler.AutomaticDecompression%2A> property to either <xref:System.Net.DecompressionMethods.Deflate> or <xref:System.Net.DecompressionMethods.GZip> alone silently sets it to both <xref:System.Net.DecompressionMethods.Deflate> and <xref:System.Net.DecompressionMethods.GZip>.  
  
 **Cookies**  
  
 Cookie handling is performed simultaneously by <xref:System.Net.Http.HttpClient> and WinINet.  Cookies from the <xref:System.Net.CookieContainer> are combined with cookies in the WinINet cookie cache.  Removing a cookie from <xref:System.Net.CookieContainer> prevents <xref:System.Net.Http.HttpClient> from sending the cookie, but if the cookie was already seen by WinINet, and cookies weren't deleted by the user, WinINet sends it.  It isn't possible to programmatically remove a cookie from WinINet by using the <xref:System.Net.Http.HttpClient>, <xref:System.Net.Http.HttpClientHandler>, or <xref:System.Net.CookieContainer> API.  Setting the <xref:System.Net.Http.HttpClientHandler.UseCookies%2A?displayProperty=nameWithType> property to `false` causes only <xref:System.Net.Http.HttpClient> to stop sending cookies; WinINet might still include its cookies in the request.  
  
 **Credentials**  
  
 In .NET for Windows Store apps, the <xref:System.Net.Http.HttpClientHandler.UseDefaultCredentials%2A?displayProperty=nameWithType> and <xref:System.Net.Http.HttpClientHandler.Credentials%2A?displayProperty=nameWithType> properties work independently.  Additionally, the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property accepts any object that implements the <xref:System.Net.ICredentials> interface.  In [!INCLUDE[net_native](../../../includes/net-native-md.md)], setting the <xref:System.Net.Http.HttpClientHandler.UseDefaultCredentials%2A> property to `true` causes the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property to become `null`.  In addition, the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property can be set only to `null`, <xref:System.Net.CredentialCache.DefaultCredentials%2A>, or an object of type <xref:System.Net.NetworkCredential>.  Assigning any other <xref:System.Net.ICredentials> object, the most popular of which is <xref:System.Net.CredentialCache>, to the <xref:System.Net.Http.HttpClientHandler.Credentials%2A> property throws a <xref:System.PlatformNotSupportedException>.  
  
 **Other unsupported or unconfigurable features**  
  
 In [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
-   The value of the <xref:System.Net.Http.HttpClientHandler.ClientCertificateOptions%2A?displayProperty=nameWithType> property is always <xref:System.Net.Http.ClientCertificateOption.Automatic>.  In .NET for Windows Store apps, the default is <xref:System.Net.Http.ClientCertificateOption.Manual>.  
  
-   The <xref:System.Net.Http.HttpClientHandler.MaxRequestContentBufferSize%2A?displayProperty=nameWithType> property isn't configurable.  
  
-   The <xref:System.Net.Http.HttpClientHandler.PreAuthenticate%2A?displayProperty=nameWithType> property is always `true`.  In .NET for Windows Store apps, the default is `false`.  
  
-   The `SetCookie2` header in responses is ignored as obsolete.  
  
<a name="Interop"></a>   
### Interop differences  
 **Deprecated APIs**  
  
 A number of infrequently used APIs for interoperability with managed code have been deprecated. When used with [!INCLUDE[net_native](../../../includes/net-native-md.md)], these APIs may throw a <xref:System.NotImplementedException> or <xref:System.PlatformNotSupportedException> exception, or result in a compiler error. In .NET for Windows Store apps, these APIs are marked as obsolete, although calling them generates a compiler warning rather than a compiler error.  
  
 Deprecated APIs for `VARIANT` marshaling:  
  
||  
|-|  
|<xref:System.Runtime.InteropServices.BStrWrapper?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.CurrencyWrapper?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.DispatchWrapper?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.ErrorWrapper?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.UnknownWrapper?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.VariantWrapper?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.UnmanagedType.IDispatch?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.UnmanagedType.SafeArray?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.VarEnum?displayProperty=nameWithType>|  
  
 <xref:System.Runtime.InteropServices.UnmanagedType.Struct?displayProperty=nameWithType> is supported, but it throws an exception in some scenarios, such as when it is used with [IDispatch](http://msdn.microsoft.com/library/windows/apps/ms221608.aspx) or byref variants.  
  
 Deprecated APIs for [IDispatch](http://msdn.microsoft.com/library/windows/apps/ms221608.aspx) support:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.ClassInterfaceType?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.ClassInterfaceType.AutoDispatch>|  
|<xref:System.Runtime.InteropServices.ClassInterfaceType?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.ClassInterfaceType.AutoDual>|  
|<xref:System.Runtime.InteropServices.ComDefaultInterfaceAttribute?displayProperty=nameWithType>|Attribute isn't supported|  
  
 Deprecated APIs for classic COM events:  
  
||  
|-|  
|<xref:System.Runtime.InteropServices.ComEventsHelper?displayProperty=nameWithType>|  
|<xref:System.Runtime.InteropServices.ComSourceInterfacesAttribute>|  
  
 Deprecated APIs in the <xref:System.Runtime.InteropServices.ICustomQueryInterface?displayProperty=nameWithType> interface, which isn't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.ICustomQueryInterface?displayProperty=nameWithType>|All members.|  
|<xref:System.Runtime.InteropServices.CustomQueryInterfaceMode?displayProperty=nameWithType>|All members.|  
|<xref:System.Runtime.InteropServices.CustomQueryInterfaceResult?displayProperty=nameWithType>|All members.|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.GetComInterfaceForObject%28System.Object%2CSystem.Type%2CSystem.Runtime.InteropServices.CustomQueryInterfaceMode%29?displayProperty=nameWithType>|  
  
 Other unsupported interop features:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.ICustomAdapter?displayProperty=nameWithType>|All members.|  
|<xref:System.Runtime.InteropServices.SafeBuffer?displayProperty=nameWithType>|All members.|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.UnmanagedType.Currency>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.UnmanagedType.VBByRefStr>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.UnmanagedType.AnsiBStr>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.UnmanagedType.AsAny>|  
|<xref:System.Runtime.InteropServices.UnmanagedType?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.UnmanagedType.CustomMarshaler>|  
  
 Rarely used marshalling APIs:  
  
|Type|Member|  
|----------|------------|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ReadByte%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ReadInt16%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ReadInt32%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ReadInt64%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.ReadIntPtr%28System.Object%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.WriteByte%28System.Object%2CSystem.Int32%2CSystem.Byte%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.WriteInt16%28System.Object%2CSystem.Int32%2CSystem.Int16%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.WriteInt32%28System.Object%2CSystem.Int32%2CSystem.Int32%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.WriteInt64%28System.Object%2CSystem.Int32%2CSystem.Int64%29>|  
|<xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType>|<xref:System.Runtime.InteropServices.Marshal.WriteIntPtr%28System.Object%2CSystem.Int32%2CSystem.IntPtr%29>|  
  
 **Platform invoke and COM interop compatibility**  
  
 Most platform invoke and COM interop scenarios are still supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. In particular, all interoperability with Windows Runtime (WinRT) APIs and all marshaling required for the Windows Runtime is supported. This includes marshaling support for:  
  
-   Arrays (including <xref:System.Runtime.InteropServices.UnmanagedType.ByValArray?displayProperty=nameWithType>)  
  
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
  
-   Implementing the <xref:System.Runtime.InteropServices.ICustomQueryInterface?displayProperty=nameWithType> interface on a managed type  
  
-   Implementing the [IDispatch](http://msdn.microsoft.com/library/windows/apps/ms221608.aspx) interface on a managed type through the <xref:System.Runtime.InteropServices.ComDefaultInterfaceAttribute?displayProperty=nameWithType> attribute. However, note that you can't call COM objects through `IDispatch`, and your managed object can't implement `IDispatch`.  
  
 Using reflection to invoke a platform invoke method isn't supported. You can work around this limitation by wrapping the method call in another method and using reflection to call the wrapper instead.  
  
<a name="APIs"></a>   
### Other differences from .NET APIs for Windows Store apps  
 This section lists the remaining APIs that aren't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. The largest set of the unsupported APIs are Windows Communication Foundation (WCF) APIs.  
  
 **DataAnnotations (System.ComponentModel.DataAnnotations)**  
  
 The types in the <xref:System.ComponentModel.DataAnnotations> and <xref:System.ComponentModel.DataAnnotations.Schema> namespaces aren't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. These include the following types that are present in the .NET for Windows Store apps for Windows 8:  
  
||  
|-|  
|<xref:System.ComponentModel.DataAnnotations.AssociationAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.ConcurrencyCheckAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.CustomValidationAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.DataType?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.DataTypeAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.DisplayAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.DisplayColumnAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.DisplayFormatAttribute>|  
|<xref:System.ComponentModel.DataAnnotations.EditableAttribute>|  
|<xref:System.ComponentModel.DataAnnotations.EnumDataTypeAttribute>|  
|<xref:System.ComponentModel.DataAnnotations.FilterUIHintAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.KeyAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.RangeAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.RequiredAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.StringLengthAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.TimestampAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.UIHintAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationContext?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationException?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.ValidationResult?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.Validator?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute?displayProperty=nameWithType>|  
|<xref:System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption?displayProperty=nameWithType>|  
  
 **Visual Basic**  
  
 Visual Basic isn't currently supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. The following types in the <xref:Microsoft.VisualBasic> and <xref:Microsoft.VisualBasic.CompilerServices> namespaces aren't available in [!INCLUDE[net_native](../../../includes/net-native-md.md)]:  
  
||  
|-|  
|<xref:Microsoft.VisualBasic.CallType?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.Constants?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.HideModuleNameAttribute?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.Strings?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.Conversions?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.DesignerGeneratedAttribute?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.IncompleteInitialization?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.NewLateBinding?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.ObjectFlowControl?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.ObjectFlowControl.ForLoopControl?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.Operators?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.OptionCompareAttribute?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.OptionTextAttribute?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.ProjectData?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag?displayProperty=nameWithType>|  
|<xref:Microsoft.VisualBasic.CompilerServices.Utils?displayProperty=nameWithType>|  
  
 **Reflection Context (System.Reflection.Context namespace)**  
  
 The <xref:System.Reflection.Context.CustomReflectionContext?displayProperty=nameWithType> class isn't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 **RTC (System.Net.Http.Rtc)**  
  
 The <xref:System.Net.Http.RtcRequestFactory?displayProperty=nameWithType> class isn't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)].  
  
 **Windows Communication Foundation (WCF) (System.ServiceModel.\*)**  
  
 The types in the [System.ServiceModel.* namespaces](http://msdn.microsoft.com/library/gg145010.aspx) aren't supported in [!INCLUDE[net_native](../../../includes/net-native-md.md)]. These includes the following types:  
  
||  
|-|  
|<xref:System.ServiceModel.ActionNotSupportedException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.BasicHttpBinding?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.BasicHttpMessageCredentialType?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.BasicHttpSecurity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.BasicHttpSecurityMode?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.CallbackBehaviorAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ChannelFactory?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ChannelFactory%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ClientBase%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ClientBase%601.BeginOperationDelegate?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ClientBase%601.ChannelBase%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ClientBase%601.EndOperationDelegate?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ClientBase%601.InvokeAsyncCompletedEventArgs?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.CommunicationException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.CommunicationObjectAbortedException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.CommunicationObjectFaultedException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.CommunicationState?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.DataContractFormatAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.DnsEndpointIdentity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.DuplexChannelFactory%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.DuplexClientBase%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.EndpointAddress?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.EndpointAddressBuilder?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.EndpointIdentity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.EndpointNotFoundException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.EnvelopeVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ExceptionDetail?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.FaultCode?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.FaultContractAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.FaultException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.FaultException%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.FaultReason?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.FaultReasonText?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.HttpBindingBase?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.HttpClientCredentialType?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.HttpTransportSecurity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.IClientChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ICommunicationObject?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.IContextChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.IDefaultCommunicationTimeouts?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.IExtensibleObject%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.IExtension%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.IExtensionCollection%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.InstanceContext?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.InvalidMessageContractException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageBodyMemberAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageContractAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageContractMemberAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageCredentialType?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageHeader%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageHeaderException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageParameterAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageSecurityOverTcp?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.MessageSecurityVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.NetHttpBinding?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.NetHttpMessageEncoding?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.NetTcpBinding?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.NetTcpSecurity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.OperationContext?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.OperationContextScope?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.OperationContractAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.OperationFormatStyle?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ProtocolException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.QuotaExceededException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.SecurityMode?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ServerTooBusyException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ServiceActivationException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ServiceContractAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.ServiceKnownTypeAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.SpnEndpointIdentity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.TcpClientCredentialType?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.TcpTransportSecurity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.TransferMode?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.UnknownMessageReceivedEventArgs?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.UpnEndpointIdentity?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.XmlSerializerFormatAttribute?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.AddressHeader?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.AddressHeaderCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.AddressingVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.ChannelManagerBase?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.ChannelParameterCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.CommunicationObject?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.CompressionFormat?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.ConnectionOrientedTransportBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.CustomBinding?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.FaultConverter?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.HttpRequestMessageProperty?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.HttpResponseMessageProperty?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.HttpsTransportBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.HttpTransportBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IChannelFactory?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IChannelFactory%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IDuplexChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IDuplexSession?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IDuplexSessionChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IHttpCookieContainerManager?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IInputChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IInputSession?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IInputSessionChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IMessageProperty?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IOutputChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IOutputSession?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IOutputSessionChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IRequestChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.IRequestSessionChannel?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.ISession?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.ISessionChannel%601?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.LocalClientSecuritySettings?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.Message?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageBuffer?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageEncoder?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageEncoderFactory?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageEncodingBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageFault?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageHeader?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageHeaderInfo?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageHeaders?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageProperties?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageState?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.MessageVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.RequestContext?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.SecurityBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.SecurityHeaderLayout?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.SslStreamSecurityBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.TcpConnectionPoolSettings?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.TcpTransportBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.TransportBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.TransportSecurityBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.WebSocketTransportSettings?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.WebSocketTransportUsage?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Channels.WindowsStreamSecurityBindingElement?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.ClientCredentials?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.ContractDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.FaultDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.FaultDescriptionCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.IContractBehavior?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.IEndpointBehavior?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.IOperationBehavior?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessageBodyDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessageDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessageDescriptionCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessageDirection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessageHeaderDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessageHeaderDescriptionCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessagePartDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessagePartDescriptionCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessagePropertyDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.MessagePropertyDescriptionCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.OperationDescription?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.OperationDescriptionCollection?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Description.ServiceEndpoint?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.ClientOperation?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.ClientRuntime?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.DispatchOperation?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.DispatchRuntime?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.EndpointDispatcher?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageFormatter?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.IClientMessageInspector?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.IClientOperationSelector?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Dispatcher.IParameterInspector?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.BasicSecurityProfileVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.HttpDigestClientCredential?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.MessageSecurityException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.SecureConversationVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.SecurityAccessDeniedException?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.SecurityPolicyVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.SecurityVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.TrustVersion?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.UserNamePasswordClientCredential?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.WindowsClientCredential?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.Tokens.SecurityTokenParameters?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.Tokens.SupportingTokenParameters?displayProperty=nameWithType>|  
|<xref:System.ServiceModel.Security.Tokens.UserNameSecurityTokenParameters?displayProperty=nameWithType>|  
  
### Differences in serializers  
 The following differences concern serialization and deserialization with the <xref:System.Runtime.Serialization.DataContractSerializer>, <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>, and <xref:System.Xml.Serialization.XmlSerializer> classes:  
  
-   In [!INCLUDE[net_native](../../../includes/net-native-md.md)], <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> fail to serialize or deserialize a derived class that has a base class member whose type isn't a root serialization type. For example, in the following code, trying to serialize or deserialize `Y` results in an error:  
  
     [!code-csharp[ProjectN#10](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn/cs/compat3.cs#10)]  
  
     Type `InnerType` isn't known to the serializer, because the members of the base class aren't traversed during serialization.  
  
-   <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> fail to serialize a class or structure that implements the <xref:System.Collections.Generic.IEnumerable%601> interface. For example, the following types fail to serialize or deserialize:  
  
  
  
-   <xref:System.Xml.Serialization.XmlSerializer> fails to serialize the following object value, because it doesn't know the exact type of the object to be serialized:  
  
  
  
-   <xref:System.Xml.Serialization.XmlSerializer> fails to serialize or deserialize if the type of the serialized object is <xref:System.Xml.XmlQualifiedName>.  
  
-   All serializers (<xref:System.Runtime.Serialization.DataContractSerializer>, <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>, and <xref:System.Xml.Serialization.XmlSerializer>) fail to generate serialization code for type <xref:System.Xml.Linq.XElement?displayProperty=nameWithType> or for a type that contains <xref:System.Xml.Linq.XElement>. They display build-time errors instead.  
  
-   The following constructors of the serialization types aren't guaranteed to work as expected:  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=nameWithType>  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.Runtime.Serialization.DataContractSerializerSettings%29?displayProperty=nameWithType>  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.String%2CSystem.String%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=nameWithType>  
  
    -   <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.Xml.XmlDictionaryString%2CSystem.Xml.XmlDictionaryString%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=nameWithType>  
  
    -   <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.%23ctor%28System.Type%2CSystem.Runtime.Serialization.Json.DataContractJsonSerializerSettings%29?displayProperty=nameWithType>  
  
    -   <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.%23ctor%28System.Type%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29?displayProperty=nameWithType>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.String%29?displayProperty=nameWithType>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Type%5B%5D%29?displayProperty=nameWithType>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Xml.Serialization.XmlAttributeOverrides%29?displayProperty=nameWithType>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Xml.Serialization.XmlRootAttribute%29?displayProperty=nameWithType>  
  
    -   <xref:System.Xml.Serialization.XmlSerializer.%23ctor%28System.Type%2CSystem.Xml.Serialization.XmlAttributeOverrides%2CSystem.Type%5B%5D%2CSystem.Xml.Serialization.XmlRootAttribute%2CSystem.String%29?displayProperty=nameWithType>  
  
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
