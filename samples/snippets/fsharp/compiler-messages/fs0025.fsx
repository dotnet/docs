(* declaration and construction of Discriminated Union *)
type Faucet =
| Hot
| Cold

let faucet = Hot

(* complete match expression on Discriminated Union *)
let completeFaucetString =
    match faucet with
    | Hot -> "Hot"
    | Cold -> "Cold"

(* incomplete match expression on Discriminated Union *)
let incompleteFaucetString =
    match faucet with
    | Hot -> "Hot"

(* wildcard match expression on Discriminated Union *)
let wildcardFaucetString =
    match faucet with
    | Hot -> "Hot"
    | _ -> "Other"
