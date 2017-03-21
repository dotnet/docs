    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ' Set the DataMembers of the List
            List1.DataValueField = "Status"
            List1.DataTextField = "TaskName"

            ' Create an ArrayList of task data
            Dim arr As ArrayList = New ArrayList()
            arr.Add(New Task("Define transactions", "scheduled"))
            arr.Add(New Task("Verify transactions", "scheduled"))
            arr.Add(New Task("Check balance sheet", "scheduled"))
            arr.Add(New Task("Compile balance sheet", "scheduled"))
            arr.Add(New Task("Prepare report", "scheduled"))
            arr.Add(New Task("Send report", "scheduled"))
            
            ' Bind the array to the list
            List1.DataSource = arr
            List1.DataBind()

            Const spec As String = "Start: {0} tasks are done, {1} " & _
               "tasks are scheduled, and {2} tasks are pending."
            Label2.Text = String.Format(spec, doneCount, _
                schedCount, pendCount)

            List1.Decoration = ListDecoration.Bulleted
        End If
    End Sub