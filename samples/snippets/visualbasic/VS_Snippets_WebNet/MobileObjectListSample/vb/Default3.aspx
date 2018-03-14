<!-- ShowItemCommands -->
<!-- <Snippet10> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    ' System.Web.UI.MobileControls.ObjectListItem item
    ' System.Web.UI.MobileControls.ObjectListItemCollection itemColl
    ' Get the persisted array through postbacks.
    Private arr As New ArrayList()
    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ' Create and fill the array
            arr.Add(new Task("Tomorrow's work", "Yes", 1))
            arr.Add(new Task("Today's work", "Yes", 1))
            arr.Add(new Task("Yesterday's work", "No", 1))
            
            ' Persist the array in the Session object
            Session("MyArrayList") = arr

            ' Associate and bind array to the 
            ' ObjectList for each postback.
            ObjectList1.DataSource = arr
            ObjectList1.LabelField = "TaskName"
            ObjectList1.DataBind()
            
        End If
    End Sub

    Private Sub SelectCommand(ByVal sender As Object, _
         ByVal e As ObjectListCommandEventArgs)
        ' Get the array from the Session object
        arr = CType(Session("MyArrayList"), ArrayList)

        ' Remove selected item from the ObjectLis
        Dim i As Integer = ObjectList1.SelectedIndex
        arr.RemoveAt(i)
        Session("MyArrayList") = arr

        ' Re-Bind ObjectList to altered ArrayList.
        ObjectList1.DataSource = arr
        ObjectList1.LabelField = "TaskName"
        ObjectList1.DataBind()
        ObjectList1.ViewMode = ObjectListViewMode.List
    End Sub

    Public Sub ShowTaskDetail(ByVal sender As Object, _
        ByVal e As ObjectListShowCommandsEventArgs)

        ' Check conditions, and add or remove 
        ' commands in the detail view.
        If e.ListItem("Editable").Equals("No") Then
            ObjectList1.Commands.RemoveAt(0)
        ElseIf ObjectList1.Commands.Count < 1 Then
            ObjectList1.Commands.Add(New ObjectListCommand("Delete", "Delete"))
        End If
    End Sub

    Private Class Task
        Private _TaskName As String
        Private _Editable As String
        Private _Days As Integer
        Public Sub New(ByVal TaskName As String, _
            ByVal Editable As String, ByVal Days As Integer)

            _TaskName = TaskName
            _Editable = Editable
            _Days = Days
        End Sub
        Public ReadOnly Property TaskName() As String
            Get
                Return _TaskName
            End Get
        End Property
        Public ReadOnly Property Editable() As String
            Get
                Return _Editable
            End Get
        End Property
        Public ReadOnly Property Days() As Integer
            Get
                Return _Days
            End Get
        End Property
    End Class
</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1" >
        <mobile:ObjectList runat="server" id="ObjectList1" 
            OnItemCommand="SelectCommand" OnShowItemCommands="ShowTaskDetail" >
            <Command Name="Delete" Text="Delete" />
        </mobile:ObjectList>
        <mobile:Label runat="server" id="Label1" />
        <mobile:Label runat="server" id="Label2" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet10> -->
