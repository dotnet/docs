---
title: "Wfc.exe (Workflow Command-line Compiler Tool)"
description: Understand wfc.exe, the Workflow command line compiler tool. 
ms.date: "10/10/2020"
helpviewer_keywords: 
  - "wfc [Workflow]"
  - "compiler tool"
  - "wfc.exe"
  - "Workflow, compilation"
  - "Workflow, XOML files"
  - "Workflow, wcf"
ms.topic: "reference"
---
# wfc.exe (Workflow Command-line Compiler Tool)

> [!NOTE]
> This material discusses types and namespaces that are obsolete.

The wfc.exe workflow command-line compiler tool works with old workflow markup files that have the file extension *.xoml* (obsoleted).

## Compilation process

When workflows are compiled, the following procedures are performed as part of the compilation process:

- Validation is performed to ensure that the workflow activities validate based on the rules that the activities have set for themselves. If there are validation errors, the compiler returns a list of the errors.  
- A partial class is generated from the markup definition that is input into the compiler.  

- Code is generated to help with the run-time execution of the activities. Event subscriptions are generated, which help activities know when the activities they contain are finished executing.  
- The partial classes generated from the markup file and the partial classes from the code file are entered into the .NET Framework C# or Visual Basic compiler. The output of this process is the .NET assembly, WorkflowSample.dll. This can be deployed to run the workflow.

### Compiler options

This section shows the options for the wfc.exe workflow command-line compiler.

```output
    Microsoft (R) Windows Workflow Compiler version 3.0.0.0
    Copyright (C) Microsoft Corporation 2005. All rights reserved.

                      Windows Workflow Compiler Options

    wfc.exe <Xoml file list> /target:assembly [<vb/cs file list>] [/language:...]
            [/out:...] [/reference:...] [/library:...] [/debug...] [/nocode...]
             [/checktypes...] [/resource:<resource info>]

                            - OUTPUT FILE -
    /out:<file>             Output file name
    /target:assembly        Build a Windows Workflow assembly (default).
                            Short form: /t:assembly
    /target:exe             Build a Windows Workflow application.
                            Short form: /t:exe
    /delaysign[+|-]         Delay-sign the assembly using only the public portion
                            of the strong name key.
    /keyfile:<file>         Specifies a strong name key file.
    /keycontainer:<string>  Specifies a strong name key container.

                            - INPUT FILES -
    <Xoml file list>        Xoml source file name(s).
    <vb/cs file list>       Code-beside file name(s).
    /reference:<file list>  Reference metadata from the specified assembly file(s).
                            Short form is '/r:'.
    /library:<path list>    Set of directories where to lookup for the references.
                            Short form is '/lib:'.
    /resource:<resinfo>     Embed the specified resource. Short form is '/res:'.
                            resinfo format is <file>[,<name>[,public|private]].

    Rules and freeform layout files must be embedded as assembly resources.
    The resource name is constructed by using the namespace and type name
    of the activity. For example, an activity named "MyActivity" in namespace
    "WFProject" would require resource names "WFProject.MyActivity.rules"
    and/or "WFProject.MyActivity.layout".

                            - CODE GENERATION -
    /debug[+|-]             Emit full debugging information. The default is '+'.
    /nocode[+|-]            Disallow code-beside model.
                            The default is '-'. Short form is '/nc:'.
    /checktypes[+|-]        Check for permitted types in wfc.exe.config file.
                            The default is '-'. Short form is '/ct:'.

                            - LANGUAGE -
    /language:[cs|vb]       The language to use for the generated class.
                            The default is 'CS' (C#). Short form is '/l:'.
    /rootnamespace:<string> Specifies the root Namespace for all type declarations.
                            Valid only for 'VB' (Visual Basic) language.
                            Short form is '/rns:'.

                            - MISCELLANEOUS -
    /help                   Display this usage message. Short form is '/?'.
    /nologo                 Suppress compiler copyright message. Short form is '/n'.

    /nowarn                 Ignore compiler warnings. Short form is '/w'.
```

## Remarks

> [!NOTE]
> This material discusses types and namespaces that are obsolete.

A list of authorized types is usually defined in the *wfc.exe.config* file. During the validation phase of workflow compilation, a workflow source document is rejected if it or the companion rules file directly references any .NET Framework types not present in a list of authorized types. The list of authorized types is an XML document where each entry indicates an `Assembly`, a `Namespace`, a `TypeName`, and an Authorized {`True`&#124;`False`} indicator. `AuthorizedType` corresponds to an entry in the list. Wildcard character designations, which can be used to include or exclude complete namespaces, are allowed. For example, `Type="System.*"` includes all types in <xref:System>, including types contained in child namespaces.
  
The use of a list of authorized types is controlled by the <xref:System.Workflow.ComponentModel.Compiler.WorkflowCompiler> option `'/checktypes'`.

```xml  
<configuration>  
  <System.Workflow.ComponentModel.WorkflowCompiler>
    <authorizedTypes>
      <targetFx version="v4.0">
        ...
        <authorizedType Assembly="System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System*" TypeName="*" Authorized="True"/>
        ...
      </targetFx>
    </authorizedTypes>
  </System.Workflow.ComponentModel.WorkflowCompiler>  
</configuration>  
```

> [!WARNING]
> When `Type="System.*"` type is present, it's possible to include other unintended types, such as `Type="System.Configuration"`, for compilation. You should be cautious and review each one. For any type that should be restricted, be sure to set `Authorized` to `False`.

## See also

- [AuthorizedType class](xref:System.Workflow.ComponentModel.Compiler.AuthorizedType)
