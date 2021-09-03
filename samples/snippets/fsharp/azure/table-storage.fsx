open System
open Azure
open Azure.Data.Tables // Namespace for Table storage types
open System.Linq
open System.Collections.Generic

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account

//
// Create the Table service client.
//

// Create the table client.
let tableClient = TableServiceClient(storageConnString)

//
// Create a table.
//

// Retrieve a reference to the table.
let table = tableClient.GetTableClient("people")

// Create the table if it doesn't exist.
ignore(table.CreateIfNotExists())

//
// Add an entity to a table. The last name is used as a partition key.
//

type Customer(firstName, lastName, email: string, phone: string) =
    interface ITableEntity with
        member this.ETag
            with get (): ETag = 
                raise (System.NotImplementedException())
            and set (v: ETag): unit = 
                raise (System.NotImplementedException())
        member this.PartitionKey
            with get (): string = 
                raise (System.NotImplementedException())
            and set (v: string): unit = 
                raise (System.NotImplementedException())
        member this.RowKey
            with get (): string = 
                raise (System.NotImplementedException())
            and set (v: string): unit = 
                raise (System.NotImplementedException())
        member this.Timestamp
            with get (): Nullable<DateTimeOffset> = 
                raise (System.NotImplementedException())
            and set (v: Nullable<DateTimeOffset>): unit = 
                raise (System.NotImplementedException())
    new() = Customer(null, null, null, null)
    member val Email = email with get, set
    member val PhoneNumber = phone with get, set
    member val PartitionKey = lastName with get, set
    member val RowKey = firstName with get, set

let customer = Customer("Walter", "Harp", "Walter@contoso.com", "425-555-0101")
ignore(table.AddEntity(customer))

//
// Insert a batch of entities. All must have the same partition key.
//

let customer1 =
    Customer("Jeff", "Smith", "Jeff@contoso.com", "425-555-0102")

let customer2 =
    Customer("Ben", "Smith", "Ben@contoso.com", "425-555-0103")

let entityList = [ customer1; customer2]

// Create the batch.
let addEntitiesBatch = List<TableTransactionAction>()

// Add the entities to be added to the batch.
addEntitiesBatch.AddRange(entityList.Select(fun e -> TableTransactionAction(TableTransactionActionType.Add, e)))

// Submit the batch.
let response = table.SubmitTransactionAsync(addEntitiesBatch).ConfigureAwait(false)

//
// Retrieve all entities in a partition.
//

let results = table.Query<Customer>("PartitionKey eq 'Smith'")

for customer in results do 
    printfn $"customer: {customer.RowKey} {customer.PartitionKey}"

//
// Retrieve a range of entities in a partition.
//

let rangeResult = table.Query<Customer>("PartitionKey eq 'Smith' and RowKey lt 'M'")

for customer in rangeResult do 
    printfn $"customer: {customer.RowKey} {customer.PartitionKey}"

//
// Retrieve a single entity.
//

let singleResult = table.GetEntityAsync<Customer>("Smith", "Ben").Result.Value

// Show the result
printfn $"customer: {singleResult.RowKey} {singleResult.PartitionKey}"

//
// Update an entity.
//

try
    singleResult.PhoneNumber <- "425-555-0103"
    ignore(table.UpdateEntity(singleResult, new ETag("etag"), TableUpdateMode.Replace))
    Console.WriteLine("Update succeeeded")
with e ->
    Console.WriteLine("Update failed")

//
// Upsert an entity.
//

try
    singleResult.PhoneNumber <- "425-555-0104"
    ignore(table.UpsertEntity(singleResult, TableUpdateMode.Replace))
    Console.WriteLine("Update succeeeded")
with e ->
    Console.WriteLine("Update failed")

//
// Query a subset of entity properties.
//

let subsetResults = query{
    for customer in table.Query<Customer>() do 
    select customer.Email
}

//
// Retrieve entities in pages asynchronously.
//

let pagesResults = table.Query<Customer>()

for page in pagesResults.AsPages() do 
    printfn "This is a new page!" 
    for qEntity in page.Values do
        printfn $"customer: {qEntity.RowKey} {qEntity.PartitionKey}"

//
// Delete an entity.
//

ignore(table.DeleteEntity("Smith", "Ben"))

//
// Delete a table.
//

ignore(table.Delete())
