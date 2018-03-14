// <Snippet1>
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CSDataIsolationLevel {

   // Use the delegate to call the different threads.
   public delegate void AsyncAccessDatabase(String connString, IsolationLevel level);

   static class DirtyReadThreads {
      public static void DirtyReadFirstThread(String connStrig, IsolationLevel level) {
         Console.WriteLine("Begin the DirtyReadFirstThread.....");

         using (SqlConnection conn = new SqlConnection(connStrig)) {
            String cmdText = @"Use DbDataIsolationLevel; 

                    Update dbo.Products set Quantity=Quantity+100 where ProductId=1;
                    WaitFor Delay '00:00:06';";

            conn.Open();

            using (SqlTransaction tran = conn.BeginTransaction(level, "DirtyReadFirst")) {
               using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                  command.Transaction = tran;
                  command.ExecuteNonQuery();
               }

               if (tran != null)
                  tran.Rollback();
            }
         }

         Console.WriteLine("Exit from the DirtyReadFirstThread.....");
      }

      public static void DirtyReadSecondThread(String connStrig, IsolationLevel level) {
         Console.WriteLine("Begin the DirtyReadSecondThread.....");

         using (SqlConnection conn = new SqlConnection(connStrig)) {
            String cmdText = @"Use DbDataIsolationLevel;

                    WaitFor Delay '00:00:03'; 

                    Declare @qty int;
                    select @qty=Quantity from dbo.Products where ProductId=1;

                    Update dbo.Products set Quantity=@qty+100 where ProductId=1;";

            conn.Open();

            using (SqlTransaction tran = conn.BeginTransaction(level, "DirtyReadSecond")) {
               using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                  command.Transaction = tran;
                  command.ExecuteNonQuery();
               }
               tran.Commit();
            }
         }

         Console.WriteLine("Exit from the DirtyReadSecondThread.....");
      }
   }


   static class NonrepeatableReadThreads {
      public static void NonrepeatableReadFirstThread(String connStrig, IsolationLevel level) {
         Console.WriteLine("Begin the NonrepeatableReadFirstThread.....");

         using (SqlConnection conn = new SqlConnection(connStrig)) {
            String cmdText = @"Use DbDataIsolationLevel; 

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products
                    where ProductId=1

                    WaitFor Delay '00:00:06';

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products
                    where ProductId=1";

            conn.Open();

            using (SqlTransaction tran = conn.BeginTransaction(level, "NonrepeatableReadFirst")) {
               using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                  command.Transaction = tran;

                  using (SqlDataReader reader = command.ExecuteReader()) {
                     Boolean isFirstReader = true;
                     do {
                        Console.WriteLine("It's the result of {0} read:", isFirstReader ? "first" : "second");
                        TransactionIsolationLevels.DisplayData(reader);
                        isFirstReader = !isFirstReader;
                     } while (reader.NextResult() && !isFirstReader);
                  }
               }

               tran.Commit();
            }
         }

         Console.WriteLine("Exit from the NonrepeatableReadFirstThread.....");
      }

      public static void NonrepeatableReadSecondThread(String connStrig, IsolationLevel level) {
         Console.WriteLine("Begin the NonrepeatableReadSecondThread.....");

         using (SqlConnection conn = new SqlConnection(connStrig)) {
            String cmdText = @"Use DbDataIsolationLevel;

                    WaitFor Delay '00:00:03'; 

                    Update dbo.Products set Quantity=Quantity+100 where ProductId=1;";

            conn.Open();

            using (SqlTransaction tran = conn.BeginTransaction(level, "NonrepeatableReadSecond")) {
               using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                  command.Transaction = tran;
                  command.ExecuteNonQuery();
               }
               tran.Commit();
            }
         }

         Console.WriteLine("Exit from the NonrepeatableReadSecondThread.....");
      }
   }


   static class PhantomReadThreads {
      public static void PhantomReadFirstThread(String connStrig, IsolationLevel level) {
         Console.WriteLine("Begin the PhantomReadFirstThread.....");

         using (SqlConnection conn = new SqlConnection(connStrig)) {
            String cmdText = @"Use DbDataIsolationLevel; 

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products

                    WaitFor Delay '00:00:06';

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products";

            conn.Open();

            using (SqlTransaction tran = conn.BeginTransaction(level, "PhantomReadFirst")) {
               using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                  command.Transaction = tran;

                  using (SqlDataReader reader = command.ExecuteReader()) {
                     Boolean isFirstReader = true;
                     do {
                        Console.WriteLine("It's the result of {0} read:", isFirstReader ? "first" : "second");

                        TransactionIsolationLevels.DisplayData(reader);

                        isFirstReader = !isFirstReader;
                     } while (reader.NextResult() && !isFirstReader);
                  }
               }

               tran.Commit();
            }
         }
         Console.WriteLine("Exit from the PhantomReadFirstThread.....");
      }

      public static void PhantomReadSecondThread(String connStrig, IsolationLevel level) {
         Console.WriteLine("Begin the PhantomReadSecondThread.....");

         using (SqlConnection conn = new SqlConnection(connStrig)) {
            String cmdText = @"Use DbDataIsolationLevel;

                    WaitFor Delay '00:00:03'; 

                    INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) 
                    VALUES (N'White Bike', 843, 1349.00)";

            conn.Open();

            using (SqlTransaction tran = conn.BeginTransaction(level, "PhantomReadSecond")) {
               using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                  command.Transaction = tran;
                  command.ExecuteNonQuery();
               }
               tran.Commit();
            }
         }

         Console.WriteLine("Exit from the PhantomReadSecondThread.....");
      }
   }


   // Demonstrates if the specific transaction allows the following behaviors:
   // 1. Dirty reads;
   // 2. Non-repeatable reads;
   // 3. Phantoms.
   static class TransactionIsolationLevels {
      public static void DemonstrateIsolationLevel(String connString, IsolationLevel level) {
         // Before connect the database, recreate the table.
         OperateDatabase.CreateTable(connString);
         DemonstrateIsolationLevel(connString, level, DirtyReadThreads.DirtyReadFirstThread, DirtyReadThreads.DirtyReadSecondThread);
         DisplayData(connString);
         Console.WriteLine();

         OperateDatabase.CreateTable(connString);
         DemonstrateIsolationLevel(connString, level, NonrepeatableReadThreads.NonrepeatableReadFirstThread, NonrepeatableReadThreads.NonrepeatableReadSecondThread);
         Console.WriteLine();

         OperateDatabase.CreateTable(connString);
         DemonstrateIsolationLevel(connString, level, PhantomReadThreads.PhantomReadFirstThread, PhantomReadThreads.PhantomReadSecondThread);
         Console.WriteLine();
      }

      // Demonstrates if the specific transaction allows the specific behaviors.
      public static void DemonstrateIsolationLevel(String connString, IsolationLevel level,
          AsyncAccessDatabase firstThread, AsyncAccessDatabase secondThread) {
         Task[] tasks ={
                            Task.Factory.StartNew(()=>firstThread(connString, level)),
                            Task.Factory.StartNew(()=>secondThread(connString, level))
                        };

         Task.WaitAll(tasks);
      }

      static class ExchangeValuesThreads {
         public static void ExchangeValuesFirstThread(String connStrig, IsolationLevel level) {
            Console.WriteLine("Begin the ExchangeValuesFirstThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig)) {
               String cmdText = @"Use DbDataIsolationLevel;

                    Declare @price money;
                    select @price=Price from dbo.Products where ProductId=2;

                    Update dbo.Products set Price=@price where ProductId=1;

                    WaitFor Delay '00:00:06'; ";

               conn.Open();
               using (SqlTransaction tran = conn.BeginTransaction(level, "ExchangeValuesFirst")) {

                  using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                     command.Transaction = tran;
                     command.ExecuteNonQuery();
                  }

                  tran.Commit();
               }
            }

            Console.WriteLine("Exit from the ExchangeValuesFirstThread.....");
         }

         public static void ExchangeValuesSecondThread(String connStrig, IsolationLevel level) {
            Console.WriteLine("Begin the ExchangeValuesSecondThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig)) {
               String cmdText = @"Use DbDataIsolationLevel;

                    WaitFor Delay '00:00:03'; 

                    Declare @price money;
                    select @price=Price from dbo.Products where ProductId=1;

                    Update dbo.Products set Price=@price where ProductId=2;";

               conn.Open();

               using (SqlTransaction tran = conn.BeginTransaction(level, "ExchangeValuesSecond")) {
                  using (SqlCommand command = new SqlCommand(cmdText, conn)) {
                     command.Transaction = tran;
                     command.ExecuteNonQuery();
                  }
                  tran.Commit();
               }
            }

            Console.WriteLine("Exit from the ExchangeValuesSecondThread.....");
         }
      }

      // Demonstrates the difference between the Serializable and Snapshot transaction
      public static void DemonstrateBetweenSnapshotAndSerializable(String connString) {
         OperateDatabase.CreateTable(connString);

         Console.WriteLine("Exchange Vaules in the Snapshot transaction:");
         DemonstrateIsolationLevel(connString, IsolationLevel.Snapshot,
             ExchangeValuesThreads.ExchangeValuesFirstThread,
             ExchangeValuesThreads.ExchangeValuesSecondThread);
         DisplayData(connString);
         Console.WriteLine();

         Console.WriteLine("Cannot Exchange Vaules in the Serializable transaction:");
         OperateDatabase.CreateTable(connString);
         DemonstrateIsolationLevel(connString, IsolationLevel.Serializable,
             ExchangeValuesThreads.ExchangeValuesFirstThread,
             ExchangeValuesThreads.ExchangeValuesSecondThread);
         DisplayData(connString);
      }

      public static void DisplayData(String connString) {
         using (SqlConnection conn = new SqlConnection(connString)) {
            String cmdText = @"Use DbDataIsolationLevel; 

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products";

            conn.Open();

            using (SqlCommand command = new SqlCommand(cmdText, conn)) {
               using (SqlDataReader reader = command.ExecuteReader()) {
                  DisplayData(reader);
               }
            }
         }
      }

      public static void DisplayData(SqlDataReader reader) {
         Boolean isFirst = true;

         while (reader.Read()) {
            if (isFirst) {
               isFirst = false;

               for (int i = 0; i < reader.FieldCount; i++)
                  Console.Write("{0,-12}   ", reader.GetName(i));
               Console.WriteLine();
            }

            for (int i = 0; i < reader.FieldCount; i++)
               Console.Write("{0,-12}   ", reader[i]);
            Console.WriteLine();
         }
      }
   }

   // This class includes database operations. If there's no database 'DbDataIsolationLevel', create the database.
   static class OperateDatabase {
      public static Boolean CreateDatabase(String connString) {
         using (SqlConnection conn = new SqlConnection(connString)) {
            String cmdText = @"Use Master;

                                     if Db_Id('DbDataIsolationLevel') is null
                                      create Database [DbDataIsolationLevel];";

            using (SqlCommand command = new SqlCommand(cmdText, conn)) {
               conn.Open();
               command.ExecuteNonQuery();
            }

            Console.WriteLine("Create the Database 'DbDataIsolationLevel'");
         }

         return true;
      }


      // If there's no table [dbo].[Products] in DbDataIsolationLevel, create the table; or recreate it.
      public static Boolean CreateTable(String connString) {
         using (SqlConnection conn = new SqlConnection(connString)) {
            String cmdText = @"Use DbDataIsolationLevel

                                    if Object_ID('[dbo].[Products]') is not null
                                    drop table [dbo].[Products]

                                    Create Table [dbo].[Products]
                                    (
                                    [ProductId] int IDENTITY(1,1) primary key,
                                    [ProductName] NVarchar(100) not null,
                                    [Quantity] int null,
                                    [Price] money null
                                    )";

            using (SqlCommand command = new SqlCommand(cmdText, conn)) {
               conn.Open();
               command.ExecuteNonQuery();
            }
         }

         return InsertRows(connString);
      }

      // Insert some rows into [dbo].[Products] table.
      public static Boolean InsertRows(String connString) {
         using (SqlConnection conn = new SqlConnection(connString)) {
            String cmdText = @"Use DbDataIsolationLevel

                    INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Blue Bike', 365,1075.00)
                    INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Red Bike', 159, 1299.00)
                    INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Black Bike', 638, 1159.00)";

            using (SqlCommand command = new SqlCommand(cmdText, conn)) {
               conn.Open();
               command.ExecuteNonQuery();
            }
         }
         return true;
      }

      // Turn on or off 'ALLOW_SNAPSHOT_ISOLATION'
      public static Boolean SetSnapshot(String connString, Boolean isOpen) {
         using (SqlConnection conn = new SqlConnection(connString)) {
            String cmdText = null;

            if (isOpen)
               cmdText = @"ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION ON";
            else
               cmdText = @"ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION OFF";

            using (SqlCommand command = new SqlCommand(cmdText, conn)) {
               conn.Open();
               command.ExecuteNonQuery();
            }
         }

         return true;
      }
   }
   class Program {
      static void Main(string[] args) {
         String connString = "Data Source=(local);Initial Catalog=master;Integrated Security=True;Asynchronous Processing=true;";

         OperateDatabase.CreateDatabase(connString);
         Console.WriteLine();

         Console.WriteLine("Demonstrate the ReadUncommitted transaction: ");
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
             System.Data.IsolationLevel.ReadUncommitted);
         Console.WriteLine("-----------------------------------------------");

         Console.WriteLine("Demonstrate the ReadCommitted transaction: ");
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
             System.Data.IsolationLevel.ReadCommitted);
         Console.WriteLine("-----------------------------------------------");

         Console.WriteLine("Demonstrate the RepeatableRead transaction: ");
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
             System.Data.IsolationLevel.RepeatableRead);
         Console.WriteLine("-----------------------------------------------");

         Console.WriteLine("Demonstrate the Serializable transaction: ");
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
             System.Data.IsolationLevel.Serializable);
         Console.WriteLine("-----------------------------------------------");

         Console.WriteLine("Demonstrate the Snapshot transaction: ");
         OperateDatabase.SetSnapshot(connString, true);
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
             System.Data.IsolationLevel.Snapshot);
         Console.WriteLine("-----------------------------------------------");

         Console.WriteLine("Demonstrate the difference between the Snapshot and Serializable transactions:");
         TransactionIsolationLevels.DemonstrateBetweenSnapshotAndSerializable(connString);
         OperateDatabase.SetSnapshot(connString, false);
         Console.WriteLine();
      }
   }
}
// </Snippet1>