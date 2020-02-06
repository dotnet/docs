---
title: Interactive.InteractiveSession Class (F#)
description: Interactive.InteractiveSession Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2e92b40f-7186-4b97-b68d-2346fe7a7828 
---

# Interactive.InteractiveSession Class (F#)

Operations supported by the currently executing F# Interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
[<Sealed>]
type InteractiveSession =
class
member this.AddPrintTransformer : InteractiveSession -> ('T -> obj) -> unit
member this.AddPrinter : InteractiveSession -> ('T -> string) -> unit
member this.CommandLineArgs :  string []
member this.EventLoop :  IEventLoop
member this.FloatingPointFormat :  string
member this.FormatProvider :  IFormatProvider
member this.PrintDepth :  int
member this.PrintLength :  int
member this.PrintSize :  int
member this.PrintWidth :  int
member this.ShowDeclarationValues :  bool
member this.ShowIEnumerable :  bool
member this.ShowProperties :  bool
member this.CommandLineArgs : string [] with set :  string []
member this.EventLoop : IEventLoop with set :  IEventLoop
member this.FloatingPointFormat : string with set :  string
member this.FormatProvider : IFormatProvider with set :  IFormatProvider
member this.PrintDepth : int with set :  int
member this.PrintLength : int with set :  int
member this.PrintSize : int with set :  int
member this.PrintWidth : int with set :  int
member this.ShowDeclarationValues : bool with set :  bool
member this.ShowIEnumerable : bool with set :  bool
member this.ShowProperties : bool with set :  bool
end
```

## Instance Members


|Member|Description|
|------|-----------|
|[AddPrinter](https://msdn.microsoft.com/library/d5d6a505-453a-4cf8-9230-095d615eb96e)|Registers a printer that controls the output of the interactive session.|
|[AddPrintTransformer](https://msdn.microsoft.com/library/606010a2-fcb2-4994-8522-b9f35a7db391)|Registers a print transformer that controls the output of the interactive session.|
|[CommandLineArgs](https://msdn.microsoft.com/library/a20e0de2-2969-4223-af6b-0fdeb614e448)|The command line arguments after ignoring the arguments relevant to the interactive environment and replacing the first argument with the name of the last script file, if any.|
|[EventLoop](https://msdn.microsoft.com/library/79671c60-f021-4a02-8082-a54acbd2addb)|Gets or sets the current event loop being used to process interactions.|
|[FloatingPointFormat](https://msdn.microsoft.com/library/521bfd81-e707-4139-9908-408b7cf64428)|Gets or sets the floating point format used in the output of the interactive session.|
|[FormatProvider](https://msdn.microsoft.com/library/204f48ea-f7ae-4438-abe6-0a497f52d258)|Gets or sets the format provider used in the output of the interactive session.|
|[PrintDepth](https://msdn.microsoft.com/library/7d95a43a-e005-404c-bc7b-7014a7e96ade)|Gets or sets the print depth of the interactive session.|
|[PrintLength](https://msdn.microsoft.com/library/e4bc1b18-7623-48c3-9159-8c31019855c6)|Gets or sets the total print length of the interactive session.|
|[PrintSize](https://msdn.microsoft.com/library/decec1b9-6403-433c-b45f-6e4a03b8db51)|Gets or sets the total print size of the interactive session.|
|[PrintWidth](https://msdn.microsoft.com/library/e6c79af4-b6ef-4612-8658-43981632e513)|Gets or sets the print width of the interactive session.|
|[ShowDeclarationValues](https://msdn.microsoft.com/library/a7e9481d-4159-4587-99ad-58610f8a7ef5)|When set to **false**, disables the display of declaration values in the output of the interactive session.|
|[ShowIEnumerable](https://msdn.microsoft.com/library/815bf5fa-e240-4324-8db1-b39972bd6063)|When set to **false**, disables the display of sequences in the output of the interactive session.|
|[ShowProperties](https://msdn.microsoft.com/library/d9bdf52d-1cf7-4808-ac4e-e151ec921c4d)|When set to **false**, disables the display of properties of evaluated objects in the output of the interactive session.|

## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)