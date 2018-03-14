open Microsoft.Azure // Namespace for CloudConfigurationManager 
open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
open Microsoft.WindowsAzure.Storage.Queue // Namespace for Queue storage types

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account
(*
// Parse the connection string and return a reference to the storage account.
let storageConnString = 
    CloudConfigurationManager.GetSetting("StorageConnectionString")
*)
//
// Parse the connection string.
//

// Parse the connection string and return a reference to the storage account.
let storageAccount = CloudStorageAccount.Parse(storageConnString)

//
// Create the Queue Service client.
//

let queueClient = storageAccount.CreateCloudQueueClient()

//
// Create a queue.
//

// Retrieve a reference to a container.
let queue = queueClient.GetQueueReference("myqueue")

// Create the queue if it doesn't already exist
queue.CreateIfNotExists()

//
// Insert a message into a queue.
//

// Create a message and add it to the queue.
let message = new CloudQueueMessage("Hello, World")
queue.AddMessage(message)

//
// Peek at the next message.
//

// Peek at the next message.
let peekedMessage = queue.PeekMessage()
let msgAsString = peekedMessage.AsString

//
// Get the next message.
//

// Get the next message. Successful processing must be indicated via DeleteMessage later.
let retrieved = queue.GetMessage()

//
// Change the contents of a retrieved message.
//

// Update the message contents and set a new timeout.
retrieved.SetMessageContent("Updated contents.")
queue.UpdateMessage(retrieved,
    TimeSpan.FromSeconds(60.0),
    MessageUpdateFields.Content ||| MessageUpdateFields.Visibility)

//
// De-queue the next message, indicating successful processing
//

// Process the message in less than 30 seconds, and then delete the message.
queue.DeleteMessage(retrieved)

//
// Use Async-Await pattern with common Queue storage APIs.
//

async {
    let! exists = queue.CreateIfNotExistsAsync() |> Async.AwaitTask

    let! retrieved = queue.GetMessageAsync() |> Async.AwaitTask

    // ... process the message here ...

    // Now indicate successful processing:
    do! queue.DeleteMessageAsync(retrieved) |> Async.AwaitTask
}

//
// Additional options for de-queuing messages.
//

for msg in queue.GetMessages(20, Nullable(TimeSpan.FromMinutes(5.))) do
        // Process the message here.
        queue.DeleteMessage(msg)

//
// Get the queue length.
//

queue.FetchAttributes()
let count = queue.ApproximateMessageCount.GetValueOrDefault()

//
// Delete a queue.
//

// Delete the queue.
queue.Delete()
