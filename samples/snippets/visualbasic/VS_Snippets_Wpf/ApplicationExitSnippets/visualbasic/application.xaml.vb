'<SnippetHandleExitCODEBEHIND>

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Windows
Imports System.IO
Imports System.IO.IsolatedStorage

Namespace VisualBasic
    Public Enum ApplicationExitCode
        Success = 0
        Failure = 1
        CantWriteToApplicationLog = 2
        CantPersistApplicationState = 3
    End Enum

    Partial Public Class App
        Inherits Application
        Private Sub App_Exit(ByVal sender As Object, ByVal e As ExitEventArgs)
            Try
                ' Write entry to application log
                If e.ApplicationExitCode = CInt(ApplicationExitCode.Success) Then
                    WriteApplicationLogEntry("Failure", e.ApplicationExitCode)
                Else
                    WriteApplicationLogEntry("Success", e.ApplicationExitCode)
                End If
            Catch
                ' Update exit code to reflect failure to write to application log
                e.ApplicationExitCode = CInt(ApplicationExitCode.CantWriteToApplicationLog)
            End Try

            ' Persist application state
            Try
                PersistApplicationState()
            Catch
                ' Update exit code to reflect failure to persist application state
                e.ApplicationExitCode = CInt(ApplicationExitCode.CantPersistApplicationState)
            End Try
        End Sub

        Private Sub WriteApplicationLogEntry(ByVal message As String, ByVal exitCode As Integer)
            ' Write log entry to file in isolated storage for the user
            Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly()
            Using stream As Stream = New IsolatedStorageFileStream("log.txt", FileMode.Append, FileAccess.Write, store)
                Using writer As New StreamWriter(stream)
                    Dim entry As String = String.Format("{0}: {1} - {2}", message, exitCode, Date.Now)
                    writer.WriteLine(entry)
                End Using
            End Using
        End Sub

        Private Sub PersistApplicationState()
            ' Persist application state to file in isolated storage for the user
            Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly()
            Using stream As Stream = New IsolatedStorageFileStream("state.txt", FileMode.Create, store)
                Using writer As New StreamWriter(stream)
                    For Each entry As DictionaryEntry In Me.Properties
                        writer.WriteLine(entry.Value)
                    Next entry
                End Using
            End Using
        End Sub
    End Class
End Namespace
'</SnippetHandleExitCODEBEHIND>