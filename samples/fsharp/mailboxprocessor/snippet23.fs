open System

type Message = string

let agent = MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n =
        async {
                let! message = inbox.Receive(10000);
                printfn "Message number %d. Message contents: %s" n message
                do! loop (n + 1)
        }
    loop 0)

agent.Error.Add(fun exn ->
    match exn with
    | :? System.TimeoutException as exn -> printfn "The agent timed out."
                                           printfn "Press Enter to close the program."
                                           Console.ReadLine() |> ignore
                                           exit(1)
    | _ -> printfn "Unknown exception.")

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
  
while true do
    Console.ReadLine() |> agent.Post