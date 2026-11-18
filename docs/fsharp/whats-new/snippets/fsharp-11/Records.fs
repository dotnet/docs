module RecordComposition

// <Models>
open System

type CustomerId = CustomerId of Guid

type CustomerDetails = { Name: string; PreferredLanguage: string }

type CustomerRow =
    { ...CustomerDetails
      Id: string
      InternalNote: string }

type Customer =
    { ...CustomerDetails
      Id: CustomerId }
// </Models>

// <Mapping>
let toCustomer (row: CustomerRow) =
    match Guid.TryParse row.Id with
    | true, id -> Ok ({ ...row; Id = CustomerId id }: Customer)
    | false, _ -> Error "Invalid customer identifier."
// </Mapping>

// <MappingUse>
let row: CustomerRow =
    { Name = "Ada"; PreferredLanguage = "en"
      Id = "c8d5f799-5d58-4d97-9fd5-481fa799fcb6"
      InternalNote = "Imported from the previous system." }

match toCustomer row with
| Ok customer -> printfn "%s (%s)" customer.Name customer.PreferredLanguage
| Error message -> printfn "%s" message
// Ada (en)
// </MappingUse>

// <Strengthen>
type ImportedCustomer = { Name: string; Id: string }
type IdentifiedCustomer = { ...ImportedCustomer; Id: CustomerId }

let identify (source: ImportedCustomer) =
    match Guid.TryParse source.Id with
    | true, id -> Ok ({ ...source; Id = CustomerId id }: IdentifiedCustomer)
    | false, _ -> Error "Invalid customer identifier."
// </Strengthen>

// <ComposeTypes>
type PublicProductFields = { Name: string; UnitPrice: decimal }
type ProductRow = { ...PublicProductFields; InternalCost: decimal }
type StockCounts = {| InStock: int; Reserved: int |}

type ProductCard =
    { ...PublicProductFields
      ...StockCounts
      CanOrder: bool }
// </ComposeTypes>

// <Compose>
let product: ProductRow =
    { Name = "Notebook"; UnitPrice = 12.50m; InternalCost = 4m }
let stock: StockCounts = {| InStock = 8; Reserved = 2 |}

let card: ProductCard =
    { ...product; ...stock; CanOrder = stock.InStock > stock.Reserved }

let viewState = {| ...card; Selected = false |}
let selected = {| ...viewState; Selected = true |}
// </Compose>

// <Project>
type PriceLabel = { Name: string; UnitPrice: decimal }

let label: PriceLabel = { ...selected }
printfn "%s: %.2f" label.Name label.UnitPrice
// Notebook: 12.50
// </Project>

let verify () =
    match toCustomer row with
    | Ok customer when customer.Name = row.Name &&
                       customer.PreferredLanguage = row.PreferredLanguage &&
                       customer.Id = CustomerId(Guid.Parse row.Id) -> ()
    | result -> failwithf "Customer mapping: %A" result
    if toCustomer { ...row; Id = "not-an-id" } <> Error "Invalid customer identifier." then
        failwith "Invalid identifier accepted"
    if identify { Name = row.Name; Id = row.Id } <>
       Ok { Name = row.Name; Id = CustomerId(Guid.Parse row.Id) } then
        failwith "Replaced field type"
    if card.Name <> product.Name || card.InStock <> 8 || not card.CanOrder then
        failwith "Mixed-source composition"
    if viewState.Selected || not selected.Selected || label.UnitPrice <> 12.50m then
        failwith "Anonymous composition or named projection"
    if typeof<Customer>.GetProperty("InternalNote") <> null ||
       typeof<ProductCard>.GetProperty("InternalCost") <> null then
        failwith "Internal fields escaped the destination"
