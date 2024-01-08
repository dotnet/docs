module base2

// <Snippet5>
open System

type BaseClass2() =
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

    override this.Finalize() =
        this.Dispose false
// </Snippet5>