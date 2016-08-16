open System

type Message = string * AsyncReplyChannel<string>

let formatString = "Message number {0} was received. Message contents: {1}"

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {                 
                let! (message, replyChannel) = inbox.Receive();
                
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


let rec loop() =
    printf "> "
    let input = Console.ReadLine()
    let replyAsync = agent.PostAndAsyncReply(fun replyChannel -> input, replyChannel)
    // Wait for reply.
    let reply = Async.RunSynchronously(replyAsync);
    if (reply <> "Stop") then
        printfn "Reply: %s" reply
        loop()
    else
        ()
loop()
     
printfn "Press Enter to continue."
Console.ReadLine() |> ignore