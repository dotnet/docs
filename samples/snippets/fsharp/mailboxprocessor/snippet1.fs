open System
open Microsoft.FSharp.Control

type Message =
    {
        id : int
        contents : string
    }
    static member count = 0
    static member CreateMessage(content) =
        { id = Message.count; contents = content }

let mailbox = new MailboxProcessor<Message>(fun mailbox ->
    printfn "Message received."
    Async.Sleep(10000))

mailbox.Start()
mailbox.Post(Message.CreateMessage("123"))
Async.Start(async { do! mailbox.PostAndAsyncReply(fun _ ->
                            printfn "Reply received via PostAndAsyncReply."
                            Message.CreateMessage("ABC")) })

Async.Start(async { do! mailbox.PostAndReply(fun _ ->
    printfn "Reply received via PostAndReply."
    Message.CreateMessage("DEF")) })

Async.Start(async {
    let! resultOption =  mailbox.PostAndTryAsyncReply(fun _ ->
                   printfn "Reply received via PostAndTryAsyncReply."
                   Message.CreateMessage("XYZ"))
    match resultOption with
    | Some value -> ()
    | None -> printfn "Operation timed out."
    } )

Async.Start(
        async {
            while (mailbox.CurrentQueueLength > 0) do
                let! message = mailbox.Receive()
                // process/respond to message.
                printfn "Message received: ID = %d Message = %s" message.id message.contents
        }
)