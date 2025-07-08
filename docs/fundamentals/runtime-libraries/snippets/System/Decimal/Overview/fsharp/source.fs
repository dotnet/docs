module snippets

open System

module snippet1 =
    //<snippet1>
    /// Keeping my fortune in Decimals to avoid the round-off errors.
    type PiggyBank() =
        let mutable myFortune = 0m

        member _.AddPenny() =
            myFortune <- Decimal.Add(myFortune, 0.01m)

        member _.Capacity =
            Decimal.MaxValue

        member _.Dollars =
            Decimal.Floor myFortune

        member _.Cents =
            Decimal.Subtract(myFortune, Decimal.Floor myFortune)

        override _.ToString() =
            $"{myFortune:C} in piggy bank"
    //</snippet1>

module snippet2 =
    //<snippet2>
    type PiggyBank() =
        let mutable myFortune = 0m

        member _.Capacity =
            Decimal.MaxValue

        member _.AddPenny() =
            myFortune <- myFortune + 0.01m
    //</snippet2>

module snippet3 =
    //<snippet3>
    type PiggyBank() =
        let mutable myFortune = 0m

        member _.Dollars =
            Decimal.Floor myFortune

        member _.AddPenny() =
            myFortune <- myFortune + 0.01m
    //</snippet3>

module snippet4 =
    //<snippet4>
    type PiggyBank() =
        let mutable myFortune = 0m

        member _.Cents =
            Decimal.Subtract(myFortune, Decimal.Floor myFortune)

        member _.AddPenny() =
            myFortune <- myFortune + 0.01m
    //</snippet4>

module snippet5 =
    //<snippet5>
    type PiggyBank() =
        let mutable myFortune = 0m

        member _.AddPenny() =
            myFortune <- Decimal.Add(myFortune, 0.01m)

        override _.ToString() =
            $"{myFortune:C} in piggy bank"
    //</snippet5> 