<!-- <Snippet5> -->
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProfileInfo.aspx.vb" Inherits="ProfileInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Profile Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Current Authenticated User Profile Information</h3> 

        <a href="Default.aspx">back to default page</a>

        <h4>Read Profile Information</h4>
        <table>
            <tr>
                <td align="left">User Name</td>
                <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Label"/>
                </td>
            </tr>
            <tr>
                <td align="left">User Roles</td>
                <td align="left">
                    <asp:Label ID="Label2" runat="server" Text="Label"/>
                </td>
            </tr>
            <tr>
                <td align="left">First Name</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label"/>
                </td>
            </tr>
            <tr>
                <td align="left">Last Name</td>
                <td>    
                    <asp:Label ID="Label4" runat="server" Text="Label"/>
                </td>
            </tr>
            <tr>
                <td align="left">Phone #</td>
                <td>    
                    <asp:Label ID="Label5" runat="server" Text="Label"/>
                </td>
            </tr>

        </table>
	    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
		    Text="Read Profile Information" />
	    
	    <hr />
	    
		<h3>Update Profile Information </h3>

		<table>
		    <tr>
		        <td align="left">First Name</td>
		        <td align="left"><asp:TextBox ID="TextBox1" runat="server"/></td>
		    </tr>
		    <tr>
		        <td align="left">Last Name</td>
		        <td align="left"><asp:TextBox ID="TextBox2" runat="server"/></td>
		    </tr>
		    <tr>
		        <td align="left">Phone Number</td>
		        <td align="left"><asp:TextBox ID="TextBox3" runat="server"/></td>
		    </tr>
		   
		</table>
    	
    	<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
		Text="Update Profile Data" />
		
    </div>
    </form>
</body>
</html>
<!-- </Snippet5> -->