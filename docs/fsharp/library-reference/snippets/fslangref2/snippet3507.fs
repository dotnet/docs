
  type Account(accountNumber : int, ?first: string, ?last: string, ?bal : float) =
     let mutable balance = defaultArg bal 0.0
     let mutable number = accountNumber
     let mutable firstName = defaultArg first ""
     let mutable lastName = defaultArg last ""
     member this.AccountNumber
        with get() = number
        and set(value) = number <- value
     member this.FirstName
        with get() = firstName
        and set(value) = firstName <- value
     member this.LastName
        with get() = lastName
        and set(value) = lastName <- value
     member this.Balance
        with get() = balance
        and set(value) = balance <- value
     member this.Deposit(amount: float) = this.Balance <- this.Balance + amount
     member this.Withdraw(amount: float) = this.Balance <- this.Balance - amount
   
   
  let account1 = new Account(8782108, bal = 543.33,
                            FirstName="Raman", LastName="Iyer")