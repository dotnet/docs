open System
open System.IO
open Microsoft.Azure // Namespace for CloudConfigurationManager
open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
open Microsoft.WindowsAzure.Storage.Table // Namespace for Table storage types

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account

// Parse the connection string and return a reference to the storage account.
let storageConnString = 
    CloudConfigurationManager.GetSetting("StorageConnectionString")

//
// Parse the connection string.
//

// Parse the connection string and return a reference to the storage account.
let storageAccount = CloudStorageAccount.Parse(storageConnString)

//
// Create the Table service client.
//

// Create the table client.
let tableClient = storageAccount.CreateCloudTableClient()

//
// Create a table.
//

// Retrieve a reference to the table.
let table = tableClient.GetTableReference("people")

// Create the table if it doesn't exist.
table.CreateIfNotExists()

//
// Add an entity to a table.
//

type Customer
    (firstName, lastName, email: string, phone: string) =
    inherit TableEntity(lastName, firstName)
    new() = Customer(null, null, null, null)
    member val Email = email with get, set
    member val PhoneNumber = phone with get, set

let customer = 
    Customer("Larry", "Buster", "larry@example.com", "425-555-0101")

let insertOp = TableOperation.Insert(customer)
table.Execute(insertOp)

//
// Insert a batch of entities.
//

let customer2 =
    Customer("Bob", "Boomer", "bob@example.com", "425-555-0102")

let batchOp = TableBatchOperation()
batchOp.Insert(customer)
batchOp.Insert(customer2)
table.ExecuteBatch(batchOp)

//
// Retreive all entities in a partition.
//

let query =
    TableQuery<Customer>().Where(
        TableQuery.GenerateFilterCondition(
            "PartitionKey", QueryComparisons.Equal, "Buster"))

let result = table.ExecuteQuery(query)

//
// Retrieve a range of entities in a partition.
//

let range =
    TableQuery<Customer>().Where(
        TableQuery.CombineFilters(
            TableQuery.GenerateFilterCondition(
                "PartitionKey", QueryComparisons.Equal, "Buster"),
            TableOperators.And,
            TableQuery.GenerateFilterCondition(
                "RowKey", QueryComparisons.LessThan, "M")))

let rangeResult = table.ExecuteQuery(query)

//
// Retrieve a single entity.
//

let retrieveOp = TableOperation.Retrieve<Customer>("Buster", "Larry")
let retrieveResult = table.Execute(retrieveOp)

//
// Replace an entity.
//

try
    let customer = retrieveResult.Result :?> Customer
    customer.PhoneNumber <- "425-555-0103"
    let replaceOp = TableOperation.Replace(customer)
    table.Execute(replaceOp) |> ignore
with e ->
    Console.WriteLine("Update failed")

//
// Insert-or-update an entity.
//

try
    customer.PhoneNumber <- "425-555-0104"
    let replaceOp = TableOperation.InsertOrReplace(customer)
    table.Execute(replaceOp) |> ignore
with e ->
    Console.WriteLine("Update failed")

//
// Query a subset of entity properties.
//

// Define the query, and select only the Email property.
let projectionQ = TableQuery<DynamicTableEntity>().Select([|"Email"|])

// Define an entity resolver to work with the entity after retrieval.
let resolver = EntityResolver<string>(fun pk rk ts props etag ->
    if props.ContainsKey("Email") then
        props.["Email"].StringValue
    else
        null
    )

table.ExecuteQuery(projectionQ, resolver, null, null)

//
// Delete an entity.
//

let deleteOp = TableOperation.Delete(customer)
table.Execute(deleteOp)

//
// Delete a table.
//

table.DeleteIfExists()

//
// Retrieve entities in pages asynchronously.
//

let tableQ = TableQuery<Customer>()

async {
    let rec q (cont: TableContinuationToken) = async {
        let! result = 
            table.ExecuteQuerySegmentedAsync(tableQ, cont) 
            |> Async.AwaitTask

        // Process the result here.
        match result.ContinuationToken with
        | null -> return ()
        | cont -> q cont |> Async.RunSynchronously
    }
    q null |> Async.RunSynchronously
} |> Async.RunSynchronously
