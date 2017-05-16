<!-- <Snippet1> -->
<%@ Page Language="VB"  Title="Using Roles Service" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>Using Roles Service</title>
    <style type="text/css">
        body {  font: 11pt Trebuchet MS;
                padding-top: 72px;
                text-align: center }

        .text { font: 8pt Trebuchet MS }
    </style>

<script language="javascript" type="text/jscript">



</script>


</head>
<body>

    <form id="form1" runat="server">
         
        <h2>Access Authenticated User's Roles</h2>
	    Using the Sys.Services.RoleService client type to obtain roles information.

	    <p>
	        You must be authenticated to access roles information. <br /> 
	        Refer to the Forms Authentication example.
	    </p>
	
	   <asp:ScriptManager runat="server" ID="ScriptManagerId">
            <Scripts>
                <asp:ScriptReference Path="Roles.js" />
            </Scripts>
        </asp:ScriptManager>
 
        <hr />
        <table>
	        <tr>
			    <td align="left">User's roles: </td>
			    <td align="left"> 
			        <input type="button" id="UserRoles" 
					       onclick="ReadUserRoles(); return false;" 
					       value="UserRoles" />
		        </td>
			</tr>
			<tr>
			    <td align="left">Is User in Administrators Role?: </td>
				<td align="left" >
				    <input type="button" id="UserInRole" 
					       onclick="UserIsInRole('Administrators'); return false;" 
					       value="Check Role" /></td>
			</tr>
			
			<tr>
			    <td align="left">Role Service path: </td>
				<td align="left">
				    <input type="button" id="ServicePathId" 
					       onclick="GetRoleServicePath(); return false;" 
					       value="Role Service Path" /></td>
			</tr>

			<tr>
			    <td align="left">Role Service timeout: </td>
				<td align="left">
				    <input type="button" id="ServiceTimeoutId" 
					       onclick="GetRoleServiceTimeout(); return false;" 
					       value="Role Service Timeout" /></td>
			</tr>
				
		</table>				
        
    </form>
    
    <div id="placeHolder" ></div>
</body>

</html>
<!-- </Snippet1> -->
