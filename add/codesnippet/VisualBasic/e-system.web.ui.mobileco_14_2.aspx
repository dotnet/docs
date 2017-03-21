<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<!-- The first Form -->
    <mobile:Form ID="Form1" Runat="server" 
        Paginate="true" OnActivate="Form_Activate" 
        OnPaginated="Form_Paginated">
        <mobile:link ID="Link1" Runat="server" 
            NavigateUrl="#Form2">
            Go To Other Form
        </mobile:link>
        <mobile:Label ID="Label1" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        <mobile:textview ID="txtView" Runat="server" />
        
        <mobile:DeviceSpecific ID="DevSpec" Runat="server">
            <Choice>
                <FooterTemplate>
                    <mobile:Label runat="server" id="lblCount" />
                </FooterTemplate>
            </Choice>
        </mobile:DeviceSpecific>

    </mobile:Form>
    
    <!-- The second Form -->
    <mobile:Form ID="Form2" Runat="server" 
        Paginate="true" OnPaginated="Form_Paginated">
        <mobile:Label ID="message2" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        <mobile:link ID="Link2" Runat="server" 
            NavigateUrl="#Form1">Back</mobile:link>
    </mobile:Form>
</body>
</html>