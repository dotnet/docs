
  type Account() =
     let mutable balance = 0.0
     let mutable number = 0
     let mutable firstName = ""
     let mutable lastName = ""
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
    
   
 let account1 = new Account(AccountNumber=8782108, 
                            FirstName="Darren", LastName="Parker",
                            Balance=1543.33)