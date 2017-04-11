' <Snippet1>
Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading
Imports System.Threading.Tasks

Namespace CSDataIsolationLevel

   ' Use the delegate to call the different threads.
   Public Delegate Sub AsyncAccessDatabase(connString As [String], level As IsolationLevel)

   NotInheritable Class DirtyReadThreads
      Private Sub New()
      End Sub
      Public Shared Sub DirtyReadFirstThread(connStrig As [String], level As IsolationLevel)
         Console.WriteLine("Begin the DirtyReadFirstThread.....")

         Using conn As New SqlConnection(connStrig)
            Dim cmdText As [String] = "Use DbDataIsolationLevel; " & vbCr & vbLf & vbCr & vbLf &
                "Update dbo.Products set Quantity=Quantity+100 where ProductId=1;" & vbCr & vbLf &
                "WaitFor Delay '00:00:06';"

            conn.Open()

            Using tran As SqlTransaction = conn.BeginTransaction(level, "DirtyReadFirst")
               Using command As New SqlCommand(cmdText, conn)
                  command.Transaction = tran
                  command.ExecuteNonQuery()
               End Using

               If tran IsNot Nothing Then
                  tran.Rollback()
               End If
            End Using
         End Using

         Console.WriteLine("Exit from the DirtyReadFirstThread.....")
      End Sub

      Public Shared Sub DirtyReadSecondThread(connStrig As [String], level As IsolationLevel)
         Console.WriteLine("Begin the DirtyReadSecondThread.....")

         Using conn As New SqlConnection(connStrig)
            Dim cmdText As [String] = "Use DbDataIsolationLevel;" & vbCr & vbLf & vbCr & vbLf &
                "WaitFor Delay '00:00:03'; " & vbCr & vbLf & vbCr & vbLf &
                "Declare @qty int;" & vbCr & vbLf &
                "select @qty=Quantity from dbo.Products where ProductId=1;" & vbCr & vbLf & vbCr & vbLf &
                "Update dbo.Products set Quantity=@qty+100 where ProductId=1;"

            conn.Open()

            Using tran As SqlTransaction = conn.BeginTransaction(level, "DirtyReadSecond")
               Using command As New SqlCommand(cmdText, conn)
                  command.Transaction = tran
                  command.ExecuteNonQuery()
               End Using
               tran.Commit()
            End Using
         End Using

         Console.WriteLine("Exit from the DirtyReadSecondThread.....")
      End Sub
   End Class


   NotInheritable Class NonrepeatableReadThreads
      Private Sub New()
      End Sub
      Public Shared Sub NonrepeatableReadFirstThread(connStrig As [String], level As IsolationLevel)
         Console.WriteLine("Begin the NonrepeatableReadFirstThread.....")

         Using conn As New SqlConnection(connStrig)
            Dim cmdText As [String] = "Use DbDataIsolationLevel; " & vbCr & vbLf & vbCr & vbLf &
                "Select ProductId,ProductName,Quantity,Price" & vbCr & vbLf &
                "from dbo.Products" & vbCr & vbLf &
                "where ProductId=1" & vbCr & vbLf & vbCr & vbLf &
                "WaitFor Delay '00:00:06';" & vbCr & vbLf & vbCr & vbLf &
                "Select ProductId,ProductName,Quantity,Price" & vbCr & vbLf &
                "from dbo.Products" & vbCr & vbLf &
                "where ProductId=1"

            conn.Open()

            Using tran As SqlTransaction = conn.BeginTransaction(level, "NonrepeatableReadFirst")
               Using command As New SqlCommand(cmdText, conn)
                  command.Transaction = tran

                  Using reader As SqlDataReader = command.ExecuteReader()
                     Dim isFirstReader As [Boolean] = True
                     Do
                        Console.WriteLine("It's the result of {0} read:", If(isFirstReader, "first", "second"))
                        TransactionIsolationLevels.DisplayData(reader)
                        isFirstReader = Not isFirstReader
                     Loop While reader.NextResult() AndAlso Not isFirstReader
                  End Using
               End Using

               tran.Commit()
            End Using
         End Using

         Console.WriteLine("Exit from the NonrepeatableReadFirstThread.....")
      End Sub

      Public Shared Sub NonrepeatableReadSecondThread(connStrig As [String], level As IsolationLevel)
         Console.WriteLine("Begin the NonrepeatableReadSecondThread.....")

         Using conn As New SqlConnection(connStrig)
            Dim cmdText As [String] = "Use DbDataIsolationLevel;" & vbCr & vbLf & vbCr & vbLf &
                "WaitFor Delay '00:00:03'; " & vbCr & vbLf & vbCr & vbLf &
                "Update dbo.Products set Quantity=Quantity+100 where ProductId=1;"

            conn.Open()

            Using tran As SqlTransaction = conn.BeginTransaction(level, "NonrepeatableReadSecond")
               Using command As New SqlCommand(cmdText, conn)
                  command.Transaction = tran
                  command.ExecuteNonQuery()
               End Using
               tran.Commit()
            End Using
         End Using

         Console.WriteLine("Exit from the NonrepeatableReadSecondThread.....")
      End Sub
   End Class


   NotInheritable Class PhantomReadThreads
      Private Sub New()
      End Sub
      Public Shared Sub PhantomReadFirstThread(connStrig As [String], level As IsolationLevel)
         Console.WriteLine("Begin the PhantomReadFirstThread.....")

         Using conn As New SqlConnection(connStrig)
            Dim cmdText As [String] = "Use DbDataIsolationLevel; " & vbCr & vbLf & vbCr & vbLf &
                "Select ProductId,ProductName,Quantity,Price" & vbCr & vbLf &
                "from dbo.Products" & vbCr & vbLf & vbCr & vbLf &
                "WaitFor Delay '00:00:06';" & vbCr & vbLf & vbCr & vbLf &
                "Select ProductId,ProductName,Quantity,Price" & vbCr & vbLf &
                "from dbo.Products"

            conn.Open()

            Using tran As SqlTransaction = conn.BeginTransaction(level, "PhantomReadFirst")
               Using command As New SqlCommand(cmdText, conn)
                  command.Transaction = tran

                  Using reader As SqlDataReader = command.ExecuteReader()
                     Dim isFirstReader As [Boolean] = True
                     Do
                        Console.WriteLine("It's the result of {0} read:", If(isFirstReader, "first", "second"))

                        TransactionIsolationLevels.DisplayData(reader)

                        isFirstReader = Not isFirstReader
                     Loop While reader.NextResult() AndAlso Not isFirstReader
                  End Using
               End Using

               tran.Commit()
            End Using
         End Using
         Console.WriteLine("Exit from the PhantomReadFirstThread.....")
      End Sub

      Public Shared Sub PhantomReadSecondThread(connStrig As [String], level As IsolationLevel)
         Console.WriteLine("Begin the PhantomReadSecondThread.....")

         Using conn As New SqlConnection(connStrig)
            Dim cmdText As [String] = "Use DbDataIsolationLevel;" & vbCr & vbLf & vbCr & vbLf &
                "WaitFor Delay '00:00:03'; " & vbCr & vbLf & vbCr & vbLf &
                "INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) " & vbCr & vbLf &
                "VALUES (N'White Bike', 843, 1349.00)"

            conn.Open()

            Using tran As SqlTransaction = conn.BeginTransaction(level, "PhantomReadSecond")
               Using command As New SqlCommand(cmdText, conn)
                  command.Transaction = tran
                  command.ExecuteNonQuery()
               End Using
               tran.Commit()
            End Using
         End Using

         Console.WriteLine("Exit from the PhantomReadSecondThread.....")
      End Sub
   End Class


   ' Demonstrates if the specific transaction allows the following behaviors:
   ' 1. Dirty reads;
   ' 2. Non-repeatable reads;
   ' 3. Phantoms.
   NotInheritable Class TransactionIsolationLevels
      Private Sub New()
      End Sub
      Public Shared Sub DemonstrateIsolationLevel(connString As [String], level As IsolationLevel)
         ' Before connect the database, recreate the table.
         OperateDatabase.CreateTable(connString)
         DemonstrateIsolationLevel(connString, level, AddressOf DirtyReadThreads.DirtyReadFirstThread, AddressOf DirtyReadThreads.DirtyReadSecondThread)
         DisplayData(connString)
         Console.WriteLine()

         OperateDatabase.CreateTable(connString)
         DemonstrateIsolationLevel(connString, level, AddressOf NonrepeatableReadThreads.NonrepeatableReadFirstThread, AddressOf NonrepeatableReadThreads.NonrepeatableReadSecondThread)
         Console.WriteLine()

         OperateDatabase.CreateTable(connString)
         DemonstrateIsolationLevel(connString, level, AddressOf PhantomReadThreads.PhantomReadFirstThread, AddressOf PhantomReadThreads.PhantomReadSecondThread)
         Console.WriteLine()
      End Sub

      ' Demonstrates if the specific transaction allows the specific behaviors.
      Public Shared Sub DemonstrateIsolationLevel(connString As [String], level As IsolationLevel, firstThread As AsyncAccessDatabase, secondThread As AsyncAccessDatabase)
         ' Dim tasks As Task() = {Task.Factory.StartNew(Function() firstThread(connString, level)), Task.Factory.StartNew(Function() secondThread(connString, level))}

         Dim tasks() As Task = {
                         Task.Factory.StartNew(Sub() firstThread(connString, level)),
                         Task.Factory.StartNew(Sub() secondThread(connString, level))
                                        }

         Task.WaitAll(tasks)
      End Sub

      Private NotInheritable Class ExchangeValuesThreads
         Private Sub New()
         End Sub
         Public Shared Sub ExchangeValuesFirstThread(connStrig As [String], level As IsolationLevel)
            Console.WriteLine("Begin the ExchangeValuesFirstThread.....")

            Using conn As New SqlConnection(connStrig)
               Dim cmdText As [String] = "Use DbDataIsolationLevel;" & vbCr & vbLf & vbCr & vbLf &
                   "Declare @price money;" & vbCr & vbLf &
                   "select @price=Price from dbo.Products where ProductId=2;" & vbCr & vbLf & vbCr & vbLf &
                   "Update dbo.Products set Price=@price where ProductId=1;" & vbCr & vbLf & vbCr & vbLf &
                   "WaitFor Delay '00:00:06'; "

               conn.Open()
               Using tran As SqlTransaction = conn.BeginTransaction(level, "ExchangeValuesFirst")

                  Using command As New SqlCommand(cmdText, conn)
                     command.Transaction = tran
                     command.ExecuteNonQuery()
                  End Using

                  tran.Commit()
               End Using
            End Using

            Console.WriteLine("Exit from the ExchangeValuesFirstThread.....")
         End Sub

         Public Shared Sub ExchangeValuesSecondThread(connStrig As [String], level As IsolationLevel)
            Console.WriteLine("Begin the ExchangeValuesSecondThread.....")

            Using conn As New SqlConnection(connStrig)
               Dim cmdText As [String] = "Use DbDataIsolationLevel;" & vbCr & vbLf & vbCr & vbLf &
                   "WaitFor Delay '00:00:03'; " & vbCr & vbLf & vbCr & vbLf &
                   "Declare @price money;" & vbCr & vbLf &
                   "select @price=Price from dbo.Products where ProductId=1;" & vbCr & vbLf & vbCr & vbLf &
                   "Update dbo.Products set Price=@price where ProductId=2;"

               conn.Open()

               Using tran As SqlTransaction = conn.BeginTransaction(level, "ExchangeValuesSecond")
                  Using command As New SqlCommand(cmdText, conn)
                     command.Transaction = tran
                     command.ExecuteNonQuery()
                  End Using
                  tran.Commit()
               End Using
            End Using

            Console.WriteLine("Exit from the ExchangeValuesSecondThread.....")
         End Sub
      End Class

      ' Demonstrates the difference between the Serializable and Snapshot transaction
      Public Shared Sub DemonstrateBetweenSnapshotAndSerializable(connString As [String])
         OperateDatabase.CreateTable(connString)

         Console.WriteLine("Exchange Vaules in the Snapshot transaction:")
         DemonstrateIsolationLevel(connString, IsolationLevel.Snapshot, AddressOf ExchangeValuesThreads.ExchangeValuesFirstThread, AddressOf ExchangeValuesThreads.ExchangeValuesSecondThread)
         DisplayData(connString)
         Console.WriteLine()

         Console.WriteLine("Cannot Exchange Vaules in the Serializable transaction:")
         OperateDatabase.CreateTable(connString)
         DemonstrateIsolationLevel(connString, IsolationLevel.Serializable, AddressOf ExchangeValuesThreads.ExchangeValuesFirstThread, AddressOf ExchangeValuesThreads.ExchangeValuesSecondThread)
         DisplayData(connString)
      End Sub

      Public Shared Sub DisplayData(connString As [String])
         Using conn As New SqlConnection(connString)
            Dim cmdText As [String] = "Use DbDataIsolationLevel; " & vbCr & vbLf & vbCr & vbLf &
                "Select ProductId,ProductName,Quantity,Price" & vbCr & vbLf &
                "from dbo.Products"

            conn.Open()

            Using command As New SqlCommand(cmdText, conn)
               Using reader As SqlDataReader = command.ExecuteReader()
                  DisplayData(reader)
               End Using
            End Using
         End Using
      End Sub

      Public Shared Sub DisplayData(reader As SqlDataReader)
         Dim isFirst As [Boolean] = True

         While reader.Read()
            If isFirst Then
               isFirst = False

               For i As Integer = 0 To reader.FieldCount - 1
                  Console.Write("{0,-12}   ", reader.GetName(i))
               Next
               Console.WriteLine()
            End If

            For i As Integer = 0 To reader.FieldCount - 1
               Console.Write("{0,-12}   ", reader(i))
            Next
            Console.WriteLine()
         End While
      End Sub
   End Class

   ' This class includes database operations. If there's no database 'DbDataIsolationLevel', create the database.
   NotInheritable Class OperateDatabase
      Private Sub New()
      End Sub
      Public Shared Function CreateDatabase(connString As [String]) As [Boolean]
         Using conn As New SqlConnection(connString)
            Dim cmdText As [String] = "Use Master;" & vbCr & vbLf & vbCr & vbLf &
                "if Db_Id('DbDataIsolationLevel') is null" & vbCr & vbLf &
                "create Database [DbDataIsolationLevel];"

            Using command As New SqlCommand(cmdText, conn)
               conn.Open()
               command.ExecuteNonQuery()
            End Using

            Console.WriteLine("Create the Database 'DbDataIsolationLevel'")
         End Using

         Return True
      End Function


      ' If there's no table [dbo].[Products] in DbDataIsolationLevel, create the table; or recreate it.
      Public Shared Function CreateTable(connString As [String]) As [Boolean]
         Using conn As New SqlConnection(connString)
            Dim cmdText As [String] = "Use DbDataIsolationLevel" & vbCr & vbLf & vbCr & vbLf &
                "if Object_ID('[dbo].[Products]') is not null" & vbCr & vbLf &
                "drop table [dbo].[Products]" & vbCr & vbLf & vbCr & vbLf &
                "Create Table [dbo].[Products]" & vbCr & vbLf &
                "(" & vbCr & vbLf &
                "[ProductId] int IDENTITY(1,1) primary key," & vbCr & vbLf &
                "[ProductName] NVarchar(100) not null," & vbCr & vbLf &
                "[Quantity] int null," & vbCr & vbLf &
                "[Price] money null" & vbCr & vbLf & "                                    )"

            Using command As New SqlCommand(cmdText, conn)
               conn.Open()
               command.ExecuteNonQuery()
            End Using
         End Using

         Return InsertRows(connString)
      End Function

      ' Insert some rows into [dbo].[Products] table.
      Public Shared Function InsertRows(connString As [String]) As [Boolean]
         Using conn As New SqlConnection(connString)
            Dim cmdText As [String] = "Use DbDataIsolationLevel" & vbCr & vbLf & vbCr & vbLf &
                "INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Blue Bike', 365,1075.00)" & vbCr & vbLf &
                "INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Red Bike', 159, 1299.00)" & vbCr & vbLf &
                "INSERT [dbo].[Products] ([ProductName], [Quantity], [Price]) VALUES (N'Black Bike', 638, 1159.00)"

            Using command As New SqlCommand(cmdText, conn)
               conn.Open()
               command.ExecuteNonQuery()
            End Using
         End Using
         Return True
      End Function

      ' Turn on or off 'ALLOW_SNAPSHOT_ISOLATION'
      Public Shared Function SetSnapshot(connString As [String], isOpen As [Boolean]) As [Boolean]
         Using conn As New SqlConnection(connString)
            Dim cmdText As [String] = Nothing

            If isOpen Then
               cmdText = "ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION ON"
            Else
               cmdText = "ALTER DATABASE DbDataIsolationLevel SET ALLOW_SNAPSHOT_ISOLATION OFF"
            End If

            Using command As New SqlCommand(cmdText, conn)
               conn.Open()
               command.ExecuteNonQuery()
            End Using
         End Using

         Return True
      End Function
   End Class
   Class Program
      Public Shared Sub Main(args As String())
         Dim connString As [String] = "Data Source=(local);Initial Catalog=master;Integrated Security=True;Asynchronous Processing=true;"

         OperateDatabase.CreateDatabase(connString)
         Console.WriteLine()

         Console.WriteLine("Demonstrate the ReadUncommitted transaction: ")
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString, System.Data.IsolationLevel.ReadUncommitted)
         Console.WriteLine("-----------------------------------------------")

         Console.WriteLine("Demonstrate the ReadCommitted transaction: ")
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString, System.Data.IsolationLevel.ReadCommitted)
         Console.WriteLine("-----------------------------------------------")

         Console.WriteLine("Demonstrate the RepeatableRead transaction: ")
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString, System.Data.IsolationLevel.RepeatableRead)
         Console.WriteLine("-----------------------------------------------")

         Console.WriteLine("Demonstrate the Serializable transaction: ")
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString, System.Data.IsolationLevel.Serializable)
         Console.WriteLine("-----------------------------------------------")

         Console.WriteLine("Demonstrate the Snapshot transaction: ")
         OperateDatabase.SetSnapshot(connString, True)
         TransactionIsolationLevels.DemonstrateIsolationLevel(connString, System.Data.IsolationLevel.Snapshot)
         Console.WriteLine("-----------------------------------------------")

         Console.WriteLine("Demonstrate the difference between the Snapshot and Serializable transactions:")
         TransactionIsolationLevels.DemonstrateBetweenSnapshotAndSerializable(connString)
         OperateDatabase.SetSnapshot(connString, False)
         Console.WriteLine()
      End Sub
   End Class
End Namespace
' </Snippet1>