---
title: Interactive.InteractiveSession Class
description: Interactive.InteractiveSession Class
ms.date: 02/26/2020
---

# Interactive.InteractiveSession Class

Operations supported by the currently executing F# Interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
[<Sealed>]
type InteractiveSession =
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
```

## Instance Members

|Member|Description|
|------|-----------|
|[`AddPrinter`](interactive.addprinter['t]-method.md)|Registers a printer that controls the output of the interactive session.|
|[`AddPrintTransformer`](interactive.addprinttransformer['t]-method.md)|Registers a print transformer that controls the output of the interactive session.|
|[`CommandLineArgs`](interactive.commandlineargs-property.md)|The command line arguments after ignoring the arguments relevant to the interactive environment and replacing the first argument with the name of the last script file, if any.|
|[`EventLoop`](interactive.eventloop-property.md)|Gets or sets the current event loop being used to process interactions.|
|[`FloatingPointFormat`](interactive.floatingpointformat-property.md)|Gets or sets the floating point format used in the output of the interactive session.|
|[`FormatProvider`](interactive.formatprovider-property.md)|Gets or sets the format provider used in the output of the interactive session.|
|[`PrintDepth`](interactive.printdepth-property.md)|Gets or sets the print depth of the interactive session.|
|[`PrintLength`](interactive.printlength-property.md)|Gets or sets the total print length of the interactive session.|
|[`PrintSize`](interactive.printsize-property.md)|Gets or sets the total print size of the interactive session.|
|[`PrintWidth`](interactive.printwidth-property.md)|Gets or sets the print width of the interactive session.|
|[`ShowDeclarationValues`](interactive.showdeclarationvalues-property.md)|When set to **false**, disables the display of declaration values in the output of the interactive session.|
|[`ShowIEnumerable`](interactive.showienumerable-property.md)|When set to **false**, disables the display of sequences in the output of the interactive session.|
|[`ShowProperties`](interactive.showproperties-property.md)|When set to **false**, disables the display of properties of evaluated objects in the output of the interactive session.|

## See Also
[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
