
open System
open System.Diagnostics

// Represents a stream of IObserver events.
type ObservableSource<'T>() =

    let protect function1 =
        let mutable ok = false
        try 
            function1()
            ok <- true
        finally
            Debug.Assert(ok, "IObserver method threw an exception.")

    let mutable key = 0

    // Use a Map, not a Dictionary, because callers might unsubscribe in the OnNext
    // method, so thread-safe snapshots of subscribers to iterate over are needed.
    let mutable subscriptions = Map.empty : Map<int, IObserver<'T>>

    let next(obs) = 
        subscriptions |> Seq.iter (fun (KeyValue(_, value)) -> 
            protect (fun () -> value.OnNext(obs)))

    let completed() = 
        subscriptions |> Seq.iter (fun (KeyValue(_, value)) -> 
            protect (fun () -> value.OnCompleted()))

    let error(err) = 
        subscriptions |> Seq.iter (fun (KeyValue(_, value)) -> 
            protect (fun () -> value.OnError(err)))

    let thisLock = new obj()

    let obs = 
        { new IObservable<'T> with
            member this.Subscribe(obs) =
                let key1 =
                    lock thisLock (fun () ->
                        let key1 = key
                        key <- key + 1
                        subscriptions <- subscriptions.Add(key1, obs)
                        key1)
                { new IDisposable with 
                    member this.Dispose() = 
                        lock thisLock (fun () -> 
                            subscriptions <- subscriptions.Remove(key1)) } }

    let mutable finished = false

    // The source ought to call these methods in serialized fashion (from
    // any thread, but serialized and non-reentrant).
    member this.Next(obs) =
        Debug.Assert(not finished, "IObserver is already finished")
        next obs

    member this.Completed() =
        Debug.Assert(not finished, "IObserver is already finished")
        finished <- true
        completed()

    member this.Error(err) =
        Debug.Assert(not finished, "IObserver is already finished")
        finished <- true
        error err

    // The IObservable object returned is thread-safe; you can subscribe 
    // and unsubscribe (Dispose) concurrently.
    member this.AsObservable = obs

// Create a source.
let source = new ObservableSource<int>()

// Get an IObservable from the source.
let obs = source.AsObservable 

// Add a simple subscriber.
let unsubA = obs |> Observable.subscribe (fun x -> printfn "A: %d" x)

// Send some messages from the source.
// Output: A: 1
source.Next(1)
// Output: A: 2
source.Next(2)

// Add another subscriber. This subscriber has a filter.
let unsubB =
    obs
    |> Observable.filter (fun num -> num % 2 = 0)
    |> Observable.subscribe (fun num -> printfn "B: %d" num)

// Send more messages from the source.
// Output: A: 3
source.Next(3)
// Output: A: 4
//         B: 4
source.Next(4)

// Have subscriber A unsubscribe.
unsubA.Dispose()
    
// Send more messages from the source.
// No output
source.Next(5)
// Output: B: 6
source.Next(6)

// If you use add, there is no way to unsubscribe from the event.
obs |> Observable.add(fun x -> printfn "C: %d" x)

// Now add a subscriber that only does positive numbers and transforms
// the numbers into another type, here a string.
let unsubD =
    obs |> Observable.choose (fun int1 ->
             if int1 >= 0 then None else Some(int1.ToString()))
        |> Observable.subscribe(fun string1 -> printfn "D: %s" string1)

let unsubE =
    obs |> Observable.filter (fun int1 -> int1 >= 0)
        |> Observable.subscribe(fun int1 -> printfn "E: %d" int1)

let unsubF =
    obs |> Observable.map (fun int1 -> int1.ToString())
        |> Observable.subscribe (fun string1 -> printfn "F: %s" string1)
