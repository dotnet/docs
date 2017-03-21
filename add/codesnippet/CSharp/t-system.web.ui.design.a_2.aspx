    <!-- Define a hyperlink that maps the NavigateUrl property to the
         MyHyperLinkSetting value in the Web.Config appSettings section. -->
    <asp:HyperLink runat="server" ID="HyperLink1" 
         NavigateUrl="<%$ AppSettings:MyHyperLinkSetting %>">
         HyperLink using an AppSetting expression
    </asp:HyperLink>