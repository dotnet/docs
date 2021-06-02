open Azure.Storage.Queues // Namespace for Queue storage types
open System

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
// Create the Queue Service client.
//

// Instantiate a QueueClient which will be used to create and manipulate the queue
let queueClient = new QueueClient(storageConnString, "myqueue");

//
// Create a queue.
//

// Create the queue if it doesn't already exist
queueClient.CreateIfNotExists()

//
// Insert a message into a queue.
//

// Send a message to the queue
queueClient.SendMessage("Hello, World")

//
// Peek at the next message.
//

let peekedMessage = queueClient.PeekMessage()
let messageContents = peekedMessage.ToString()

//
// Get the next message.
//

// Get the next message. Successful processing must be indicated via DeleteMessage later.
let updateMessage = queueClient.ReceiveMessage().Value

//
// Change the contents of a retrieved message.
//

// Update the message contents and set a new timeout.
queueClient.UpdateMessage(
    updateMessage.MessageId,
    updateMessage.PopReceipt,
    "Updated contents.",
    TimeSpan.FromSeconds(60.0))

//
// De-queue the next message, indicating successful processing
//

// Process the message in less than 30 seconds, and then delete the message.
let delMessage = queueClient.ReceiveMessage().Value
queueClient.DeleteMessage(delMessage.MessageId, delMessage.PopReceipt)

//
// Use Async-Await pattern with common Queue storage APIs.
//

async {
    let! exists = queueClient.CreateIfNotExistsAsync() |> Async.AwaitTask

    let! delAsyncMessage = queueClient.ReceiveMessageAsync() |> Async.AwaitTask

    // ... process the message here ...

    // Now indicate successful processing:
    queueClient.DeleteMessageAsync(delAsyncMessage.Value.MessageId, delAsyncMessage.Value.PopReceipt) |> Async.AwaitTask
}

//
// Additional options for de-queuing messages.
//

for dequeueMessage in queueClient.ReceiveMessages(20, Nullable(TimeSpan.FromMinutes(5.))).Value do
        // Process the message here.
        queueClient.DeleteMessage(dequeueMessage.MessageId, dequeueMessage.PopReceipt)

//
// Get the queue length.
//

let properties = queueClient.GetProperties().Value
let count = properties.ApproximateMessagesCount

//
// Delete a queue.
//

queueClient.Delete()
