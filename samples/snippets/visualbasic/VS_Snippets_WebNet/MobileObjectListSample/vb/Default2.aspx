<!-- AutoGenerateFields -->
<!-- <Snippet5> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ' Create and fill the array.
            Dim arr As New ArrayList()
            arr.Add(New Task("Tomorrow's work", "Yes"))
            arr.Add(New Task("Today's work", "Yes"))
            arr.Add(New Task("Next week's work", "No"))

            ' Associate the array to List1.
            List1.DataSource = arr

            ' Turn off automatic field generation
            ' because fields were built by hand
            List1.AutoGenerateFields = False
            List1.DataBind()
        End If
    End Sub

    Private Class Task
        Private _TaskName As String
        Private _Editable As String
        Public Sub New(ByVal TaskName As String, ByVal Editable As String)
            _TaskName = TaskName
            _Editable = Editable
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
    End Class
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1">
        <mobile:ObjectList runat="server" id="List1" >
            <!-- Build the fields -->
            <Field Name="Task Name" DataField="TaskName" 
                Title="Name of Task" />
            <Field Name="Editable?" DataField="Editable" 
                Title="Is Editable?" />
        </mobile:ObjectList>
    </mobile:Form>
</body>
</html>
<!-- </Snippet5> -->
