<!-- <Snippet3> -->
<%@ control inherits = "SimpleControl" src = "SimpleControl.vb" %>

<table style="background-color: yellow; font: 10pt verdana;border-width:1;border-style:solid;border-color:black;" cellspacing="15">
<tr>
<td><b>Enter your name here: </b></td>
<td><ASP:TextBox id="name" runat="server"/></td>
</tr>
<tr>
<td><b><ASP:Label id="output" runat="server"/></b></td>
</tr>
<tr>
<td></td>
<td><asp:button text="Submit" OnClick="myButton_Click" runat="server" /></td>
</tr>
</table>
<!-- </Snippet3> -->
