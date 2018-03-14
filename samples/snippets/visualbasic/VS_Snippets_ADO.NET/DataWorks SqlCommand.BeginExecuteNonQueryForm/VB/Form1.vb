Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Public Class Form1
    ' Add this code to the form's class:
    ' You need this delegate in order to display text from a thread
    ' other than the form's thread. See the HandleCallback
    ' procedure for more information.
    ' This same delegate matches both the DisplayStatus 
    ' and DisplayResults methods.
    Private Delegate Sub DisplayInfoDelegate(ByVal Text As String)

    ' This flag ensures that the user does not attempt
    ' to restart the command or close the form while the 
    ' asynchronous command is executing.
    Private isExecuting As Boolean

    ' This example maintains the connection object 
    ' externally, so that it is available for closing.
    Private connection As SqlConnection

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,            
        ' you can retrieve it from a configuration file. 

        ' If you have not included "Asynchronous Processing=true" in the
        ' connection string, the command is not able
        ' to execute asynchronously.
        Return "Data Source=(local);Integrated Security=true;" & _
          "Initial Catalog=AdventureWorks; Asynchronous Processing=true"
    End Function

    Private Sub DisplayStatus(ByVal Text As String)
        Me.Label1.Text = Text
    End Sub

    Private Sub DisplayResults(ByVal Text As String)
        Me.Label1.Text = Text
        DisplayStatus("Ready")
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles Me.FormClosing
        If isExecuting Then
            MessageBox.Show(Me, "Cannot close the form until " & _
                "the pending asynchronous command has completed. Please wait...")
            e.Cancel = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        If isExecuting Then
            MessageBox.Show(Me, _
               "Already executing. Please wait until the current query " & _
                "has completed.")
        Else
            Dim command As SqlCommand
            Try
                DisplayResults("")
                DisplayStatus("Connecting...")
                connection = New SqlConnection(GetConnectionString())
                ' To emulate a long-running query, wait for 
                ' a few seconds before working with the data.
                ' This command does not do much, but that's the point--
                ' it does not change your data, in the long run.
                Dim commandText As String = _
                    "WAITFOR DELAY '0:0:05';" & _
                    "UPDATE Production.Product SET ReorderPoint = ReorderPoint + 1 " & _
                    "WHERE ReorderPoint Is Not Null;" & _
                    "UPDATE Production.Product SET ReorderPoint = ReorderPoint - 1 " & _
                    "WHERE ReorderPoint Is Not Null"

                command = New SqlCommand(commandText, connection)
                connection.Open()

                DisplayStatus("Executing...")
                isExecuting = True
                ' Although it is not required that you pass the 
                ' SqlCommand object as the second parameter in the 
                ' BeginExecuteNonQuery call, doing so makes it easier
                ' to call EndExecuteNonQuery in the callback procedure.
                Dim callback As New AsyncCallback(AddressOf HandleCallback)
                command.BeginExecuteNonQuery(callback, command)

            Catch ex As Exception
                isExecuting = False
                DisplayStatus(String.Format("Ready (last error: {0})", ex.Message))
                If connection IsNot Nothing Then
                    connection.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub HandleCallback(ByVal result As IAsyncResult)
        Try
            ' Retrieve the original command object, passed
            ' to this procedure in the AsyncState property
            ' of the IAsyncResult parameter.
            Dim command As SqlCommand = CType(result.AsyncState, SqlCommand)
            Dim rowCount As Integer = command.EndExecuteNonQuery(result)
            Dim rowText As String = " rows affected."
            If rowCount = 1 Then
                rowText = " row affected."
            End If
            rowText = rowCount & rowText

            ' You may not interact with the form and its contents
            ' from a different thread, and this callback procedure
            ' is all but guaranteed to be running from a different thread
            ' than the form. Therefore you cannot simply call code that 
            ' displays the results, like this:
            ' DisplayResults(rowText)

            ' Instead, you must call the procedure from the form's thread.
            ' One simple way to accomplish this is to call the Invoke
            ' method of the form, which calls the delegate you supply
            ' from the form's thread. 
            Dim del As New DisplayInfoDelegate(AddressOf DisplayResults)
            Me.Invoke(del, rowText)

        Catch ex As Exception
            ' Because you are now running code in a separate thread, 
            ' if you do not handle the exception here, none of your other
            ' code catches the exception. Because none of your code
            ' is on the call stack in this thread, there is nothing
            ' higher up the stack to catch the exception if you do not 
            ' handle it here. You can either log the exception or 
            ' invoke a delegate (as in the non-error case in this 
            ' example) to display the error on the form. In no case
            ' can you simply display the error without executing a delegate
            ' as in the Try block here. 

            ' You can create the delegate instance as you 
            ' invoke it, like this:
            Me.Invoke(New DisplayInfoDelegate(AddressOf DisplayStatus), _
                String.Format("Ready(last error: {0}", ex.Message))
        Finally
            isExecuting = False
            If connection IsNot Nothing Then
                connection.Close()
            End If
        End Try
    End Sub
End Class
' </Snippet1>
