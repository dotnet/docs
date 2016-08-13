open System

type Message = string

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
            try
                let! message = inbox.Receive(10000);
                printfn "Message number %d. Message contents: %s" n message
                do! loop (n+1)
            with
                | :? TimeoutException -> printfn "Mailbox processor timeout exceeded."

        }
    loop 0)

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."


// This one never breaks out of the loop.
while true do
   Console.ReadLine() |> agent.Post