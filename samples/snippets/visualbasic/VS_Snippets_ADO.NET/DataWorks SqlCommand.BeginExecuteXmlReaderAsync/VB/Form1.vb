Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
Imports System.Xml

Public Class Form1
    ' Add this code to the form's class:
    ' You need these delegates in order to display text from a thread
    ' other than the form's thread. See the HandleCallback
    ' procedure for more information.
    Private Delegate Sub DisplayInfoDelegate(ByVal Text As String)
    Private Delegate Sub DisplayReaderDelegate(ByVal reader As XmlReader)

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

    Private Sub ClearProductInfo()
        ' Clear the list box.
        Me.ListBox1.Items.Clear()
    End Sub

    Private Sub DisplayProductInfo(ByVal reader As XmlReader)
        ' Display the data within the reader.
        While reader.Read()
            ' Skip past items that are not from the correct table.
            If reader.LocalName.ToString = "Production.Product" Then
                Me.ListBox1.Items.Add(String.Format("{0}: {1:C}", _
                    reader("Name"), CSng(reader("ListPrice"))))
            End If
        End While
        DisplayStatus("Ready")
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isExecuting Then
            MessageBox.Show(Me, "Cannot close the form until " & _
                "the pending asynchronous command has completed. Please wait...")
            e.Cancel = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        If isExecuting Then
            MessageBox.Show(Me, "Already executing. Please wait until the current query " & _
                "has completed.")
        Else
            Dim command As SqlCommand
            Try
                ClearProductInfo()
                DisplayStatus("Connecting...")
                connection = New SqlConnection(GetConnectionString())
                ' To emulate a long-running query, wait for 
                ' a few seconds before working with the data.
                Dim commandText As String = _
                    "WAITFOR DELAY '00:00:03';" & _
                    "SELECT Name, ListPrice " & _
                    "FROM Production.Product WHERE ListPrice < 100 " & _
                    "FOR XML AUTO, XMLDATA"

                command = New SqlCommand(commandText, connection)
                connection.Open()

                DisplayStatus("Executing...")
                isExecuting = True
                ' Although it is not required that you pass the 
                ' SqlCommand object as the second parameter in the 
                ' BeginExecuteXmlReader call, doing so makes it easier
                ' to call EndExecuteXmlReader in the callback procedure.
                Dim callback As New AsyncCallback(AddressOf HandleCallback)
                command.BeginExecuteXmlReader(callback, command)

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
            Dim reader As XmlReader = command.EndExecuteXmlReader(result)

            ' You may not interact with the form and its contents
            ' from a different thread, and this callback procedure
            ' is all but guaranteed to be running from a different thread
            ' than the form. 

            ' Instead, you must call the procedure from the form's thread.
            ' One simple way to accomplish this is to call the Invoke
            ' method of the form, which calls the delegate you supply
            ' from the form's thread. 
            Dim del As New DisplayReaderDelegate(AddressOf DisplayProductInfo)
            Me.Invoke(del, reader)

        Catch ex As Exception
            ' Because you are now running code in a separate thread, 
            ' if you do not handle the exception here, none of your other
            ' code catches the exception. Because none of 
            ' your code is on the call stack in this thread, there is nothing
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
