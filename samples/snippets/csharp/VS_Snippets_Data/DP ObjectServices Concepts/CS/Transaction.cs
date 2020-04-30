//<snippetEnlistTransaction>
using System;
using System.Linq;
using System.Data;
using System.Data.Objects;
using System.Messaging;
using System.Transactions;

namespace ObjectServicesConceptsCS
{
    class TransactionSample
    {
        public static void EnlistTransaction()
        {
            int retries = 3;
            string queueName = @".\Fulfilling";

            // Define variables that we need to add an item.
            short quantity = 2;
            int productId = 750;
            int orderId = 43680;

            // Define a long-running object context.
            AdventureWorksEntities context
                = new AdventureWorksEntities();

            bool success = false;

            // Wrap the operation in a retry loop.
            for (int i = 0; i < retries; i++)
            {
                // Define a transaction scope for the operations.
                using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        // Define a query that returns a order by order ID.
                        SalesOrderHeader order =
                        context.SalesOrderHeaders.Where
                        ("it.SalesOrderID = @id", new ObjectParameter(
                         "id", orderId)).First();

                        // Load items for the order, if not already loaded.
                        if (!order.SalesOrderDetails.IsLoaded)
                        {
                            order.SalesOrderDetails.Load();
                        }

                        // Load the customer, if not already loaded.
                        if (!order.ContactReference.IsLoaded)
                        {
                            order.ContactReference.Load();
                        }

                        // Create a new item for an existing order.
                        SalesOrderDetail newItem = SalesOrderDetail.CreateSalesOrderDetail(
                            0, 0, quantity, productId, 1, 0, 0, 0, Guid.NewGuid(), DateTime.Today);

                        // Add new item to the order.
                        order.SalesOrderDetails.Add(newItem);

                        // Save changes pessimistically. This means that changes
                        // must be accepted manually once the transaction succeeds.
                        context.SaveChanges(SaveOptions.DetectChangesBeforeSave);

                        // Create the message queue if it does not already exist.
                        if (!MessageQueue.Exists(queueName))
                        {
                            MessageQueue.Create(queueName);
                        }

                        // Initiate fulfilling order by sending a message.
                        using (MessageQueue q = new MessageQueue(queueName))
                        {
                            System.Messaging.Message msg =
                                new System.Messaging.Message(String.Format(
                                    "<order customerId='{0}'>" +
                                    "<orderLine product='{1}' quantity='{2}' />" +
                                    "</order>", order.Contact.ContactID,
                                newItem.ProductID, newItem.OrderQty));

                            // Send the message to the queue.
                            q.Send(msg);
                        }

                        // Mark the transaction as complete.
                        transaction.Complete();
                        success = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        // Handle errors and deadlocks here and retry if needed.
                        // Allow an UpdateException to pass through and
                        // retry, otherwise stop the execution.
                        if (ex.GetType() != typeof(UpdateException))
                        {
                            Console.WriteLine("An error occurred. "
                                + "The operation cannot be retried."
                                + ex.Message);
                            break;
                        }
                        // If we get to this point, the operation will be retried.
                    }
                }
            }
            if (success)
            {
                // Reset the context since the operation succeeded.
                context.AcceptAllChanges();
            }
            else
            {
                Console.WriteLine("The operation could not be completed in "
                    + retries + " tries.");
            }

            // Dispose the object context.
            context.Dispose();
        }
    }
}
//</snippetEnlistTransaction>
