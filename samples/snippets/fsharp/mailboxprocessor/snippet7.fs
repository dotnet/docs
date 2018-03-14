open System

type Message = string * AsyncReplyChannel<string>

let formatString = "Message number {0} was received. Message contents: {1}"

let printThreadId note =

    // Append the thread ID.
    printfn "%d : %s" System.Threading.Thread.CurrentThread.ManagedThreadId note


let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
                let! (message, replyChannel) = inbox.Receive();
                printThreadId "MailboxProcessor"
                if (message = "Stop") then
                    replyChannel.Reply("Stopping.")
                else
                    replyChannel.Reply(String.Format(formatString, n, message))
                do! loop (n + 1)
        }
    loop 0)

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."

let rec loop() =
    printf "> "
    let input = Console.ReadLine()
    printThreadId("Console loop")
    let reply = agent.PostAndReply(fun replyChannel -> input, replyChannel)
    if (reply <> "Stopping.") then
        printfn "Reply: %s" reply
        loop()
    else
        ()
loop()

printfn "Press Enter to continue."
Console.ReadLine() |> ignore