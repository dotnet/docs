module RuntimeAsyncExample

// <RuntimeBuilder>
open System.Threading.Tasks
open System.Runtime.CompilerServices
open Microsoft.FSharp.Core.CompilerServices

type RuntimeTaskBuilder() =
    member inline _.Delay([<InlineIfLambda>] code: unit -> 'T) = code
    member inline _.Run([<InlineIfLambda>] code: unit -> 'T) : Task<'T> =
        StateMachineHelpers.__runtimeAsyncReturn (code())
    member inline _.Return(value: 'T) = value
    member inline _.Bind(work: Task<'T>, [<InlineIfLambda>] next: 'T -> 'U) =
        next (AsyncHelpers.Await work)

let runtimeTask = RuntimeTaskBuilder()
// </RuntimeBuilder>

// <RuntimeUse>
let readManifest (path: string) =
    runtimeTask {
        let! text = System.IO.File.ReadAllTextAsync path
        return text.Length
    }
// </RuntimeUse>
