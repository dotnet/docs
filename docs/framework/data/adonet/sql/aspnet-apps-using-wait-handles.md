---
description: "Learn more about ASP.NET applications using wait handles. The Wait models provide a more flexible way of processing multiple asynchronous operations."
title: "ASP.NET Applications Using Wait Handles"
ms.date: "10/23/2026"
dev_langs:
  - "csharp"
  - "vb"
---
# ASP.NET applications using wait handles

Install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package to use these examples. Microsoft.Data.SqlClient supports the `BeginExecute` and `EndExecute` methods shown here without an asynchronous connection-string option. Don't add `Asynchronous Processing=true`; Microsoft.Data.SqlClient doesn't support that keyword. For new code, prefer `ExecuteReaderAsync` and `ExecuteNonQueryAsync` with `await`, and use `Task.WhenAny` or `Task.WhenAll` to coordinate operations without blocking a request thread.

The callback and polling models for handling asynchronous operations are useful when your application is processing only one asynchronous operation at a time. The Wait models provide a more flexible way of processing multiple asynchronous operations. There are two Wait models, named for the <xref:System.Threading.WaitHandle> methods used to implement them: the Wait (Any) model and the Wait (All) model.

To use either Wait model, use the <xref:System.IAsyncResult.AsyncWaitHandle> property of the <xref:System.IAsyncResult> object returned by the <xref:Microsoft.Data.SqlClient.SqlCommand.BeginExecuteNonQuery*>, <xref:Microsoft.Data.SqlClient.SqlCommand.BeginExecuteReader*>, or <xref:Microsoft.Data.SqlClient.SqlCommand.BeginExecuteXmlReader*> methods. Pass an array of <xref:System.Threading.WaitHandle> objects to <xref:System.Threading.WaitHandle.WaitAny*> or <xref:System.Threading.WaitHandle.WaitAll*>.

 Both Wait methods monitor the asynchronous operations, waiting for completion. The <xref:System.Threading.WaitHandle.WaitAny*> method waits for any of the operations to complete or time out. Once you know a particular operation is complete, you can process its results and then continue waiting for the next operation to complete or time out. The <xref:System.Threading.WaitHandle.WaitAll*> method waits for all of the processes in the array of <xref:System.Threading.WaitHandle> instances to complete or time out before continuing.

 The Wait models' benefit is most striking when you need to run multiple operations of some length on different servers, or when your server is powerful enough to process all the queries at the same time. In the examples presented here, three queries emulate long processes by adding `WAITFOR` commands of varying lengths to inconsequential `SELECT` queries.

## Example: Wait (Any) Model

The following example illustrates the Wait (Any) model. After it starts three asynchronous operations, the code calls <xref:System.Threading.WaitHandle.WaitAny*> to wait for any operation to complete. For each completed operation, the code calls <xref:Microsoft.Data.SqlClient.SqlCommand.EndExecuteReader*> and reads the resulting <xref:Microsoft.Data.SqlClient.SqlDataReader>. An application can use those results to populate part of the page. The example instead adds the completion time to the corresponding text box. Each time records when the code processes a completed operation.

Because completed handles remain signaled, the example removes each completed operation from the pending lists before it waits again.

 To set up this example, create a new ASP.NET Web Site project. Place a <xref:System.Web.UI.WebControls.Button> control and four <xref:System.Web.UI.WebControls.TextBox> controls on the page (accepting the default name for each control).

Add the following code to the form's class. In both Wait model examples, replace the ellipsis returned by `GetConnectionString` with your connection string. For a remote server with Windows integrated authentication, use `Server=<server>;Database=<database>;Integrated Security=true;Encrypt=true`. Replace `<server>` and `<database>` with your server and database names, and configure a server certificate that the client trusts. For other authentication options, see [Connection string syntax](/sql/connect/ado-net/connection-string-syntax).

```vb
' Add these to the top of the class
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports System.Threading

' Add this code to the page's class:
    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file.

        Return "..."
    End Function

    Sub Button1_Click( _
     ByVal sender As Object, ByVal e As System.EventArgs)

        ' In a real-world application, you might be connecting to
        '  three different servers or databases. For the example,
        '  we connect to only one.
        Dim connection1 As New SqlConnection(GetConnectionString())
        Dim connection2 As New SqlConnection(GetConnectionString())
        Dim connection3 As New SqlConnection(GetConnectionString())

        ' To keep the example simple, all three asynchronous
        ' processes select a row from the same table. WAITFOR
        ' commands are used to emulate long-running processes
        ' that complete after different periods of time.
        Dim commandText1 As String = _
            "WAITFOR DELAY '0:0:01';" & _
            "SELECT * FROM Production.Product " & _
            "WHERE ProductNumber = 'BL-2036'"

        Dim commandText2 As String = _
            "WAITFOR DELAY '0:0:05';" & _
            "SELECT * FROM Production.Product " & _
            "WHERE ProductNumber = 'BL-2036'"

        Dim commandText3 As String = _
            "WAITFOR DELAY '0:0:10';" & _
            "SELECT * FROM Production.Product " & _
            "WHERE ProductNumber = 'BL-2036'"

        Dim waitHandles As New List(Of WaitHandle)
        Dim pending As New List(Of Integer) From {0, 1, 2}
        Try
            ' For each process, open a connection and begin execution.
            ' Use the IAsyncResult object returned by
            ' BeginExecuteReader to add a WaitHandle for the process
            ' to the pending list.
            connection1.Open()
            Dim command1 As New SqlCommand(commandText1, connection1)
            Dim result1 As IAsyncResult = _
             command1.BeginExecuteReader()
            waitHandles.Add(result1.AsyncWaitHandle)

            connection2.Open()
            Dim command2 As New SqlCommand(commandText2, connection2)
            Dim result2 As IAsyncResult = _
             command2.BeginExecuteReader()
            waitHandles.Add(result2.AsyncWaitHandle)

            connection3.Open()
            Dim command3 As New SqlCommand(commandText3, connection3)
            Dim result3 As IAsyncResult = _
             command3.BeginExecuteReader()
            waitHandles.Add(result3.AsyncWaitHandle)

            Dim index As Integer
            For countWaits As Integer = 1 To 3
                ' WaitAny waits for any of the processes to complete.
                ' The return value is either the index of the
                ' array element whose process just completed, or
                ' the WaitTimeout value.
                index = WaitHandle.WaitAny(waitHandles.ToArray(), 60000, False)
                If index = WaitHandle.WaitTimeout Then
                    Throw New Exception("Timeout")
                End If
                ' This example doesn't actually do anything with the
                ' data returned by the processes, but the code opens
                ' readers for each just to demonstrate the concept.
                ' Instead of using the returned data to fill the
                ' controls on the page, the example adds the time
                ' the process was completed to the corresponding
                ' text box.
                Select Case pending(index)
                    Case 0
                        Dim reader1 As SqlDataReader
                        reader1 = command1.EndExecuteReader(result1)
                        If reader1.Read Then
                            TextBox1.Text = _
                             "Completed " & _
                             System.DateTime.Now.ToLongTimeString()
                        End If
                        reader1.Close()

                    Case 1
                        Dim reader2 As SqlDataReader
                        reader2 = command2.EndExecuteReader(result2)
                        If reader2.Read Then
                            TextBox2.Text = _
                             "Completed " & _
                             System.DateTime.Now.ToLongTimeString()
                        End If
                        reader2.Close()
                    Case 2
                        Dim reader3 As SqlDataReader
                        reader3 = command3.EndExecuteReader(result3)
                        If reader3.Read Then
                            TextBox3.Text = _
                             "Completed " & _
                             System.DateTime.Now.ToLongTimeString()
                        End If
                        reader3.Close()
                End Select
                waitHandles.RemoveAt(index)
                pending.RemoveAt(index)
            Next
        Catch ex As Exception
            TextBox4.Text = ex.ToString
        End Try
        connection1.Close()
        connection2.Close()
        connection3.Close()

    End Sub
```

```csharp
// Add the following using directives, if they aren't already there.
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using Microsoft.Data.SqlClient;

// Add this code to the page's class
string GetConnectionString()
     //  To avoid storing the connection string in your code,
     //  you can retrieve it from a configuration file.
{
     return "...";
}
void Button1_Click(object sender, System.EventArgs e)
{
     //  In a real-world application, you might be connecting to
     //   three different servers or databases. For the example,
     //   we connect to only one.

     SqlConnection connection1 =
          new SqlConnection(GetConnectionString());
     SqlConnection connection2 =
          new SqlConnection(GetConnectionString());
     SqlConnection connection3 =
          new SqlConnection(GetConnectionString());
     //  To keep the example simple, all three asynchronous
     //  processes select a row from the same table. WAITFOR
     //  commands are used to emulate long-running processes
     //  that complete after different periods of time.

     string commandText1 = "WAITFOR DELAY '0:0:01';" +
          "SELECT * FROM Production.Product " +
          "WHERE ProductNumber = 'BL-2036'";
     string commandText2 = "WAITFOR DELAY '0:0:05';" +
          "SELECT * FROM Production.Product " +
          "WHERE ProductNumber = 'BL-2036'";
     string commandText3 = "WAITFOR DELAY '0:0:10';" +
          "SELECT * FROM Production.Product " +
          "WHERE ProductNumber = 'BL-2036'";
     try
          //  For each process, open a connection and begin
          //  execution. Use the IAsyncResult object returned by
          //  BeginExecuteReader to add a WaitHandle for the
          //  process to the pending list.
     {
          connection1.Open();
          SqlCommand command1 =
               new SqlCommand(commandText1, connection1);
          IAsyncResult result1 = command1.BeginExecuteReader();
          WaitHandle waitHandle1 = result1.AsyncWaitHandle;

          connection2.Open();
          SqlCommand command2 =
               new SqlCommand(commandText2, connection2);
          IAsyncResult result2 = command2.BeginExecuteReader();
          WaitHandle waitHandle2 = result2.AsyncWaitHandle;

          connection3.Open();
          SqlCommand command3 =
               new SqlCommand(commandText3, connection3);
          IAsyncResult result3 = command3.BeginExecuteReader();
          WaitHandle waitHandle3 = result3.AsyncWaitHandle;

          List<WaitHandle> waitHandles = new List<WaitHandle> {
               waitHandle1, waitHandle2, waitHandle3
          };
          List<int> pending = new List<int> { 0, 1, 2 };

          int index;
          for (int countWaits = 0; countWaits <= 2; countWaits++)
          {
               //  WaitAny waits for any of the processes to
               //  complete. The return value is either the index
               //  of the array element whose process just
               //  completed, or the WaitTimeout value.

               index = WaitHandle.WaitAny(waitHandles.ToArray(),
                    60000, false);
               if (index == WaitHandle.WaitTimeout)
               {
                    throw new Exception("Timeout");
               }
               //  This example doesn't actually do anything with
               //  the data returned by the processes, but the
               //  code opens readers for each just to demonstrate
               //  the concept.
               //  Instead of using the returned data to fill the
               //  controls on the page, the example adds the time
               //  the process was completed to the corresponding
               //  text box.

               switch (pending[index])
               {
                    case 0:
                         SqlDataReader reader1;
                         reader1 =
                              command1.EndExecuteReader(result1);
                         if (reader1.Read())
                         {
                           TextBox1.Text =
                           "Completed " +
                           System.DateTime.Now.ToLongTimeString();
                         }
                         reader1.Close();
                         break;
                    case 1:
                         SqlDataReader reader2;
                         reader2 =
                              command2.EndExecuteReader(result2);
                         if (reader2.Read())
                         {
                           TextBox2.Text =
                           "Completed " +
                           System.DateTime.Now.ToLongTimeString();
                         }
                         reader2.Close();
                         break;
                    case 2:
                         SqlDataReader reader3;
                         reader3 =
                              command3.EndExecuteReader(result3);
                         if (reader3.Read())
                         {
                           TextBox3.Text =
                           "Completed " +
                           System.DateTime.Now.ToLongTimeString();
                         }
                         reader3.Close();
                         break;
               }
               waitHandles.RemoveAt(index);
               pending.RemoveAt(index);
          }
     }
     catch (Exception ex)
     {
          TextBox4.Text = ex.ToString();
     }
     connection1.Close();
     connection2.Close();
     connection3.Close();
}
```

## Example: Wait (All) Model

 The following example illustrates the Wait (All) model. Once three asynchronous processes are started, the <xref:System.Threading.WaitHandle.WaitAll*> method is called to wait for the processes to complete or time out.

 Like the example of the Wait (Any) model, the time the process completed is added to a text box corresponding to the process. Again, the times in the text boxes illustrate the point: Code following the <xref:System.Threading.WaitHandle.WaitAny*> method is executed only after all processes are complete.

 To set up this example, create a new ASP.NET Web Site project. Place a <xref:System.Web.UI.WebControls.Button> control and four <xref:System.Web.UI.WebControls.TextBox> controls on the page (accepting the default name for each control).

 Add the following code to the form's class, modifying the connection string as necessary for your environment.

```vb
' Add these to the top of the class
Imports System
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports System.Threading

' Add this code to the page's class:
    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file.

        Return "..."
    End Function
    Sub Button1_Click( _
     ByVal sender As Object, ByVal e As System.EventArgs)

        ' In a real-world application, you might be connecting to
        '  three different servers or databases. For the example,
        '  we connect to only one.
        Dim connection1 As New SqlConnection(GetConnectionString())
        Dim connection2 As New SqlConnection(GetConnectionString())
        Dim connection3 As New SqlConnection(GetConnectionString())

        ' To keep the example simple, all three asynchronous
        ' processes select a row from the same table. WAITFOR
        ' commands are used to emulate long-running processes
        ' that complete after different periods of time.
        Dim commandText1 As String = _
         "UPDATE Production.Product " & _
         "SET ReorderPoint = ReorderPoint + 1 " & _
         "WHERE ReorderPoint Is Not Null;" & _
         "WAITFOR DELAY '0:0:01';" & _
         "UPDATE Production.Product " & _
         "SET ReorderPoint = ReorderPoint - 1 " & _
         "WHERE ReorderPoint Is Not Null"

        Dim commandText2 As String = _
         "UPDATE Production.Product " & _
         "SET ReorderPoint = ReorderPoint + 1 " & _
         "WHERE ReorderPoint Is Not Null;" & _
         "WAITFOR DELAY '0:0:05';" & _
         "UPDATE Production.Product " & _
         "SET ReorderPoint = ReorderPoint - 1 " & _
         "WHERE ReorderPoint Is Not Null"

        Dim commandText3 As String = _
         "UPDATE Production.Product " & _
         "SET ReorderPoint = ReorderPoint + 1 " & _
         "WHERE ReorderPoint Is Not Null;" & _
         "WAITFOR DELAY '0:0:10';" & _
         "UPDATE Production.Product " & _
         "SET ReorderPoint = ReorderPoint - 1 " & _
         "WHERE ReorderPoint Is Not Null"

        Dim waitHandles(2) As WaitHandle

        Try
            ' For each process, open a connection and begin execution.
            ' Use the IAsyncResult object returned by
            ' BeginExecuteReader to add a WaitHandle for the process
            ' to the array.
            connection1.Open()
            Dim command1 As New SqlCommand(commandText1, connection1)
            Dim result1 As IAsyncResult = _
             command1.BeginExecuteNonQuery()
            waitHandles(0) = result1.AsyncWaitHandle

            connection2.Open()
            Dim command2 As New SqlCommand(commandText2, connection2)
            Dim result2 As IAsyncResult = _
             command2.BeginExecuteNonQuery()
            waitHandles(1) = result2.AsyncWaitHandle

            connection3.Open()
            Dim command3 As New SqlCommand(commandText3, connection3)
            Dim result3 As IAsyncResult = _
             command3.BeginExecuteNonQuery()
            waitHandles(2) = result3.AsyncWaitHandle

            ' WaitAll waits for all of the processes to complete.
            ' The return value is True if all processes completed,
            ' False if any process timed out.
            Dim result As Boolean = _
             WaitHandle.WaitAll(waitHandles, 60000, False)
            If result Then
                Dim rowCount1 As Long = _
                 command1.EndExecuteNonQuery(result1)
                TextBox1.Text = _
                 "Completed " & _
                 System.DateTime.Now.ToLongTimeString()

                Dim rowCount2 As Long = _
                 command2.EndExecuteNonQuery(result2)
                TextBox2.Text = _
                 "Completed " & _
                 System.DateTime.Now.ToLongTimeString()

                Dim rowCount3 As Long = _
                 command3.EndExecuteNonQuery(result3)
                TextBox3.Text = _
                 "Completed " & _
                 System.DateTime.Now.ToLongTimeString()
            Else
                Throw New Exception("Timeout")
            End If
        Catch ex As Exception
            TextBox4.Text = ex.ToString
        End Try
        connection1.Close()
        connection2.Close()
        connection3.Close()

    End Sub
```

```csharp
// Add the following using directives, if they aren't already there.
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using Microsoft.Data.SqlClient;

// Add this code to the page's class
string GetConnectionString()
    //  To avoid storing the connection string in your code,
    //  you can retrieve it from a configuration file.
{
    return "...";
}
void Button1_Click(object sender, System.EventArgs e)
{
    //  In a real-world application, you might be connecting to
    //   three different servers or databases. For the example,
    //   we connect to only one.

    SqlConnection connection1 =
        new SqlConnection(GetConnectionString());
    SqlConnection connection2 =
        new SqlConnection(GetConnectionString());
    SqlConnection connection3 =
        new SqlConnection(GetConnectionString());
    //  To keep the example simple, all three asynchronous
    //  processes execute UPDATE queries that result in
      //  no change to the data. WAITFOR
    //  commands are used to emulate long-running processes
    //  that complete after different periods of time.

    string commandText1 =
        "UPDATE Production.Product " +
        "SET ReorderPoint = ReorderPoint + 1 " +
        "WHERE ReorderPoint Is Not Null;" +
        "WAITFOR DELAY '0:0:01';" +
        "UPDATE Production.Product " +
        "SET ReorderPoint = ReorderPoint - 1 " +
        "WHERE ReorderPoint Is Not Null";

    string commandText2 =
      "UPDATE Production.Product " +
      "SET ReorderPoint = ReorderPoint + 1 " +
      "WHERE ReorderPoint Is Not Null;" +
      "WAITFOR DELAY '0:0:05';" +
      "UPDATE Production.Product " +
      "SET ReorderPoint = ReorderPoint - 1 " +
      "WHERE ReorderPoint Is Not Null";

    string commandText3 =
       "UPDATE Production.Product " +
       "SET ReorderPoint = ReorderPoint + 1 " +
       "WHERE ReorderPoint Is Not Null;" +
       "WAITFOR DELAY '0:0:10';" +
       "UPDATE Production.Product " +
       "SET ReorderPoint = ReorderPoint - 1 " +
       "WHERE ReorderPoint Is Not Null";
    try
        //  For each process, open a connection and begin
        //  execution. Use the IAsyncResult object returned by
        //  BeginExecuteReader to add a WaitHandle for the
        //  process to the array.
    {
        connection1.Open();
        SqlCommand command1 =
            new SqlCommand(commandText1, connection1);
        IAsyncResult result1 = command1.BeginExecuteNonQuery();
        WaitHandle waitHandle1 = result1.AsyncWaitHandle;
        connection2.Open();

        SqlCommand command2 =
            new SqlCommand(commandText2, connection2);
        IAsyncResult result2 = command2.BeginExecuteNonQuery();
        WaitHandle waitHandle2 = result2.AsyncWaitHandle;
        connection3.Open();

        SqlCommand command3 =
            new SqlCommand(commandText3, connection3);
        IAsyncResult result3 = command3.BeginExecuteNonQuery();
        WaitHandle waitHandle3 = result3.AsyncWaitHandle;

        WaitHandle[] waitHandles = {
            waitHandle1, waitHandle2, waitHandle3
        };

        bool result;
        //  WaitAll waits for all of the processes to
        //  complete. The return value is True if the processes
        //  all completed successfully, False if any process
        //  timed out.

        result = WaitHandle.WaitAll(waitHandles, 60000, false);
        if(result)
        {
            long rowCount1 =
                command1.EndExecuteNonQuery(result1);
            TextBox1.Text = "Completed " +
                System.DateTime.Now.ToLongTimeString();
            long rowCount2 =
                command2.EndExecuteNonQuery(result2);
            TextBox2.Text = "Completed " +
                System.DateTime.Now.ToLongTimeString();

            long rowCount3 =
                command3.EndExecuteNonQuery(result3);
            TextBox3.Text = "Completed " +
                System.DateTime.Now.ToLongTimeString();
        }
        else
        {
            throw new Exception("Timeout");
        }
    }

    catch (Exception ex)
    {
        TextBox4.Text = ex.ToString();
    }
    connection1.Close();
    connection2.Close();
    connection3.Close();
}
```

## See also

- [Asynchronous Operations](asynchronous-operations.md)
- [ADO.NET Overview](../ado-net-overview.md)
