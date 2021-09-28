open Azure.Storage.Queues // Namespace for Queue storage types
open System
open System.Text

//
// Get your connection string.
//

let storageConnString = "..." // fill this in from your storage account

//
// Create the Queue Service client.
//

let queueClient = QueueClient(storageConnString, "myqueue")

//
// Create a queue.
//

queueClient.CreateIfNotExists()

//
// Insert a message into a queue.
//

queueClient.SendMessage("Hello, World") // Insert a String message into a queue
queueClient.SendMessage(BinaryData.FromBytes(Encoding.UTF8.GetBytes("Hello, World"))) // Insert a BinaryData message into a queue

//
// Peek at the next message.
//

let peekedMessage = queueClient.PeekMessage()
let messageContents = peekedMessage.Value.Body.ToString()

//
// Get the next message.
//

let updateMessage = queueClient.ReceiveMessage().Value

//
// Change the contents of a retrieved message.
//

queueClient.UpdateMessage(
    updateMessage.MessageId,
    updateMessage.PopReceipt,
    "Updated contents.",
    TimeSpan.FromSeconds(60.0))

//
// De-queue the next message, indicating successful processing
//

let deleteMessage = queueClient.ReceiveMessage().Value
queueClient.DeleteMessage(deleteMessage.MessageId, deleteMessage.PopReceipt)

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

queueClient.DeleteIfExists()
