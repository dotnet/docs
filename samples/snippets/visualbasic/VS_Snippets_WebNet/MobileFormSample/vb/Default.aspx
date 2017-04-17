<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.UI.MobileControls" %>
<%@ Import Namespace="System.Drawing" %>

<script runat="server">
    ' When Form1 is activated
    Private Sub Form1_Activate(ByVal sender As Object, _
        ByVal e As EventArgs)
        Dim viewText As String = "You have viewed this Form {0} times."
        
        ' First viewing
        If (count = 0) Then
            message2.Text = "Welcome to the Form Sample"
        Else ' subsequent viewings
            message2.Text = String.Format(viewText, _
              (count + 1).ToString())
        End If
        
        ' Format the form
        Form1.Alignment = Alignment.Center
        Form1.Wrapping = Wrapping.NoWrap
        Form1.BackColor = Color.LightBlue
        Form1.ForeColor = Color.Blue
        Form1.Paginate = True

        ' Create an array and add the tasks to it.
        Dim arr As ArrayList = New ArrayList()
        arr.Add(New Task("Verify transactions", "Done"))
        arr.Add(New Task("Check balance sheet", "Scheduled"))
        arr.Add(New Task("Send report", "Pending"))

        ' Bind the SelectionList to the array.
        SelectionList1.DataValueField = "Status"
        SelectionList1.DataTextField = "TaskName"
        SelectionList1.DataSource = arr
        SelectionList1.DataBind()
    End Sub

    ' <Snippet2>
    ' When Form1 is deactivated
    Private Sub Form1_Deactivate(ByVal sender As Object, _
        ByVal e As EventArgs)

        count += 1
    End Sub
    ' </Snippet2>

    ' <Snippet3>
    ' When Form2 is activated
    Private Sub Form2_Activate(ByVal sender As Object, _
        ByVal e As EventArgs)
    
        Form2.BackColor = Color.DarkGray
        Form2.ForeColor = Color.White
        Form2.Font.Bold = BooleanOption.True
    End Sub
    ' </Snippet3>

    ' The the Submit button is clicked
    Protected Sub Command1_OnSubmit(ByVal sender As Object, _
        ByVal e As EventArgs)

        Dim i As Integer
        message2.Text = "FORM RESULTS:"
        message2.Font.Bold = BooleanOption.True

        ' Create a string and a TextView control
        Dim txtView As TextView = New TextView()
        Dim txt As String = ""
        Dim spec As String = "{0} is {1}<br />"
        
        ' Display a list of selected items with values
        For i = 0 To SelectionList1.Items.Count - 1
            ' Get the ListItem
            Dim itm As MobileListItem = SelectionList1.Items(i)
            
            ' List the selected items and values
            If itm.Selected Then
                txt &= String.Format(spec, itm.Text, itm.Value)
            End If
        Next
        
        ' Put the text into the TextView
        txtView.Text = txt
        ' Add the TextView to the form
        Form1.Controls.Add(txtView)
        
        ' Hide unnecessary controls
        SelectionList1.Visible = False
        link1.Visible = False
        Command1.Visible = False
    End Sub

    ' Property to persist the count between postbacks
    Private Property count() As Integer
        Get
            Dim o As Object = ViewState("FormCount")
            If IsNothing(o) Then
                Return 0
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("FormCount") = value
        End Set
    End Property

    ' A custom class for the task array
    Private Class Task
        Private _TaskName As String
        Private _Status As String

        Public Sub New(ByVal TaskName As String, ByVal Status As String)
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
    <!-- The first form: Form1 -->
    <mobile:Form ID="Form1" Runat="server"
        OnDeactivate="Form1_Deactivate" 
        OnActivate="Form1_Activate">
        <mobile:Label ID="message1" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        
        <mobile:Label ID="message2" Runat="server" />
        <mobile:SelectionList Runat="server" 
            ID="SelectionList1" 
            ForeColor="red" SelectType="CheckBox" />
        <mobile:Link ID="link1" Runat="server" 
            NavigateUrl="#Form2" 
            Text="Next Form" /><br />
        <mobile:Command ID="Command1" Runat="server" 
            Text="Submit" OnClick="Command1_OnSubmit" />
    </mobile:Form>

    <!-- The second form: Form2 -->
    <mobile:Form ID="Form2" Runat="server" 
        OnActivate="Form2_Activate">
        <mobile:Label ID="message4" Runat="server">
           Welcome to ASP.NET
        </mobile:Label> 
        <mobile:Link ID="Link2" Runat="server" 
            NavigateUrl="#Form1" Text="Back" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
