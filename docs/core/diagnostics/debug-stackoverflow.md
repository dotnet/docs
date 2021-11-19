---
title: Debugging StackOverflow errors
description: Learn how to diagnose StackOverflow exceptions
ms.topic: tutorial
ms.date: 12/22/2020
---
# Debug StackOverflow errors

A <xref:System.StackOverflowException> is thrown when the execution stack overflows because it contains too many nested method calls.

For example, suppose you have an app as follows:

````csharp
using System;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            Main(args); // Oops, this recursion won't stop.
        }
    }
}
````

The `Main` method will continuously call itself until there is no more stack space. Once there is no more stack space, execution cannot continue and so it will throw a <xref:System.StackOverflowException>.

````
> dotnet run
Stack overflow.
````

> [!NOTE]
> On .NET 5 and later, the callstack is output to the console.

> [!NOTE]
> This article describes how to debug a stack overflow with lldb. If you are running on Windows, we suggest debugging the app with [Visual Studio](/visualstudio/debugger/what-is-debugging) or [Visual Studio Code](https://code.visualstudio.com/Docs/editor/debugging).

## Example

1. Run the app with it configured to collect a dump on crash

    ````
    > export DOTNET_DbgEnableMiniDump=1
    > dotnet run
    Stack overflow.
    Writing minidump with heap to file /tmp/coredump.6412
    Written 58191872 bytes (14207 pages) to core file
    ````

   [!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

2. Install the SOS extension using [dotnet-sos](dotnet-sos.md)

    ````
    dotnet-sos install
    ````

3. Debug the dump in lldb to see the failing stack

    ````
    lldb --core /temp/coredump.6412
    (lldb) bt
    ...
        frame #261930: 0x00007f59b40900cc
        frame #261931: 0x00007f59b40900cc
        frame #261932: 0x00007f59b40900cc
        frame #261933: 0x00007f59b40900cc
        frame #261934: 0x00007f59b40900cc
        frame #261935: 0x00007f5a2d4a080f libcoreclr.so`CallDescrWorkerInternal at unixasmmacrosamd64.inc:867
        frame #261936: 0x00007f5a2d3cc4c3 libcoreclr.so`MethodDescCallSite::CallTargetWorker(unsigned long const*, unsigned long*, int) at callhelpers.cpp:70
        frame #261937: 0x00007f5a2d3cc468 libcoreclr.so`MethodDescCallSite::CallTargetWorker(this=<unavailable>, pArguments=0x00007ffe8222e7b0, pReturnValue=0x0000000000000000, cbReturnValue=0) at callhelpers.cpp:604
        frame #261938: 0x00007f5a2d4b6182 libcoreclr.so`RunMain(MethodDesc*, short, int*, PtrArray**) [inlined] MethodDescCallSite::Call(this=<unavailable>, pArguments=<unavailable>) at callhelpers.h:468
    ...
    ````

4. The top frame `0x00007f59b40900cc` is repeated several times. Use the [SOS](sos-debugging-extension.md) `ip2md` command to figure out what method is located at the `0x00007f59b40900cc` address

    ````
    (lldb) ip2md 0x00007f59b40900cc
    MethodDesc:   00007f59b413ffa8
    Method Name:          temp.Program.Main(System.String[])
    Class:                00007f59b4181d40
    MethodTable:          00007f59b4190020
    mdToken:              0000000006000001
    Module:               00007f59b413dbf8
    IsJitted:             yes
    Current CodeAddr:     00007f59b40900a0
    Version History:
      ILCodeVersion:      0000000000000000
      ReJIT ID:           0
      IL Addr:            0000000000000000
         CodeAddr:           00007f59b40900a0  (MinOptJitted)
         NativeCodeVersion:  0000000000000000
    Source file:  /temp/Program.cs @ 9
    ````

5. Go look at the indicated method temp.Program.Main(System.String[]) and source "/temp/Program.cs @ 9" to see if you can figure out what you did wrong. If it still wasn't clear you could add logging in that area of the code.

## See Also

* [An introduction to dumps in .NET](dumps.md)
* [Debug Linux dumps](debug-linux-dumps.md)
* [SOS Debugging Extension for .NET](sos-debugging-extension.md)
