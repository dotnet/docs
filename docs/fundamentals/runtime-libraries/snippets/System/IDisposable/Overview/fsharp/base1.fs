module base1

// <Snippet3>
open System
open System.IO

type BaseClass1() =
    // Flag: Has Dispose already been called?
    let mutable disposed = false

    // Instantiate a FileStream instance.
    let fs = new FileStream("test.txt", FileMode.OpenOrCreate)

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
                fs.Dispose()
                // Free any other managed objects here.
            disposed <- true

// </Snippet3>
