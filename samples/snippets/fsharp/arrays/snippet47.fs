type Transaction =
    | Deposit
    | Withdrawal

let transactionTypes = [| Deposit; Deposit; Withdrawal |]
let transactionAmounts = [| 100.00; 1000.00; 95.00 |]
let initialBalance = 200.00

let endingBalance = Array.foldBack2 (fun elem1 elem2 acc ->
                        match elem1 with
                        | Deposit -> acc + elem2
                        | Withdrawal -> acc - elem2)
                        transactionTypes
                        transactionAmounts
                        initialBalance
printfn "Ending balance: $%.2f" endingBalance