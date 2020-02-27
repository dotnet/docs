<!-- <snippet5> -->
<%@ Control Language="C#" ClassName="WebUserControl" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="UserInfoWebPartCS" %>

<aspSample:UserInfoWebPart 
  runat="server"   
  id="userinfo1" 
  title = "User Information WebPart"
  Description ="Contains custom, editable user information for display on a page." />
<aspSample:TextDisplayWebPart 
  runat="server"   
  id="TextDisplayWebPart1" 
  title = "Text Display WebPart" 
  Description="Contains a label where users can dynamically update the text." />
<!-- </snippet5> -->
