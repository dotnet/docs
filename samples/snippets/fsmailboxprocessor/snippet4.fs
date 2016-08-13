open System
type Message = string

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
            let! message = inbox.Receive();
            if (message = "Stop") then
                raise (new Exception("Stop command received."))
                ()
            else
               printfn "Message number %d. Message contents: %s" n message
               do! loop (n+1)
        }
    loop 0)

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."

try
    while true do
        System.Console.ReadLine() |> agent.Post
with
    | exn -> printfn "%s" exn.Message