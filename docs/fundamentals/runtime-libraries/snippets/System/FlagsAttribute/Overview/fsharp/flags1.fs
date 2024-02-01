module flags1

// <Snippet2>
open System

[<Flags>]
type PhoneService =
    | None = 0
    | LandLine = 1
    | Cell = 2
    | Fax = 4
    | Internet = 8
    | Other = 16

// Define three variables representing the types of phone service
// in three households.
let household1 = 
    PhoneService.LandLine ||| PhoneService.Cell ||| PhoneService.Internet

let household2 = 
    PhoneService.None

let household3 = 
    PhoneService.Cell ||| PhoneService.Internet

// Store the variables in a list for ease of access.
let households =
    [ household1; household2; household3 ]

// Which households have no service?
for i = 0 to households.Length - 1 do
    printfn $"""Household {i + 1} has phone service: {if households[i] = PhoneService.None then "No" else "Yes"}"""
printfn ""

// Which households have cell phone service?
for i = 0 to households.Length - 1 do
    printfn $"""Household {i + 1} has cell phone service: {if households[i] &&& PhoneService.Cell = PhoneService.Cell then "Yes" else "No"}"""
printfn ""

// Which households have cell phones and land lines?
let cellAndLand = 
    PhoneService.Cell ||| PhoneService.LandLine

for i = 0 to households.Length - 1 do
    printfn $"""Household {i + 1} has cell and land line service: {if households[i] &&& cellAndLand = cellAndLand then "Yes" else "No"}"""
printfn ""

// List all types of service of each household?//
for i = 0 to households.Length - 1 do
    printfn $"Household {i + 1} has: {households[i]:G}"

// The example displays the following output:
//    Household 1 has phone service: Yes
//    Household 2 has phone service: No
//    Household 3 has phone service: Yes
//
//    Household 1 has cell phone service: Yes
//    Household 2 has cell phone service: No
//    Household 3 has cell phone service: Yes
//
//    Household 1 has cell and land line service: Yes
//    Household 2 has cell and land line service: No
//    Household 3 has cell and land line service: No
//
//    Household 1 has: LandLine, Cell, Internet
//    Household 2 has: None
//    Household 3 has: Cell, Internet
// </Snippet2>