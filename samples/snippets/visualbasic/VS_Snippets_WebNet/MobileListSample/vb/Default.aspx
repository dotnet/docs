<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    ' Persist across multiple postbacks.
    Private Shared doneCount, schedCount, pendCount As Integer

    ' <Snippet3>
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
    ' </Snippet3>

    ' <Snippet2>
    Private Sub Status_ItemCommand(ByVal sender As Object, _
        ByVal e As ListCommandEventArgs)

        Const spec As String = "You now have {0} tasks done, {1} " & _
            "tasks scheduled, and {2} tasks pending."

        ' Move selection to next status toward 'done'
        Select Case e.ListItem.Value
            Case "scheduled"
                schedCount -= 1
                pendCount += 1
                e.ListItem.Value = "pending"
            Case "pending"
                pendCount -= 1
                doneCount += 1
                e.ListItem.Value = "done"
                
        End Select

        ' Show the status of the current task
        Label1.Text = e.ListItem.Text & " is " & _
            e.ListItem.Value

        ' Show current selection counts
        Label2.Text = String.Format(spec, doneCount, _
            schedCount, pendCount)
    End Sub
    ' </Snippet2>

    ' <Snippet4>
    Private Sub Status_DataBinding(ByVal sender As Object, _
        ByVal e As ListDataBindEventArgs)

        ' Increment initial counts
        Select Case e.ListItem.Value
            Case "done"
                doneCount += 1
            Case "scheduled"
                schedCount += 1
            Case "pending"
                pendCount += 1
        End Select
    End Sub
    ' </Snippet4>
    
    ' Custom class for the ArrayList items
    Private Class Task
        Private _TaskName, _Status As String
        
        Public Sub New(ByVal TaskName As String, _
            ByVal Status As String)

            _TaskName = TaskName
            _Status = Status
        End Sub
        Public ReadOnly Property TaskName() As String
            Get
                Return _TaskName
            End Get
        End Property
        Public ReadOnly Property Status() As String
            Get
                Return _Status
            End Get
        End Property
    End Class
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label ID="Label3" Runat="server">
            Click a task to change its status from 
            scheduled to pending or from pending to done:
        </mobile:Label>
        <mobile:List runat="server" id="List1" 
            OnItemCommand="Status_ItemCommand" 
            OnItemDataBind="Status_DataBinding" />
        <mobile:Label runat="server" id="Label1" 
            ForeColor="green" Font-Italic="true" />
        <mobile:Label id="Label2" runat="server" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
