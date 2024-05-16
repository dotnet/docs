---
description: "Learn more about: FILESTREAM Data"
title: "FILESTREAM Data"
ms.date: "03/30/2017"
ms.assetid: bd8b845c-0f09-4295-b466-97ef106eefa8
---

# FILESTREAM Data

The FILESTREAM storage attribute is for binary (BLOB) data stored in a varbinary(max) column. Before FILESTREAM, storing binary data required special handling. Unstructured data, such as text documents, images and video, is often stored outside of the database, making it difficult to manage.

> [!NOTE]
> You must install the .NET Framework 3.5 SP1 (or later) to work with FILESTREAM data using SqlClient.

Specifying the FILESTREAM attribute on a varbinary(max) column causes SQL Server to store the data on the local NTFS file system instead of in the database file. Although it is stored separately, you can use the same Transact-SQL statements that are supported for working with varbinary(max) data that is stored in the database.

## SqlClient Support for FILESTREAM

The .NET Framework Data Provider for SQL Server, <xref:System.Data.SqlClient>, supports reading and writing to FILESTREAM data using the <xref:System.Data.SqlTypes.SqlFileStream> class defined in the <xref:System.Data.SqlTypes> namespace. `SqlFileStream` inherits from the <xref:System.IO.Stream> class, which provides methods for reading and writing to streams of data. Reading from a stream transfers data from the stream into a data structure, such as an array of bytes. Writing transfers the data from the data structure into a stream.

### Creating the SQL Server Table

The following Transact-SQL statements creates a table named employees and inserts a row of data. Once you have enabled FILESTREAM storage, you can use this table in conjunction with the code examples that follow.

```sql
CREATE TABLE employees
(
  EmployeeId INT  NOT NULL  PRIMARY KEY,
  Photo VARBINARY(MAX) FILESTREAM  NULL,
  RowGuid UNIQUEIDENTIFIER  NOT NULL  ROWGUIDCOL
  UNIQUE DEFAULT NEWID()
)
GO
Insert into employees
Values(1, 0x00, default)
GO
```

### Example: Reading, Overwriting, and Inserting FILESTREAM Data

The following sample demonstrates how to read data from a FILESTREAM. The code gets the logical path to the file, setting the `FileAccess` to `Read` and the `FileOptions` to `SequentialScan`. The code then reads the bytes from the SqlFileStream into the buffer. The bytes are then written to the console window.

The sample also demonstrates how to write data to a FILESTREAM in which all existing data is overwritten. The code gets the logical path to the file and creates the `SqlFileStream`, setting the `FileAccess` to `Write` and the `FileOptions` to `SequentialScan`. A single byte is written to the `SqlFileStream`, replacing any data in the file.

The sample also demonstrates how to write data to a FILESTREAM by using the Seek method to append data to the end of the file. The code gets the logical path to the file and creates the `SqlFileStream`, setting the `FileAccess` to `ReadWrite` and the `FileOptions` to `SequentialScan`. The code uses the Seek method to seek to the end of the file, appending a single byte to the existing file.

```csharp
using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.IO;

namespace FileStreamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("server=(local);integrated security=true;database=myDB");
            ReadFileStream(builder);
            OverwriteFileStream(builder);
            InsertFileStream(builder);

            Console.WriteLine("Done");
        }

        private static void ReadFileStream(SqlConnectionStringBuilder connStringBuilder)
        {
            using (SqlConnection connection = new SqlConnection(connStringBuilder.ToString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP(1) Photo.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() FROM employees", connection);

                SqlTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = tran;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Get the pointer for the file
                        string path = reader.GetString(0);
                        byte[] transactionContext = reader.GetSqlBytes(1).Buffer;

                        // Create the SqlFileStream
                        using (Stream fileStream = new SqlFileStream(path, transactionContext, FileAccess.Read, FileOptions.SequentialScan, allocationSize: 0))
                        {
                            // Read the contents as bytes and write them to the console
                            for (long index = 0; index < fileStream.Length; index++)
                            {
                                Console.WriteLine(fileStream.ReadByte());
                            }
                        }
                    }
                }
                tran.Commit();
            }
        }

        private static void OverwriteFileStream(SqlConnectionStringBuilder connStringBuilder)
        {
            using (SqlConnection connection = new SqlConnection(connStringBuilder.ToString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP(1) Photo.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() FROM employees", connection);

                SqlTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = tran;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Get the pointer for file
                        string path = reader.GetString(0);
                        byte[] transactionContext = reader.GetSqlBytes(1).Buffer;

                        // Create the SqlFileStream
                        using (Stream fileStream = new SqlFileStream(path, transactionContext, FileAccess.Write, FileOptions.SequentialScan, allocationSize: 0))
                        {
                            // Write a single byte to the file. This will
                            // replace any data in the file.
                            fileStream.WriteByte(0x01);
                        }
                    }
                }
                tran.Commit();
            }
        }

        private static void InsertFileStream(SqlConnectionStringBuilder connStringBuilder)
        {
            using (SqlConnection connection = new SqlConnection(connStringBuilder.ToString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP(1) Photo.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() FROM employees", connection);

                SqlTransaction tran = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = tran;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Get the pointer for file
                        string path = reader.GetString(0);
                        byte[] transactionContext = reader.GetSqlBytes(1).Buffer;

                        using (Stream fileStream = new SqlFileStream(path, transactionContext, FileAccess.ReadWrite, FileOptions.SequentialScan, allocationSize: 0))
                        {
                            // Seek to the end of the file
                            fileStream.Seek(0, SeekOrigin.End);

                            // Append a single byte
                            fileStream.WriteByte(0x01);
                        }
                    }
                }
                tran.Commit();
            }

        }
    }
}
```

For another sample, see [How to store and fetch binary data into a file stream column](https://www.codeproject.com/Articles/32216/How-to-store-and-fetch-binary-data-into-a-file-str).

## SQL Server docs resources

The complete documentation for FILESTREAM is located in the following sections of the SQL Server docs.

|Topic|Description|
|-----------|-----------------|
|[FILESTREAM (SQL Server)](/sql/relational-databases/blob/filestream-sql-server)|Describes when to use FILESTREAM storage and how it integrates the SQL Server Database Engine with an NTFS file system.|
|[Create Client Applications for FILESTREAM Data](/sql/relational-databases/blob/create-client-applications-for-filestream-data)|Describes the Windows API functions for working with FILESTREAM data.|
|[FILESTREAM and Other SQL Server Features](/sql/relational-databases/blob/filestream-compatibility-with-other-sql-server-features)|Provides considerations, guidelines and limitations for using FILESTREAM data with other features of SQL Server.|

## See also

- [SQL Server Data Types and ADO.NET](sql-server-data-types.md)
- [Retrieving and Modifying Data in ADO.NET](../retrieving-and-modifying-data.md)
- [Code Access Security and ADO.NET](../code-access-security.md)
- [SQL Server Binary and Large-Value Data](sql-server-binary-and-large-value-data.md)
- [ADO.NET Overview](../ado-net-overview.md)
