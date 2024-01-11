module derived1
open System
open System.IO

type MyBaseClass() =
    // Flag: Has Dispose already been called?
    let mutable disposed = false

    interface IDisposable with
        // Public implementation of Dispose pattern callable by consumers.
        member this.Dispose() =
            this.Dispose true
            GC.SuppressFinalize this

    // Implementation of Dispose pattern.
    abstract Dispose: bool -> unit
    override _.Dispose(disposing) =
        if not disposed then
            if disposing then
                // Free any other managed objects here.
                ()
            // Free any unmanaged objects here.
            disposed <- true

// <Snippet4>
open Microsoft.Win32.SafeHandles
open System

type MyDerivedClass() =
    inherit MyBaseClass()
    
    // Flag: Has Dispose already been called?
    let mutable disposed = false
    // Instantiate a FileStream instance.
    let fs = new FileStream("test.txt", FileMode.OpenOrCreate)

    // Implementation of Dispose pattern.
    override _.Dispose(disposing) =
        if not disposed then
            if disposing then
                fs.Dispose()
                // Free any other managed objects here.

            // Free any unmanaged objects here.
            disposed <- true
            // Call base class implementation.
            base.Dispose disposing
// </Snippet4>
