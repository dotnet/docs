open System

let random = System.Random()

// Generates mock jobs using Async.Sleep
let createJob(id:int) =
    let job = async {
        // Let the time be a random number between 1 and 10000
        // And the mock computed result is a floating point value
        let time = random.Next(10000)
        let result = random.NextDouble()
        do! Async.Sleep(time)
        return result
        }
    id, job

type Result = double
// a Job consists of a job ID and a computation that produces a single result.
type Job = int * Async<Result>

type Message = int * Result

let context = System.Threading.SynchronizationContext.Current

// This agent processes when jobs are completed.
let completeAgent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
            let! (id, result) = inbox.Receive()
            printfn "The result of job #%d is %f" id result
            do! loop (n + 1)
        }
    loop (0))

// This agent starts each job in the order it is received.
let runAgent = MailboxProcessor<Job>.Start(fun inbox ->
    let rec loop n =
        async {
            let! (id, job) = inbox.Receive()
            printfn "Starting job #%d" id
            // Start each job, and specify a continuation that
            // posts to the completeAgent's queue.
            Async.StartWithContinuations(job,
               (fun result -> completeAgent.Post(id, result)),
               (fun _ -> ()),
               (fun _ -> ()))
            do! loop (n + 1)
        }
    loop (0))


for id in 1 .. 10 do
    runAgent.Post(createJob(id))

printfn "Press enter to stop at any time."
System.Console.ReadLine() |> ignore