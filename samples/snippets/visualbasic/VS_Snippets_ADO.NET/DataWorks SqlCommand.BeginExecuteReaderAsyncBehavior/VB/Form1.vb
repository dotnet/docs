Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Public Class Form1
    ' Add this code to the form's class:
    ' You this delegate in order to fill the grid from
    ' a thread other than the form's thread. See the HandleCallback
    ' procedure for more information.
    Private Delegate Sub FillGridDelegate(ByVal reader As SqlDataReader)

    ' You need this delegate to update the status bar.
    Private Delegate Sub DisplayStatusDelegate(ByVal Text As String)

    ' This flag ensures that the user does not attempt
    ' to restart the command or close the form while the 
    ' asynchronous command is executing.
    Private isExecuting As Boolean

    Private Sub DisplayStatus(ByVal Text As String)
        Me.Label1.Text = Text
    End Sub

    Private Sub FillGrid(ByVal reader As SqlDataReader)
        Try
            Dim table As New DataTable
            table.Load(reader)
            Me.DataGridView1.DataSource = table
            DisplayStatus("Ready")

        Catch ex As Exception
            ' Because you are guaranteed this procedure
            ' is running from within the form's thread,
            ' it can directly interact with members of the form.
            DisplayStatus(String.Format("Ready (last attempt failed: {0})", ex.Message))
        Finally
            ' Closing the reader also closes the connection,
            ' because this reader was created using the 
            ' CommandBehavior.CloseConnection value.
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try
    End Sub

    Private Sub HandleCallback(ByVal result As IAsyncResult)
        Try
            ' Retrieve the original command object, passed
            ' to this procedure in the AsyncState property
            ' of the IAsyncResult parameter.
            Dim command As SqlCommand = CType(result.AsyncState, SqlCommand)
            Dim reader As SqlDataReader = command.EndExecuteReader(result)

            ' You may not interact with the form and its contents
            ' from a different thread, and this callback procedure
            ' is all but guaranteed to be running from a different thread
            ' than the form. Therefore you cannot simply call code that 
            ' fills the grid, like this:
            ' FillGrid(reader)

            ' Instead, you must call the procedure from the form's thread.
            ' One simple way to accomplish this is to call the Invoke
            ' method of the form, which calls the delegate you supply
            ' from the form's thread. 
            Dim del As New FillGridDelegate(AddressOf FillGrid)
            Me.Invoke(del, reader)

            ' Do not close the reader here, because it is being used in 
            ' a separate thread. Instead, have the procedure you have
            ' called close the reader once it is done with it.

        Catch ex As Exception
            ' Because you are now running code in a separate thread, 
            ' if you do not handle the exception here, none of your other
            ' code catches the exception. Because there is none of 
            ' your code on the call stack in this thread, there is nothing
            ' higher up the stack to catch the exception if you do not 
            ' handle it here. You can either log the exception or 
            ' invoke a delegate (as in the non-error case in this 
            ' example) to display the error on the form. In no case
            ' can you simply display the error without executing a delegate
            ' as in the Try block here. 

            ' You can create the delegate instance as you 
            ' invoke it, like this:
            Me.Invoke(New DisplayStatusDelegate(AddressOf DisplayStatus), _
             "Error: " & ex.Message)
        Finally
            isExecuting = False
        End Try
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file. 

        ' If you do not include the Asynchronous Processing=true name/value pair,
        ' you wo not be able to execute the command asynchronously.

        Return "Data Source=(local);Integrated Security=true;" & _
        "Initial Catalog=AdventureWorks; Asynchronous Processing=true"
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        If isExecuting Then
            MessageBox.Show(Me, "Already executing. Please wait until the current query " & _
             "has completed.")
        Else
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Try
                DisplayStatus("Connecting...")
                connection = New SqlConnection(GetConnectionString())
                ' To emulate a long-running query, wait for 
                ' a few seconds before retrieving the real data.
                command = New SqlCommand( _
                 "WAITFOR DELAY '0:0:5';" & _
                 "SELECT ProductID, Name, ListPrice, Weight FROM Production.Product", _
                 connection)
                connection.Open()

                DisplayStatus("Executing...")
                isExecuting = True
                ' Although it is not required that you pass the 
                ' SqlCommand object as the second parameter in the 
                ' BeginExecuteReader call, doing so makes it easier
                ' to call EndExecuteReader in the callback procedure.
                Dim callback As New AsyncCallback(AddressOf HandleCallback)
                command.BeginExecuteReader(callback, command, _
                  CommandBehavior.CloseConnection)

            Catch ex As Exception
                DisplayStatus("Error: " & ex.Message)
                If connection IsNot Nothing Then
                    connection.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isExecuting Then
            MessageBox.Show(Me, "Cannot close the form until " & _
             "the pending asynchronous command has completed. Please wait...")
            e.Cancel = True
        End If
    End Sub
End Class
' </Snippet1>
