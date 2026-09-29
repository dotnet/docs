module RecordComposition

// <Quantity>
type PositiveQuantity = private PositiveQuantity of int

module PositiveQuantity =
    let create value =
        if value > 0 then Ok (PositiveQuantity value)
        else Error "Quantity must be positive."

    let value (PositiveQuantity value) = value
// </Quantity>

// <Strengthen>
type OrderLine =
    { ProductCode: string
      Quantity: int
      UnitPrice: decimal }

type ValidatedOrderLine =
    { ...OrderLine
      Quantity: PositiveQuantity }

let validateLine (line: OrderLine) =
    PositiveQuantity.create line.Quantity
    |> Result.map (fun quantity ->
        ({ ...line; Quantity = quantity }: ValidatedOrderLine))
// </Strengthen>

// <ValidationUse>
let request: OrderLine =
    { ProductCode = "BK-42"; Quantity = 3; UnitPrice = 12.50m }

let total =
    validateLine request
    |> Result.map (fun line ->
        decimal (PositiveQuantity.value line.Quantity) * line.UnitPrice)

printfn "%A" total
printfn "%A" (validateLine { ...request; Quantity = 0 })
// Ok 37.50M
// Error "Quantity must be positive."
// </ValidationUse>

// <Compose>
type Product =
    { ProductCode: string
      Name: string
      UnitPrice: decimal }

type Inventory = { Available: int; Warehouse: string }

type Listing =
    { ...Product
      ...Inventory
      CanOrder: bool }

let product: Product =
    { ProductCode = "BK-42"; Name = "Notebook"; UnitPrice = 12.50m }
let inventory = { Available = 8; Warehouse = "North" }

let listing: Listing =
    { ...product; ...inventory; CanOrder = inventory.Available > 0 }
// </Compose>

// <Project>
type PriceLabel = { Name: string; UnitPrice: decimal }

let sale: Listing = { ...listing; UnitPrice = 10.00m }
let label: PriceLabel = { ...sale }
let display = {| ...label; Currency = "EUR" |}

printn $"{display.Name}: {display.UnitPrice:F2} {display.Currency}"
// Notebook: 10.00 EUR
// </Project>

let verify () =
    if total <> Ok 37.50m then failwith "Validated total"
    match validateLine request with
    | Ok line when line.ProductCode = "BK-42" && line.UnitPrice = 12.50m -> ()
    | result -> failwithf "Field preservation: %A" result
    for quantity in [0; -1] do
        match validateLine { ...request; Quantity = quantity } with
        | Error "Quantity must be positive." -> ()
        | result -> failwithf "Invalid quantity accepted: %A" result
    if listing.Available <> 8 || listing.Warehouse <> "North" || not listing.CanOrder then
        failwith "Composition"
    if label.Name <> "Notebook" || label.UnitPrice <> 10.00m || listing.UnitPrice <> 12.50m then
        failwith "Projection or immutable override"
