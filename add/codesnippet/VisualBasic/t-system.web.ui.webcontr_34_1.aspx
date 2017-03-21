      <asp:ListView ID="ContactsListView" 
        DataSourceID="ContactsDataSource" 
        DataKeyNames="ContactID"
        OnItemInserted="ContactsListView_ItemInserted"  
        InsertItemPosition="LastItem"
        runat="server">
        <LayoutTemplate>
          <table cellpadding="2" border="1" runat="server" id="tblContacts" width="640px">
            <tr runat="server" id="itemPlaceholder" />
          </table>
          <asp:DataPager runat="server" ID="PeopleDataPager" PageSize="12">
            <Fields>
              <asp:NextPreviousPagerField 
                ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
          <tr runat="server">
            <td valign="top">
              <asp:Label ID="FirstNameLabel" runat="server" Text='<%#Eval("FirstName") %>' />
              <asp:Label ID="LastNameLabel" runat="server" Text='<%#Eval("LastName") %>' />
            </td>
            <td>&nbsp;
              <asp:Label ID="EmailLabel" runat="server" Text='<%#Eval("EmailAddress") %>' />
            </td>
          </tr>
        </ItemTemplate>
        <InsertItemTemplate>
          <tr style="background-color:#D3D3D3">
            <td valign="top">
              <asp:Label runat="server" ID="FirstNameLabel" 
                AssociatedControlID="FirstNameTextBox" Text="First Name"/>
              <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%#Bind("FirstName") %>' /><br />
              <asp:Label runat="server" ID="LastNameLabel" 
                AssociatedControlID="LastNameTextBox" Text="Last Name" />
              <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%#Bind("LastName") %>' /><br />
              <asp:Label runat="server" ID="EmailLabel" 
                AssociatedControlID="EmailTextBox" Text="E-mail" />
              <asp:TextBox ID="EmailTextBox" runat="server" 
                Text='<%#Bind("EmailAddress") %>' />
            </td>
            <td>
              <asp:LinkButton ID="InsertButton" runat="server" 
                CommandName="Insert" Text="Insert" />
            </td>
          </tr>
        </InsertItemTemplate>
      </asp:ListView>