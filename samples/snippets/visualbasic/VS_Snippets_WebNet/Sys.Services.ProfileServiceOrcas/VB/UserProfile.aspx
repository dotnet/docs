<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>Using Profile Service</title>
   <style type="text/css">
        body {  font: 11pt Trebuchet MS;
                padding-top: 72px;
                text-align: center }

        .text { font: 8pt Trebuchet MS }
    </style>
   
</head>
<body>

    <form id="form1" runat="server">
	
        <asp:ScriptManager runat="server" ID="ScriptManagerId">
            <Scripts>
                <asp:ScriptReference Path="Profile.js" />
            </Scripts>
        </asp:ScriptManager>
 
         
        <h2>Profile Service</h2>
	
	    <p>
	        You must log in first to set or get profile data. 
	        Create a new user, if needed. <br /> Refer to the Authentication example.
	    </p>
	     
		<div id="loginId" style="visibility:visible">
			<table id="loginForm">
				<tr>
					<td>User Name: </td>
					<td><input type="text" 
					    id="userId" name="userId" value=""/></td>
				</tr>
				
				<tr>
					<td>Password: </td>
					<td><input type="password" 
					    id="userPwd" name="userPwd" value="" /></td>
				</tr>
				
				<tr>
					<td><input type="button" 
					    id="login" name="login" value="Login" 
					        onclick="OnClickLogin()" /></td>
				</tr>
			</table>				
	
		</div>
		
		<div id="setProfProps" style="visibility:hidden">
			<input type="button" 
			value="Set Profile Properties" 
			onclick="SetProfileControlsVisibility('visible')"/> 
		</div>
		
		<div id="placeHolder" style="visibility:visible" />
		
		<br />
		
		
	    <input id="logoutId" type="button" 
	        value="Logout"  style="visibility:hidden"
	    onclick="OnClickLogout()" />
		
	
		<div id="setProfileProps" style="visibility:hidden">
			<table>
				<tr>
					<td>Foreground Color</td>
					<td><input type="text" id="fgcolor" 
					name="fgcolor" value=""/></td>
				</tr>
				
				<tr>
					<td>Background Color</td>
					<td><input type="text" id="bgcolor" 
					    name="bgcolor" value="" /></td>
				</tr>
				
				<tr>
					<td><input type="button" 
					id="saveProf" name="saveProf" 
					value="Save Profile Properties" 
					onclick="SaveProfile();" /></td>
				</tr>
			</table>		
		</div>	    
	
    </form>
  
</body>

</html>
<!-- </Snippet1> -->