#r "nuget:Azure.Data.Tables" // Load the Azure Data Tables nuget package

open System
open Azure
open Azure.Data.Tables // Namespace for Table storage types

//
// Get your connection string.
//

let storageConnString = "UseDevelopmentStorage=true" // fill this in from your storage account

//
// Create the Table service client.
//

// Create the table client.
let tableClient = TableServiceClient storageConnString

//
// Create a table.
//

// Retrieve a reference to the table.
let table = tableClient.GetTableClient "people"

// Create the table if it doesn't exist.
table.CreateIfNotExists() |> ignore

//
// Add an entity to a table. The last name is used as a partition key.
//

type Customer(firstName, lastName, email: string, phone: string) =
    interface ITableEntity with
        member val ETag = ETag "" with get, set
        member val PartitionKey = "" with get, set
        member val RowKey = "" with get, set
        member val Timestamp = Nullable() with get, set

    new() = Customer(null, null, null, null)
    member val Email = email with get, set
    member val PhoneNumber = phone with get, set
    member val PartitionKey = lastName with get, set
    member val RowKey = firstName with get, set

let customer = Customer("Walter", "Harp", "Walter@contoso.com", "425-555-0101")
table.AddEntity customer |> ignore

//
// Insert a batch of entities. All must have the same partition key.
//

let customers =
    [
        Customer("Jeff", "Smith", "Jeff@contoso.com", "425-555-0102")
        Customer("Ben", "Smith", "Ben@contoso.com", "425-555-0103")
    ]

// Add the entities to be added to the batch and submit it in a transaction.
let response =
    customers
    |> List.map (fun customer -> TableTransactionAction(TableTransactionActionType.Add, customer))
    |> table.SubmitTransaction

//
// Retrieve all entities in a partition.
//

let results = table.Query<Customer>("PartitionKey eq 'Smith'")

for customer in results do
    printfn $"customer: {customer.RowKey} {customer.PartitionKey}"

//
// Retrieve a range of entities in a partition.
//

let rangeResult = table.Query<Customer>("PartitionKey eq 'Smith' and RowKey lt 'J'")

for customer in rangeResult do
    printfn $"customer: {customer.RowKey} {customer.PartitionKey}"

//
// Retrieve a single entity.
//

let singleResult = table.GetEntity<Customer>("Smith", "Ben").Value

// Show the result
printfn $"customer: {singleResult.RowKey} {singleResult.PartitionKey}"

//
// Update an entity.
//

try
    singleResult.PhoneNumber <- "425-555-0103"
    table.UpdateEntity(singleResult, ETag "etag", TableUpdateMode.Replace) |> ignore
    printfn "Update succeeeded"
with e ->
    printfn "Update failed"

//
// Upsert an entity.
//

try
    singleResult.PhoneNumber <- "425-555-0104"
    table.UpsertEntity(singleResult, TableUpdateMode.Replace) |> ignore
    printfn "Update succeeeded"
with e ->
    printfn "Update failed"

//
// Query a subset of entity properties.
//

let subsetResults =
    query {
        for customer in table.Query<Customer>() do
        select customer.Email
    } |> Seq.toArray

//
// Retrieve entities in pages asynchronously.
//

let pagesResults = table.Query<Customer>()

for page in pagesResults.AsPages() do
    printfn "This is a new page!"
    for customer in page.Values do
        printfn $"customer: {customer.RowKey} {customer.PartitionKey}"

//
// Delete an entity.
//

table.DeleteEntity("Smith", "Ben")

//
// Delete a table.
//

table.Delete()
