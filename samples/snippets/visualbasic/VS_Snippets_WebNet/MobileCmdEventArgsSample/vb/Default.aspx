<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ' Create array and add the tasks to it.
            Dim arr As New ArrayList()
            arr.Add(New Task("Verify transactions", "Done"))
            arr.Add(New Task("Check balance sheet", "Scheduled"))
            arr.Add(New Task("Send report", "Pending"))

            ' Bind the List to the ArrayList
            ObjectList1.DataSource = arr
            ObjectList1.DataBind()
        End If
        ObjectList1.DefaultCommand = "Check"
    End Sub

    ' Event handler for all ObjectList1 commands
    Private Sub SelectCommand(ByVal sender As Object, _
        ByVal e As ObjectListCommandEventArgs)
        
        If e.CommandName.ToString() = "Check" Then
            ActiveForm = Form2
        ElseIf e.CommandName.ToString() = "Browse" Then
            ActiveForm = Form3
        End If
    End Sub

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
    <mobile:form id="Form1" runat="server">
        <mobile:ObjectList runat="server" id="ObjectList1" 
            OnItemCommand="SelectCommand">
            <Command Name="Check" Text="Check Appointments" />
            <Command Name="Browse" Text="Browse Tasks" />
        </mobile:ObjectList>
    </mobile:form>
    <mobile:Form ID="Form2" Runat="server">
        <mobile:Label ID="Label1" Runat="server">
            Check Appointments</mobile:Label>
        <mobile:Link ID="Link1" Runat="server" 
            NavigateUrl="#Form1">Back</mobile:Link>
    </mobile:Form>
    <mobile:Form ID="Form3" Runat="server">
        <mobile:Label ID="Label2" Runat="server">
            Browse Tasks</mobile:Label>
        <mobile:Link ID="Link2" Runat="server" 
            NavigateUrl="#Form1">Back</mobile:Link>
    </mobile:Form>
</body>
</html>
