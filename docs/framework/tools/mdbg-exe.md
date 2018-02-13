---
title: "MDbg.exe (.NET Framework Command-Line Debugger)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "command-line debugger [.NET Framework]"
  - "MDbg.exe"
ms.assetid: 28a3f509-07e2-4dbe-81df-874c5e969cc4
caps.latest.revision: 27
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# MDbg.exe (.NET Framework Command-Line Debugger)
The NET Framework Command-Line Debugger helps tools vendors and application developers find and fix bugs in programs that target the .NET Framework common language runtime. This tool uses the runtime debugging API to provide debugging services. You can use MDbg.exe to debug only managed code; there is no support for debugging unmanaged code.  
  
 This tool is available through NuGet. For installation information, see [MDbg 0.1.0](http://www.nuget.org/packages/MDbg/0.1.0). To run the tool, use the Package Manager Console. For more information how to use the Package Manager Console, see [Using the Package Manager Console](http://docs.nuget.org/docs/start-here/Using-the-Package-Manager-Console).  
  
 At the Package Manager prompt, type the following:  
  
## Syntax  
  
```  
MDbg [ProgramName[arguments]] [options]  
```  
  
## Commands  
 When you are in the debugger (as indicated by the **mdbg>** prompt), type one of the commands described in the next section:  
  
 **command** [*arguments*]  
  
 MDbg.exe commands are case-sensitive.  
  
|Command|Description|  
|-------------|-----------------|  
|**ap**[**rocess**] [*number*]|Switches to another debugged process or prints available processes. The numbers are not real process IDs (PIDs), but a 0-indexed list.|  
|**a**[**ttach**] [*pid*]|Attaches to a process or prints available processes.|  
|**b**[**reak**] [*ClassName.Method* &#124; *FileName:LineNo*]|Sets a breakpoint at the specified method. Modules are scanned sequentially.<br /><br /> -   **break** *FileName:LineNo* sets a breakpoint at a location in the source.<br />-   **break** *~number* sets a breakpoint on a symbol recently displayed with the **x** command.<br />-   **break** *module!ClassName.Method+IlOffset* sets a breakpoint on the fully qualified location.|  
|**block**[**ingObjects**]|Displays monitor locks, which are blocking threads.|  
|**ca**[**tch**] [*exceptionType*]|Causes the debugger to break on all exceptions, and not just on the unhandled exceptions.|  
|**cl**[**earException**]|Marks the current exception as handled so that execution can continue. If the cause of the exception has not been dealt with, the exception may be quickly rethrown.|  
|**conf**[**ig**] [*option value*]|Displays all configurable options and shows how the options are invoked without any optional values. If the option is specified, sets `value` as the current option. The following options are currently available:<br /><br /> -   `extpath` sets the path to search for  extensions when the `load` command is used.<br />-   `extpath+` adds a path for loading extensions.|  
|**del**[**ete**]|Deletes a breakpoint.|  
|**de**[**tach**]|Detaches from a debugged process.|  
|**d**[**own**] [*frames*]|Moves the active stack frame down.|  
|**echo**|Echoes a message to the console.|  
|**enableNotif**[**ication**] *typeName* 0&#124;1|Enables (1) or disables (0) custom notifications for the specified type.|  
|**ex**[**it**] [*exitcode*]|Exits the MDbg.exe shell, and optionally specifies the process exit code.|  
|**fo**[**reach**] [*OtherCommand*]|Performs a command on all threads. *OtherCommand* is a valid command that operates on one thread; **foreach** *OtherCommand* performs the same command on all threads.|  
|**f**[**unceval**] [`-ad` *Num*] *functionName* [*args ...* ]|Performs a function evaluation on the current active thread where the function to evaluate is *functionName*. The function name must be fully qualified, including namespaces.<br /><br /> The `-ad` option specifies the application domain to use to resolve the function. If the `-ad` option is not specified, the application domain for resolution defaults to the application domain where the thread that is used for function evaluation is located.<br /><br /> If the function that is being evaluated is not static, the first parameter passed in should be a `this` pointer. All application domains are searched for arguments to the function evaluation..<br /><br /> To request a value from an application domain, prefix the variable with the module and application domain name; for example, `funceval -ad 0 System.Object.ToString hello.exe#0!MyClass.g_rootRef`. This command evaluates the function `System.Object.ToString` in the application domain `0`. Because the `ToString` method is an instance function, the first parameter must be a `this` pointer.|  
|**g**[**o**]|Causes the program to continue until it encounters a breakpoint, the program exits, or an event (for example, an unhandled exception) causes the program to stop.|  
|**h**[**elp**] [*command*]<br /><br /> -or-<br /><br /> **?** [*command*]|Displays a description of all commands or a detailed description of a specified command.|  
|**ig**[**nore**] [*event*]|Causes the debugger to stop on unhandled exceptions only.|  
|**int**[**ercept**] *FrameNumber*|Rolls the debugger back to a specified frame number.<br /><br /> If the debugger encounters an exception, use this command to roll the debugger back to the specified frame number. You can change the program state by using the **set** command and continue by using the **go** command.|  
|**k**[**ill**]|Stops the active process.|  
|**l**[**ist**] [*modules* &#124; *appdomains* &#124; *assemblies*]|Displays the loaded modules, application domains, or assemblies.|  
|**lo**[**ad**] *assemblyName*|Loads an extension in the following manner: The specified assembly is loaded and an attempt is then made to run the static method `LoadExtension` from the `Microsoft.Tools.Mdbg.Extension.Extension` type.|  
|**log** [*eventType*]|Set or display the events to be logged.|  
|**mo**[**de**] [*option on/off*]|Sets different debugger options. Use `mode` with no options to get a list of the debugging modes and their current settings.|  
|**mon**[**itorInfo**] *monitorReference*|Displays object monitor lock information.|  
|**newo**[**bj**] *typeName* [*arguments...*]|Creates a new object of type *typeName*.|  
|**n**[**ext**]|Runs code and moves to the next line (even if the next line includes many function calls).|  
|**Opendump** *pathToDumpFile*|Opens the specified dump file for debugging.|  
|**o**[**ut**]|Moves to the end of the current function.|  
|**pa**[**th**] [*pathName*]|Searches the specified path for the source files if the location in the binaries is not available.|  
|**p**[**rint**] [*var*] &#124; [`-d`]|Prints all variables in scope (**print**), prints the specified variable (**print** *var*), or prints the debugger variables (**print**`-d`).|  
|**printe**[**xception**] [*-r*]|Prints the last exception on the current thread. Use the `–r` (recursive) option to traverse the `InnerException` property on the exception object to get information about the entire chain of exceptions.|  
|**pro**[**cessenum**]|Displays the active processes.|  
|**q**[**uit**] [*exitcode*]|Quits the MDbg.exe shell, optionally specifying the process exit code.|  
|**re**[**sume**] [`*` &#124; [`~`]*threadNumber*]|Resumes the current thread or the thread specified by the *threadNumber* parameter.<br /><br /> If the *threadNumber* parameter is specified as `*` or if the thread number starts with `~`, the command applies to all threads except the one specified by *threadNumber*.<br /><br /> Resuming a non-suspended thread has no effect.|  
|**r**[**un**] [`-d`(`ebug`) &#124; -`o`(`ptimize`) &#124;`-enc`] [[*path_to_exe*] [*args_to_exe*]]|Stops the current process (if there is one) and starts a new one. If no executable argument is passed, this command runs the program that was previously executed with the `run` command. If the executable argument is provided, the specified program is run using the optionally supplied arguments.<br /><br /> If class load, module load, and thread start events are ignored (as they are by default), the program stops on the first executable instruction of the main thread.<br /><br /> You can force the debugger to just-in-time (JIT) compile the code by using one of the following three flags:<br /><br /> -   `-d` *(* `ebug` *)* disables optimizations. This is the default for MDbg.exe.<br />-   `-o` *(* `ptimize` *)* forces the code to run more like it does outside the debugger, but also makes the debugging experience more difficult. This is the default for use outside the debugger.<br />-   `-enc` enables the Edit and Continue feature but incurs a performance hit.|  
|**Set** *variable*=*value*|Changes the value of any in-scope variable.<br /><br /> You can also create your own debugger variables and assign reference values to them from within your application. These values act as handles to the original value, and even the original value is out of scope. All debugger variables must begin with `$` (for example, `$var`). Clear these handles by setting them to nothing using the following command:<br /><br /> `set $var=`|  
|**Setip** [`-il`] *number*|Sets the current instruction pointer (IP) in the file to the specified position. If you specify the `-il` option, the number represents a Microsoft intermediate language (MSIL) offset in the method. Otherwise, the number represents a source line number.|  
|**sh**[**ow**] [*lines*]|Specifies the number of lines to show.|  
|**s**[**tep**]|Moves execution into the next function on the current line, or moves to the next line if there is no function to step into.|  
|**su**[**spend**] [\* &#124; [~]*threadNumber*]|Suspends the current thread or the thread specified by the *threadNumber* parameter.  If *threadNumber* is specified as `*`, the command applies to all threads. If the thread number starts with `~`, the command applies to all threads except the one specified by *threadNumber*. Suspended threads are excluded from running when the process is run by either the **go** or **step** command. If there are no non-suspended threads in the process and you issue the **go** command, the process will not continue. In that case, press CTRL-C to break into the process.|  
|**sy**[**mbol**] *commandName* [*commandValue*]|Specifies one of the following commands:<br /><br /> -   `symbol path` [`"``value``"`] - Displays or sets the current symbol path.<br />-   `symbol addpath` `"` `value` `"` - Adds to your current symbol path.<br />-   `symbol reload` [`"``module``"`]- Reloads either all symbols or the symbols for the specified module.<br />-   `symbol list` [`module`] - Shows the currently loaded symbols for either all modules or the specified module.|  
|**t**[**hread**] [*newThread*] [-*nick nickname*`]`|The thread command with no parameters displays all managed threads in the current process. Threads are usually identified by their thread numbers; however, if the thread has an assigned nickname, the nickname is displayed instead. You can use the `-nick` parameter to assign a nickname to a thread.<br /><br /> -   **thread** `-nick` *threadName* assigns a nickname to the currently running thread.<br /><br /> Nicknames cannot be numbers. If the current thread already has an assigned nickname, the old nickname is replaced with the new one. If the new nickname is an empty string (""), the nickname for the current thread is deleted and no new nickname is assigned to the thread.|  
|**u**[**p**]|Moves the active stack frame up.|  
|**uwgc**[**handle**] [*var*] &#124; [*address*]|Prints the variable tracked by a handle. The handle can be specified by name or address.|  
|**when**|Displays the currently active `when` statements.<br /><br /> **when** **delete all** &#124; `num` [`num` [`num` …]] - Deletes the `when` statement specified by the number, or all `when` statements if `all` is specified.<br /><br /> **when** `stopReason` [`specific_condition`] **do**`cmd` [`cmd` [`cmd` …] ] - The *stopReason* parameter can be one of the following:<br /><br /> `StepComplete`, `ProcessExited`, `ThreadCreated`, `BreakpointHit`, `ModuleLoaded`, `ClassLoaded`, `AssemblyLoaded`, `AssemblyUnloaded`, `ControlCTrapped`, `ExceptionThrown`, `UnhandledExceptionThrown`, `AsyncStop`, `AttachComplete`, `UserBreak`, `EvalComplete`, `EvalException`, `RemapOpportunityReached`, `NativeStop`.<br /><br /> *specific_condition* can be one of the following:<br /><br /> -   *number* - For `ThreadCreated` and `BreakpointHit`, triggers action only when stopped by a thread ID/breakpoint number with same value.<br />-   [`!`]*name* - For `ModuleLoaded`, `ClassLoaded`, `AssemblyLoaded`, `AssemblyUnloaded`, `ExceptionThrown`, and `UnhandledExceptionThrown`, triggers action only when the name matches the name of the *stopReason*.<br /><br /> *specific_condition* must be empty for other values of *stopReason*.|  
|**w**[**here**] [`-v`] [`-c` *depth*] [*threadID*]|Displays debug information about stack frames.<br /><br /> -   The `-v` option provides verbose information about each displayed stack frame.<br />-   Specifying a number for `depth` limits how many frames are displayed. Use the **all** command to display all frames. The default is 100.<br />-   If you specify the *threadID* parameter, you can control which thread is associated with the stack. The default is the current thread only. Use the **all** command to get all threads.|  
|**x** [`-c`*numSymbols*] [*module*[`!`*pattern*]]|Displays functions that match the `pattern` for a module.<br /><br /> If *numSymbols* is specified, the output is limited to the specified number. If `!` (indicating a regular expression) is not specified for *pattern*, all functions are displayed. If *module* is not provided, all loaded modules are displayed. Symbols (*~#*) can be used to set breakpoints using the **break** command.|  
  
## Remarks  
 Compile the application to be debugged by using compiler-specific flags that cause your compiler to generate debugging symbols. Refer to your compiler's documentation for more information about these flags. You can debug optimized applications, but some debugging information will be missing. For example, many local variables will not be visible and source lines will be inaccurate.  
  
 After you compile your application, type **mdbg** at the command prompt to start a debugging session, as shown in the following example.  
  
```  
C:\Program Files\Microsoft Visual Studio 8\VC>mdbg  
MDbg (Managed debugger) v2.0.50727.42 (RTM.050727-4200) started.  
Copyright (C) Microsoft Corporation. All rights reserved.  
  
For information about commands type "help";  
to exit program type "quit".  
mdbg>  
```  
  
 The `mdbg>` prompt indicates that you are in the debugger.  
  
 Once you are in the debugger, use the commands and arguments described in the previous section.  
  
## Examples  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
