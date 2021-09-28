---
title: jitCompilationStart managed debugging assistant (MDA)
description: The jitCompilationStart managed debugging assistant (MDA) reports when the just-in-time (JIT) compiler begins compiling a .NET function.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "JIT compilation"
  - "MDAs (managed debugging assistants), JIT compilation"
  - "JitCompilationStart MDA"
  - "managed debugging assistants (MDAs), JIT compilation"
ms.assetid: 5ffd2857-d0ba-4342-9824-9ffe04ec135d
---
# jitCompilationStart MDA

The `jitCompilationStart` managed debugging assistant (MDA) is activated to report when the just-in-time (JIT) compiler starts to compile a function.  
  
## Symptoms  

 The working set size increases for a program that's already in native image format, because mscorjit.dll is loaded into the process.  
  
## Cause  

Not all the assemblies the program depends on have been generated into native format, or an assembly is not registered correctly.  

## Resolution  

 Enabling this MDA allows you to identify which function is being JIT-compiled. Make sure that the assembly that contains the function is generated to native format and properly registered.
  
## Effect on the runtime  

 This MDA logs a message just before a method is JIT-compiled, so enabling this MDA has significant impact on performance. If a method is inline, this MDA will not generate a separate message.  
  
## Output  

 The following code sample shows sample output. In this case, the output shows that, in assembly Test, the method "m" on class "ns2.CO" was JIT-compiled.  
  
```output
method name="Test!ns2.C0::m"  
```  
  
## Configuration  

 The following configuration file shows a variety of filters that can be employed to filter out which methods are reported when they are first JIT-compiled. You can specify that all methods be reported by setting the value of the name attribute to \*.  
  
```xml  
<mdaConfig>  
  <assistants>  
    <jitCompilationStart>  
      <methods>  
        <match name="C0::m" />  
        <match name="MyMethod" />  
        <match name="C2::*" />  
        <match name="ns0::*" />  
        <match name="ns1.C0::*" />  
        <match name="ns2.C0::m" />  
        <match name="ns2.C0+N0::m" />  
      </methods>  
    </jitCompilationStart >  
  </assistants>  
</mdaConfig>  
```  
  
## Example  

 The following code sample is intended to be used with the preceding configuration file.  
  
```csharp
using System;  
using System.Reflection;  
using System.Runtime.CompilerServices;  
using System.Runtime.InteropServices;  
  
public class Entry  
{  
    public static void Main(string[] args)  
    {  
        C0.m();  
        C1.MyMethod();  
        C2.m();  
  
        ns0.C0.m();  
        ns0.C0.N0.m();  
        ns0.C1.m();  
  
        ns1.C0.m();  
        ns1.C0.N0.m();  
  
        ns2.C0.m();  
        ns2.C0.N0.m();  
    }  
}  
  
public class C0  
{  
    [MethodImpl(MethodImplOptions.NoInlining)]  
    public static void m() { }  
}  
  
public class C1  
{  
    [MethodImpl(MethodImplOptions.NoInlining)]  
    public static void MyMethod() { }  
}  
  
public class C2  
{  
    [MethodImpl(MethodImplOptions.NoInlining)]  
    public static void m() { }  
}  
  
namespace ns0  
{  
    public class C0  
    {  
        [MethodImpl(MethodImplOptions.NoInlining)]  
        public static void m() { }  
  
        public class N0  
        {  
            [MethodImpl(MethodImplOptions.NoInlining)]  
            public static void m() { }  
        }  
    }  
  
    public class C1  
    {  
        [MethodImpl(MethodImplOptions.NoInlining)]  
        public static void m() { }  
    }  
}  
  
namespace ns1  
{  
    public class C0  
    {  
        [MethodImpl(MethodImplOptions.NoInlining)]  
        public static void m() { }  
        public class N0  
        {  
            [MethodImpl(MethodImplOptions.NoInlining)]  
            public static void m() { }  
        }  
    }  
}  
  
namespace ns2  
{  
    public class C0  
    {  
        [MethodImpl(MethodImplOptions.NoInlining)]  
        public static void m() { }  
  
        public class N0  
        {  
            [MethodImpl(MethodImplOptions.NoInlining)]  
            public static void m() { }  
        }  
    }  
}  
```  
  
## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshaling.md)
