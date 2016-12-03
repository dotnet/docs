        ' To use this example, add a reference to the 
        '     Microsoft ActiveX Data Objects 2.8 Library  
        ' from the COM tab of the project references page.
        Dim WithEvents cn As New ADODB.Connection
        Sub ADODBConnect()
            cn.ConnectionString =
            "Provider=Microsoft.Jet.OLEDB.4.0;" &
            "Data Source=C:\NWIND.MDB"
            cn.Open()
            MsgBox(cn.ConnectionString)
        End Sub

        Private Sub Form1_Load(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles MyBase.Load

            ADODBConnect()
        End Sub

        Private Sub cn_ConnectComplete(
            ByVal pError As ADODB.Error,
            ByRef adStatus As ADODB.EventStatusEnum,
            ByVal pConnection As ADODB.Connection) Handles cn.ConnectComplete

            '  This is the event handler for the cn_ConnectComplete event raised 
            '  by the ADODB.Connection object when a database is opened.
            Dim x As Integer = 6
            Dim y As Integer = 0
            Try
                x = CInt(x / y) ' Attempt to divide by zero.
                ' This procedure would fail silently without exception handling.
            Catch ex As Exception
                MsgBox("There was an error: " & ex.Message)
            End Try
        End Sub