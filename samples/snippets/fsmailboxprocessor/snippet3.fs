open System

type AssetCode = string

type Asset(code, bid, ask, initialQuantity) =
    let mutable quantity = initialQuantity
    member this.AssetCode = code
    member this.Bid = bid
    member this.Ask = ask
    member this.Quantity with get() = quantity and set(value) = quantity <- value


type OrderType =
    | Buy of AssetCode * int
    | Sell of AssetCode * int

type Message =
    | Query of AssetCode * AsyncReplyChannel<Reply>
    | Order of OrderType * AsyncReplyChannel<Reply>
and Reply =
    | Failure of string
    | Info of Asset
    | Notify of OrderType

let assets = [| new Asset("AAA", 10.0, 10.05, 1000000);
                new Asset("BBB", 20.0, 20.10, 1000000);
                new Asset("CCC", 30.0, 30.15, 1000000) |]

let codeAssetMap = assets
                   |> Array.map (fun asset -> (asset.AssetCode, asset))
                   |> Map.ofArray

let mutable totalCash = 00.00
let minCash = -1000000000.0
let maxTransaction = 1000000.0

let marketMaker = new MailboxProcessor<Message>(fun inbox ->
    let rec Loop() =
        async {
            let! message = inbox.Receive()
            match message with
            | Query(assetCode, replyChannel) ->
                match (Map.tryFind assetCode codeAssetMap) with
                | Some asset ->
                    printfn "Replying with Info for %s" (asset.AssetCode)
                    replyChannel.Reply(Info(asset))
                | None -> replyChannel.Reply(Failure("Asset code not found."))
            | Order(order, replyChannel) ->
                match order with
                | Buy(assetCode, quantity) ->
                    match (Map.tryFind assetCode codeAssetMap) with
                    | Some asset ->
                        if (quantity < asset.Quantity) then
                            asset.Quantity <- asset.Quantity - quantity
                            totalCash <- totalCash + float quantity * asset.Ask
                            printfn "Replying with Notification:\nBought %d units of %s at price $%f. Total purchase $%f."
                                    quantity asset.AssetCode asset.Ask (asset.Ask * float quantity)
                            printfn "Marketmaker balance: $%10.2f" totalCash
                            replyChannel.Reply(Notify(Buy(asset.AssetCode, quantity)))
                        else
                            printfn "Insufficient shares to fulfill order for %d units of %s."
                                    quantity asset.AssetCode
                            replyChannel.Reply(Failure("Insufficient shares to fulfill order."))
                    | None -> replyChannel.Reply(Failure("Asset code not found."))
                | Sell(assetCode, quantity) ->
                    match (Map.tryFind assetCode codeAssetMap) with
                    | Some asset ->
                        if (float quantity * asset.Bid <= maxTransaction && totalCash - float quantity * asset.Bid > minCash) then
                            asset.Quantity <- asset.Quantity + quantity
                            totalCash <- totalCash - float quantity * asset.Bid
                            printfn "Replying with Notification:\nSold %d units of %s at price $%f. Total sale $%f."
                                    quantity asset.AssetCode asset.Bid (asset.Bid * float quantity)
                            printfn "Marketmaker balance: $%10.2f" totalCash
                            replyChannel.Reply(Notify(Sell(asset.AssetCode, quantity)))
                        else
                            printfn "Insufficient cash to fulfill order for %d units of %s."
                                    quantity asset.AssetCode
                            replyChannel.Reply(Failure("Insufficient cash to cover order."))
                    | None -> replyChannel.Reply(Failure("Asset code not found."))
            do! Loop()
        }
    Loop())

marketMaker.Start()

// Query price.
let reply1 = marketMaker.PostAndReply(fun replyChannel -> 
    printfn "Posting message for AAA"
    Query("AAA", replyChannel))
    
// Test Buy Order.
let reply2 = marketMaker.PostAndReply(fun replyChannel -> 
    printfn "Posting message for BBB"
    Order(Buy("BBB", 100), replyChannel))

// Test Sell Order.
let reply3 = marketMaker.PostAndReply(fun replyChannel -> 
    printfn "Posting message for CCC"
    Order(Sell("CCC", 100), replyChannel))

// Test incorrect code.
let reply4 = marketMaker.PostAndReply(fun replyChannel -> 
    printfn "Posting message for WrongCode"
    Order(Buy("WrongCode", 100), replyChannel))

// Test too large a number of shares.

let reply5 = marketMaker.PostAndReply(fun replyChannel ->
    printfn "Posting message with large number of shares of AAA."
    Order(Buy("AAA", 1000000000), replyChannel))

// Too large an amount of money for one transaction.

let reply6 = marketMaker.PostAndReply(fun replyChannel ->
    printfn "Posting message with too large of a monetary amount."
    Order(Sell("AAA", 100000000), replyChannel))

let random = new Random()
let nextTransaction() =
    let buyOrSell = random.Next(2)
    let asset = assets.[random.Next(3)]
    let quantity = Array.init 3 (fun _ -> random.Next(1000)) |> Array.sum
    match buyOrSell with
    | n when n % 2 = 0 -> Buy(asset.AssetCode, quantity)
    | _ -> Sell(asset.AssetCode, quantity)

let simulateOne() =
   async {
       let! reply = marketMaker.PostAndAsyncReply(fun replyChannel ->
           let transaction = nextTransaction()
           match transaction with
           | Buy(assetCode, quantity) -> printfn "Posting BUY %s %d." assetCode quantity
           | Sell(assetCode, quantity) -> printfn "Posting SELL %s %d." assetCode quantity
           Order(transaction, replyChannel))
       printfn "%s" (reply.ToString())
    }

let simulate =
    async {
        while (true) do
            do! simulateOne()
            // Insert a delay so that you can see the results more easily.
            do! Async.Sleep(1000)
    }

Async.Start(simulate)

Console.WriteLine("Press any key...")
Console.ReadLine() |> ignore