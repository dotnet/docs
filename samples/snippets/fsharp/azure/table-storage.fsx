// <nuget>
#r "nuget:Azure.Data.Tables" // Load the Azure Data Tables nuget package
// </nuget>

// <open>
open System
open Azure
open Azure.Data.Tables // Namespace for Table storage types
// </open>

//
// Get your connection string.
//
// <connection-string>
let storageConnString = "UseDevelopmentStorage=true" // fill this in from your storage account
// </connection-string>

//
// Create the Table service client.
//
// <create-table-client>
let tableClient = TableServiceClient storageConnString
// </create-table-client>

//
// Create a table.
//
// <create-table>
// Retrieve a reference to the table.
let table = tableClient.GetTableClient "people"

// Create the table if it doesn't exist.
table.CreateIfNotExists () |> ignore
// </create-table>

//
// Add an entity to a table. The last name is used as a partition key.
//

// Note: In F#, interfaces are implemented explicitly. The Azure Storage SDK
// expects at least PartitionKey and RowKey to be implicitly available. Therefore,
// we have to "shadow" both PartitionKey and RowKey on the Customer type directly.
// <add-entity>
type Customer (firstName, lastName, email: string, phone: string) =
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
// </add-entity>

// <add-entity-to-table>
let customer = Customer ("Walter", "Harp", "Walter@contoso.com", "425-555-0101")
table.AddEntity customer
// </add-entity-to-table>

//
// Insert a batch of entities. All must have the same partition key.
//
// <add-batch-of-entities>
let customers =
    [
        Customer("Jeff", "Smith", "Jeff@contoso.com", "425-555-0102")
        Customer("Ben", "Smith", "Ben@contoso.com", "425-555-0103")
    ]

// Add the entities to be added to the batch and submit it in a transaction.
customers
|> List.map (fun customer -> TableTransactionAction (TableTransactionActionType.Add, customer))
|> table.SubmitTransaction
// </add-batch-of-entities>

//
// Retrieve all entities in a partition.
//
// <retrieve-entities>
table.Query<Customer> "PartitionKey eq 'Smith'"
// </retrieve-entities>

//
// Retrieve a range of entities in a partition.
//
// <retrieve-entities-range>
table.Query<Customer> "PartitionKey eq 'Smith' and RowKey lt 'J'"
// </retrieve-entities-range>

//
// Retrieve a single entity.
//
// <retrieve-entity>
let singleResult = table.GetEntity<Customer>("Smith", "Ben").Value
// </retrieve-entity>

// <print-entity>
// Evaluate this value to print it out into the F# Interactive console
singleResult
// </print-entity>

//
// Update an entity and show how to handle any exceptions that Azure may throw.
//
// <update-entity>
singleResult.PhoneNumber <- "425-555-0103"
try
    table.UpdateEntity (singleResult, ETag "", TableUpdateMode.Replace) |> ignore
    printfn "Update succeeded"
with
| :? RequestFailedException as e ->
    printfn $"Update failed: {e.Status} - {e.ErrorCode}"
// </update-entity>

//
// Upsert an entity.
//
// <upsert-entity>
singleResult.PhoneNumber <- "425-555-0104"
table.UpsertEntity (singleResult, TableUpdateMode.Replace)
// </upsert-entity>

//
// Query a subset of entity properties.
//
// <query-subset>
query {
    for customer in table.Query<Customer> () do
    select customer.Email
}
// </query-subset>

//
// Retrieve entities in pages asynchronously.
//
// <retrieve-entities-async>
let pagesResults = table.Query<Customer> ()

for page in pagesResults.AsPages () do
    printfn "This is a new page!"
    for customer in page.Values do
        printfn $"customer: {customer.RowKey} {customer.PartitionKey}"
// </retrieve-entities-async>

//
// Delete an entity.
//
// <delete-entity>
table.DeleteEntity ("Smith", "Ben")
// </delete-entity>

//
// Delete a table.
//
// <delete-table>
table.Delete ()
// </delete-table>
