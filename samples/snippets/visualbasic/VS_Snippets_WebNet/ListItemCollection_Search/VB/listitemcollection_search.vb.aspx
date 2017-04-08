
<!---
The following example demonstrates the FindByText, FindByValue,
Insert(Int32,String), Insert(Int32,ListItem), and Add(String)
methods of the ListItemCollection class. The user can search for a
country or region by selecting an item in a drop-down list and giving
the corresponding input to the text box. The program starts searching
the ListBox by passing the string entered in the text box using
the FindByText or FindByValue methods. If a match is found it displays
the value and text of the corresponding ListItem. If no match is found it
gives the user the option of adding a ListItem to the ListBox.
-->


<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">  

    Dim ItemCollection As ListItemCollection

    Sub Search_CR(Sender As Object, e As EventArgs)
        try                
' <Snippet1>
' <Snippet2>
            Dim myListItem As ListItem = SearchType.SelectedItem
            Dim crItem As ListItem 
            Dim searchText As String  = TextBox1.Text
            If(myListItem.Value = "Name") Then
                If(TextBox1.Text <> "" ) Then        
                    Dim searchSubfirst As String = searchText.Substring(0,1)
                    Dim searchSubsecond As String = searchText.Substring(1)
                    searchText = searchSubfirst.ToUpper()+searchSubsecond.ToLower()
                    ' Search by country or region name.                       
                    crItem = ItemCollection.FindByText(searchText)    
                End If            
            Else
                'Search by country or region code.
                crItem = ItemCollection.FindByValue(searchText.ToUpper())
            End If
            
            Dim str As String  = "Search is successful. Match is Found.<br />"
            str = str & "The results for search string '" & searchText & "' are:<br />"
            str = str & "the country or region code is: " & crItem.Value & "<br />"
            str = str & "the country or region name is: " & crItem.Text
            ' Add the string to the label.
            Label1.Text = str
          
' </Snippet2>
' </Snippet1>
        catch ex As System.NullReferenceException
   
            Dim str1 As String = "Search failed. No Match Found.<br />"
            str1 = str1 & "The country or region you are " & _
                "searching for is not available.<br />"
            str1 = str1 & "If you want to add the country or region " & _
                "to the ListBox, enter the details here:"
            ' Add the string to the label.
            Label1.Text = str1

            ' Set the Web controls' visible properties to true.
            CodeLabel.Visible = true
            crCode.Text = ""
            crCode.Visible = true
            NameLabel.Visible = true
            crName.Text = ""
            crName.Visible = true
            Add.Visible = true
            Position.Visible = true
            PositionValue.Text = ""
            PositionValue.Visible = true 
        End Try
    End Sub   


    Sub Add_CR(Sender As Object, e As EventArgs)
        Dim myListItem As ListItem = new ListItem()
        try     
' <Snippet3>       
' <Snippet4>           
            Dim searchSubfirst As String = crName.Text.Substring(0,1).ToUpper()
            Dim searchSubsecond As String = crName.Text.Substring(1).ToLower()
            myListItem.Text = String.Concat(searchSubfirst,searchSubsecond)
            myListItem.Value = crCode.Text.ToUpper()
            Dim position As Integer = Convert.ToInt32(PositionValue.Text)
            If(crCode.Text = "") Then
                ItemCollection.Insert(position,crName.Text)
            Else
                ItemCollection.Insert(position,myListItem)
            End If                 
' </Snippet4>       
' </Snippet3>
        catch ex As System.FormatException                          
' <Snippet5>
            If(crCode.Text = "") Then
                ItemCollection.Add(crName.Text)
            Else
                ItemCollection.Add(myListItem)
            End If
' </Snippet5>
        End Try
    End Sub


    Sub Page_Load(Sender As Object, e As EventArgs) 
        ' Create the ItemCollection object.
        ItemCollection = Listbox1.Items
        Label1.Text =""
        ' Make the Web controls invisible.
        CodeLabel.Visible = False
        crCode.Visible = False
        NameLabel.Visible = False
        crName.Visible = False
        Add.Visible = False
        Position.Visible = False
        PositionValue.Visible = False
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>
                ListItemCollection Example
            </title>
</head>
    
    <body>
        <center>
            <h3>
                ListItemCollection Example
            </h3>
        </center>

        <form runat="server" id="Form1">
            <table style="text-align:center; background-color:#ffffcc">
                <tr>
                    <td colspan="3" align="center">
                        <b>list of countries and regions</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:ListBox id="Listbox1" runat="server">
                            <asp:ListItem Value="AU">Australia</asp:ListItem>
                            <asp:ListItem Value="BR">Brazil</asp:ListItem>
                            <asp:ListItem Value="BG">Bulgaria</asp:ListItem>
                            <asp:ListItem Value="CA">Canada</asp:ListItem>
                            <asp:ListItem Value="CN">China</asp:ListItem>
                            <asp:ListItem Value="EG">Egypt</asp:ListItem>
                            <asp:ListItem Value="FI">Finland</asp:ListItem>
                            <asp:ListItem Value="FR">France</asp:ListItem>
                            <asp:ListItem Value="DE">Germany</asp:ListItem>
                            <asp:ListItem Value="IN">India</asp:ListItem>
                            <asp:ListItem Value="JP">Japan</asp:ListItem>
                            <asp:ListItem Value="PE">Peru</asp:ListItem>
                            <asp:ListItem Value="RU">Russia</asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Select the type of Search
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:DropDownList id="SearchType" runat="server">
                        <asp:ListItem Value="Code">country or region code</asp:ListItem>
                        <asp:ListItem Value="Name">country or region name</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Enter the country or region name or code
                    </td>
                    <td>
                        <b>:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" Runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="Search" OnClick="Search_CR" Text="Search" Runat="server"></asp:Button>
                    </td>
                </tr>
            </table>
            
            <table style="text-align:center">
                <tr>
                    <td colspan="3">
                        <br />
                        <asp:Label id="Label1" Runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            
            <table style="border-width:0; text-align:center">
                <tr>
                    <td>
                        <asp:Label ID="CodeLabel" Visible="False" 
                            Text="Enter the country or region code:"
                            Runat="server" AssociatedControlID="crCode">
                            </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="crCode" Runat="server" 
                            Visible="False" > </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="NameLabel" Visible="False" 
                            Text="Enter the country or region name:" 
                            Runat="server" AssociatedControlID="crName">
                            </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="crName" Runat="server" 
                            Visible="False" Text="">
                            </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Position" Visible="False" 
                            Text="Enter the position for the new value:" 
                            Runat="server" AssociatedControlID="PositionValue">
                            </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="PositionValue" Runat="server" 
                            Visible="False" Text="">
                            </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="Add" Visible="False" Runat="server" 
                        OnClick="Add_CR" Text="Add To List"></asp:Button>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
