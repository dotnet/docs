open System

type Message = string * AsyncReplyChannel<string>

let formatString = "Message number {0} was received. Message contents: {1}"

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
            try
                let! (message, replyChannel) = inbox.Receive(10000);

                if (message = "Stop") then
                    replyChannel.Reply("Stop")
                else
                    replyChannel.Reply(String.Format(formatString, n, message))
                do! loop (n + 1)

            with
            | :? TimeoutException ->
                printfn "The mailbox processor timed out."
                do! loop (n + 1)
        }
    loop (0))

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."


let rec loop() =
    printf "> "
    let input = Console.ReadLine()
    let reply = agent.PostAndReply(fun replyChannel -> input, replyChannel)
    if (reply <> "Stop") then
        printfn "Reply: %s" reply
        loop()
    else
        ()
loop()

printfn "Press Enter to continue."
Console.ReadLine() |> ignore