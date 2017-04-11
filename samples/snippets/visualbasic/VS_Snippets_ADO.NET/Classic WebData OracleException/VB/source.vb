Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OracleClient
Imports System.Data.Common
Imports Microsoft.VisualBasic

Public class Sample


' <Snippet1>
 Public Sub ShowOracleException() 
 
    Dim myConnection As OracleConnection = _
       New OracleConnection("Data Source=Oracle8i;Integrated Security=yes")

    Try 

       myConnection.Open()

    Catch e As OracleException

      Dim errorMessage As String = "Code: " & e.Code & vbCrLf & _
                                   "Message: " & e.Message

      Dim log As System.Diagnostics.EventLog = New System.Diagnostics.EventLog()
      log.Source = "My Application"
      log.WriteEntry(errorMessage)
      Console.WriteLine("An exception occurred. Please contact your system administrator.")

    End Try
 End Sub
' </Snippet1>

End Class