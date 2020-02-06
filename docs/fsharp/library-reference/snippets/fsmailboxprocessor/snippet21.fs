open System
open System.Threading

let random = System.Random()


// Generates mock jobs by using Async.Sleep.
let createJob(id:int, source:CancellationTokenSource) =
    let job = async {
        // Let the time be a random number between 1 and 10000.
        // The mock computed result is a floating point value.
        let time = random.Next(10000)
        let result = random.NextDouble()
        let count = ref 1
        while (!count <= 100 && not source.IsCancellationRequested) do
            do! Async.Sleep(time / 100)
            count := !count + 1
        return result
        }
    id, job, source

type Result = double

// A Job consists of a job ID and a computation that produces a single result.
type Job = int * Async<Result> * CancellationTokenSource

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

// inprogressAgent maintains a queue of in-progress jobs that can be
// scanned to remove canceled jobs. It never runs its processor function,
// so we set it to do nothing.
let inprogressAgent = new MailboxProcessor<Job>(fun _ -> async { () })

// This agent starts each job in the order in which it is received.
let runAgent = MailboxProcessor<Job>.Start(fun inbox ->
    let rec loop n =
        async {          
            let! (id, job, source) = inbox.Receive()
            printfn "Starting job #%d" id
            // Post to the in-progress queue.
            inprogressAgent.Post(id, job, source)
            // Start the job.
            Async.StartWithContinuations(job,
                (fun result -> completeAgent.Post(id, result)),
                (fun _ -> ()),
                (fun cancelException -> printfn "Canceled job #%d" id),
                source.Token)
            do! loop (n + 1)
            }
    loop (0))

for id in 1 .. 10 do
    let source = new CancellationTokenSource()
    runAgent.Post(createJob(id, source))

let cancelJob(cancelId) =
    Async.RunSynchronously(
        inprogressAgent.Scan(fun (jobId, result, source) ->
            let action =
                async {
                    printfn "Canceling job #%d" cancelId
                    source.Cancel()
                }
            // Return Some(async) if the job ID matches.
            if (jobId = cancelId) then
                Some(action)
            else
                None))

printfn "Specify a job by number to cancel it, then press Enter."

let mutable finished = false
while not finished do
    let input = System.Console.ReadLine()
    let a = ref 0
    if (Int32.TryParse(input, a) = true) then
        cancelJob(!a)
    else
        printfn "Terminating."
        finished <- true