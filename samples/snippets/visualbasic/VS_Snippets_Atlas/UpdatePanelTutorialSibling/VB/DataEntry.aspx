<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Enter New Employees</title>
    <script runat="server">
        Private EmployeeList As List(Of Employee)

        Protected Sub Page_Load()
            If Not IsPostBack Then
                EmployeeList = New List(Of Employee)
                EmployeeList.Add(New Employee(1, "Jump", "Dan"))
                EmployeeList.Add(New Employee(2, "Kirwan", "Yvette"))
                ViewState("EmployeeList") = EmployeeList
            Else
                EmployeeList = CType(ViewState("EmployeeList"), List(Of Employee))
            End If
            
            EmployeesGridView.DataSource = EmployeeList
            EmployeesGridView.DataBind()
        End Sub
        
        Protected Sub InsertButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            If String.IsNullOrEmpty(FirstNameTextBox.Text) Or _
               String.IsNullOrEmpty(LastNameTextBox.Text) Then Return
            
            Dim employeeID As Integer = EmployeeList(EmployeeList.Count - 1).EmployeeID + 1
            
            Dim lastName As String = Server.HtmlEncode(FirstNameTextBox.Text)
            Dim firstName As String = Server.HtmlEncode(LastNameTextBox.Text)
            
            FirstNameTextBox.Text = String.Empty
            LastNameTextBox.Text = String.Empty
            
            EmployeeList.Add(New Employee(employeeID, lastName, firstName))
            ViewState("EmployeeList") = EmployeeList
            
            EmployeesGridView.DataBind()
            EmployeesGridView.PageIndex = EmployeesGridView.PageCount
        End Sub
        
        Protected Sub CancelButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            FirstNameTextBox.Text = String.Empty
            LastNameTextBox.Text = String.Empty
        End Sub
        
        <Serializable()> _
        Public Class Employee
            Private _employeeID As Integer
            Private _lastName As String
            Private _firstName As String

            Public ReadOnly Property EmployeeID() As Integer
                Get
                    Return _employeeID
                End Get
            End Property
            
            Public ReadOnly Property LastName() As String
                Get
                    Return _lastName
                End Get
            End Property

            Public ReadOnly Property FirstName() As String
                Get
                    Return _firstName
                End Get
            End Property
            
            Public Sub New(ByVal employeeID As Integer, ByVal lastName As String, ByVal firstName As String)
                _employeeID = employeeID
                _lastName = lastName
                _firstName = firstName
            End Sub
        End Class

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
        <table>
            <tr>
                <td style="height: 206px" valign="top">
                    <asp:UpdatePanel ID="InsertEmployeeUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                          <table cellpadding="2" border="0" style="background-color:#7C6F57">
                            <tr>
                              <td><asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstNameTextBox" 
                                             Text="First Name" ForeColor="White" /></td>
                              <td><asp:TextBox runat="server" ID="FirstNameTextBox" /></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastNameTextBox" 
                                             Text="Last Name" ForeColor="White" /></td>
                              <td><asp:TextBox runat="server" ID="LastNameTextBox" /></td>
                            </tr>
                            <tr>
                              <td></td>
                              <td>
                                <asp:LinkButton ID="InsertButton" runat="server" Text="Insert" OnClick="InsertButton_Click" ForeColor="White" />
                                <asp:LinkButton ID="Cancelbutton" runat="server" Text="Cancel" OnClick="CancelButton_Click" ForeColor="White" />
                              </td>
                            </tr>
                          </table>
                          <asp:Label runat="server" ID="InputTimeLabel"><%=DateTime.Now %></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 206px" valign="top">
                    <asp:UpdatePanel ID="EmployeesUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="EmployeesGridView" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False">
                                <FooterStyle BackColor="Tan" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <Columns>
                                    <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                </Columns>
                                <PagerSettings PageButtonCount="5" />
                            </asp:GridView>
                            <asp:Label runat="server" ID="ListTimeLabel"><%=DateTime.Now %></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="InsertButton" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<!--</Snippet1>-->
