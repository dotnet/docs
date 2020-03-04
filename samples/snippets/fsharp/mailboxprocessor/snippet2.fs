open System
open Microsoft.FSharp.Control

type Message(id, contents) =
    static let mutable count = 0
    member this.ID = id
    member this.Contents = contents
    static member CreateMessage(contents) =
        count <- count + 1
        Message(count, contents)

let mailbox = new MailboxProcessor<Message>(fun inbox ->
    let rec loop count =
        async { printfn "Message count = %d. Waiting for next message." count
                let! msg = inbox.Receive()
                printfn "Message received. ID: %d Contents: %s" msg.ID msg.Contents
                return! loop( count + 1) }
    loop 0)

mailbox.Start()

mailbox.Post(Message.CreateMessage("ABC"))
mailbox.Post(Message.CreateMessage("XYZ"))


Console.WriteLine("Press any key...")
Console.ReadLine() |> ignore