Public Class Form1

    ' <Snippet1>
    Dim db As New Northwnd("c:\linqtest3\northwnd.mdf")
    ' </Snippet1>

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' <Snippet2>
        ' Declare a variable to hold the contents of
        ' TextBox1 as an argument for the stored
        ' procedure.
        Dim parm As String = TextBox1.Text

        ' Declare a variable to hold the results returned
        ' by the stored procedure.
        Dim custQuery = db.CustOrdersDetail(parm)

        ' Clear the message box of previous results.
        Dim msg As String = ""
        Dim response As MsgBoxResult

        ' Execute the stored procedure and store the results.
        For Each custOrdersDetail As CustOrdersDetailResult In custQuery
            msg &= custOrdersDetail.ProductName & vbCrLf
        Next

        ' Display the results.
        If msg = "" Then
            msg = "No results."
        End If
        response = MsgBox(msg)

        ' Clear the variables before continuing.
        parm = ""
        TextBox1.Text = ""
        ' </Snippet2>

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ' <Snippet3>
        ' Comments in the code for Button2 are the same
        ' as for Button1.
        Dim parm As String = TextBox2.Text

        Dim custQuery2 = db.CustOrderHist(parm)
        Dim msg As String = ""
        Dim response As MsgBoxResult

        For Each custOrdHist As CustOrderHistResult In custQuery2
            msg &= custOrdHist.ProductName & vbCrLf
        Next

        If msg = "" Then
            msg = "No results."
        End If

        response = MsgBox(msg)
        parm = ""
        TextBox2.Text = ""
        ' </Snippet3>

    End Sub
End Class
