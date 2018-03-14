open System

type Message = string * AsyncReplyChannel<string>

let formatString = "Message number {0} was received. Message contents: {1}"

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
            let! (message, replyChannel) = inbox.Receive(10000);
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
    let messageAsync = agent.PostAndAsyncReply(fun replyChannel -> input, replyChannel)

    // Set up a continuation function (the first argument below) that prints the reply.
    // The second argument is the exception continuation.
    // The third argument is the cancellation continuation (not used here).
    Async.StartWithContinuations(messageAsync,
         (fun reply -> if (reply = "Stop") then
                           isCompleted <- true
                       else printfn "%s" reply),
         (fun exn ->
            printfn "Exception occurred: %s" exn.Message),
         (fun _ -> ()))

printfn "Press Enter to continue."
Console.ReadLine() |> ignore