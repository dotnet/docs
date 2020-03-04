<!-- Overview -->
<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Dim bakeryCount, dairyCount, produceCount As Integer

    Private Sub Page_Load(ByVal o As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            ' Create an array and bind it to the list
            Dim arr As New ArrayList()
            arr.Add(New GroceryItem _
                ("Bakery", "Rolls", "On Sale"))
            arr.Add(New GroceryItem _
                ("Dairy", "Eggnog", "Half price"))
            arr.Add(New GroceryItem _
                ("Produce", "Apples", _
                "A dollar a bushel"))
            arr.Add(New GroceryItem _
                ("Bakery", "Bread", "On Sale"))

            List1.DataSource = arr
            List1.DataBind()

            ' To show only one field on opening page,
            ' comment the next line
            List1.TableFields = "Item;Department"
            List1.LabelField = "Department"

            ' Display a report after items are databound
            Const txt As String = "Number of items by Department<br>Produce: " + _
                "{0}<br />Dairy: {1}<br />Bakery: {2}"
            TextView2.Text = String.Format(txt, produceCount, dairyCount, bakeryCount)
        End If
    End Sub

    ' Command event for buttons
    Private Sub List1_Click(ByVal sender As Object, _
        ByVal e As ObjectListCommandEventArgs)

        If e.CommandName = "Reserve" Then
            ActiveForm = Form2
        ElseIf e.CommandName = "Buy" Then
            ActiveForm = Form3
        Else
            ActiveForm = Form4
        End If
    End Sub

    '<Snippet4>
    ' Count items in each department
    Private Sub List1_ItemDataBind(ByVal sender As Object, ByVal e As ObjectListDataBindEventArgs)
        Select Case CType(e.DataItem, GroceryItem).Department
            Case "Bakery"
                bakeryCount += 1
            Case "Dairy"
                dairyCount += 1
            Case "Produce"
                produceCount += 1
        End Select
    End Sub
    '</Snippet4>

    '<Snippet2>
    Private Sub AllFields_Click(ByVal sender As Object, ByVal e As EventArgs)

        ActiveForm = Form5
        Dim spec As String = "{0}: {1}<br/>"
        Dim flds As IObjectListFieldCollection = List1.AllFields
        Dim i As Integer
        For i = 0 To flds.Count - 1
            TextView1.Text += _
                String.Format(spec, (i + 1), flds(i).Title)
        Next
    End Sub
    '</Snippet2>

    ' Structure for ArrayList records
    Private Class GroceryItem
        ' A private class for the Grocery List
        Private _department, _item, _status As String
        Public Sub New(ByVal department As String, _
            ByVal item As String, ByVal status As String)
            _department = department
            _item = item
            _status = status
        End Sub
        Public ReadOnly Property Department() As String
            Get
                Return _department
            End Get
        End Property
        Public ReadOnly Property Item() As String
            Get
                Return _item
            End Get
        End Property
        Public ReadOnly Property Status() As String
            Get
                Return _status
            End Get
        End Property
    End Class
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server" BackColor="LightBlue">
        <mobile:ObjectList id="List1" runat="server" 
            OnItemCommand="List1_Click" OnItemDataBind="List1_ItemDataBind">
            <DeviceSpecific ID="DeviceSpecific1" Runat="server">
                <!-- See Web.config for filters -->
                <Choice Filter="isWML11" CommandStyle-Font-Bold="NotSet" />
                <Choice CommandStyle-Font-Bold="true" 
                    CommandStyle-Font-Name="Arial" />
            </DeviceSpecific>
            <Command Name="Reserve" Text="Reserve" />
            <Command Name="Buy" Text="Buy" />
        </mobile:ObjectList>
        <mobile:Command ID="AllFieldsCmd" Runat="server" 
            OnClick="AllFields_Click">
            List All Fields</mobile:Command>
        <mobile:TextView ID="TextView2" Runat="server" />
    </mobile:Form>
    <mobile:Form id="Form2" runat="server" BackColor="LightBlue">
        <mobile:Label id="ResLabel" runat="server"
            text="Sale item reservation system coming soon!" />
        <mobile:Link id="ResLink" NavigateURL="#Form1" 
            runat="server" text="Return" />
    </mobile:Form>
    <mobile:Form id="Form3" runat="server" BackColor="LightBlue">
        <mobile:Label id="BuyLabel" runat="server"
            Text="Online purchasing system coming soon!" />
        <mobile:Link ID="BuyLink" NavigateURL="#Form1" 
            Runat="server" text="Return" />
    </mobile:Form>
    <mobile:Form id="Form4" Runat="server" BackColor="LightBlue">
        <mobile:Label ID="DefLabel" Runat="server" 
             Text="Detailed item descriptions will be here soon!"/>
        <mobile:Link ID="DefLink" NavigateURL="#Form1" 
            Runat="server" Text="Return" />
    </mobile:Form>
    <mobile:Form ID="Form5" Runat="server">
        <mobile:Label ID="Label1" Runat="server">
            List of AllFields:</mobile:Label>
        <mobile:TextView ID="TextView1" Runat="server" />
        <mobile:Link ID="Link1" Runat="server" NavigateUrl="#Form1" 
            Text="Return"></mobile:Link>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
