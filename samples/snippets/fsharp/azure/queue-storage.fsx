open Microsoft.Azure // Namespace for CloudConfigurationManager 
open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
open Microsoft.WindowsAzure.Storage.Queue // Namespace for Queue storage types

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
// Change the contents of a queued message.
//

// Update the message contents and set a new timeout.
message.SetMessageContent("Updated contents.")
queue.UpdateMessage(message,
    TimeSpan.FromSeconds(60.0),
    MessageUpdateFields.Content ||| MessageUpdateFields.Visibility)

//
// De-queue the next message.
//

// Process the message in less than 30 seconds, and then delete the message.
queue.DeleteMessage(message)

//
// Use Async-Await pattern with common Queue storage APIs.
//

async {
    let! exists = queue.CreateIfNotExistsAsync() |> Async.AwaitTask
    let msg = new CloudQueueMessage("My message")
    queue.AddMessageAsync(msg) |> Async.AwaitTask
    let! retrieved = queue.GetMessageAsync() |> Async.AwaitTask
    queue.DeleteMessageAsync(retrieved) |> Async.AwaitTask
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
