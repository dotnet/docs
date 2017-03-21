    <!-- Define a hyperlink that maps the Text property to the
         myLinkText string value in the Strings.resx resource file. -->
    <asp:HyperLink runat="server" ID="HyperLink2" 
         Text="<%$ Resources:Strings, myLinkText%>"
         NavigateUrl="http://www.microsoft.com"></asp:HyperLink>