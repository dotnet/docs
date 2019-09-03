---
title: "How to: Build a multifile assembly"
ms.date: "08/20/2019"
helpviewer_keywords: 
  - "assemblies [.NET Framework], multifile"
  - "entry point for assembly"
  - "compiling assemblies"
  - "Al.exe"
  - "command-line compilers"
  - "assembly manifest, multifile assemblies"
  - "assemblies [.NET Framework], compiling"
  - "Assembly Linker"
  - "code modules"
  - "multifile assemblies"
ms.assetid: 261c5583-8a76-412d-bda7-9b8ee3b131e5
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Build a multifile assembly
This article explains how to create a multifile assembly and provides code that illustrates each step in the procedure.

> [!NOTE]
> The Visual Studio IDE for C# and Visual Basic can only be used to create single-file assemblies. If you want to create multifile assemblies, you must use the command-line compilers or Visual Studio with Visual C++.

## Create a multifile assembly

1. Compile all files that contain namespaces referenced by other modules in the assembly into code modules. The default extension for code modules is *.netmodule*.
   
   For example, let's say the `Stringer` file has a namespace called `myStringer`, which includes a class called `Stringer`. The `Stringer` class contains a method called `StringerMethod` that writes a single line to the console.
   
   # [C++](#tab/cpp)
   ```cpp
   // Assembly building example in the .NET Framework.
   using namespace System;
   
   namespace myStringer
   {
       public ref class Stringer
       {
       public:
           void StringerMethod()
           {
               System::Console::WriteLine("This is a line from StringerMethod.");
           }
       };
   }
   ```
   # [C#](#tab/csharp)
   ```csharp
   // Assembly building example in the .NET Framework.
   using System;
   
   namespace myStringer
   {
       public class Stringer
       {
           public void StringerMethod()
           {
               System.Console.WriteLine("This is a line from StringerMethod.");
           }
       }
   }
   ```
   # [Visual Basic](#tab/vb)
   ```vb
   ' Assembly building example in the .NET Framework.
   Imports System
   
   Namespace myStringer
       Public Class Stringer
           Public Sub StringerMethod()
               System.Console.WriteLine("This is a line from StringerMethod.")
           End Sub
       End Class
   End Namespace
   ```
   ---
   
2. Use the following command to compile this code:
   
   # [C++](#tab/cpp)
   ```cmd
   cl /clr:pure /LN Stringer.cpp
   ```
   # [C#](#tab/csharp)
   ```cmd
   csc /t:module Stringer.cs
   ```
   # [Visual Basic](#tab/vb)
   ```cmd
   vbc /t:module Stringer.vb
   ```
   ---
   
   Specifying the *module* parameter with the **/t:** compiler option indicates that the file should be compiled as a module rather than as an assembly. The compiler produces a module called *Stringer.netmodule*, which can be added to an assembly.
   
3. Compile all other modules, using the necessary compiler options to indicate the other modules that are referenced in the code. This step uses the **/addmodule** compiler option.
   
   In the following example, a code module called *Client* has an entry point `Main` method that references a method in the *Stringer.dll* module created in step 1.
   
   # [C++](#tab/cpp)
   ```cpp
   #using "Stringer.netmodule"
   
   using namespace System;
   using namespace myStringer; //The namespace created in Stringer.netmodule.
   
   ref class MainClientApp
   {
       // Static method Main is the entry point method.
   public:
       static void Main()
       {
           Stringer^ myStringInstance = gcnew Stringer();
           Console::WriteLine("Client code executes");
           myStringInstance->StringerMethod();
       }
   };
   
   int main()
   {
       MainClientApp::Main();
   }
   ```
   # [C#](#tab/csharp)
   ```csharp
   using System;
   using myStringer;
   
   class MainClientApp
   {
       // Static method Main is the entry point method.
       public static void Main()
       {
           Stringer myStringInstance = new Stringer();
           Console.WriteLine("Client code executes");
           myStringInstance.StringerMethod();
       }
   }
   ```
   # [Visual Basic](#tab/vb)
   ```vb
   Imports System
   Imports myStringer
   
   Class MainClientApp
       ' Static method Main is the entry point method.
       Public Shared Sub Main()
           Dim myStringInstance As New Stringer()
           Console.WriteLine("Client code executes")
           myStringInstance.StringerMethod()
       End Sub
   End Class
   ```
   ---
   
4. Use the following command to compile this code:
   
   # [C++](#tab/cpp)
   ```cmd
   cl /clr:pure /FUStringer.netmodule /LN Client.cpp
   ```
   # [C#](#tab/csharp)
   ```cmd
   csc /addmodule:Stringer.netmodule /t:module Client.cs
   ```
   # [Visual Basic](#tab/vb)
   ```cmd
   vbc /addmodule:Stringer.netmodule /t:module Client.vb
   ```
   ---
   
   Specify the **/t:module** option because this module will be added to an assembly in a future step. Specify the **/addmodule** option because the code in *Client* references a namespace created by the code in *Stringer.netmodule*. The compiler produces a module called *Client.netmodule* that contains a reference to another module, *Stringer.netmodule*.
   
   > [!NOTE]
   > The C# and Visual Basic compilers support directly creating multifile assemblies using the following two different syntaxes.
   > 
   > Two compilations create a two-file assembly:
   >   
   >   # [C++](#tab/cpp)
   >   ```cmd
   >   cl /clr:pure /LN Stringer.cpp
   >   cl /clr:pure Client.cpp /link /ASSEMBLYMODULE:Stringer.netmodule
   >   ```
   >   # [C#](#tab/csharp)
   >   ```cmd
   >   csc /t:module Stringer.cs
   >   csc Client.cs /addmodule:Stringer.netmodule
   >   ```
   >   # [Visual Basic](#tab/vb)
   >   ```cmd
   >   vbc /t:module Stringer.vb
   >   vbc Client.vb /addmodule:Stringer.netmodule
   >   ```
   >   ---
   > One compilation creates a two-file assembly:
   >   # [C++](#tab/cpp)
   >   ```cmd
   >   cl /clr:pure /LN Stringer.cpp
   >   cl /clr:pure Client.cpp /link /ASSEMBLYMODULE:Stringer.netmodule
   >   ```
   >   # [C#](#tab/csharp)
   >   ```cmd
   >   csc /out:Client.exe Client.cs /out:Stringer.netmodule Stringer.cs
   >   ```
   >   # [Visual Basic](#tab/vb)
   >   ```cmd
   >   vbc /out:Client.exe Client.vb /out:Stringer.netmodule Stringer.vb
   >   ```
   >   ---
    
3. Use the [Assembly Linker (Al.exe)](../tools/al-exe-assembly-linker.md) to create the output file that contains the assembly manifest. This file contains reference information for all modules or resources that are part of the assembly.

    At the command prompt, type the following command:

    **al** \<*module name*> \<*module name*> … **/main:**\<*method name*> **/out:**\<*file name*> **/target:**\<*assembly file type*>

    In this command, the *module name* arguments specify the name of each module to include in the assembly. The **/main:** option specifies the method name that is the assembly's entry point. The **/out:** option specifies the name of the output file, which contains assembly metadata. The **/target:** option specifies that the assembly is a console application executable (*.exe*) file, a Windows executable (*.win*) file, or a library (*.lib*) file.

    In the following example, *Al.exe* creates an assembly that is a console application executable called *myAssembly.exe*. The application consists of two modules called *Client.netmodule* and *Stringer.netmodule*, and the executable file called *myAssembly.exe*, which contains only assembly metadata. The entry point of the assembly is the `Main` method in the class `MainClientApp`, which is located in *Client.dll*.

    ```
    al Client.netmodule Stringer.netmodule /main:MainClientApp.Main /out:myAssembly.exe /target:exe
    ```

    You can use the [MSIL Disassembler (Ildasm.exe)](../tools/ildasm-exe-il-disassembler.md) to examine the contents of an assembly, or determine whether a file is an assembly or a module.

## See also

- [Create assemblies](../../standard/assembly/create.md)
- [How to: View assembly contents](../../standard/assembly/view-contents.md)
- [How the runtime locates assemblies](../deployment/how-the-runtime-locates-assemblies.md)
- [Multifile assemblies](multifile-assemblies.md)
