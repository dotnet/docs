---
title: "SOS Debugging Extension for .NET"
description: Learn about the SOS debugging extension for .NET, which provides information about the internal CLR environment.
ms.date: "12/21/2020"
ms.topic: reference
helpviewer_keywords:
  - "debugging extensions"
  - "SOS debugging extensions"
  - "SOS.dll"
---

# SOS debugging extension

The SOS Debugging Extension lets you view information about code that is running inside the .NET Core runtime, both on live processes and dumps. The extension is preinstalled with [dotnet-dump](dotnet-dump.md) and [Windbg/dbg](/windows-hardware/drivers/debugger/debugger-download-tools), and can be [downloaded](dotnet-sos.md) for use with LLDB.  The SOS Debugging Extension is useful for collecting information about the managed heap, looking for heap corruptions, displaying internal data types used by the runtime, and viewing information about all managed code running inside the runtime.

## Syntax

### Windows

`![command] [options]`

### Linux and macOS

`sos [command] [options]`

Many of the commands have aliases or shortcuts under lldb:

`clrstack [options]`

## Commands

The following table of commands is also available under **Help** or **soshelp**.  Individual command help is available using `soshelp <command>`.

|Command|Description|
|-------------|-----------------|
|**bpmd** [**-nofuturemodule**] [\<*module name*> \<*method name*>] [**-md** <`MethodDesc`>] **-list** **-clear** \<*pending breakpoint number*> **-clearall**|Creates a breakpoint at the specified method in the specified module.<br /><br /> If the specified module and method have not been loaded, this command waits for a notification that the module was loaded and just-in-time (JIT) compiled before creating a breakpoint.<br /><br /> You can manage the list of pending breakpoints by using the **-list**, **-clear**, and **-clearall** options:<br /><br /> The **-list** option generates a list of all the pending breakpoints. If a pending breakpoint has a non-zero module ID, that breakpoint is specific to a function in that particular loaded module. If the pending breakpoint has a zero module ID, that breakpoint applies to modules that have not yet been loaded.<br /><br /> Use the **-clear** or **-clearall** option to remove pending breakpoints from the list.|
|**CLRStack** [**-a**] [**-l**] [**-p**] [**-n**] [**-f**] [**-r**] [**-all**]|Provides a stack trace of managed code only.<br /><br /> The **-p** option shows arguments to the managed function.<br /><br /> The **-l** option shows information on local variables in a frame. The SOS Debugging Extension cannot retrieve local names, so the output for local names is in the format \<*local address*> **=** \<*value*>.<br /><br /> The **-a** option is a shortcut for **-l** and **-p** combined.<br /><br /> The **-n** option disables the display of source file names and line numbers. If the debugger has the option SYMOPT_LOAD_LINES specified, SOS will look up the symbols for every managed frame and if successful will display the corresponding source file name and line number. The **-n** (No line numbers) parameter can be specified to disable this behavior.<br /><br />The **-f** option (full mode) displays the native frames intermixing them with the managed frames and the assembly name and function offset for the managed frames.  This option does not display native frames when used with `dotnet-dump`.<br /><br />The **-r** option dumps the registers for each stack frame.<br /><br />The **-all** option dumps all the managed threads' stacks.|
|**COMState**|Lists the COM apartment model for each thread and a `Context` pointer, if available. This command is only supported on Windows.|
|**DumpArray** [**-start** \<*startIndex*>] [**-length** \<*length*>] [**-details**] [**-nofields**] \<*array object address*><br /><br /> -or-<br /><br /> **DA** [**-start** \<*startIndex*>] [**-length** \<*length*>] [**-detail**] [**-nofields**] *array object address*>|Examines elements of an array object.<br /><br /> The **-start** option specifies the starting index at which to display elements.<br /><br /> The **-length** option specifies how many elements to show.<br /><br /> The **-details** option displays details of the element using the **DumpObj** and **DumpVC** formats.<br /><br /> The **-nofields** option prevents arrays from displaying. This option is available only when the **-detail** option is specified.|
|**DumpAsync** (**dumpasync**) [**-mt** \<*MethodTable address*>] [**-type** \<*partial type name*>] [**-waiting**] [**-roots**]|DumpAsync traverses the garbage collected heap, looking for objects representing async state machines as created when an async method's state is transferred to the heap.  This command recognizes async state machines defined as `async void`, `async Task`, `async Task<T>`, `async ValueTask`, and `async ValueTask<T>`.<br /><br />The output includes a block of details for each async state machine object found. These details include:<br />- a line for the type of the async state machine object, including its MethodTable address, its object address, its size, and its type name.<br />- a line for the state machine type name as contained in the object.<br />- a listing of each field on the state machine.<br />- a line for a continuation from this state machine object, if one or more has been registered.<br />- discovered GC roots for this async state machine object.<br />|
|**DumpAssembly** \<*assembly address*>|Displays information about an assembly.<br /><br /> The **DumpAssembly** command lists multiple modules, if they exist.<br /><br /> You can get an assembly address by using the **DumpDomain** command.|
|**DumpClass** \<*EEClass address*>|Displays information about the `EEClass` structure associated with a type.<br /><br /> The **DumpClass** command displays static field values but does not display nonstatic field values.<br /><br /> Use the **DumpMT**, **DumpObj**, **Name2EE**, or **Token2EE** command to get an `EEClass` structure address.|
|**DumpDomain** [\<*domain address*>]|Enumerates each <xref:System.Reflection.Assembly> object that is loaded within the specified <xref:System.AppDomain> object address.  When called with no parameters, the **DumpDomain** command lists all <xref:System.AppDomain> objects in a process. Since .NET Core only has one <xref:System.AppDomain>, **DumpDomain** will only return one object.|
|**DumpHeap** [**-stat**] [**-strings**] [**-short**] [**-min** \<*size*>] [**-max** \<*size*>] [**-thinlock**] [**-startAtLowerBound**] [**-mt** \<*MethodTable address*>] [**-type** \<*partial type name*>][*start* [*end*]]|Displays information about the garbage-collected heap and collection statistics about objects.<br /><br /> The **DumpHeap** command displays a warning if it detects excessive fragmentation in the garbage collector heap.<br /><br /> The **-stat** option restricts the output to the statistical type summary.<br /><br /> The **-strings** option restricts the output to a statistical string value summary.<br /><br /> The **-short** option limits output to just the address of each object. This lets you easily pipe output from the command to another debugger command for automation.<br /><br /> The **-min** option ignores objects that are less than the `size` parameter, specified in bytes.<br /><br /> The **-max** option ignores objects that are larger than the `size` parameter, specified in bytes.<br /><br /> The **-thinlock** option reports ThinLocks.  For more information, see the **SyncBlk** command.<br /><br /> The `-startAtLowerBound` option forces the heap walk to begin at the lower bound of a supplied address range. During the planning phase, the heap is often not walkable because objects are being moved. This option forces **DumpHeap** to begin its walk at the specified lower bound. You must supply the address of a valid object as the lower bound for this option to work. You can display memory at the address of a bad object to manually find the next method table. If the garbage collection is currently in a call to `memcopy`, you may also be able to find the address of the next object by adding the size to the start address, which is supplied as a parameter.<br /><br /> The **-mt** option lists only those objects that correspond to the specified `MethodTable` structure.<br /><br /> The **-type** option lists only those objects whose type name is a substring match of the specified string.<br /><br /> The `start` parameter begins listing from the specified address.<br /><br /> The `end` parameter stops listing at the specified address.|
|**DumpIL** \<*Managed DynamicMethod object*> &#124;       \<*DynamicMethodDesc pointer*> &#124;        \<*MethodDesc pointer*>|Displays the Microsoft intermediate language (MSIL) that is associated with a managed method.<br /><br /> Dynamic MSIL is emitted differently than MSIL that's loaded from an assembly. Dynamic MSIL refers to objects in a managed object array rather than to metadata tokens.|
|**DumpLog** [**-addr** \<*addressOfStressLog*>] [<*Filename*>]|Writes the contents of an in-memory stress log to the specified file. If you do not specify a name, this command creates a file called StressLog.txt in the current directory.<br /><br /> The in-memory stress log helps you diagnose stress failures without using locks or I/O. To enable the stress log, set the following registry keys under HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\\.NETFramework:<br /><br /> (DWORD) StressLog = 1<br /><br /> (DWORD) LogFacility = 0xffffffff<br /><br /> (DWORD) StressLogSize = 65536<br /><br /> The optional `-addr` option lets you specify a stress log other than the default log.|
|**DumpMD** \<*MethodDesc address*>|Displays information about a `MethodDesc` structure at the specified address.<br /><br /> You can use the **IP2MD** command to get the `MethodDesc` structure address from a managed function.|
|**DumpMT** [**-MD**] \<*MethodTable address*>|Displays information about a method table at the specified address. Specifying the **-MD** option displays a list of all methods defined with the object.<br /><br /> Each managed object contains a method table pointer.|
|**DumpModule** [**-mt**] \<*Module address*>|Displays information about a module at the specified address. The **-mt** option displays the types defined in a module and the types referenced by the module<br /><br /> You can use the **DumpDomain** or **DumpAssembly** command to retrieve a module's address.|
|**DumpObj** [**-nofields**] \<*object address*><br /><br /> -or-<br /><br /> **DO** \<*object address*>|Displays information about an object at the specified address. The **DumpObj** command displays the fields, the `EEClass` structure information, the method table, and the size of the object.<br /><br /> You can use the **DumpStackObjects** command to retrieve an object's address.<br /><br /> You can run the **DumpObj** command on fields of type `CLASS` because they are also objects.<br /><br /> The `-`**nofields** option prevents fields of the object being displayed, it is useful for objects like String.|
|**DumpRuntimeTypes**|Displays the runtime type objects in the garbage collector heap and lists their associated type names and method tables.|
|**DumpStack** [**-EE**] [**-n**] [`top` *stack* [`bottom` *stac*`k`]]|Displays a stack trace.<br /><br /> The **-EE** option causes the **DumpStack** command to display only managed functions. Use the `top` and `bottom` parameters to limit the stack frames displayed on x86 platforms.<br /><br /> The **-n** option disables the display of source file names and line numbers. If the debugger has the option SYMOPT_LOAD_LINES specified, SOS will look up the symbols for every managed frame and if successful will display the corresponding source file name and line number. The **-n** (No line numbers) parameter can be specified to disable this behavior.<br /><br />
|**DumpSig** \<*sigaddr*> \<*moduleaddr*>|Displays information about a `Sig` structure at the specified address.|
|**DumpSigElem** \<*sigaddr*> \<*moduleaddr*>|Displays a single element of a signature object. In most cases, you should use **DumpSig** to look at individual signature objects. However, if a signature has been corrupted in some way, you can use **DumpSigElem** to read the valid portions of it.|
|**DumpStackObjects** [**-verify**] [`top` *stack* [`bottom` *stack*]]<br /><br /> -or-<br /><br /> **DSO** [**-verify**] [`top` *stack* [`bottom` *stack*]]|Displays all managed objects found within the bounds of the current stack.<br /><br /> The **-verify** option validates each non-static `CLASS` field of an object field.<br /><br /> Use the **DumpStackObject** command with stack tracing commands such as **K** (windbg) or **bt** (lldb) along with the **clrstack** command to determine the values of local variables and parameters.|
|**DumpVC** \<*MethodTable address*> \<*Address*>|Displays information about the fields of a value class at the specified address.<br /><br /> The **MethodTable** parameter allows the **DumpVC** command to correctly interpret fields. Value classes do not have a method table as their first field.|
|**EEHeap** [**-gc**] [**-loader**]|Displays information about process memory consumed by internal runtime data structures.<br /><br /> The **-gc** and **-loader** options limit the output of this command to garbage collector or loader data structures.<br /><br /> The information for the garbage collector lists the ranges of each segment in the managed heap.  If the pointer falls within a segment range given by **-gc**, the pointer is an object pointer.|
|**EEStack** [**-short**] [**-EE**]|Runs the **DumpStack** command on all threads in the process.<br /><br /> The **-EE** option is passed directly to the **DumpStack** command. The **-short** parameter limits the output to the following kinds of threads:<br /><br />Threads that have taken a lock.<br /><br />Threads that have been stalled in order to allow a garbage collection.<br /><br /> Threads that are currently in managed code.|
|**EHInfo** [\<*MethodDesc address*>] [\<*Code address*>]|Displays the exception handling blocks in a specified method.  This command displays the code addresses and offsets for the clause block (the `try` block) and the handler block (the `catch` block).|
|**FAQ**|Displays frequently asked questions.  Not supported in `dotnet-dump`.|
|**FinalizeQueue** [**-detail**] &#124; [**-allReady**] [**-short**]|Displays all objects registered for finalization.<br /><br /> The **-detail** option displays extra information about any `SyncBlocks` that need to be cleaned up, and any `RuntimeCallableWrappers` (RCWs) that await cleanup. Both of these data structures are cached and cleaned up by the finalizer thread when it runs.<br /><br /> The `-allReady` option displays all objects that are ready for finalization, regardless of whether they are already marked by the garbage collection as such, or will be marked by the next garbage collection. The objects that are in the "ready for finalization" list are finalizable objects that are no longer rooted. This option can be very expensive, because it verifies whether all the objects in the finalizable queues are still rooted.<br /><br /> The `-short` option limits the output to the address of each object. If it is used in conjunction with **-allReady**, it enumerates all objects that have a finalizer that are no longer rooted. If it is used independently, it lists all objects in the finalizable and "ready for finalization" queues.|
|**FindAppDomain** \<*Object address*>|Determines the application domain of an object at the specified address.|
|**FindRoots** **-gen** \<*N*> &#124; **-gen any** &#124;\<*object address*>|Causes the debugger to break in the debuggee on the next collection of the specified generation. The effect is reset as soon as the break occurs. To break on the next collection, you have to reissue the command. The *\<object address>* form of this command is used after the break caused by the **-gen** or **-gen any** has occurred. At that time, the debuggee is in the right state for **FindRoots** to identify roots for objects from the current condemned generations. Only supported on Windows.|
|**GCHandles** [**-perdomain**]|Displays statistics about garbage collector handles in the process.<br /><br /> The **-perdomain** option arranges the statistics by application domain.<br /><br /> Use the **GCHandles** command to find memory leaks caused by garbage collector handle leaks. For example, a memory leak occurs when code retains a large array because a strong garbage collector handle still points to it, and the handle is discarded without freeing it. <br /><br />Only supported on Windows.|
|**GCHandleLeaks**|Searches memory for any references to strong and pinned garbage collector handles in the process and displays the results. If a handle is found, the **GCHandleLeaks** command displays the address of the reference. If a handle is not found in memory, this command displays a notification. Only supported on Windows.|
|**GCInfo** \<*MethodDesc address*>\<*Code address*>|Displays data that indicates when registers or stack locations contain managed objects. If a garbage collection occurs, the collector must know the locations of references to objects so it can update them with new object pointer values.|
|**GCRoot** [**-nostacks**] [**-all**] \<*Object address*>|Displays information about references (or roots) to an object at the specified address.<br /><br /> The **GCRoot** command examines the entire managed heap and the handle table for handles within other objects and handles on the stack. Each stack is then searched for pointers to objects, and the finalizer queue is also searched.<br /><br /> This command does not determine whether a stack root is valid or is discarded. Use the **clrstack** and **U** commands to disassemble the frame that the local or argument value belongs to in order to determine if the stack root is still in use.<br /><br /> The **-nostacks** option restricts the search to garbage collector handles and reachable objects.<br /><br /> The **-all** option forces all roots to be displayed instead of just the unique roots.|
|**GCWhere**  *\<object address>*|Displays the location and size in the garbage collection heap of the argument passed in. When the argument lies in the managed heap but is not a valid object address, the size is displayed as 0 (zero).|
|**Help** (**soshelp**) [\<*command*>] [`faq`]|Displays all available commands when no parameter is specified, or displays detailed help information about the specified command.<br /><br /> The `faq` parameter displays answers to frequently asked questions.|
|**HeapStat** [**-inclUnrooted** &#124; **-iu**]|Displays the generation sizes for each heap and the total free space in each generation on each heap. If the -**inclUnrooted** option is specified, the report includes information about the managed objects from the garbage collection heap that is no longer rooted. Only supported on Windows.|
|**HistClear**|Releases any resources used by the family of `Hist` commands.<br /><br /> Generally, you do not have to explicitly call `HistClear`, because each `HistInit` cleans up the previous resources.|
|**HistInit**|Initializes the SOS structures from the stress log saved in the debuggee.|
|**HistObj** *<obj_address>*|Examines all stress log relocation records and displays the chain of garbage collection relocations that may have led to the address passed in as an argument.|
|**HistObjFind**  *<obj_address>*|Displays all the log entries that reference an object at the specified address.|
|**HistRoot** *\<root>*|Displays information related to both promotions and relocations of the specified root.<br /><br /> The root value can be used to track the movement of an object through the garbage collections.|
|**IP2MD** (**ip2md**) \<*Code address*>|Displays the `MethodDesc` structure at the specified address in code that has been JIT-compiled.|
|**ListNearObj** (**lno**) *<obj_address>*|Displays the objects preceding and following the specified address. The command looks for the address in the garbage collection heap that looks like a valid beginning of a managed object (based on a valid method table) and the object following the argument address. Only supported on Windows.|
|**MinidumpMode** [**0**] [**1**]|Prevents running unsafe commands when using a minidump.<br /><br /> Pass **0** to disable this feature or **1** to enable this feature. By default, the **MinidumpMode** value is set to **0**.<br /><br /> Minidumps created with the **.dump /m** command or **.dump** command have limited CLR-specific data and allow you to run only a subset of SOS commands correctly. Some commands may fail with unexpected errors because required areas of memory are not mapped or are only partially mapped. This option protects you from running unsafe commands against minidumps. <br /><br />Only supported with Windbg.|
|**Name2EE** (**name2ee**) \<*module name*> \<*type or method name*><br /><br /> -or-<br /><br /> **Name2EE** \<*module name*>**!**\<*type or method name*>|Displays the `MethodTable` structure and `EEClass` structure for the specified type or method in the specified module.<br /><br /> The specified module must be loaded in the process.<br /><br /> To get the proper type name, browse the module by using the [Ildasm.exe (IL Disassembler)](../../../docs/framework/tools/ildasm-exe-il-disassembler.md). You can also pass `*` as the module name parameter to search all loaded managed modules. The *module name* parameter can also be the debugger's name for a module, such as `mscorlib` or `image00400000`.<br /><br /> This command supports the Windows debugger syntax of <`module`>`!`<`type`>. The type must be fully qualified.|
|**ObjSize** [\<*Object address*>] &#124; [**-aggregate**] [**-stat**]|Displays the size of the specified object. If you do not specify any parameters, the **ObjSize** command displays the size of all objects found on managed threads, displays all garbage collector handles in the process, and totals the size of any objects pointed to by those handles. The **ObjSize** command includes the size of all child objects in addition to the parent.<br /><br /> The **-aggregate** option can be used in conjunction with the **-stat** argument to get a detailed view of the types that are still rooted. By using **!dumpheap -stat** and **!objsize -aggregate -stat**, you can determine which objects are no longer rooted and diagnose various memory issues. <br /><br /> Only supported on Windows.|
|**PrintException** [**-nested**] [**-lines**] [\<*Exception object address*>]<br /><br /> -or-<br /><br /> **PE** [**-nested**] [\<*Exception object address*>]|Displays and formats fields of any object derived from the <xref:System.Exception> class at the specified address. If you do not specify an address, the **PrintException** command displays the last exception thrown on the current thread.<br /><br /> The **-nested** option displays details about nested exception objects.<br /><br /> The **-lines** option displays source information, if available.<br /><br /> You can use this command to format and view the `_stackTrace` field, which is a binary array.|
|**ProcInfo** [**-env**] [**-time**] [**-mem**]|Displays environment variables for the process, kernel CPU time, and memory usage statistics. Only supported with Windbg.|
|**RCWCleanupList** \<*RCWCleanupList address*>|Displays the list of runtime callable wrappers at the specified address that are awaiting cleanup. Only supported with Windbg.|
|**SaveModule** \<*Base address*> \<*Filename*>|Writes an image, which is loaded in memory at the specified address, to the specified file. Only supported with Windbg.|
|**SetHostRuntime** [\<runtime-directory\>]|This command sets the path to the .NET Core runtime to use to host the managed code that runs as part of SOS in the debugger (lldb). The runtime needs to be at least version 2.1.0 or greater. If there are spaces in directory, it needs to be single-quoted (').<br/><br/>Normally, SOS attempts to find an installed .NET Core runtime to run its managed code automatically but this command is available if it fails. The default is to use the same runtime (libcoreclr) being debugged. Use this command if the default runtime being debugged isn't working enough to run the SOS code or if the version is less than 2.1.0.<br/><br/>If you received the following error message when running a SOS command, use this command to set the path to 2.1.0 or greater .NET Core runtime. <br/><br/>`(lldb) clrstack`<br/>`Error: Fail to initialize CoreCLR 80004005 ClrStack failed`<br/><br/>`(lldb) sethostruntime /usr/share/dotnet/shared/Microsoft.NETCore.App/2.1.6`<br/><br/>You can use the "dotnet --info" in a command shell to find the path of an installed .NET Core runtime.|
|**SetSymbolServer** [**-ms**] [**-disable**] [**-log**] [**-loadsymbols**] [**-cache** \<cache-path>] [**-directory** \<search-directory>] [**-sympath** \<windows-symbol-path>] [\<symbol-server-URL>]|Enables the symbol server downloading support.<br/><br/>The **-ms** option enables downloading from the public Microsoft symbol server.<br/><br/>The **-disable** option turns on the symbol download support.<br/><br/>The **-cache** \<cache-path> option specifies a symbol cache directory. The default is $HOME/.dotnet/symbolcache if not specified.<br/><br/>The **-directory** option adds a path to search for symbols. Can be more than one.<br/><br/>The **-sympath** option adds server, cache, and directory paths in the Windows symbol path format.<br/><br/>The **-log** option enables symbol download logging.<br/><br/>The **-loadsymbols** option attempts to download the native .NET Core symbols for the runtime. Supported on lldb and dotnet-dump|
|**SOSFlush**|Flushes an internal SOS cache.|
|**SOSStatus** [**-reset**]|Displays internal SOS status or reset the internal cached state.|
|**StopOnException** [**-derived**] [**-create** &#124; **-create2**] \<*Exception*> \<*Pseudo-register number*>|Causes the debugger to stop when the specified exception is thrown, but to continue running when other exceptions are thrown.<br /><br /> The **-derived** option catches the specified exception and every exception that derives from the specified exception. <br /><br /> Only supported with Windbg.|
|**SyncBlk** [**-all** &#124; \<*syncblk number*>]|Displays the specified `SyncBlock` structure or all `SyncBlock` structures.  If you do not pass any arguments, the **SyncBlk** command displays the `SyncBlock` structure corresponding to objects that are owned by a thread.<br /><br /> A `SyncBlock` structure is a container for extra information that does not need to be created for every object. It can hold COM interop data, hash codes, and locking information for thread-safe operations.|
|**ThreadPool**|Displays information about the managed thread pool, including the number of work requests in the queue, the number of completion port threads, and the number of timers.|
|**Threads** (**clrthreads**) [**-live**] [**-special**]|Displays all managed threads in the process.<br /><br /> The **Threads** command displays the debugger shorthand ID, the CLR thread ID, and the operating system thread ID.  Additionally, the **Threads** command displays a Domain column that indicates the application domain in which a thread is executing, an APT column that displays the COM apartment mode, and an Exception column that displays the last exception thrown in the thread.<br /><br /> The **-live** option displays threads associated with a live thread.<br /><br /> The **-special** option displays all special threads created by the CLR. Special threads include garbage collection threads (in concurrent and server garbage collection), debugger helper threads, finalizer threads, <xref:System.AppDomain> unload threads, and thread pool timer threads.|
|**ThreadState \<** *State value field* **>**|Displays the state of the thread. The `value` parameter is the value of the `State` field in the **Threads** report output.|
|**Token2EE** \<*module name*> \<*token*>|Turns the specified metadata token in the specified module into a `MethodTable` structure or `MethodDesc` structure.<br /><br /> You can pass `*` for the module name parameter to find what that token maps to in every loaded managed module. You can also pass the debugger's name for a module, such as `mscorlib` or `image00400000`.|
|**U** [**-gcinfo**] [**-ehinfo**] [**-n**] \<*MethodDesc address*> &#124; \<*Code address*>|Displays an annotated disassembly of a managed method specified either by a `MethodDesc` structure pointer for the method or by a code address within the method body. The **U** command displays the entire method from start to finish, with annotations that convert metadata tokens to names.<br /><br /> The **-gcinfo** option causes the **U** command to display the `GCInfo` structure for the method.<br /><br /> The **-ehinfo** option displays exception information for the method. You can also obtain this information with the **EHInfo** command.<br /><br /> The **-n** option disables the display of source file names and line numbers. If the debugger has the option SYMOPT_LOAD_LINES specified, SOS looks up the symbols for every managed frame and, if successful, displays the corresponding source file name and line number. You can specify the **-n** option to disable this behavior.|
|**VerifyHeap**|Checks the garbage collector heap for signs of corruption and displays any errors found.<br /><br /> Heap corruptions can be caused by platform invoke calls that are constructed incorrectly. |
|**VerifyObj** \<*object address*>|Checks the object that is passed as an argument for signs of corruption. Only supported on Windows.|
|**VMMap**|Traverses the virtual address space and displays the type of protection applied to each region. Only supported with Windbg.|
|**VMStat**|Provides a summary view of the virtual address space, ordered by each type of protection applied to that memory (free, reserved, committed, private, mapped, image). The TOTAL column displays the result of the AVERAGE column multiplied by the BLK COUNT column. Only supported with Windbg.|

### Dotnet-Dump

For a list of available SOS commands with `dotnet-dump analyze`, see [dotnet-dump](dotnet-dump.md#analyze-sos-commands).

### Windows Debugger

You can also use the SOS Debugging Extension by loading it into the [WinDbg/dbg debugger](/windows-hardware/drivers/debugger/debugger-download-tools) and executing commands within the Windows debugger.  SOS commands can be used on live processes or dumps.

To load the SOS Debugging Extension into the Windows debugger, run the following command in the tool:

```console
.loadby sos clr
```

WinDbg.exe and Visual Studio use a version of SOS.dll that corresponds to the version of Mscorwks.dll currently in use. By default, you should use the version of SOS.dll that matches the current version of Mscorwks.dll.

To use a dump file created on another computer, make sure that the Mscorwks.dll file that came with that installation is in your symbol path, and load the corresponding version of SOS.dll.

To load a specific version of SOS.dll, enter the following command into the Windows Debugger:

```console
.load <full path to sos.dll>
```

### LLDB Debugger

For instructions on configuring SOS for LLDB, see [dotnet-sos](dotnet-sos.md). SOS commands can be used on live processes or dumps.

By default you can reach all the SOS commands by entering: `sos [command\_name]`. However, the common commands have been aliased so that you don't need the `sos` prefix:

| Command                               | Function
| ------------------------------------- | ---------------------------------------------------------------------------------------------
|    `bpmd`                             | Creates a breakpoint at the specified managed method in the specified module.
|    `clrstack`                         | Provides a stack trace of managed code only.
|    `clrthreads`                       | List the managed threads that are running.
|    `clru`                             | Displays an annotated disassembly of a managed method.
|    `dso`                              | Displays all managed objects found within the bounds of the current stack.
|    `dumpasync`                        | Displays info about async state machines on the garbage-collected heap.
|    `dumpclass`                        | Displays information about the `EEClass` structure at the specified address.
|    `dumpdomain`                       | Displays information all the AppDomains and all assemblies within the specified domain.
|    `dumpheap`                         | Displays info about the garbage-collected heap and collection statistics about objects.
|    `dumpil`                           | Displays the Microsoft intermediate language (MSIL) that is associated with a managed method.
|    `dumplog`                          | Writes the contents of an in-memory stress log to the specified file.
|    `dumpmd`                           | Displays information about the `MethodDesc` structure at the specified address.
|    `dumpmodule`                       | Displays information about the module at the specified address.
|    `dumpmt`                           | Displays information about the method table at the specified address.
|    `dumpobj`                          | Displays info the object at the specified address.
|    `dumpstack`                        | Displays a native and managed stack trace.
|    `eeheap`                           | Displays info about process memory consumed by internal runtime data structures.
|    `eestack`                          | Runs `dumpstack` on all threads in the process.
|    `gcroot`                           | Displays info about references (or roots) to the object at the specified address.
|    `histclear`                        | Releases any resources used by the family of Hist commands.
|    `histinit`                         | Initializes the SOS structures from the stress log saved in the debuggee.
|    `histobj`                          | Examines all stress log relocation records and displays the chain of garbage collection relocations that may have led to the address passed in as an argument.
|    `histobjfind`                      | Displays all the log entries that reference the object at the specified address.
|    `histroot`                         | Displays information related to both promotions and relocations of the specified root.
|    `ip2md`                            | Displays the `MethodDesc` structure at the specified address in code that has been JIT-compiled.
|    `loadsymbols`                      | Load the .NET Core native module symbols.
|    `name2ee`                          | Displays the `MethodTable` and `EEClass` structures for the specified type or method in the specified module.
|    `pe`                               | Displays and formats fields of any object derived from the <xref:System.Exception> class at the specified address.
|    `setclrpath`                       | Sets the path to load coreclr dac/dbi files. `setclrpath <path>`
|    `sethostruntime`                   | Sets or displays the .NET Core runtime directory to use to run managed code in SOS.
|    `setsymbolserver`                  | Enables the symbol server support.
|    `setsostid`                        | Sets the current OS tid/thread index instead of using the one lldb provides. `setsostid <tid> <index>`
|    `sos`                              | Various coreclr debugging commands. For more information, see 'soshelp'. `sos <command-name> <args>`
|    `soshelp`                          | Displays all available commands when no parameter is specified, or displays detailed help information about the specified command: `soshelp <command>`
|    `syncblk`                          | Displays the SyncBlock holder info.

## Windbg/cdb example usage

| Command  | Description
| - | -
| `!dumparray -start 2 -length 5 -detail 00ad28d0` | Displays the contents of an array at the address `00ad28d0`.  The display starts from the second element and continues for five elements.
| `!dumpassembly 1ca248` | Displays the contents of an assembly at the address `1ca248`.
| `!dumpheap` | Displays information about the garbage collector heap.
| `!DumpLog` | Writes the contents of the in-memory stress log to a (default) file called StressLog.txt in the current directory.
 `!dumpmd 902f40` | Displays the `MethodDesc` structure at the address `902f40`.
| `!dumpmodule 1caa50` | Displays information about a module at the address `1caa50`.
| `!DumpObj a79d40` | Displays information about an object at the address `a79d40`.
| `!DumpVC 0090320c 00a79d9c` | Displays the fields of a value class at the address `00a79d9c` using the method table at the address `0090320c`.
| `!eeheap` -gc | Displays the process memory used by the garbage collector.
| `!finalizequeue` | Displays all objects scheduled for finalization.
| `!findappdomain 00a79d98` |  Determines the application domain of an object at the address `00a79d98`.
| `!gcinfo 5b68dbb8` | Displays all garbage collector handles in the current process.
| `!name2ee unittest.exe MainClass.Main` | Displays the `MethodTable` and `EEClass` structures for the `Main` method in the class `MainClass` in the module `unittest.exe`.
| `!token2ee unittest.exe 02000003` | Displays information about the metadata token at the address `02000003` in the module `unittest.exe`.

## LLDB example usage

| Command  | Description
| - | -
| `sos DumpArray -start 2 -length 5 -detail 00ad28d0` | Displays the contents of an array at the address `00ad28d0`.  The display starts from the second element and continues for five elements.
| `sos DumpAssembly 1ca248` | Displays the contents of an assembly at the address `1ca248`.
| `dumpheap` | Displays information about the garbage collector heap.
| `dumplog` | Writes the contents of the in-memory stress log to a (default) file called StressLog.txt in the current directory.
| `dumpmd 902f40` | Displays the `MethodDesc` structure at the address `902f40`.
| `dumpmodule 1caa50` | Displays information about a module at the address `1caa50`.
| `dumpobj a79d40` | Displays information about an object at the address `a79d40`.
| `sos DumpVC 0090320c 00a79d9c` | Displays the fields of a value class at the address `00a79d9c` using the method table at the address `0090320c`.
| `eeheap -gc` | Displays the process memory used by the garbage collector.
| `sos FindAppDomain 00a79d98` | Determines the application domain of an object at the address `00a79d98`.
| `sos GCInfo 5b68dbb8` | Displays all garbage collector handles in the current process.
| `name2ee unittest.exe MainClass.Main` | Displays the `MethodTable` and `EEClass` structures for the `Main` method in the class `MainClass` in the module `unittest.exe`.
| `sos Token2EE unittest.exe 02000003` | Displays information about the metadata token at the address `02000003` in the module `unittest.exe`.
| `clrthreads` | Displays the managed threads.

## See also

- [An introduction to dumps in .NET](dumps.md)
- [Learn how to debug a memory leak in .NET Core](debug-memory-leak.md)
- [Collecting and analyzing memory dumps blog](https://devblogs.microsoft.com/dotnet/collecting-and-analyzing-memory-dumps/)
- [Dump analysis tool (dotnet-dump)](dotnet-dump.md)
- [SOS Installation Tool (dotnet-sos)](dotnet-sos.md)
- [Heap analysis tool (dotnet-gcdump)](dotnet-gcdump.md)
