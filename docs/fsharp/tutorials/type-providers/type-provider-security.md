---
title: Type Provider Security
description: Learn about type provider security in F#, including how to change the trust settings for a type provider.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 9c5a8a1f-5a31-490d-83c0-8beabda75c78 
---

# Type Provider Security

Type providers are assemblies (DLLs) referenced by your F# project or script that contain code to connect to external data sources and surface this type information to the F# type environment. Typically, code in referenced assemblies is only run when you compile and then execute the code (or in the case of a script, send the code to F# Interactive). However, a type provider assembly will run inside Visual Studio when the code is merely browsed in the editor. This happens because type providers need to run to add extra information to the editor, such as Quick Info tooltips, IntelliSense completions, and so on. As a result, there are extra security considerations for type provider assemblies, since they run automatically inside the Visual Studio process.


## Security Warning Dialog
When using a particular type provider assembly for the first time, Visual Studio displays a security dialog that warns you that the type provider is about to run. Before Visual Studio loads the type provider, it gives you the opportunity to decide if you trust this particular provider. If you trust the source of the type provider, then select "I trust this type provider." If you do not trust the source of the type provider, then select "I do not trust this type provider." Trusting the provider enables it to run inside Visual Studio and provide IntelliSense and build features. But if the type provider itself is malicious, running its code could compromise your machine.

If your project contains code that references type providers that you chose in the dialog not to trust, then at compile time, the compiler will report an error that indicates that the type provider is untrusted. Any types that are dependent on the untrusted type provider are indicated by red squiggles. It is safe to browse the code in the editor.

If you decide to change the trust setting directly in Visual Studio, perform the following steps.


#### To change the trust settings for type providers

1. On the `Tools` menu, select `Options`, and expand the `F# Tools` node.
<br />

2. Select `Type Providers`, and in the list of type providers, select the check box for type providers you trust, and clear the check box for those you don't trust.
<br />


## See Also
[Type Providers](index.md)
