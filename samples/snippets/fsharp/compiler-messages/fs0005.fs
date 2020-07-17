(* simple mutable assignment of immutable record field example  *)
type Food =  { Kind: string
               DaysOld: int }

let apple = { Kind = "apple"
              DaysOld = 10 }

apple.Kind <- "orange"

(* solving the problem by making the field mutable *)
type Food =  { mutable Kind: string
               DaysOld: int }

let apple = { Kind = "apple"
              DaysOld = 10 }

apple.Kind <- "orange"

(* solving the problem by immutable update *)
type Food =  { Kind: string
               DaysOld: int }

let apple = { Kind = "apple"
              DaysOld = 10 }

let orange = { apple with Kind = "orange" }
