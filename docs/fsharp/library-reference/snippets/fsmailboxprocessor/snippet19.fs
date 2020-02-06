open System

type Message = string * AsyncReplyChannel<string>

let formatString = "Message number {0} was received. Message contents: {1}"

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {          
            let! (message, replyChannel) = inbox.Receive();
            // The delay gets longer with each message, and eventually triggers a timeout.
            do! Async.Sleep(200 * n );
            if (message = "Stop") then
                replyChannel.Reply("Stop")
            else
                replyChannel.Reply(String.Format(formatString, n, message))
            do! loop (n + 1)
        }
    loop (0))

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."

let mutable isCompleted = false
while (not isCompleted) do
    printf "> "
    let input = Console.ReadLine()
    let messageAsync = agent.PostAndTryAsyncReply((fun replyChannel -> input, replyChannel), 1000)
    // Set up a continuation function (the first argument below) that prints the reply.
    // The second argument is the exception continuation.
    // The third argument is the cancellation continuation (not used).
    Async.StartWithContinuations(messageAsync, 
         (fun reply -> 
             match reply with
             | None -> printfn "Reply timeout exceeded."
             | Some reply -> if (reply = "Stop") then
                                 isCompleted <- true
                             else printfn "%s" reply),
         (fun exn ->
            printfn "Exception occurred: %s" exn.Message),
         (fun _ -> ()))

printfn "Press Enter to continue."
Console.ReadLine() |> ignore