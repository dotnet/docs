<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Public Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        If Not IsPostBack Then
            ' Create data for the list
            Dim arr As New ArrayList()
            arr.Add(New _
                Task("Verify transactions", "Done"))
            arr.Add(New _
                Task("Check balance sheet", "Scheduled"))
            arr.Add(New _
                Task("Call customer", "Done"))
            arr.Add(New _
                Task("Issue checks", "Pending"))
            arr.Add(New _
                Task("Send report", "Pending"))
            arr.Add(New _
                Task("Attend meeting", "Scheduled"))
            
            ' Set properties for the list
            SelList1.SelectType = _
                ListSelectType.ListBox
            SelList1.Wrapping = Wrapping.NoWrap
            SelList1.DataValueField = "Status"
            SelList1.DataTextField  = "TaskName"
            SelList1.Rows = 3

            ' Bind the list to the data
            SelList1.DataSource = arr
            SelList1.DataBind ()

            Label1.Text = "Select an item and click the button."
            Label2.Text = "Tasks are arranged by priority"
        End If
    End Sub
    
    Private Sub ShowStatus(ByVal sender As Object, ByVal e As EventArgs)
        Const statusSpec As String = "Status: {0} is {1}"
        Const prioSpec As String = "Priority: {0}"
        
        ' Expand the list to show all items
        SelList1.Rows = SelList1.Items.Count

        ' Display the status
        Label1.Text = String.Format(statusSpec, _
            SelList1.Selection.Text, _
            SelList1.Selection.Value)
        ' Display the priority
        Label2.Text = String.Format(prioSpec, _
            (SelList1.SelectedIndex + 1))
    End Sub

    ' Custom class for the task data
    Class Task
        Private _TaskName As String
        Private _Status As String

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

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1">
        <mobile:Label runat="server" id="Label1" />
        <mobile:Label runat="server" id="Label2" />
        <mobile:SelectionList runat="server" id="SelList1" 
            OnSelectedIndexChanged="ShowStatus" />
        <mobile:Command ID="Command1" runat="server" 
            Text="Show Status" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
