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

let queueClient = new QueueClient(storageConnString, "myqueue");
queueClient.CreateIfNotExists()

//
// Insert a message into a queue.
//

// Create a message and add it to the queue.
let message = "Hello, World"
queueClient.SendMessage(message)

//
// Peek at the next message.
//

// Peek at the next message.
let peekedMessage = queueClient.PeekMessage()
let msgToString = peekedMessage.ToString()

//
// Get the next message.
//

// Get the next message. Successful processing must be indicated via DeleteMessage later.
let retrieved = queueClient.ReceiveMessage()

//
// Change the contents of a retrieved message.
//

// Update the message contents and set a new timeout.
queueClient.UpdateMessage(
    retrieved.Value.MessageId,
    retrieved.Value.PopReceipt,
    "Updated contents.",
    TimeSpan.FromSeconds(60.0))

//
// De-queue the next message, indicating successful processing
//

// Process the message in less than 30 seconds, and then delete the message.
queueClient.DeleteMessage(retrieved.Value.MessageId, retrieved.Value.PopReceipt)

//
// Use Async-Await pattern with common Queue storage APIs.
//

async {
    let! exists = queueClient.CreateIfNotExistsAsync() |> Async.AwaitTask

    let! receipt = queueClient.ReceiveMessageAsync() |> Async.AwaitTask

    // ... process the message here ...

    // Now indicate successful processing:
    queueClient.DeleteMessageAsync(receipt.Value.MessageId, receipt.Value.PopReceipt) |> Async.AwaitTask
}

//
// Additional options for de-queuing messages.
//

for msg in queueClient.ReceiveMessages(20, Nullable(TimeSpan.FromMinutes(5.))).Value do
        // Process the message here.
        queueClient.DeleteMessage(msg.MessageId, msg.PopReceipt)

//
// Get the queue length.
//

let properties = queueClient.GetProperties().Value
let count = properties.ApproximateMessagesCount

//
// Delete a queue.
//

// Delete the queue.
queueClient.Delete()
