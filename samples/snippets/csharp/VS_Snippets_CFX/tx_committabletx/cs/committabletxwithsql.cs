//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
//
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Transactions;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Microsoft.Samples.Transactions.Quickstarts
{
    class CommittableTxWithSQL
    {
        static void Main(string[] args)
        {
            CommittableTransaction tx = null;

            try
            {
                //<snippet1>
                //Create a committable transaction
                tx = new CommittableTransaction();

                string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new InvalidOperationException("Set the SQL_CONNECTION_STRING environment variable.");
                using SqlConnection myConnection = new SqlConnection(connectionString);
                SqlCommand myCommand = new SqlCommand();

                //Open the SQL connection
                myConnection.Open();

                //Give the transaction to SQL to enlist with
                myConnection.EnlistTransaction(tx);

                myCommand.Connection = myConnection;

                // Restore database to near it's original condition so sample will work correctly.
                myCommand.CommandText = "DELETE FROM Region WHERE (RegionID = 100) OR (RegionID = 101)";
                myCommand.ExecuteNonQuery();

                // Insert the first record.
                myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'MidWestern')";
                myCommand.ExecuteNonQuery();

                // Insert the second record.
                myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (101, 'MidEastern')";
                myCommand.ExecuteNonQuery();

                // Commit or rollback the transaction
                while (true)
                {
                    Console.Write("Commit or Rollback? [C|R] ");
                    string choice = Console.ReadLine();
                    if (choice == null)
                        throw new InvalidOperationException("Enter C to commit or R to roll back.");

                    if (string.Equals(choice, "C", StringComparison.OrdinalIgnoreCase))
                    {
                        tx.Commit();
                        break;
                    }
                    else if (string.Equals(choice, "R", StringComparison.OrdinalIgnoreCase))
                    {
                        tx.Rollback();
                        break;
                    }
                }
                myConnection.Close();
                tx = null;
                //</snippet1>
            }
            catch (System.Transactions.TransactionException ex)
            {
                //Call rollback inside the catch block
                if (tx != null)
                    tx.Rollback();
                Console.WriteLine(ex);
            }
            catch
            {
                //Call rollback inside the catch block
                if (tx != null)
                    tx.Rollback();
                Console.WriteLine("Cannot complete transaction");
                throw;
            }
        }
    }
}
