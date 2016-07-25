---
title: Async.SwitchToContext Method (F#)
description: Async.SwitchToContext Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c9ac8eb9-456c-4719-b017-b63d5eddb80a 
---

# Async.SwitchToContext Method (F#)

Creates an asynchronous computation that runs its continuation using the [`System.Threading.SynchronizationContext.Post(SendOrPostCallback,Object)`](https://msdn.microsoft.com/library/system.threading.synchronizationcontext.post.aspx) method on the synchronization context object.

**Namespace/Module Path**: Microsoft.FSharp.Control

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
static member SwitchToContext : SynchronizationContext -> Async<unit>

// Usage:
Async.SwitchToContext (syncContext)
```

#### Parameters

*syncContext*
Type: **System.Threading.SynchronizationContext**

The synchronization context to accept the posted computation.

## Return Value

Returns an asynchronous computation that uses the `syncContext` context to execute.

## Remarks

If `syncContext` is null then the asynchronous computation is equivalent to [`Async.SwitchToThreadPool`](https://msdn.microsoft.com/library/c2708739-5389-487a-a3c9-490f417bcdc6).

## Example

The following code example illustrates how to use `Async.SwitchToContext` to switch to the UI thread to update the UI. In this, case a progress bar that indicates the state of completion of a computation is updated.

```fsharp
open System.Windows.Forms

let form = new Form(Text = "Test Form", Width = 400, Height = 400)
let syncContext = System.Threading.SynchronizationContext()
let button1 = new Button(Text = "Start")
let label1 = new Label(Text = "", Height = 200, Width = 200,
                       Top = button1.Height + 10)
form.Controls.AddRange([| button1; label1 |] )

let async1(syncContext, form : System.Windows.Forms.Form) =
    async {
        let label1 = form.Controls.[1]
        // Do something. 
        do! Async.Sleep(10000)
        let threadName = System.Threading.Thread.CurrentThread.Name
        let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
        label1.Text <- label1.Text + sprintf "Something [%s] [%d]" threadName threadNumber

        // Switch to the UI thread and update the UI. 
        do! Async.SwitchToContext(syncContext)
        let threadName = System.Threading.Thread.CurrentThread.Name
        let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
        label1.Text <- label1.Text + sprintf "Here [%s] [%d]" threadName threadNumber

        // Switch back to the thread pool. 
        do! Async.SwitchToThreadPool()
        // Do something. 
        do! Async.Sleep(10000)
        let threadName = System.Threading.Thread.CurrentThread.Name
        let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
        label1.Text <- label1.Text +
                       sprintf "Switched to thread pool [%s] [%d]" threadName threadNumber
    }

let buttonClick(sender:obj, args) =
    let button = sender :?> Button
    Async.Start(async1(syncContext, button.Parent :?> Form))
    let threadName = System.Threading.Thread.CurrentThread.Name
    let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
    button.Parent.Text <- sprintf "Started asynchronous workflow [%s] [%d]" threadName threadNumber
    ()

button1.Click.AddHandler(fun sender args -> buttonClick(sender, args))
Application.Run(form)
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Control.Async Class &#40;F&#35;&#41;](Control.Async-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)