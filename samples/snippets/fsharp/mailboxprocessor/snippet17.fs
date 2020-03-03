open System

type Message = string * AsyncReplyChannel<string>

let formatString = "Message number {0} was received. Message contents: {1}"

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
                let! (message, replyChannel) = inbox.Receive();
                // The delay gets longer with each message, eventually will trigger a timeout.
                do! Async.Sleep(200 * n );
                if (message = "Stop") then
                    replyChannel.Reply("Stop")
                else
                    replyChannel.Reply(String.Format(formatString, n, message))
                do! loop (n + 1)
        }
    loop 0)

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."

let mutable isCompleted = false
while (not isCompleted) do
    printf "> "
    let input = Console.ReadLine()
    let reply = agent.TryPostAndReply((fun replyChannel -> input, replyChannel), 1000)
    match reply with
    | None -> printfn "Timeout exceeded."
    | Some(reply) ->
        if (reply <> "Stop") then
            printfn "Reply: %s" reply
        else
            isCompleted <- true

printfn "Press Enter to continue."
Console.ReadLine() |> ignore