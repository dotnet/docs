let initialBalance = 1122.73
let transactions = [| -100.00; +450.34; -62.34; -127.00; -13.50; -12.92 |]
let balances =
    Array.scan (fun balance transactionAmount -> balance + transactionAmount) initialBalance transactions
printfn "Initial balance:\n $%10.2f" initialBalance
printfn "Transaction   Balance"
for i in 0 .. Array.length transactions - 1 do
    printfn "$%10.2f $%10.2f" transactions.[i] balances.[i]
printfn "Final balance:\n $%10.2f" balances.[ Array.length balances - 1]